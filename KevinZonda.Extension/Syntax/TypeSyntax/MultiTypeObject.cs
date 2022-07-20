using System;

namespace KevinZonda.Extension.Syntax.TypeSyntax;

public class MultiTypeObject
{
    private dynamic? _obj;
    private Type[] _typeList;
    private Type? _currentType;

    public bool IsNull => _obj == null;

    public MultiTypeObject(dynamic obj, List<Type> typeList)
    {
        this._obj = obj;
        _currentType = obj.GetType();
        _typeList = typeList.ToArray();
        if (!IsSupportedType(_currentType))
            throw new InvalidOperationException("Not supported type");
    }

    public MultiTypeObject(dynamic obj, params Type[] types)
    {
        this._obj = obj;
        _currentType = obj.GetType();
        _typeList = types;
        if (!IsSupportedType(_currentType))
            throw new InvalidOperationException("Not supported type");
    }

    public MultiTypeObject(params Type[] types)
    {
        _typeList = types;
    }

    public bool IsSupportedType(Type t)
    {
        return _typeList.Contains(t);
    }

    public new Type? GetType()
    {
        return _currentType;
    }

    public bool SetValueT<T>(T v, bool autoFallBack = true, bool throwExIfFailed = true)
    {
        bool rst = SetValueBool(v, autoFallBack);
        if (!rst && throwExIfFailed)
            throw new InvalidOperationException("Not Valid Type");
        return rst;
    }


    public bool SetValue(dynamic v, bool autoFallBack = true, bool throwExIfFailed = true)
    {
        bool rst = SetValueBool(v, autoFallBack);
        if (!rst && throwExIfFailed)
            throw new InvalidOperationException("Not Valid Type");
        return rst;
    }

    private bool SetValueBool(dynamic v, bool autoFallBack = true)
    {
        Type t = v.GetType();
        if (!_typeList.Contains(t))
        {
            if (!autoFallBack) return false;
            foreach (Type _type in _typeList)
            {
                if (_type.IsAssignableFrom(t))
                {
                    _currentType = _type;
                    _obj = v;
                    return true;
                }
            }
            return false;
        }
        _obj = v;
        _currentType = t;
        return true;
    }

    public T GetValue<T>() => (T)GetValue(typeof(T));

    public object GetValue(Type t)
    {
        if (IsNull) throw new NullReferenceException();
        if (_currentType == t) return _obj!;
        if (_currentType!.IsSubclassOf(t)) return _obj!;
        return DynamicExt.ConvertType(_obj, t);
    }

    public bool TryGetValue<T>(ref T v)
    {
        if (IsNull) return false;
        if (!IsType<T>()) return false;
        v = (T)_obj!;
        return true;
    }

    public bool IsType(Type t)
    {
        if (IsNull) return false;
        if (_currentType == t) return true;
        return _currentType!.IsSubclassOf(t);
    }

    public bool IsType<T>() => IsType(typeof(T));
}
