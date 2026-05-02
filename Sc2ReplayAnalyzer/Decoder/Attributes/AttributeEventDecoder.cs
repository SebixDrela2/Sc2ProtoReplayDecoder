using System.Text;

namespace Sc2ReplayAnalyzer.Decoder.Attributes;

public class AttributeEventParser
{
    private const int GlobalScope = 16;

    private const int PrivacyOption = 4000;
    private const int PartiesPrivate = 2000;
    private const int GameSpeed = 3000;
    private const int LobbyDelay = 3006;
    private const int IsPremadeGame = 1001;
    private const int GameMode = 3009;
    private const int GameDuration = 3015;
    private const int Rules = 1000;
    private const int LockedAlliances = 3010;
    private const int PartiesPremade = 2001;

    private static readonly Dictionary<string, string> GameSpeedMap = new()
    {
        ["Fasr"] = "Faster",
        ["Fast"] = "Fast",
        ["Norm"] = "Normal",
        ["Slow"] = "Slow",
        ["Slower"] = "Slower"
    };

    private static readonly Dictionary<string, string> GameModeMap = new()
    {
        ["Pub"] = "Public",
        ["Priv"] = "Private",
        ["Cust"] = "Custom"
    };

    private static readonly Dictionary<string, string> RulesMap = new()
    {
        ["Dflt"] = "Default",
        ["Cust"] = "Custom"
    };

    private static readonly Dictionary<string, string> PrivacyMap = new()
    {
        ["Norm"] = "Normal",
        ["Public"] = "Public",
        ["Private"] = "Private",
        ["Open"] = "Open"
    };

    public ReplayAttributes ParseGlobalAttributes(byte[] attributeData)
    {
        var builder = new GameAttributesBuilder();
        var buffer = new BitPackedLittleEndianBuffer(attributeData);

        if (buffer.Done())
        {
            return builder.Build();
        }

        buffer.ReadUnalignedBytes(9); // SKIP SCOPE

        while (!buffer.Done())
        {
            buffer.ReadBits(32);

            var attrid = buffer.ReadBits(32);
            var scope = buffer.ReadBits(8);

            var rawBytes = buffer.ReadAlignedBytes(4);
            Array.Reverse(rawBytes);

            var rawValue = StripNullSpan(rawBytes);

            if (scope == GlobalScope)
            {
                ProcessGlobalAttribute(attrid, rawValue, ref builder);
            }
        }

        return builder.Build();
    }

    private static void ProcessGlobalAttribute(int attrid, ReadOnlySpan<byte> rawValue, ref GameAttributesBuilder builder)
    {
        Span<byte> valueCopy = stackalloc byte[rawValue.Length];
        rawValue.CopyTo(valueCopy);

        var asString = Encoding.ASCII.GetString(valueCopy).TrimEnd('\0');

        var isNumeric = int.TryParse(asString, out var intValue);

        if (isNumeric && rawValue.Length >= 4)
        {
            Span<byte> intBytes = stackalloc byte[4];
            rawValue[..4].CopyTo(intBytes);

            intValue = BitConverter.ToInt32(intBytes);
        }

        Console.WriteLine($"attrid: {attrid}: {(isNumeric ? intValue : asString)}");

        object result = attrid switch
        {
            PrivacyOption => builder.PrivacyOption = PrivacyMap.TryGetValue(asString, out var privacy) ? privacy : asString,
            PartiesPrivate => builder.PartiesPrivate = asString,
            GameSpeed => builder.GameSpeed = GameSpeedMap.TryGetValue(asString, out var speed) ? speed : asString,
            LobbyDelay => builder.LobbyDelay = isNumeric ? intValue : 0,
            IsPremadeGame => builder.IsPremadeGame = asString.Equals("yes", StringComparison.OrdinalIgnoreCase),
            GameMode => builder.GameMode = GameModeMap.TryGetValue(asString, out var mode) ? mode : asString,
            GameDuration => builder.GameDuration = isNumeric ? intValue : 0,
            Rules => builder.Rules = RulesMap.TryGetValue(asString, out var rule) ? rule : asString,
            LockedAlliances => builder.LockedAlliances = asString.Equals("yes", StringComparison.OrdinalIgnoreCase),
            PartiesPremade => builder.PartiesPremade = asString,
            _ => 0
        };
    }

    private static ReadOnlySpan<byte> StripNullSpan(byte[] data)
    {
        var start = 0;

        while (start < data.Length && data[start] == 0)
        {
            start++;
        }

        var end = data.Length - 1;

        while (end >= start && data[end] == 0)
        {
            end--;
        }

        return start > end
            ? []
            : new ReadOnlySpan<byte>(data, start, end - start + 1);
    }

    private struct GameAttributesBuilder
    {
        public string PrivacyOption;
        public string PartiesPrivate;
        public string GameSpeed;
        public int LobbyDelay;
        public bool IsPremadeGame;
        public string GameMode;
        public int GameDuration;
        public string Rules;
        public bool LockedAlliances;
        public string PartiesPremade;

        public readonly ReplayAttributes Build() => new()
        {
            PrivacyOption = PrivacyOption ?? "Unknown",
            PartiesPrivate = PartiesPrivate ?? "Unknown",
            GameSpeed = GameSpeed ?? "Unknown",
            LobbyDelay = LobbyDelay,
            IsPremadeGame = IsPremadeGame,
            GameMode = GameMode ?? "Unknown",
            GameDuration = GameDuration,
            Rules = Rules ?? "Unknown",
            LockedAlliances = LockedAlliances,
            PartiesPremade = PartiesPremade ?? "Unknown",
        };
    }
}