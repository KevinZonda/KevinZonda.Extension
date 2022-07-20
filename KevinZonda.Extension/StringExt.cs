using System;
using System.Linq;

namespace KevinZonda.Extension;
public static class StringExt
{
    public static bool IsNullOrEmpty(this string s)
    {
        return string.IsNullOrEmpty(s);
    }

    public static bool IsNullOrWhiteSpace(this string s)
    {
        return string.IsNullOrWhiteSpace(s);
    }

    public static int Count(this string s, char ch)
    {
        int counter = 0;
        foreach (var c in s)
        {
            if (c == ch) ++counter;
        }
        return counter;
    }
    public static int Count(this string s, string ss)
    {
        int count = 0, minIndex = s.IndexOf(ss, 0);
        while (minIndex != -1)
        {
            minIndex = s.IndexOf(ss, minIndex + ss.Length);
            ++count;
        }
        return count;
    }
}
