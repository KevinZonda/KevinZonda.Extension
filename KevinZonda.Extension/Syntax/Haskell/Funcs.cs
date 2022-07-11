namespace KevinZonda.Extension.Syntax.Haskell;

public static class Funcs<T>
{
    public static Func<T[], T> Head = new(l => Methods.Head(l));

    public static Func<T[], T[]> Tail = new(l => Methods.Tail(l));

    public static Func<T[], T[]> Reverse = new(l => Methods.Reverse(l));

    public static Func<dynamic, dynamic, T[]> PlusPlus = new((x, y) => Methods.PlusPlus(x, y));
}