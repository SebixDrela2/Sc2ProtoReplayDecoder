using Sc2ReplayAnalyzer.Global;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
using Sc2ReplayAnalyzer.Decoder.Factory;

namespace Sc2ReplayAnalyzer.Json.protocol73559.BitPacked;

public class BitPackedProtocolParser(BinaryReader reader) : BitPackedProtocolParserImpl(reader), IBitPackedProtocolParser
{

    public SVarUint32 Parse_SVarUint32() 
    {
        var offset = 0;
        var numBits = 2;
        var variantTag = parse_packed_int(offset, numBits);

        switch (variantTag)
        {
            case 0:
            {
                var res = Parse_uint6();

                return new m_uint6
                {
                    Value = res
                };
            }
            case 1:
            {
                var res = Parse_uint14();

                return new m_uint14
                {
                    Value = res
                };
            }
            case 2:
            {
                var res = Parse_uint22();

                return new m_uint22
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_uint32();

                return new m_uint32
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public GameSCmdData Parse_GameSCmdData() 
    {
        var offset = 0;
        var numBits = 2;
        var variantTag = parse_packed_int(offset, numBits);

        switch (variantTag)
        {
            case 0:
            {
                var res = take_null();

                return default;
            }
            case 1:
            {
                var res = Parse_GameSMapCoord3D();

                return new TargetPoint
                {
                    Value = res
                };
            }
            case 2:
            {
                var res = Parse_GameSCmdDataTargetUnit();

                return new TargetUnit
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_uint32();

                return new Data
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public m_eventData Parse_m_eventData() 
    {
        var offset = 0;
        var numBits = 3;
        var variantTag = parse_packed_int(offset, numBits);

        switch (variantTag)
        {
            case 0:
            {
                var res = take_null();

                return default;
            }
            case 1:
            {
                var res = parse_bool();

                return new Checked
                {
                    Value = res
                };
            }
            case 2:
            {
                var res = Parse_uint32();

                return new ValueChanged
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_int32();

                return new SelectionChanged
                {
                    Value = res
                };
            }
            case 4:
            {
                var res = Parse_GameCChatString();

                return new TextChanged
                {
                    Value = res
                };
            }
            case 5:
            {
                var res = Parse_uint32();

                return new MouseButton
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public GameSLobbySlotChange Parse_GameSLobbySlotChange() 
    {
        var offset = 0;
        var numBits = 5;
        var variantTag = parse_packed_int(offset, numBits);

        switch (variantTag)
        {
            case 0:
            {
                var res = Parse_GameTControlId();

                return new m_control
                {
                    Value = res
                };
            }
            case 1:
            {
                var isProvided = parse_bool();
                var res = Parse_TUserId();

                if (isProvided)
                {
                    return new m_userId
                    {
                        Value = Option.Some(res)
                    };
                }
                else
                {
                    return new m_userId
                    {
                        Value = Option.None
                    };
                }
            }
            case 2:
            {
                var res = Parse_GameTTeamId();

                return new m_teamId
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_GameTColorPreference();

                return new m_colorPref
                {
                    Value = res
                };
            }
            case 4:
            {
                var res = Parse_TRacePreference();

                return new m_racePref
                {
                    Value = res
                };
            }
            case 5:
            {
                var res = Parse_GameTDifficulty();

                return new m_difficulty
                {
                    Value = res
                };
            }
            case 6:
            {
                var res = Parse_GameTAIBuild();

                return new m_aiBuild
                {
                    Value = res
                };
            }
            case 7:
            {
                var res = Parse_GameTHandicap();

                return new m_handicap
                {
                    Value = res
                };
            }
            case 8:
            {
                var res = Parse_EObserve();

                return new m_observe
                {
                    Value = res
                };
            }
            case 9:
            {
                var res = Parse_GameTPlayerLogoIndex();

                return new m_logoIndex
                {
                    Value = res
                };
            }
            case 10:
            {
                var res = Parse_CHeroHandle();

                return new m_hero
                {
                    Value = res
                };
            }
            case 11:
            {
                var res = Parse_CSkinHandle();

                return new m_skin
                {
                    Value = res
                };
            }
            case 12:
            {
                var res = Parse_CMountHandle();

                return new m_mount
                {
                    Value = res
                };
            }
            case 13:
            {
                var res = Parse_GameCLicenseArray();

                return new m_licenses
                {
                    Value = res
                };
            }
            case 14:
            {
                var isProvided = parse_bool();
                var res = Parse_TUserId();

                if (isProvided)
                {
                    return new m_tandemLeaderId
                    {
                        Value = Option.Some(res)
                    };
                }
                else
                {
                    return new m_tandemLeaderId
                    {
                        Value = Option.None
                    };
                }
            }
            case 15:
            {
                var res = Parse_CCommanderHandle();

                return new m_commander
                {
                    Value = res
                };
            }
            case 16:
            {
                var res = Parse_uint32();

                return new m_commanderLevel
                {
                    Value = res
                };
            }
            case 17:
            {
                var res = parse_bool();

                return new m_hasSilencePenalty
                {
                    Value = res
                };
            }
            case 18:
            {
                var isProvided = parse_bool();
                var res = Parse_TUserId();

                if (isProvided)
                {
                    return new m_tandemId
                    {
                        Value = Option.Some(res)
                    };
                }
                else
                {
                    return new m_tandemId
                    {
                        Value = Option.None
                    };
                }
            }
            case 19:
            {
                var res = Parse_uint32();

                return new m_commanderMasteryLevel
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public GameSSelectionMask Parse_GameSSelectionMask() 
    {
        var offset = 0;
        var numBits = 2;
        var variantTag = parse_packed_int(offset, numBits);

        switch (variantTag)
        {
            case 0:
            {
                var res = take_null();

                return default;
            }
            case 1:
            {
                var res = Parse_GameSelectionMaskType();

                return new Mask
                {
                    Value = res
                };
            }
            case 2:
            {
                var res = Parse_GameSelectionIndexArrayType();

                return new OneIndices
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_GameSelectionIndexArrayType();

                return new ZeroIndices
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public TRacePreference Parse_TRacePreference() 
    {
        var m_race = Option.Some<Option<TRaceId>>(Option.None);
        if (m_race is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_race = Parse_TRacePreference_m_race();
            m_race = Option.Some(parsed_m_race);
        }

        return new TRacePreference
        {   
            m_race = Option.OkOrReturnMissingFieldErr(m_race),
        };
    }

    public Option<TRaceId> Parse_TRacePreference_m_race()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TRaceId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public TTeamPreference Parse_TTeamPreference() 
    {
        var m_team = Option.Some<Option<uint8>>(Option.None);
        if (m_team is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_team = Parse_TTeamPreference_m_team();
            m_team = Option.Some(parsed_m_team);
        }

        return new TTeamPreference
        {   
            m_team = Option.OkOrReturnMissingFieldErr(m_team),
        };
    }

    public Option<uint8> Parse_TTeamPreference_m_team()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public SUserInitialData Parse_SUserInitialData() 
    {
        Option<CUserName> m_name = Option.None;
        var m_clanTag = Option.Some<Option<CClanTag>>(Option.None);
        var m_clanLogo = Option.Some<Option<CCacheHandle>>(Option.None);
        var m_highestLeague = Option.Some<Option<uint8>>(Option.None);
        var m_combinedRaceLevels = Option.Some<Option<uint32>>(Option.None);
        Option<uint32> m_randomSeed = Option.None;
        Option<TRacePreference> m_racePreference = Option.None;
        Option<TTeamPreference> m_teamPreference = Option.None;
        Option<bool> m_testMap = Option.None;
        Option<bool> m_testAuto = Option.None;
        Option<bool> m_examine = Option.None;
        Option<bool> m_customInterface = Option.None;
        Option<uint32> m_testType = Option.None;
        Option<EObserve> m_observe = Option.None;
        Option<CHeroHandle> m_hero = Option.None;
        Option<CSkinHandle> m_skin = Option.None;
        Option<CMountHandle> m_mount = Option.None;
        Option<CToonHandle> m_toonHandle = Option.None;
        var m_scaledRating = Option.Some<Option<int32>>(Option.None);
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_SUserInitialData_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_clanTag is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_clanTag = Parse_SUserInitialData_m_clanTag();
            m_clanTag = Option.Some(parsed_m_clanTag);
        }

        if (m_clanLogo is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_clanLogo = Parse_SUserInitialData_m_clanLogo();
            m_clanLogo = Option.Some(parsed_m_clanLogo);
        }

        if (m_highestLeague is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_highestLeague = Parse_SUserInitialData_m_highestLeague();
            m_highestLeague = Option.Some(parsed_m_highestLeague);
        }

        if (m_combinedRaceLevels is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_combinedRaceLevels = Parse_SUserInitialData_m_combinedRaceLevels();
            m_combinedRaceLevels = Option.Some(parsed_m_combinedRaceLevels);
        }

        if (m_randomSeed is { HasValue: false })                           
        {
            var parsed_m_randomSeed = Parse_SUserInitialData_m_randomSeed();
            m_randomSeed = Option.Some(parsed_m_randomSeed);
        }

        if (m_racePreference is { HasValue: false })                           
        {
            var parsed_m_racePreference = Parse_SUserInitialData_m_racePreference();
            m_racePreference = Option.Some(parsed_m_racePreference);
        }

        if (m_teamPreference is { HasValue: false })                           
        {
            var parsed_m_teamPreference = Parse_SUserInitialData_m_teamPreference();
            m_teamPreference = Option.Some(parsed_m_teamPreference);
        }

        if (m_testMap is { HasValue: false })                           
        {
            var parsed_m_testMap = Parse_SUserInitialData_m_testMap();
            m_testMap = Option.Some(parsed_m_testMap);
        }

        if (m_testAuto is { HasValue: false })                           
        {
            var parsed_m_testAuto = Parse_SUserInitialData_m_testAuto();
            m_testAuto = Option.Some(parsed_m_testAuto);
        }

        if (m_examine is { HasValue: false })                           
        {
            var parsed_m_examine = Parse_SUserInitialData_m_examine();
            m_examine = Option.Some(parsed_m_examine);
        }

        if (m_customInterface is { HasValue: false })                           
        {
            var parsed_m_customInterface = Parse_SUserInitialData_m_customInterface();
            m_customInterface = Option.Some(parsed_m_customInterface);
        }

        if (m_testType is { HasValue: false })                           
        {
            var parsed_m_testType = Parse_SUserInitialData_m_testType();
            m_testType = Option.Some(parsed_m_testType);
        }

        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_SUserInitialData_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        if (m_hero is { HasValue: false })                           
        {
            var parsed_m_hero = Parse_SUserInitialData_m_hero();
            m_hero = Option.Some(parsed_m_hero);
        }

        if (m_skin is { HasValue: false })                           
        {
            var parsed_m_skin = Parse_SUserInitialData_m_skin();
            m_skin = Option.Some(parsed_m_skin);
        }

        if (m_mount is { HasValue: false })                           
        {
            var parsed_m_mount = Parse_SUserInitialData_m_mount();
            m_mount = Option.Some(parsed_m_mount);
        }

        if (m_toonHandle is { HasValue: false })                           
        {
            var parsed_m_toonHandle = Parse_SUserInitialData_m_toonHandle();
            m_toonHandle = Option.Some(parsed_m_toonHandle);
        }

        if (m_scaledRating is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_scaledRating = Parse_SUserInitialData_m_scaledRating();
            m_scaledRating = Option.Some(parsed_m_scaledRating);
        }

        return new SUserInitialData
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_clanTag = Option.OkOrReturnMissingFieldErr(m_clanTag),
            m_clanLogo = Option.OkOrReturnMissingFieldErr(m_clanLogo),
            m_highestLeague = Option.OkOrReturnMissingFieldErr(m_highestLeague),
            m_combinedRaceLevels = Option.OkOrReturnMissingFieldErr(m_combinedRaceLevels),
            m_randomSeed = Option.OkOrReturnMissingFieldErr(m_randomSeed),
            m_racePreference = Option.OkOrReturnMissingFieldErr(m_racePreference),
            m_teamPreference = Option.OkOrReturnMissingFieldErr(m_teamPreference),
            m_testMap = Option.OkOrReturnMissingFieldErr(m_testMap),
            m_testAuto = Option.OkOrReturnMissingFieldErr(m_testAuto),
            m_examine = Option.OkOrReturnMissingFieldErr(m_examine),
            m_customInterface = Option.OkOrReturnMissingFieldErr(m_customInterface),
            m_testType = Option.OkOrReturnMissingFieldErr(m_testType),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
            m_hero = Option.OkOrReturnMissingFieldErr(m_hero),
            m_skin = Option.OkOrReturnMissingFieldErr(m_skin),
            m_mount = Option.OkOrReturnMissingFieldErr(m_mount),
            m_toonHandle = Option.OkOrReturnMissingFieldErr(m_toonHandle),
            m_scaledRating = Option.OkOrReturnMissingFieldErr(m_scaledRating),
        };
    }

    public CUserName Parse_SUserInitialData_m_name()
    {                             
        var m_name = Parse_CUserName();
        return m_name;
    }

    public Option<CClanTag> Parse_SUserInitialData_m_clanTag()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_CClanTag();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<CCacheHandle> Parse_SUserInitialData_m_clanLogo()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_CCacheHandle();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<uint8> Parse_SUserInitialData_m_highestLeague()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<uint32> Parse_SUserInitialData_m_combinedRaceLevels()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint32();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public uint32 Parse_SUserInitialData_m_randomSeed()
    {                             
        var m_randomSeed = Parse_uint32();
        return m_randomSeed;
    }

    public TRacePreference Parse_SUserInitialData_m_racePreference()
    {                             
        var m_racePreference = Parse_TRacePreference();
        return m_racePreference;
    }

    public TTeamPreference Parse_SUserInitialData_m_teamPreference()
    {                             
        var m_teamPreference = Parse_TTeamPreference();
        return m_teamPreference;
    }

    public bool Parse_SUserInitialData_m_testMap()
    {                             
        var m_testMap = parse_bool();
        return m_testMap;
    }

    public bool Parse_SUserInitialData_m_testAuto()
    {                             
        var m_testAuto = parse_bool();
        return m_testAuto;
    }

    public bool Parse_SUserInitialData_m_examine()
    {                             
        var m_examine = parse_bool();
        return m_examine;
    }

    public bool Parse_SUserInitialData_m_customInterface()
    {                             
        var m_customInterface = parse_bool();
        return m_customInterface;
    }

    public uint32 Parse_SUserInitialData_m_testType()
    {                             
        var m_testType = Parse_uint32();
        return m_testType;
    }

    public EObserve Parse_SUserInitialData_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }

    public CHeroHandle Parse_SUserInitialData_m_hero()
    {                             
        var m_hero = Parse_CHeroHandle();
        return m_hero;
    }

    public CSkinHandle Parse_SUserInitialData_m_skin()
    {                             
        var m_skin = Parse_CSkinHandle();
        return m_skin;
    }

    public CMountHandle Parse_SUserInitialData_m_mount()
    {                             
        var m_mount = Parse_CMountHandle();
        return m_mount;
    }

    public CToonHandle Parse_SUserInitialData_m_toonHandle()
    {                             
        var m_toonHandle = Parse_CToonHandle();
        return m_toonHandle;
    }

    public Option<int32> Parse_SUserInitialData_m_scaledRating()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_int32();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public SVersion Parse_SVersion() 
    {
        Option<uint8> m_flags = Option.None;
        Option<uint8> m_major = Option.None;
        Option<uint8> m_minor = Option.None;
        Option<uint8> m_revision = Option.None;
        Option<uint32> m_build = Option.None;
        Option<uint32> m_baseBuild = Option.None;
        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_SVersion_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        if (m_major is { HasValue: false })                           
        {
            var parsed_m_major = Parse_SVersion_m_major();
            m_major = Option.Some(parsed_m_major);
        }

        if (m_minor is { HasValue: false })                           
        {
            var parsed_m_minor = Parse_SVersion_m_minor();
            m_minor = Option.Some(parsed_m_minor);
        }

        if (m_revision is { HasValue: false })                           
        {
            var parsed_m_revision = Parse_SVersion_m_revision();
            m_revision = Option.Some(parsed_m_revision);
        }

        if (m_build is { HasValue: false })                           
        {
            var parsed_m_build = Parse_SVersion_m_build();
            m_build = Option.Some(parsed_m_build);
        }

        if (m_baseBuild is { HasValue: false })                           
        {
            var parsed_m_baseBuild = Parse_SVersion_m_baseBuild();
            m_baseBuild = Option.Some(parsed_m_baseBuild);
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

    public uint8 Parse_SVersion_m_flags()
    {                             
        var m_flags = Parse_uint8();
        return m_flags;
    }

    public uint8 Parse_SVersion_m_major()
    {                             
        var m_major = Parse_uint8();
        return m_major;
    }

    public uint8 Parse_SVersion_m_minor()
    {                             
        var m_minor = Parse_uint8();
        return m_minor;
    }

    public uint8 Parse_SVersion_m_revision()
    {                             
        var m_revision = Parse_uint8();
        return m_revision;
    }

    public uint32 Parse_SVersion_m_build()
    {                             
        var m_build = Parse_uint32();
        return m_build;
    }

    public uint32 Parse_SVersion_m_baseBuild()
    {                             
        var m_baseBuild = Parse_uint32();
        return m_baseBuild;
    }

    public SMD5 Parse_SMD5() 
    {
        var m_dataDeprecated = Option.Some<Option<List<uint8>>>(Option.None);
        Option<List<u8>> m_data = Option.None;
        if (m_dataDeprecated is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_dataDeprecated = Parse_SMD5_m_dataDeprecated();
            m_dataDeprecated = Option.Some(parsed_m_dataDeprecated);
        }

        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_SMD5_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new SMD5
        {   
            m_dataDeprecated = Option.OkOrReturnMissingFieldErr(m_dataDeprecated),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public Option<List<uint8>> Parse_SMD5_m_dataDeprecated()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var arrayLength = take_n_bits_into_i64(5);

                var array = ReadList(Parse_uint8, arrayLength);
        

                return Option.Some(array);
            }
            else
            {
                return Option.None;
            }
    }

    public List<u8> Parse_SMD5_m_data()
    {                             
        var arrayLength = take_n_bits_into_i64(5);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameTColorPreference Parse_GameTColorPreference() 
    {
        var m_color = Option.Some<Option<GameTColorId>>(Option.None);
        if (m_color is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_color = Parse_GameTColorPreference_m_color();
            m_color = Option.Some(parsed_m_color);
        }

        return new GameTColorPreference
        {   
            m_color = Option.OkOrReturnMissingFieldErr(m_color),
        };
    }

    public Option<GameTColorId> Parse_GameTColorPreference_m_color()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTColorId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCmdAbil Parse_GameSCmdAbil() 
    {
        Option<GameTAbilLink> m_abilLink = Option.None;
        Option<i64> m_abilCmdIndex = Option.None;
        var m_abilCmdData = Option.Some<Option<uint8>>(Option.None);
        if (m_abilLink is { HasValue: false })                           
        {
            var parsed_m_abilLink = Parse_GameSCmdAbil_m_abilLink();
            m_abilLink = Option.Some(parsed_m_abilLink);
        }

        if (m_abilCmdIndex is { HasValue: false })                           
        {
            var parsed_m_abilCmdIndex = Parse_GameSCmdAbil_m_abilCmdIndex();
            m_abilCmdIndex = Option.Some(parsed_m_abilCmdIndex);
        }

        if (m_abilCmdData is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_abilCmdData = Parse_GameSCmdAbil_m_abilCmdData();
            m_abilCmdData = Option.Some(parsed_m_abilCmdData);
        }

        return new GameSCmdAbil
        {   
            m_abilLink = Option.OkOrReturnMissingFieldErr(m_abilLink),
            m_abilCmdIndex = Option.OkOrReturnMissingFieldErr(m_abilCmdIndex),
            m_abilCmdData = Option.OkOrReturnMissingFieldErr(m_abilCmdData),
        };
    }

    public GameTAbilLink Parse_GameSCmdAbil_m_abilLink()
    {                             
        var m_abilLink = Parse_GameTAbilLink();
        return m_abilLink;
    }

    public i64 Parse_GameSCmdAbil_m_abilCmdIndex()
    {                             
        var m_abilCmdIndex = parse_packed_int(0, 5);
        return m_abilCmdIndex;
    }

    public Option<uint8> Parse_GameSCmdAbil_m_abilCmdData()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCmdDataTargetUnit Parse_GameSCmdDataTargetUnit() 
    {
        Option<uint16> m_targetUnitFlags = Option.None;
        Option<uint8> m_timer = Option.None;
        Option<GameTUnitTag> m_tag = Option.None;
        Option<GameTUnitLink> m_snapshotUnitLink = Option.None;
        var m_snapshotControlPlayerId = Option.Some<Option<GameTPlayerId>>(Option.None);
        var m_snapshotUpkeepPlayerId = Option.Some<Option<GameTPlayerId>>(Option.None);
        Option<GameSMapCoord3D> m_snapshotPoint = Option.None;
        if (m_targetUnitFlags is { HasValue: false })                           
        {
            var parsed_m_targetUnitFlags = Parse_GameSCmdDataTargetUnit_m_targetUnitFlags();
            m_targetUnitFlags = Option.Some(parsed_m_targetUnitFlags);
        }

        if (m_timer is { HasValue: false })                           
        {
            var parsed_m_timer = Parse_GameSCmdDataTargetUnit_m_timer();
            m_timer = Option.Some(parsed_m_timer);
        }

        if (m_tag is { HasValue: false })                           
        {
            var parsed_m_tag = Parse_GameSCmdDataTargetUnit_m_tag();
            m_tag = Option.Some(parsed_m_tag);
        }

        if (m_snapshotUnitLink is { HasValue: false })                           
        {
            var parsed_m_snapshotUnitLink = Parse_GameSCmdDataTargetUnit_m_snapshotUnitLink();
            m_snapshotUnitLink = Option.Some(parsed_m_snapshotUnitLink);
        }

        if (m_snapshotControlPlayerId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_snapshotControlPlayerId = Parse_GameSCmdDataTargetUnit_m_snapshotControlPlayerId();
            m_snapshotControlPlayerId = Option.Some(parsed_m_snapshotControlPlayerId);
        }

        if (m_snapshotUpkeepPlayerId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_snapshotUpkeepPlayerId = Parse_GameSCmdDataTargetUnit_m_snapshotUpkeepPlayerId();
            m_snapshotUpkeepPlayerId = Option.Some(parsed_m_snapshotUpkeepPlayerId);
        }

        if (m_snapshotPoint is { HasValue: false })                           
        {
            var parsed_m_snapshotPoint = Parse_GameSCmdDataTargetUnit_m_snapshotPoint();
            m_snapshotPoint = Option.Some(parsed_m_snapshotPoint);
        }

        return new GameSCmdDataTargetUnit
        {   
            m_targetUnitFlags = Option.OkOrReturnMissingFieldErr(m_targetUnitFlags),
            m_timer = Option.OkOrReturnMissingFieldErr(m_timer),
            m_tag = Option.OkOrReturnMissingFieldErr(m_tag),
            m_snapshotUnitLink = Option.OkOrReturnMissingFieldErr(m_snapshotUnitLink),
            m_snapshotControlPlayerId = Option.OkOrReturnMissingFieldErr(m_snapshotControlPlayerId),
            m_snapshotUpkeepPlayerId = Option.OkOrReturnMissingFieldErr(m_snapshotUpkeepPlayerId),
            m_snapshotPoint = Option.OkOrReturnMissingFieldErr(m_snapshotPoint),
        };
    }

    public uint16 Parse_GameSCmdDataTargetUnit_m_targetUnitFlags()
    {                             
        var m_targetUnitFlags = Parse_uint16();
        return m_targetUnitFlags;
    }

    public uint8 Parse_GameSCmdDataTargetUnit_m_timer()
    {                             
        var m_timer = Parse_uint8();
        return m_timer;
    }

    public GameTUnitTag Parse_GameSCmdDataTargetUnit_m_tag()
    {                             
        var m_tag = Parse_GameTUnitTag();
        return m_tag;
    }

    public GameTUnitLink Parse_GameSCmdDataTargetUnit_m_snapshotUnitLink()
    {                             
        var m_snapshotUnitLink = Parse_GameTUnitLink();
        return m_snapshotUnitLink;
    }

    public Option<GameTPlayerId> Parse_GameSCmdDataTargetUnit_m_snapshotControlPlayerId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTPlayerId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameTPlayerId> Parse_GameSCmdDataTargetUnit_m_snapshotUpkeepPlayerId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTPlayerId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSMapCoord3D Parse_GameSCmdDataTargetUnit_m_snapshotPoint()
    {                             
        var m_snapshotPoint = Parse_GameSMapCoord3D();
        return m_snapshotPoint;
    }

    public GameSSetLobbySlotEvent Parse_GameSSetLobbySlotEvent() 
    {
        Option<GameTLobbySlotId> m_slotId = Option.None;
        Option<GameSLobbySlotChange> m_slotChange = Option.None;
        if (m_slotId is { HasValue: false })                           
        {
            var parsed_m_slotId = Parse_GameSSetLobbySlotEvent_m_slotId();
            m_slotId = Option.Some(parsed_m_slotId);
        }

        if (m_slotChange is { HasValue: false })                           
        {
            var parsed_m_slotChange = Parse_GameSSetLobbySlotEvent_m_slotChange();
            m_slotChange = Option.Some(parsed_m_slotChange);
        }

        return new GameSSetLobbySlotEvent
        {   
            m_slotId = Option.OkOrReturnMissingFieldErr(m_slotId),
            m_slotChange = Option.OkOrReturnMissingFieldErr(m_slotChange),
        };
    }

    public GameTLobbySlotId Parse_GameSSetLobbySlotEvent_m_slotId()
    {                             
        var m_slotId = Parse_GameTLobbySlotId();
        return m_slotId;
    }

    public GameSLobbySlotChange Parse_GameSSetLobbySlotEvent_m_slotChange()
    {                             
        var m_slotChange = Parse_GameSLobbySlotChange();
        return m_slotChange;
    }

    public GameSDropUserEvent Parse_GameSDropUserEvent() 
    {
        Option<TUserId> m_dropSessionUserId = Option.None;
        Option<ELeaveReason> m_reason = Option.None;
        if (m_dropSessionUserId is { HasValue: false })                           
        {
            var parsed_m_dropSessionUserId = Parse_GameSDropUserEvent_m_dropSessionUserId();
            m_dropSessionUserId = Option.Some(parsed_m_dropSessionUserId);
        }

        if (m_reason is { HasValue: false })                           
        {
            var parsed_m_reason = Parse_GameSDropUserEvent_m_reason();
            m_reason = Option.Some(parsed_m_reason);
        }

        return new GameSDropUserEvent
        {   
            m_dropSessionUserId = Option.OkOrReturnMissingFieldErr(m_dropSessionUserId),
            m_reason = Option.OkOrReturnMissingFieldErr(m_reason),
        };
    }

    public TUserId Parse_GameSDropUserEvent_m_dropSessionUserId()
    {                             
        var m_dropSessionUserId = Parse_TUserId();
        return m_dropSessionUserId;
    }

    public ELeaveReason Parse_GameSDropUserEvent_m_reason()
    {                             
        var m_reason = Parse_ELeaveReason();
        return m_reason;
    }

    public GameSStartGameEvent Parse_GameSStartGameEvent() 
    {
        return new GameSStartGameEvent
        {   
        };
    }

    public GameSDropOurselvesEvent Parse_GameSDropOurselvesEvent() 
    {
        return new GameSDropOurselvesEvent
        {   
        };
    }

    public GameSBankFileEvent Parse_GameSBankFileEvent() 
    {
        Option<List<u8>> m_name = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankFileEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        return new GameSBankFileEvent
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
        };
    }

    public List<u8> Parse_GameSBankFileEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSBankSectionEvent Parse_GameSBankSectionEvent() 
    {
        Option<List<u8>> m_name = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankSectionEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        return new GameSBankSectionEvent
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
        };
    }

    public List<u8> Parse_GameSBankSectionEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSBankKeyEvent Parse_GameSBankKeyEvent() 
    {
        Option<List<u8>> m_name = Option.None;
        Option<uint32> m_type = Option.None;
        Option<List<u8>> m_data = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankKeyEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_type is { HasValue: false })                           
        {
            var parsed_m_type = Parse_GameSBankKeyEvent_m_type();
            m_type = Option.Some(parsed_m_type);
        }

        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSBankKeyEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSBankKeyEvent
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_type = Option.OkOrReturnMissingFieldErr(m_type),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public List<u8> Parse_GameSBankKeyEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public uint32 Parse_GameSBankKeyEvent_m_type()
    {                             
        var m_type = Parse_uint32();
        return m_type;
    }

    public List<u8> Parse_GameSBankKeyEvent_m_data()
    {                             
        var arrayLength = take_n_bits_into_i64(5);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSBankValueEvent Parse_GameSBankValueEvent() 
    {
        Option<uint32> m_type = Option.None;
        Option<List<u8>> m_name = Option.None;
        Option<List<u8>> m_data = Option.None;
        if (m_type is { HasValue: false })                           
        {
            var parsed_m_type = Parse_GameSBankValueEvent_m_type();
            m_type = Option.Some(parsed_m_type);
        }

        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankValueEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSBankValueEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSBankValueEvent
        {   
            m_type = Option.OkOrReturnMissingFieldErr(m_type),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public uint32 Parse_GameSBankValueEvent_m_type()
    {                             
        var m_type = Parse_uint32();
        return m_type;
    }

    public List<u8> Parse_GameSBankValueEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public List<u8> Parse_GameSBankValueEvent_m_data()
    {                             
        var arrayLength = take_n_bits_into_i64(12);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSBankSignatureEvent Parse_GameSBankSignatureEvent() 
    {
        Option<List<uint8>> m_signature = Option.None;
        Option<CToonHandle> m_toonHandle = Option.None;
        if (m_signature is { HasValue: false })                           
        {
            var parsed_m_signature = Parse_GameSBankSignatureEvent_m_signature();
            m_signature = Option.Some(parsed_m_signature);
        }

        if (m_toonHandle is { HasValue: false })                           
        {
            var parsed_m_toonHandle = Parse_GameSBankSignatureEvent_m_toonHandle();
            m_toonHandle = Option.Some(parsed_m_toonHandle);
        }

        return new GameSBankSignatureEvent
        {   
            m_signature = Option.OkOrReturnMissingFieldErr(m_signature),
            m_toonHandle = Option.OkOrReturnMissingFieldErr(m_toonHandle),
        };
    }

    public List<uint8> Parse_GameSBankSignatureEvent_m_signature()
    {                             
        var arrayLength = take_n_bits_into_i64(5);
        var array = new List<uint8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_uint8();
            array.Add(data);
        }
        return array;
    }

    public CToonHandle Parse_GameSBankSignatureEvent_m_toonHandle()
    {                             
        var m_toonHandle = Parse_CToonHandle();
        return m_toonHandle;
    }

    public GameSUserOptionsEvent Parse_GameSUserOptionsEvent() 
    {
        Option<bool> m_gameFullyDownloaded = Option.None;
        Option<bool> m_developmentCheatsEnabled = Option.None;
        Option<bool> m_testCheatsEnabled = Option.None;
        Option<bool> m_multiplayerCheatsEnabled = Option.None;
        Option<bool> m_syncChecksummingEnabled = Option.None;
        Option<bool> m_isMapToMapTransition = Option.None;
        Option<bool> m_debugPauseEnabled = Option.None;
        Option<bool> m_useGalaxyAsserts = Option.None;
        Option<bool> m_platformMac = Option.None;
        Option<bool> m_cameraFollow = Option.None;
        Option<uint32> m_baseBuildNum = Option.None;
        Option<uint32> m_buildNum = Option.None;
        Option<uint32> m_versionFlags = Option.None;
        Option<List<u8>> m_hotkeyProfile = Option.None;
        if (m_gameFullyDownloaded is { HasValue: false })                           
        {
            var parsed_m_gameFullyDownloaded = Parse_GameSUserOptionsEvent_m_gameFullyDownloaded();
            m_gameFullyDownloaded = Option.Some(parsed_m_gameFullyDownloaded);
        }

        if (m_developmentCheatsEnabled is { HasValue: false })                           
        {
            var parsed_m_developmentCheatsEnabled = Parse_GameSUserOptionsEvent_m_developmentCheatsEnabled();
            m_developmentCheatsEnabled = Option.Some(parsed_m_developmentCheatsEnabled);
        }

        if (m_testCheatsEnabled is { HasValue: false })                           
        {
            var parsed_m_testCheatsEnabled = Parse_GameSUserOptionsEvent_m_testCheatsEnabled();
            m_testCheatsEnabled = Option.Some(parsed_m_testCheatsEnabled);
        }

        if (m_multiplayerCheatsEnabled is { HasValue: false })                           
        {
            var parsed_m_multiplayerCheatsEnabled = Parse_GameSUserOptionsEvent_m_multiplayerCheatsEnabled();
            m_multiplayerCheatsEnabled = Option.Some(parsed_m_multiplayerCheatsEnabled);
        }

        if (m_syncChecksummingEnabled is { HasValue: false })                           
        {
            var parsed_m_syncChecksummingEnabled = Parse_GameSUserOptionsEvent_m_syncChecksummingEnabled();
            m_syncChecksummingEnabled = Option.Some(parsed_m_syncChecksummingEnabled);
        }

        if (m_isMapToMapTransition is { HasValue: false })                           
        {
            var parsed_m_isMapToMapTransition = Parse_GameSUserOptionsEvent_m_isMapToMapTransition();
            m_isMapToMapTransition = Option.Some(parsed_m_isMapToMapTransition);
        }

        if (m_debugPauseEnabled is { HasValue: false })                           
        {
            var parsed_m_debugPauseEnabled = Parse_GameSUserOptionsEvent_m_debugPauseEnabled();
            m_debugPauseEnabled = Option.Some(parsed_m_debugPauseEnabled);
        }

        if (m_useGalaxyAsserts is { HasValue: false })                           
        {
            var parsed_m_useGalaxyAsserts = Parse_GameSUserOptionsEvent_m_useGalaxyAsserts();
            m_useGalaxyAsserts = Option.Some(parsed_m_useGalaxyAsserts);
        }

        if (m_platformMac is { HasValue: false })                           
        {
            var parsed_m_platformMac = Parse_GameSUserOptionsEvent_m_platformMac();
            m_platformMac = Option.Some(parsed_m_platformMac);
        }

        if (m_cameraFollow is { HasValue: false })                           
        {
            var parsed_m_cameraFollow = Parse_GameSUserOptionsEvent_m_cameraFollow();
            m_cameraFollow = Option.Some(parsed_m_cameraFollow);
        }

        if (m_baseBuildNum is { HasValue: false })                           
        {
            var parsed_m_baseBuildNum = Parse_GameSUserOptionsEvent_m_baseBuildNum();
            m_baseBuildNum = Option.Some(parsed_m_baseBuildNum);
        }

        if (m_buildNum is { HasValue: false })                           
        {
            var parsed_m_buildNum = Parse_GameSUserOptionsEvent_m_buildNum();
            m_buildNum = Option.Some(parsed_m_buildNum);
        }

        if (m_versionFlags is { HasValue: false })                           
        {
            var parsed_m_versionFlags = Parse_GameSUserOptionsEvent_m_versionFlags();
            m_versionFlags = Option.Some(parsed_m_versionFlags);
        }

        if (m_hotkeyProfile is { HasValue: false })                           
        {
            var parsed_m_hotkeyProfile = Parse_GameSUserOptionsEvent_m_hotkeyProfile();
            m_hotkeyProfile = Option.Some(parsed_m_hotkeyProfile);
        }

        return new GameSUserOptionsEvent
        {   
            m_gameFullyDownloaded = Option.OkOrReturnMissingFieldErr(m_gameFullyDownloaded),
            m_developmentCheatsEnabled = Option.OkOrReturnMissingFieldErr(m_developmentCheatsEnabled),
            m_testCheatsEnabled = Option.OkOrReturnMissingFieldErr(m_testCheatsEnabled),
            m_multiplayerCheatsEnabled = Option.OkOrReturnMissingFieldErr(m_multiplayerCheatsEnabled),
            m_syncChecksummingEnabled = Option.OkOrReturnMissingFieldErr(m_syncChecksummingEnabled),
            m_isMapToMapTransition = Option.OkOrReturnMissingFieldErr(m_isMapToMapTransition),
            m_debugPauseEnabled = Option.OkOrReturnMissingFieldErr(m_debugPauseEnabled),
            m_useGalaxyAsserts = Option.OkOrReturnMissingFieldErr(m_useGalaxyAsserts),
            m_platformMac = Option.OkOrReturnMissingFieldErr(m_platformMac),
            m_cameraFollow = Option.OkOrReturnMissingFieldErr(m_cameraFollow),
            m_baseBuildNum = Option.OkOrReturnMissingFieldErr(m_baseBuildNum),
            m_buildNum = Option.OkOrReturnMissingFieldErr(m_buildNum),
            m_versionFlags = Option.OkOrReturnMissingFieldErr(m_versionFlags),
            m_hotkeyProfile = Option.OkOrReturnMissingFieldErr(m_hotkeyProfile),
        };
    }

    public bool Parse_GameSUserOptionsEvent_m_gameFullyDownloaded()
    {                             
        var m_gameFullyDownloaded = parse_bool();
        return m_gameFullyDownloaded;
    }

    public bool Parse_GameSUserOptionsEvent_m_developmentCheatsEnabled()
    {                             
        var m_developmentCheatsEnabled = parse_bool();
        return m_developmentCheatsEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_testCheatsEnabled()
    {                             
        var m_testCheatsEnabled = parse_bool();
        return m_testCheatsEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_multiplayerCheatsEnabled()
    {                             
        var m_multiplayerCheatsEnabled = parse_bool();
        return m_multiplayerCheatsEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_syncChecksummingEnabled()
    {                             
        var m_syncChecksummingEnabled = parse_bool();
        return m_syncChecksummingEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_isMapToMapTransition()
    {                             
        var m_isMapToMapTransition = parse_bool();
        return m_isMapToMapTransition;
    }

    public bool Parse_GameSUserOptionsEvent_m_debugPauseEnabled()
    {                             
        var m_debugPauseEnabled = parse_bool();
        return m_debugPauseEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_useGalaxyAsserts()
    {                             
        var m_useGalaxyAsserts = parse_bool();
        return m_useGalaxyAsserts;
    }

    public bool Parse_GameSUserOptionsEvent_m_platformMac()
    {                             
        var m_platformMac = parse_bool();
        return m_platformMac;
    }

    public bool Parse_GameSUserOptionsEvent_m_cameraFollow()
    {                             
        var m_cameraFollow = parse_bool();
        return m_cameraFollow;
    }

    public uint32 Parse_GameSUserOptionsEvent_m_baseBuildNum()
    {                             
        var m_baseBuildNum = Parse_uint32();
        return m_baseBuildNum;
    }

    public uint32 Parse_GameSUserOptionsEvent_m_buildNum()
    {                             
        var m_buildNum = Parse_uint32();
        return m_buildNum;
    }

    public uint32 Parse_GameSUserOptionsEvent_m_versionFlags()
    {                             
        var m_versionFlags = Parse_uint32();
        return m_versionFlags;
    }

    public List<u8> Parse_GameSUserOptionsEvent_m_hotkeyProfile()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSPickMapTagEvent Parse_GameSPickMapTagEvent() 
    {
        Option<uint8> m_pickedMapTag = Option.None;
        if (m_pickedMapTag is { HasValue: false })                           
        {
            var parsed_m_pickedMapTag = Parse_GameSPickMapTagEvent_m_pickedMapTag();
            m_pickedMapTag = Option.Some(parsed_m_pickedMapTag);
        }

        return new GameSPickMapTagEvent
        {   
            m_pickedMapTag = Option.OkOrReturnMissingFieldErr(m_pickedMapTag),
        };
    }

    public uint8 Parse_GameSPickMapTagEvent_m_pickedMapTag()
    {                             
        var m_pickedMapTag = Parse_uint8();
        return m_pickedMapTag;
    }

    public GameSUserFinishedLoadingEvent Parse_GameSUserFinishedLoadingEvent() 
    {
        return new GameSUserFinishedLoadingEvent
        {   
        };
    }

    public GameSUserFinishedLoadingSyncEvent Parse_GameSUserFinishedLoadingSyncEvent() 
    {
        return new GameSUserFinishedLoadingSyncEvent
        {   
        };
    }

    public GameSSetGameDurationEvent Parse_GameSSetGameDurationEvent() 
    {
        Option<uint32> m_gameDuration = Option.None;
        if (m_gameDuration is { HasValue: false })                           
        {
            var parsed_m_gameDuration = Parse_GameSSetGameDurationEvent_m_gameDuration();
            m_gameDuration = Option.Some(parsed_m_gameDuration);
        }

        return new GameSSetGameDurationEvent
        {   
            m_gameDuration = Option.OkOrReturnMissingFieldErr(m_gameDuration),
        };
    }

    public uint32 Parse_GameSSetGameDurationEvent_m_gameDuration()
    {                             
        var m_gameDuration = Parse_uint32();
        return m_gameDuration;
    }

    public GameSTurnEvent Parse_GameSTurnEvent() 
    {
        return new GameSTurnEvent
        {   
        };
    }

    public GameSCameraSaveEvent Parse_GameSCameraSaveEvent() 
    {
        Option<i64> m_which = Option.None;
        Option<GameSPointMini> m_target = Option.None;
        if (m_which is { HasValue: false })                           
        {
            var parsed_m_which = Parse_GameSCameraSaveEvent_m_which();
            m_which = Option.Some(parsed_m_which);
        }

        if (m_target is { HasValue: false })                           
        {
            var parsed_m_target = Parse_GameSCameraSaveEvent_m_target();
            m_target = Option.Some(parsed_m_target);
        }

        return new GameSCameraSaveEvent
        {   
            m_which = Option.OkOrReturnMissingFieldErr(m_which),
            m_target = Option.OkOrReturnMissingFieldErr(m_target),
        };
    }

    public i64 Parse_GameSCameraSaveEvent_m_which()
    {                             
        var m_which = parse_packed_int(0, 3);
        return m_which;
    }

    public GameSPointMini Parse_GameSCameraSaveEvent_m_target()
    {                             
        var m_target = Parse_GameSPointMini();
        return m_target;
    }

    public GameSPauseGameEvent Parse_GameSPauseGameEvent() 
    {
        Option<uint8> m_pauseTypeIndex = Option.None;
        if (m_pauseTypeIndex is { HasValue: false })                           
        {
            var parsed_m_pauseTypeIndex = Parse_GameSPauseGameEvent_m_pauseTypeIndex();
            m_pauseTypeIndex = Option.Some(parsed_m_pauseTypeIndex);
        }

        return new GameSPauseGameEvent
        {   
            m_pauseTypeIndex = Option.OkOrReturnMissingFieldErr(m_pauseTypeIndex),
        };
    }

    public uint8 Parse_GameSPauseGameEvent_m_pauseTypeIndex()
    {                             
        var m_pauseTypeIndex = Parse_uint8();
        return m_pauseTypeIndex;
    }

    public GameSUnpauseGameEvent Parse_GameSUnpauseGameEvent() 
    {
        Option<uint8> m_pauseTypeIndex = Option.None;
        if (m_pauseTypeIndex is { HasValue: false })                           
        {
            var parsed_m_pauseTypeIndex = Parse_GameSUnpauseGameEvent_m_pauseTypeIndex();
            m_pauseTypeIndex = Option.Some(parsed_m_pauseTypeIndex);
        }

        return new GameSUnpauseGameEvent
        {   
            m_pauseTypeIndex = Option.OkOrReturnMissingFieldErr(m_pauseTypeIndex),
        };
    }

    public uint8 Parse_GameSUnpauseGameEvent_m_pauseTypeIndex()
    {                             
        var m_pauseTypeIndex = Parse_uint8();
        return m_pauseTypeIndex;
    }

    public GameSSingleStepGameEvent Parse_GameSSingleStepGameEvent() 
    {
        return new GameSSingleStepGameEvent
        {   
        };
    }

    public GameSSetGameSpeedEvent Parse_GameSSetGameSpeedEvent() 
    {
        Option<GameEGameSpeed> m_speed = Option.None;
        if (m_speed is { HasValue: false })                           
        {
            var parsed_m_speed = Parse_GameSSetGameSpeedEvent_m_speed();
            m_speed = Option.Some(parsed_m_speed);
        }

        return new GameSSetGameSpeedEvent
        {   
            m_speed = Option.OkOrReturnMissingFieldErr(m_speed),
        };
    }

    public GameEGameSpeed Parse_GameSSetGameSpeedEvent_m_speed()
    {                             
        var m_speed = Parse_GameEGameSpeed();
        return m_speed;
    }

    public GameSAddGameSpeedEvent Parse_GameSAddGameSpeedEvent() 
    {
        Option<int8> m_delta = Option.None;
        if (m_delta is { HasValue: false })                           
        {
            var parsed_m_delta = Parse_GameSAddGameSpeedEvent_m_delta();
            m_delta = Option.Some(parsed_m_delta);
        }

        return new GameSAddGameSpeedEvent
        {   
            m_delta = Option.OkOrReturnMissingFieldErr(m_delta),
        };
    }

    public int8 Parse_GameSAddGameSpeedEvent_m_delta()
    {                             
        var m_delta = Parse_int8();
        return m_delta;
    }

    public GameSReplayJumpEvent Parse_GameSReplayJumpEvent() 
    {
        var m_replayJumpGameLoop = Option.Some<Option<uint32>>(Option.None);
        if (m_replayJumpGameLoop is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_replayJumpGameLoop = Parse_GameSReplayJumpEvent_m_replayJumpGameLoop();
            m_replayJumpGameLoop = Option.Some(parsed_m_replayJumpGameLoop);
        }

        return new GameSReplayJumpEvent
        {   
            m_replayJumpGameLoop = Option.OkOrReturnMissingFieldErr(m_replayJumpGameLoop),
        };
    }

    public Option<uint32> Parse_GameSReplayJumpEvent_m_replayJumpGameLoop()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint32();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSSaveGameEvent Parse_GameSSaveGameEvent() 
    {
        Option<CFilePath> m_fileName = Option.None;
        Option<bool> m_automatic = Option.None;
        Option<bool> m_overwrite = Option.None;
        Option<List<u8>> m_name = Option.None;
        Option<List<u8>> m_description = Option.None;
        if (m_fileName is { HasValue: false })                           
        {
            var parsed_m_fileName = Parse_GameSSaveGameEvent_m_fileName();
            m_fileName = Option.Some(parsed_m_fileName);
        }

        if (m_automatic is { HasValue: false })                           
        {
            var parsed_m_automatic = Parse_GameSSaveGameEvent_m_automatic();
            m_automatic = Option.Some(parsed_m_automatic);
        }

        if (m_overwrite is { HasValue: false })                           
        {
            var parsed_m_overwrite = Parse_GameSSaveGameEvent_m_overwrite();
            m_overwrite = Option.Some(parsed_m_overwrite);
        }

        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSSaveGameEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_description is { HasValue: false })                           
        {
            var parsed_m_description = Parse_GameSSaveGameEvent_m_description();
            m_description = Option.Some(parsed_m_description);
        }

        return new GameSSaveGameEvent
        {   
            m_fileName = Option.OkOrReturnMissingFieldErr(m_fileName),
            m_automatic = Option.OkOrReturnMissingFieldErr(m_automatic),
            m_overwrite = Option.OkOrReturnMissingFieldErr(m_overwrite),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_description = Option.OkOrReturnMissingFieldErr(m_description),
        };
    }

    public CFilePath Parse_GameSSaveGameEvent_m_fileName()
    {                             
        var m_fileName = Parse_CFilePath();
        return m_fileName;
    }

    public bool Parse_GameSSaveGameEvent_m_automatic()
    {                             
        var m_automatic = parse_bool();
        return m_automatic;
    }

    public bool Parse_GameSSaveGameEvent_m_overwrite()
    {                             
        var m_overwrite = parse_bool();
        return m_overwrite;
    }

    public List<u8> Parse_GameSSaveGameEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public List<u8> Parse_GameSSaveGameEvent_m_description()
    {                             
        var arrayLength = take_n_bits_into_i64(9);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSSaveGameDoneEvent Parse_GameSSaveGameDoneEvent() 
    {
        return new GameSSaveGameDoneEvent
        {   
        };
    }

    public GameSLoadGameDoneEvent Parse_GameSLoadGameDoneEvent() 
    {
        return new GameSLoadGameDoneEvent
        {   
        };
    }

    public GameSCheatEventData Parse_GameSCheatEventData() 
    {
        Option<GameSPoint> m_point = Option.None;
        Option<int32> m_time = Option.None;
        Option<GameCCheatString> m_verb = Option.None;
        Option<GameCCheatString> m_arguments = Option.None;
        if (m_point is { HasValue: false })                           
        {
            var parsed_m_point = Parse_GameSCheatEventData_m_point();
            m_point = Option.Some(parsed_m_point);
        }

        if (m_time is { HasValue: false })                           
        {
            var parsed_m_time = Parse_GameSCheatEventData_m_time();
            m_time = Option.Some(parsed_m_time);
        }

        if (m_verb is { HasValue: false })                           
        {
            var parsed_m_verb = Parse_GameSCheatEventData_m_verb();
            m_verb = Option.Some(parsed_m_verb);
        }

        if (m_arguments is { HasValue: false })                           
        {
            var parsed_m_arguments = Parse_GameSCheatEventData_m_arguments();
            m_arguments = Option.Some(parsed_m_arguments);
        }

        return new GameSCheatEventData
        {   
            m_point = Option.OkOrReturnMissingFieldErr(m_point),
            m_time = Option.OkOrReturnMissingFieldErr(m_time),
            m_verb = Option.OkOrReturnMissingFieldErr(m_verb),
            m_arguments = Option.OkOrReturnMissingFieldErr(m_arguments),
        };
    }

    public GameSPoint Parse_GameSCheatEventData_m_point()
    {                             
        var m_point = Parse_GameSPoint();
        return m_point;
    }

    public int32 Parse_GameSCheatEventData_m_time()
    {                             
        var m_time = Parse_int32();
        return m_time;
    }

    public GameCCheatString Parse_GameSCheatEventData_m_verb()
    {                             
        var m_verb = Parse_GameCCheatString();
        return m_verb;
    }

    public GameCCheatString Parse_GameSCheatEventData_m_arguments()
    {                             
        var m_arguments = Parse_GameCCheatString();
        return m_arguments;
    }

    public GameSSessionCheatEvent Parse_GameSSessionCheatEvent() 
    {
        Option<GameSCheatEventData> m_data = Option.None;
        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSSessionCheatEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSSessionCheatEvent
        {   
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public GameSCheatEventData Parse_GameSSessionCheatEvent_m_data()
    {                             
        var m_data = Parse_GameSCheatEventData();
        return m_data;
    }

    public GameSCommandManagerResetEvent Parse_GameSCommandManagerResetEvent() 
    {
        Option<uint32> m_sequence = Option.None;
        if (m_sequence is { HasValue: false })                           
        {
            var parsed_m_sequence = Parse_GameSCommandManagerResetEvent_m_sequence();
            m_sequence = Option.Some(parsed_m_sequence);
        }

        return new GameSCommandManagerResetEvent
        {   
            m_sequence = Option.OkOrReturnMissingFieldErr(m_sequence),
        };
    }

    public uint32 Parse_GameSCommandManagerResetEvent_m_sequence()
    {                             
        var m_sequence = Parse_uint32();
        return m_sequence;
    }

    public GameSGameCheatEvent Parse_GameSGameCheatEvent() 
    {
        Option<GameSCheatEventData> m_data = Option.None;
        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSGameCheatEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSGameCheatEvent
        {   
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public GameSCheatEventData Parse_GameSGameCheatEvent_m_data()
    {                             
        var m_data = Parse_GameSCheatEventData();
        return m_data;
    }

    public GameSCmdEvent Parse_GameSCmdEvent() 
    {
        Option<i64> m_cmdFlags = Option.None;
        var m_abil = Option.Some<Option<GameSCmdAbil>>(Option.None);
        Option<GameSCmdData> m_data = Option.None;
        Option<i64> m_sequence = Option.None;
        var m_otherUnit = Option.Some<Option<GameTUnitTag>>(Option.None);
        var m_unitGroup = Option.Some<Option<uint32>>(Option.None);
        if (m_cmdFlags is { HasValue: false })                           
        {
            var parsed_m_cmdFlags = Parse_GameSCmdEvent_m_cmdFlags();
            m_cmdFlags = Option.Some(parsed_m_cmdFlags);
        }

        if (m_abil is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_abil = Parse_GameSCmdEvent_m_abil();
            m_abil = Option.Some(parsed_m_abil);
        }

        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSCmdEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        if (m_sequence is { HasValue: false })                           
        {
            var parsed_m_sequence = Parse_GameSCmdEvent_m_sequence();
            m_sequence = Option.Some(parsed_m_sequence);
        }

        if (m_otherUnit is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_otherUnit = Parse_GameSCmdEvent_m_otherUnit();
            m_otherUnit = Option.Some(parsed_m_otherUnit);
        }

        if (m_unitGroup is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_unitGroup = Parse_GameSCmdEvent_m_unitGroup();
            m_unitGroup = Option.Some(parsed_m_unitGroup);
        }

        return new GameSCmdEvent
        {   
            m_cmdFlags = Option.OkOrReturnMissingFieldErr(m_cmdFlags),
            m_abil = Option.OkOrReturnMissingFieldErr(m_abil),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
            m_sequence = Option.OkOrReturnMissingFieldErr(m_sequence),
            m_otherUnit = Option.OkOrReturnMissingFieldErr(m_otherUnit),
            m_unitGroup = Option.OkOrReturnMissingFieldErr(m_unitGroup),
        };
    }

    public i64 Parse_GameSCmdEvent_m_cmdFlags()
    {                             
        var m_cmdFlags = parse_packed_int(0, 26);
        return m_cmdFlags;
    }

    public Option<GameSCmdAbil> Parse_GameSCmdEvent_m_abil()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameSCmdAbil();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCmdData Parse_GameSCmdEvent_m_data()
    {                             
        var m_data = Parse_GameSCmdData();
        return m_data;
    }

    public i64 Parse_GameSCmdEvent_m_sequence()
    {                             
        var m_sequence = parse_packed_int(1, 32);
        return m_sequence;
    }

    public Option<GameTUnitTag> Parse_GameSCmdEvent_m_otherUnit()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTUnitTag();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<uint32> Parse_GameSCmdEvent_m_unitGroup()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint32();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSSelectionDeltaEvent Parse_GameSSelectionDeltaEvent() 
    {
        Option<GameTControlGroupId> m_controlGroupId = Option.None;
        Option<GameSSelectionDelta> m_delta = Option.None;
        if (m_controlGroupId is { HasValue: false })                           
        {
            var parsed_m_controlGroupId = Parse_GameSSelectionDeltaEvent_m_controlGroupId();
            m_controlGroupId = Option.Some(parsed_m_controlGroupId);
        }

        if (m_delta is { HasValue: false })                           
        {
            var parsed_m_delta = Parse_GameSSelectionDeltaEvent_m_delta();
            m_delta = Option.Some(parsed_m_delta);
        }

        return new GameSSelectionDeltaEvent
        {   
            m_controlGroupId = Option.OkOrReturnMissingFieldErr(m_controlGroupId),
            m_delta = Option.OkOrReturnMissingFieldErr(m_delta),
        };
    }

    public GameTControlGroupId Parse_GameSSelectionDeltaEvent_m_controlGroupId()
    {                             
        var m_controlGroupId = Parse_GameTControlGroupId();
        return m_controlGroupId;
    }

    public GameSSelectionDelta Parse_GameSSelectionDeltaEvent_m_delta()
    {                             
        var m_delta = Parse_GameSSelectionDelta();
        return m_delta;
    }

    public GameSControlGroupUpdateEvent Parse_GameSControlGroupUpdateEvent() 
    {
        Option<GameTControlGroupIndex> m_controlGroupIndex = Option.None;
        Option<GameEControlGroupUpdate> m_controlGroupUpdate = Option.None;
        Option<GameSSelectionMask> m_mask = Option.None;
        if (m_controlGroupIndex is { HasValue: false })                           
        {
            var parsed_m_controlGroupIndex = Parse_GameSControlGroupUpdateEvent_m_controlGroupIndex();
            m_controlGroupIndex = Option.Some(parsed_m_controlGroupIndex);
        }

        if (m_controlGroupUpdate is { HasValue: false })                           
        {
            var parsed_m_controlGroupUpdate = Parse_GameSControlGroupUpdateEvent_m_controlGroupUpdate();
            m_controlGroupUpdate = Option.Some(parsed_m_controlGroupUpdate);
        }

        if (m_mask is { HasValue: false })                           
        {
            var parsed_m_mask = Parse_GameSControlGroupUpdateEvent_m_mask();
            m_mask = Option.Some(parsed_m_mask);
        }

        return new GameSControlGroupUpdateEvent
        {   
            m_controlGroupIndex = Option.OkOrReturnMissingFieldErr(m_controlGroupIndex),
            m_controlGroupUpdate = Option.OkOrReturnMissingFieldErr(m_controlGroupUpdate),
            m_mask = Option.OkOrReturnMissingFieldErr(m_mask),
        };
    }

    public GameTControlGroupIndex Parse_GameSControlGroupUpdateEvent_m_controlGroupIndex()
    {                             
        var m_controlGroupIndex = Parse_GameTControlGroupIndex();
        return m_controlGroupIndex;
    }

    public GameEControlGroupUpdate Parse_GameSControlGroupUpdateEvent_m_controlGroupUpdate()
    {                             
        var m_controlGroupUpdate = Parse_GameEControlGroupUpdate();
        return m_controlGroupUpdate;
    }

    public GameSSelectionMask Parse_GameSControlGroupUpdateEvent_m_mask()
    {                             
        var m_mask = Parse_GameSSelectionMask();
        return m_mask;
    }

    public GameSSelectionSyncCheckEvent Parse_GameSSelectionSyncCheckEvent() 
    {
        Option<GameTControlGroupId> m_controlGroupId = Option.None;
        Option<GameSSelectionSyncData> m_selectionSyncData = Option.None;
        if (m_controlGroupId is { HasValue: false })                           
        {
            var parsed_m_controlGroupId = Parse_GameSSelectionSyncCheckEvent_m_controlGroupId();
            m_controlGroupId = Option.Some(parsed_m_controlGroupId);
        }

        if (m_selectionSyncData is { HasValue: false })                           
        {
            var parsed_m_selectionSyncData = Parse_GameSSelectionSyncCheckEvent_m_selectionSyncData();
            m_selectionSyncData = Option.Some(parsed_m_selectionSyncData);
        }

        return new GameSSelectionSyncCheckEvent
        {   
            m_controlGroupId = Option.OkOrReturnMissingFieldErr(m_controlGroupId),
            m_selectionSyncData = Option.OkOrReturnMissingFieldErr(m_selectionSyncData),
        };
    }

    public GameTControlGroupId Parse_GameSSelectionSyncCheckEvent_m_controlGroupId()
    {                             
        var m_controlGroupId = Parse_GameTControlGroupId();
        return m_controlGroupId;
    }

    public GameSSelectionSyncData Parse_GameSSelectionSyncCheckEvent_m_selectionSyncData()
    {                             
        var m_selectionSyncData = Parse_GameSSelectionSyncData();
        return m_selectionSyncData;
    }

    public GameSResourceTradeEvent Parse_GameSResourceTradeEvent() 
    {
        Option<GameTPlayerId> m_recipientId = Option.None;
        Option<List<int32>> m_resources = Option.None;
        if (m_recipientId is { HasValue: false })                           
        {
            var parsed_m_recipientId = Parse_GameSResourceTradeEvent_m_recipientId();
            m_recipientId = Option.Some(parsed_m_recipientId);
        }

        if (m_resources is { HasValue: false })                           
        {
            var parsed_m_resources = Parse_GameSResourceTradeEvent_m_resources();
            m_resources = Option.Some(parsed_m_resources);
        }

        return new GameSResourceTradeEvent
        {   
            m_recipientId = Option.OkOrReturnMissingFieldErr(m_recipientId),
            m_resources = Option.OkOrReturnMissingFieldErr(m_resources),
        };
    }

    public GameTPlayerId Parse_GameSResourceTradeEvent_m_recipientId()
    {                             
        var m_recipientId = Parse_GameTPlayerId();
        return m_recipientId;
    }

    public List<int32> Parse_GameSResourceTradeEvent_m_resources()
    {                             
        var arrayLength = take_n_bits_into_i64(3);
        var array = new List<int32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_int32();
            array.Add(data);
        }
        return array;
    }

    public GameSTriggerChatMessageEvent Parse_GameSTriggerChatMessageEvent() 
    {
        Option<GameCTriggerChatMessageString> m_chatMessage = Option.None;
        if (m_chatMessage is { HasValue: false })                           
        {
            var parsed_m_chatMessage = Parse_GameSTriggerChatMessageEvent_m_chatMessage();
            m_chatMessage = Option.Some(parsed_m_chatMessage);
        }

        return new GameSTriggerChatMessageEvent
        {   
            m_chatMessage = Option.OkOrReturnMissingFieldErr(m_chatMessage),
        };
    }

    public GameCTriggerChatMessageString Parse_GameSTriggerChatMessageEvent_m_chatMessage()
    {                             
        var m_chatMessage = Parse_GameCTriggerChatMessageString();
        return m_chatMessage;
    }

    public GameSAICommunicateEvent Parse_GameSAICommunicateEvent() 
    {
        Option<int8> m_beacon = Option.None;
        Option<int8> m_ally = Option.None;
        Option<int8> m_flags = Option.None;
        Option<int8> m_build = Option.None;
        Option<GameTUnitTag> m_targetUnitTag = Option.None;
        Option<GameTUnitLink> m_targetUnitSnapshotUnitLink = Option.None;
        Option<int8> m_targetUnitSnapshotUpkeepPlayerId = Option.None;
        Option<int8> m_targetUnitSnapshotControlPlayerId = Option.None;
        Option<GameSPoint3> m_targetPoint = Option.None;
        if (m_beacon is { HasValue: false })                           
        {
            var parsed_m_beacon = Parse_GameSAICommunicateEvent_m_beacon();
            m_beacon = Option.Some(parsed_m_beacon);
        }

        if (m_ally is { HasValue: false })                           
        {
            var parsed_m_ally = Parse_GameSAICommunicateEvent_m_ally();
            m_ally = Option.Some(parsed_m_ally);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSAICommunicateEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        if (m_build is { HasValue: false })                           
        {
            var parsed_m_build = Parse_GameSAICommunicateEvent_m_build();
            m_build = Option.Some(parsed_m_build);
        }

        if (m_targetUnitTag is { HasValue: false })                           
        {
            var parsed_m_targetUnitTag = Parse_GameSAICommunicateEvent_m_targetUnitTag();
            m_targetUnitTag = Option.Some(parsed_m_targetUnitTag);
        }

        if (m_targetUnitSnapshotUnitLink is { HasValue: false })                           
        {
            var parsed_m_targetUnitSnapshotUnitLink = Parse_GameSAICommunicateEvent_m_targetUnitSnapshotUnitLink();
            m_targetUnitSnapshotUnitLink = Option.Some(parsed_m_targetUnitSnapshotUnitLink);
        }

        if (m_targetUnitSnapshotUpkeepPlayerId is { HasValue: false })                           
        {
            var parsed_m_targetUnitSnapshotUpkeepPlayerId = Parse_GameSAICommunicateEvent_m_targetUnitSnapshotUpkeepPlayerId();
            m_targetUnitSnapshotUpkeepPlayerId = Option.Some(parsed_m_targetUnitSnapshotUpkeepPlayerId);
        }

        if (m_targetUnitSnapshotControlPlayerId is { HasValue: false })                           
        {
            var parsed_m_targetUnitSnapshotControlPlayerId = Parse_GameSAICommunicateEvent_m_targetUnitSnapshotControlPlayerId();
            m_targetUnitSnapshotControlPlayerId = Option.Some(parsed_m_targetUnitSnapshotControlPlayerId);
        }

        if (m_targetPoint is { HasValue: false })                           
        {
            var parsed_m_targetPoint = Parse_GameSAICommunicateEvent_m_targetPoint();
            m_targetPoint = Option.Some(parsed_m_targetPoint);
        }

        return new GameSAICommunicateEvent
        {   
            m_beacon = Option.OkOrReturnMissingFieldErr(m_beacon),
            m_ally = Option.OkOrReturnMissingFieldErr(m_ally),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
            m_build = Option.OkOrReturnMissingFieldErr(m_build),
            m_targetUnitTag = Option.OkOrReturnMissingFieldErr(m_targetUnitTag),
            m_targetUnitSnapshotUnitLink = Option.OkOrReturnMissingFieldErr(m_targetUnitSnapshotUnitLink),
            m_targetUnitSnapshotUpkeepPlayerId = Option.OkOrReturnMissingFieldErr(m_targetUnitSnapshotUpkeepPlayerId),
            m_targetUnitSnapshotControlPlayerId = Option.OkOrReturnMissingFieldErr(m_targetUnitSnapshotControlPlayerId),
            m_targetPoint = Option.OkOrReturnMissingFieldErr(m_targetPoint),
        };
    }

    public int8 Parse_GameSAICommunicateEvent_m_beacon()
    {                             
        var m_beacon = Parse_int8();
        return m_beacon;
    }

    public int8 Parse_GameSAICommunicateEvent_m_ally()
    {                             
        var m_ally = Parse_int8();
        return m_ally;
    }

    public int8 Parse_GameSAICommunicateEvent_m_flags()
    {                             
        var m_flags = Parse_int8();
        return m_flags;
    }

    public int8 Parse_GameSAICommunicateEvent_m_build()
    {                             
        var m_build = Parse_int8();
        return m_build;
    }

    public GameTUnitTag Parse_GameSAICommunicateEvent_m_targetUnitTag()
    {                             
        var m_targetUnitTag = Parse_GameTUnitTag();
        return m_targetUnitTag;
    }

    public GameTUnitLink Parse_GameSAICommunicateEvent_m_targetUnitSnapshotUnitLink()
    {                             
        var m_targetUnitSnapshotUnitLink = Parse_GameTUnitLink();
        return m_targetUnitSnapshotUnitLink;
    }

    public int8 Parse_GameSAICommunicateEvent_m_targetUnitSnapshotUpkeepPlayerId()
    {                             
        var m_targetUnitSnapshotUpkeepPlayerId = Parse_int8();
        return m_targetUnitSnapshotUpkeepPlayerId;
    }

    public int8 Parse_GameSAICommunicateEvent_m_targetUnitSnapshotControlPlayerId()
    {                             
        var m_targetUnitSnapshotControlPlayerId = Parse_int8();
        return m_targetUnitSnapshotControlPlayerId;
    }

    public GameSPoint3 Parse_GameSAICommunicateEvent_m_targetPoint()
    {                             
        var m_targetPoint = Parse_GameSPoint3();
        return m_targetPoint;
    }

    public GameSSetAbsoluteGameSpeedEvent Parse_GameSSetAbsoluteGameSpeedEvent() 
    {
        Option<GameEGameSpeed> m_speed = Option.None;
        if (m_speed is { HasValue: false })                           
        {
            var parsed_m_speed = Parse_GameSSetAbsoluteGameSpeedEvent_m_speed();
            m_speed = Option.Some(parsed_m_speed);
        }

        return new GameSSetAbsoluteGameSpeedEvent
        {   
            m_speed = Option.OkOrReturnMissingFieldErr(m_speed),
        };
    }

    public GameEGameSpeed Parse_GameSSetAbsoluteGameSpeedEvent_m_speed()
    {                             
        var m_speed = Parse_GameEGameSpeed();
        return m_speed;
    }

    public GameSAddAbsoluteGameSpeedEvent Parse_GameSAddAbsoluteGameSpeedEvent() 
    {
        Option<int8> m_delta = Option.None;
        if (m_delta is { HasValue: false })                           
        {
            var parsed_m_delta = Parse_GameSAddAbsoluteGameSpeedEvent_m_delta();
            m_delta = Option.Some(parsed_m_delta);
        }

        return new GameSAddAbsoluteGameSpeedEvent
        {   
            m_delta = Option.OkOrReturnMissingFieldErr(m_delta),
        };
    }

    public int8 Parse_GameSAddAbsoluteGameSpeedEvent_m_delta()
    {                             
        var m_delta = Parse_int8();
        return m_delta;
    }

    public GameSTriggerPingEvent Parse_GameSTriggerPingEvent() 
    {
        Option<GameSPoint> m_point = Option.None;
        Option<GameTUnitTag> m_unit = Option.None;
        Option<GameTUnitLink> m_unitLink = Option.None;
        var m_unitControlPlayerId = Option.Some<Option<GameTPlayerId>>(Option.None);
        var m_unitUpkeepPlayerId = Option.Some<Option<GameTPlayerId>>(Option.None);
        Option<GameSMapCoord3D> m_unitPosition = Option.None;
        Option<bool> m_unitIsUnderConstruction = Option.None;
        Option<bool> m_pingedMinimap = Option.None;
        Option<int32> m_option = Option.None;
        if (m_point is { HasValue: false })                           
        {
            var parsed_m_point = Parse_GameSTriggerPingEvent_m_point();
            m_point = Option.Some(parsed_m_point);
        }

        if (m_unit is { HasValue: false })                           
        {
            var parsed_m_unit = Parse_GameSTriggerPingEvent_m_unit();
            m_unit = Option.Some(parsed_m_unit);
        }

        if (m_unitLink is { HasValue: false })                           
        {
            var parsed_m_unitLink = Parse_GameSTriggerPingEvent_m_unitLink();
            m_unitLink = Option.Some(parsed_m_unitLink);
        }

        if (m_unitControlPlayerId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_unitControlPlayerId = Parse_GameSTriggerPingEvent_m_unitControlPlayerId();
            m_unitControlPlayerId = Option.Some(parsed_m_unitControlPlayerId);
        }

        if (m_unitUpkeepPlayerId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_unitUpkeepPlayerId = Parse_GameSTriggerPingEvent_m_unitUpkeepPlayerId();
            m_unitUpkeepPlayerId = Option.Some(parsed_m_unitUpkeepPlayerId);
        }

        if (m_unitPosition is { HasValue: false })                           
        {
            var parsed_m_unitPosition = Parse_GameSTriggerPingEvent_m_unitPosition();
            m_unitPosition = Option.Some(parsed_m_unitPosition);
        }

        if (m_unitIsUnderConstruction is { HasValue: false })                           
        {
            var parsed_m_unitIsUnderConstruction = Parse_GameSTriggerPingEvent_m_unitIsUnderConstruction();
            m_unitIsUnderConstruction = Option.Some(parsed_m_unitIsUnderConstruction);
        }

        if (m_pingedMinimap is { HasValue: false })                           
        {
            var parsed_m_pingedMinimap = Parse_GameSTriggerPingEvent_m_pingedMinimap();
            m_pingedMinimap = Option.Some(parsed_m_pingedMinimap);
        }

        if (m_option is { HasValue: false })                           
        {
            var parsed_m_option = Parse_GameSTriggerPingEvent_m_option();
            m_option = Option.Some(parsed_m_option);
        }

        return new GameSTriggerPingEvent
        {   
            m_point = Option.OkOrReturnMissingFieldErr(m_point),
            m_unit = Option.OkOrReturnMissingFieldErr(m_unit),
            m_unitLink = Option.OkOrReturnMissingFieldErr(m_unitLink),
            m_unitControlPlayerId = Option.OkOrReturnMissingFieldErr(m_unitControlPlayerId),
            m_unitUpkeepPlayerId = Option.OkOrReturnMissingFieldErr(m_unitUpkeepPlayerId),
            m_unitPosition = Option.OkOrReturnMissingFieldErr(m_unitPosition),
            m_unitIsUnderConstruction = Option.OkOrReturnMissingFieldErr(m_unitIsUnderConstruction),
            m_pingedMinimap = Option.OkOrReturnMissingFieldErr(m_pingedMinimap),
            m_option = Option.OkOrReturnMissingFieldErr(m_option),
        };
    }

    public GameSPoint Parse_GameSTriggerPingEvent_m_point()
    {                             
        var m_point = Parse_GameSPoint();
        return m_point;
    }

    public GameTUnitTag Parse_GameSTriggerPingEvent_m_unit()
    {                             
        var m_unit = Parse_GameTUnitTag();
        return m_unit;
    }

    public GameTUnitLink Parse_GameSTriggerPingEvent_m_unitLink()
    {                             
        var m_unitLink = Parse_GameTUnitLink();
        return m_unitLink;
    }

    public Option<GameTPlayerId> Parse_GameSTriggerPingEvent_m_unitControlPlayerId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTPlayerId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameTPlayerId> Parse_GameSTriggerPingEvent_m_unitUpkeepPlayerId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTPlayerId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSMapCoord3D Parse_GameSTriggerPingEvent_m_unitPosition()
    {                             
        var m_unitPosition = Parse_GameSMapCoord3D();
        return m_unitPosition;
    }

    public bool Parse_GameSTriggerPingEvent_m_unitIsUnderConstruction()
    {                             
        var m_unitIsUnderConstruction = parse_bool();
        return m_unitIsUnderConstruction;
    }

    public bool Parse_GameSTriggerPingEvent_m_pingedMinimap()
    {                             
        var m_pingedMinimap = parse_bool();
        return m_pingedMinimap;
    }

    public int32 Parse_GameSTriggerPingEvent_m_option()
    {                             
        var m_option = Parse_int32();
        return m_option;
    }

    public GameSBroadcastCheatEvent Parse_GameSBroadcastCheatEvent() 
    {
        Option<GameCCheatString> m_verb = Option.None;
        Option<GameCCheatString> m_arguments = Option.None;
        if (m_verb is { HasValue: false })                           
        {
            var parsed_m_verb = Parse_GameSBroadcastCheatEvent_m_verb();
            m_verb = Option.Some(parsed_m_verb);
        }

        if (m_arguments is { HasValue: false })                           
        {
            var parsed_m_arguments = Parse_GameSBroadcastCheatEvent_m_arguments();
            m_arguments = Option.Some(parsed_m_arguments);
        }

        return new GameSBroadcastCheatEvent
        {   
            m_verb = Option.OkOrReturnMissingFieldErr(m_verb),
            m_arguments = Option.OkOrReturnMissingFieldErr(m_arguments),
        };
    }

    public GameCCheatString Parse_GameSBroadcastCheatEvent_m_verb()
    {                             
        var m_verb = Parse_GameCCheatString();
        return m_verb;
    }

    public GameCCheatString Parse_GameSBroadcastCheatEvent_m_arguments()
    {                             
        var m_arguments = Parse_GameCCheatString();
        return m_arguments;
    }

    public GameSAllianceEvent Parse_GameSAllianceEvent() 
    {
        Option<uint32> m_alliance = Option.None;
        Option<uint32> m_control = Option.None;
        if (m_alliance is { HasValue: false })                           
        {
            var parsed_m_alliance = Parse_GameSAllianceEvent_m_alliance();
            m_alliance = Option.Some(parsed_m_alliance);
        }

        if (m_control is { HasValue: false })                           
        {
            var parsed_m_control = Parse_GameSAllianceEvent_m_control();
            m_control = Option.Some(parsed_m_control);
        }

        return new GameSAllianceEvent
        {   
            m_alliance = Option.OkOrReturnMissingFieldErr(m_alliance),
            m_control = Option.OkOrReturnMissingFieldErr(m_control),
        };
    }

    public uint32 Parse_GameSAllianceEvent_m_alliance()
    {                             
        var m_alliance = Parse_uint32();
        return m_alliance;
    }

    public uint32 Parse_GameSAllianceEvent_m_control()
    {                             
        var m_control = Parse_uint32();
        return m_control;
    }

    public GameSUnitClickEvent Parse_GameSUnitClickEvent() 
    {
        Option<GameTUnitTag> m_unitTag = Option.None;
        if (m_unitTag is { HasValue: false })                           
        {
            var parsed_m_unitTag = Parse_GameSUnitClickEvent_m_unitTag();
            m_unitTag = Option.Some(parsed_m_unitTag);
        }

        return new GameSUnitClickEvent
        {   
            m_unitTag = Option.OkOrReturnMissingFieldErr(m_unitTag),
        };
    }

    public GameTUnitTag Parse_GameSUnitClickEvent_m_unitTag()
    {                             
        var m_unitTag = Parse_GameTUnitTag();
        return m_unitTag;
    }

    public GameSUnitHighlightEvent Parse_GameSUnitHighlightEvent() 
    {
        Option<GameTUnitTag> m_unitTag = Option.None;
        Option<uint8> m_flags = Option.None;
        if (m_unitTag is { HasValue: false })                           
        {
            var parsed_m_unitTag = Parse_GameSUnitHighlightEvent_m_unitTag();
            m_unitTag = Option.Some(parsed_m_unitTag);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSUnitHighlightEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        return new GameSUnitHighlightEvent
        {   
            m_unitTag = Option.OkOrReturnMissingFieldErr(m_unitTag),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
        };
    }

    public GameTUnitTag Parse_GameSUnitHighlightEvent_m_unitTag()
    {                             
        var m_unitTag = Parse_GameTUnitTag();
        return m_unitTag;
    }

    public uint8 Parse_GameSUnitHighlightEvent_m_flags()
    {                             
        var m_flags = Parse_uint8();
        return m_flags;
    }

    public GameSTriggerReplySelectedEvent Parse_GameSTriggerReplySelectedEvent() 
    {
        Option<int32> m_conversationId = Option.None;
        Option<int32> m_replyId = Option.None;
        if (m_conversationId is { HasValue: false })                           
        {
            var parsed_m_conversationId = Parse_GameSTriggerReplySelectedEvent_m_conversationId();
            m_conversationId = Option.Some(parsed_m_conversationId);
        }

        if (m_replyId is { HasValue: false })                           
        {
            var parsed_m_replyId = Parse_GameSTriggerReplySelectedEvent_m_replyId();
            m_replyId = Option.Some(parsed_m_replyId);
        }

        return new GameSTriggerReplySelectedEvent
        {   
            m_conversationId = Option.OkOrReturnMissingFieldErr(m_conversationId),
            m_replyId = Option.OkOrReturnMissingFieldErr(m_replyId),
        };
    }

    public int32 Parse_GameSTriggerReplySelectedEvent_m_conversationId()
    {                             
        var m_conversationId = Parse_int32();
        return m_conversationId;
    }

    public int32 Parse_GameSTriggerReplySelectedEvent_m_replyId()
    {                             
        var m_replyId = Parse_int32();
        return m_replyId;
    }

    public GameSHijackReplaySessionUserInfo Parse_GameSHijackReplaySessionUserInfo() 
    {
        Option<TUserId> m_sessionUserId = Option.None;
        Option<bool> m_addNewGameUser = Option.None;
        Option<TUserId> m_gameUserId = Option.None;
        if (m_sessionUserId is { HasValue: false })                           
        {
            var parsed_m_sessionUserId = Parse_GameSHijackReplaySessionUserInfo_m_sessionUserId();
            m_sessionUserId = Option.Some(parsed_m_sessionUserId);
        }

        if (m_addNewGameUser is { HasValue: false })                           
        {
            var parsed_m_addNewGameUser = Parse_GameSHijackReplaySessionUserInfo_m_addNewGameUser();
            m_addNewGameUser = Option.Some(parsed_m_addNewGameUser);
        }

        if (m_gameUserId is { HasValue: false })                           
        {
            var parsed_m_gameUserId = Parse_GameSHijackReplaySessionUserInfo_m_gameUserId();
            m_gameUserId = Option.Some(parsed_m_gameUserId);
        }

        return new GameSHijackReplaySessionUserInfo
        {   
            m_sessionUserId = Option.OkOrReturnMissingFieldErr(m_sessionUserId),
            m_addNewGameUser = Option.OkOrReturnMissingFieldErr(m_addNewGameUser),
            m_gameUserId = Option.OkOrReturnMissingFieldErr(m_gameUserId),
        };
    }

    public TUserId Parse_GameSHijackReplaySessionUserInfo_m_sessionUserId()
    {                             
        var m_sessionUserId = Parse_TUserId();
        return m_sessionUserId;
    }

    public bool Parse_GameSHijackReplaySessionUserInfo_m_addNewGameUser()
    {                             
        var m_addNewGameUser = parse_bool();
        return m_addNewGameUser;
    }

    public TUserId Parse_GameSHijackReplaySessionUserInfo_m_gameUserId()
    {                             
        var m_gameUserId = Parse_TUserId();
        return m_gameUserId;
    }

    public GameSHijackReplaySessionEvent Parse_GameSHijackReplaySessionEvent() 
    {
        Option<List<GameSHijackReplaySessionUserInfo>> m_userInfos = Option.None;
        Option<GameEHijackMethod> m_method = Option.None;
        if (m_userInfos is { HasValue: false })                           
        {
            var parsed_m_userInfos = Parse_GameSHijackReplaySessionEvent_m_userInfos();
            m_userInfos = Option.Some(parsed_m_userInfos);
        }

        if (m_method is { HasValue: false })                           
        {
            var parsed_m_method = Parse_GameSHijackReplaySessionEvent_m_method();
            m_method = Option.Some(parsed_m_method);
        }

        return new GameSHijackReplaySessionEvent
        {   
            m_userInfos = Option.OkOrReturnMissingFieldErr(m_userInfos),
            m_method = Option.OkOrReturnMissingFieldErr(m_method),
        };
    }

    public List<GameSHijackReplaySessionUserInfo> Parse_GameSHijackReplaySessionEvent_m_userInfos()
    {                             
        var arrayLength = take_n_bits_into_i64(5);
        var array = new List<GameSHijackReplaySessionUserInfo>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameSHijackReplaySessionUserInfo();
            array.Add(data);
        }
        return array;
    }

    public GameEHijackMethod Parse_GameSHijackReplaySessionEvent_m_method()
    {                             
        var m_method = Parse_GameEHijackMethod();
        return m_method;
    }

    public GameSHijackReplayGameUserInfo Parse_GameSHijackReplayGameUserInfo() 
    {
        Option<TUserId> m_gameUserId = Option.None;
        Option<EObserve> m_observe = Option.None;
        Option<CUserName> m_name = Option.None;
        var m_toonHandle = Option.Some<Option<CToonHandle>>(Option.None);
        var m_clanTag = Option.Some<Option<CClanTag>>(Option.None);
        var m_clanLogo = Option.Some<Option<GameCCacheHandle>>(Option.None);
        if (m_gameUserId is { HasValue: false })                           
        {
            var parsed_m_gameUserId = Parse_GameSHijackReplayGameUserInfo_m_gameUserId();
            m_gameUserId = Option.Some(parsed_m_gameUserId);
        }

        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_GameSHijackReplayGameUserInfo_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSHijackReplayGameUserInfo_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_toonHandle is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_toonHandle = Parse_GameSHijackReplayGameUserInfo_m_toonHandle();
            m_toonHandle = Option.Some(parsed_m_toonHandle);
        }

        if (m_clanTag is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_clanTag = Parse_GameSHijackReplayGameUserInfo_m_clanTag();
            m_clanTag = Option.Some(parsed_m_clanTag);
        }

        if (m_clanLogo is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_clanLogo = Parse_GameSHijackReplayGameUserInfo_m_clanLogo();
            m_clanLogo = Option.Some(parsed_m_clanLogo);
        }

        return new GameSHijackReplayGameUserInfo
        {   
            m_gameUserId = Option.OkOrReturnMissingFieldErr(m_gameUserId),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_toonHandle = Option.OkOrReturnMissingFieldErr(m_toonHandle),
            m_clanTag = Option.OkOrReturnMissingFieldErr(m_clanTag),
            m_clanLogo = Option.OkOrReturnMissingFieldErr(m_clanLogo),
        };
    }

    public TUserId Parse_GameSHijackReplayGameUserInfo_m_gameUserId()
    {                             
        var m_gameUserId = Parse_TUserId();
        return m_gameUserId;
    }

    public EObserve Parse_GameSHijackReplayGameUserInfo_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }

    public CUserName Parse_GameSHijackReplayGameUserInfo_m_name()
    {                             
        var m_name = Parse_CUserName();
        return m_name;
    }

    public Option<CToonHandle> Parse_GameSHijackReplayGameUserInfo_m_toonHandle()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_CToonHandle();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<CClanTag> Parse_GameSHijackReplayGameUserInfo_m_clanTag()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_CClanTag();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameCCacheHandle> Parse_GameSHijackReplayGameUserInfo_m_clanLogo()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameCCacheHandle();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSHijackReplayGameEvent Parse_GameSHijackReplayGameEvent() 
    {
        Option<List<GameSHijackReplayGameUserInfo>> m_userInfos = Option.None;
        Option<GameEHijackMethod> m_method = Option.None;
        if (m_userInfos is { HasValue: false })                           
        {
            var parsed_m_userInfos = Parse_GameSHijackReplayGameEvent_m_userInfos();
            m_userInfos = Option.Some(parsed_m_userInfos);
        }

        if (m_method is { HasValue: false })                           
        {
            var parsed_m_method = Parse_GameSHijackReplayGameEvent_m_method();
            m_method = Option.Some(parsed_m_method);
        }

        return new GameSHijackReplayGameEvent
        {   
            m_userInfos = Option.OkOrReturnMissingFieldErr(m_userInfos),
            m_method = Option.OkOrReturnMissingFieldErr(m_method),
        };
    }

    public List<GameSHijackReplayGameUserInfo> Parse_GameSHijackReplayGameEvent_m_userInfos()
    {                             
        var arrayLength = take_n_bits_into_i64(5);
        var array = new List<GameSHijackReplayGameUserInfo>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameSHijackReplayGameUserInfo();
            array.Add(data);
        }
        return array;
    }

    public GameEHijackMethod Parse_GameSHijackReplayGameEvent_m_method()
    {                             
        var m_method = Parse_GameEHijackMethod();
        return m_method;
    }

    public GameSTriggerAbortMissionEvent Parse_GameSTriggerAbortMissionEvent() 
    {
        return new GameSTriggerAbortMissionEvent
        {   
        };
    }

    public GameSTriggerPurchaseMadeEvent Parse_GameSTriggerPurchaseMadeEvent() 
    {
        Option<int32> m_purchaseItemId = Option.None;
        if (m_purchaseItemId is { HasValue: false })                           
        {
            var parsed_m_purchaseItemId = Parse_GameSTriggerPurchaseMadeEvent_m_purchaseItemId();
            m_purchaseItemId = Option.Some(parsed_m_purchaseItemId);
        }

        return new GameSTriggerPurchaseMadeEvent
        {   
            m_purchaseItemId = Option.OkOrReturnMissingFieldErr(m_purchaseItemId),
        };
    }

    public int32 Parse_GameSTriggerPurchaseMadeEvent_m_purchaseItemId()
    {                             
        var m_purchaseItemId = Parse_int32();
        return m_purchaseItemId;
    }

    public GameSTriggerPurchaseExitEvent Parse_GameSTriggerPurchaseExitEvent() 
    {
        return new GameSTriggerPurchaseExitEvent
        {   
        };
    }

    public GameSTriggerPlanetMissionLaunchedEvent Parse_GameSTriggerPlanetMissionLaunchedEvent() 
    {
        Option<int32> m_difficultyLevel = Option.None;
        if (m_difficultyLevel is { HasValue: false })                           
        {
            var parsed_m_difficultyLevel = Parse_GameSTriggerPlanetMissionLaunchedEvent_m_difficultyLevel();
            m_difficultyLevel = Option.Some(parsed_m_difficultyLevel);
        }

        return new GameSTriggerPlanetMissionLaunchedEvent
        {   
            m_difficultyLevel = Option.OkOrReturnMissingFieldErr(m_difficultyLevel),
        };
    }

    public int32 Parse_GameSTriggerPlanetMissionLaunchedEvent_m_difficultyLevel()
    {                             
        var m_difficultyLevel = Parse_int32();
        return m_difficultyLevel;
    }

    public GameSTriggerPlanetPanelCanceledEvent Parse_GameSTriggerPlanetPanelCanceledEvent() 
    {
        return new GameSTriggerPlanetPanelCanceledEvent
        {   
        };
    }

    public GameSTriggerDialogControlEvent Parse_GameSTriggerDialogControlEvent() 
    {
        Option<int32> m_controlId = Option.None;
        Option<int32> m_eventType = Option.None;
        Option<m_eventData> m_eventData = Option.None;
        if (m_controlId is { HasValue: false })                           
        {
            var parsed_m_controlId = Parse_GameSTriggerDialogControlEvent_m_controlId();
            m_controlId = Option.Some(parsed_m_controlId);
        }

        if (m_eventType is { HasValue: false })                           
        {
            var parsed_m_eventType = Parse_GameSTriggerDialogControlEvent_m_eventType();
            m_eventType = Option.Some(parsed_m_eventType);
        }

        if (m_eventData is { HasValue: false })                           
        {
            var parsed_m_eventData = Parse_GameSTriggerDialogControlEvent_m_eventData();
            m_eventData = Option.Some(parsed_m_eventData);
        }

        return new GameSTriggerDialogControlEvent
        {   
            m_controlId = Option.OkOrReturnMissingFieldErr(m_controlId),
            m_eventType = Option.OkOrReturnMissingFieldErr(m_eventType),
            m_eventData = Option.OkOrReturnMissingFieldErr(m_eventData),
        };
    }

    public int32 Parse_GameSTriggerDialogControlEvent_m_controlId()
    {                             
        var m_controlId = Parse_int32();
        return m_controlId;
    }

    public int32 Parse_GameSTriggerDialogControlEvent_m_eventType()
    {                             
        var m_eventType = Parse_int32();
        return m_eventType;
    }

    public m_eventData Parse_GameSTriggerDialogControlEvent_m_eventData()
    {                             
        var m_eventData = Parse_m_eventData();
        return m_eventData;
    }

    public GameSTriggerSkippedEvent Parse_GameSTriggerSkippedEvent() 
    {
        return new GameSTriggerSkippedEvent
        {   
        };
    }

    public GameSTriggerSoundLengthQueryEvent Parse_GameSTriggerSoundLengthQueryEvent() 
    {
        Option<uint32> m_soundHash = Option.None;
        Option<uint32> m_length = Option.None;
        if (m_soundHash is { HasValue: false })                           
        {
            var parsed_m_soundHash = Parse_GameSTriggerSoundLengthQueryEvent_m_soundHash();
            m_soundHash = Option.Some(parsed_m_soundHash);
        }

        if (m_length is { HasValue: false })                           
        {
            var parsed_m_length = Parse_GameSTriggerSoundLengthQueryEvent_m_length();
            m_length = Option.Some(parsed_m_length);
        }

        return new GameSTriggerSoundLengthQueryEvent
        {   
            m_soundHash = Option.OkOrReturnMissingFieldErr(m_soundHash),
            m_length = Option.OkOrReturnMissingFieldErr(m_length),
        };
    }

    public uint32 Parse_GameSTriggerSoundLengthQueryEvent_m_soundHash()
    {                             
        var m_soundHash = Parse_uint32();
        return m_soundHash;
    }

    public uint32 Parse_GameSTriggerSoundLengthQueryEvent_m_length()
    {                             
        var m_length = Parse_uint32();
        return m_length;
    }

    public GameSTriggerSoundLengthSyncEvent Parse_GameSTriggerSoundLengthSyncEvent() 
    {
        Option<GameSSyncSoundLength> m_syncInfo = Option.None;
        if (m_syncInfo is { HasValue: false })                           
        {
            var parsed_m_syncInfo = Parse_GameSTriggerSoundLengthSyncEvent_m_syncInfo();
            m_syncInfo = Option.Some(parsed_m_syncInfo);
        }

        return new GameSTriggerSoundLengthSyncEvent
        {   
            m_syncInfo = Option.OkOrReturnMissingFieldErr(m_syncInfo),
        };
    }

    public GameSSyncSoundLength Parse_GameSTriggerSoundLengthSyncEvent_m_syncInfo()
    {                             
        var m_syncInfo = Parse_GameSSyncSoundLength();
        return m_syncInfo;
    }

    public GameSTriggerAnimLengthQueryByNameEvent Parse_GameSTriggerAnimLengthQueryByNameEvent() 
    {
        Option<GameTQueryID> m_queryId = Option.None;
        Option<uint32> m_lengthMs = Option.None;
        Option<uint32> m_finishGameLoop = Option.None;
        if (m_queryId is { HasValue: false })                           
        {
            var parsed_m_queryId = Parse_GameSTriggerAnimLengthQueryByNameEvent_m_queryId();
            m_queryId = Option.Some(parsed_m_queryId);
        }

        if (m_lengthMs is { HasValue: false })                           
        {
            var parsed_m_lengthMs = Parse_GameSTriggerAnimLengthQueryByNameEvent_m_lengthMs();
            m_lengthMs = Option.Some(parsed_m_lengthMs);
        }

        if (m_finishGameLoop is { HasValue: false })                           
        {
            var parsed_m_finishGameLoop = Parse_GameSTriggerAnimLengthQueryByNameEvent_m_finishGameLoop();
            m_finishGameLoop = Option.Some(parsed_m_finishGameLoop);
        }

        return new GameSTriggerAnimLengthQueryByNameEvent
        {   
            m_queryId = Option.OkOrReturnMissingFieldErr(m_queryId),
            m_lengthMs = Option.OkOrReturnMissingFieldErr(m_lengthMs),
            m_finishGameLoop = Option.OkOrReturnMissingFieldErr(m_finishGameLoop),
        };
    }

    public GameTQueryID Parse_GameSTriggerAnimLengthQueryByNameEvent_m_queryId()
    {                             
        var m_queryId = Parse_GameTQueryID();
        return m_queryId;
    }

    public uint32 Parse_GameSTriggerAnimLengthQueryByNameEvent_m_lengthMs()
    {                             
        var m_lengthMs = Parse_uint32();
        return m_lengthMs;
    }

    public uint32 Parse_GameSTriggerAnimLengthQueryByNameEvent_m_finishGameLoop()
    {                             
        var m_finishGameLoop = Parse_uint32();
        return m_finishGameLoop;
    }

    public GameSTriggerAnimLengthQueryByPropsEvent Parse_GameSTriggerAnimLengthQueryByPropsEvent() 
    {
        Option<GameTQueryID> m_queryId = Option.None;
        Option<uint32> m_lengthMs = Option.None;
        if (m_queryId is { HasValue: false })                           
        {
            var parsed_m_queryId = Parse_GameSTriggerAnimLengthQueryByPropsEvent_m_queryId();
            m_queryId = Option.Some(parsed_m_queryId);
        }

        if (m_lengthMs is { HasValue: false })                           
        {
            var parsed_m_lengthMs = Parse_GameSTriggerAnimLengthQueryByPropsEvent_m_lengthMs();
            m_lengthMs = Option.Some(parsed_m_lengthMs);
        }

        return new GameSTriggerAnimLengthQueryByPropsEvent
        {   
            m_queryId = Option.OkOrReturnMissingFieldErr(m_queryId),
            m_lengthMs = Option.OkOrReturnMissingFieldErr(m_lengthMs),
        };
    }

    public GameTQueryID Parse_GameSTriggerAnimLengthQueryByPropsEvent_m_queryId()
    {                             
        var m_queryId = Parse_GameTQueryID();
        return m_queryId;
    }

    public uint32 Parse_GameSTriggerAnimLengthQueryByPropsEvent_m_lengthMs()
    {                             
        var m_lengthMs = Parse_uint32();
        return m_lengthMs;
    }

    public GameSTriggerAnimOffsetEvent Parse_GameSTriggerAnimOffsetEvent() 
    {
        Option<GameTQueryID> m_animWaitQueryId = Option.None;
        if (m_animWaitQueryId is { HasValue: false })                           
        {
            var parsed_m_animWaitQueryId = Parse_GameSTriggerAnimOffsetEvent_m_animWaitQueryId();
            m_animWaitQueryId = Option.Some(parsed_m_animWaitQueryId);
        }

        return new GameSTriggerAnimOffsetEvent
        {   
            m_animWaitQueryId = Option.OkOrReturnMissingFieldErr(m_animWaitQueryId),
        };
    }

    public GameTQueryID Parse_GameSTriggerAnimOffsetEvent_m_animWaitQueryId()
    {                             
        var m_animWaitQueryId = Parse_GameTQueryID();
        return m_animWaitQueryId;
    }

    public GameSTriggerSoundOffsetEvent Parse_GameSTriggerSoundOffsetEvent() 
    {
        Option<GameTTriggerSoundTag> m_sound = Option.None;
        if (m_sound is { HasValue: false })                           
        {
            var parsed_m_sound = Parse_GameSTriggerSoundOffsetEvent_m_sound();
            m_sound = Option.Some(parsed_m_sound);
        }

        return new GameSTriggerSoundOffsetEvent
        {   
            m_sound = Option.OkOrReturnMissingFieldErr(m_sound),
        };
    }

    public GameTTriggerSoundTag Parse_GameSTriggerSoundOffsetEvent_m_sound()
    {                             
        var m_sound = Parse_GameTTriggerSoundTag();
        return m_sound;
    }

    public GameSTriggerTransmissionOffsetEvent Parse_GameSTriggerTransmissionOffsetEvent() 
    {
        Option<int32> m_transmissionId = Option.None;
        Option<GameTTriggerThreadTag> m_thread = Option.None;
        if (m_transmissionId is { HasValue: false })                           
        {
            var parsed_m_transmissionId = Parse_GameSTriggerTransmissionOffsetEvent_m_transmissionId();
            m_transmissionId = Option.Some(parsed_m_transmissionId);
        }

        if (m_thread is { HasValue: false })                           
        {
            var parsed_m_thread = Parse_GameSTriggerTransmissionOffsetEvent_m_thread();
            m_thread = Option.Some(parsed_m_thread);
        }

        return new GameSTriggerTransmissionOffsetEvent
        {   
            m_transmissionId = Option.OkOrReturnMissingFieldErr(m_transmissionId),
            m_thread = Option.OkOrReturnMissingFieldErr(m_thread),
        };
    }

    public int32 Parse_GameSTriggerTransmissionOffsetEvent_m_transmissionId()
    {                             
        var m_transmissionId = Parse_int32();
        return m_transmissionId;
    }

    public GameTTriggerThreadTag Parse_GameSTriggerTransmissionOffsetEvent_m_thread()
    {                             
        var m_thread = Parse_GameTTriggerThreadTag();
        return m_thread;
    }

    public GameSTriggerTransmissionCompleteEvent Parse_GameSTriggerTransmissionCompleteEvent() 
    {
        Option<int32> m_transmissionId = Option.None;
        if (m_transmissionId is { HasValue: false })                           
        {
            var parsed_m_transmissionId = Parse_GameSTriggerTransmissionCompleteEvent_m_transmissionId();
            m_transmissionId = Option.Some(parsed_m_transmissionId);
        }

        return new GameSTriggerTransmissionCompleteEvent
        {   
            m_transmissionId = Option.OkOrReturnMissingFieldErr(m_transmissionId),
        };
    }

    public int32 Parse_GameSTriggerTransmissionCompleteEvent_m_transmissionId()
    {                             
        var m_transmissionId = Parse_int32();
        return m_transmissionId;
    }

    public GameSCameraUpdateEvent Parse_GameSCameraUpdateEvent() 
    {
        var m_target = Option.Some<Option<GameSPointMini>>(Option.None);
        var m_distance = Option.Some<Option<GameTFixedMiniBitsUnsigned>>(Option.None);
        var m_pitch = Option.Some<Option<GameTFixedMiniBitsUnsigned>>(Option.None);
        var m_yaw = Option.Some<Option<GameTFixedMiniBitsUnsigned>>(Option.None);
        var m_reason = Option.Some<Option<int8>>(Option.None);
        Option<bool> m_follow = Option.None;
        if (m_target is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_target = Parse_GameSCameraUpdateEvent_m_target();
            m_target = Option.Some(parsed_m_target);
        }

        if (m_distance is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_distance = Parse_GameSCameraUpdateEvent_m_distance();
            m_distance = Option.Some(parsed_m_distance);
        }

        if (m_pitch is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_pitch = Parse_GameSCameraUpdateEvent_m_pitch();
            m_pitch = Option.Some(parsed_m_pitch);
        }

        if (m_yaw is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_yaw = Parse_GameSCameraUpdateEvent_m_yaw();
            m_yaw = Option.Some(parsed_m_yaw);
        }

        if (m_reason is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_reason = Parse_GameSCameraUpdateEvent_m_reason();
            m_reason = Option.Some(parsed_m_reason);
        }

        if (m_follow is { HasValue: false })                           
        {
            var parsed_m_follow = Parse_GameSCameraUpdateEvent_m_follow();
            m_follow = Option.Some(parsed_m_follow);
        }

        return new GameSCameraUpdateEvent
        {   
            m_target = Option.OkOrReturnMissingFieldErr(m_target),
            m_distance = Option.OkOrReturnMissingFieldErr(m_distance),
            m_pitch = Option.OkOrReturnMissingFieldErr(m_pitch),
            m_yaw = Option.OkOrReturnMissingFieldErr(m_yaw),
            m_reason = Option.OkOrReturnMissingFieldErr(m_reason),
            m_follow = Option.OkOrReturnMissingFieldErr(m_follow),
        };
    }

    public Option<GameSPointMini> Parse_GameSCameraUpdateEvent_m_target()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameSPointMini();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameTFixedMiniBitsUnsigned> Parse_GameSCameraUpdateEvent_m_distance()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTFixedMiniBitsUnsigned();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameTFixedMiniBitsUnsigned> Parse_GameSCameraUpdateEvent_m_pitch()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTFixedMiniBitsUnsigned();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameTFixedMiniBitsUnsigned> Parse_GameSCameraUpdateEvent_m_yaw()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTFixedMiniBitsUnsigned();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<int8> Parse_GameSCameraUpdateEvent_m_reason()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_int8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public bool Parse_GameSCameraUpdateEvent_m_follow()
    {                             
        var m_follow = parse_bool();
        return m_follow;
    }

    public GameSTriggerConversationSkippedEvent Parse_GameSTriggerConversationSkippedEvent() 
    {
        Option<GameEConversationSkip> m_skipType = Option.None;
        if (m_skipType is { HasValue: false })                           
        {
            var parsed_m_skipType = Parse_GameSTriggerConversationSkippedEvent_m_skipType();
            m_skipType = Option.Some(parsed_m_skipType);
        }

        return new GameSTriggerConversationSkippedEvent
        {   
            m_skipType = Option.OkOrReturnMissingFieldErr(m_skipType),
        };
    }

    public GameEConversationSkip Parse_GameSTriggerConversationSkippedEvent_m_skipType()
    {                             
        var m_skipType = Parse_GameEConversationSkip();
        return m_skipType;
    }

    public GameSTriggerMouseClickedEvent Parse_GameSTriggerMouseClickedEvent() 
    {
        Option<uint32> m_button = Option.None;
        Option<bool> m_down = Option.None;
        Option<GameSUICoord> m_posUI = Option.None;
        Option<GameSMapCoord3D> m_posWorld = Option.None;
        Option<int8> m_flags = Option.None;
        if (m_button is { HasValue: false })                           
        {
            var parsed_m_button = Parse_GameSTriggerMouseClickedEvent_m_button();
            m_button = Option.Some(parsed_m_button);
        }

        if (m_down is { HasValue: false })                           
        {
            var parsed_m_down = Parse_GameSTriggerMouseClickedEvent_m_down();
            m_down = Option.Some(parsed_m_down);
        }

        if (m_posUI is { HasValue: false })                           
        {
            var parsed_m_posUI = Parse_GameSTriggerMouseClickedEvent_m_posUI();
            m_posUI = Option.Some(parsed_m_posUI);
        }

        if (m_posWorld is { HasValue: false })                           
        {
            var parsed_m_posWorld = Parse_GameSTriggerMouseClickedEvent_m_posWorld();
            m_posWorld = Option.Some(parsed_m_posWorld);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSTriggerMouseClickedEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        return new GameSTriggerMouseClickedEvent
        {   
            m_button = Option.OkOrReturnMissingFieldErr(m_button),
            m_down = Option.OkOrReturnMissingFieldErr(m_down),
            m_posUI = Option.OkOrReturnMissingFieldErr(m_posUI),
            m_posWorld = Option.OkOrReturnMissingFieldErr(m_posWorld),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
        };
    }

    public uint32 Parse_GameSTriggerMouseClickedEvent_m_button()
    {                             
        var m_button = Parse_uint32();
        return m_button;
    }

    public bool Parse_GameSTriggerMouseClickedEvent_m_down()
    {                             
        var m_down = parse_bool();
        return m_down;
    }

    public GameSUICoord Parse_GameSTriggerMouseClickedEvent_m_posUI()
    {                             
        var m_posUI = Parse_GameSUICoord();
        return m_posUI;
    }

    public GameSMapCoord3D Parse_GameSTriggerMouseClickedEvent_m_posWorld()
    {                             
        var m_posWorld = Parse_GameSMapCoord3D();
        return m_posWorld;
    }

    public int8 Parse_GameSTriggerMouseClickedEvent_m_flags()
    {                             
        var m_flags = Parse_int8();
        return m_flags;
    }

    public GameSTriggerMouseMovedEvent Parse_GameSTriggerMouseMovedEvent() 
    {
        Option<GameSUICoord> m_posUI = Option.None;
        Option<GameSMapCoord3D> m_posWorld = Option.None;
        Option<int8> m_flags = Option.None;
        if (m_posUI is { HasValue: false })                           
        {
            var parsed_m_posUI = Parse_GameSTriggerMouseMovedEvent_m_posUI();
            m_posUI = Option.Some(parsed_m_posUI);
        }

        if (m_posWorld is { HasValue: false })                           
        {
            var parsed_m_posWorld = Parse_GameSTriggerMouseMovedEvent_m_posWorld();
            m_posWorld = Option.Some(parsed_m_posWorld);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSTriggerMouseMovedEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        return new GameSTriggerMouseMovedEvent
        {   
            m_posUI = Option.OkOrReturnMissingFieldErr(m_posUI),
            m_posWorld = Option.OkOrReturnMissingFieldErr(m_posWorld),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
        };
    }

    public GameSUICoord Parse_GameSTriggerMouseMovedEvent_m_posUI()
    {                             
        var m_posUI = Parse_GameSUICoord();
        return m_posUI;
    }

    public GameSMapCoord3D Parse_GameSTriggerMouseMovedEvent_m_posWorld()
    {                             
        var m_posWorld = Parse_GameSMapCoord3D();
        return m_posWorld;
    }

    public int8 Parse_GameSTriggerMouseMovedEvent_m_flags()
    {                             
        var m_flags = Parse_int8();
        return m_flags;
    }

    public GameSAchievementAwardedEvent Parse_GameSAchievementAwardedEvent() 
    {
        Option<GameTAchievementLink> m_achievementLink = Option.None;
        if (m_achievementLink is { HasValue: false })                           
        {
            var parsed_m_achievementLink = Parse_GameSAchievementAwardedEvent_m_achievementLink();
            m_achievementLink = Option.Some(parsed_m_achievementLink);
        }

        return new GameSAchievementAwardedEvent
        {   
            m_achievementLink = Option.OkOrReturnMissingFieldErr(m_achievementLink),
        };
    }

    public GameTAchievementLink Parse_GameSAchievementAwardedEvent_m_achievementLink()
    {                             
        var m_achievementLink = Parse_GameTAchievementLink();
        return m_achievementLink;
    }

    public GameSTriggerHotkeyPressedEvent Parse_GameSTriggerHotkeyPressedEvent() 
    {
        Option<uint32> m_hotkey = Option.None;
        Option<bool> m_down = Option.None;
        if (m_hotkey is { HasValue: false })                           
        {
            var parsed_m_hotkey = Parse_GameSTriggerHotkeyPressedEvent_m_hotkey();
            m_hotkey = Option.Some(parsed_m_hotkey);
        }

        if (m_down is { HasValue: false })                           
        {
            var parsed_m_down = Parse_GameSTriggerHotkeyPressedEvent_m_down();
            m_down = Option.Some(parsed_m_down);
        }

        return new GameSTriggerHotkeyPressedEvent
        {   
            m_hotkey = Option.OkOrReturnMissingFieldErr(m_hotkey),
            m_down = Option.OkOrReturnMissingFieldErr(m_down),
        };
    }

    public uint32 Parse_GameSTriggerHotkeyPressedEvent_m_hotkey()
    {                             
        var m_hotkey = Parse_uint32();
        return m_hotkey;
    }

    public bool Parse_GameSTriggerHotkeyPressedEvent_m_down()
    {                             
        var m_down = parse_bool();
        return m_down;
    }

    public GameSTriggerTargetModeUpdateEvent Parse_GameSTriggerTargetModeUpdateEvent() 
    {
        Option<GameTAbilLink> m_abilLink = Option.None;
        Option<i64> m_abilCmdIndex = Option.None;
        Option<int8> m_state = Option.None;
        if (m_abilLink is { HasValue: false })                           
        {
            var parsed_m_abilLink = Parse_GameSTriggerTargetModeUpdateEvent_m_abilLink();
            m_abilLink = Option.Some(parsed_m_abilLink);
        }

        if (m_abilCmdIndex is { HasValue: false })                           
        {
            var parsed_m_abilCmdIndex = Parse_GameSTriggerTargetModeUpdateEvent_m_abilCmdIndex();
            m_abilCmdIndex = Option.Some(parsed_m_abilCmdIndex);
        }

        if (m_state is { HasValue: false })                           
        {
            var parsed_m_state = Parse_GameSTriggerTargetModeUpdateEvent_m_state();
            m_state = Option.Some(parsed_m_state);
        }

        return new GameSTriggerTargetModeUpdateEvent
        {   
            m_abilLink = Option.OkOrReturnMissingFieldErr(m_abilLink),
            m_abilCmdIndex = Option.OkOrReturnMissingFieldErr(m_abilCmdIndex),
            m_state = Option.OkOrReturnMissingFieldErr(m_state),
        };
    }

    public GameTAbilLink Parse_GameSTriggerTargetModeUpdateEvent_m_abilLink()
    {                             
        var m_abilLink = Parse_GameTAbilLink();
        return m_abilLink;
    }

    public i64 Parse_GameSTriggerTargetModeUpdateEvent_m_abilCmdIndex()
    {                             
        var m_abilCmdIndex = parse_packed_int(0, 5);
        return m_abilCmdIndex;
    }

    public int8 Parse_GameSTriggerTargetModeUpdateEvent_m_state()
    {                             
        var m_state = Parse_int8();
        return m_state;
    }

    public GameSTriggerPlanetPanelReplayEvent Parse_GameSTriggerPlanetPanelReplayEvent() 
    {
        return new GameSTriggerPlanetPanelReplayEvent
        {   
        };
    }

    public GameSTriggerSoundtrackDoneEvent Parse_GameSTriggerSoundtrackDoneEvent() 
    {
        Option<uint32> m_soundtrack = Option.None;
        if (m_soundtrack is { HasValue: false })                           
        {
            var parsed_m_soundtrack = Parse_GameSTriggerSoundtrackDoneEvent_m_soundtrack();
            m_soundtrack = Option.Some(parsed_m_soundtrack);
        }

        return new GameSTriggerSoundtrackDoneEvent
        {   
            m_soundtrack = Option.OkOrReturnMissingFieldErr(m_soundtrack),
        };
    }

    public uint32 Parse_GameSTriggerSoundtrackDoneEvent_m_soundtrack()
    {                             
        var m_soundtrack = Parse_uint32();
        return m_soundtrack;
    }

    public GameSTriggerPlanetMissionSelectedEvent Parse_GameSTriggerPlanetMissionSelectedEvent() 
    {
        Option<int32> m_planetId = Option.None;
        if (m_planetId is { HasValue: false })                           
        {
            var parsed_m_planetId = Parse_GameSTriggerPlanetMissionSelectedEvent_m_planetId();
            m_planetId = Option.Some(parsed_m_planetId);
        }

        return new GameSTriggerPlanetMissionSelectedEvent
        {   
            m_planetId = Option.OkOrReturnMissingFieldErr(m_planetId),
        };
    }

    public int32 Parse_GameSTriggerPlanetMissionSelectedEvent_m_planetId()
    {                             
        var m_planetId = Parse_int32();
        return m_planetId;
    }

    public GameSTriggerKeyPressedEvent Parse_GameSTriggerKeyPressedEvent() 
    {
        Option<int8> m_key = Option.None;
        Option<int8> m_flags = Option.None;
        if (m_key is { HasValue: false })                           
        {
            var parsed_m_key = Parse_GameSTriggerKeyPressedEvent_m_key();
            m_key = Option.Some(parsed_m_key);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSTriggerKeyPressedEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        return new GameSTriggerKeyPressedEvent
        {   
            m_key = Option.OkOrReturnMissingFieldErr(m_key),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
        };
    }

    public int8 Parse_GameSTriggerKeyPressedEvent_m_key()
    {                             
        var m_key = Parse_int8();
        return m_key;
    }

    public int8 Parse_GameSTriggerKeyPressedEvent_m_flags()
    {                             
        var m_flags = Parse_int8();
        return m_flags;
    }

    public GameSTriggerPlanetPanelBirthCompleteEvent Parse_GameSTriggerPlanetPanelBirthCompleteEvent() 
    {
        return new GameSTriggerPlanetPanelBirthCompleteEvent
        {   
        };
    }

    public GameSTriggerPlanetPanelDeathCompleteEvent Parse_GameSTriggerPlanetPanelDeathCompleteEvent() 
    {
        return new GameSTriggerPlanetPanelDeathCompleteEvent
        {   
        };
    }

    public GameSResourceRequestEvent Parse_GameSResourceRequestEvent() 
    {
        Option<List<int32>> m_resources = Option.None;
        if (m_resources is { HasValue: false })                           
        {
            var parsed_m_resources = Parse_GameSResourceRequestEvent_m_resources();
            m_resources = Option.Some(parsed_m_resources);
        }

        return new GameSResourceRequestEvent
        {   
            m_resources = Option.OkOrReturnMissingFieldErr(m_resources),
        };
    }

    public List<int32> Parse_GameSResourceRequestEvent_m_resources()
    {                             
        var arrayLength = take_n_bits_into_i64(3);
        var array = new List<int32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_int32();
            array.Add(data);
        }
        return array;
    }

    public GameSResourceRequestFulfillEvent Parse_GameSResourceRequestFulfillEvent() 
    {
        Option<int32> m_fulfillRequestId = Option.None;
        if (m_fulfillRequestId is { HasValue: false })                           
        {
            var parsed_m_fulfillRequestId = Parse_GameSResourceRequestFulfillEvent_m_fulfillRequestId();
            m_fulfillRequestId = Option.Some(parsed_m_fulfillRequestId);
        }

        return new GameSResourceRequestFulfillEvent
        {   
            m_fulfillRequestId = Option.OkOrReturnMissingFieldErr(m_fulfillRequestId),
        };
    }

    public int32 Parse_GameSResourceRequestFulfillEvent_m_fulfillRequestId()
    {                             
        var m_fulfillRequestId = Parse_int32();
        return m_fulfillRequestId;
    }

    public GameSResourceRequestCancelEvent Parse_GameSResourceRequestCancelEvent() 
    {
        Option<int32> m_cancelRequestId = Option.None;
        if (m_cancelRequestId is { HasValue: false })                           
        {
            var parsed_m_cancelRequestId = Parse_GameSResourceRequestCancelEvent_m_cancelRequestId();
            m_cancelRequestId = Option.Some(parsed_m_cancelRequestId);
        }

        return new GameSResourceRequestCancelEvent
        {   
            m_cancelRequestId = Option.OkOrReturnMissingFieldErr(m_cancelRequestId),
        };
    }

    public int32 Parse_GameSResourceRequestCancelEvent_m_cancelRequestId()
    {                             
        var m_cancelRequestId = Parse_int32();
        return m_cancelRequestId;
    }

    public GameSTriggerResearchPanelExitEvent Parse_GameSTriggerResearchPanelExitEvent() 
    {
        return new GameSTriggerResearchPanelExitEvent
        {   
        };
    }

    public GameSTriggerResearchPanelPurchaseEvent Parse_GameSTriggerResearchPanelPurchaseEvent() 
    {
        return new GameSTriggerResearchPanelPurchaseEvent
        {   
        };
    }

    public GameSTriggerCommandErrorEvent Parse_GameSTriggerCommandErrorEvent() 
    {
        Option<int32> m_error = Option.None;
        var m_abil = Option.Some<Option<GameSCmdAbil>>(Option.None);
        if (m_error is { HasValue: false })                           
        {
            var parsed_m_error = Parse_GameSTriggerCommandErrorEvent_m_error();
            m_error = Option.Some(parsed_m_error);
        }

        if (m_abil is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_abil = Parse_GameSTriggerCommandErrorEvent_m_abil();
            m_abil = Option.Some(parsed_m_abil);
        }

        return new GameSTriggerCommandErrorEvent
        {   
            m_error = Option.OkOrReturnMissingFieldErr(m_error),
            m_abil = Option.OkOrReturnMissingFieldErr(m_abil),
        };
    }

    public int32 Parse_GameSTriggerCommandErrorEvent_m_error()
    {                             
        var m_error = Parse_int32();
        return m_error;
    }

    public Option<GameSCmdAbil> Parse_GameSTriggerCommandErrorEvent_m_abil()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameSCmdAbil();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSTriggerResearchPanelSelectionChangedEvent Parse_GameSTriggerResearchPanelSelectionChangedEvent() 
    {
        Option<int32> m_researchItemId = Option.None;
        if (m_researchItemId is { HasValue: false })                           
        {
            var parsed_m_researchItemId = Parse_GameSTriggerResearchPanelSelectionChangedEvent_m_researchItemId();
            m_researchItemId = Option.Some(parsed_m_researchItemId);
        }

        return new GameSTriggerResearchPanelSelectionChangedEvent
        {   
            m_researchItemId = Option.OkOrReturnMissingFieldErr(m_researchItemId),
        };
    }

    public int32 Parse_GameSTriggerResearchPanelSelectionChangedEvent_m_researchItemId()
    {                             
        var m_researchItemId = Parse_int32();
        return m_researchItemId;
    }

    public GameSTriggerMercenaryPanelExitEvent Parse_GameSTriggerMercenaryPanelExitEvent() 
    {
        return new GameSTriggerMercenaryPanelExitEvent
        {   
        };
    }

    public GameSTriggerMercenaryPanelPurchaseEvent Parse_GameSTriggerMercenaryPanelPurchaseEvent() 
    {
        return new GameSTriggerMercenaryPanelPurchaseEvent
        {   
        };
    }

    public GameSTriggerMercenaryPanelSelectionChangedEvent Parse_GameSTriggerMercenaryPanelSelectionChangedEvent() 
    {
        Option<int32> m_mercenaryId = Option.None;
        if (m_mercenaryId is { HasValue: false })                           
        {
            var parsed_m_mercenaryId = Parse_GameSTriggerMercenaryPanelSelectionChangedEvent_m_mercenaryId();
            m_mercenaryId = Option.Some(parsed_m_mercenaryId);
        }

        return new GameSTriggerMercenaryPanelSelectionChangedEvent
        {   
            m_mercenaryId = Option.OkOrReturnMissingFieldErr(m_mercenaryId),
        };
    }

    public int32 Parse_GameSTriggerMercenaryPanelSelectionChangedEvent_m_mercenaryId()
    {                             
        var m_mercenaryId = Parse_int32();
        return m_mercenaryId;
    }

    public GameSTriggerVictoryPanelExitEvent Parse_GameSTriggerVictoryPanelExitEvent() 
    {
        return new GameSTriggerVictoryPanelExitEvent
        {   
        };
    }

    public GameSTriggerBattleReportPanelExitEvent Parse_GameSTriggerBattleReportPanelExitEvent() 
    {
        return new GameSTriggerBattleReportPanelExitEvent
        {   
        };
    }

    public GameSTriggerBattleReportPanelPlayMissionEvent Parse_GameSTriggerBattleReportPanelPlayMissionEvent() 
    {
        Option<int32> m_battleReportId = Option.None;
        Option<int32> m_difficultyLevel = Option.None;
        if (m_battleReportId is { HasValue: false })                           
        {
            var parsed_m_battleReportId = Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_battleReportId();
            m_battleReportId = Option.Some(parsed_m_battleReportId);
        }

        if (m_difficultyLevel is { HasValue: false })                           
        {
            var parsed_m_difficultyLevel = Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_difficultyLevel();
            m_difficultyLevel = Option.Some(parsed_m_difficultyLevel);
        }

        return new GameSTriggerBattleReportPanelPlayMissionEvent
        {   
            m_battleReportId = Option.OkOrReturnMissingFieldErr(m_battleReportId),
            m_difficultyLevel = Option.OkOrReturnMissingFieldErr(m_difficultyLevel),
        };
    }

    public int32 Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_battleReportId()
    {                             
        var m_battleReportId = Parse_int32();
        return m_battleReportId;
    }

    public int32 Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_difficultyLevel()
    {                             
        var m_difficultyLevel = Parse_int32();
        return m_difficultyLevel;
    }

    public GameSTriggerBattleReportPanelPlaySceneEvent Parse_GameSTriggerBattleReportPanelPlaySceneEvent() 
    {
        Option<int32> m_battleReportId = Option.None;
        if (m_battleReportId is { HasValue: false })                           
        {
            var parsed_m_battleReportId = Parse_GameSTriggerBattleReportPanelPlaySceneEvent_m_battleReportId();
            m_battleReportId = Option.Some(parsed_m_battleReportId);
        }

        return new GameSTriggerBattleReportPanelPlaySceneEvent
        {   
            m_battleReportId = Option.OkOrReturnMissingFieldErr(m_battleReportId),
        };
    }

    public int32 Parse_GameSTriggerBattleReportPanelPlaySceneEvent_m_battleReportId()
    {                             
        var m_battleReportId = Parse_int32();
        return m_battleReportId;
    }

    public GameSTriggerBattleReportPanelSelectionChangedEvent Parse_GameSTriggerBattleReportPanelSelectionChangedEvent() 
    {
        Option<int32> m_battleReportId = Option.None;
        if (m_battleReportId is { HasValue: false })                           
        {
            var parsed_m_battleReportId = Parse_GameSTriggerBattleReportPanelSelectionChangedEvent_m_battleReportId();
            m_battleReportId = Option.Some(parsed_m_battleReportId);
        }

        return new GameSTriggerBattleReportPanelSelectionChangedEvent
        {   
            m_battleReportId = Option.OkOrReturnMissingFieldErr(m_battleReportId),
        };
    }

    public int32 Parse_GameSTriggerBattleReportPanelSelectionChangedEvent_m_battleReportId()
    {                             
        var m_battleReportId = Parse_int32();
        return m_battleReportId;
    }

    public GameSTriggerVictoryPanelPlayMissionAgainEvent Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent() 
    {
        Option<int32> m_difficultyLevel = Option.None;
        if (m_difficultyLevel is { HasValue: false })                           
        {
            var parsed_m_difficultyLevel = Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent_m_difficultyLevel();
            m_difficultyLevel = Option.Some(parsed_m_difficultyLevel);
        }

        return new GameSTriggerVictoryPanelPlayMissionAgainEvent
        {   
            m_difficultyLevel = Option.OkOrReturnMissingFieldErr(m_difficultyLevel),
        };
    }

    public int32 Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent_m_difficultyLevel()
    {                             
        var m_difficultyLevel = Parse_int32();
        return m_difficultyLevel;
    }

    public GameSTriggerMovieStartedEvent Parse_GameSTriggerMovieStartedEvent() 
    {
        return new GameSTriggerMovieStartedEvent
        {   
        };
    }

    public GameSTriggerMovieFinishedEvent Parse_GameSTriggerMovieFinishedEvent() 
    {
        return new GameSTriggerMovieFinishedEvent
        {   
        };
    }

    public GameSDecrementGameTimeRemainingEvent Parse_GameSDecrementGameTimeRemainingEvent() 
    {
        Option<int32> m_decrementSeconds = Option.None;
        if (m_decrementSeconds is { HasValue: false })                           
        {
            var parsed_m_decrementSeconds = Parse_GameSDecrementGameTimeRemainingEvent_m_decrementSeconds();
            m_decrementSeconds = Option.Some(parsed_m_decrementSeconds);
        }

        return new GameSDecrementGameTimeRemainingEvent
        {   
            m_decrementSeconds = Option.OkOrReturnMissingFieldErr(m_decrementSeconds),
        };
    }

    public int32 Parse_GameSDecrementGameTimeRemainingEvent_m_decrementSeconds()
    {                             
        var m_decrementSeconds = Parse_int32();
        return m_decrementSeconds;
    }

    public GameSTriggerPortraitLoadedEvent Parse_GameSTriggerPortraitLoadedEvent() 
    {
        Option<int32> m_portraitId = Option.None;
        if (m_portraitId is { HasValue: false })                           
        {
            var parsed_m_portraitId = Parse_GameSTriggerPortraitLoadedEvent_m_portraitId();
            m_portraitId = Option.Some(parsed_m_portraitId);
        }

        return new GameSTriggerPortraitLoadedEvent
        {   
            m_portraitId = Option.OkOrReturnMissingFieldErr(m_portraitId),
        };
    }

    public int32 Parse_GameSTriggerPortraitLoadedEvent_m_portraitId()
    {                             
        var m_portraitId = Parse_int32();
        return m_portraitId;
    }

    public GameSTriggerMovieFunctionEvent Parse_GameSTriggerMovieFunctionEvent() 
    {
        Option<List<u8>> m_functionName = Option.None;
        if (m_functionName is { HasValue: false })                           
        {
            var parsed_m_functionName = Parse_GameSTriggerMovieFunctionEvent_m_functionName();
            m_functionName = Option.Some(parsed_m_functionName);
        }

        return new GameSTriggerMovieFunctionEvent
        {   
            m_functionName = Option.OkOrReturnMissingFieldErr(m_functionName),
        };
    }

    public List<u8> Parse_GameSTriggerMovieFunctionEvent_m_functionName()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSTriggerCustomDialogDismissedEvent Parse_GameSTriggerCustomDialogDismissedEvent() 
    {
        Option<int32> m_result = Option.None;
        if (m_result is { HasValue: false })                           
        {
            var parsed_m_result = Parse_GameSTriggerCustomDialogDismissedEvent_m_result();
            m_result = Option.Some(parsed_m_result);
        }

        return new GameSTriggerCustomDialogDismissedEvent
        {   
            m_result = Option.OkOrReturnMissingFieldErr(m_result),
        };
    }

    public int32 Parse_GameSTriggerCustomDialogDismissedEvent_m_result()
    {                             
        var m_result = Parse_int32();
        return m_result;
    }

    public GameSTriggerGameMenuItemSelectedEvent Parse_GameSTriggerGameMenuItemSelectedEvent() 
    {
        Option<int32> m_gameMenuItemIndex = Option.None;
        if (m_gameMenuItemIndex is { HasValue: false })                           
        {
            var parsed_m_gameMenuItemIndex = Parse_GameSTriggerGameMenuItemSelectedEvent_m_gameMenuItemIndex();
            m_gameMenuItemIndex = Option.Some(parsed_m_gameMenuItemIndex);
        }

        return new GameSTriggerGameMenuItemSelectedEvent
        {   
            m_gameMenuItemIndex = Option.OkOrReturnMissingFieldErr(m_gameMenuItemIndex),
        };
    }

    public int32 Parse_GameSTriggerGameMenuItemSelectedEvent_m_gameMenuItemIndex()
    {                             
        var m_gameMenuItemIndex = Parse_int32();
        return m_gameMenuItemIndex;
    }

    public GameSTriggerMouseWheelEvent Parse_GameSTriggerMouseWheelEvent() 
    {
        Option<GameTFixedMiniBitsSigned> m_wheelSpin = Option.None;
        Option<int8> m_flags = Option.None;
        if (m_wheelSpin is { HasValue: false })                           
        {
            var parsed_m_wheelSpin = Parse_GameSTriggerMouseWheelEvent_m_wheelSpin();
            m_wheelSpin = Option.Some(parsed_m_wheelSpin);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSTriggerMouseWheelEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        return new GameSTriggerMouseWheelEvent
        {   
            m_wheelSpin = Option.OkOrReturnMissingFieldErr(m_wheelSpin),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
        };
    }

    public GameTFixedMiniBitsSigned Parse_GameSTriggerMouseWheelEvent_m_wheelSpin()
    {                             
        var m_wheelSpin = Parse_GameTFixedMiniBitsSigned();
        return m_wheelSpin;
    }

    public int8 Parse_GameSTriggerMouseWheelEvent_m_flags()
    {                             
        var m_flags = Parse_int8();
        return m_flags;
    }

    public GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent() 
    {
        Option<int32> m_purchaseItemId = Option.None;
        if (m_purchaseItemId is { HasValue: false })                           
        {
            var parsed_m_purchaseItemId = Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent_m_purchaseItemId();
            m_purchaseItemId = Option.Some(parsed_m_purchaseItemId);
        }

        return new GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent
        {   
            m_purchaseItemId = Option.OkOrReturnMissingFieldErr(m_purchaseItemId),
        };
    }

    public int32 Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent_m_purchaseItemId()
    {                             
        var m_purchaseItemId = Parse_int32();
        return m_purchaseItemId;
    }

    public GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent() 
    {
        Option<int32> m_purchaseCategoryId = Option.None;
        if (m_purchaseCategoryId is { HasValue: false })                           
        {
            var parsed_m_purchaseCategoryId = Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent_m_purchaseCategoryId();
            m_purchaseCategoryId = Option.Some(parsed_m_purchaseCategoryId);
        }

        return new GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent
        {   
            m_purchaseCategoryId = Option.OkOrReturnMissingFieldErr(m_purchaseCategoryId),
        };
    }

    public int32 Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent_m_purchaseCategoryId()
    {                             
        var m_purchaseCategoryId = Parse_int32();
        return m_purchaseCategoryId;
    }

    public GameSTriggerButtonPressedEvent Parse_GameSTriggerButtonPressedEvent() 
    {
        Option<GameTButtonLink> m_button = Option.None;
        if (m_button is { HasValue: false })                           
        {
            var parsed_m_button = Parse_GameSTriggerButtonPressedEvent_m_button();
            m_button = Option.Some(parsed_m_button);
        }

        return new GameSTriggerButtonPressedEvent
        {   
            m_button = Option.OkOrReturnMissingFieldErr(m_button),
        };
    }

    public GameTButtonLink Parse_GameSTriggerButtonPressedEvent_m_button()
    {                             
        var m_button = Parse_GameTButtonLink();
        return m_button;
    }

    public GameSTriggerGameCreditsFinishedEvent Parse_GameSTriggerGameCreditsFinishedEvent() 
    {
        return new GameSTriggerGameCreditsFinishedEvent
        {   
        };
    }

    public GameSTriggerCutsceneBookmarkFiredEvent Parse_GameSTriggerCutsceneBookmarkFiredEvent() 
    {
        Option<int32> m_cutsceneId = Option.None;
        Option<List<u8>> m_bookmarkName = Option.None;
        if (m_cutsceneId is { HasValue: false })                           
        {
            var parsed_m_cutsceneId = Parse_GameSTriggerCutsceneBookmarkFiredEvent_m_cutsceneId();
            m_cutsceneId = Option.Some(parsed_m_cutsceneId);
        }

        if (m_bookmarkName is { HasValue: false })                           
        {
            var parsed_m_bookmarkName = Parse_GameSTriggerCutsceneBookmarkFiredEvent_m_bookmarkName();
            m_bookmarkName = Option.Some(parsed_m_bookmarkName);
        }

        return new GameSTriggerCutsceneBookmarkFiredEvent
        {   
            m_cutsceneId = Option.OkOrReturnMissingFieldErr(m_cutsceneId),
            m_bookmarkName = Option.OkOrReturnMissingFieldErr(m_bookmarkName),
        };
    }

    public int32 Parse_GameSTriggerCutsceneBookmarkFiredEvent_m_cutsceneId()
    {                             
        var m_cutsceneId = Parse_int32();
        return m_cutsceneId;
    }

    public List<u8> Parse_GameSTriggerCutsceneBookmarkFiredEvent_m_bookmarkName()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSTriggerCutsceneEndSceneFiredEvent Parse_GameSTriggerCutsceneEndSceneFiredEvent() 
    {
        Option<int32> m_cutsceneId = Option.None;
        if (m_cutsceneId is { HasValue: false })                           
        {
            var parsed_m_cutsceneId = Parse_GameSTriggerCutsceneEndSceneFiredEvent_m_cutsceneId();
            m_cutsceneId = Option.Some(parsed_m_cutsceneId);
        }

        return new GameSTriggerCutsceneEndSceneFiredEvent
        {   
            m_cutsceneId = Option.OkOrReturnMissingFieldErr(m_cutsceneId),
        };
    }

    public int32 Parse_GameSTriggerCutsceneEndSceneFiredEvent_m_cutsceneId()
    {                             
        var m_cutsceneId = Parse_int32();
        return m_cutsceneId;
    }

    public GameSTriggerCutsceneConversationLineEvent Parse_GameSTriggerCutsceneConversationLineEvent() 
    {
        Option<int32> m_cutsceneId = Option.None;
        Option<List<u8>> m_conversationLine = Option.None;
        Option<List<u8>> m_altConversationLine = Option.None;
        if (m_cutsceneId is { HasValue: false })                           
        {
            var parsed_m_cutsceneId = Parse_GameSTriggerCutsceneConversationLineEvent_m_cutsceneId();
            m_cutsceneId = Option.Some(parsed_m_cutsceneId);
        }

        if (m_conversationLine is { HasValue: false })                           
        {
            var parsed_m_conversationLine = Parse_GameSTriggerCutsceneConversationLineEvent_m_conversationLine();
            m_conversationLine = Option.Some(parsed_m_conversationLine);
        }

        if (m_altConversationLine is { HasValue: false })                           
        {
            var parsed_m_altConversationLine = Parse_GameSTriggerCutsceneConversationLineEvent_m_altConversationLine();
            m_altConversationLine = Option.Some(parsed_m_altConversationLine);
        }

        return new GameSTriggerCutsceneConversationLineEvent
        {   
            m_cutsceneId = Option.OkOrReturnMissingFieldErr(m_cutsceneId),
            m_conversationLine = Option.OkOrReturnMissingFieldErr(m_conversationLine),
            m_altConversationLine = Option.OkOrReturnMissingFieldErr(m_altConversationLine),
        };
    }

    public int32 Parse_GameSTriggerCutsceneConversationLineEvent_m_cutsceneId()
    {                             
        var m_cutsceneId = Parse_int32();
        return m_cutsceneId;
    }

    public List<u8> Parse_GameSTriggerCutsceneConversationLineEvent_m_conversationLine()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public List<u8> Parse_GameSTriggerCutsceneConversationLineEvent_m_altConversationLine()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSTriggerCutsceneConversationLineMissingEvent Parse_GameSTriggerCutsceneConversationLineMissingEvent() 
    {
        Option<int32> m_cutsceneId = Option.None;
        Option<List<u8>> m_conversationLine = Option.None;
        if (m_cutsceneId is { HasValue: false })                           
        {
            var parsed_m_cutsceneId = Parse_GameSTriggerCutsceneConversationLineMissingEvent_m_cutsceneId();
            m_cutsceneId = Option.Some(parsed_m_cutsceneId);
        }

        if (m_conversationLine is { HasValue: false })                           
        {
            var parsed_m_conversationLine = Parse_GameSTriggerCutsceneConversationLineMissingEvent_m_conversationLine();
            m_conversationLine = Option.Some(parsed_m_conversationLine);
        }

        return new GameSTriggerCutsceneConversationLineMissingEvent
        {   
            m_cutsceneId = Option.OkOrReturnMissingFieldErr(m_cutsceneId),
            m_conversationLine = Option.OkOrReturnMissingFieldErr(m_conversationLine),
        };
    }

    public int32 Parse_GameSTriggerCutsceneConversationLineMissingEvent_m_cutsceneId()
    {                             
        var m_cutsceneId = Parse_int32();
        return m_cutsceneId;
    }

    public List<u8> Parse_GameSTriggerCutsceneConversationLineMissingEvent_m_conversationLine()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSGameUserLeaveEvent Parse_GameSGameUserLeaveEvent() 
    {
        Option<ELeaveReason> m_leaveReason = Option.None;
        if (m_leaveReason is { HasValue: false })                           
        {
            var parsed_m_leaveReason = Parse_GameSGameUserLeaveEvent_m_leaveReason();
            m_leaveReason = Option.Some(parsed_m_leaveReason);
        }

        return new GameSGameUserLeaveEvent
        {   
            m_leaveReason = Option.OkOrReturnMissingFieldErr(m_leaveReason),
        };
    }

    public ELeaveReason Parse_GameSGameUserLeaveEvent_m_leaveReason()
    {                             
        var m_leaveReason = Parse_ELeaveReason();
        return m_leaveReason;
    }

    public GameSGameUserJoinEvent Parse_GameSGameUserJoinEvent() 
    {
        Option<EObserve> m_observe = Option.None;
        Option<CUserName> m_name = Option.None;
        var m_toonHandle = Option.Some<Option<CToonHandle>>(Option.None);
        var m_clanTag = Option.Some<Option<CClanTag>>(Option.None);
        var m_clanLogo = Option.Some<Option<GameCCacheHandle>>(Option.None);
        Option<bool> m_hijack = Option.None;
        var m_hijackCloneGameUserId = Option.Some<Option<TUserId>>(Option.None);
        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_GameSGameUserJoinEvent_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSGameUserJoinEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_toonHandle is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_toonHandle = Parse_GameSGameUserJoinEvent_m_toonHandle();
            m_toonHandle = Option.Some(parsed_m_toonHandle);
        }

        if (m_clanTag is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_clanTag = Parse_GameSGameUserJoinEvent_m_clanTag();
            m_clanTag = Option.Some(parsed_m_clanTag);
        }

        if (m_clanLogo is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_clanLogo = Parse_GameSGameUserJoinEvent_m_clanLogo();
            m_clanLogo = Option.Some(parsed_m_clanLogo);
        }

        if (m_hijack is { HasValue: false })                           
        {
            var parsed_m_hijack = Parse_GameSGameUserJoinEvent_m_hijack();
            m_hijack = Option.Some(parsed_m_hijack);
        }

        if (m_hijackCloneGameUserId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_hijackCloneGameUserId = Parse_GameSGameUserJoinEvent_m_hijackCloneGameUserId();
            m_hijackCloneGameUserId = Option.Some(parsed_m_hijackCloneGameUserId);
        }

        return new GameSGameUserJoinEvent
        {   
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_toonHandle = Option.OkOrReturnMissingFieldErr(m_toonHandle),
            m_clanTag = Option.OkOrReturnMissingFieldErr(m_clanTag),
            m_clanLogo = Option.OkOrReturnMissingFieldErr(m_clanLogo),
            m_hijack = Option.OkOrReturnMissingFieldErr(m_hijack),
            m_hijackCloneGameUserId = Option.OkOrReturnMissingFieldErr(m_hijackCloneGameUserId),
        };
    }

    public EObserve Parse_GameSGameUserJoinEvent_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }

    public CUserName Parse_GameSGameUserJoinEvent_m_name()
    {                             
        var m_name = Parse_CUserName();
        return m_name;
    }

    public Option<CToonHandle> Parse_GameSGameUserJoinEvent_m_toonHandle()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_CToonHandle();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<CClanTag> Parse_GameSGameUserJoinEvent_m_clanTag()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_CClanTag();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameCCacheHandle> Parse_GameSGameUserJoinEvent_m_clanLogo()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameCCacheHandle();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public bool Parse_GameSGameUserJoinEvent_m_hijack()
    {                             
        var m_hijack = parse_bool();
        return m_hijack;
    }

    public Option<TUserId> Parse_GameSGameUserJoinEvent_m_hijackCloneGameUserId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TUserId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCommandManagerStateEvent Parse_GameSCommandManagerStateEvent() 
    {
        Option<GameECommandManagerState> m_state = Option.None;
        var m_sequence = Option.Some<Option<i64>>(Option.None);
        if (m_state is { HasValue: false })                           
        {
            var parsed_m_state = Parse_GameSCommandManagerStateEvent_m_state();
            m_state = Option.Some(parsed_m_state);
        }

        if (m_sequence is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_sequence = Parse_GameSCommandManagerStateEvent_m_sequence();
            m_sequence = Option.Some(parsed_m_sequence);
        }

        return new GameSCommandManagerStateEvent
        {   
            m_state = Option.OkOrReturnMissingFieldErr(m_state),
            m_sequence = Option.OkOrReturnMissingFieldErr(m_sequence),
        };
    }

    public GameECommandManagerState Parse_GameSCommandManagerStateEvent_m_state()
    {                             
        var m_state = Parse_GameECommandManagerState();
        return m_state;
    }

    public Option<i64> Parse_GameSCommandManagerStateEvent_m_sequence()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = parse_packed_int(1, 32);

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCmdUpdateTargetPointEvent Parse_GameSCmdUpdateTargetPointEvent() 
    {
        Option<GameSMapCoord3D> m_target = Option.None;
        if (m_target is { HasValue: false })                           
        {
            var parsed_m_target = Parse_GameSCmdUpdateTargetPointEvent_m_target();
            m_target = Option.Some(parsed_m_target);
        }

        return new GameSCmdUpdateTargetPointEvent
        {   
            m_target = Option.OkOrReturnMissingFieldErr(m_target),
        };
    }

    public GameSMapCoord3D Parse_GameSCmdUpdateTargetPointEvent_m_target()
    {                             
        var m_target = Parse_GameSMapCoord3D();
        return m_target;
    }

    public GameSCmdUpdateTargetUnitEvent Parse_GameSCmdUpdateTargetUnitEvent() 
    {
        Option<GameSCmdDataTargetUnit> m_target = Option.None;
        if (m_target is { HasValue: false })                           
        {
            var parsed_m_target = Parse_GameSCmdUpdateTargetUnitEvent_m_target();
            m_target = Option.Some(parsed_m_target);
        }

        return new GameSCmdUpdateTargetUnitEvent
        {   
            m_target = Option.OkOrReturnMissingFieldErr(m_target),
        };
    }

    public GameSCmdDataTargetUnit Parse_GameSCmdUpdateTargetUnitEvent_m_target()
    {                             
        var m_target = Parse_GameSCmdDataTargetUnit();
        return m_target;
    }

    public GameSCatalogModifyEvent Parse_GameSCatalogModifyEvent() 
    {
        Option<uint8> m_catalog = Option.None;
        Option<uint16> m_entry = Option.None;
        Option<List<u8>> m_field = Option.None;
        Option<List<u8>> m_value = Option.None;
        if (m_catalog is { HasValue: false })                           
        {
            var parsed_m_catalog = Parse_GameSCatalogModifyEvent_m_catalog();
            m_catalog = Option.Some(parsed_m_catalog);
        }

        if (m_entry is { HasValue: false })                           
        {
            var parsed_m_entry = Parse_GameSCatalogModifyEvent_m_entry();
            m_entry = Option.Some(parsed_m_entry);
        }

        if (m_field is { HasValue: false })                           
        {
            var parsed_m_field = Parse_GameSCatalogModifyEvent_m_field();
            m_field = Option.Some(parsed_m_field);
        }

        if (m_value is { HasValue: false })                           
        {
            var parsed_m_value = Parse_GameSCatalogModifyEvent_m_value();
            m_value = Option.Some(parsed_m_value);
        }

        return new GameSCatalogModifyEvent
        {   
            m_catalog = Option.OkOrReturnMissingFieldErr(m_catalog),
            m_entry = Option.OkOrReturnMissingFieldErr(m_entry),
            m_field = Option.OkOrReturnMissingFieldErr(m_field),
            m_value = Option.OkOrReturnMissingFieldErr(m_value),
        };
    }

    public uint8 Parse_GameSCatalogModifyEvent_m_catalog()
    {                             
        var m_catalog = Parse_uint8();
        return m_catalog;
    }

    public uint16 Parse_GameSCatalogModifyEvent_m_entry()
    {                             
        var m_entry = Parse_uint16();
        return m_entry;
    }

    public List<u8> Parse_GameSCatalogModifyEvent_m_field()
    {                             
        var arrayLength = take_n_bits_into_i64(9);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public List<u8> Parse_GameSCatalogModifyEvent_m_value()
    {                             
        var arrayLength = take_n_bits_into_i64(9);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSHeroTalentTreeSelectedEvent Parse_GameSHeroTalentTreeSelectedEvent() 
    {
        Option<uint32> m_index = Option.None;
        if (m_index is { HasValue: false })                           
        {
            var parsed_m_index = Parse_GameSHeroTalentTreeSelectedEvent_m_index();
            m_index = Option.Some(parsed_m_index);
        }

        return new GameSHeroTalentTreeSelectedEvent
        {   
            m_index = Option.OkOrReturnMissingFieldErr(m_index),
        };
    }

    public uint32 Parse_GameSHeroTalentTreeSelectedEvent_m_index()
    {                             
        var m_index = Parse_uint32();
        return m_index;
    }

    public GameSTriggerProfilerLoggingFinishedEvent Parse_GameSTriggerProfilerLoggingFinishedEvent() 
    {
        return new GameSTriggerProfilerLoggingFinishedEvent
        {   
        };
    }

    public GameSHeroTalentTreeSelectionPanelToggledEvent Parse_GameSHeroTalentTreeSelectionPanelToggledEvent() 
    {
        Option<bool> m_shown = Option.None;
        if (m_shown is { HasValue: false })                           
        {
            var parsed_m_shown = Parse_GameSHeroTalentTreeSelectionPanelToggledEvent_m_shown();
            m_shown = Option.Some(parsed_m_shown);
        }

        return new GameSHeroTalentTreeSelectionPanelToggledEvent
        {   
            m_shown = Option.OkOrReturnMissingFieldErr(m_shown),
        };
    }

    public bool Parse_GameSHeroTalentTreeSelectionPanelToggledEvent_m_shown()
    {                             
        var m_shown = parse_bool();
        return m_shown;
    }

    public GameSMuteChatEvent Parse_GameSMuteChatEvent() 
    {
        Option<TUserId> m_targetUserId = Option.None;
        Option<bool> m_muted = Option.None;
        if (m_targetUserId is { HasValue: false })                           
        {
            var parsed_m_targetUserId = Parse_GameSMuteChatEvent_m_targetUserId();
            m_targetUserId = Option.Some(parsed_m_targetUserId);
        }

        if (m_muted is { HasValue: false })                           
        {
            var parsed_m_muted = Parse_GameSMuteChatEvent_m_muted();
            m_muted = Option.Some(parsed_m_muted);
        }

        return new GameSMuteChatEvent
        {   
            m_targetUserId = Option.OkOrReturnMissingFieldErr(m_targetUserId),
            m_muted = Option.OkOrReturnMissingFieldErr(m_muted),
        };
    }

    public TUserId Parse_GameSMuteChatEvent_m_targetUserId()
    {                             
        var m_targetUserId = Parse_TUserId();
        return m_targetUserId;
    }

    public bool Parse_GameSMuteChatEvent_m_muted()
    {                             
        var m_muted = parse_bool();
        return m_muted;
    }

    public GameSConvertToReplaySessionEvent Parse_GameSConvertToReplaySessionEvent() 
    {
        var m_replayJumpGameLoop = Option.Some<Option<int32>>(Option.None);
        if (m_replayJumpGameLoop is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_replayJumpGameLoop = Parse_GameSConvertToReplaySessionEvent_m_replayJumpGameLoop();
            m_replayJumpGameLoop = Option.Some(parsed_m_replayJumpGameLoop);
        }

        return new GameSConvertToReplaySessionEvent
        {   
            m_replayJumpGameLoop = Option.OkOrReturnMissingFieldErr(m_replayJumpGameLoop),
        };
    }

    public Option<int32> Parse_GameSConvertToReplaySessionEvent_m_replayJumpGameLoop()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_int32();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSSetSyncLoadingTimeEvent Parse_GameSSetSyncLoadingTimeEvent() 
    {
        Option<uint32> m_syncTime = Option.None;
        if (m_syncTime is { HasValue: false })                           
        {
            var parsed_m_syncTime = Parse_GameSSetSyncLoadingTimeEvent_m_syncTime();
            m_syncTime = Option.Some(parsed_m_syncTime);
        }

        return new GameSSetSyncLoadingTimeEvent
        {   
            m_syncTime = Option.OkOrReturnMissingFieldErr(m_syncTime),
        };
    }

    public uint32 Parse_GameSSetSyncLoadingTimeEvent_m_syncTime()
    {                             
        var m_syncTime = Parse_uint32();
        return m_syncTime;
    }

    public GameSSetSyncPlayingTimeEvent Parse_GameSSetSyncPlayingTimeEvent() 
    {
        Option<uint32> m_syncTime = Option.None;
        if (m_syncTime is { HasValue: false })                           
        {
            var parsed_m_syncTime = Parse_GameSSetSyncPlayingTimeEvent_m_syncTime();
            m_syncTime = Option.Some(parsed_m_syncTime);
        }

        return new GameSSetSyncPlayingTimeEvent
        {   
            m_syncTime = Option.OkOrReturnMissingFieldErr(m_syncTime),
        };
    }

    public uint32 Parse_GameSSetSyncPlayingTimeEvent_m_syncTime()
    {                             
        var m_syncTime = Parse_uint32();
        return m_syncTime;
    }

    public GameSPeerSetSyncLoadingTimeEvent Parse_GameSPeerSetSyncLoadingTimeEvent() 
    {
        Option<uint32> m_syncTime = Option.None;
        if (m_syncTime is { HasValue: false })                           
        {
            var parsed_m_syncTime = Parse_GameSPeerSetSyncLoadingTimeEvent_m_syncTime();
            m_syncTime = Option.Some(parsed_m_syncTime);
        }

        return new GameSPeerSetSyncLoadingTimeEvent
        {   
            m_syncTime = Option.OkOrReturnMissingFieldErr(m_syncTime),
        };
    }

    public uint32 Parse_GameSPeerSetSyncLoadingTimeEvent_m_syncTime()
    {                             
        var m_syncTime = Parse_uint32();
        return m_syncTime;
    }

    public GameSPeerSetSyncPlayingTimeEvent Parse_GameSPeerSetSyncPlayingTimeEvent() 
    {
        Option<uint32> m_syncTime = Option.None;
        if (m_syncTime is { HasValue: false })                           
        {
            var parsed_m_syncTime = Parse_GameSPeerSetSyncPlayingTimeEvent_m_syncTime();
            m_syncTime = Option.Some(parsed_m_syncTime);
        }

        return new GameSPeerSetSyncPlayingTimeEvent
        {   
            m_syncTime = Option.OkOrReturnMissingFieldErr(m_syncTime),
        };
    }

    public uint32 Parse_GameSPeerSetSyncPlayingTimeEvent_m_syncTime()
    {                             
        var m_syncTime = Parse_uint32();
        return m_syncTime;
    }

    public GameSPoint Parse_GameSPoint() 
    {
        Option<GameTFixedBits> x = Option.None;
        Option<GameTFixedBits> y = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSPoint_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSPoint_y();
            y = Option.Some(parsed_y);
        }

        return new GameSPoint
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
        };
    }

    public GameTFixedBits Parse_GameSPoint_x()
    {                             
        var x = Parse_GameTFixedBits();
        return x;
    }

    public GameTFixedBits Parse_GameSPoint_y()
    {                             
        var y = Parse_GameTFixedBits();
        return y;
    }

    public GameSPoint3 Parse_GameSPoint3() 
    {
        Option<GameTFixedBits> x = Option.None;
        Option<GameTFixedBits> y = Option.None;
        Option<GameTFixedBits> z = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSPoint3_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSPoint3_y();
            y = Option.Some(parsed_y);
        }

        if (z is { HasValue: false })                           
        {
            var parsed_z = Parse_GameSPoint3_z();
            z = Option.Some(parsed_z);
        }

        return new GameSPoint3
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
            z = Option.OkOrReturnMissingFieldErr(z),
        };
    }

    public GameTFixedBits Parse_GameSPoint3_x()
    {                             
        var x = Parse_GameTFixedBits();
        return x;
    }

    public GameTFixedBits Parse_GameSPoint3_y()
    {                             
        var y = Parse_GameTFixedBits();
        return y;
    }

    public GameTFixedBits Parse_GameSPoint3_z()
    {                             
        var z = Parse_GameTFixedBits();
        return z;
    }

    public GameSPointMini Parse_GameSPointMini() 
    {
        Option<GameTFixedMiniBitsUnsigned> x = Option.None;
        Option<GameTFixedMiniBitsUnsigned> y = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSPointMini_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSPointMini_y();
            y = Option.Some(parsed_y);
        }

        return new GameSPointMini
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
        };
    }

    public GameTFixedMiniBitsUnsigned Parse_GameSPointMini_x()
    {                             
        var x = Parse_GameTFixedMiniBitsUnsigned();
        return x;
    }

    public GameTFixedMiniBitsUnsigned Parse_GameSPointMini_y()
    {                             
        var y = Parse_GameTFixedMiniBitsUnsigned();
        return y;
    }

    public GameSMapCoord Parse_GameSMapCoord() 
    {
        Option<GameTMapCoordFixedBits> x = Option.None;
        Option<GameTMapCoordFixedBits> y = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSMapCoord_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSMapCoord_y();
            y = Option.Some(parsed_y);
        }

        return new GameSMapCoord
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
        };
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord_x()
    {                             
        var x = Parse_GameTMapCoordFixedBits();
        return x;
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord_y()
    {                             
        var y = Parse_GameTMapCoordFixedBits();
        return y;
    }

    public GameSMapCoord3D Parse_GameSMapCoord3D() 
    {
        Option<GameTMapCoordFixedBits> x = Option.None;
        Option<GameTMapCoordFixedBits> y = Option.None;
        Option<GameTFixedBits> z = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSMapCoord3D_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSMapCoord3D_y();
            y = Option.Some(parsed_y);
        }

        if (z is { HasValue: false })                           
        {
            var parsed_z = Parse_GameSMapCoord3D_z();
            z = Option.Some(parsed_z);
        }

        return new GameSMapCoord3D
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
            z = Option.OkOrReturnMissingFieldErr(z),
        };
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord3D_x()
    {                             
        var x = Parse_GameTMapCoordFixedBits();
        return x;
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord3D_y()
    {                             
        var y = Parse_GameTMapCoordFixedBits();
        return y;
    }

    public GameTFixedBits Parse_GameSMapCoord3D_z()
    {                             
        var z = Parse_GameTFixedBits();
        return z;
    }

    public GameSUICoord Parse_GameSUICoord() 
    {
        Option<GameTUICoordX> x = Option.None;
        Option<GameTUICoordY> y = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSUICoord_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSUICoord_y();
            y = Option.Some(parsed_y);
        }

        return new GameSUICoord
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
        };
    }

    public GameTUICoordX Parse_GameSUICoord_x()
    {                             
        var x = Parse_GameTUICoordX();
        return x;
    }

    public GameTUICoordY Parse_GameSUICoord_y()
    {                             
        var y = Parse_GameTUICoordY();
        return y;
    }

    public GameSSyncSoundLength Parse_GameSSyncSoundLength() 
    {
        Option<List<uint32>> m_soundHash = Option.None;
        Option<List<uint32>> m_length = Option.None;
        if (m_soundHash is { HasValue: false })                           
        {
            var parsed_m_soundHash = Parse_GameSSyncSoundLength_m_soundHash();
            m_soundHash = Option.Some(parsed_m_soundHash);
        }

        if (m_length is { HasValue: false })                           
        {
            var parsed_m_length = Parse_GameSSyncSoundLength_m_length();
            m_length = Option.Some(parsed_m_length);
        }

        return new GameSSyncSoundLength
        {   
            m_soundHash = Option.OkOrReturnMissingFieldErr(m_soundHash),
            m_length = Option.OkOrReturnMissingFieldErr(m_length),
        };
    }

    public List<uint32> Parse_GameSSyncSoundLength_m_soundHash()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<uint32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_uint32();
            array.Add(data);
        }
        return array;
    }

    public List<uint32> Parse_GameSSyncSoundLength_m_length()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<uint32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_uint32();
            array.Add(data);
        }
        return array;
    }

    public GameSThumbnail Parse_GameSThumbnail() 
    {
        Option<List<u8>> m_file = Option.None;
        if (m_file is { HasValue: false })                           
        {
            var parsed_m_file = Parse_GameSThumbnail_m_file();
            m_file = Option.Some(parsed_m_file);
        }

        return new GameSThumbnail
        {   
            m_file = Option.OkOrReturnMissingFieldErr(m_file),
        };
    }

    public List<u8> Parse_GameSThumbnail_m_file()
    {                             
        var arrayLength = take_n_bits_into_i64(10);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSColor Parse_GameSColor() 
    {
        Option<uint8> m_a = Option.None;
        Option<uint8> m_r = Option.None;
        Option<uint8> m_g = Option.None;
        Option<uint8> m_b = Option.None;
        if (m_a is { HasValue: false })                           
        {
            var parsed_m_a = Parse_GameSColor_m_a();
            m_a = Option.Some(parsed_m_a);
        }

        if (m_r is { HasValue: false })                           
        {
            var parsed_m_r = Parse_GameSColor_m_r();
            m_r = Option.Some(parsed_m_r);
        }

        if (m_g is { HasValue: false })                           
        {
            var parsed_m_g = Parse_GameSColor_m_g();
            m_g = Option.Some(parsed_m_g);
        }

        if (m_b is { HasValue: false })                           
        {
            var parsed_m_b = Parse_GameSColor_m_b();
            m_b = Option.Some(parsed_m_b);
        }

        return new GameSColor
        {   
            m_a = Option.OkOrReturnMissingFieldErr(m_a),
            m_r = Option.OkOrReturnMissingFieldErr(m_r),
            m_g = Option.OkOrReturnMissingFieldErr(m_g),
            m_b = Option.OkOrReturnMissingFieldErr(m_b),
        };
    }

    public uint8 Parse_GameSColor_m_a()
    {                             
        var m_a = Parse_uint8();
        return m_a;
    }

    public uint8 Parse_GameSColor_m_r()
    {                             
        var m_r = Parse_uint8();
        return m_r;
    }

    public uint8 Parse_GameSColor_m_g()
    {                             
        var m_g = Parse_uint8();
        return m_g;
    }

    public uint8 Parse_GameSColor_m_b()
    {                             
        var m_b = Parse_uint8();
        return m_b;
    }

    public GameSToonNameDetails Parse_GameSToonNameDetails() 
    {
        Option<uint8> m_region = Option.None;
        Option<List<u8>> m_programId = Option.None;
        Option<uint32> m_realm = Option.None;
        Option<List<u8>> m_name = Option.None;
        Option<uint64> m_id = Option.None;
        if (m_region is { HasValue: false })                           
        {
            var parsed_m_region = Parse_GameSToonNameDetails_m_region();
            m_region = Option.Some(parsed_m_region);
        }

        if (m_programId is { HasValue: false })                           
        {
            var parsed_m_programId = Parse_GameSToonNameDetails_m_programId();
            m_programId = Option.Some(parsed_m_programId);
        }

        if (m_realm is { HasValue: false })                           
        {
            var parsed_m_realm = Parse_GameSToonNameDetails_m_realm();
            m_realm = Option.Some(parsed_m_realm);
        }

        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSToonNameDetails_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_id is { HasValue: false })                           
        {
            var parsed_m_id = Parse_GameSToonNameDetails_m_id();
            m_id = Option.Some(parsed_m_id);
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

    public uint8 Parse_GameSToonNameDetails_m_region()
    {                             
        var m_region = Parse_uint8();
        return m_region;
    }

    public List<u8> Parse_GameSToonNameDetails_m_programId()
    {                             
        var m_programId = take_fourcc();
        return m_programId;
    }

    public uint32 Parse_GameSToonNameDetails_m_realm()
    {                             
        var m_realm = Parse_uint32();
        return m_realm;
    }

    public List<u8> Parse_GameSToonNameDetails_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(5);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public uint64 Parse_GameSToonNameDetails_m_id()
    {                             
        var m_id = Parse_uint64();
        return m_id;
    }

    public GameSPlayerDetails Parse_GameSPlayerDetails() 
    {
        Option<CUserName> m_name = Option.None;
        Option<GameSToonNameDetails> m_toon = Option.None;
        Option<List<u8>> m_race = Option.None;
        Option<GameSColor> m_color = Option.None;
        Option<GameTControlId> m_control = Option.None;
        Option<GameTTeamId> m_teamId = Option.None;
        Option<GameTHandicap> m_handicap = Option.None;
        Option<EObserve> m_observe = Option.None;
        Option<GameEResultDetails> m_result = Option.None;
        var m_workingSetSlotId = Option.Some<Option<uint8>>(Option.None);
        Option<List<u8>> m_hero = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSPlayerDetails_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_toon is { HasValue: false })                           
        {
            var parsed_m_toon = Parse_GameSPlayerDetails_m_toon();
            m_toon = Option.Some(parsed_m_toon);
        }

        if (m_race is { HasValue: false })                           
        {
            var parsed_m_race = Parse_GameSPlayerDetails_m_race();
            m_race = Option.Some(parsed_m_race);
        }

        if (m_color is { HasValue: false })                           
        {
            var parsed_m_color = Parse_GameSPlayerDetails_m_color();
            m_color = Option.Some(parsed_m_color);
        }

        if (m_control is { HasValue: false })                           
        {
            var parsed_m_control = Parse_GameSPlayerDetails_m_control();
            m_control = Option.Some(parsed_m_control);
        }

        if (m_teamId is { HasValue: false })                           
        {
            var parsed_m_teamId = Parse_GameSPlayerDetails_m_teamId();
            m_teamId = Option.Some(parsed_m_teamId);
        }

        if (m_handicap is { HasValue: false })                           
        {
            var parsed_m_handicap = Parse_GameSPlayerDetails_m_handicap();
            m_handicap = Option.Some(parsed_m_handicap);
        }

        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_GameSPlayerDetails_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        if (m_result is { HasValue: false })                           
        {
            var parsed_m_result = Parse_GameSPlayerDetails_m_result();
            m_result = Option.Some(parsed_m_result);
        }

        if (m_workingSetSlotId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_workingSetSlotId = Parse_GameSPlayerDetails_m_workingSetSlotId();
            m_workingSetSlotId = Option.Some(parsed_m_workingSetSlotId);
        }

        if (m_hero is { HasValue: false })                           
        {
            var parsed_m_hero = Parse_GameSPlayerDetails_m_hero();
            m_hero = Option.Some(parsed_m_hero);
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

    public CUserName Parse_GameSPlayerDetails_m_name()
    {                             
        var m_name = Parse_CUserName();
        return m_name;
    }

    public GameSToonNameDetails Parse_GameSPlayerDetails_m_toon()
    {                             
        var m_toon = Parse_GameSToonNameDetails();
        return m_toon;
    }

    public List<u8> Parse_GameSPlayerDetails_m_race()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSColor Parse_GameSPlayerDetails_m_color()
    {                             
        var m_color = Parse_GameSColor();
        return m_color;
    }

    public GameTControlId Parse_GameSPlayerDetails_m_control()
    {                             
        var m_control = Parse_GameTControlId();
        return m_control;
    }

    public GameTTeamId Parse_GameSPlayerDetails_m_teamId()
    {                             
        var m_teamId = Parse_GameTTeamId();
        return m_teamId;
    }

    public GameTHandicap Parse_GameSPlayerDetails_m_handicap()
    {                             
        var m_handicap = Parse_GameTHandicap();
        return m_handicap;
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

    public Option<uint8> Parse_GameSPlayerDetails_m_workingSetSlotId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public List<u8> Parse_GameSPlayerDetails_m_hero()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSDetails Parse_GameSDetails() 
    {
        var m_playerList = Option.Some<Option<GameCPlayerDetailsArray>>(Option.None);
        Option<List<u8>> m_title = Option.None;
        Option<List<u8>> m_difficulty = Option.None;
        Option<GameSThumbnail> m_thumbnail = Option.None;
        Option<bool> m_isBlizzardMap = Option.None;
        Option<int64> m_timeUTC = Option.None;
        Option<int64> m_timeLocalOffset = Option.None;
        var m_restartAsTransitionMap = Option.Some<Option<bool>>(Option.None);
        Option<bool> m_disableRecoverGame = Option.None;
        Option<List<u8>> m_description = Option.None;
        Option<CFilePath> m_imageFilePath = Option.None;
        Option<uint8> m_campaignIndex = Option.None;
        Option<CFilePath> m_mapFileName = Option.None;
        var m_cacheHandles = Option.Some<Option<GameCCacheHandles>>(Option.None);
        Option<bool> m_miniSave = Option.None;
        Option<GameEGameSpeed> m_gameSpeed = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        var m_modPaths = Option.Some<Option<GameCModPaths>>(Option.None);
        if (m_playerList is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_playerList = Parse_GameSDetails_m_playerList();
            m_playerList = Option.Some(parsed_m_playerList);
        }

        if (m_title is { HasValue: false })                           
        {
            var parsed_m_title = Parse_GameSDetails_m_title();
            m_title = Option.Some(parsed_m_title);
        }

        if (m_difficulty is { HasValue: false })                           
        {
            var parsed_m_difficulty = Parse_GameSDetails_m_difficulty();
            m_difficulty = Option.Some(parsed_m_difficulty);
        }

        if (m_thumbnail is { HasValue: false })                           
        {
            var parsed_m_thumbnail = Parse_GameSDetails_m_thumbnail();
            m_thumbnail = Option.Some(parsed_m_thumbnail);
        }

        if (m_isBlizzardMap is { HasValue: false })                           
        {
            var parsed_m_isBlizzardMap = Parse_GameSDetails_m_isBlizzardMap();
            m_isBlizzardMap = Option.Some(parsed_m_isBlizzardMap);
        }

        if (m_timeUTC is { HasValue: false })                           
        {
            var parsed_m_timeUTC = Parse_GameSDetails_m_timeUTC();
            m_timeUTC = Option.Some(parsed_m_timeUTC);
        }

        if (m_timeLocalOffset is { HasValue: false })                           
        {
            var parsed_m_timeLocalOffset = Parse_GameSDetails_m_timeLocalOffset();
            m_timeLocalOffset = Option.Some(parsed_m_timeLocalOffset);
        }

        if (m_restartAsTransitionMap is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_restartAsTransitionMap = Parse_GameSDetails_m_restartAsTransitionMap();
            m_restartAsTransitionMap = Option.Some(parsed_m_restartAsTransitionMap);
        }

        if (m_disableRecoverGame is { HasValue: false })                           
        {
            var parsed_m_disableRecoverGame = Parse_GameSDetails_m_disableRecoverGame();
            m_disableRecoverGame = Option.Some(parsed_m_disableRecoverGame);
        }

        if (m_description is { HasValue: false })                           
        {
            var parsed_m_description = Parse_GameSDetails_m_description();
            m_description = Option.Some(parsed_m_description);
        }

        if (m_imageFilePath is { HasValue: false })                           
        {
            var parsed_m_imageFilePath = Parse_GameSDetails_m_imageFilePath();
            m_imageFilePath = Option.Some(parsed_m_imageFilePath);
        }

        if (m_campaignIndex is { HasValue: false })                           
        {
            var parsed_m_campaignIndex = Parse_GameSDetails_m_campaignIndex();
            m_campaignIndex = Option.Some(parsed_m_campaignIndex);
        }

        if (m_mapFileName is { HasValue: false })                           
        {
            var parsed_m_mapFileName = Parse_GameSDetails_m_mapFileName();
            m_mapFileName = Option.Some(parsed_m_mapFileName);
        }

        if (m_cacheHandles is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_cacheHandles = Parse_GameSDetails_m_cacheHandles();
            m_cacheHandles = Option.Some(parsed_m_cacheHandles);
        }

        if (m_miniSave is { HasValue: false })                           
        {
            var parsed_m_miniSave = Parse_GameSDetails_m_miniSave();
            m_miniSave = Option.Some(parsed_m_miniSave);
        }

        if (m_gameSpeed is { HasValue: false })                           
        {
            var parsed_m_gameSpeed = Parse_GameSDetails_m_gameSpeed();
            m_gameSpeed = Option.Some(parsed_m_gameSpeed);
        }

        if (m_defaultDifficulty is { HasValue: false })                           
        {
            var parsed_m_defaultDifficulty = Parse_GameSDetails_m_defaultDifficulty();
            m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
        }

        if (m_modPaths is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_modPaths = Parse_GameSDetails_m_modPaths();
            m_modPaths = Option.Some(parsed_m_modPaths);
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

    public Option<GameCPlayerDetailsArray> Parse_GameSDetails_m_playerList()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameCPlayerDetailsArray();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public List<u8> Parse_GameSDetails_m_title()
    {                             
        var arrayLength = take_n_bits_into_i64(9);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public List<u8> Parse_GameSDetails_m_difficulty()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSThumbnail Parse_GameSDetails_m_thumbnail()
    {                             
        var m_thumbnail = Parse_GameSThumbnail();
        return m_thumbnail;
    }

    public bool Parse_GameSDetails_m_isBlizzardMap()
    {                             
        var m_isBlizzardMap = parse_bool();
        return m_isBlizzardMap;
    }

    public int64 Parse_GameSDetails_m_timeUTC()
    {                             
        var m_timeUTC = Parse_int64();
        return m_timeUTC;
    }

    public int64 Parse_GameSDetails_m_timeLocalOffset()
    {                             
        var m_timeLocalOffset = Parse_int64();
        return m_timeLocalOffset;
    }

    public Option<bool> Parse_GameSDetails_m_restartAsTransitionMap()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = parse_bool();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public bool Parse_GameSDetails_m_disableRecoverGame()
    {                             
        var m_disableRecoverGame = parse_bool();
        return m_disableRecoverGame;
    }

    public List<u8> Parse_GameSDetails_m_description()
    {                             
        var arrayLength = take_n_bits_into_i64(11);
        var array = new List<u8>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_aligned_byte();
            array.Add(data);
        }
        return array;
    }

    public CFilePath Parse_GameSDetails_m_imageFilePath()
    {                             
        var m_imageFilePath = Parse_CFilePath();
        return m_imageFilePath;
    }

    public uint8 Parse_GameSDetails_m_campaignIndex()
    {                             
        var m_campaignIndex = Parse_uint8();
        return m_campaignIndex;
    }

    public CFilePath Parse_GameSDetails_m_mapFileName()
    {                             
        var m_mapFileName = Parse_CFilePath();
        return m_mapFileName;
    }

    public Option<GameCCacheHandles> Parse_GameSDetails_m_cacheHandles()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameCCacheHandles();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public bool Parse_GameSDetails_m_miniSave()
    {                             
        var m_miniSave = parse_bool();
        return m_miniSave;
    }

    public GameEGameSpeed Parse_GameSDetails_m_gameSpeed()
    {                             
        var m_gameSpeed = Parse_GameEGameSpeed();
        return m_gameSpeed;
    }

    public GameTDifficulty Parse_GameSDetails_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = Parse_GameTDifficulty();
        return m_defaultDifficulty;
    }

    public Option<GameCModPaths> Parse_GameSDetails_m_modPaths()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameCModPaths();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSGameOptions Parse_GameSGameOptions() 
    {
        Option<bool> m_lockTeams = Option.None;
        Option<bool> m_teamsTogether = Option.None;
        Option<bool> m_advancedSharedControl = Option.None;
        Option<bool> m_randomRaces = Option.None;
        Option<bool> m_battleNet = Option.None;
        Option<bool> m_amm = Option.None;
        Option<bool> m_competitive = Option.None;
        Option<bool> m_practice = Option.None;
        Option<bool> m_cooperative = Option.None;
        Option<bool> m_noVictoryOrDefeat = Option.None;
        Option<bool> m_heroDuplicatesAllowed = Option.None;
        Option<GameEOptionFog> m_fog = Option.None;
        Option<GameEOptionObservers> m_observers = Option.None;
        Option<GameEOptionUserDifficulty> m_userDifficulty = Option.None;
        Option<GameEClientDebugFlags> m_clientDebugFlags = Option.None;
        Option<bool> m_buildCoachEnabled = Option.None;
        if (m_lockTeams is { HasValue: false })                           
        {
            var parsed_m_lockTeams = Parse_GameSGameOptions_m_lockTeams();
            m_lockTeams = Option.Some(parsed_m_lockTeams);
        }

        if (m_teamsTogether is { HasValue: false })                           
        {
            var parsed_m_teamsTogether = Parse_GameSGameOptions_m_teamsTogether();
            m_teamsTogether = Option.Some(parsed_m_teamsTogether);
        }

        if (m_advancedSharedControl is { HasValue: false })                           
        {
            var parsed_m_advancedSharedControl = Parse_GameSGameOptions_m_advancedSharedControl();
            m_advancedSharedControl = Option.Some(parsed_m_advancedSharedControl);
        }

        if (m_randomRaces is { HasValue: false })                           
        {
            var parsed_m_randomRaces = Parse_GameSGameOptions_m_randomRaces();
            m_randomRaces = Option.Some(parsed_m_randomRaces);
        }

        if (m_battleNet is { HasValue: false })                           
        {
            var parsed_m_battleNet = Parse_GameSGameOptions_m_battleNet();
            m_battleNet = Option.Some(parsed_m_battleNet);
        }

        if (m_amm is { HasValue: false })                           
        {
            var parsed_m_amm = Parse_GameSGameOptions_m_amm();
            m_amm = Option.Some(parsed_m_amm);
        }

        if (m_competitive is { HasValue: false })                           
        {
            var parsed_m_competitive = Parse_GameSGameOptions_m_competitive();
            m_competitive = Option.Some(parsed_m_competitive);
        }

        if (m_practice is { HasValue: false })                           
        {
            var parsed_m_practice = Parse_GameSGameOptions_m_practice();
            m_practice = Option.Some(parsed_m_practice);
        }

        if (m_cooperative is { HasValue: false })                           
        {
            var parsed_m_cooperative = Parse_GameSGameOptions_m_cooperative();
            m_cooperative = Option.Some(parsed_m_cooperative);
        }

        if (m_noVictoryOrDefeat is { HasValue: false })                           
        {
            var parsed_m_noVictoryOrDefeat = Parse_GameSGameOptions_m_noVictoryOrDefeat();
            m_noVictoryOrDefeat = Option.Some(parsed_m_noVictoryOrDefeat);
        }

        if (m_heroDuplicatesAllowed is { HasValue: false })                           
        {
            var parsed_m_heroDuplicatesAllowed = Parse_GameSGameOptions_m_heroDuplicatesAllowed();
            m_heroDuplicatesAllowed = Option.Some(parsed_m_heroDuplicatesAllowed);
        }

        if (m_fog is { HasValue: false })                           
        {
            var parsed_m_fog = Parse_GameSGameOptions_m_fog();
            m_fog = Option.Some(parsed_m_fog);
        }

        if (m_observers is { HasValue: false })                           
        {
            var parsed_m_observers = Parse_GameSGameOptions_m_observers();
            m_observers = Option.Some(parsed_m_observers);
        }

        if (m_userDifficulty is { HasValue: false })                           
        {
            var parsed_m_userDifficulty = Parse_GameSGameOptions_m_userDifficulty();
            m_userDifficulty = Option.Some(parsed_m_userDifficulty);
        }

        if (m_clientDebugFlags is { HasValue: false })                           
        {
            var parsed_m_clientDebugFlags = Parse_GameSGameOptions_m_clientDebugFlags();
            m_clientDebugFlags = Option.Some(parsed_m_clientDebugFlags);
        }

        if (m_buildCoachEnabled is { HasValue: false })                           
        {
            var parsed_m_buildCoachEnabled = Parse_GameSGameOptions_m_buildCoachEnabled();
            m_buildCoachEnabled = Option.Some(parsed_m_buildCoachEnabled);
        }

        return new GameSGameOptions
        {   
            m_lockTeams = Option.OkOrReturnMissingFieldErr(m_lockTeams),
            m_teamsTogether = Option.OkOrReturnMissingFieldErr(m_teamsTogether),
            m_advancedSharedControl = Option.OkOrReturnMissingFieldErr(m_advancedSharedControl),
            m_randomRaces = Option.OkOrReturnMissingFieldErr(m_randomRaces),
            m_battleNet = Option.OkOrReturnMissingFieldErr(m_battleNet),
            m_amm = Option.OkOrReturnMissingFieldErr(m_amm),
            m_competitive = Option.OkOrReturnMissingFieldErr(m_competitive),
            m_practice = Option.OkOrReturnMissingFieldErr(m_practice),
            m_cooperative = Option.OkOrReturnMissingFieldErr(m_cooperative),
            m_noVictoryOrDefeat = Option.OkOrReturnMissingFieldErr(m_noVictoryOrDefeat),
            m_heroDuplicatesAllowed = Option.OkOrReturnMissingFieldErr(m_heroDuplicatesAllowed),
            m_fog = Option.OkOrReturnMissingFieldErr(m_fog),
            m_observers = Option.OkOrReturnMissingFieldErr(m_observers),
            m_userDifficulty = Option.OkOrReturnMissingFieldErr(m_userDifficulty),
            m_clientDebugFlags = Option.OkOrReturnMissingFieldErr(m_clientDebugFlags),
            m_buildCoachEnabled = Option.OkOrReturnMissingFieldErr(m_buildCoachEnabled),
        };
    }

    public bool Parse_GameSGameOptions_m_lockTeams()
    {                             
        var m_lockTeams = parse_bool();
        return m_lockTeams;
    }

    public bool Parse_GameSGameOptions_m_teamsTogether()
    {                             
        var m_teamsTogether = parse_bool();
        return m_teamsTogether;
    }

    public bool Parse_GameSGameOptions_m_advancedSharedControl()
    {                             
        var m_advancedSharedControl = parse_bool();
        return m_advancedSharedControl;
    }

    public bool Parse_GameSGameOptions_m_randomRaces()
    {                             
        var m_randomRaces = parse_bool();
        return m_randomRaces;
    }

    public bool Parse_GameSGameOptions_m_battleNet()
    {                             
        var m_battleNet = parse_bool();
        return m_battleNet;
    }

    public bool Parse_GameSGameOptions_m_amm()
    {                             
        var m_amm = parse_bool();
        return m_amm;
    }

    public bool Parse_GameSGameOptions_m_competitive()
    {                             
        var m_competitive = parse_bool();
        return m_competitive;
    }

    public bool Parse_GameSGameOptions_m_practice()
    {                             
        var m_practice = parse_bool();
        return m_practice;
    }

    public bool Parse_GameSGameOptions_m_cooperative()
    {                             
        var m_cooperative = parse_bool();
        return m_cooperative;
    }

    public bool Parse_GameSGameOptions_m_noVictoryOrDefeat()
    {                             
        var m_noVictoryOrDefeat = parse_bool();
        return m_noVictoryOrDefeat;
    }

    public bool Parse_GameSGameOptions_m_heroDuplicatesAllowed()
    {                             
        var m_heroDuplicatesAllowed = parse_bool();
        return m_heroDuplicatesAllowed;
    }

    public GameEOptionFog Parse_GameSGameOptions_m_fog()
    {                             
        var m_fog = Parse_GameEOptionFog();
        return m_fog;
    }

    public GameEOptionObservers Parse_GameSGameOptions_m_observers()
    {                             
        var m_observers = Parse_GameEOptionObservers();
        return m_observers;
    }

    public GameEOptionUserDifficulty Parse_GameSGameOptions_m_userDifficulty()
    {                             
        var m_userDifficulty = Parse_GameEOptionUserDifficulty();
        return m_userDifficulty;
    }

    public GameEClientDebugFlags Parse_GameSGameOptions_m_clientDebugFlags()
    {                             
        var m_clientDebugFlags = Parse_GameEClientDebugFlags();
        return m_clientDebugFlags;
    }

    public bool Parse_GameSGameOptions_m_buildCoachEnabled()
    {                             
        var m_buildCoachEnabled = parse_bool();
        return m_buildCoachEnabled;
    }

    public GameSSlotDescription Parse_GameSSlotDescription() 
    {
        Option<GameCAllowedColors> m_allowedColors = Option.None;
        Option<CAllowedRaces> m_allowedRaces = Option.None;
        Option<GameCAllowedDifficulty> m_allowedDifficulty = Option.None;
        Option<GameCAllowedControls> m_allowedControls = Option.None;
        Option<CAllowedObserveTypes> m_allowedObserveTypes = Option.None;
        Option<GameCAllowedAIBuild> m_allowedAIBuilds = Option.None;
        if (m_allowedColors is { HasValue: false })                           
        {
            var parsed_m_allowedColors = Parse_GameSSlotDescription_m_allowedColors();
            m_allowedColors = Option.Some(parsed_m_allowedColors);
        }

        if (m_allowedRaces is { HasValue: false })                           
        {
            var parsed_m_allowedRaces = Parse_GameSSlotDescription_m_allowedRaces();
            m_allowedRaces = Option.Some(parsed_m_allowedRaces);
        }

        if (m_allowedDifficulty is { HasValue: false })                           
        {
            var parsed_m_allowedDifficulty = Parse_GameSSlotDescription_m_allowedDifficulty();
            m_allowedDifficulty = Option.Some(parsed_m_allowedDifficulty);
        }

        if (m_allowedControls is { HasValue: false })                           
        {
            var parsed_m_allowedControls = Parse_GameSSlotDescription_m_allowedControls();
            m_allowedControls = Option.Some(parsed_m_allowedControls);
        }

        if (m_allowedObserveTypes is { HasValue: false })                           
        {
            var parsed_m_allowedObserveTypes = Parse_GameSSlotDescription_m_allowedObserveTypes();
            m_allowedObserveTypes = Option.Some(parsed_m_allowedObserveTypes);
        }

        if (m_allowedAIBuilds is { HasValue: false })                           
        {
            var parsed_m_allowedAIBuilds = Parse_GameSSlotDescription_m_allowedAIBuilds();
            m_allowedAIBuilds = Option.Some(parsed_m_allowedAIBuilds);
        }

        return new GameSSlotDescription
        {   
            m_allowedColors = Option.OkOrReturnMissingFieldErr(m_allowedColors),
            m_allowedRaces = Option.OkOrReturnMissingFieldErr(m_allowedRaces),
            m_allowedDifficulty = Option.OkOrReturnMissingFieldErr(m_allowedDifficulty),
            m_allowedControls = Option.OkOrReturnMissingFieldErr(m_allowedControls),
            m_allowedObserveTypes = Option.OkOrReturnMissingFieldErr(m_allowedObserveTypes),
            m_allowedAIBuilds = Option.OkOrReturnMissingFieldErr(m_allowedAIBuilds),
        };
    }

    public GameCAllowedColors Parse_GameSSlotDescription_m_allowedColors()
    {                             
        var m_allowedColors = Parse_GameCAllowedColors();
        return m_allowedColors;
    }

    public CAllowedRaces Parse_GameSSlotDescription_m_allowedRaces()
    {                             
        var m_allowedRaces = Parse_CAllowedRaces();
        return m_allowedRaces;
    }

    public GameCAllowedDifficulty Parse_GameSSlotDescription_m_allowedDifficulty()
    {                             
        var m_allowedDifficulty = Parse_GameCAllowedDifficulty();
        return m_allowedDifficulty;
    }

    public GameCAllowedControls Parse_GameSSlotDescription_m_allowedControls()
    {                             
        var m_allowedControls = Parse_GameCAllowedControls();
        return m_allowedControls;
    }

    public CAllowedObserveTypes Parse_GameSSlotDescription_m_allowedObserveTypes()
    {                             
        var m_allowedObserveTypes = Parse_CAllowedObserveTypes();
        return m_allowedObserveTypes;
    }

    public GameCAllowedAIBuild Parse_GameSSlotDescription_m_allowedAIBuilds()
    {                             
        var m_allowedAIBuilds = Parse_GameCAllowedAIBuild();
        return m_allowedAIBuilds;
    }

    public GameSGameDescription Parse_GameSGameDescription() 
    {
        Option<uint32> m_randomValue = Option.None;
        Option<GameCGameCacheName> m_gameCacheName = Option.None;
        Option<GameSGameOptions> m_gameOptions = Option.None;
        Option<GameEGameSpeed> m_gameSpeed = Option.None;
        Option<GameEGameType> m_gameType = Option.None;
        Option<TUserCount> m_maxUsers = Option.None;
        Option<TUserCount> m_maxObservers = Option.None;
        Option<GameTPlayerCount> m_maxPlayers = Option.None;
        Option<GameTTeamCount> m_maxTeams = Option.None;
        Option<GameTColorCount> m_maxColors = Option.None;
        Option<TRaceCount> m_maxRaces = Option.None;
        Option<GameTControlCount> m_maxControls = Option.None;
        Option<uint8> m_mapSizeX = Option.None;
        Option<uint8> m_mapSizeY = Option.None;
        Option<GameTSyncChecksum> m_mapFileSyncChecksum = Option.None;
        Option<CFilePath> m_mapFileName = Option.None;
        Option<GameCAuthorName> m_mapAuthorName = Option.None;
        Option<GameTSyncChecksum> m_modFileSyncChecksum = Option.None;
        Option<GameSSlotDescriptions> m_slotDescriptions = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        Option<GameTAIBuild> m_defaultAIBuild = Option.None;
        Option<GameCCacheHandles> m_cacheHandles = Option.None;
        Option<bool> m_hasExtensionMod = Option.None;
        Option<bool> m_hasNonBlizzardExtensionMod = Option.None;
        Option<bool> m_isBlizzardMap = Option.None;
        Option<bool> m_isPremadeFFA = Option.None;
        Option<bool> m_isCoopMode = Option.None;
        Option<bool> m_isRealtimeMode = Option.None;
        if (m_randomValue is { HasValue: false })                           
        {
            var parsed_m_randomValue = Parse_GameSGameDescription_m_randomValue();
            m_randomValue = Option.Some(parsed_m_randomValue);
        }

        if (m_gameCacheName is { HasValue: false })                           
        {
            var parsed_m_gameCacheName = Parse_GameSGameDescription_m_gameCacheName();
            m_gameCacheName = Option.Some(parsed_m_gameCacheName);
        }

        if (m_gameOptions is { HasValue: false })                           
        {
            var parsed_m_gameOptions = Parse_GameSGameDescription_m_gameOptions();
            m_gameOptions = Option.Some(parsed_m_gameOptions);
        }

        if (m_gameSpeed is { HasValue: false })                           
        {
            var parsed_m_gameSpeed = Parse_GameSGameDescription_m_gameSpeed();
            m_gameSpeed = Option.Some(parsed_m_gameSpeed);
        }

        if (m_gameType is { HasValue: false })                           
        {
            var parsed_m_gameType = Parse_GameSGameDescription_m_gameType();
            m_gameType = Option.Some(parsed_m_gameType);
        }

        if (m_maxUsers is { HasValue: false })                           
        {
            var parsed_m_maxUsers = Parse_GameSGameDescription_m_maxUsers();
            m_maxUsers = Option.Some(parsed_m_maxUsers);
        }

        if (m_maxObservers is { HasValue: false })                           
        {
            var parsed_m_maxObservers = Parse_GameSGameDescription_m_maxObservers();
            m_maxObservers = Option.Some(parsed_m_maxObservers);
        }

        if (m_maxPlayers is { HasValue: false })                           
        {
            var parsed_m_maxPlayers = Parse_GameSGameDescription_m_maxPlayers();
            m_maxPlayers = Option.Some(parsed_m_maxPlayers);
        }

        if (m_maxTeams is { HasValue: false })                           
        {
            var parsed_m_maxTeams = Parse_GameSGameDescription_m_maxTeams();
            m_maxTeams = Option.Some(parsed_m_maxTeams);
        }

        if (m_maxColors is { HasValue: false })                           
        {
            var parsed_m_maxColors = Parse_GameSGameDescription_m_maxColors();
            m_maxColors = Option.Some(parsed_m_maxColors);
        }

        if (m_maxRaces is { HasValue: false })                           
        {
            var parsed_m_maxRaces = Parse_GameSGameDescription_m_maxRaces();
            m_maxRaces = Option.Some(parsed_m_maxRaces);
        }

        if (m_maxControls is { HasValue: false })                           
        {
            var parsed_m_maxControls = Parse_GameSGameDescription_m_maxControls();
            m_maxControls = Option.Some(parsed_m_maxControls);
        }

        if (m_mapSizeX is { HasValue: false })                           
        {
            var parsed_m_mapSizeX = Parse_GameSGameDescription_m_mapSizeX();
            m_mapSizeX = Option.Some(parsed_m_mapSizeX);
        }

        if (m_mapSizeY is { HasValue: false })                           
        {
            var parsed_m_mapSizeY = Parse_GameSGameDescription_m_mapSizeY();
            m_mapSizeY = Option.Some(parsed_m_mapSizeY);
        }

        if (m_mapFileSyncChecksum is { HasValue: false })                           
        {
            var parsed_m_mapFileSyncChecksum = Parse_GameSGameDescription_m_mapFileSyncChecksum();
            m_mapFileSyncChecksum = Option.Some(parsed_m_mapFileSyncChecksum);
        }

        if (m_mapFileName is { HasValue: false })                           
        {
            var parsed_m_mapFileName = Parse_GameSGameDescription_m_mapFileName();
            m_mapFileName = Option.Some(parsed_m_mapFileName);
        }

        if (m_mapAuthorName is { HasValue: false })                           
        {
            var parsed_m_mapAuthorName = Parse_GameSGameDescription_m_mapAuthorName();
            m_mapAuthorName = Option.Some(parsed_m_mapAuthorName);
        }

        if (m_modFileSyncChecksum is { HasValue: false })                           
        {
            var parsed_m_modFileSyncChecksum = Parse_GameSGameDescription_m_modFileSyncChecksum();
            m_modFileSyncChecksum = Option.Some(parsed_m_modFileSyncChecksum);
        }

        if (m_slotDescriptions is { HasValue: false })                           
        {
            var parsed_m_slotDescriptions = Parse_GameSGameDescription_m_slotDescriptions();
            m_slotDescriptions = Option.Some(parsed_m_slotDescriptions);
        }

        if (m_defaultDifficulty is { HasValue: false })                           
        {
            var parsed_m_defaultDifficulty = Parse_GameSGameDescription_m_defaultDifficulty();
            m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
        }

        if (m_defaultAIBuild is { HasValue: false })                           
        {
            var parsed_m_defaultAIBuild = Parse_GameSGameDescription_m_defaultAIBuild();
            m_defaultAIBuild = Option.Some(parsed_m_defaultAIBuild);
        }

        if (m_cacheHandles is { HasValue: false })                           
        {
            var parsed_m_cacheHandles = Parse_GameSGameDescription_m_cacheHandles();
            m_cacheHandles = Option.Some(parsed_m_cacheHandles);
        }

        if (m_hasExtensionMod is { HasValue: false })                           
        {
            var parsed_m_hasExtensionMod = Parse_GameSGameDescription_m_hasExtensionMod();
            m_hasExtensionMod = Option.Some(parsed_m_hasExtensionMod);
        }

        if (m_hasNonBlizzardExtensionMod is { HasValue: false })                           
        {
            var parsed_m_hasNonBlizzardExtensionMod = Parse_GameSGameDescription_m_hasNonBlizzardExtensionMod();
            m_hasNonBlizzardExtensionMod = Option.Some(parsed_m_hasNonBlizzardExtensionMod);
        }

        if (m_isBlizzardMap is { HasValue: false })                           
        {
            var parsed_m_isBlizzardMap = Parse_GameSGameDescription_m_isBlizzardMap();
            m_isBlizzardMap = Option.Some(parsed_m_isBlizzardMap);
        }

        if (m_isPremadeFFA is { HasValue: false })                           
        {
            var parsed_m_isPremadeFFA = Parse_GameSGameDescription_m_isPremadeFFA();
            m_isPremadeFFA = Option.Some(parsed_m_isPremadeFFA);
        }

        if (m_isCoopMode is { HasValue: false })                           
        {
            var parsed_m_isCoopMode = Parse_GameSGameDescription_m_isCoopMode();
            m_isCoopMode = Option.Some(parsed_m_isCoopMode);
        }

        if (m_isRealtimeMode is { HasValue: false })                           
        {
            var parsed_m_isRealtimeMode = Parse_GameSGameDescription_m_isRealtimeMode();
            m_isRealtimeMode = Option.Some(parsed_m_isRealtimeMode);
        }

        return new GameSGameDescription
        {   
            m_randomValue = Option.OkOrReturnMissingFieldErr(m_randomValue),
            m_gameCacheName = Option.OkOrReturnMissingFieldErr(m_gameCacheName),
            m_gameOptions = Option.OkOrReturnMissingFieldErr(m_gameOptions),
            m_gameSpeed = Option.OkOrReturnMissingFieldErr(m_gameSpeed),
            m_gameType = Option.OkOrReturnMissingFieldErr(m_gameType),
            m_maxUsers = Option.OkOrReturnMissingFieldErr(m_maxUsers),
            m_maxObservers = Option.OkOrReturnMissingFieldErr(m_maxObservers),
            m_maxPlayers = Option.OkOrReturnMissingFieldErr(m_maxPlayers),
            m_maxTeams = Option.OkOrReturnMissingFieldErr(m_maxTeams),
            m_maxColors = Option.OkOrReturnMissingFieldErr(m_maxColors),
            m_maxRaces = Option.OkOrReturnMissingFieldErr(m_maxRaces),
            m_maxControls = Option.OkOrReturnMissingFieldErr(m_maxControls),
            m_mapSizeX = Option.OkOrReturnMissingFieldErr(m_mapSizeX),
            m_mapSizeY = Option.OkOrReturnMissingFieldErr(m_mapSizeY),
            m_mapFileSyncChecksum = Option.OkOrReturnMissingFieldErr(m_mapFileSyncChecksum),
            m_mapFileName = Option.OkOrReturnMissingFieldErr(m_mapFileName),
            m_mapAuthorName = Option.OkOrReturnMissingFieldErr(m_mapAuthorName),
            m_modFileSyncChecksum = Option.OkOrReturnMissingFieldErr(m_modFileSyncChecksum),
            m_slotDescriptions = Option.OkOrReturnMissingFieldErr(m_slotDescriptions),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
            m_defaultAIBuild = Option.OkOrReturnMissingFieldErr(m_defaultAIBuild),
            m_cacheHandles = Option.OkOrReturnMissingFieldErr(m_cacheHandles),
            m_hasExtensionMod = Option.OkOrReturnMissingFieldErr(m_hasExtensionMod),
            m_hasNonBlizzardExtensionMod = Option.OkOrReturnMissingFieldErr(m_hasNonBlizzardExtensionMod),
            m_isBlizzardMap = Option.OkOrReturnMissingFieldErr(m_isBlizzardMap),
            m_isPremadeFFA = Option.OkOrReturnMissingFieldErr(m_isPremadeFFA),
            m_isCoopMode = Option.OkOrReturnMissingFieldErr(m_isCoopMode),
            m_isRealtimeMode = Option.OkOrReturnMissingFieldErr(m_isRealtimeMode),
        };
    }

    public uint32 Parse_GameSGameDescription_m_randomValue()
    {                             
        var m_randomValue = Parse_uint32();
        return m_randomValue;
    }

    public GameCGameCacheName Parse_GameSGameDescription_m_gameCacheName()
    {                             
        var m_gameCacheName = Parse_GameCGameCacheName();
        return m_gameCacheName;
    }

    public GameSGameOptions Parse_GameSGameDescription_m_gameOptions()
    {                             
        var m_gameOptions = Parse_GameSGameOptions();
        return m_gameOptions;
    }

    public GameEGameSpeed Parse_GameSGameDescription_m_gameSpeed()
    {                             
        var m_gameSpeed = Parse_GameEGameSpeed();
        return m_gameSpeed;
    }

    public GameEGameType Parse_GameSGameDescription_m_gameType()
    {                             
        var m_gameType = Parse_GameEGameType();
        return m_gameType;
    }

    public TUserCount Parse_GameSGameDescription_m_maxUsers()
    {                             
        var m_maxUsers = Parse_TUserCount();
        return m_maxUsers;
    }

    public TUserCount Parse_GameSGameDescription_m_maxObservers()
    {                             
        var m_maxObservers = Parse_TUserCount();
        return m_maxObservers;
    }

    public GameTPlayerCount Parse_GameSGameDescription_m_maxPlayers()
    {                             
        var m_maxPlayers = Parse_GameTPlayerCount();
        return m_maxPlayers;
    }

    public GameTTeamCount Parse_GameSGameDescription_m_maxTeams()
    {                             
        var m_maxTeams = Parse_GameTTeamCount();
        return m_maxTeams;
    }

    public GameTColorCount Parse_GameSGameDescription_m_maxColors()
    {                             
        var m_maxColors = Parse_GameTColorCount();
        return m_maxColors;
    }

    public TRaceCount Parse_GameSGameDescription_m_maxRaces()
    {                             
        var m_maxRaces = Parse_TRaceCount();
        return m_maxRaces;
    }

    public GameTControlCount Parse_GameSGameDescription_m_maxControls()
    {                             
        var m_maxControls = Parse_GameTControlCount();
        return m_maxControls;
    }

    public uint8 Parse_GameSGameDescription_m_mapSizeX()
    {                             
        var m_mapSizeX = Parse_uint8();
        return m_mapSizeX;
    }

    public uint8 Parse_GameSGameDescription_m_mapSizeY()
    {                             
        var m_mapSizeY = Parse_uint8();
        return m_mapSizeY;
    }

    public GameTSyncChecksum Parse_GameSGameDescription_m_mapFileSyncChecksum()
    {                             
        var m_mapFileSyncChecksum = Parse_GameTSyncChecksum();
        return m_mapFileSyncChecksum;
    }

    public CFilePath Parse_GameSGameDescription_m_mapFileName()
    {                             
        var m_mapFileName = Parse_CFilePath();
        return m_mapFileName;
    }

    public GameCAuthorName Parse_GameSGameDescription_m_mapAuthorName()
    {                             
        var m_mapAuthorName = Parse_GameCAuthorName();
        return m_mapAuthorName;
    }

    public GameTSyncChecksum Parse_GameSGameDescription_m_modFileSyncChecksum()
    {                             
        var m_modFileSyncChecksum = Parse_GameTSyncChecksum();
        return m_modFileSyncChecksum;
    }

    public GameSSlotDescriptions Parse_GameSGameDescription_m_slotDescriptions()
    {                             
        var m_slotDescriptions = Parse_GameSSlotDescriptions();
        return m_slotDescriptions;
    }

    public GameTDifficulty Parse_GameSGameDescription_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = Parse_GameTDifficulty();
        return m_defaultDifficulty;
    }

    public GameTAIBuild Parse_GameSGameDescription_m_defaultAIBuild()
    {                             
        var m_defaultAIBuild = Parse_GameTAIBuild();
        return m_defaultAIBuild;
    }

    public GameCCacheHandles Parse_GameSGameDescription_m_cacheHandles()
    {                             
        var m_cacheHandles = Parse_GameCCacheHandles();
        return m_cacheHandles;
    }

    public bool Parse_GameSGameDescription_m_hasExtensionMod()
    {                             
        var m_hasExtensionMod = parse_bool();
        return m_hasExtensionMod;
    }

    public bool Parse_GameSGameDescription_m_hasNonBlizzardExtensionMod()
    {                             
        var m_hasNonBlizzardExtensionMod = parse_bool();
        return m_hasNonBlizzardExtensionMod;
    }

    public bool Parse_GameSGameDescription_m_isBlizzardMap()
    {                             
        var m_isBlizzardMap = parse_bool();
        return m_isBlizzardMap;
    }

    public bool Parse_GameSGameDescription_m_isPremadeFFA()
    {                             
        var m_isPremadeFFA = parse_bool();
        return m_isPremadeFFA;
    }

    public bool Parse_GameSGameDescription_m_isCoopMode()
    {                             
        var m_isCoopMode = parse_bool();
        return m_isCoopMode;
    }

    public bool Parse_GameSGameDescription_m_isRealtimeMode()
    {                             
        var m_isRealtimeMode = parse_bool();
        return m_isRealtimeMode;
    }

    public GameCRewardOverride Parse_GameCRewardOverride() 
    {
        Option<uint32> m_key = Option.None;
        Option<GameCRewardArray> m_rewards = Option.None;
        if (m_key is { HasValue: false })                           
        {
            var parsed_m_key = Parse_GameCRewardOverride_m_key();
            m_key = Option.Some(parsed_m_key);
        }

        if (m_rewards is { HasValue: false })                           
        {
            var parsed_m_rewards = Parse_GameCRewardOverride_m_rewards();
            m_rewards = Option.Some(parsed_m_rewards);
        }

        return new GameCRewardOverride
        {   
            m_key = Option.OkOrReturnMissingFieldErr(m_key),
            m_rewards = Option.OkOrReturnMissingFieldErr(m_rewards),
        };
    }

    public uint32 Parse_GameCRewardOverride_m_key()
    {                             
        var m_key = Parse_uint32();
        return m_key;
    }

    public GameCRewardArray Parse_GameCRewardOverride_m_rewards()
    {                             
        var m_rewards = Parse_GameCRewardArray();
        return m_rewards;
    }

    public GameSLobbySlot Parse_GameSLobbySlot() 
    {
        Option<GameTControlId> m_control = Option.None;
        var m_userId = Option.Some<Option<TUserId>>(Option.None);
        Option<GameTTeamId> m_teamId = Option.None;
        Option<GameTColorPreference> m_colorPref = Option.None;
        Option<TRacePreference> m_racePref = Option.None;
        Option<GameTDifficulty> m_difficulty = Option.None;
        Option<GameTAIBuild> m_aiBuild = Option.None;
        Option<GameTHandicap> m_handicap = Option.None;
        Option<EObserve> m_observe = Option.None;
        Option<GameTPlayerLogoIndex> m_logoIndex = Option.None;
        Option<CHeroHandle> m_hero = Option.None;
        Option<CSkinHandle> m_skin = Option.None;
        Option<CMountHandle> m_mount = Option.None;
        Option<GameCArtifactArray> m_artifacts = Option.None;
        var m_workingSetSlotId = Option.Some<Option<uint8>>(Option.None);
        Option<GameCRewardArray> m_rewards = Option.None;
        Option<CToonHandle> m_toonHandle = Option.None;
        Option<GameCLicenseArray> m_licenses = Option.None;
        var m_tandemLeaderId = Option.Some<Option<TUserId>>(Option.None);
        Option<CCommanderHandle> m_commander = Option.None;
        Option<uint32> m_commanderLevel = Option.None;
        Option<bool> m_hasSilencePenalty = Option.None;
        var m_tandemId = Option.Some<Option<TUserId>>(Option.None);
        Option<uint32> m_commanderMasteryLevel = Option.None;
        Option<GameCCommanderMasteryTalentArray> m_commanderMasteryTalents = Option.None;
        Option<GameCRewardOverrideArray> m_rewardOverrides = Option.None;
        if (m_control is { HasValue: false })                           
        {
            var parsed_m_control = Parse_GameSLobbySlot_m_control();
            m_control = Option.Some(parsed_m_control);
        }

        if (m_userId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_userId = Parse_GameSLobbySlot_m_userId();
            m_userId = Option.Some(parsed_m_userId);
        }

        if (m_teamId is { HasValue: false })                           
        {
            var parsed_m_teamId = Parse_GameSLobbySlot_m_teamId();
            m_teamId = Option.Some(parsed_m_teamId);
        }

        if (m_colorPref is { HasValue: false })                           
        {
            var parsed_m_colorPref = Parse_GameSLobbySlot_m_colorPref();
            m_colorPref = Option.Some(parsed_m_colorPref);
        }

        if (m_racePref is { HasValue: false })                           
        {
            var parsed_m_racePref = Parse_GameSLobbySlot_m_racePref();
            m_racePref = Option.Some(parsed_m_racePref);
        }

        if (m_difficulty is { HasValue: false })                           
        {
            var parsed_m_difficulty = Parse_GameSLobbySlot_m_difficulty();
            m_difficulty = Option.Some(parsed_m_difficulty);
        }

        if (m_aiBuild is { HasValue: false })                           
        {
            var parsed_m_aiBuild = Parse_GameSLobbySlot_m_aiBuild();
            m_aiBuild = Option.Some(parsed_m_aiBuild);
        }

        if (m_handicap is { HasValue: false })                           
        {
            var parsed_m_handicap = Parse_GameSLobbySlot_m_handicap();
            m_handicap = Option.Some(parsed_m_handicap);
        }

        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_GameSLobbySlot_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        if (m_logoIndex is { HasValue: false })                           
        {
            var parsed_m_logoIndex = Parse_GameSLobbySlot_m_logoIndex();
            m_logoIndex = Option.Some(parsed_m_logoIndex);
        }

        if (m_hero is { HasValue: false })                           
        {
            var parsed_m_hero = Parse_GameSLobbySlot_m_hero();
            m_hero = Option.Some(parsed_m_hero);
        }

        if (m_skin is { HasValue: false })                           
        {
            var parsed_m_skin = Parse_GameSLobbySlot_m_skin();
            m_skin = Option.Some(parsed_m_skin);
        }

        if (m_mount is { HasValue: false })                           
        {
            var parsed_m_mount = Parse_GameSLobbySlot_m_mount();
            m_mount = Option.Some(parsed_m_mount);
        }

        if (m_artifacts is { HasValue: false })                           
        {
            var parsed_m_artifacts = Parse_GameSLobbySlot_m_artifacts();
            m_artifacts = Option.Some(parsed_m_artifacts);
        }

        if (m_workingSetSlotId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_workingSetSlotId = Parse_GameSLobbySlot_m_workingSetSlotId();
            m_workingSetSlotId = Option.Some(parsed_m_workingSetSlotId);
        }

        if (m_rewards is { HasValue: false })                           
        {
            var parsed_m_rewards = Parse_GameSLobbySlot_m_rewards();
            m_rewards = Option.Some(parsed_m_rewards);
        }

        if (m_toonHandle is { HasValue: false })                           
        {
            var parsed_m_toonHandle = Parse_GameSLobbySlot_m_toonHandle();
            m_toonHandle = Option.Some(parsed_m_toonHandle);
        }

        if (m_licenses is { HasValue: false })                           
        {
            var parsed_m_licenses = Parse_GameSLobbySlot_m_licenses();
            m_licenses = Option.Some(parsed_m_licenses);
        }

        if (m_tandemLeaderId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_tandemLeaderId = Parse_GameSLobbySlot_m_tandemLeaderId();
            m_tandemLeaderId = Option.Some(parsed_m_tandemLeaderId);
        }

        if (m_commander is { HasValue: false })                           
        {
            var parsed_m_commander = Parse_GameSLobbySlot_m_commander();
            m_commander = Option.Some(parsed_m_commander);
        }

        if (m_commanderLevel is { HasValue: false })                           
        {
            var parsed_m_commanderLevel = Parse_GameSLobbySlot_m_commanderLevel();
            m_commanderLevel = Option.Some(parsed_m_commanderLevel);
        }

        if (m_hasSilencePenalty is { HasValue: false })                           
        {
            var parsed_m_hasSilencePenalty = Parse_GameSLobbySlot_m_hasSilencePenalty();
            m_hasSilencePenalty = Option.Some(parsed_m_hasSilencePenalty);
        }

        if (m_tandemId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_tandemId = Parse_GameSLobbySlot_m_tandemId();
            m_tandemId = Option.Some(parsed_m_tandemId);
        }

        if (m_commanderMasteryLevel is { HasValue: false })                           
        {
            var parsed_m_commanderMasteryLevel = Parse_GameSLobbySlot_m_commanderMasteryLevel();
            m_commanderMasteryLevel = Option.Some(parsed_m_commanderMasteryLevel);
        }

        if (m_commanderMasteryTalents is { HasValue: false })                           
        {
            var parsed_m_commanderMasteryTalents = Parse_GameSLobbySlot_m_commanderMasteryTalents();
            m_commanderMasteryTalents = Option.Some(parsed_m_commanderMasteryTalents);
        }

        if (m_rewardOverrides is { HasValue: false })                           
        {
            var parsed_m_rewardOverrides = Parse_GameSLobbySlot_m_rewardOverrides();
            m_rewardOverrides = Option.Some(parsed_m_rewardOverrides);
        }

        return new GameSLobbySlot
        {   
            m_control = Option.OkOrReturnMissingFieldErr(m_control),
            m_userId = Option.OkOrReturnMissingFieldErr(m_userId),
            m_teamId = Option.OkOrReturnMissingFieldErr(m_teamId),
            m_colorPref = Option.OkOrReturnMissingFieldErr(m_colorPref),
            m_racePref = Option.OkOrReturnMissingFieldErr(m_racePref),
            m_difficulty = Option.OkOrReturnMissingFieldErr(m_difficulty),
            m_aiBuild = Option.OkOrReturnMissingFieldErr(m_aiBuild),
            m_handicap = Option.OkOrReturnMissingFieldErr(m_handicap),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
            m_logoIndex = Option.OkOrReturnMissingFieldErr(m_logoIndex),
            m_hero = Option.OkOrReturnMissingFieldErr(m_hero),
            m_skin = Option.OkOrReturnMissingFieldErr(m_skin),
            m_mount = Option.OkOrReturnMissingFieldErr(m_mount),
            m_artifacts = Option.OkOrReturnMissingFieldErr(m_artifacts),
            m_workingSetSlotId = Option.OkOrReturnMissingFieldErr(m_workingSetSlotId),
            m_rewards = Option.OkOrReturnMissingFieldErr(m_rewards),
            m_toonHandle = Option.OkOrReturnMissingFieldErr(m_toonHandle),
            m_licenses = Option.OkOrReturnMissingFieldErr(m_licenses),
            m_tandemLeaderId = Option.OkOrReturnMissingFieldErr(m_tandemLeaderId),
            m_commander = Option.OkOrReturnMissingFieldErr(m_commander),
            m_commanderLevel = Option.OkOrReturnMissingFieldErr(m_commanderLevel),
            m_hasSilencePenalty = Option.OkOrReturnMissingFieldErr(m_hasSilencePenalty),
            m_tandemId = Option.OkOrReturnMissingFieldErr(m_tandemId),
            m_commanderMasteryLevel = Option.OkOrReturnMissingFieldErr(m_commanderMasteryLevel),
            m_commanderMasteryTalents = Option.OkOrReturnMissingFieldErr(m_commanderMasteryTalents),
            m_rewardOverrides = Option.OkOrReturnMissingFieldErr(m_rewardOverrides),
        };
    }

    public GameTControlId Parse_GameSLobbySlot_m_control()
    {                             
        var m_control = Parse_GameTControlId();
        return m_control;
    }

    public Option<TUserId> Parse_GameSLobbySlot_m_userId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TUserId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameTTeamId Parse_GameSLobbySlot_m_teamId()
    {                             
        var m_teamId = Parse_GameTTeamId();
        return m_teamId;
    }

    public GameTColorPreference Parse_GameSLobbySlot_m_colorPref()
    {                             
        var m_colorPref = Parse_GameTColorPreference();
        return m_colorPref;
    }

    public TRacePreference Parse_GameSLobbySlot_m_racePref()
    {                             
        var m_racePref = Parse_TRacePreference();
        return m_racePref;
    }

    public GameTDifficulty Parse_GameSLobbySlot_m_difficulty()
    {                             
        var m_difficulty = Parse_GameTDifficulty();
        return m_difficulty;
    }

    public GameTAIBuild Parse_GameSLobbySlot_m_aiBuild()
    {                             
        var m_aiBuild = Parse_GameTAIBuild();
        return m_aiBuild;
    }

    public GameTHandicap Parse_GameSLobbySlot_m_handicap()
    {                             
        var m_handicap = Parse_GameTHandicap();
        return m_handicap;
    }

    public EObserve Parse_GameSLobbySlot_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }

    public GameTPlayerLogoIndex Parse_GameSLobbySlot_m_logoIndex()
    {                             
        var m_logoIndex = Parse_GameTPlayerLogoIndex();
        return m_logoIndex;
    }

    public CHeroHandle Parse_GameSLobbySlot_m_hero()
    {                             
        var m_hero = Parse_CHeroHandle();
        return m_hero;
    }

    public CSkinHandle Parse_GameSLobbySlot_m_skin()
    {                             
        var m_skin = Parse_CSkinHandle();
        return m_skin;
    }

    public CMountHandle Parse_GameSLobbySlot_m_mount()
    {                             
        var m_mount = Parse_CMountHandle();
        return m_mount;
    }

    public GameCArtifactArray Parse_GameSLobbySlot_m_artifacts()
    {                             
        var m_artifacts = Parse_GameCArtifactArray();
        return m_artifacts;
    }

    public Option<uint8> Parse_GameSLobbySlot_m_workingSetSlotId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameCRewardArray Parse_GameSLobbySlot_m_rewards()
    {                             
        var m_rewards = Parse_GameCRewardArray();
        return m_rewards;
    }

    public CToonHandle Parse_GameSLobbySlot_m_toonHandle()
    {                             
        var m_toonHandle = Parse_CToonHandle();
        return m_toonHandle;
    }

    public GameCLicenseArray Parse_GameSLobbySlot_m_licenses()
    {                             
        var m_licenses = Parse_GameCLicenseArray();
        return m_licenses;
    }

    public Option<TUserId> Parse_GameSLobbySlot_m_tandemLeaderId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TUserId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public CCommanderHandle Parse_GameSLobbySlot_m_commander()
    {                             
        var m_commander = Parse_CCommanderHandle();
        return m_commander;
    }

    public uint32 Parse_GameSLobbySlot_m_commanderLevel()
    {                             
        var m_commanderLevel = Parse_uint32();
        return m_commanderLevel;
    }

    public bool Parse_GameSLobbySlot_m_hasSilencePenalty()
    {                             
        var m_hasSilencePenalty = parse_bool();
        return m_hasSilencePenalty;
    }

    public Option<TUserId> Parse_GameSLobbySlot_m_tandemId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TUserId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public uint32 Parse_GameSLobbySlot_m_commanderMasteryLevel()
    {                             
        var m_commanderMasteryLevel = Parse_uint32();
        return m_commanderMasteryLevel;
    }

    public GameCCommanderMasteryTalentArray Parse_GameSLobbySlot_m_commanderMasteryTalents()
    {                             
        var m_commanderMasteryTalents = Parse_GameCCommanderMasteryTalentArray();
        return m_commanderMasteryTalents;
    }

    public GameCRewardOverrideArray Parse_GameSLobbySlot_m_rewardOverrides()
    {                             
        var m_rewardOverrides = Parse_GameCRewardOverrideArray();
        return m_rewardOverrides;
    }

    public GameSLobbyState Parse_GameSLobbyState() 
    {
        Option<GameEPhase> m_phase = Option.None;
        Option<TUserCount> m_maxUsers = Option.None;
        Option<TUserCount> m_maxObservers = Option.None;
        Option<GameCLobbySlotArray> m_slots = Option.None;
        Option<uint32> m_randomSeed = Option.None;
        var m_hostUserId = Option.Some<Option<TUserId>>(Option.None);
        Option<bool> m_isSinglePlayer = Option.None;
        Option<uint8> m_pickedMapTag = Option.None;
        Option<uint32> m_gameDuration = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        Option<GameTAIBuild> m_defaultAIBuild = Option.None;
        if (m_phase is { HasValue: false })                           
        {
            var parsed_m_phase = Parse_GameSLobbyState_m_phase();
            m_phase = Option.Some(parsed_m_phase);
        }

        if (m_maxUsers is { HasValue: false })                           
        {
            var parsed_m_maxUsers = Parse_GameSLobbyState_m_maxUsers();
            m_maxUsers = Option.Some(parsed_m_maxUsers);
        }

        if (m_maxObservers is { HasValue: false })                           
        {
            var parsed_m_maxObservers = Parse_GameSLobbyState_m_maxObservers();
            m_maxObservers = Option.Some(parsed_m_maxObservers);
        }

        if (m_slots is { HasValue: false })                           
        {
            var parsed_m_slots = Parse_GameSLobbyState_m_slots();
            m_slots = Option.Some(parsed_m_slots);
        }

        if (m_randomSeed is { HasValue: false })                           
        {
            var parsed_m_randomSeed = Parse_GameSLobbyState_m_randomSeed();
            m_randomSeed = Option.Some(parsed_m_randomSeed);
        }

        if (m_hostUserId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_hostUserId = Parse_GameSLobbyState_m_hostUserId();
            m_hostUserId = Option.Some(parsed_m_hostUserId);
        }

        if (m_isSinglePlayer is { HasValue: false })                           
        {
            var parsed_m_isSinglePlayer = Parse_GameSLobbyState_m_isSinglePlayer();
            m_isSinglePlayer = Option.Some(parsed_m_isSinglePlayer);
        }

        if (m_pickedMapTag is { HasValue: false })                           
        {
            var parsed_m_pickedMapTag = Parse_GameSLobbyState_m_pickedMapTag();
            m_pickedMapTag = Option.Some(parsed_m_pickedMapTag);
        }

        if (m_gameDuration is { HasValue: false })                           
        {
            var parsed_m_gameDuration = Parse_GameSLobbyState_m_gameDuration();
            m_gameDuration = Option.Some(parsed_m_gameDuration);
        }

        if (m_defaultDifficulty is { HasValue: false })                           
        {
            var parsed_m_defaultDifficulty = Parse_GameSLobbyState_m_defaultDifficulty();
            m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
        }

        if (m_defaultAIBuild is { HasValue: false })                           
        {
            var parsed_m_defaultAIBuild = Parse_GameSLobbyState_m_defaultAIBuild();
            m_defaultAIBuild = Option.Some(parsed_m_defaultAIBuild);
        }

        return new GameSLobbyState
        {   
            m_phase = Option.OkOrReturnMissingFieldErr(m_phase),
            m_maxUsers = Option.OkOrReturnMissingFieldErr(m_maxUsers),
            m_maxObservers = Option.OkOrReturnMissingFieldErr(m_maxObservers),
            m_slots = Option.OkOrReturnMissingFieldErr(m_slots),
            m_randomSeed = Option.OkOrReturnMissingFieldErr(m_randomSeed),
            m_hostUserId = Option.OkOrReturnMissingFieldErr(m_hostUserId),
            m_isSinglePlayer = Option.OkOrReturnMissingFieldErr(m_isSinglePlayer),
            m_pickedMapTag = Option.OkOrReturnMissingFieldErr(m_pickedMapTag),
            m_gameDuration = Option.OkOrReturnMissingFieldErr(m_gameDuration),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
            m_defaultAIBuild = Option.OkOrReturnMissingFieldErr(m_defaultAIBuild),
        };
    }

    public GameEPhase Parse_GameSLobbyState_m_phase()
    {                             
        var m_phase = Parse_GameEPhase();
        return m_phase;
    }

    public TUserCount Parse_GameSLobbyState_m_maxUsers()
    {                             
        var m_maxUsers = Parse_TUserCount();
        return m_maxUsers;
    }

    public TUserCount Parse_GameSLobbyState_m_maxObservers()
    {                             
        var m_maxObservers = Parse_TUserCount();
        return m_maxObservers;
    }

    public GameCLobbySlotArray Parse_GameSLobbyState_m_slots()
    {                             
        var m_slots = Parse_GameCLobbySlotArray();
        return m_slots;
    }

    public uint32 Parse_GameSLobbyState_m_randomSeed()
    {                             
        var m_randomSeed = Parse_uint32();
        return m_randomSeed;
    }

    public Option<TUserId> Parse_GameSLobbyState_m_hostUserId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TUserId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public bool Parse_GameSLobbyState_m_isSinglePlayer()
    {                             
        var m_isSinglePlayer = parse_bool();
        return m_isSinglePlayer;
    }

    public uint8 Parse_GameSLobbyState_m_pickedMapTag()
    {                             
        var m_pickedMapTag = Parse_uint8();
        return m_pickedMapTag;
    }

    public uint32 Parse_GameSLobbyState_m_gameDuration()
    {                             
        var m_gameDuration = Parse_uint32();
        return m_gameDuration;
    }

    public GameTDifficulty Parse_GameSLobbyState_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = Parse_GameTDifficulty();
        return m_defaultDifficulty;
    }

    public GameTAIBuild Parse_GameSLobbyState_m_defaultAIBuild()
    {                             
        var m_defaultAIBuild = Parse_GameTAIBuild();
        return m_defaultAIBuild;
    }

    public GameSLobbySyncState Parse_GameSLobbySyncState() 
    {
        Option<CUserInitialDataArray> m_userInitialData = Option.None;
        Option<GameSGameDescription> m_gameDescription = Option.None;
        Option<GameSLobbyState> m_lobbyState = Option.None;
        if (m_userInitialData is { HasValue: false })                           
        {
            var parsed_m_userInitialData = Parse_GameSLobbySyncState_m_userInitialData();
            m_userInitialData = Option.Some(parsed_m_userInitialData);
        }

        if (m_gameDescription is { HasValue: false })                           
        {
            var parsed_m_gameDescription = Parse_GameSLobbySyncState_m_gameDescription();
            m_gameDescription = Option.Some(parsed_m_gameDescription);
        }

        if (m_lobbyState is { HasValue: false })                           
        {
            var parsed_m_lobbyState = Parse_GameSLobbySyncState_m_lobbyState();
            m_lobbyState = Option.Some(parsed_m_lobbyState);
        }

        return new GameSLobbySyncState
        {   
            m_userInitialData = Option.OkOrReturnMissingFieldErr(m_userInitialData),
            m_gameDescription = Option.OkOrReturnMissingFieldErr(m_gameDescription),
            m_lobbyState = Option.OkOrReturnMissingFieldErr(m_lobbyState),
        };
    }

    public CUserInitialDataArray Parse_GameSLobbySyncState_m_userInitialData()
    {                             
        var m_userInitialData = Parse_CUserInitialDataArray();
        return m_userInitialData;
    }

    public GameSGameDescription Parse_GameSLobbySyncState_m_gameDescription()
    {                             
        var m_gameDescription = Parse_GameSGameDescription();
        return m_gameDescription;
    }

    public GameSLobbyState Parse_GameSLobbySyncState_m_lobbyState()
    {                             
        var m_lobbyState = Parse_GameSLobbyState();
        return m_lobbyState;
    }

    public GameSChatMessage Parse_GameSChatMessage() 
    {
        Option<GameEMessageRecipient> m_recipient = Option.None;
        Option<GameCChatString> m_string = Option.None;
        if (m_recipient is { HasValue: false })                           
        {
            var parsed_m_recipient = Parse_GameSChatMessage_m_recipient();
            m_recipient = Option.Some(parsed_m_recipient);
        }

        if (m_string is { HasValue: false })                           
        {
            var parsed_m_string = Parse_GameSChatMessage_m_string();
            m_string = Option.Some(parsed_m_string);
        }

        return new GameSChatMessage
        {   
            m_recipient = Option.OkOrReturnMissingFieldErr(m_recipient),
            m_string = Option.OkOrReturnMissingFieldErr(m_string),
        };
    }

    public GameEMessageRecipient Parse_GameSChatMessage_m_recipient()
    {                             
        var m_recipient = Parse_GameEMessageRecipient();
        return m_recipient;
    }

    public GameCChatString Parse_GameSChatMessage_m_string()
    {                             
        var m_string = Parse_GameCChatString();
        return m_string;
    }

    public GameSPingMessage Parse_GameSPingMessage() 
    {
        Option<GameEMessageRecipient> m_recipient = Option.None;
        Option<GameSPoint> m_point = Option.None;
        if (m_recipient is { HasValue: false })                           
        {
            var parsed_m_recipient = Parse_GameSPingMessage_m_recipient();
            m_recipient = Option.Some(parsed_m_recipient);
        }

        if (m_point is { HasValue: false })                           
        {
            var parsed_m_point = Parse_GameSPingMessage_m_point();
            m_point = Option.Some(parsed_m_point);
        }

        return new GameSPingMessage
        {   
            m_recipient = Option.OkOrReturnMissingFieldErr(m_recipient),
            m_point = Option.OkOrReturnMissingFieldErr(m_point),
        };
    }

    public GameEMessageRecipient Parse_GameSPingMessage_m_recipient()
    {                             
        var m_recipient = Parse_GameEMessageRecipient();
        return m_recipient;
    }

    public GameSPoint Parse_GameSPingMessage_m_point()
    {                             
        var m_point = Parse_GameSPoint();
        return m_point;
    }

    public GameSLoadingProgressMessage Parse_GameSLoadingProgressMessage() 
    {
        Option<int32> m_progress = Option.None;
        if (m_progress is { HasValue: false })                           
        {
            var parsed_m_progress = Parse_GameSLoadingProgressMessage_m_progress();
            m_progress = Option.Some(parsed_m_progress);
        }

        return new GameSLoadingProgressMessage
        {   
            m_progress = Option.OkOrReturnMissingFieldErr(m_progress),
        };
    }

    public int32 Parse_GameSLoadingProgressMessage_m_progress()
    {                             
        var m_progress = Parse_int32();
        return m_progress;
    }

    public GameSServerPingMessage Parse_GameSServerPingMessage() 
    {
        return new GameSServerPingMessage
        {   
        };
    }

    public GameSReconnectNotifyMessage Parse_GameSReconnectNotifyMessage() 
    {
        Option<EReconnectStatus> m_status = Option.None;
        if (m_status is { HasValue: false })                           
        {
            var parsed_m_status = Parse_GameSReconnectNotifyMessage_m_status();
            m_status = Option.Some(parsed_m_status);
        }

        return new GameSReconnectNotifyMessage
        {   
            m_status = Option.OkOrReturnMissingFieldErr(m_status),
        };
    }

    public EReconnectStatus Parse_GameSReconnectNotifyMessage_m_status()
    {                             
        var m_status = Parse_EReconnectStatus();
        return m_status;
    }

    public GameSSelectionDeltaSubgroup Parse_GameSSelectionDeltaSubgroup() 
    {
        Option<GameTUnitLink> m_unitLink = Option.None;
        Option<GameTSubgroupPriority> m_subgroupPriority = Option.None;
        Option<GameTSubgroupPriority> m_intraSubgroupPriority = Option.None;
        Option<GameTSelectionCount> m_count = Option.None;
        if (m_unitLink is { HasValue: false })                           
        {
            var parsed_m_unitLink = Parse_GameSSelectionDeltaSubgroup_m_unitLink();
            m_unitLink = Option.Some(parsed_m_unitLink);
        }

        if (m_subgroupPriority is { HasValue: false })                           
        {
            var parsed_m_subgroupPriority = Parse_GameSSelectionDeltaSubgroup_m_subgroupPriority();
            m_subgroupPriority = Option.Some(parsed_m_subgroupPriority);
        }

        if (m_intraSubgroupPriority is { HasValue: false })                           
        {
            var parsed_m_intraSubgroupPriority = Parse_GameSSelectionDeltaSubgroup_m_intraSubgroupPriority();
            m_intraSubgroupPriority = Option.Some(parsed_m_intraSubgroupPriority);
        }

        if (m_count is { HasValue: false })                           
        {
            var parsed_m_count = Parse_GameSSelectionDeltaSubgroup_m_count();
            m_count = Option.Some(parsed_m_count);
        }

        return new GameSSelectionDeltaSubgroup
        {   
            m_unitLink = Option.OkOrReturnMissingFieldErr(m_unitLink),
            m_subgroupPriority = Option.OkOrReturnMissingFieldErr(m_subgroupPriority),
            m_intraSubgroupPriority = Option.OkOrReturnMissingFieldErr(m_intraSubgroupPriority),
            m_count = Option.OkOrReturnMissingFieldErr(m_count),
        };
    }

    public GameTUnitLink Parse_GameSSelectionDeltaSubgroup_m_unitLink()
    {                             
        var m_unitLink = Parse_GameTUnitLink();
        return m_unitLink;
    }

    public GameTSubgroupPriority Parse_GameSSelectionDeltaSubgroup_m_subgroupPriority()
    {                             
        var m_subgroupPriority = Parse_GameTSubgroupPriority();
        return m_subgroupPriority;
    }

    public GameTSubgroupPriority Parse_GameSSelectionDeltaSubgroup_m_intraSubgroupPriority()
    {                             
        var m_intraSubgroupPriority = Parse_GameTSubgroupPriority();
        return m_intraSubgroupPriority;
    }

    public GameTSelectionCount Parse_GameSSelectionDeltaSubgroup_m_count()
    {                             
        var m_count = Parse_GameTSelectionCount();
        return m_count;
    }

    public GameSSelectionDelta Parse_GameSSelectionDelta() 
    {
        Option<GameTSubgroupIndex> m_subgroupIndex = Option.None;
        Option<GameSSelectionMask> m_removeMask = Option.None;
        Option<List<GameSSelectionDeltaSubgroup>> m_addSubgroups = Option.None;
        Option<List<GameTUnitTag>> m_addUnitTags = Option.None;
        if (m_subgroupIndex is { HasValue: false })                           
        {
            var parsed_m_subgroupIndex = Parse_GameSSelectionDelta_m_subgroupIndex();
            m_subgroupIndex = Option.Some(parsed_m_subgroupIndex);
        }

        if (m_removeMask is { HasValue: false })                           
        {
            var parsed_m_removeMask = Parse_GameSSelectionDelta_m_removeMask();
            m_removeMask = Option.Some(parsed_m_removeMask);
        }

        if (m_addSubgroups is { HasValue: false })                           
        {
            var parsed_m_addSubgroups = Parse_GameSSelectionDelta_m_addSubgroups();
            m_addSubgroups = Option.Some(parsed_m_addSubgroups);
        }

        if (m_addUnitTags is { HasValue: false })                           
        {
            var parsed_m_addUnitTags = Parse_GameSSelectionDelta_m_addUnitTags();
            m_addUnitTags = Option.Some(parsed_m_addUnitTags);
        }

        return new GameSSelectionDelta
        {   
            m_subgroupIndex = Option.OkOrReturnMissingFieldErr(m_subgroupIndex),
            m_removeMask = Option.OkOrReturnMissingFieldErr(m_removeMask),
            m_addSubgroups = Option.OkOrReturnMissingFieldErr(m_addSubgroups),
            m_addUnitTags = Option.OkOrReturnMissingFieldErr(m_addUnitTags),
        };
    }

    public GameTSubgroupIndex Parse_GameSSelectionDelta_m_subgroupIndex()
    {                             
        var m_subgroupIndex = Parse_GameTSubgroupIndex();
        return m_subgroupIndex;
    }

    public GameSSelectionMask Parse_GameSSelectionDelta_m_removeMask()
    {                             
        var m_removeMask = Parse_GameSSelectionMask();
        return m_removeMask;
    }

    public List<GameSSelectionDeltaSubgroup> Parse_GameSSelectionDelta_m_addSubgroups()
    {                             
        var arrayLength = take_n_bits_into_i64(9);
        var array = new List<GameSSelectionDeltaSubgroup>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameSSelectionDeltaSubgroup();
            array.Add(data);
        }
        return array;
    }

    public List<GameTUnitTag> Parse_GameSSelectionDelta_m_addUnitTags()
    {                             
        var arrayLength = take_n_bits_into_i64(9);
        var array = new List<GameTUnitTag>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameTUnitTag();
            array.Add(data);
        }
        return array;
    }

    public GameSSelectionSyncData Parse_GameSSelectionSyncData() 
    {
        Option<GameTSelectionCount> m_count = Option.None;
        Option<GameTSubgroupCount> m_subgroupCount = Option.None;
        Option<GameTSubgroupIndex> m_activeSubgroupIndex = Option.None;
        Option<GameTSyncChecksum> m_unitTagsChecksum = Option.None;
        Option<GameTSyncChecksum> m_subgroupIndicesChecksum = Option.None;
        Option<GameTSyncChecksum> m_subgroupsChecksum = Option.None;
        if (m_count is { HasValue: false })                           
        {
            var parsed_m_count = Parse_GameSSelectionSyncData_m_count();
            m_count = Option.Some(parsed_m_count);
        }

        if (m_subgroupCount is { HasValue: false })                           
        {
            var parsed_m_subgroupCount = Parse_GameSSelectionSyncData_m_subgroupCount();
            m_subgroupCount = Option.Some(parsed_m_subgroupCount);
        }

        if (m_activeSubgroupIndex is { HasValue: false })                           
        {
            var parsed_m_activeSubgroupIndex = Parse_GameSSelectionSyncData_m_activeSubgroupIndex();
            m_activeSubgroupIndex = Option.Some(parsed_m_activeSubgroupIndex);
        }

        if (m_unitTagsChecksum is { HasValue: false })                           
        {
            var parsed_m_unitTagsChecksum = Parse_GameSSelectionSyncData_m_unitTagsChecksum();
            m_unitTagsChecksum = Option.Some(parsed_m_unitTagsChecksum);
        }

        if (m_subgroupIndicesChecksum is { HasValue: false })                           
        {
            var parsed_m_subgroupIndicesChecksum = Parse_GameSSelectionSyncData_m_subgroupIndicesChecksum();
            m_subgroupIndicesChecksum = Option.Some(parsed_m_subgroupIndicesChecksum);
        }

        if (m_subgroupsChecksum is { HasValue: false })                           
        {
            var parsed_m_subgroupsChecksum = Parse_GameSSelectionSyncData_m_subgroupsChecksum();
            m_subgroupsChecksum = Option.Some(parsed_m_subgroupsChecksum);
        }

        return new GameSSelectionSyncData
        {   
            m_count = Option.OkOrReturnMissingFieldErr(m_count),
            m_subgroupCount = Option.OkOrReturnMissingFieldErr(m_subgroupCount),
            m_activeSubgroupIndex = Option.OkOrReturnMissingFieldErr(m_activeSubgroupIndex),
            m_unitTagsChecksum = Option.OkOrReturnMissingFieldErr(m_unitTagsChecksum),
            m_subgroupIndicesChecksum = Option.OkOrReturnMissingFieldErr(m_subgroupIndicesChecksum),
            m_subgroupsChecksum = Option.OkOrReturnMissingFieldErr(m_subgroupsChecksum),
        };
    }

    public GameTSelectionCount Parse_GameSSelectionSyncData_m_count()
    {                             
        var m_count = Parse_GameTSelectionCount();
        return m_count;
    }

    public GameTSubgroupCount Parse_GameSSelectionSyncData_m_subgroupCount()
    {                             
        var m_subgroupCount = Parse_GameTSubgroupCount();
        return m_subgroupCount;
    }

    public GameTSubgroupIndex Parse_GameSSelectionSyncData_m_activeSubgroupIndex()
    {                             
        var m_activeSubgroupIndex = Parse_GameTSubgroupIndex();
        return m_activeSubgroupIndex;
    }

    public GameTSyncChecksum Parse_GameSSelectionSyncData_m_unitTagsChecksum()
    {                             
        var m_unitTagsChecksum = Parse_GameTSyncChecksum();
        return m_unitTagsChecksum;
    }

    public GameTSyncChecksum Parse_GameSSelectionSyncData_m_subgroupIndicesChecksum()
    {                             
        var m_subgroupIndicesChecksum = Parse_GameTSyncChecksum();
        return m_subgroupIndicesChecksum;
    }

    public GameTSyncChecksum Parse_GameSSelectionSyncData_m_subgroupsChecksum()
    {                             
        var m_subgroupsChecksum = Parse_GameTSyncChecksum();
        return m_subgroupsChecksum;
    }

    public GameSSessionSyncInfo Parse_GameSSessionSyncInfo() 
    {
        Option<List<GameTSyncChecksum>> m_checksums = Option.None;
        if (m_checksums is { HasValue: false })                           
        {
            var parsed_m_checksums = Parse_GameSSessionSyncInfo_m_checksums();
            m_checksums = Option.Some(parsed_m_checksums);
        }

        return new GameSSessionSyncInfo
        {   
            m_checksums = Option.OkOrReturnMissingFieldErr(m_checksums),
        };
    }

    public List<GameTSyncChecksum> Parse_GameSSessionSyncInfo_m_checksums()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<GameTSyncChecksum>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameTSyncChecksum();
            array.Add(data);
        }
        return array;
    }

    public GameSGameSyncInfo Parse_GameSGameSyncInfo() 
    {
        Option<List<GameTSyncChecksum>> m_checksums = Option.None;
        if (m_checksums is { HasValue: false })                           
        {
            var parsed_m_checksums = Parse_GameSGameSyncInfo_m_checksums();
            m_checksums = Option.Some(parsed_m_checksums);
        }

        return new GameSGameSyncInfo
        {   
            m_checksums = Option.OkOrReturnMissingFieldErr(m_checksums),
        };
    }

    public List<GameTSyncChecksum> Parse_GameSGameSyncInfo_m_checksums()
    {                             
        var arrayLength = take_n_bits_into_i64(8);
        var array = new List<GameTSyncChecksum>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameTSyncChecksum();
            array.Add(data);
        }
        return array;
    }

    public ReplaySInitData Parse_ReplaySInitData() 
    {
        Option<GameSLobbySyncState> m_syncLobbyState = Option.None;
        if (m_syncLobbyState is { HasValue: false })                           
        {
            var parsed_m_syncLobbyState = Parse_ReplaySInitData_m_syncLobbyState();
            m_syncLobbyState = Option.Some(parsed_m_syncLobbyState);
        }

        return new ReplaySInitData
        {   
            m_syncLobbyState = Option.OkOrReturnMissingFieldErr(m_syncLobbyState),
        };
    }

    public GameSLobbySyncState Parse_ReplaySInitData_m_syncLobbyState()
    {                             
        var m_syncLobbyState = Parse_GameSLobbySyncState();
        return m_syncLobbyState;
    }

    public ReplaySGameUserId Parse_ReplaySGameUserId() 
    {
        Option<i64> m_userId = Option.None;
        if (m_userId is { HasValue: false })                           
        {
            var parsed_m_userId = Parse_ReplaySGameUserId_m_userId();
            m_userId = Option.Some(parsed_m_userId);
        }

        return new ReplaySGameUserId
        {   
            m_userId = Option.OkOrReturnMissingFieldErr(m_userId),
        };
    }

    public i64 Parse_ReplaySGameUserId_m_userId()
    {                             
        var m_userId = parse_packed_int(0, 5);
        return m_userId;
    }
    public EObserve Parse_EObserve()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

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
    public ELeaveReason Parse_ELeaveReason()
    {
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new ELeaveReason_e_userLeft();
            }                
            case 1:
            {                        
                return new ELeaveReason_e_userDropped();
            }                
            case 2:
            {                        
                return new ELeaveReason_e_userBanned();
            }                
            case 3:
            {                        
                return new ELeaveReason_e_userVictory();
            }                
            case 4:
            {                        
                return new ELeaveReason_e_userDefeat();
            }                
            case 5:
            {                        
                return new ELeaveReason_e_userTied();
            }                
            case 6:
            {                        
                return new ELeaveReason_e_userDesynced();
            }                
            case 7:
            {                        
                return new ELeaveReason_e_userOutOfTime();
            }                
            case 8:
            {                        
                return new ELeaveReason_e_weWereUnresponsive();
            }                
            case 9:
            {                        
                return new ELeaveReason_e_weContinuedAlone();
            }                
            case 10:
            {                        
                return new ELeaveReason_e_replayDesynced();
            }                
            case 11:
            {                        
                return new ELeaveReason_e_userTimeout();
            }                
            case 12:
            {                        
                return new ELeaveReason_e_userDisconnected();
            }                
            case 13:
            {                        
                return new ELeaveReason_e_unrecoverable();
            }                
            case 14:
            {                        
                return new ELeaveReason_e_userCatchupDesynced();
            }                
            case 15:
            {                        
                return new ELeaveReason_e_takeCommandDropped();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public EReconnectStatus Parse_EReconnectStatus()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new EReconnectStatus_e_connected();
            }                
            case 1:
            {                        
                return new EReconnectStatus_e_reconnected();
            }                
            case 2:
            {                        
                return new EReconnectStatus_e_disconnected();
            }                
            case 3:
            {                        
                return new EReconnectStatus_e_unrecoverable();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameESynchronous Parse_GameESynchronous()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameESynchronous_e_local();
            }                
            case 1:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameESynchronous_e_session(res);
            }                
            case 2:
            {                        
                var res = Parse_GameSBankFileEvent();

                return new GameESynchronous_e_game(res);
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameESynthesized Parse_GameESynthesized()
    {
        var numBits = 1;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSDropOurselvesEvent();

                return new GameESynthesized_e_synthesized(res);
            }                
            case 1:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameESynthesized_e_notSynthesized(res);
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEDebug Parse_GameEDebug()
    {
        var numBits = 1;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSPickMapTagEvent();

                return new GameEDebug_e_debug(res);
            }                
            case 1:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameEDebug_e_notDebug(res);
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEHijackMethod Parse_GameEHijackMethod()
    {
        var numBits = 1;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEHijackMethod_e_recover();
            }                
            case 1:
            {                        
                return new GameEHijackMethod_e_takeCommand();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEEventId Parse_GameEEventId()
    {
        var numBits = 7;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameEEventId_e_setLobbySlot(res);
            }                
            case 1:
            {                        
                var res = Parse_GameSDropUserEvent();

                return new GameEEventId_e_dropUser(res);
            }                
            case 2:
            {                        
                var res = Parse_GameSStartGameEvent();

                return new GameEEventId_e_startGame(res);
            }                
            case 3:
            {                        
                var res = Parse_GameSDropOurselvesEvent();

                return new GameEEventId_e_dropOurselves(res);
            }                
            case 4:
            {                        
                var res = Parse_GameSUserFinishedLoadingEvent();

                return new GameEEventId_e_userFinishedLoading(res);
            }                
            case 5:
            {                        
                var res = Parse_GameSUserFinishedLoadingSyncEvent();

                return new GameEEventId_e_userFinishedLoadingSync(res);
            }                
            case 6:
            {                        
                var res = Parse_GameSSetGameDurationEvent();

                return new GameEEventId_e_setGameDuration(res);
            }                
            case 7:
            {                        
                var res = Parse_GameSUserOptionsEvent();

                return new GameEEventId_e_userOptions(res);
            }                
            case 114:
            {                        
                var res = Parse_GameSPickMapTagEvent();

                return new GameEEventId_e_pickMapTag(res);
            }                
            case 8:
            {                        
                var res = Parse_GameSTurnEvent();

                return new GameEEventId_e_turn(res);
            }                
            case 9:
            {                        
                var res = Parse_GameSBankFileEvent();

                return new GameEEventId_e_bankFile(res);
            }                
            case 10:
            {                        
                var res = Parse_GameSBankSectionEvent();

                return new GameEEventId_e_bankSection(res);
            }                
            case 11:
            {                        
                var res = Parse_GameSBankKeyEvent();

                return new GameEEventId_e_bankKey(res);
            }                
            case 12:
            {                        
                var res = Parse_GameSBankValueEvent();

                return new GameEEventId_e_bankValue(res);
            }                
            case 13:
            {                        
                var res = Parse_GameSBankSignatureEvent();

                return new GameEEventId_e_bankSignature(res);
            }                
            case 14:
            {                        
                var res = Parse_GameSCameraSaveEvent();

                return new GameEEventId_e_cameraSave(res);
            }                
            case 15:
            {                        
                var res = Parse_GameSPauseGameEvent();

                return new GameEEventId_e_pauseGame(res);
            }                
            case 16:
            {                        
                var res = Parse_GameSUnpauseGameEvent();

                return new GameEEventId_e_unpauseGame(res);
            }                
            case 17:
            {                        
                var res = Parse_GameSSingleStepGameEvent();

                return new GameEEventId_e_singleStepGame(res);
            }                
            case 18:
            {                        
                var res = Parse_GameSSetGameSpeedEvent();

                return new GameEEventId_e_setGameSpeed(res);
            }                
            case 19:
            {                        
                var res = Parse_GameSAddGameSpeedEvent();

                return new GameEEventId_e_addGameSpeed(res);
            }                
            case 20:
            {                        
                var res = Parse_GameSReplayJumpEvent();

                return new GameEEventId_e_replayJump(res);
            }                
            case 21:
            {                        
                var res = Parse_GameSSaveGameEvent();

                return new GameEEventId_e_saveGame(res);
            }                
            case 22:
            {                        
                var res = Parse_GameSSaveGameDoneEvent();

                return new GameEEventId_e_saveGameDone(res);
            }                
            case 23:
            {                        
                var res = Parse_GameSLoadGameDoneEvent();

                return new GameEEventId_e_loadGameDone(res);
            }                
            case 24:
            {                        
                var res = Parse_GameSSessionCheatEvent();

                return new GameEEventId_e_sessionCheat(res);
            }                
            case 25:
            {                        
                var res = Parse_GameSCommandManagerResetEvent();

                return new GameEEventId_e_commandManagerReset(res);
            }                
            case 26:
            {                        
                var res = Parse_GameSGameCheatEvent();

                return new GameEEventId_e_gameCheat(res);
            }                
            case 27:
            {                        
                var res = Parse_GameSCmdEvent();

                return new GameEEventId_e_cmd(res);
            }                
            case 28:
            {                        
                var res = Parse_GameSSelectionDeltaEvent();

                return new GameEEventId_e_selectionDelta(res);
            }                
            case 29:
            {                        
                var res = Parse_GameSControlGroupUpdateEvent();

                return new GameEEventId_e_controlGroupUpdate(res);
            }                
            case 30:
            {                        
                var res = Parse_GameSSelectionSyncCheckEvent();

                return new GameEEventId_e_selectionSyncCheck(res);
            }                
            case 31:
            {                        
                var res = Parse_GameSResourceTradeEvent();

                return new GameEEventId_e_resourceTrade(res);
            }                
            case 32:
            {                        
                var res = Parse_GameSTriggerChatMessageEvent();

                return new GameEEventId_e_triggerChatMessage(res);
            }                
            case 33:
            {                        
                var res = Parse_GameSAICommunicateEvent();

                return new GameEEventId_e_aiCommunicate(res);
            }                
            case 34:
            {                        
                var res = Parse_GameSSetAbsoluteGameSpeedEvent();

                return new GameEEventId_e_setAbsoluteGameSpeed(res);
            }                
            case 35:
            {                        
                var res = Parse_GameSAddAbsoluteGameSpeedEvent();

                return new GameEEventId_e_addAbsoluteGameSpeed(res);
            }                
            case 36:
            {                        
                var res = Parse_GameSTriggerPingEvent();

                return new GameEEventId_e_triggerPing(res);
            }                
            case 37:
            {                        
                var res = Parse_GameSBroadcastCheatEvent();

                return new GameEEventId_e_broadcastCheat(res);
            }                
            case 38:
            {                        
                var res = Parse_GameSAllianceEvent();

                return new GameEEventId_e_alliance(res);
            }                
            case 39:
            {                        
                var res = Parse_GameSUnitClickEvent();

                return new GameEEventId_e_unitClick(res);
            }                
            case 40:
            {                        
                var res = Parse_GameSUnitHighlightEvent();

                return new GameEEventId_e_unitHighlight(res);
            }                
            case 41:
            {                        
                var res = Parse_GameSTriggerReplySelectedEvent();

                return new GameEEventId_e_triggerReplySelected(res);
            }                
            case 42:
            {                        
                var res = Parse_GameSHijackReplaySessionEvent();

                return new GameEEventId_e_hijackReplaySession(res);
            }                
            case 43:
            {                        
                var res = Parse_GameSHijackReplayGameEvent();

                return new GameEEventId_e_hijackReplayGame(res);
            }                
            case 44:
            {                        
                var res = Parse_GameSTriggerSkippedEvent();

                return new GameEEventId_e_triggerSkipped(res);
            }                
            case 45:
            {                        
                var res = Parse_GameSTriggerSoundLengthQueryEvent();

                return new GameEEventId_e_triggerSoundLengthQuery(res);
            }                
            case 46:
            {                        
                var res = Parse_GameSTriggerSoundOffsetEvent();

                return new GameEEventId_e_triggerSoundOffset(res);
            }                
            case 47:
            {                        
                var res = Parse_GameSTriggerTransmissionOffsetEvent();

                return new GameEEventId_e_triggerTransmissionOffset(res);
            }                
            case 48:
            {                        
                var res = Parse_GameSTriggerTransmissionCompleteEvent();

                return new GameEEventId_e_triggerTransmissionComplete(res);
            }                
            case 49:
            {                        
                var res = Parse_GameSCameraUpdateEvent();

                return new GameEEventId_e_cameraUpdate(res);
            }                
            case 50:
            {                        
                var res = Parse_GameSTriggerAbortMissionEvent();

                return new GameEEventId_e_triggerAbortMission(res);
            }                
            case 51:
            {                        
                var res = Parse_GameSTriggerPurchaseMadeEvent();

                return new GameEEventId_e_triggerPurchaseMade(res);
            }                
            case 52:
            {                        
                var res = Parse_GameSTriggerPurchaseExitEvent();

                return new GameEEventId_e_triggerPurchaseExit(res);
            }                
            case 53:
            {                        
                var res = Parse_GameSTriggerPlanetMissionLaunchedEvent();

                return new GameEEventId_e_triggerPlanetMissionLaunched(res);
            }                
            case 54:
            {                        
                var res = Parse_GameSTriggerPlanetPanelCanceledEvent();

                return new GameEEventId_e_triggerPlanetPanelCanceled(res);
            }                
            case 55:
            {                        
                var res = Parse_GameSTriggerDialogControlEvent();

                return new GameEEventId_e_triggerDialogControl(res);
            }                
            case 56:
            {                        
                var res = Parse_GameSTriggerSoundLengthSyncEvent();

                return new GameEEventId_e_triggerSoundLengthSync(res);
            }                
            case 57:
            {                        
                var res = Parse_GameSTriggerConversationSkippedEvent();

                return new GameEEventId_e_triggerConversationSkipped(res);
            }                
            case 58:
            {                        
                var res = Parse_GameSTriggerMouseClickedEvent();

                return new GameEEventId_e_triggerMouseClicked(res);
            }                
            case 59:
            {                        
                var res = Parse_GameSTriggerMouseMovedEvent();

                return new GameEEventId_e_triggerMouseMoved(res);
            }                
            case 60:
            {                        
                var res = Parse_GameSAchievementAwardedEvent();

                return new GameEEventId_e_achievementAwarded(res);
            }                
            case 61:
            {                        
                var res = Parse_GameSTriggerHotkeyPressedEvent();

                return new GameEEventId_e_triggerHotkeyPressed(res);
            }                
            case 62:
            {                        
                var res = Parse_GameSTriggerTargetModeUpdateEvent();

                return new GameEEventId_e_triggerTargetModeUpdate(res);
            }                
            case 63:
            {                        
                var res = Parse_GameSTriggerPlanetPanelReplayEvent();

                return new GameEEventId_e_triggerPlanetPanelPanelReplay(res);
            }                
            case 64:
            {                        
                var res = Parse_GameSTriggerSoundtrackDoneEvent();

                return new GameEEventId_e_triggerSoundtrackDone(res);
            }                
            case 65:
            {                        
                var res = Parse_GameSTriggerPlanetMissionSelectedEvent();

                return new GameEEventId_e_triggerPlanetMissionSelected(res);
            }                
            case 66:
            {                        
                var res = Parse_GameSTriggerKeyPressedEvent();

                return new GameEEventId_e_triggerKeyPressed(res);
            }                
            case 67:
            {                        
                var res = Parse_GameSTriggerMovieFunctionEvent();

                return new GameEEventId_e_triggerMovieFunction(res);
            }                
            case 68:
            {                        
                var res = Parse_GameSTriggerPlanetPanelBirthCompleteEvent();

                return new GameEEventId_e_triggerPlanetPanelPanelBirthComplete(res);
            }                
            case 69:
            {                        
                var res = Parse_GameSTriggerPlanetPanelDeathCompleteEvent();

                return new GameEEventId_e_triggerPlanetPanelPanelDeathComplete(res);
            }                
            case 70:
            {                        
                var res = Parse_GameSResourceRequestEvent();

                return new GameEEventId_e_resourceRequest(res);
            }                
            case 71:
            {                        
                var res = Parse_GameSResourceRequestFulfillEvent();

                return new GameEEventId_e_resourceRequestFulfill(res);
            }                
            case 72:
            {                        
                var res = Parse_GameSResourceRequestCancelEvent();

                return new GameEEventId_e_resourceRequestCancel(res);
            }                
            case 73:
            {                        
                var res = Parse_GameSTriggerResearchPanelExitEvent();

                return new GameEEventId_e_triggerResearchPanelExit(res);
            }                
            case 74:
            {                        
                var res = Parse_GameSTriggerResearchPanelPurchaseEvent();

                return new GameEEventId_e_triggerResearchPanelPurchase(res);
            }                
            case 75:
            {                        
                var res = Parse_GameSTriggerResearchPanelSelectionChangedEvent();

                return new GameEEventId_e_triggerResearchPanelSelectionChanged(res);
            }                
            case 76:
            {                        
                var res = Parse_GameSTriggerCommandErrorEvent();

                return new GameEEventId_e_triggerCommandError(res);
            }                
            case 77:
            {                        
                var res = Parse_GameSTriggerMercenaryPanelExitEvent();

                return new GameEEventId_e_triggerMercenaryPanelExit(res);
            }                
            case 78:
            {                        
                var res = Parse_GameSTriggerMercenaryPanelPurchaseEvent();

                return new GameEEventId_e_triggerMercenaryPanelPurchase(res);
            }                
            case 79:
            {                        
                var res = Parse_GameSTriggerMercenaryPanelSelectionChangedEvent();

                return new GameEEventId_e_triggerMercenaryPanelSelectionChanged(res);
            }                
            case 80:
            {                        
                var res = Parse_GameSTriggerVictoryPanelExitEvent();

                return new GameEEventId_e_triggerVictoryPanelExit(res);
            }                
            case 81:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelExitEvent();

                return new GameEEventId_e_triggerBattleReportPanelExit(res);
            }                
            case 82:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelPlayMissionEvent();

                return new GameEEventId_e_triggerBattleReportPanelPlayMission(res);
            }                
            case 83:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelPlaySceneEvent();

                return new GameEEventId_e_triggerBattleReportPanelPlayScene(res);
            }                
            case 84:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelSelectionChangedEvent();

                return new GameEEventId_e_triggerBattleReportSelectionChanged(res);
            }                
            case 85:
            {                        
                var res = Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent();

                return new GameEEventId_e_triggerVictoryPanelPlayMissionAgain(res);
            }                
            case 86:
            {                        
                var res = Parse_GameSTriggerMovieStartedEvent();

                return new GameEEventId_e_triggerMovieStarted(res);
            }                
            case 87:
            {                        
                var res = Parse_GameSTriggerMovieFinishedEvent();

                return new GameEEventId_e_triggerMovieFinished(res);
            }                
            case 88:
            {                        
                var res = Parse_GameSDecrementGameTimeRemainingEvent();

                return new GameEEventId_e_decrementGameTimeRemaining(res);
            }                
            case 89:
            {                        
                var res = Parse_GameSTriggerPortraitLoadedEvent();

                return new GameEEventId_e_triggerPortraitLoaded(res);
            }                
            case 90:
            {                        
                var res = Parse_GameSTriggerCustomDialogDismissedEvent();

                return new GameEEventId_e_triggerQueryDialogDismissed(res);
            }                
            case 91:
            {                        
                var res = Parse_GameSTriggerGameMenuItemSelectedEvent();

                return new GameEEventId_e_triggerGameMenuItemSelected(res);
            }                
            case 92:
            {                        
                var res = Parse_GameSTriggerMouseWheelEvent();

                return new GameEEventId_e_triggerMouseWheel(res);
            }                
            case 93:
            {                        
                var res = Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent();

                return new GameEEventId_e_triggerPurchasePanelSelectedPurchaseItemChanged(res);
            }                
            case 94:
            {                        
                var res = Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent();

                return new GameEEventId_e_triggerPurchasePanelSelectedPurchaseCategoryChanged(res);
            }                
            case 95:
            {                        
                var res = Parse_GameSTriggerButtonPressedEvent();

                return new GameEEventId_e_triggerButtonPressed(res);
            }                
            case 96:
            {                        
                var res = Parse_GameSTriggerGameCreditsFinishedEvent();

                return new GameEEventId_e_triggerGameCreditsFinished(res);
            }                
            case 97:
            {                        
                var res = Parse_GameSTriggerCutsceneBookmarkFiredEvent();

                return new GameEEventId_e_triggerCutsceneBookmarkFired(res);
            }                
            case 98:
            {                        
                var res = Parse_GameSTriggerCutsceneEndSceneFiredEvent();

                return new GameEEventId_e_triggerCutsceneEndSceneFired(res);
            }                
            case 99:
            {                        
                var res = Parse_GameSTriggerCutsceneConversationLineEvent();

                return new GameEEventId_e_triggerCutsceneConversationLine(res);
            }                
            case 100:
            {                        
                var res = Parse_GameSTriggerCutsceneConversationLineMissingEvent();

                return new GameEEventId_e_triggerCutsceneConversationLineMissing(res);
            }                
            case 101:
            {                        
                var res = Parse_GameSGameUserLeaveEvent();

                return new GameEEventId_e_gameUserLeave(res);
            }                
            case 102:
            {                        
                var res = Parse_GameSGameUserJoinEvent();

                return new GameEEventId_e_gameUserJoin(res);
            }                
            case 103:
            {                        
                var res = Parse_GameSCommandManagerStateEvent();

                return new GameEEventId_e_commandManagerState(res);
            }                
            case 104:
            {                        
                var res = Parse_GameSCmdUpdateTargetPointEvent();

                return new GameEEventId_e_cmdUpdateTargetPoint(res);
            }                
            case 105:
            {                        
                var res = Parse_GameSCmdUpdateTargetUnitEvent();

                return new GameEEventId_e_cmdUpdateTargetUnit(res);
            }                
            case 106:
            {                        
                var res = Parse_GameSTriggerAnimLengthQueryByNameEvent();

                return new GameEEventId_e_triggerAnimLengthQueryByName(res);
            }                
            case 107:
            {                        
                var res = Parse_GameSTriggerAnimLengthQueryByPropsEvent();

                return new GameEEventId_e_triggerAnimLengthQueryByProps(res);
            }                
            case 108:
            {                        
                var res = Parse_GameSTriggerAnimOffsetEvent();

                return new GameEEventId_e_triggerAnimOffset(res);
            }                
            case 109:
            {                        
                var res = Parse_GameSCatalogModifyEvent();

                return new GameEEventId_e_catalogModify(res);
            }                
            case 110:
            {                        
                var res = Parse_GameSHeroTalentTreeSelectedEvent();

                return new GameEEventId_e_heroTalentTreeSelected(res);
            }                
            case 111:
            {                        
                var res = Parse_GameSTriggerProfilerLoggingFinishedEvent();

                return new GameEEventId_e_triggerProfilerLoggingFinished(res);
            }                
            case 112:
            {                        
                var res = Parse_GameSHeroTalentTreeSelectionPanelToggledEvent();

                return new GameEEventId_e_heroTalentTreeSelectionPanelToggled(res);
            }                
            case 113:
            {                        
                var res = Parse_GameSMuteChatEvent();

                return new GameEEventId_e_muteUserChanged(res);
            }                
            case 115:
            {                        
                var res = Parse_GameSConvertToReplaySessionEvent();

                return new GameEEventId_e_convertToReplaySession(res);
            }                
            case 116:
            {                        
                var res = Parse_GameSSetSyncLoadingTimeEvent();

                return new GameEEventId_e_setSyncLoadingTime(res);
            }                
            case 117:
            {                        
                var res = Parse_GameSSetSyncPlayingTimeEvent();

                return new GameEEventId_e_setSyncPlayingTime(res);
            }                
            case 118:
            {                        
                var res = Parse_GameSPeerSetSyncLoadingTimeEvent();

                return new GameEEventId_e_peerSetSyncLoadingTime(res);
            }                
            case 119:
            {                        
                var res = Parse_GameSPeerSetSyncPlayingTimeEvent();

                return new GameEEventId_e_peerSetSyncPlayingTime(res);
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameECommandManagerState Parse_GameECommandManagerState()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameECommandManagerState_e_fireDone();
            }                
            case 1:
            {                        
                return new GameECommandManagerState_e_fireOnce();
            }                
            case 2:
            {                        
                return new GameECommandManagerState_e_fireMany();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEGameSpeed Parse_GameEGameSpeed()
    {
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

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
    public GameEPhase Parse_GameEPhase()
    {
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEPhase_e_initializing();
            }                
            case 1:
            {                        
                return new GameEPhase_e_lobby();
            }                
            case 2:
            {                        
                return new GameEPhase_e_closed();
            }                
            case 3:
            {                        
                return new GameEPhase_e_loading();
            }                
            case 4:
            {                        
                return new GameEPhase_e_playing();
            }                
            case 5:
            {                        
                return new GameEPhase_e_gameover();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEConversationSkip Parse_GameEConversationSkip()
    {
        var numBits = 1;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEConversationSkip_e_skipOneLine();
            }                
            case 1:
            {                        
                return new GameEConversationSkip_e_skipAllLines();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEResultDetails Parse_GameEResultDetails()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

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
    public GameEOptionFog Parse_GameEOptionFog()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEOptionFog_e_default();
            }                
            case 1:
            {                        
                return new GameEOptionFog_e_hideTerrain();
            }                
            case 2:
            {                        
                return new GameEOptionFog_e_mapExplored();
            }                
            case 3:
            {                        
                return new GameEOptionFog_e_alwaysVisible();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEOptionObservers Parse_GameEOptionObservers()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEOptionObservers_e_none();
            }                
            case 1:
            {                        
                return new GameEOptionObservers_e_onJoin();
            }                
            case 2:
            {                        
                return new GameEOptionObservers_e_onJoinAndDefeat();
            }                
            case 3:
            {                        
                return new GameEOptionObservers_e_refereesOnJoin();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEOptionUserDifficulty Parse_GameEOptionUserDifficulty()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEOptionUserDifficulty_e_none();
            }                
            case 1:
            {                        
                return new GameEOptionUserDifficulty_e_global();
            }                
            case 2:
            {                        
                return new GameEOptionUserDifficulty_e_individual();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEGameLaunch Parse_GameEGameLaunch()
    {
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEGameLaunch_e_invalid();
            }                
            case 1:
            {                        
                return new GameEGameLaunch_e_map();
            }                
            case 2:
            {                        
                return new GameEGameLaunch_e_replay();
            }                
            case 3:
            {                        
                return new GameEGameLaunch_e_save();
            }                
            case 4:
            {                        
                return new GameEGameLaunch_e_transition();
            }                
            case 5:
            {                        
                return new GameEGameLaunch_e_serverReplay();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEGameType Parse_GameEGameType()
    {
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEGameType_e_melee();
            }                
            case 1:
            {                        
                return new GameEGameType_e_freeForAll();
            }                
            case 2:
            {                        
                return new GameEGameType_e_useSettings();
            }                
            case 3:
            {                        
                return new GameEGameType_e_oneOnOne();
            }                
            case 4:
            {                        
                return new GameEGameType_e_twoTeamPlay();
            }                
            case 5:
            {                        
                return new GameEGameType_e_threeTeamPlay();
            }                
            case 6:
            {                        
                return new GameEGameType_e_fourTeamPlay();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEControl Parse_GameEControl()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEControl_e_open();
            }                
            case 1:
            {                        
                return new GameEControl_e_closed();
            }                
            case 2:
            {                        
                return new GameEControl_e_user();
            }                
            case 3:
            {                        
                return new GameEControl_e_computer();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEMessageRecipient Parse_GameEMessageRecipient()
    {
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEMessageRecipient_e_all();
            }                
            case 1:
            {                        
                return new GameEMessageRecipient_e_allies();
            }                
            case 2:
            {                        
                return new GameEMessageRecipient_e_individual();
            }                
            case 3:
            {                        
                return new GameEMessageRecipient_e_battlenet();
            }                
            case 4:
            {                        
                return new GameEMessageRecipient_e_observers();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEMessageId Parse_GameEMessageId()
    {
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSChatMessage();

                return new GameEMessageId_e_chat(res);
            }                
            case 1:
            {                        
                var res = Parse_GameSPingMessage();

                return new GameEMessageId_e_ping(res);
            }                
            case 2:
            {                        
                var res = Parse_GameSLoadingProgressMessage();

                return new GameEMessageId_e_loadingProgress(res);
            }                
            case 3:
            {                        
                var res = Parse_GameSServerPingMessage();

                return new GameEMessageId_e_serverPing(res);
            }                
            case 4:
            {                        
                var res = Parse_GameSReconnectNotifyMessage();

                return new GameEMessageId_e_reconnectNotify(res);
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEResultCode Parse_GameEResultCode()
    {
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEResultCode_e_undecided();
            }                
            case 1:
            {                        
                return new GameEResultCode_e_loss();
            }                
            case 2:
            {                        
                return new GameEResultCode_e_tie();
            }                
            case 3:
            {                        
                return new GameEResultCode_e_win();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEControlGroupUpdate Parse_GameEControlGroupUpdate()
    {
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEControlGroupUpdate_e_set();
            }                
            case 1:
            {                        
                return new GameEControlGroupUpdate_e_append();
            }                
            case 2:
            {                        
                return new GameEControlGroupUpdate_e_recall();
            }                
            case 3:
            {                        
                return new GameEControlGroupUpdate_e_clear();
            }                
            case 4:
            {                        
                return new GameEControlGroupUpdate_e_setAndSteal();
            }                
            case 5:
            {                        
                return new GameEControlGroupUpdate_e_appendAndSteal();
            }                
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public TRaceId Parse_TRaceId()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new TRaceId
        {
            Value = res
        };
    }
    public TRaceCount Parse_TRaceCount()
    {
        var offset = 1;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new TRaceCount
        {
            Value = res
        };
    }
    public int8 Parse_int8()
    {
        var offset = -128;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new int8
        {
            Value = res
        };
    }
    public int16 Parse_int16()
    {
        var offset = -32768;
        var numBits = 16;
        var res = parse_packed_int(offset, numBits);

        return new int16
        {
            Value = res
        };
    }
    public int32 Parse_int32()
    {
        var offset = -2147483648;
        var numBits = 32;
        var res = parse_packed_int(offset, numBits);

        return new int32
        {
            Value = res
        };
    }
    public int64 Parse_int64()
    {
        var offset = -9223372036854775808;
        var numBits = 64;
        var res = parse_packed_int(offset, numBits);

        return new int64
        {
            Value = res
        };
    }
    public uint8 Parse_uint8()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new uint8
        {
            Value = res
        };
    }
    public uint16 Parse_uint16()
    {
        var offset = 0;
        var numBits = 16;
        var res = parse_packed_int(offset, numBits);

        return new uint16
        {
            Value = res
        };
    }
    public uint32 Parse_uint32()
    {
        var offset = 0;
        var numBits = 32;
        var res = parse_packed_int(offset, numBits);

        return new uint32
        {
            Value = res
        };
    }
    public uint64 Parse_uint64()
    {
        var offset = 0;
        var numBits = 64;
        var res = parse_packed_int(offset, numBits);

        return new uint64
        {
            Value = res
        };
    }
    public uint6 Parse_uint6()
    {
        var offset = 0;
        var numBits = 6;
        var res = parse_packed_int(offset, numBits);

        return new uint6
        {
            Value = res
        };
    }
    public uint14 Parse_uint14()
    {
        var offset = 0;
        var numBits = 14;
        var res = parse_packed_int(offset, numBits);

        return new uint14
        {
            Value = res
        };
    }
    public uint22 Parse_uint22()
    {
        var offset = 0;
        var numBits = 22;
        var res = parse_packed_int(offset, numBits);

        return new uint22
        {
            Value = res
        };
    }
    public TUserId Parse_TUserId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new TUserId
        {
            Value = res
        };
    }
    public TUserCount Parse_TUserCount()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new TUserCount
        {
            Value = res
        };
    }
    public GameTColorId Parse_GameTColorId()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTColorId
        {
            Value = res
        };
    }
    public GameTColorCount Parse_GameTColorCount()
    {
        var offset = 0;
        var numBits = 6;
        var res = parse_packed_int(offset, numBits);

        return new GameTColorCount
        {
            Value = res
        };
    }
    public GameTFixedInt Parse_GameTFixedInt()
    {
        var offset = -524288;
        var numBits = 20;
        var res = parse_packed_int(offset, numBits);

        return new GameTFixedInt
        {
            Value = res
        };
    }
    public GameTFixedUInt Parse_GameTFixedUInt()
    {
        var offset = 0;
        var numBits = 19;
        var res = parse_packed_int(offset, numBits);

        return new GameTFixedUInt
        {
            Value = res
        };
    }
    public GameTMapCoordFixedBits Parse_GameTMapCoordFixedBits()
    {
        var offset = 0;
        var numBits = 20;
        var res = parse_packed_int(offset, numBits);

        return new GameTMapCoordFixedBits
        {
            Value = res
        };
    }
    public GameTUICoordX Parse_GameTUICoordX()
    {
        var offset = 0;
        var numBits = 11;
        var res = parse_packed_int(offset, numBits);

        return new GameTUICoordX
        {
            Value = res
        };
    }
    public GameTUICoordY Parse_GameTUICoordY()
    {
        var offset = 0;
        var numBits = 11;
        var res = parse_packed_int(offset, numBits);

        return new GameTUICoordY
        {
            Value = res
        };
    }
    public GameTHandicap Parse_GameTHandicap()
    {
        var offset = 0;
        var numBits = 7;
        var res = parse_packed_int(offset, numBits);

        return new GameTHandicap
        {
            Value = res
        };
    }
    public GameTDifficulty Parse_GameTDifficulty()
    {
        var offset = 0;
        var numBits = 6;
        var res = parse_packed_int(offset, numBits);

        return new GameTDifficulty
        {
            Value = res
        };
    }
    public GameTAIBuild Parse_GameTAIBuild()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTAIBuild
        {
            Value = res
        };
    }
    public GameEClientDebugFlags Parse_GameEClientDebugFlags()
    {
        var offset = 0;
        var numBits = 64;
        var res = parse_packed_int(offset, numBits);

        return new GameEClientDebugFlags
        {
            Value = res
        };
    }
    public GameTControlId Parse_GameTControlId()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlId
        {
            Value = res
        };
    }
    public GameTControlCount Parse_GameTControlCount()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlCount
        {
            Value = res
        };
    }
    public GameTLobbySlotCount Parse_GameTLobbySlotCount()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTLobbySlotCount
        {
            Value = res
        };
    }
    public GameTLobbySlotId Parse_GameTLobbySlotId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTLobbySlotId
        {
            Value = res
        };
    }
    public GameTPlayerId Parse_GameTPlayerId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTPlayerId
        {
            Value = res
        };
    }
    public GameTPlayerCount Parse_GameTPlayerCount()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTPlayerCount
        {
            Value = res
        };
    }
    public GameTSelectionCount Parse_GameTSelectionCount()
    {
        var offset = 0;
        var numBits = 9;
        var res = parse_packed_int(offset, numBits);

        return new GameTSelectionCount
        {
            Value = res
        };
    }
    public GameTSelectionIndex Parse_GameTSelectionIndex()
    {
        var offset = 0;
        var numBits = 9;
        var res = parse_packed_int(offset, numBits);

        return new GameTSelectionIndex
        {
            Value = res
        };
    }
    public GameTSubgroupPriority Parse_GameTSubgroupPriority()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTSubgroupPriority
        {
            Value = res
        };
    }
    public GameTSubgroupCount Parse_GameTSubgroupCount()
    {
        var offset = 0;
        var numBits = 9;
        var res = parse_packed_int(offset, numBits);

        return new GameTSubgroupCount
        {
            Value = res
        };
    }
    public GameTSubgroupIndex Parse_GameTSubgroupIndex()
    {
        var offset = 0;
        var numBits = 9;
        var res = parse_packed_int(offset, numBits);

        return new GameTSubgroupIndex
        {
            Value = res
        };
    }
    public GameTControlGroupCount Parse_GameTControlGroupCount()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlGroupCount
        {
            Value = res
        };
    }
    public GameTControlGroupIndex Parse_GameTControlGroupIndex()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlGroupIndex
        {
            Value = res
        };
    }
    public GameTControlGroupId Parse_GameTControlGroupId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlGroupId
        {
            Value = res
        };
    }
    public GameTTeamId Parse_GameTTeamId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTTeamId
        {
            Value = res
        };
    }
    public GameTTeamCount Parse_GameTTeamCount()
    {
        var offset = 1;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTTeamCount
        {
            Value = res
        };
    }
    public CAllowedRaces Parse_CAllowedRaces()
    {
        var bitArrayLengthBits = 8;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new CAllowedRaces
        {
            Value = value
        };
    }
    public CAllowedObserveTypes Parse_CAllowedObserveTypes()
    {
        var bitArrayLengthBits = 2;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new CAllowedObserveTypes
        {
            Value = value
        };
    }
    public GameCAllowedColors Parse_GameCAllowedColors()
    {
        var bitArrayLengthBits = 6;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameCAllowedColors
        {
            Value = value
        };
    }
    public GameCAllowedDifficulty Parse_GameCAllowedDifficulty()
    {
        var bitArrayLengthBits = 6;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameCAllowedDifficulty
        {
            Value = value
        };
    }
    public GameCAllowedAIBuild Parse_GameCAllowedAIBuild()
    {
        var bitArrayLengthBits = 8;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameCAllowedAIBuild
        {
            Value = value
        };
    }
    public GameCAllowedControls Parse_GameCAllowedControls()
    {
        var bitArrayLengthBits = 8;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameCAllowedControls
        {
            Value = value
        };
    }
    public GameSelectionMaskType Parse_GameSelectionMaskType()
    {
        var bitArrayLengthBits = 9;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameSelectionMaskType
        {
            Value = value
        };
    }
    public GameTQueryID Parse_GameTQueryID()
    {
        var value = Parse_uint16();

        return new GameTQueryID
        {
            Value = value,
        };
    }
    public Gamec_invalidQueryId Parse_Gamec_invalidQueryId()
    {
        var value = Parse_uint16();

        return new Gamec_invalidQueryId
        {
            Value = value,
        };
    }
    public GameTAchievementLink Parse_GameTAchievementLink()
    {
        var value = Parse_uint16();

        return new GameTAchievementLink
        {
            Value = value,
        };
    }
    public GameTAchievementTermLink Parse_GameTAchievementTermLink()
    {
        var value = Parse_uint16();

        return new GameTAchievementTermLink
        {
            Value = value,
        };
    }
    public GameTButtonLink Parse_GameTButtonLink()
    {
        var value = Parse_uint16();

        return new GameTButtonLink
        {
            Value = value,
        };
    }
    public GameTUnitLink Parse_GameTUnitLink()
    {
        var value = Parse_uint16();

        return new GameTUnitLink
        {
            Value = value,
        };
    }
    public GameTUnitTag Parse_GameTUnitTag()
    {
        var value = Parse_uint32();

        return new GameTUnitTag
        {
            Value = value,
        };
    }
    public GameTTriggerThreadTag Parse_GameTTriggerThreadTag()
    {
        var value = Parse_uint32();

        return new GameTTriggerThreadTag
        {
            Value = value,
        };
    }
    public GameTTriggerSoundTag Parse_GameTTriggerSoundTag()
    {
        var value = Parse_uint32();

        return new GameTTriggerSoundTag
        {
            Value = value,
        };
    }
    public GameTAbilLink Parse_GameTAbilLink()
    {
        var value = Parse_uint16();

        return new GameTAbilLink
        {
            Value = value,
        };
    }
    public GameTFixedBits Parse_GameTFixedBits()
    {
        var value = Parse_int32();

        return new GameTFixedBits
        {
            Value = value,
        };
    }
    public GameTFixedMiniBitsUnsigned Parse_GameTFixedMiniBitsUnsigned()
    {
        var value = Parse_uint16();

        return new GameTFixedMiniBitsUnsigned
        {
            Value = value,
        };
    }
    public GameTFixedMiniBitsSigned Parse_GameTFixedMiniBitsSigned()
    {
        var value = Parse_int16();

        return new GameTFixedMiniBitsSigned
        {
            Value = value,
        };
    }
    public GameTPlayerLogoIndex Parse_GameTPlayerLogoIndex()
    {
        var value = Parse_uint32();

        return new GameTPlayerLogoIndex
        {
            Value = value,
        };
    }
    public Gamec_maxPlayerLogoIndex Parse_Gamec_maxPlayerLogoIndex()
    {
        var value = Parse_GameTPlayerLogoIndex();

        return new Gamec_maxPlayerLogoIndex
        {
            Value = value,
        };
    }
    public GameTHeroLink Parse_GameTHeroLink()
    {
        var value = Parse_uint16();

        return new GameTHeroLink
        {
            Value = value,
        };
    }
    public GameTReward Parse_GameTReward()
    {
        var value = Parse_uint32();

        return new GameTReward
        {
            Value = value,
        };
    }
    public GameTLicense Parse_GameTLicense()
    {
        var value = Parse_uint32();

        return new GameTLicense
        {
            Value = value,
        };
    }
    public GameTSyncChecksum Parse_GameTSyncChecksum()
    {
        var value = Parse_uint32();

        return new GameTSyncChecksum
        {
            Value = value,
        };
    }
    public GameTSyncValue Parse_GameTSyncValue()
    {
        var value = Parse_uint16();

        return new GameTSyncValue
        {
            Value = value,
        };
    }
    public Gamec_ignoreSyncValue Parse_Gamec_ignoreSyncValue()
    {
        var value = Parse_GameTSyncValue();

        return new Gamec_ignoreSyncValue
        {
            Value = value,
        };
    }
    public CUserInitialDataArray Parse_CUserInitialDataArray()
    {
        var arrayLengthNumBits = 5;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_SUserInitialData, arrayLength);

        return new CUserInitialDataArray
        {
            Value = value
        };
    }
    public GameCPlayerDetailsArray Parse_GameCPlayerDetailsArray()
    {
        var arrayLengthNumBits = 5;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameSPlayerDetails, arrayLength);

        return new GameCPlayerDetailsArray
        {
            Value = value
        };
    }
    public GameCModPaths Parse_GameCModPaths()
    {
        var arrayLengthNumBits = 6;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_CFilePath, arrayLength);

        return new GameCModPaths
        {
            Value = value
        };
    }
    public GameCCacheHandles Parse_GameCCacheHandles()
    {
        var arrayLengthNumBits = 6;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameCCacheHandle, arrayLength);

        return new GameCCacheHandles
        {
            Value = value
        };
    }
    public GameSSlotDescriptions Parse_GameSSlotDescriptions()
    {
        var arrayLengthNumBits = 5;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameSSlotDescription, arrayLength);

        return new GameSSlotDescriptions
        {
            Value = value
        };
    }
    public GameCArtifactArray Parse_GameCArtifactArray()
    {
        var arrayLengthNumBits = 4;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_CArtifactHandle, arrayLength);

        return new GameCArtifactArray
        {
            Value = value
        };
    }
    public GameCCommanderMasteryTalentArray Parse_GameCCommanderMasteryTalentArray()
    {
        var arrayLengthNumBits = 3;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_uint32, arrayLength);

        return new GameCCommanderMasteryTalentArray
        {
            Value = value
        };
    }
    public GameCRewardArray Parse_GameCRewardArray()
    {
        var arrayLengthNumBits = 17;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameTReward, arrayLength);

        return new GameCRewardArray
        {
            Value = value
        };
    }
    public GameCRewardOverrideArray Parse_GameCRewardOverrideArray()
    {
        var arrayLengthNumBits = 17;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameCRewardOverride, arrayLength);

        return new GameCRewardOverrideArray
        {
            Value = value
        };
    }
    public GameCLicenseArray Parse_GameCLicenseArray()
    {
        var arrayLengthNumBits = 13;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameTLicense, arrayLength);

        return new GameCLicenseArray
        {
            Value = value
        };
    }
    public GameCLobbySlotArray Parse_GameCLobbySlotArray()
    {
        var arrayLengthNumBits = 5;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameSLobbySlot, arrayLength);

        return new GameCLobbySlotArray
        {
            Value = value
        };
    }
    public GameSelectionIndexArrayType Parse_GameSelectionIndexArrayType()
    {
        var arrayLengthNumBits = 9;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameTSelectionIndex, arrayLength);

        return new GameSelectionIndexArrayType
        {
            Value = value
        };
    }
    public CFilePath Parse_CFilePath()
    {
        var strSizeNumBits = 11;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CFilePath
        {
            Value = value
        };
    }
    public CUserName Parse_CUserName()
    {
        var strSizeNumBits = 8;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CUserName
        {
            Value = value
        };
    }
    public CClanTag Parse_CClanTag()
    {
        var strSizeNumBits = 8;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CClanTag
        {
            Value = value
        };
    }
    public CHeroHandle Parse_CHeroHandle()
    {
        var strSizeNumBits = 9;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CHeroHandle
        {
            Value = value
        };
    }
    public CSkinHandle Parse_CSkinHandle()
    {
        var strSizeNumBits = 9;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CSkinHandle
        {
            Value = value
        };
    }
    public CMountHandle Parse_CMountHandle()
    {
        var strSizeNumBits = 9;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CMountHandle
        {
            Value = value
        };
    }
    public CArtifactHandle Parse_CArtifactHandle()
    {
        var strSizeNumBits = 9;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CArtifactHandle
        {
            Value = value
        };
    }
    public CToonHandle Parse_CToonHandle()
    {
        var strSizeNumBits = 7;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CToonHandle
        {
            Value = value
        };
    }
    public CCommanderHandle Parse_CCommanderHandle()
    {
        var strSizeNumBits = 9;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CCommanderHandle
        {
            Value = value
        };
    }
    public GameCCheatString Parse_GameCCheatString()
    {
        var strSizeNumBits = 10;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCCheatString
        {
            Value = value
        };
    }
    public GameCTriggerChatMessageString Parse_GameCTriggerChatMessageString()
    {
        var strSizeNumBits = 10;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCTriggerChatMessageString
        {
            Value = value
        };
    }
    public GameCGameCacheName Parse_GameCGameCacheName()
    {
        var strSizeNumBits = 10;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCGameCacheName
        {
            Value = value
        };
    }
    public GameCAuthorName Parse_GameCAuthorName()
    {
        var strSizeNumBits = 8;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCAuthorName
        {
            Value = value
        };
    }
    public GameCChatString Parse_GameCChatString()
    {
        var strSizeNumBits = 11;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCChatString
        {
            Value = value
        };
    }
    public CCacheHandle Parse_CCacheHandle()
    {
        byte_align();
        var numBytes = 40;
        
        var value = ReadBytes(numBytes);

        return new CCacheHandle
        {
            Value = value
        };
    }
    public GameCCacheHandle Parse_GameCCacheHandle()
    {
        byte_align();
        var numBytes = 40;
        
        var value = ReadBytes(numBytes);

        return new GameCCacheHandle
        {
            Value = value
        };
    }

}
