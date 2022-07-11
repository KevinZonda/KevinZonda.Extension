using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinZonda.Extension;

public static class DynamicExt
{
    public static dynamic ConvertType(dynamic obj, Type t)
    {
        return Convert.ChangeType(obj, t);
    }

    public static dynamic ConvertType<T>(dynamic obj)
    {
        return ConvertType(obj, typeof(T));
    }
}
