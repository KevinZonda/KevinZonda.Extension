using System;
using System.Linq;
using System.Text;

namespace KevinZonda.Extension;
public static class ArrayExt
{
    /// <summary>
    /// if out of bound, return defaultValue
    /// </summary>
    public static T? SafeIndex<T>(this T[] arr, int index, T? defaultValue = default)
    {
        if (arr == null) return default;
        if (index < 0 || index >= arr.Length) return defaultValue;
        return arr[index];
    }

    public static string[] SafeTrim(this string[] arr)
    {
        if (arr == null) return Array.Empty<string>();
        return arr.Select(s => s.Trim()).ToArray();
    }

    /// <summary>
    /// if index is neg, will return len + index
    /// </summary>
    public static T SmartIndex<T>(this T[] arr, int index)
    {
        return index >= 0 ? arr[index] : arr[arr.Length + index];
    }

    public static T? SmartSafeIndex<T>(this T[] arr, int index, T? defaultValue = default)
    {
        var nI = index >= 0 ? index : arr.Length + index;
        return arr.SafeIndex(nI);
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

    public static string ToUtf8String(this byte[] b)
    {
        return Encoding.UTF8.GetString(b);
    }
}
