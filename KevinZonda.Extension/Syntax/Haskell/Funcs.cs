namespace KevinZonda.Extension.Syntax.Haskell;

public static class Funcs<T>
{
    public readonly static Func<T[], T> Head = l => Methods.Head(l);

    public readonly static Func<T[], T[]> Tail = l => Methods.Tail(l);

    public readonly static Func<T[], T[]> Reverse = l => Methods.Reverse(l);

    public readonly static Func<dynamic, dynamic, T[]> PlusPlus = (x, y) => Methods.PlusPlus(x, y);

    public readonly static Func<T[], Func<T, bool>, T[]> Where = (a, xs) => Methods.Where(a, xs);

    public readonly static Action<object> PutStrLn = (obj) => Methods.PutStrLn(obj);

    public readonly static Action<object> PutStr = (obj) => Methods.PutStr(obj);

    public readonly static Action<Func<bool>, Action, Action> IfThenElse = (condition, ifThen, ifElse) => Methods.IfThenElse(condition, ifThen, ifElse);

    public readonly static Action<Func<bool>, Action> IfThen = (condition, ifThen) => Methods.IfThen(condition, ifThen);
}