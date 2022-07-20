using System;
using System.Linq;
using System.Text;

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

    public static void Panic(string s)
    {
        throw new Exception(s);
    }

    public static string String(byte[] b)
    {
        return Encoding.UTF8.GetString(b);
    }

    public static string String(Rune[] b)
    {
        var sb = new StringBuilder();
        foreach (var r in b)
        {
            sb.Append(r);
        }
        return sb.ToString();
    }

    public static int Atoi(string s)
    {
        return int.Parse(s);
    }

    public static string Itoa(int i)
    {
        return i.ToString();
    }

    public static bool HasPrefix(string s, string prefix)
    {
        return s.StartsWith(prefix);
    }

    public static bool HasSuffix(string s, string suffix)
    {
        return s.EndsWith(suffix);
    }
}
