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
}
