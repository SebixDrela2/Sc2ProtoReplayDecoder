using Sc2ReplayAnalyzer.Global;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
using Sc2ReplayAnalyzer.Decoder.Factory;

namespace Sc2ReplayAnalyzer.Json.protocol70154.Versioned;

public class VersionedProtocolParser(BinaryReader reader) : VersionedProtocolParserImpl(reader), IVersionedProtocolParser
{

    public SVarUint32 Parse_SVarUint32() 
    {
        ValidateChoiceTag();
        var variantTag = ParseVlqInt();
        
        switch (variantTag)
        {
            case 0:
            {
                var res = tagged_vlq_int();
                return new m_uint6
                {
                    Value = ProtocolConversion<u8>.From(res)
                };
            }
            case 1:
            {
                var res = tagged_vlq_int();
                return new m_uint14
                {
                    Value = ProtocolConversion<u32>.From(res)
                };
            }
            case 2:
            {
                var res = tagged_vlq_int();
                return new m_uint22
                {
                    Value = ProtocolConversion<u32>.From(res)
                };
            }
            case 3:
            {
                var res = tagged_vlq_int();
                return new m_uint32
                {
                    Value = ProtocolConversion<u32>.From(res)
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public SVersion Parse_SVersion() 
    {
        Option<u8> m_flags = Option.None;
        Option<u8> m_major = Option.None;
        Option<u8> m_minor = Option.None;
        Option<u8> m_revision = Option.None;
        Option<u32> m_build = Option.None;
        Option<u32> m_baseBuild = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_flags is { HasValue: false })                           
                    {
                        var parsed_m_flags = Parse_SVersion_m_flags();
                        m_flags = Option.Some(parsed_m_flags);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_major is { HasValue: false })                           
                    {
                        var parsed_m_major = Parse_SVersion_m_major();
                        m_major = Option.Some(parsed_m_major);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_minor is { HasValue: false })                           
                    {
                        var parsed_m_minor = Parse_SVersion_m_minor();
                        m_minor = Option.Some(parsed_m_minor);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_revision is { HasValue: false })                           
                    {
                        var parsed_m_revision = Parse_SVersion_m_revision();
                        m_revision = Option.Some(parsed_m_revision);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_build is { HasValue: false })                           
                    {
                        var parsed_m_build = Parse_SVersion_m_build();
                        m_build = Option.Some(parsed_m_build);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_baseBuild is { HasValue: false })                           
                    {
                        var parsed_m_baseBuild = Parse_SVersion_m_baseBuild();
                        m_baseBuild = Option.Some(parsed_m_baseBuild);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new SVersion
        {   
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
            m_major = Option.OkOrReturnMissingFieldErr(m_major),
            m_minor = Option.OkOrReturnMissingFieldErr(m_minor),
            m_revision = Option.OkOrReturnMissingFieldErr(m_revision),
            m_build = Option.OkOrReturnMissingFieldErr(m_build),
            m_baseBuild = Option.OkOrReturnMissingFieldErr(m_baseBuild),
        };
    }
    public u8 Parse_SVersion_m_flags()
    {                             
        var m_flags = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_flags);
    }
    public u8 Parse_SVersion_m_major()
    {                             
        var m_major = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_major);
    }
    public u8 Parse_SVersion_m_minor()
    {                             
        var m_minor = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_minor);
    }
    public u8 Parse_SVersion_m_revision()
    {                             
        var m_revision = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_revision);
    }
    public u32 Parse_SVersion_m_build()
    {                             
        var m_build = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_build);
    }
    public u32 Parse_SVersion_m_baseBuild()
    {                             
        var m_baseBuild = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_baseBuild);
    }

    public SMD5 Parse_SMD5() 
    {
        var m_dataDeprecated = Option.Some<Option<u8[]>>(Option.None);
        Option<byte[]> m_data = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_dataDeprecated is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_dataDeprecated = Parse_SMD5_m_dataDeprecated();
                        m_dataDeprecated = Option.Some(parsed_m_dataDeprecated);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_data is { HasValue: false })                           
                    {
                        var parsed_m_data = Parse_SMD5_m_data();
                        m_data = Option.Some(parsed_m_data);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new SMD5
        {   
            m_dataDeprecated = Option.OkOrReturnMissingFieldErr(m_dataDeprecated),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }
    public Option<u8[]> Parse_SMD5_m_dataDeprecated()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u8[]> m_dataDeprecated = default;
        if (isProvided != 0)
        {                                   
            ValidateArrayTag();
            var arrayLength = ParseVlqInt();
            var array = ReadArray(tagged_vlq_int, arrayLength);
            m_dataDeprecated = Option.Some(array.Select(ProtocolConversion<u8>.From).ToArray());                                 
        }
        else
        {
            m_dataDeprecated = Option.None;
        }

        return m_dataDeprecated;
    }
    public byte[] Parse_SMD5_m_data()
    {                             
        var m_data = tagged_blob();
        return m_data;
    }

    public GameSThumbnail Parse_GameSThumbnail() 
    {
        Option<byte[]> m_file = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_file is { HasValue: false })                           
                    {
                        var parsed_m_file = Parse_GameSThumbnail_m_file();
                        m_file = Option.Some(parsed_m_file);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new GameSThumbnail
        {   
            m_file = Option.OkOrReturnMissingFieldErr(m_file),
        };
    }
    public byte[] Parse_GameSThumbnail_m_file()
    {                             
        var m_file = tagged_blob();
        return m_file;
    }

    public GameSColor Parse_GameSColor() 
    {
        Option<u8> m_a = Option.None;
        Option<u8> m_r = Option.None;
        Option<u8> m_g = Option.None;
        Option<u8> m_b = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_a is { HasValue: false })                           
                    {
                        var parsed_m_a = Parse_GameSColor_m_a();
                        m_a = Option.Some(parsed_m_a);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_r is { HasValue: false })                           
                    {
                        var parsed_m_r = Parse_GameSColor_m_r();
                        m_r = Option.Some(parsed_m_r);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_g is { HasValue: false })                           
                    {
                        var parsed_m_g = Parse_GameSColor_m_g();
                        m_g = Option.Some(parsed_m_g);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_b is { HasValue: false })                           
                    {
                        var parsed_m_b = Parse_GameSColor_m_b();
                        m_b = Option.Some(parsed_m_b);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new GameSColor
        {   
            m_a = Option.OkOrReturnMissingFieldErr(m_a),
            m_r = Option.OkOrReturnMissingFieldErr(m_r),
            m_g = Option.OkOrReturnMissingFieldErr(m_g),
            m_b = Option.OkOrReturnMissingFieldErr(m_b),
        };
    }
    public u8 Parse_GameSColor_m_a()
    {                             
        var m_a = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_a);
    }
    public u8 Parse_GameSColor_m_r()
    {                             
        var m_r = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_r);
    }
    public u8 Parse_GameSColor_m_g()
    {                             
        var m_g = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_g);
    }
    public u8 Parse_GameSColor_m_b()
    {                             
        var m_b = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_b);
    }

    public GameSToonNameDetails Parse_GameSToonNameDetails() 
    {
        Option<u8> m_region = Option.None;
        Option<uint> m_programId = Option.None;
        Option<u32> m_realm = Option.None;
        Option<byte[]> m_name = Option.None;
        Option<u64> m_id = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_region is { HasValue: false })                           
                    {
                        var parsed_m_region = Parse_GameSToonNameDetails_m_region();
                        m_region = Option.Some(parsed_m_region);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_programId is { HasValue: false })                           
                    {
                        var parsed_m_programId = Parse_GameSToonNameDetails_m_programId();
                        m_programId = Option.Some(parsed_m_programId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_realm is { HasValue: false })                           
                    {
                        var parsed_m_realm = Parse_GameSToonNameDetails_m_realm();
                        m_realm = Option.Some(parsed_m_realm);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_name is { HasValue: false })                           
                    {
                        var parsed_m_name = Parse_GameSToonNameDetails_m_name();
                        m_name = Option.Some(parsed_m_name);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_id is { HasValue: false })                           
                    {
                        var parsed_m_id = Parse_GameSToonNameDetails_m_id();
                        m_id = Option.Some(parsed_m_id);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new GameSToonNameDetails
        {   
            m_region = Option.OkOrReturnMissingFieldErr(m_region),
            m_programId = Option.OkOrReturnMissingFieldErr(m_programId),
            m_realm = Option.OkOrReturnMissingFieldErr(m_realm),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_id = Option.OkOrReturnMissingFieldErr(m_id),
        };
    }
    public u8 Parse_GameSToonNameDetails_m_region()
    {                             
        var m_region = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_region);
    }
    public uint Parse_GameSToonNameDetails_m_programId()
    {                             
        var m_programId = tagged_fourcc();
        return m_programId;
    }
    public u32 Parse_GameSToonNameDetails_m_realm()
    {                             
        var m_realm = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_realm);
    }
    public byte[] Parse_GameSToonNameDetails_m_name()
    {                             
        var m_name = tagged_blob();
        return m_name;
    }
    public u64 Parse_GameSToonNameDetails_m_id()
    {                             
        var m_id = tagged_vlq_int();
        return ProtocolConversion<u64>.From(m_id);
    }

    public GameSPlayerDetails Parse_GameSPlayerDetails() 
    {
        Option<byte[]> m_name = Option.None;
        Option<GameSToonNameDetails> m_toon = Option.None;
        Option<byte[]> m_race = Option.None;
        Option<GameSColor> m_color = Option.None;
        Option<u8> m_control = Option.None;
        Option<u8> m_teamId = Option.None;
        Option<u32> m_handicap = Option.None;
        Option<EObserve> m_observe = Option.None;
        Option<GameEResultDetails> m_result = Option.None;
        var m_workingSetSlotId = Option.Some<Option<u8>>(Option.None);
        Option<byte[]> m_hero = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_name is { HasValue: false })                           
                    {
                        var parsed_m_name = Parse_GameSPlayerDetails_m_name();
                        m_name = Option.Some(parsed_m_name);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_toon is { HasValue: false })                           
                    {
                        var parsed_m_toon = Parse_GameSPlayerDetails_m_toon();
                        m_toon = Option.Some(parsed_m_toon);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_race is { HasValue: false })                           
                    {
                        var parsed_m_race = Parse_GameSPlayerDetails_m_race();
                        m_race = Option.Some(parsed_m_race);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_color is { HasValue: false })                           
                    {
                        var parsed_m_color = Parse_GameSPlayerDetails_m_color();
                        m_color = Option.Some(parsed_m_color);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_control is { HasValue: false })                           
                    {
                        var parsed_m_control = Parse_GameSPlayerDetails_m_control();
                        m_control = Option.Some(parsed_m_control);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_teamId is { HasValue: false })                           
                    {
                        var parsed_m_teamId = Parse_GameSPlayerDetails_m_teamId();
                        m_teamId = Option.Some(parsed_m_teamId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 6:
                {
                    if (m_handicap is { HasValue: false })                           
                    {
                        var parsed_m_handicap = Parse_GameSPlayerDetails_m_handicap();
                        m_handicap = Option.Some(parsed_m_handicap);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 7:
                {
                    if (m_observe is { HasValue: false })                           
                    {
                        var parsed_m_observe = Parse_GameSPlayerDetails_m_observe();
                        m_observe = Option.Some(parsed_m_observe);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 8:
                {
                    if (m_result is { HasValue: false })                           
                    {
                        var parsed_m_result = Parse_GameSPlayerDetails_m_result();
                        m_result = Option.Some(parsed_m_result);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 9:
                {
                    if (m_workingSetSlotId is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_workingSetSlotId = Parse_GameSPlayerDetails_m_workingSetSlotId();
                        m_workingSetSlotId = Option.Some(parsed_m_workingSetSlotId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 10:
                {
                    if (m_hero is { HasValue: false })                           
                    {
                        var parsed_m_hero = Parse_GameSPlayerDetails_m_hero();
                        m_hero = Option.Some(parsed_m_hero);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new GameSPlayerDetails
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_toon = Option.OkOrReturnMissingFieldErr(m_toon),
            m_race = Option.OkOrReturnMissingFieldErr(m_race),
            m_color = Option.OkOrReturnMissingFieldErr(m_color),
            m_control = Option.OkOrReturnMissingFieldErr(m_control),
            m_teamId = Option.OkOrReturnMissingFieldErr(m_teamId),
            m_handicap = Option.OkOrReturnMissingFieldErr(m_handicap),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
            m_result = Option.OkOrReturnMissingFieldErr(m_result),
            m_workingSetSlotId = Option.OkOrReturnMissingFieldErr(m_workingSetSlotId),
            m_hero = Option.OkOrReturnMissingFieldErr(m_hero),
        };
    }
    public byte[] Parse_GameSPlayerDetails_m_name()
    {                             
        var m_name = tagged_blob();
        return m_name;
    }
    public GameSToonNameDetails Parse_GameSPlayerDetails_m_toon()
    {                             
        var m_toon = Parse_GameSToonNameDetails();
        return m_toon;
    }
    public byte[] Parse_GameSPlayerDetails_m_race()
    {                             
        var m_race = tagged_blob();
        return m_race;
    }
    public GameSColor Parse_GameSPlayerDetails_m_color()
    {                             
        var m_color = Parse_GameSColor();
        return m_color;
    }
    public u8 Parse_GameSPlayerDetails_m_control()
    {                             
        var m_control = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_control);
    }
    public u8 Parse_GameSPlayerDetails_m_teamId()
    {                             
        var m_teamId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_teamId);
    }
    public u32 Parse_GameSPlayerDetails_m_handicap()
    {                             
        var m_handicap = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_handicap);
    }
    public EObserve Parse_GameSPlayerDetails_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }
    public GameEResultDetails Parse_GameSPlayerDetails_m_result()
    {                             
        var m_result = Parse_GameEResultDetails();
        return m_result;
    }
    public Option<u8> Parse_GameSPlayerDetails_m_workingSetSlotId()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u8> m_workingSetSlotId = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_workingSetSlotId = Option.Some(ProtocolConversion<u8>.From(res));
        }
        else
        {
            m_workingSetSlotId = Option.None;
        }

        return m_workingSetSlotId;
    }
    public byte[] Parse_GameSPlayerDetails_m_hero()
    {                             
        var m_hero = tagged_blob();
        return m_hero;
    }

    public GameSDetails Parse_GameSDetails() 
    {
        var m_playerList = Option.Some<Option<GameSPlayerDetails[]>>(Option.None);
        Option<byte[]> m_title = Option.None;
        Option<byte[]> m_difficulty = Option.None;
        Option<GameSThumbnail> m_thumbnail = Option.None;
        Option<bool> m_isBlizzardMap = Option.None;
        Option<i64> m_timeUTC = Option.None;
        Option<i64> m_timeLocalOffset = Option.None;
        var m_restartAsTransitionMap = Option.Some<Option<bool>>(Option.None);
        Option<bool> m_disableRecoverGame = Option.None;
        Option<byte[]> m_description = Option.None;
        Option<byte[]> m_imageFilePath = Option.None;
        Option<u8> m_campaignIndex = Option.None;
        Option<byte[]> m_mapFileName = Option.None;
        var m_cacheHandles = Option.Some<Option<byte[][]>>(Option.None);
        Option<bool> m_miniSave = Option.None;
        Option<GameEGameSpeed> m_gameSpeed = Option.None;
        Option<u32> m_defaultDifficulty = Option.None;
        var m_modPaths = Option.Some<Option<byte[][]>>(Option.None);
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_playerList is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_playerList = Parse_GameSDetails_m_playerList();
                        m_playerList = Option.Some(parsed_m_playerList);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_title is { HasValue: false })                           
                    {
                        var parsed_m_title = Parse_GameSDetails_m_title();
                        m_title = Option.Some(parsed_m_title);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_difficulty is { HasValue: false })                           
                    {
                        var parsed_m_difficulty = Parse_GameSDetails_m_difficulty();
                        m_difficulty = Option.Some(parsed_m_difficulty);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_thumbnail is { HasValue: false })                           
                    {
                        var parsed_m_thumbnail = Parse_GameSDetails_m_thumbnail();
                        m_thumbnail = Option.Some(parsed_m_thumbnail);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_isBlizzardMap is { HasValue: false })                           
                    {
                        var parsed_m_isBlizzardMap = Parse_GameSDetails_m_isBlizzardMap();
                        m_isBlizzardMap = Option.Some(parsed_m_isBlizzardMap);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_timeUTC is { HasValue: false })                           
                    {
                        var parsed_m_timeUTC = Parse_GameSDetails_m_timeUTC();
                        m_timeUTC = Option.Some(parsed_m_timeUTC);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 6:
                {
                    if (m_timeLocalOffset is { HasValue: false })                           
                    {
                        var parsed_m_timeLocalOffset = Parse_GameSDetails_m_timeLocalOffset();
                        m_timeLocalOffset = Option.Some(parsed_m_timeLocalOffset);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 16:
                {
                    if (m_restartAsTransitionMap is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_restartAsTransitionMap = Parse_GameSDetails_m_restartAsTransitionMap();
                        m_restartAsTransitionMap = Option.Some(parsed_m_restartAsTransitionMap);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 17:
                {
                    if (m_disableRecoverGame is { HasValue: false })                           
                    {
                        var parsed_m_disableRecoverGame = Parse_GameSDetails_m_disableRecoverGame();
                        m_disableRecoverGame = Option.Some(parsed_m_disableRecoverGame);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 7:
                {
                    if (m_description is { HasValue: false })                           
                    {
                        var parsed_m_description = Parse_GameSDetails_m_description();
                        m_description = Option.Some(parsed_m_description);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 8:
                {
                    if (m_imageFilePath is { HasValue: false })                           
                    {
                        var parsed_m_imageFilePath = Parse_GameSDetails_m_imageFilePath();
                        m_imageFilePath = Option.Some(parsed_m_imageFilePath);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 15:
                {
                    if (m_campaignIndex is { HasValue: false })                           
                    {
                        var parsed_m_campaignIndex = Parse_GameSDetails_m_campaignIndex();
                        m_campaignIndex = Option.Some(parsed_m_campaignIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 9:
                {
                    if (m_mapFileName is { HasValue: false })                           
                    {
                        var parsed_m_mapFileName = Parse_GameSDetails_m_mapFileName();
                        m_mapFileName = Option.Some(parsed_m_mapFileName);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 10:
                {
                    if (m_cacheHandles is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_cacheHandles = Parse_GameSDetails_m_cacheHandles();
                        m_cacheHandles = Option.Some(parsed_m_cacheHandles);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 11:
                {
                    if (m_miniSave is { HasValue: false })                           
                    {
                        var parsed_m_miniSave = Parse_GameSDetails_m_miniSave();
                        m_miniSave = Option.Some(parsed_m_miniSave);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 12:
                {
                    if (m_gameSpeed is { HasValue: false })                           
                    {
                        var parsed_m_gameSpeed = Parse_GameSDetails_m_gameSpeed();
                        m_gameSpeed = Option.Some(parsed_m_gameSpeed);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 13:
                {
                    if (m_defaultDifficulty is { HasValue: false })                           
                    {
                        var parsed_m_defaultDifficulty = Parse_GameSDetails_m_defaultDifficulty();
                        m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 14:
                {
                    if (m_modPaths is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_modPaths = Parse_GameSDetails_m_modPaths();
                        m_modPaths = Option.Some(parsed_m_modPaths);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new GameSDetails
        {   
            m_playerList = Option.OkOrReturnMissingFieldErr(m_playerList),
            m_title = Option.OkOrReturnMissingFieldErr(m_title),
            m_difficulty = Option.OkOrReturnMissingFieldErr(m_difficulty),
            m_thumbnail = Option.OkOrReturnMissingFieldErr(m_thumbnail),
            m_isBlizzardMap = Option.OkOrReturnMissingFieldErr(m_isBlizzardMap),
            m_timeUTC = Option.OkOrReturnMissingFieldErr(m_timeUTC),
            m_timeLocalOffset = Option.OkOrReturnMissingFieldErr(m_timeLocalOffset),
            m_restartAsTransitionMap = Option.OkOrReturnMissingFieldErr(m_restartAsTransitionMap),
            m_disableRecoverGame = Option.OkOrReturnMissingFieldErr(m_disableRecoverGame),
            m_description = Option.OkOrReturnMissingFieldErr(m_description),
            m_imageFilePath = Option.OkOrReturnMissingFieldErr(m_imageFilePath),
            m_campaignIndex = Option.OkOrReturnMissingFieldErr(m_campaignIndex),
            m_mapFileName = Option.OkOrReturnMissingFieldErr(m_mapFileName),
            m_cacheHandles = Option.OkOrReturnMissingFieldErr(m_cacheHandles),
            m_miniSave = Option.OkOrReturnMissingFieldErr(m_miniSave),
            m_gameSpeed = Option.OkOrReturnMissingFieldErr(m_gameSpeed),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
            m_modPaths = Option.OkOrReturnMissingFieldErr(m_modPaths),
        };
    }
    public Option<GameSPlayerDetails[]> Parse_GameSDetails_m_playerList()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<GameSPlayerDetails[]> m_playerList = default;
        if (isProvided != 0)
        {                                   
            ValidateArrayTag();
            var arrayLength = ParseVlqInt();
            var array = ReadArray(Parse_GameSPlayerDetails, arrayLength);
            m_playerList = Option.Some(array);
        }
        else
        {
            m_playerList = Option.None;
        }

        return m_playerList;
    }
    public byte[] Parse_GameSDetails_m_title()
    {                             
        var m_title = tagged_blob();
        return m_title;
    }
    public byte[] Parse_GameSDetails_m_difficulty()
    {                             
        var m_difficulty = tagged_blob();
        return m_difficulty;
    }
    public GameSThumbnail Parse_GameSDetails_m_thumbnail()
    {                             
        var m_thumbnail = Parse_GameSThumbnail();
        return m_thumbnail;
    }
    public bool Parse_GameSDetails_m_isBlizzardMap()
    {                             
        var m_isBlizzardMap = tagged_bool();
        return m_isBlizzardMap;
    }
    public i64 Parse_GameSDetails_m_timeUTC()
    {                             
        var m_timeUTC = tagged_vlq_int();
        return ProtocolConversion<i64>.From(m_timeUTC);
    }
    public i64 Parse_GameSDetails_m_timeLocalOffset()
    {                             
        var m_timeLocalOffset = tagged_vlq_int();
        return ProtocolConversion<i64>.From(m_timeLocalOffset);
    }
    public Option<bool> Parse_GameSDetails_m_restartAsTransitionMap()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<bool> m_restartAsTransitionMap = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_bool();

            m_restartAsTransitionMap = Option.Some(res);          
        }
        else
        {
            m_restartAsTransitionMap = Option.None;
        }

        return m_restartAsTransitionMap;
    }
    public bool Parse_GameSDetails_m_disableRecoverGame()
    {                             
        var m_disableRecoverGame = tagged_bool();
        return m_disableRecoverGame;
    }
    public byte[] Parse_GameSDetails_m_description()
    {                             
        var m_description = tagged_blob();
        return m_description;
    }
    public byte[] Parse_GameSDetails_m_imageFilePath()
    {                             
        var m_imageFilePath = tagged_blob();
        return m_imageFilePath;
    }
    public u8 Parse_GameSDetails_m_campaignIndex()
    {                             
        var m_campaignIndex = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_campaignIndex);
    }
    public byte[] Parse_GameSDetails_m_mapFileName()
    {                             
        var m_mapFileName = tagged_blob();
        return m_mapFileName;
    }
    public Option<byte[][]> Parse_GameSDetails_m_cacheHandles()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<byte[][]> m_cacheHandles = default;
        if (isProvided != 0)
        {                                   
            ValidateArrayTag();
            var arrayLength = ParseVlqInt();
            var array = ReadArray(tagged_blob, arrayLength);
            m_cacheHandles = Option.Some(array);
        }
        else
        {
            m_cacheHandles = Option.None;
        }

        return m_cacheHandles;
    }
    public bool Parse_GameSDetails_m_miniSave()
    {                             
        var m_miniSave = tagged_bool();
        return m_miniSave;
    }
    public GameEGameSpeed Parse_GameSDetails_m_gameSpeed()
    {                             
        var m_gameSpeed = Parse_GameEGameSpeed();
        return m_gameSpeed;
    }
    public u32 Parse_GameSDetails_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_defaultDifficulty);
    }
    public Option<byte[][]> Parse_GameSDetails_m_modPaths()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<byte[][]> m_modPaths = default;
        if (isProvided != 0)
        {                                   
            ValidateArrayTag();
            var arrayLength = ParseVlqInt();
            var array = ReadArray(tagged_blob, arrayLength);
            m_modPaths = Option.Some(array);
        }
        else
        {
            m_modPaths = Option.None;
        }

        return m_modPaths;
    }

    public ReplaySHeader Parse_ReplaySHeader() 
    {
        Option<byte[]> m_signature = Option.None;
        Option<SVersion> m_version = Option.None;
        Option<u8> m_type = Option.None;
        Option<u32> m_elapsedGameLoops = Option.None;
        Option<bool> m_useScaledTime = Option.None;
        Option<SMD5> m_ngdpRootKey = Option.None;
        Option<u32> m_dataBuildNum = Option.None;
        Option<SMD5> m_replayCompatibilityHash = Option.None;
        Option<bool> m_ngdpRootKeyIsDevData = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_signature is { HasValue: false })                           
                    {
                        var parsed_m_signature = Parse_ReplaySHeader_m_signature();
                        m_signature = Option.Some(parsed_m_signature);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_version is { HasValue: false })                           
                    {
                        var parsed_m_version = Parse_ReplaySHeader_m_version();
                        m_version = Option.Some(parsed_m_version);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_type is { HasValue: false })                           
                    {
                        var parsed_m_type = Parse_ReplaySHeader_m_type();
                        m_type = Option.Some(parsed_m_type);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_elapsedGameLoops is { HasValue: false })                           
                    {
                        var parsed_m_elapsedGameLoops = Parse_ReplaySHeader_m_elapsedGameLoops();
                        m_elapsedGameLoops = Option.Some(parsed_m_elapsedGameLoops);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_useScaledTime is { HasValue: false })                           
                    {
                        var parsed_m_useScaledTime = Parse_ReplaySHeader_m_useScaledTime();
                        m_useScaledTime = Option.Some(parsed_m_useScaledTime);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_ngdpRootKey is { HasValue: false })                           
                    {
                        var parsed_m_ngdpRootKey = Parse_ReplaySHeader_m_ngdpRootKey();
                        m_ngdpRootKey = Option.Some(parsed_m_ngdpRootKey);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 6:
                {
                    if (m_dataBuildNum is { HasValue: false })                           
                    {
                        var parsed_m_dataBuildNum = Parse_ReplaySHeader_m_dataBuildNum();
                        m_dataBuildNum = Option.Some(parsed_m_dataBuildNum);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 7:
                {
                    if (m_replayCompatibilityHash is { HasValue: false })                           
                    {
                        var parsed_m_replayCompatibilityHash = Parse_ReplaySHeader_m_replayCompatibilityHash();
                        m_replayCompatibilityHash = Option.Some(parsed_m_replayCompatibilityHash);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 8:
                {
                    if (m_ngdpRootKeyIsDevData is { HasValue: false })                           
                    {
                        var parsed_m_ngdpRootKeyIsDevData = Parse_ReplaySHeader_m_ngdpRootKeyIsDevData();
                        m_ngdpRootKeyIsDevData = Option.Some(parsed_m_ngdpRootKeyIsDevData);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplaySHeader
        {   
            m_signature = Option.OkOrReturnMissingFieldErr(m_signature),
            m_version = Option.OkOrReturnMissingFieldErr(m_version),
            m_type = Option.OkOrReturnMissingFieldErr(m_type),
            m_elapsedGameLoops = Option.OkOrReturnMissingFieldErr(m_elapsedGameLoops),
            m_useScaledTime = Option.OkOrReturnMissingFieldErr(m_useScaledTime),
            m_ngdpRootKey = Option.OkOrReturnMissingFieldErr(m_ngdpRootKey),
            m_dataBuildNum = Option.OkOrReturnMissingFieldErr(m_dataBuildNum),
            m_replayCompatibilityHash = Option.OkOrReturnMissingFieldErr(m_replayCompatibilityHash),
            m_ngdpRootKeyIsDevData = Option.OkOrReturnMissingFieldErr(m_ngdpRootKeyIsDevData),
        };
    }
    public byte[] Parse_ReplaySHeader_m_signature()
    {                             
        var m_signature = tagged_blob();
        return m_signature;
    }
    public SVersion Parse_ReplaySHeader_m_version()
    {                             
        var m_version = Parse_SVersion();
        return m_version;
    }
    public u8 Parse_ReplaySHeader_m_type()
    {                             
        var m_type = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_type);
    }
    public u32 Parse_ReplaySHeader_m_elapsedGameLoops()
    {                             
        var m_elapsedGameLoops = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_elapsedGameLoops);
    }
    public bool Parse_ReplaySHeader_m_useScaledTime()
    {                             
        var m_useScaledTime = tagged_bool();
        return m_useScaledTime;
    }
    public SMD5 Parse_ReplaySHeader_m_ngdpRootKey()
    {                             
        var m_ngdpRootKey = Parse_SMD5();
        return m_ngdpRootKey;
    }
    public u32 Parse_ReplaySHeader_m_dataBuildNum()
    {                             
        var m_dataBuildNum = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_dataBuildNum);
    }
    public SMD5 Parse_ReplaySHeader_m_replayCompatibilityHash()
    {                             
        var m_replayCompatibilityHash = Parse_SMD5();
        return m_replayCompatibilityHash;
    }
    public bool Parse_ReplaySHeader_m_ngdpRootKeyIsDevData()
    {                             
        var m_ngdpRootKeyIsDevData = tagged_bool();
        return m_ngdpRootKeyIsDevData;
    }

    public ReplayTrackerSPlayerStats Parse_ReplayTrackerSPlayerStats() 
    {
        Option<i32> m_scoreValueMineralsCurrent = Option.None;
        Option<i32> m_scoreValueVespeneCurrent = Option.None;
        Option<i32> m_scoreValueMineralsCollectionRate = Option.None;
        Option<i32> m_scoreValueVespeneCollectionRate = Option.None;
        Option<i32> m_scoreValueWorkersActiveCount = Option.None;
        Option<i32> m_scoreValueMineralsUsedInProgressArmy = Option.None;
        Option<i32> m_scoreValueMineralsUsedInProgressEconomy = Option.None;
        Option<i32> m_scoreValueMineralsUsedInProgressTechnology = Option.None;
        Option<i32> m_scoreValueVespeneUsedInProgressArmy = Option.None;
        Option<i32> m_scoreValueVespeneUsedInProgressEconomy = Option.None;
        Option<i32> m_scoreValueVespeneUsedInProgressTechnology = Option.None;
        Option<i32> m_scoreValueMineralsUsedCurrentArmy = Option.None;
        Option<i32> m_scoreValueMineralsUsedCurrentEconomy = Option.None;
        Option<i32> m_scoreValueMineralsUsedCurrentTechnology = Option.None;
        Option<i32> m_scoreValueVespeneUsedCurrentArmy = Option.None;
        Option<i32> m_scoreValueVespeneUsedCurrentEconomy = Option.None;
        Option<i32> m_scoreValueVespeneUsedCurrentTechnology = Option.None;
        Option<i32> m_scoreValueMineralsLostArmy = Option.None;
        Option<i32> m_scoreValueMineralsLostEconomy = Option.None;
        Option<i32> m_scoreValueMineralsLostTechnology = Option.None;
        Option<i32> m_scoreValueVespeneLostArmy = Option.None;
        Option<i32> m_scoreValueVespeneLostEconomy = Option.None;
        Option<i32> m_scoreValueVespeneLostTechnology = Option.None;
        Option<i32> m_scoreValueMineralsKilledArmy = Option.None;
        Option<i32> m_scoreValueMineralsKilledEconomy = Option.None;
        Option<i32> m_scoreValueMineralsKilledTechnology = Option.None;
        Option<i32> m_scoreValueVespeneKilledArmy = Option.None;
        Option<i32> m_scoreValueVespeneKilledEconomy = Option.None;
        Option<i32> m_scoreValueVespeneKilledTechnology = Option.None;
        Option<i32> m_scoreValueFoodUsed = Option.None;
        Option<i32> m_scoreValueFoodMade = Option.None;
        Option<i32> m_scoreValueMineralsUsedActiveForces = Option.None;
        Option<i32> m_scoreValueVespeneUsedActiveForces = Option.None;
        Option<i32> m_scoreValueMineralsFriendlyFireArmy = Option.None;
        Option<i32> m_scoreValueMineralsFriendlyFireEconomy = Option.None;
        Option<i32> m_scoreValueMineralsFriendlyFireTechnology = Option.None;
        Option<i32> m_scoreValueVespeneFriendlyFireArmy = Option.None;
        Option<i32> m_scoreValueVespeneFriendlyFireEconomy = Option.None;
        Option<i32> m_scoreValueVespeneFriendlyFireTechnology = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_scoreValueMineralsCurrent is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsCurrent = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsCurrent();
                        m_scoreValueMineralsCurrent = Option.Some(parsed_m_scoreValueMineralsCurrent);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_scoreValueVespeneCurrent is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneCurrent = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneCurrent();
                        m_scoreValueVespeneCurrent = Option.Some(parsed_m_scoreValueVespeneCurrent);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_scoreValueMineralsCollectionRate is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsCollectionRate = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsCollectionRate();
                        m_scoreValueMineralsCollectionRate = Option.Some(parsed_m_scoreValueMineralsCollectionRate);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_scoreValueVespeneCollectionRate is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneCollectionRate = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneCollectionRate();
                        m_scoreValueVespeneCollectionRate = Option.Some(parsed_m_scoreValueVespeneCollectionRate);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_scoreValueWorkersActiveCount is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueWorkersActiveCount = Parse_ReplayTrackerSPlayerStats_m_scoreValueWorkersActiveCount();
                        m_scoreValueWorkersActiveCount = Option.Some(parsed_m_scoreValueWorkersActiveCount);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_scoreValueMineralsUsedInProgressArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsUsedInProgressArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedInProgressArmy();
                        m_scoreValueMineralsUsedInProgressArmy = Option.Some(parsed_m_scoreValueMineralsUsedInProgressArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 6:
                {
                    if (m_scoreValueMineralsUsedInProgressEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsUsedInProgressEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedInProgressEconomy();
                        m_scoreValueMineralsUsedInProgressEconomy = Option.Some(parsed_m_scoreValueMineralsUsedInProgressEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 7:
                {
                    if (m_scoreValueMineralsUsedInProgressTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsUsedInProgressTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedInProgressTechnology();
                        m_scoreValueMineralsUsedInProgressTechnology = Option.Some(parsed_m_scoreValueMineralsUsedInProgressTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 8:
                {
                    if (m_scoreValueVespeneUsedInProgressArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneUsedInProgressArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedInProgressArmy();
                        m_scoreValueVespeneUsedInProgressArmy = Option.Some(parsed_m_scoreValueVespeneUsedInProgressArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 9:
                {
                    if (m_scoreValueVespeneUsedInProgressEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneUsedInProgressEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedInProgressEconomy();
                        m_scoreValueVespeneUsedInProgressEconomy = Option.Some(parsed_m_scoreValueVespeneUsedInProgressEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 10:
                {
                    if (m_scoreValueVespeneUsedInProgressTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneUsedInProgressTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedInProgressTechnology();
                        m_scoreValueVespeneUsedInProgressTechnology = Option.Some(parsed_m_scoreValueVespeneUsedInProgressTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 11:
                {
                    if (m_scoreValueMineralsUsedCurrentArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsUsedCurrentArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedCurrentArmy();
                        m_scoreValueMineralsUsedCurrentArmy = Option.Some(parsed_m_scoreValueMineralsUsedCurrentArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 12:
                {
                    if (m_scoreValueMineralsUsedCurrentEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsUsedCurrentEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedCurrentEconomy();
                        m_scoreValueMineralsUsedCurrentEconomy = Option.Some(parsed_m_scoreValueMineralsUsedCurrentEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 13:
                {
                    if (m_scoreValueMineralsUsedCurrentTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsUsedCurrentTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedCurrentTechnology();
                        m_scoreValueMineralsUsedCurrentTechnology = Option.Some(parsed_m_scoreValueMineralsUsedCurrentTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 14:
                {
                    if (m_scoreValueVespeneUsedCurrentArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneUsedCurrentArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedCurrentArmy();
                        m_scoreValueVespeneUsedCurrentArmy = Option.Some(parsed_m_scoreValueVespeneUsedCurrentArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 15:
                {
                    if (m_scoreValueVespeneUsedCurrentEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneUsedCurrentEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedCurrentEconomy();
                        m_scoreValueVespeneUsedCurrentEconomy = Option.Some(parsed_m_scoreValueVespeneUsedCurrentEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 16:
                {
                    if (m_scoreValueVespeneUsedCurrentTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneUsedCurrentTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedCurrentTechnology();
                        m_scoreValueVespeneUsedCurrentTechnology = Option.Some(parsed_m_scoreValueVespeneUsedCurrentTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 17:
                {
                    if (m_scoreValueMineralsLostArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsLostArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsLostArmy();
                        m_scoreValueMineralsLostArmy = Option.Some(parsed_m_scoreValueMineralsLostArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 18:
                {
                    if (m_scoreValueMineralsLostEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsLostEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsLostEconomy();
                        m_scoreValueMineralsLostEconomy = Option.Some(parsed_m_scoreValueMineralsLostEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 19:
                {
                    if (m_scoreValueMineralsLostTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsLostTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsLostTechnology();
                        m_scoreValueMineralsLostTechnology = Option.Some(parsed_m_scoreValueMineralsLostTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 20:
                {
                    if (m_scoreValueVespeneLostArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneLostArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneLostArmy();
                        m_scoreValueVespeneLostArmy = Option.Some(parsed_m_scoreValueVespeneLostArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 21:
                {
                    if (m_scoreValueVespeneLostEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneLostEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneLostEconomy();
                        m_scoreValueVespeneLostEconomy = Option.Some(parsed_m_scoreValueVespeneLostEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 22:
                {
                    if (m_scoreValueVespeneLostTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneLostTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneLostTechnology();
                        m_scoreValueVespeneLostTechnology = Option.Some(parsed_m_scoreValueVespeneLostTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 23:
                {
                    if (m_scoreValueMineralsKilledArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsKilledArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsKilledArmy();
                        m_scoreValueMineralsKilledArmy = Option.Some(parsed_m_scoreValueMineralsKilledArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 24:
                {
                    if (m_scoreValueMineralsKilledEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsKilledEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsKilledEconomy();
                        m_scoreValueMineralsKilledEconomy = Option.Some(parsed_m_scoreValueMineralsKilledEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 25:
                {
                    if (m_scoreValueMineralsKilledTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsKilledTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsKilledTechnology();
                        m_scoreValueMineralsKilledTechnology = Option.Some(parsed_m_scoreValueMineralsKilledTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 26:
                {
                    if (m_scoreValueVespeneKilledArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneKilledArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneKilledArmy();
                        m_scoreValueVespeneKilledArmy = Option.Some(parsed_m_scoreValueVespeneKilledArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 27:
                {
                    if (m_scoreValueVespeneKilledEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneKilledEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneKilledEconomy();
                        m_scoreValueVespeneKilledEconomy = Option.Some(parsed_m_scoreValueVespeneKilledEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 28:
                {
                    if (m_scoreValueVespeneKilledTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneKilledTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneKilledTechnology();
                        m_scoreValueVespeneKilledTechnology = Option.Some(parsed_m_scoreValueVespeneKilledTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 29:
                {
                    if (m_scoreValueFoodUsed is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueFoodUsed = Parse_ReplayTrackerSPlayerStats_m_scoreValueFoodUsed();
                        m_scoreValueFoodUsed = Option.Some(parsed_m_scoreValueFoodUsed);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 30:
                {
                    if (m_scoreValueFoodMade is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueFoodMade = Parse_ReplayTrackerSPlayerStats_m_scoreValueFoodMade();
                        m_scoreValueFoodMade = Option.Some(parsed_m_scoreValueFoodMade);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 31:
                {
                    if (m_scoreValueMineralsUsedActiveForces is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsUsedActiveForces = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedActiveForces();
                        m_scoreValueMineralsUsedActiveForces = Option.Some(parsed_m_scoreValueMineralsUsedActiveForces);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 32:
                {
                    if (m_scoreValueVespeneUsedActiveForces is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneUsedActiveForces = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedActiveForces();
                        m_scoreValueVespeneUsedActiveForces = Option.Some(parsed_m_scoreValueVespeneUsedActiveForces);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 33:
                {
                    if (m_scoreValueMineralsFriendlyFireArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsFriendlyFireArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsFriendlyFireArmy();
                        m_scoreValueMineralsFriendlyFireArmy = Option.Some(parsed_m_scoreValueMineralsFriendlyFireArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 34:
                {
                    if (m_scoreValueMineralsFriendlyFireEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsFriendlyFireEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsFriendlyFireEconomy();
                        m_scoreValueMineralsFriendlyFireEconomy = Option.Some(parsed_m_scoreValueMineralsFriendlyFireEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 35:
                {
                    if (m_scoreValueMineralsFriendlyFireTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueMineralsFriendlyFireTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsFriendlyFireTechnology();
                        m_scoreValueMineralsFriendlyFireTechnology = Option.Some(parsed_m_scoreValueMineralsFriendlyFireTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 36:
                {
                    if (m_scoreValueVespeneFriendlyFireArmy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneFriendlyFireArmy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneFriendlyFireArmy();
                        m_scoreValueVespeneFriendlyFireArmy = Option.Some(parsed_m_scoreValueVespeneFriendlyFireArmy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 37:
                {
                    if (m_scoreValueVespeneFriendlyFireEconomy is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneFriendlyFireEconomy = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneFriendlyFireEconomy();
                        m_scoreValueVespeneFriendlyFireEconomy = Option.Some(parsed_m_scoreValueVespeneFriendlyFireEconomy);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 38:
                {
                    if (m_scoreValueVespeneFriendlyFireTechnology is { HasValue: false })                           
                    {
                        var parsed_m_scoreValueVespeneFriendlyFireTechnology = Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneFriendlyFireTechnology();
                        m_scoreValueVespeneFriendlyFireTechnology = Option.Some(parsed_m_scoreValueVespeneFriendlyFireTechnology);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSPlayerStats
        {   
            m_scoreValueMineralsCurrent = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsCurrent),
            m_scoreValueVespeneCurrent = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneCurrent),
            m_scoreValueMineralsCollectionRate = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsCollectionRate),
            m_scoreValueVespeneCollectionRate = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneCollectionRate),
            m_scoreValueWorkersActiveCount = Option.OkOrReturnMissingFieldErr(m_scoreValueWorkersActiveCount),
            m_scoreValueMineralsUsedInProgressArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsUsedInProgressArmy),
            m_scoreValueMineralsUsedInProgressEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsUsedInProgressEconomy),
            m_scoreValueMineralsUsedInProgressTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsUsedInProgressTechnology),
            m_scoreValueVespeneUsedInProgressArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneUsedInProgressArmy),
            m_scoreValueVespeneUsedInProgressEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneUsedInProgressEconomy),
            m_scoreValueVespeneUsedInProgressTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneUsedInProgressTechnology),
            m_scoreValueMineralsUsedCurrentArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsUsedCurrentArmy),
            m_scoreValueMineralsUsedCurrentEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsUsedCurrentEconomy),
            m_scoreValueMineralsUsedCurrentTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsUsedCurrentTechnology),
            m_scoreValueVespeneUsedCurrentArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneUsedCurrentArmy),
            m_scoreValueVespeneUsedCurrentEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneUsedCurrentEconomy),
            m_scoreValueVespeneUsedCurrentTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneUsedCurrentTechnology),
            m_scoreValueMineralsLostArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsLostArmy),
            m_scoreValueMineralsLostEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsLostEconomy),
            m_scoreValueMineralsLostTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsLostTechnology),
            m_scoreValueVespeneLostArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneLostArmy),
            m_scoreValueVespeneLostEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneLostEconomy),
            m_scoreValueVespeneLostTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneLostTechnology),
            m_scoreValueMineralsKilledArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsKilledArmy),
            m_scoreValueMineralsKilledEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsKilledEconomy),
            m_scoreValueMineralsKilledTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsKilledTechnology),
            m_scoreValueVespeneKilledArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneKilledArmy),
            m_scoreValueVespeneKilledEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneKilledEconomy),
            m_scoreValueVespeneKilledTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneKilledTechnology),
            m_scoreValueFoodUsed = Option.OkOrReturnMissingFieldErr(m_scoreValueFoodUsed),
            m_scoreValueFoodMade = Option.OkOrReturnMissingFieldErr(m_scoreValueFoodMade),
            m_scoreValueMineralsUsedActiveForces = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsUsedActiveForces),
            m_scoreValueVespeneUsedActiveForces = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneUsedActiveForces),
            m_scoreValueMineralsFriendlyFireArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsFriendlyFireArmy),
            m_scoreValueMineralsFriendlyFireEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsFriendlyFireEconomy),
            m_scoreValueMineralsFriendlyFireTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueMineralsFriendlyFireTechnology),
            m_scoreValueVespeneFriendlyFireArmy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneFriendlyFireArmy),
            m_scoreValueVespeneFriendlyFireEconomy = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneFriendlyFireEconomy),
            m_scoreValueVespeneFriendlyFireTechnology = Option.OkOrReturnMissingFieldErr(m_scoreValueVespeneFriendlyFireTechnology),
        };
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsCurrent()
    {                             
        var m_scoreValueMineralsCurrent = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsCurrent);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneCurrent()
    {                             
        var m_scoreValueVespeneCurrent = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneCurrent);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsCollectionRate()
    {                             
        var m_scoreValueMineralsCollectionRate = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsCollectionRate);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneCollectionRate()
    {                             
        var m_scoreValueVespeneCollectionRate = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneCollectionRate);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueWorkersActiveCount()
    {                             
        var m_scoreValueWorkersActiveCount = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueWorkersActiveCount);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedInProgressArmy()
    {                             
        var m_scoreValueMineralsUsedInProgressArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsUsedInProgressArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedInProgressEconomy()
    {                             
        var m_scoreValueMineralsUsedInProgressEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsUsedInProgressEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedInProgressTechnology()
    {                             
        var m_scoreValueMineralsUsedInProgressTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsUsedInProgressTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedInProgressArmy()
    {                             
        var m_scoreValueVespeneUsedInProgressArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneUsedInProgressArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedInProgressEconomy()
    {                             
        var m_scoreValueVespeneUsedInProgressEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneUsedInProgressEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedInProgressTechnology()
    {                             
        var m_scoreValueVespeneUsedInProgressTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneUsedInProgressTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedCurrentArmy()
    {                             
        var m_scoreValueMineralsUsedCurrentArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsUsedCurrentArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedCurrentEconomy()
    {                             
        var m_scoreValueMineralsUsedCurrentEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsUsedCurrentEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedCurrentTechnology()
    {                             
        var m_scoreValueMineralsUsedCurrentTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsUsedCurrentTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedCurrentArmy()
    {                             
        var m_scoreValueVespeneUsedCurrentArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneUsedCurrentArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedCurrentEconomy()
    {                             
        var m_scoreValueVespeneUsedCurrentEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneUsedCurrentEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedCurrentTechnology()
    {                             
        var m_scoreValueVespeneUsedCurrentTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneUsedCurrentTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsLostArmy()
    {                             
        var m_scoreValueMineralsLostArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsLostArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsLostEconomy()
    {                             
        var m_scoreValueMineralsLostEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsLostEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsLostTechnology()
    {                             
        var m_scoreValueMineralsLostTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsLostTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneLostArmy()
    {                             
        var m_scoreValueVespeneLostArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneLostArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneLostEconomy()
    {                             
        var m_scoreValueVespeneLostEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneLostEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneLostTechnology()
    {                             
        var m_scoreValueVespeneLostTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneLostTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsKilledArmy()
    {                             
        var m_scoreValueMineralsKilledArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsKilledArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsKilledEconomy()
    {                             
        var m_scoreValueMineralsKilledEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsKilledEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsKilledTechnology()
    {                             
        var m_scoreValueMineralsKilledTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsKilledTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneKilledArmy()
    {                             
        var m_scoreValueVespeneKilledArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneKilledArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneKilledEconomy()
    {                             
        var m_scoreValueVespeneKilledEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneKilledEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneKilledTechnology()
    {                             
        var m_scoreValueVespeneKilledTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneKilledTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueFoodUsed()
    {                             
        var m_scoreValueFoodUsed = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueFoodUsed);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueFoodMade()
    {                             
        var m_scoreValueFoodMade = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueFoodMade);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsUsedActiveForces()
    {                             
        var m_scoreValueMineralsUsedActiveForces = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsUsedActiveForces);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneUsedActiveForces()
    {                             
        var m_scoreValueVespeneUsedActiveForces = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneUsedActiveForces);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsFriendlyFireArmy()
    {                             
        var m_scoreValueMineralsFriendlyFireArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsFriendlyFireArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsFriendlyFireEconomy()
    {                             
        var m_scoreValueMineralsFriendlyFireEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsFriendlyFireEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueMineralsFriendlyFireTechnology()
    {                             
        var m_scoreValueMineralsFriendlyFireTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueMineralsFriendlyFireTechnology);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneFriendlyFireArmy()
    {                             
        var m_scoreValueVespeneFriendlyFireArmy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneFriendlyFireArmy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneFriendlyFireEconomy()
    {                             
        var m_scoreValueVespeneFriendlyFireEconomy = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneFriendlyFireEconomy);
    }
    public i32 Parse_ReplayTrackerSPlayerStats_m_scoreValueVespeneFriendlyFireTechnology()
    {                             
        var m_scoreValueVespeneFriendlyFireTechnology = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_scoreValueVespeneFriendlyFireTechnology);
    }

    public ReplayTrackerSPlayerStatsEvent Parse_ReplayTrackerSPlayerStatsEvent() 
    {
        Option<u8> m_playerId = Option.None;
        Option<ReplayTrackerSPlayerStats> m_stats = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_playerId is { HasValue: false })                           
                    {
                        var parsed_m_playerId = Parse_ReplayTrackerSPlayerStatsEvent_m_playerId();
                        m_playerId = Option.Some(parsed_m_playerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_stats is { HasValue: false })                           
                    {
                        var parsed_m_stats = Parse_ReplayTrackerSPlayerStatsEvent_m_stats();
                        m_stats = Option.Some(parsed_m_stats);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSPlayerStatsEvent
        {   
            m_playerId = Option.OkOrReturnMissingFieldErr(m_playerId),
            m_stats = Option.OkOrReturnMissingFieldErr(m_stats),
        };
    }
    public u8 Parse_ReplayTrackerSPlayerStatsEvent_m_playerId()
    {                             
        var m_playerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_playerId);
    }
    public ReplayTrackerSPlayerStats Parse_ReplayTrackerSPlayerStatsEvent_m_stats()
    {                             
        var m_stats = Parse_ReplayTrackerSPlayerStats();
        return m_stats;
    }

    public ReplayTrackerSUnitBornEvent Parse_ReplayTrackerSUnitBornEvent() 
    {
        Option<u32> m_unitTagIndex = Option.None;
        Option<u32> m_unitTagRecycle = Option.None;
        Option<byte[]> m_unitTypeName = Option.None;
        Option<u8> m_controlPlayerId = Option.None;
        Option<u8> m_upkeepPlayerId = Option.None;
        Option<u8> m_x = Option.None;
        Option<u8> m_y = Option.None;
        var m_creatorUnitTagIndex = Option.Some<Option<u32>>(Option.None);
        var m_creatorUnitTagRecycle = Option.Some<Option<u32>>(Option.None);
        var m_creatorAbilityName = Option.Some<Option<byte[]>>(Option.None);
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_unitTagIndex is { HasValue: false })                           
                    {
                        var parsed_m_unitTagIndex = Parse_ReplayTrackerSUnitBornEvent_m_unitTagIndex();
                        m_unitTagIndex = Option.Some(parsed_m_unitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_unitTagRecycle is { HasValue: false })                           
                    {
                        var parsed_m_unitTagRecycle = Parse_ReplayTrackerSUnitBornEvent_m_unitTagRecycle();
                        m_unitTagRecycle = Option.Some(parsed_m_unitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_unitTypeName is { HasValue: false })                           
                    {
                        var parsed_m_unitTypeName = Parse_ReplayTrackerSUnitBornEvent_m_unitTypeName();
                        m_unitTypeName = Option.Some(parsed_m_unitTypeName);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_controlPlayerId is { HasValue: false })                           
                    {
                        var parsed_m_controlPlayerId = Parse_ReplayTrackerSUnitBornEvent_m_controlPlayerId();
                        m_controlPlayerId = Option.Some(parsed_m_controlPlayerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_upkeepPlayerId is { HasValue: false })                           
                    {
                        var parsed_m_upkeepPlayerId = Parse_ReplayTrackerSUnitBornEvent_m_upkeepPlayerId();
                        m_upkeepPlayerId = Option.Some(parsed_m_upkeepPlayerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_x is { HasValue: false })                           
                    {
                        var parsed_m_x = Parse_ReplayTrackerSUnitBornEvent_m_x();
                        m_x = Option.Some(parsed_m_x);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 6:
                {
                    if (m_y is { HasValue: false })                           
                    {
                        var parsed_m_y = Parse_ReplayTrackerSUnitBornEvent_m_y();
                        m_y = Option.Some(parsed_m_y);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 7:
                {
                    if (m_creatorUnitTagIndex is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_creatorUnitTagIndex = Parse_ReplayTrackerSUnitBornEvent_m_creatorUnitTagIndex();
                        m_creatorUnitTagIndex = Option.Some(parsed_m_creatorUnitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 8:
                {
                    if (m_creatorUnitTagRecycle is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_creatorUnitTagRecycle = Parse_ReplayTrackerSUnitBornEvent_m_creatorUnitTagRecycle();
                        m_creatorUnitTagRecycle = Option.Some(parsed_m_creatorUnitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 9:
                {
                    if (m_creatorAbilityName is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_creatorAbilityName = Parse_ReplayTrackerSUnitBornEvent_m_creatorAbilityName();
                        m_creatorAbilityName = Option.Some(parsed_m_creatorAbilityName);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUnitBornEvent
        {   
            m_unitTagIndex = Option.OkOrReturnMissingFieldErr(m_unitTagIndex),
            m_unitTagRecycle = Option.OkOrReturnMissingFieldErr(m_unitTagRecycle),
            m_unitTypeName = Option.OkOrReturnMissingFieldErr(m_unitTypeName),
            m_controlPlayerId = Option.OkOrReturnMissingFieldErr(m_controlPlayerId),
            m_upkeepPlayerId = Option.OkOrReturnMissingFieldErr(m_upkeepPlayerId),
            m_x = Option.OkOrReturnMissingFieldErr(m_x),
            m_y = Option.OkOrReturnMissingFieldErr(m_y),
            m_creatorUnitTagIndex = Option.OkOrReturnMissingFieldErr(m_creatorUnitTagIndex),
            m_creatorUnitTagRecycle = Option.OkOrReturnMissingFieldErr(m_creatorUnitTagRecycle),
            m_creatorAbilityName = Option.OkOrReturnMissingFieldErr(m_creatorAbilityName),
        };
    }
    public u32 Parse_ReplayTrackerSUnitBornEvent_m_unitTagIndex()
    {                             
        var m_unitTagIndex = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagIndex);
    }
    public u32 Parse_ReplayTrackerSUnitBornEvent_m_unitTagRecycle()
    {                             
        var m_unitTagRecycle = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagRecycle);
    }
    public byte[] Parse_ReplayTrackerSUnitBornEvent_m_unitTypeName()
    {                             
        var m_unitTypeName = tagged_blob();
        return m_unitTypeName;
    }
    public u8 Parse_ReplayTrackerSUnitBornEvent_m_controlPlayerId()
    {                             
        var m_controlPlayerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_controlPlayerId);
    }
    public u8 Parse_ReplayTrackerSUnitBornEvent_m_upkeepPlayerId()
    {                             
        var m_upkeepPlayerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_upkeepPlayerId);
    }
    public u8 Parse_ReplayTrackerSUnitBornEvent_m_x()
    {                             
        var m_x = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_x);
    }
    public u8 Parse_ReplayTrackerSUnitBornEvent_m_y()
    {                             
        var m_y = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_y);
    }
    public Option<u32> Parse_ReplayTrackerSUnitBornEvent_m_creatorUnitTagIndex()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u32> m_creatorUnitTagIndex = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_creatorUnitTagIndex = Option.Some(ProtocolConversion<u32>.From(res));
        }
        else
        {
            m_creatorUnitTagIndex = Option.None;
        }

        return m_creatorUnitTagIndex;
    }
    public Option<u32> Parse_ReplayTrackerSUnitBornEvent_m_creatorUnitTagRecycle()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u32> m_creatorUnitTagRecycle = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_creatorUnitTagRecycle = Option.Some(ProtocolConversion<u32>.From(res));
        }
        else
        {
            m_creatorUnitTagRecycle = Option.None;
        }

        return m_creatorUnitTagRecycle;
    }
    public Option<byte[]> Parse_ReplayTrackerSUnitBornEvent_m_creatorAbilityName()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<byte[]> m_creatorAbilityName = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_blob();

            m_creatorAbilityName = Option.Some(res);          
        }
        else
        {
            m_creatorAbilityName = Option.None;
        }

        return m_creatorAbilityName;
    }

    public ReplayTrackerSUnitDiedEvent Parse_ReplayTrackerSUnitDiedEvent() 
    {
        Option<u32> m_unitTagIndex = Option.None;
        Option<u32> m_unitTagRecycle = Option.None;
        var m_killerPlayerId = Option.Some<Option<u8>>(Option.None);
        Option<u8> m_x = Option.None;
        Option<u8> m_y = Option.None;
        var m_killerUnitTagIndex = Option.Some<Option<u32>>(Option.None);
        var m_killerUnitTagRecycle = Option.Some<Option<u32>>(Option.None);
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_unitTagIndex is { HasValue: false })                           
                    {
                        var parsed_m_unitTagIndex = Parse_ReplayTrackerSUnitDiedEvent_m_unitTagIndex();
                        m_unitTagIndex = Option.Some(parsed_m_unitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_unitTagRecycle is { HasValue: false })                           
                    {
                        var parsed_m_unitTagRecycle = Parse_ReplayTrackerSUnitDiedEvent_m_unitTagRecycle();
                        m_unitTagRecycle = Option.Some(parsed_m_unitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_killerPlayerId is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_killerPlayerId = Parse_ReplayTrackerSUnitDiedEvent_m_killerPlayerId();
                        m_killerPlayerId = Option.Some(parsed_m_killerPlayerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_x is { HasValue: false })                           
                    {
                        var parsed_m_x = Parse_ReplayTrackerSUnitDiedEvent_m_x();
                        m_x = Option.Some(parsed_m_x);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_y is { HasValue: false })                           
                    {
                        var parsed_m_y = Parse_ReplayTrackerSUnitDiedEvent_m_y();
                        m_y = Option.Some(parsed_m_y);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_killerUnitTagIndex is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_killerUnitTagIndex = Parse_ReplayTrackerSUnitDiedEvent_m_killerUnitTagIndex();
                        m_killerUnitTagIndex = Option.Some(parsed_m_killerUnitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 6:
                {
                    if (m_killerUnitTagRecycle is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_killerUnitTagRecycle = Parse_ReplayTrackerSUnitDiedEvent_m_killerUnitTagRecycle();
                        m_killerUnitTagRecycle = Option.Some(parsed_m_killerUnitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUnitDiedEvent
        {   
            m_unitTagIndex = Option.OkOrReturnMissingFieldErr(m_unitTagIndex),
            m_unitTagRecycle = Option.OkOrReturnMissingFieldErr(m_unitTagRecycle),
            m_killerPlayerId = Option.OkOrReturnMissingFieldErr(m_killerPlayerId),
            m_x = Option.OkOrReturnMissingFieldErr(m_x),
            m_y = Option.OkOrReturnMissingFieldErr(m_y),
            m_killerUnitTagIndex = Option.OkOrReturnMissingFieldErr(m_killerUnitTagIndex),
            m_killerUnitTagRecycle = Option.OkOrReturnMissingFieldErr(m_killerUnitTagRecycle),
        };
    }
    public u32 Parse_ReplayTrackerSUnitDiedEvent_m_unitTagIndex()
    {                             
        var m_unitTagIndex = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagIndex);
    }
    public u32 Parse_ReplayTrackerSUnitDiedEvent_m_unitTagRecycle()
    {                             
        var m_unitTagRecycle = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagRecycle);
    }
    public Option<u8> Parse_ReplayTrackerSUnitDiedEvent_m_killerPlayerId()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u8> m_killerPlayerId = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_killerPlayerId = Option.Some(ProtocolConversion<u8>.From(res));
        }
        else
        {
            m_killerPlayerId = Option.None;
        }

        return m_killerPlayerId;
    }
    public u8 Parse_ReplayTrackerSUnitDiedEvent_m_x()
    {                             
        var m_x = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_x);
    }
    public u8 Parse_ReplayTrackerSUnitDiedEvent_m_y()
    {                             
        var m_y = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_y);
    }
    public Option<u32> Parse_ReplayTrackerSUnitDiedEvent_m_killerUnitTagIndex()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u32> m_killerUnitTagIndex = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_killerUnitTagIndex = Option.Some(ProtocolConversion<u32>.From(res));
        }
        else
        {
            m_killerUnitTagIndex = Option.None;
        }

        return m_killerUnitTagIndex;
    }
    public Option<u32> Parse_ReplayTrackerSUnitDiedEvent_m_killerUnitTagRecycle()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u32> m_killerUnitTagRecycle = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_killerUnitTagRecycle = Option.Some(ProtocolConversion<u32>.From(res));
        }
        else
        {
            m_killerUnitTagRecycle = Option.None;
        }

        return m_killerUnitTagRecycle;
    }

    public ReplayTrackerSUnitOwnerChangeEvent Parse_ReplayTrackerSUnitOwnerChangeEvent() 
    {
        Option<u32> m_unitTagIndex = Option.None;
        Option<u32> m_unitTagRecycle = Option.None;
        Option<u8> m_controlPlayerId = Option.None;
        Option<u8> m_upkeepPlayerId = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_unitTagIndex is { HasValue: false })                           
                    {
                        var parsed_m_unitTagIndex = Parse_ReplayTrackerSUnitOwnerChangeEvent_m_unitTagIndex();
                        m_unitTagIndex = Option.Some(parsed_m_unitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_unitTagRecycle is { HasValue: false })                           
                    {
                        var parsed_m_unitTagRecycle = Parse_ReplayTrackerSUnitOwnerChangeEvent_m_unitTagRecycle();
                        m_unitTagRecycle = Option.Some(parsed_m_unitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_controlPlayerId is { HasValue: false })                           
                    {
                        var parsed_m_controlPlayerId = Parse_ReplayTrackerSUnitOwnerChangeEvent_m_controlPlayerId();
                        m_controlPlayerId = Option.Some(parsed_m_controlPlayerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_upkeepPlayerId is { HasValue: false })                           
                    {
                        var parsed_m_upkeepPlayerId = Parse_ReplayTrackerSUnitOwnerChangeEvent_m_upkeepPlayerId();
                        m_upkeepPlayerId = Option.Some(parsed_m_upkeepPlayerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUnitOwnerChangeEvent
        {   
            m_unitTagIndex = Option.OkOrReturnMissingFieldErr(m_unitTagIndex),
            m_unitTagRecycle = Option.OkOrReturnMissingFieldErr(m_unitTagRecycle),
            m_controlPlayerId = Option.OkOrReturnMissingFieldErr(m_controlPlayerId),
            m_upkeepPlayerId = Option.OkOrReturnMissingFieldErr(m_upkeepPlayerId),
        };
    }
    public u32 Parse_ReplayTrackerSUnitOwnerChangeEvent_m_unitTagIndex()
    {                             
        var m_unitTagIndex = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagIndex);
    }
    public u32 Parse_ReplayTrackerSUnitOwnerChangeEvent_m_unitTagRecycle()
    {                             
        var m_unitTagRecycle = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagRecycle);
    }
    public u8 Parse_ReplayTrackerSUnitOwnerChangeEvent_m_controlPlayerId()
    {                             
        var m_controlPlayerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_controlPlayerId);
    }
    public u8 Parse_ReplayTrackerSUnitOwnerChangeEvent_m_upkeepPlayerId()
    {                             
        var m_upkeepPlayerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_upkeepPlayerId);
    }

    public ReplayTrackerSUnitTypeChangeEvent Parse_ReplayTrackerSUnitTypeChangeEvent() 
    {
        Option<u32> m_unitTagIndex = Option.None;
        Option<u32> m_unitTagRecycle = Option.None;
        Option<byte[]> m_unitTypeName = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_unitTagIndex is { HasValue: false })                           
                    {
                        var parsed_m_unitTagIndex = Parse_ReplayTrackerSUnitTypeChangeEvent_m_unitTagIndex();
                        m_unitTagIndex = Option.Some(parsed_m_unitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_unitTagRecycle is { HasValue: false })                           
                    {
                        var parsed_m_unitTagRecycle = Parse_ReplayTrackerSUnitTypeChangeEvent_m_unitTagRecycle();
                        m_unitTagRecycle = Option.Some(parsed_m_unitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_unitTypeName is { HasValue: false })                           
                    {
                        var parsed_m_unitTypeName = Parse_ReplayTrackerSUnitTypeChangeEvent_m_unitTypeName();
                        m_unitTypeName = Option.Some(parsed_m_unitTypeName);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUnitTypeChangeEvent
        {   
            m_unitTagIndex = Option.OkOrReturnMissingFieldErr(m_unitTagIndex),
            m_unitTagRecycle = Option.OkOrReturnMissingFieldErr(m_unitTagRecycle),
            m_unitTypeName = Option.OkOrReturnMissingFieldErr(m_unitTypeName),
        };
    }
    public u32 Parse_ReplayTrackerSUnitTypeChangeEvent_m_unitTagIndex()
    {                             
        var m_unitTagIndex = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagIndex);
    }
    public u32 Parse_ReplayTrackerSUnitTypeChangeEvent_m_unitTagRecycle()
    {                             
        var m_unitTagRecycle = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagRecycle);
    }
    public byte[] Parse_ReplayTrackerSUnitTypeChangeEvent_m_unitTypeName()
    {                             
        var m_unitTypeName = tagged_blob();
        return m_unitTypeName;
    }

    public ReplayTrackerSUpgradeEvent Parse_ReplayTrackerSUpgradeEvent() 
    {
        Option<u8> m_playerId = Option.None;
        Option<byte[]> m_upgradeTypeName = Option.None;
        Option<i32> m_count = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_playerId is { HasValue: false })                           
                    {
                        var parsed_m_playerId = Parse_ReplayTrackerSUpgradeEvent_m_playerId();
                        m_playerId = Option.Some(parsed_m_playerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_upgradeTypeName is { HasValue: false })                           
                    {
                        var parsed_m_upgradeTypeName = Parse_ReplayTrackerSUpgradeEvent_m_upgradeTypeName();
                        m_upgradeTypeName = Option.Some(parsed_m_upgradeTypeName);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_count is { HasValue: false })                           
                    {
                        var parsed_m_count = Parse_ReplayTrackerSUpgradeEvent_m_count();
                        m_count = Option.Some(parsed_m_count);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUpgradeEvent
        {   
            m_playerId = Option.OkOrReturnMissingFieldErr(m_playerId),
            m_upgradeTypeName = Option.OkOrReturnMissingFieldErr(m_upgradeTypeName),
            m_count = Option.OkOrReturnMissingFieldErr(m_count),
        };
    }
    public u8 Parse_ReplayTrackerSUpgradeEvent_m_playerId()
    {                             
        var m_playerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_playerId);
    }
    public byte[] Parse_ReplayTrackerSUpgradeEvent_m_upgradeTypeName()
    {                             
        var m_upgradeTypeName = tagged_blob();
        return m_upgradeTypeName;
    }
    public i32 Parse_ReplayTrackerSUpgradeEvent_m_count()
    {                             
        var m_count = tagged_vlq_int();
        return ProtocolConversion<i32>.From(m_count);
    }

    public ReplayTrackerSUnitInitEvent Parse_ReplayTrackerSUnitInitEvent() 
    {
        Option<u32> m_unitTagIndex = Option.None;
        Option<u32> m_unitTagRecycle = Option.None;
        Option<byte[]> m_unitTypeName = Option.None;
        Option<u8> m_controlPlayerId = Option.None;
        Option<u8> m_upkeepPlayerId = Option.None;
        Option<u8> m_x = Option.None;
        Option<u8> m_y = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_unitTagIndex is { HasValue: false })                           
                    {
                        var parsed_m_unitTagIndex = Parse_ReplayTrackerSUnitInitEvent_m_unitTagIndex();
                        m_unitTagIndex = Option.Some(parsed_m_unitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_unitTagRecycle is { HasValue: false })                           
                    {
                        var parsed_m_unitTagRecycle = Parse_ReplayTrackerSUnitInitEvent_m_unitTagRecycle();
                        m_unitTagRecycle = Option.Some(parsed_m_unitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_unitTypeName is { HasValue: false })                           
                    {
                        var parsed_m_unitTypeName = Parse_ReplayTrackerSUnitInitEvent_m_unitTypeName();
                        m_unitTypeName = Option.Some(parsed_m_unitTypeName);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_controlPlayerId is { HasValue: false })                           
                    {
                        var parsed_m_controlPlayerId = Parse_ReplayTrackerSUnitInitEvent_m_controlPlayerId();
                        m_controlPlayerId = Option.Some(parsed_m_controlPlayerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 4:
                {
                    if (m_upkeepPlayerId is { HasValue: false })                           
                    {
                        var parsed_m_upkeepPlayerId = Parse_ReplayTrackerSUnitInitEvent_m_upkeepPlayerId();
                        m_upkeepPlayerId = Option.Some(parsed_m_upkeepPlayerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 5:
                {
                    if (m_x is { HasValue: false })                           
                    {
                        var parsed_m_x = Parse_ReplayTrackerSUnitInitEvent_m_x();
                        m_x = Option.Some(parsed_m_x);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 6:
                {
                    if (m_y is { HasValue: false })                           
                    {
                        var parsed_m_y = Parse_ReplayTrackerSUnitInitEvent_m_y();
                        m_y = Option.Some(parsed_m_y);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUnitInitEvent
        {   
            m_unitTagIndex = Option.OkOrReturnMissingFieldErr(m_unitTagIndex),
            m_unitTagRecycle = Option.OkOrReturnMissingFieldErr(m_unitTagRecycle),
            m_unitTypeName = Option.OkOrReturnMissingFieldErr(m_unitTypeName),
            m_controlPlayerId = Option.OkOrReturnMissingFieldErr(m_controlPlayerId),
            m_upkeepPlayerId = Option.OkOrReturnMissingFieldErr(m_upkeepPlayerId),
            m_x = Option.OkOrReturnMissingFieldErr(m_x),
            m_y = Option.OkOrReturnMissingFieldErr(m_y),
        };
    }
    public u32 Parse_ReplayTrackerSUnitInitEvent_m_unitTagIndex()
    {                             
        var m_unitTagIndex = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagIndex);
    }
    public u32 Parse_ReplayTrackerSUnitInitEvent_m_unitTagRecycle()
    {                             
        var m_unitTagRecycle = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagRecycle);
    }
    public byte[] Parse_ReplayTrackerSUnitInitEvent_m_unitTypeName()
    {                             
        var m_unitTypeName = tagged_blob();
        return m_unitTypeName;
    }
    public u8 Parse_ReplayTrackerSUnitInitEvent_m_controlPlayerId()
    {                             
        var m_controlPlayerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_controlPlayerId);
    }
    public u8 Parse_ReplayTrackerSUnitInitEvent_m_upkeepPlayerId()
    {                             
        var m_upkeepPlayerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_upkeepPlayerId);
    }
    public u8 Parse_ReplayTrackerSUnitInitEvent_m_x()
    {                             
        var m_x = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_x);
    }
    public u8 Parse_ReplayTrackerSUnitInitEvent_m_y()
    {                             
        var m_y = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_y);
    }

    public ReplayTrackerSUnitDoneEvent Parse_ReplayTrackerSUnitDoneEvent() 
    {
        Option<u32> m_unitTagIndex = Option.None;
        Option<u32> m_unitTagRecycle = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_unitTagIndex is { HasValue: false })                           
                    {
                        var parsed_m_unitTagIndex = Parse_ReplayTrackerSUnitDoneEvent_m_unitTagIndex();
                        m_unitTagIndex = Option.Some(parsed_m_unitTagIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_unitTagRecycle is { HasValue: false })                           
                    {
                        var parsed_m_unitTagRecycle = Parse_ReplayTrackerSUnitDoneEvent_m_unitTagRecycle();
                        m_unitTagRecycle = Option.Some(parsed_m_unitTagRecycle);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUnitDoneEvent
        {   
            m_unitTagIndex = Option.OkOrReturnMissingFieldErr(m_unitTagIndex),
            m_unitTagRecycle = Option.OkOrReturnMissingFieldErr(m_unitTagRecycle),
        };
    }
    public u32 Parse_ReplayTrackerSUnitDoneEvent_m_unitTagIndex()
    {                             
        var m_unitTagIndex = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagIndex);
    }
    public u32 Parse_ReplayTrackerSUnitDoneEvent_m_unitTagRecycle()
    {                             
        var m_unitTagRecycle = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_unitTagRecycle);
    }

    public ReplayTrackerSUnitPositionsEvent Parse_ReplayTrackerSUnitPositionsEvent() 
    {
        Option<u32> m_firstUnitIndex = Option.None;
        Option<i32[]> m_items = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_firstUnitIndex is { HasValue: false })                           
                    {
                        var parsed_m_firstUnitIndex = Parse_ReplayTrackerSUnitPositionsEvent_m_firstUnitIndex();
                        m_firstUnitIndex = Option.Some(parsed_m_firstUnitIndex);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_items is { HasValue: false })                           
                    {
                        var parsed_m_items = Parse_ReplayTrackerSUnitPositionsEvent_m_items();
                        m_items = Option.Some(parsed_m_items);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSUnitPositionsEvent
        {   
            m_firstUnitIndex = Option.OkOrReturnMissingFieldErr(m_firstUnitIndex),
            m_items = Option.OkOrReturnMissingFieldErr(m_items),
        };
    }
    public u32 Parse_ReplayTrackerSUnitPositionsEvent_m_firstUnitIndex()
    {                             
        var m_firstUnitIndex = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_firstUnitIndex);
    }
    public i32[] Parse_ReplayTrackerSUnitPositionsEvent_m_items()
    {                             
        ValidateArrayTag();
        var arrayLength = ParseVlqInt();
        var array = ReadArray(tagged_vlq_int, arrayLength);

        return array.Select(ProtocolConversion<i32>.From).ToArray();
    }

    public ReplayTrackerSPlayerSetupEvent Parse_ReplayTrackerSPlayerSetupEvent() 
    {
        Option<u8> m_playerId = Option.None;
        Option<u32> m_type = Option.None;
        var m_userId = Option.Some<Option<u32>>(Option.None);
        var m_slotId = Option.Some<Option<u32>>(Option.None);
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_playerId is { HasValue: false })                           
                    {
                        var parsed_m_playerId = Parse_ReplayTrackerSPlayerSetupEvent_m_playerId();
                        m_playerId = Option.Some(parsed_m_playerId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 1:
                {
                    if (m_type is { HasValue: false })                           
                    {
                        var parsed_m_type = Parse_ReplayTrackerSPlayerSetupEvent_m_type();
                        m_type = Option.Some(parsed_m_type);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 2:
                {
                    if (m_userId is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_userId = Parse_ReplayTrackerSPlayerSetupEvent_m_userId();
                        m_userId = Option.Some(parsed_m_userId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                case 3:
                {
                    if (m_slotId is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_slotId = Parse_ReplayTrackerSPlayerSetupEvent_m_slotId();
                        m_slotId = Option.Some(parsed_m_slotId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
            }
        }
        return new ReplayTrackerSPlayerSetupEvent
        {   
            m_playerId = Option.OkOrReturnMissingFieldErr(m_playerId),
            m_type = Option.OkOrReturnMissingFieldErr(m_type),
            m_userId = Option.OkOrReturnMissingFieldErr(m_userId),
            m_slotId = Option.OkOrReturnMissingFieldErr(m_slotId),
        };
    }
    public u8 Parse_ReplayTrackerSPlayerSetupEvent_m_playerId()
    {                             
        var m_playerId = tagged_vlq_int();
        return ProtocolConversion<u8>.From(m_playerId);
    }
    public u32 Parse_ReplayTrackerSPlayerSetupEvent_m_type()
    {                             
        var m_type = tagged_vlq_int();
        return ProtocolConversion<u32>.From(m_type);
    }
    public Option<u32> Parse_ReplayTrackerSPlayerSetupEvent_m_userId()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u32> m_userId = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_userId = Option.Some(ProtocolConversion<u32>.From(res));
        }
        else
        {
            m_userId = Option.None;
        }

        return m_userId;
    }
    public Option<u32> Parse_ReplayTrackerSPlayerSetupEvent_m_slotId()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<u32> m_slotId = default;
        if (isProvided != 0)
        {                                   
            var res = tagged_vlq_int();

            m_slotId = Option.Some(ProtocolConversion<u32>.From(res));
        }
        else
        {
            m_slotId = Option.None;
        }

        return m_slotId;
    }
    public EObserve Parse_EObserve()
    {
        ValidateIntTag();
        var variantTag = ParseVlqInt();

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new EObserve_e_none();
            }                
            case 1:
            {                        
                return new EObserve_e_spectator();
            }                
            case 2:
            {                        
                return new EObserve_e_referee();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEGameSpeed Parse_GameEGameSpeed()
    {
        ValidateIntTag();
        var variantTag = ParseVlqInt();

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEGameSpeed_e_slower();
            }                
            case 1:
            {                        
                return new GameEGameSpeed_e_slow();
            }                
            case 2:
            {                        
                return new GameEGameSpeed_e_normal();
            }                
            case 3:
            {                        
                return new GameEGameSpeed_e_fast();
            }                
            case 4:
            {                        
                return new GameEGameSpeed_e_faster();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEResultDetails Parse_GameEResultDetails()
    {
        ValidateIntTag();
        var variantTag = ParseVlqInt();

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEResultDetails_e_undecided();
            }                
            case 1:
            {                        
                return new GameEResultDetails_e_win();
            }                
            case 2:
            {                        
                return new GameEResultDetails_e_loss();
            }                
            case 3:
            {                        
                return new GameEResultDetails_e_tie();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public ReplayTrackerEEventId Parse_ReplayTrackerEEventId()
    {
        ValidateIntTag();
        var variantTag = ParseVlqInt();

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_ReplayTrackerSPlayerStatsEvent();

                return new ReplayTrackerEEventId_e_playerStats(res);
            }                
            case 1:
            {                        
                var res = Parse_ReplayTrackerSUnitBornEvent();

                return new ReplayTrackerEEventId_e_unitBorn(res);
            }                
            case 2:
            {                        
                var res = Parse_ReplayTrackerSUnitDiedEvent();

                return new ReplayTrackerEEventId_e_unitDied(res);
            }                
            case 3:
            {                        
                var res = Parse_ReplayTrackerSUnitOwnerChangeEvent();

                return new ReplayTrackerEEventId_e_unitOwnerChange(res);
            }                
            case 4:
            {                        
                var res = Parse_ReplayTrackerSUnitTypeChangeEvent();

                return new ReplayTrackerEEventId_e_unitTypeChange(res);
            }                
            case 5:
            {                        
                var res = Parse_ReplayTrackerSUpgradeEvent();

                return new ReplayTrackerEEventId_e_upgrade(res);
            }                
            case 6:
            {                        
                var res = Parse_ReplayTrackerSUnitInitEvent();

                return new ReplayTrackerEEventId_e_unitInit(res);
            }                
            case 7:
            {                        
                var res = Parse_ReplayTrackerSUnitDoneEvent();

                return new ReplayTrackerEEventId_e_unitDone(res);
            }                
            case 8:
            {                        
                var res = Parse_ReplayTrackerSUnitPositionsEvent();

                return new ReplayTrackerEEventId_e_unitPosition(res);
            }                
            case 9:
            {                        
                var res = Parse_ReplayTrackerSPlayerSetupEvent();

                return new ReplayTrackerEEventId_e_playerSetup(res);
            }                
            default:
            {
                return new ReplayTrackerEEventId_e_unknown();
            }
        }
    }
    public GameCPlayerDetailsArray Parse_GameCPlayerDetailsArray()
    {
        ValidateArrayTag();

        var arrayLength = ParseVlqInt();
        var value = ReadArray(Parse_GameSPlayerDetails, arrayLength);

        return new GameCPlayerDetailsArray
        {
            Value = value
        };
    }

}
