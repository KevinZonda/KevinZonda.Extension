namespace KevinZonda.Extension.Syntax;

public static class Python
{
    public static T? PassValue<T>(T? value, bool throwEx = false)
    {
        if (throwEx) throw new NotImplementedException();
        return value;
    }

    public static dynamic? PassNull(bool throwEx = false)
    {
        if (throwEx) throw new NotImplementedException();
        return null;
    }

    public static dynamic PassNotNull(bool throwEx = false)
    {
        if (throwEx) throw new NotImplementedException();
        return 1;
    }

    public static int[] Range(int x)
    {
        return Enumerable.Range(0, x).ToArray();
    }

    public static int[] Range(int left, int right)
    {
        return Enumerable.Range(left, right).ToArray();
    }
}
