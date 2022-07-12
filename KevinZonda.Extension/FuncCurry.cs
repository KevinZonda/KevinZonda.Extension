namespace KevinZonda.Extension;

public static class FuncCurry
{
    public static Func<T1, Func<T2, R>> Curry<T1, T2, R>(this Func<T1, T2, R> func)
    {
        return new(
            arg1 => new(
                arg2 => func(arg1, arg2)
                )
            );
    }

    public static Func<T1, Func<T2, Func<T3, R>>> Curry<T1, T2, T3, R>(this Func<T1, T2, T3, R> func)
    {
        return new(
            arg1 => new(
                arg2 => new(
                    arg3 => func(arg1, arg2, arg3)
                    )
                )
            );
    }

    public static Func<T1, Func<T2, Func<T3, Func<T4, R>>>> Curry<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func)
    {
        return new(
            arg1 => new(
                arg2 => new(
                    arg3 => new(
                        arg4 => func(arg1, arg2, arg3, arg4)
                        )
                    )
                )
            );
    }

    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, R>>>>> Curry<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> func)
    {
        return new(
            arg1 => new(
                arg2 => new(
                    arg3 => new(
                        arg4 => new(
                            arg5 => func(arg1, arg2, arg3, arg4, arg5)
                            )
                        )
                    )
                )
            );
    }
}
