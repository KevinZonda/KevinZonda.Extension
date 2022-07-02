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

}
