using System;
using System.Linq;

namespace KevinZonda.Extension;
public static class ArrayExt
{
    public static T? SafeIndex<T>(this T[] arr, int index)
    {
        if (arr == null) return default;
        if (index < 0 || index >= arr.Length) return default;
        return arr[index];
    }

    public static string[] SafeTrim(this string[] arr)
    {
        if (arr == null) return Array.Empty<string>();
        return arr.Select(s => s.Trim()).ToArray();
    }

    public static T[] Append<T>(T[] x, T[] y)
    {
        var z = new T[x.Length + y.Length];
        x.CopyTo(z, 0);
        y.CopyTo(z, x.Length);
        return z;
    }

    public static T[] Append<T>(T x, T[] y)
    {
        var z = new T[1 + y.Length];
        z[0] = x;
        y.CopyTo(z, 1);
        return z;
    }

    public static T[] Append<T>(T[] x, T y)
    {
        var z = new T[x.Length + 1];
        x.CopyTo(z, 0);
        z[x.Length] = y;
        return z;
    }

    public static T[] Append<T>(T x, T y)
    {
        return new[] { x, y };
    }

}
