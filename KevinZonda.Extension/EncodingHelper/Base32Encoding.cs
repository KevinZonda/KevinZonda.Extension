﻿using System;
using System.Linq;

namespace KevinZonda.Extension.EncodingHelper;

public class Base32Encoding
{
    public static string GetString(string input)
    {
        return System.Text.Encoding.UTF8.GetString(GetBytes(input));
    }

    public static byte[] GetBytes(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException("input");

        input = input.TrimEnd('='); //remove padding characters
        int byteCount = input.Length * 5 / 8; //this must be TRUNCATED
        byte[] returnArray = new byte[byteCount];

        byte curByte = 0, bitsRemaining = 8;
        int mask = 0, arrayIndex = 0;

        foreach (char c in input)
        {
            int cValue = CharToValue(c);

            if (bitsRemaining > 5)
            {
                mask = cValue << (bitsRemaining - 5);
                curByte = (byte)(curByte | mask);
                bitsRemaining -= 5;
            }
            else
            {
                mask = cValue >> (5 - bitsRemaining);
                curByte = (byte)(curByte | mask);
                returnArray[arrayIndex++] = curByte;
                curByte = (byte)(cValue << (3 + bitsRemaining));
                bitsRemaining += 3;
            }
        }

        //if we didn't end with a full byte
        if (arrayIndex != byteCount)
            returnArray[arrayIndex] = curByte;

        return returnArray;
    }


    private static int CharToValue(char c)
    {
        int value = (int)c;

        //65-90 == uppercase letters
        if (value < 91 && value > 64) return value - 65;
        //50-55 == numbers 2-7
        if (value < 56 && value > 49) return value - 24;

        //97-122 == lowercase letters
        if (value < 123 && value > 96) return value - 97;

        throw new ArgumentException("Character is not a Base32 character.", "c");
    }
}
