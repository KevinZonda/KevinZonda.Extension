using KevinZonda.Extension;

namespace KevinZonda.Extension.Syntax.Haskell;

public static class Methods
{
    public static T Head<T>(T[] list)
    {
        return list[0];
    }

    public static T[] Tail<T>(T[] list)
    {
        if (list.Length > 1)
            return list[1..];
        return Array.Empty<T>();
    }

    public static T[] Reverse<T>(T[] list)
    {
        T[] result = new T[list.Length];
        for (int i = 0; i < list.Length; ++i)
        {
            result[list.Length - 1] = list[i];
        }
        return result;
    }

    public static T[] PlusPlus<T>(T[] x, T[] y)
    {
        return ArrayExt.Append(x, y);
    }

    public static T[] PlusPlus<T>(T x, T[] y)
    {
        return ArrayExt.Append(x, y);
    }

    public static T[] PlusPlus<T>(T[] x, T y)
    {
        return ArrayExt.Append(x, y);
    }

    public static T[] PlusPlus<T>(T x, T y)
    {
        return ArrayExt.Append(x, y);
    }

    public static T[] PlusPlusDynamic<T>(dynamic x, dynamic y)
    {
        List<T> l = new();
        Type typeT = typeof(T);
        Type typeTArr = typeof(T[]);
        Type typeX = x.GetType();
        if (typeX == typeT)
        {
            T t = DynamicExt.ConvertType(x);
            l.Add(t);
        }
        else if (typeX == typeTArr)
        {
            T[] t = DynamicExt.ConvertType(x);
            l.AddRange(t);
        }        else
        {
            throw new ArrayTypeMismatchException($"Expected {typeT}, get {typeX}");
        }
        Type typeY = y.GetType();
        if (typeY == typeT)
        {
            T t = DynamicExt.ConvertType(y);
            l.Add(t);
        }
        else if (typeY == typeTArr)
        {
            T[] t = DynamicExt.ConvertType(y);
            l.AddRange(t);
        }
        else
        {
            throw new ArrayTypeMismatchException($"Expected {typeT}, get {typeY}");
        }
        return l.ToArray();
    }
}
