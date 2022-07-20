using System;
using System.Linq;

namespace KevinZonda.Extension.Syntax.TypeSyntax;

internal class MultiTypeObject<T1, T2> : MultiTypeObject
{
    public MultiTypeObject() : base(typeof(T1), typeof(T2))
    {
    }

    public MultiTypeObject(T1 t) : base(t, typeof(T1), typeof(T2))
    {
    }
    
    public MultiTypeObject(T2 t) : base(t, typeof(T1), typeof(T2))
    {
    }

    public static implicit operator MultiTypeObject<T1, T2>(T1 t)
    {
        return new MultiTypeObject<T1, T2>(t);
    }

    public static implicit operator MultiTypeObject<T1, T2>(T2 t)
    {
        return new MultiTypeObject<T1, T2>(t);
    }

    public static explicit operator T1(MultiTypeObject<T1, T2> t)
    {
        return t.GetValue<T1>();
    }

    public static explicit operator T2(MultiTypeObject<T1, T2> t)
    {
        return t.GetValue<T2>();
    }
}
