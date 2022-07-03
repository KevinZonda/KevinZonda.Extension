using KevinZonda.Extension.Syntax.TypeSyntax;

var obj1 = new A();
var obj2 = new B();
var obj3 = new C(12);

var d = new MultiTypeObject(obj3, typeof(A), typeof(C));
Console.WriteLine(d.GetType());
Console.WriteLine(d.GetValue<C>());
d.SetValue(obj2);
Console.WriteLine(d.GetType());
var a = d.GetValue<A>();
Console.WriteLine(a.X);
var b = d.GetValue<B>();
Console.WriteLine(b.Y);
d.SetValue(11);
Console.WriteLine(d.GetType());
Console.WriteLine(d.GetValue<int>());

class A
{
    public int X { get; set; } = 11;
}

class B : A
{
    public int Y { get; set; } = 17;
}

class C
{
    public C(int x)
    {
        GetValue = x;
    }
    public int GetValue { get; init; }
}