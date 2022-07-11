namespace KevinZonda.Extension.Syntax.Haskell;

public static class Funcs<T>
{
    public readonly static Func<T[], T> Head = new(l => Methods.Head(l));

    public readonly static Func<T[], T[]> Tail = new(l => Methods.Tail(l));

    public readonly static Func<T[], T[]> Reverse = new(l => Methods.Reverse(l));

    public readonly static Func<dynamic, dynamic, T[]> PlusPlus = new((x, y) => Methods.PlusPlus(x, y));

    public readonly static Func<T[], Func<T, bool>, T[]> Where = new((a, xs) => Methods.Where(a, xs));
}