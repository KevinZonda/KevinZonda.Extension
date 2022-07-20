using System;
using System.Linq;

namespace KevinZonda.Extension.Interfaces;

public interface IConvertible<T>
{
    public T Convert();
}
