namespace KevinZonda.Extension;

public static class ActionExt
{
    public static Action Apply<T1>(this Action<T1> Action, T1 arg1)
    {
        return new Action(() => Action(arg1));
    }

    public static Action<T2> Apply<T1, T2>(this Action<T1, T2> Action, T1 arg1)
    {
        return new Action<T2>((arg2) => Action(arg1, arg2));
    }

    public static Action Apply<T1, T2>(this Action<T1, T2> Action, T1 arg1, T2 arg2)
    {
        return new Action(() => Action(arg1, arg2));
    }

    public static Action<T2, T3> Apply<T1, T2, T3>(this Action<T1, T2, T3> Action, T1 arg1)
    {
        return new Action<T2, T3>((arg2, arg3) => Action(arg1, arg2, arg3));
    }

    public static Action<T3> Apply<T1, T2, T3>(this Action<T1, T2, T3> Action, T1 arg1, T2 arg2)
    {
        return new Action<T3>(arg3 => Action(arg1, arg2, arg3));
    }

    public static Action Apply<T1, T2, T3>(this Action<T1, T2, T3> Action, T1 arg1, T2 arg2, T3 arg3)
    {
        return new Action(() => Action(arg1, arg2, arg3));
    }

    public static Action<T2, T3, T4> Apply<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Action, T1 arg1)
    {
        return new Action<T2, T3, T4>((arg2, arg3, arg4) => Action(arg1, arg2, arg3, arg4));
    }

    public static Action<T3, T4> Apply<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Action, T1 arg1, T2 arg2)
    {
        return new Action<T3, T4>((arg3, arg4) => Action(arg1, arg2, arg3, arg4));
    }

    public static Action<T4> Apply<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Action, T1 arg1, T2 arg2, T3 arg3)
    {
        return new Action<T4>(arg4 => Action(arg1, arg2, arg3, arg4));
    }

    public static Action Apply<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        return new Action(() => Action(arg1, arg2, arg3, arg4));
    }
}

