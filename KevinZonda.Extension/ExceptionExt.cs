using System;
using System.Linq;

namespace KevinZonda.Extension;

public static class ExceptionExt
{
    public static bool Is<T>() where T : Exception
    {
        return typeof(T) == typeof(Exception);
    }
}
