using System;
using System.Linq;

namespace KevinZonda.Extension.Object;
public class BoolObj : BaseObj<bool>
{
    public BoolObj(bool v) : base(v)
    {
    }

    public static implicit operator bool(BoolObj d) => d._in;
    public static implicit operator BoolObj(bool b) => new BoolObj(b);
}
