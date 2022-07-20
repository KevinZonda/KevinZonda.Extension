namespace KevinZonda.Extension.Syntax.TypeSyntax;

public class MultiTypeObject
{
    private dynamic _obj;
    private List<Type> _typeList;
    private Type _currentType;

    public MultiTypeObject(dynamic obj, List<Type> typeList)
    {
        this._obj = obj;
        _currentType = obj.GetType();
        _typeList = typeList;
        if (!IsSupportedType(_currentType))
            throw new InvalidOperationException("Not supported type");
    }

    public MultiTypeObject(dynamic obj, params Type[] types)
    {
        this._obj = obj;
        _currentType = obj.GetType();
        _typeList = types.ToList();
        if (!IsSupportedType(_currentType))
            throw new InvalidOperationException("Not supported type");
    }

    public MultiTypeObject(params Type[] types)
    {
        _currentType = types[0];
        _typeList = types.ToList();
        if (!IsSupportedType(_currentType))
            throw new InvalidOperationException("Not supported type");
    }

    public bool IsSupportedType(Type t)
    {
        return _typeList.Contains(t);
    }

    public new Type GetType()
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

    public T GetValue<T>()
    {
        if (_currentType == typeof(T)) return (T)_obj;
        if (_obj is T t) return t;
        if (_currentType.IsSubclassOf(typeof(T))) return (T)_obj;

        return DynamicExt.ConvertType(_obj, typeof(T));
        //throw new InvalidOperationException("Not supported type");
    }

    public object GetValue(Type t)
    {
        if (_currentType == t) return (object)_obj;
        if (_currentType.IsSubclassOf(t)) return (object)_obj;
        return DynamicExt.ConvertType(_obj, t);
    }

    public bool IsType(Type t)
    {
        if (_currentType == t)
        {
            return true;
        }
        return _currentType.IsSubclassOf(t);
    }

    public bool IsType<T>()
    {
        var t = typeof(T);
        if (_currentType == t)
        {
            return true;
        }
        return _currentType.IsSubclassOf(t);
    }
}
