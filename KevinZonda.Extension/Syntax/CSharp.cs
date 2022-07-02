using System;
using System.Linq;

using static KevinZonda.Extension.Syntax.GoLang;

namespace KevinZonda.Extension.Syntax;

public static class CSharp
{
    public static ResultWithErr<T> TryEx<T>(this Func<T> tryFunc)
    {
        try
        {
            var l = tryFunc();
            return new ResultWithErr<T>(l);
        }
        catch (Exception ex)
        {
            return new ResultWithErr<T>(ex);
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

