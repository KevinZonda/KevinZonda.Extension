using System;
using System.Linq;

namespace KevinZonda.Extension.Syntax;

public static class CSharp
{
    public static (bool IsOk, T? Result, Exception? Ex) TryEx<T>(this Func<T> tryFunc)
    {
        try
        {
            var l = tryFunc();
            return (true, l, null);
        }
        catch (Exception ex)
        {
            return (false, default(T), ex);
        }
    }

    public static T? Try<T>(this Func<T> tryFunc)
    {
        try
        {
            return tryFunc();
        }
        catch
        {
            return default;
        }
    }

    public static T? TryCatch<T>(this Func<T> tryFunc, Func<Exception, T> catchFunc)
    {
        try
        {
            return tryFunc();
        }
        catch (Exception ex)
        {
            return catchFunc(ex);
        }
    }

    public static (bool IsOk, T? Result) TryCatchEx<T>(this Func<T> tryFunc, Func<Exception, T> catchFunc)
    {
        try
        {
            return (true, tryFunc());
        }
        catch (Exception ex)
        {
            return (false, catchFunc(ex));
        }
    }
}

