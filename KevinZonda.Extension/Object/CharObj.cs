using System;
using System.Linq;

namespace KevinZonda.Extension.Object;

public class CharObj : BaseObj<char>
{
    public CharObj(char v) : base(v)
    {

    }


    public static implicit operator char(CharObj d) => d._in;
    public static implicit operator CharObj(char b) => new CharObj(b);
}
