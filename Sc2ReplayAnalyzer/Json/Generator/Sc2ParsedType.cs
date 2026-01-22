
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.Json.Generator;

public class Sc2ParsedStructType
{
    public string UnitTypeName;
    public string UnitType;

    public Sc2MethodInfo Sc2MethodInfo;
}

public class Sc2MethodInfo
{
    public JsonNode Module;
}
