namespace KevinZonda.Extension.Syntax;

public static class Python
{
    public static T? Pass<T>(T? value)
    {
        return value;
    }

    public static dynamic? Pass()
    {
        return null;
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
