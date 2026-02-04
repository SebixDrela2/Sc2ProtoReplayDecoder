using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Running;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Decoder.APIModel;

[EtwProfiler] 
[MemoryDiagnoser]
public class RecoderGen
{
    private const string ReplaysPath = @"C:\Users\Sebastian\replays";

    private readonly byte[][] _100Replays = [];

    public RecoderGen()
    {
        _100Replays = [.. Directory
            .GetFiles(ReplaysPath)
            .Take(100)
            .Select(File.ReadAllBytes)];
    }

    [Benchmark]
    public Sc2Replay[] ReplayGen()
    {
        var decoder = new ReplayDecoder();
        var replays = new Sc2Replay[_100Replays.Length];
        var count = 0;

        foreach(var file in _100Replays)
        {
            using var memoryStream = new MemoryStream(file);
            replays[count] = decoder.DecodeReplay(memoryStream);

            ++count;
        }

        return replays;
    }    
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<RecoderGen>();
    }
}