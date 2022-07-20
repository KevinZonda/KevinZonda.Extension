using System;
using System.Linq;

namespace KevinZonda.Extension.Utils;

public static class General
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    
    public static string GetBinary(int t)
    {
        return Convert.ToString(t, 2);
    }

    public static string GetBinary(short t)
    {
        return Convert.ToString(t, 2);
    }

    public static string GetBinary(long t)
    {
        return Convert.ToString(t, 2);
    }

    public static string GetBinary(char t)
    {
        return Convert.ToString(t, 2);
    }
}
