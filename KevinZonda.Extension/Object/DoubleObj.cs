using System;
using System.Linq;

namespace KevinZonda.Extension.Object;

public class DoubleObj : BaseObj<double>
{
    public DoubleObj(double v) : base(v)
    {

    }
    

    public static implicit operator double(DoubleObj d) => d._in;
    public static implicit operator DoubleObj(double b) => new DoubleObj(b);
}
