#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#define VECTORIZE_MEMORY_MOVE
#endif

namespace MPQArchive.Bzip;

public partial class FastBZip2InputStream
{

    //public /*override int Read(Span<byte> targetSpan)*/
    //{
    //    int i = 0;
    //    while (i < targetSpan.Length)
    //    {
    //        int rb = ReadByte();

    //        if (rb == -1)
    //        {
    //            return i;
    //        }

    //        targetSpan[i] = (byte)rb;
    //        i++;
    //    }

    //    return targetSpan.Length;
    //}

    public override int Read(Span<byte> targetSpan)
    {
        Span<int> cftab = stackalloc int[257];
        int targetPos = 0;
        int targetEnd = targetSpan.Length;

    LoopCondition:
        if (targetPos >= targetEnd)
        {
            return targetEnd;
        }

    LoopBody:
        if (streamEnd)
        {
            return targetPos; // SEBA
        }

        int retChar = currentChar;

        if (retChar == -1)
        {
            return targetPos;
        }

        targetSpan[targetPos] = (byte)retChar;

        targetPos++;

        switch (currentState)
        {
            case RAND_PART_B_STATE:
                goto SetupRandPartB;

            case RAND_PART_C_STATE:
                goto SetupRandPartC;

            case NO_RAND_PART_B_STATE:
                goto SetupNoRandPartB;

            case NO_RAND_PART_C_STATE:
                goto SetupNoRandPartC;

            case START_BLOCK_STATE:
            case NO_RAND_PART_A_STATE:
            case RAND_PART_A_STATE:
                break;
        }

    Exit:
        goto LoopCondition;

    LoopBreak:
        streamEnd = true;
        return targetPos;

    SetupRandPartB:
        {
            if (ch2 != chPrev)
            {
                currentState = RAND_PART_A_STATE;
                count = 1;
                goto SetupRandPartA;
            }
            else
            {
                count++;
                if (count >= 4)
                {
                    z = ll8[tPos];
                    tPos = tt[tPos];
                    if (rNToGo == 0)
                    {
                        rNToGo = FastBZip2InputConstants.RandomNumbers[rTPos];
                        rTPos++;
                        if (rTPos == 512)
                        {
                            rTPos = 0;
                        }
                    }
                    rNToGo--;
                    z ^= (byte)((rNToGo == 1) ? 1 : 0);
                    j2 = 0;
                    currentState = RAND_PART_C_STATE;
                    goto SetupRandPartC;
                }
                else
                {
                    currentState = RAND_PART_A_STATE;
                    goto SetupRandPartA;
                }
            }
        }
        goto Exit;
        // SetupRandPartB

    SetupRandPartC:
        {
            if (j2 < (int)z)
            {
                currentChar = ch2;
                mCrc.Update(ch2);
                j2++;
            }
            else
            {
                currentState = RAND_PART_A_STATE;
                i2++;
                count = 0;
                goto SetupRandPartA;
            }
        }
        goto Exit;
        // SetupRandPartC

    SetupNoRandPartB:
        {
            if (ch2 != chPrev)
            {
                currentState = NO_RAND_PART_A_STATE;
                count = 1;
                goto SetupNoRandPartA;
            }
            else
            {
                count++;
                if (count >= 4)
                {
                    z = ll8[tPos];
                    tPos = tt[tPos];
                    currentState = NO_RAND_PART_C_STATE;
                    j2 = 0;
                    goto SetupNoRandPartC;
                }
                else
                {
                    currentState = NO_RAND_PART_A_STATE;
                    goto SetupNoRandPartA;
                }
            }
        }
        goto Exit;
        // SetupNoRandPartB

    SetupNoRandPartC:
        {
            if (j2 < (int)z)
            {
                currentChar = ch2;
                mCrc.Update(ch2);
                j2++;
            }
            else
            {
                currentState = NO_RAND_PART_A_STATE;
                i2++;
                count = 0;
                goto SetupNoRandPartA;
            }
        }
        goto Exit;
        // SetupNoRandPartC

    SetupRandPartA:
        {
            if (i2 <= last)
            {
                chPrev = ch2;
                ch2 = ll8[tPos];
                tPos = tt[tPos];
                if (rNToGo == 0)
                {
                    rNToGo = FastBZip2InputConstants.RandomNumbers[rTPos];
                    rTPos++;
                    if (rTPos == 512)
                    {
                        rTPos = 0;
                    }
                }
                rNToGo--;
                ch2 ^= (int)((rNToGo == 1) ? 1 : 0);
                i2++;

                currentChar = ch2;
                currentState = RAND_PART_B_STATE;
                mCrc.Update(ch2);
            }
            else
            {
                goto EndBlock;
            }
        }
        goto Exit;

    SetupNoRandPartA:
        {
            if (i2 <= last)
            {
                chPrev = ch2;
                ch2 = ll8[tPos];
                tPos = tt[tPos];
                i2++;

                currentChar = ch2;
                currentState = NO_RAND_PART_B_STATE;
                mCrc.Update(ch2);
            }
            else
            {
                goto EndBlock;
            }
        }
        goto Exit;

    SetupBlock:
        {

            int value = 0;
            for (int i = 0; i < 256; i++)
            {
                cftab[i] = value;
                value += unzftab[i];
            }

            cftab[256] = value;

            for (int i = 0; i <= last; i++)
            {
                byte ch = ll8[i];
                tt[cftab[ch]] = i;
                cftab[ch]++;
            }

            tPos = tt[origPtr];

            count = 0;
            i2 = 0;
            ch2 = 256;   /*-- not a char and not EOF --*/

            if (blockRandomised)
            {
                rNToGo = 0;
                rTPos = 0;
                goto SetupRandPartA;
            }
            else
            {
                goto SetupNoRandPartA;
            }
        }
        goto Exit;

        InitBlock:
        {
            char magic1 = BsGetUChar();
            char magic2 = BsGetUChar();
            char magic3 = BsGetUChar();
            char magic4 = BsGetUChar();
            char magic5 = BsGetUChar();
            char magic6 = BsGetUChar();

            if (magic1 == 0x17 && magic2 == 0x72 && magic3 == 0x45 && magic4 == 0x38 && magic5 == 0x50 && magic6 == 0x90)
            {
                storedCombinedCRC = BsGetInt32();
                if (storedCombinedCRC != (int)computedCombinedCRC)
                {
                    CrcError();
                }

                goto LoopBreak;
            }

            if (magic1 != 0x31 || magic2 != 0x41 || magic3 != 0x59 || magic4 != 0x26 || magic5 != 0x53 || magic6 != 0x59)
            {
                BadBlockHeader();

                goto LoopBreak; //unreachable
            }

            storedBlockCRC = BsGetInt32();

            blockRandomised = (BsR(1) == 1);

            GetAndMoveToFrontDecode();

            mCrc.Reset();
            currentState = START_BLOCK_STATE;
        }
        goto SetupBlock;

        EndBlock:
        {
            computedBlockCRC = (int)mCrc.Value;

            // -- A bad CRC is considered a fatal error. --
            if (storedBlockCRC != computedBlockCRC)
            {
                CrcError();
            }

            // 1528150659
            computedCombinedCRC = ((computedCombinedCRC << 1) & 0xFFFFFFFF) | (computedCombinedCRC >> 31);
            computedCombinedCRC = computedCombinedCRC ^ (uint)computedBlockCRC;
        }
        goto InitBlock;
    }   
}
