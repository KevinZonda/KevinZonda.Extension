using System;
using System.Linq;

namespace KevinZonda.Extension.Object;

public class IntObj : BaseObj<int>
{
    public IntObj(int v) : base(v)
    {

    }


    public static implicit operator int(IntObj d) => d._in;
    public static implicit operator IntObj(int b) => new IntObj(b);
}
