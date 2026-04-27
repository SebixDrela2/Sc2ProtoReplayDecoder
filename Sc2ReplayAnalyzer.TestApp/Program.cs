using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.TestApp;
using Sc2ReplayAnalyzer.Tokenizer;

internal class Program
{
    private static readonly Sc2JsonProvider _provider = new Sc2JsonProvider();

    private const ProtoRunType RunChoice = ProtoRunType.Decode;

    private const string ReplaysPath = @"C:\Users\Sebastian\replays";

    internal static void Main(string[] args)
    {
        Action action = RunChoice switch
        {
            ProtoRunType.Decode => Decode,
            ProtoRunType.Generate => Generate,
            var runChoice => throw new InvalidOperationException()
        };

        action();
    }

    private static void Generate()
    {
        var jsonFiles = _provider.Provide();
        var jsonParser = new ProtocolJsonParser(jsonFiles);
        var dataList = jsonParser.Parse();

        foreach(var data in dataList)
        {
            var generator = new SharedProtocolGenerator(data);
            generator.Generate();
        }
    }


    private static void Decode()
    {
        var path = @"C:\Users\Sebastian\Downloads\Oh_No_Its_Zombies_Subterranean_Map_123.SC2Replay";
        var decoder = new ReplayDecoder();
        var replay = decoder.DecodeReplay(path);

        // First, understand what loops exist
        var maxLoop = replay.GameEvents.Gameevents.Any()
            ? replay.GameEvents.Gameevents.Max(x => x.Gameloop)
            : 0;

        var minLoop = replay.GameEvents.Gameevents.Any()
            ? replay.GameEvents.Gameevents.Min(x => x.Gameloop)
            : 0;

        Console.WriteLine($"Game loop range: {minLoop} to {maxLoop}");
        Console.WriteLine($"Total game events: {replay.GameEvents.Gameevents.Count}");
        Console.WriteLine($"Total position events: {replay.TrackerEvents.SUnitPositionsEvents.Count()}");

        // Check if there are ANY position events at all
        if (!replay.TrackerEvents.SUnitPositionsEvents.Any())
        {
            Console.WriteLine("\nWARNING: No position events found in this replay!");
            Console.WriteLine("This replay may not have unit position tracking enabled.");
            return;
        }

        // Find the actual loop range for position events
        var posLoops = replay.TrackerEvents.SUnitPositionsEvents.Select(x => x.Gameloop).ToList();
        Console.WriteLine($"Position event loops: {posLoops.Min()} to {posLoops.Max()}");
        Console.WriteLine($"Total position events: {posLoops.Count}");

        // Now find ALL units that ever moved, regardless of loop
        Console.WriteLine("\nScanning ALL units that moved at ANY time:");

        var unitPositions = new Dictionary<int, List<(int x, int y, long loop)>>();

        foreach (var posEvent in replay.TrackerEvents.SUnitPositionsEvents.OrderBy(x => x.Gameloop))
        {
            for (int i = 0; i < posEvent.Ints.Length / 2; i++)
            {
                int unitIndex = posEvent.FirstUnitIndex + i;
                int x = posEvent.Ints[i * 2];
                int y = posEvent.Ints[i * 2 + 1];

                if (!unitPositions.ContainsKey(unitIndex))
                    unitPositions[unitIndex] = new List<(int, int, long)>();

                unitPositions[unitIndex].Add((x, y, posEvent.Gameloop));
            }
        }

        Console.WriteLine($"Total unique units with position data: {unitPositions.Count}");

        // Find units that moved (position changed between first and last recorded position)
        var movingUnits = new List<(int unitIndex, double distance, long startLoop, long endLoop, int startX, int startY, int endX, int endY)>();

        foreach (var unit in unitPositions)
        {
            if (unit.Value.Count < 2) continue;

            var first = unit.Value.First();
            var last = unit.Value.Last();
            double distance = Math.Sqrt(Math.Pow(last.x - first.x, 2) + Math.Pow(last.y - first.y, 2));

            if (distance > 1) // Any movement at all
            {
                movingUnits.Add((unit.Key, distance, first.loop, last.loop, first.x, first.y, last.x, last.y));
            }
        }

        movingUnits = movingUnits.OrderByDescending(x => x.distance).ToList();

        Console.WriteLine($"\nFound {movingUnits.Count} units that moved:");
        foreach (var moving in movingUnits.Take(20)) // Top 20 moving units
        {
            Console.WriteLine($"  Unit {moving.unitIndex}: Moved {moving.distance:F1} units (loops {moving.startLoop} -> {moving.endLoop})");
            Console.WriteLine($"    From ({moving.startX},{moving.startY}) to ({moving.endX},{moving.endY})");
        }

        // Check specifically if any train units are in the moving units
        int[] trainUnitIndexes = { 17563649, 58195969, 84148225, 97517569, 115081217, 120586241,
                               124256257, 160169985, 160432129, 169345025, 224919553, 241696769,
                               252444673, 300417025, 335544321, 337379329 };

        Console.WriteLine("\nChecking if train units moved:");
        foreach (var trainIdx in trainUnitIndexes)
        {
            var movingUnit = movingUnits.FirstOrDefault(x => x.unitIndex == trainIdx);
            if (movingUnit.unitIndex != 0)
            {
                Console.WriteLine($"  ✓ TRAIN UNIT {trainIdx} MOVED! Distance: {movingUnit.distance:F1}");
            }
            else if (unitPositions.ContainsKey(trainIdx))
            {
                var positions = unitPositions[trainIdx];
                Console.WriteLine($"  Train unit {trainIdx} has position data but didn't move (stayed at {positions.First().x},{positions.First().y})");
            }
            else
            {
                Console.WriteLine($"  ✗ Train unit {trainIdx} has NO position data at all");
            }
        }

        // If train units have position data, track their movement over time
        foreach (var trainIdx in trainUnitIndexes)
        {
            if (unitPositions.ContainsKey(trainIdx))
            {
                Console.WriteLine($"\n=== Tracking Train Unit {trainIdx} ===");
                var positions = unitPositions[trainIdx].OrderBy(x => x.loop).ToList();

                bool startedMoving = false;
                int lastX = positions[0].x;
                int lastY = positions[0].y;

                for (int i = 1; i < positions.Count; i++)
                {
                    if (positions[i].x != lastX || positions[i].y != lastY)
                    {
                        if (!startedMoving)
                        {
                            startedMoving = true;
                            Console.WriteLine($"  >>> TRAIN STARTED MOVING at loop {positions[i].loop} <<<");
                            Console.WriteLine($"      From ({lastX},{lastY}) to ({positions[i].x},{positions[i].y})");
                        }
                        else
                        {
                            Console.WriteLine($"      Loop {positions[i].loop}: Train at ({positions[i].x},{positions[i].y})");
                        }
                        lastX = positions[i].x;
                        lastY = positions[i].y;
                    }
                }

                if (!startedMoving)
                {
                    Console.WriteLine($"  Train never moved (always at {positions[0].x},{positions[0].y})");
                }
            }
        }
    }
}