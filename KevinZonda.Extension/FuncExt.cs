namespace KevinZonda.Extension;

public static class FuncExt
{
    public static string GetArgumentTypes<R>(this Func<R> func)
    {
        return $"() -> {typeof(R)}";
    }

    public static string GetArgumentTypes<T1, R>(this Func<T1, R> func)
    {
        return $"{typeof(T1)} -> {typeof(R)}";
    }

    public static string GetArgumentTypes<T1, T2, R>(this Func<T1, T2, R> func)
    {
        return $"{typeof(T1)} -> {typeof(T2)} -> {typeof(R)}";
    }

    public static string GetArgumentTypes<T1, T2, T3, R>(this Func<T1, T2, T3, R> func)
    {
        return $"{typeof(T1)} -> {typeof(T2)} -> {typeof(T3)} -> {typeof(R)}";
    }

    public static string GetArgumentTypes<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func)
    {
        return $"{typeof(T1)} -> {typeof(T2)} -> {typeof(T3)} -> {typeof(T4)} -> {typeof(R)}";
    }

    public static Func<R> Apply<T1, R>(this Func<T1, R> func, T1 arg1)
    {
        return new Func<R>(() => func(arg1));
    }

    public static Func<T2, R> Apply<T1, T2, R>(this Func<T1, T2, R> func, T1 arg1)
    {
        return new Func<T2, R>((arg2) => func(arg1, arg2));
    }

    public static Func<R> Apply<T1, T2, R>(this Func<T1, T2, R> func, T1 arg1, T2 arg2)
    {
        return new Func<R>(() => func(arg1, arg2));
    }

    public static Func<T2, T3, R> Apply<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T1 arg1)
    {
        return new Func<T2, T3, R>((arg2, arg3) => func(arg1, arg2, arg3));
    }

    public static Func<T3, R> Apply<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T1 arg1, T2 arg2)
    {
        return new Func<T3, R>(arg3 => func(arg1, arg2, arg3));
    }

    public static Func<R> Apply<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T1 arg1, T2 arg2, T3 arg3)
    {
        return new Func<R>(() => func(arg1, arg2, arg3));
    }

    public static Func<T2, T3, T4, R> Apply<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func, T1 arg1)
    {
        return new Func<T2, T3, T4, R>((arg2, arg3, arg4) => func(arg1, arg2, arg3, arg4));
    }

    public static Func<T3, T4, R> Apply<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func, T1 arg1, T2 arg2)
    {
        return new Func<T3, T4, R>((arg3, arg4) => func(arg1, arg2, arg3, arg4));
    }

    public static Func<T4, R> Apply<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func, T1 arg1, T2 arg2, T3 arg3)
    {
        return new Func<T4, R>(arg4 => func(arg1, arg2, arg3, arg4));
    }

    public static Func<R> Apply<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        return new Func<R>(() => func(arg1, arg2, arg3, arg4));
    }

}
