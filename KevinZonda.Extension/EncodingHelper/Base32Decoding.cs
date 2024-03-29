﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinZonda.Extension.EncodingHelper;

public class Base32Decoding
{
    public static string GetString(string input)
    {
        return GetString(Encoding.UTF8.GetBytes(input));
    }
    public static string GetString(byte[] input)
    {
        if (input == null || input.Length == 0)
            throw new ArgumentNullException("input");

        int charCount = (int)Math.Ceiling(input.Length / 5d) * 8;
        char[] returnArray = new char[charCount];

        byte nextChar = 0, bitsRemaining = 5;
        int arrayIndex = 0;

        foreach (byte b in input)
        {
            nextChar = (byte)(nextChar | (b >> (8 - bitsRemaining)));
            returnArray[arrayIndex++] = ValueToChar(nextChar);

            if (bitsRemaining < 4)
            {
                nextChar = (byte)((b >> (3 - bitsRemaining)) & 31);
                returnArray[arrayIndex++] = ValueToChar(nextChar);
                bitsRemaining += 5;
            }

            bitsRemaining -= 3;
            nextChar = (byte)((b << bitsRemaining) & 31);
        }

        //if we didn't end with a full char
        if (arrayIndex != charCount)
        {
            returnArray[arrayIndex++] = ValueToChar(nextChar);
            while (arrayIndex != charCount) returnArray[arrayIndex++] = '='; //padding
        }

        return new string(returnArray);
    }

    private static char ValueToChar(byte b)
    {
        if (b < 26) return (char)(b + 65);
        if (b < 32) return (char)(b + 24);
        throw new ArgumentException("Byte is not a value Base32 value.", "b");
    }
}
