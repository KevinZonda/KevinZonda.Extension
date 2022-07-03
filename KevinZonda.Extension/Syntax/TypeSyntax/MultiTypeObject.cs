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

    public bool IsSupportedType(Type t)
    {
        return _typeList.Contains(t);
    }

    public new Type GetType()
    {
        return _currentType;
    }

    public bool SetValue(dynamic v)
    {
        var t = v.GetType();
        if (!_typeList.Contains(t)) return false;
        _obj = v;
        _currentType = t;
        return true;
    }

    public T GetValue<T>()
    {
        Console.WriteLine("XXXXXXXXXXXX");
        Console.WriteLine(_currentType);
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
