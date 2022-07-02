using System;
using System.Linq;

namespace KevinZonda.Extension.Object;

public class BaseObj<T>
{
    protected T _in;

    public BaseObj(T v)
    {
        _in = v;
    }
}
