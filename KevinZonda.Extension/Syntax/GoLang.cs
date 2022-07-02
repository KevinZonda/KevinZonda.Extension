using System;
using System.Linq;

namespace KevinZonda.Extension.Syntax;
public class GoLang
{
    public const dynamic? Nil = null;

    public class ResultWithErr<T>
    {
        public T? Result { get; set; }
        public Exception? Err { get; set; }

        public bool IsOk
        {
            get => Err == null;
        }

        public ResultWithErr(T reult)
        {
            Result = reult;
        }

        public ResultWithErr(Exception ex)
        {
            Err = ex;
        }

    }

    public static void Defer<T>(T obj, Action<T> defer, Action<T> oper)
    {
        try
        {
            oper(obj);
        }
        finally
        {
            defer(obj);
        }
    }

    public static void Defer<T>(T obj, Action<T> defer, Action<T> oper, Action<Exception> recover)
    {
        try
        {
            oper(obj);
        }
        catch(Exception ex)
        {
            recover(ex);
        }
        finally
        {
            defer(obj);
        }
    }

    public static Exception? Recover(Action act)
    {
        try
        {
            act();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
