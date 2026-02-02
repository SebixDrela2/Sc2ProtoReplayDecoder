using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.Json.Generator;

public class Sc2GeneratorData
{
    public required string ProtocolName;
    public required bool IsLatestProtocol;

    public required Dictionary<string, string> EnumTags;
    public required IReadOnlyList<JsonNode> ByteAligned;
    public required IReadOnlyList<JsonNode> BitPacked;

    public StringBuilder ParserGenerator = new StringBuilder();
}