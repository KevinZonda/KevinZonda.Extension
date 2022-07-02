using System;
using System.Linq;

namespace KevinZonda.Extension
{
    public static class ListExt
    {
        public static T[] SafeToArray<T>(this List<T> l)
        {
            if (l == null) return Array.Empty<T>();
            return l.ToArray();
        }

        public static T? SafeIndex<T>(this List<T> arr, int index, T? ifOutOfBound = default)
        {
            if (arr == null) return ifOutOfBound;
            if (index < 0 || index >= arr.Count) return ifOutOfBound;
            return arr[index];
        }

        public static IEnumerable<string> SelectTrimmed(this List<string> arr)
        {
            if (arr == null) return new List<string>();
            return arr.Select(s => s.Trim()).ToList();
        }

        public static IEnumerable<string> SelectNotEmptyEntity(this List<string> s)
        {
            if (s == null) return new List<string>();
            return s.Where(s => !string.IsNullOrEmpty(s));
        }

        public static int RemoveNullOrEmpty(this List<string> s)
        {
            if (s == null) return -1;
            return s.RemoveAll(x => string.IsNullOrEmpty(x));
        }

        public static int RemoveNullOrWhiteSpace(this List<string> s)
        {
            if (s == null) return -1;
            return s.RemoveAll(x => string.IsNullOrWhiteSpace(x));
        }

        public static int RemoveNull<T>(this List<T> s)
        {
            if (s == null) return -1;
            return s.RemoveAll(x => x == null);
        }

        public static bool AddIfNotNull<T>(this List<T> l, T? newVal)
        {
            if (newVal == null) return false;
            var x = l.Where(item => !item.IsNull())
                                  .Select(item => item);
            return true;
        }
    }
}
