namespace KevinZonda.Extension;

public static class NullExt
{
    public static bool IsNull<T>(this T? v)
    {
        return v == null;
    }

    public static void EnsureNull<T>(this T? v)
    {
        if (v == null)
        {
            throw new NullReferenceException(nameof(v));
        }
    }

    public static T IfNull<T>(this T? v, T ifNull)
    {
        return v ?? ifNull;
    }

    public static T IfNull<T>(this T? v, Func<T> ifNull)
    {
        if (v == null) return ifNull();
        return v;
    }

    public static T? IfNotNull<T>(this T? v, Func<T, T> ifNotNull)
    {
        if (v == null) return v;
        return ifNotNull(v);
    }

    public static T? IfNotNull<T>(this T? v, T? ifNotNull)
    {
        if (v == null) return v;
        return ifNotNull;
    }

    public static R IfNullElse<T, R>(this T? v, R ifNull, R ifNotNull)
    {
        if (v == null) return ifNull;
        return ifNotNull;
    }

    public static R IfNullElse<T, R>(this T? v, R ifNull, Func<R> ifNotNull)
    {
        if (v == null) return ifNull;
        return ifNotNull();
    }

    public static R IfNullElse<T, R>(this T? v, R ifNull, Func<T, R> ifNotNull)
    {
        if (v == null) return ifNull;
        return ifNotNull(v);
    }
}
