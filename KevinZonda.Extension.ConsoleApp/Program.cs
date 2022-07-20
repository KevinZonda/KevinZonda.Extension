using KevinZonda.Extension.Syntax.TypeSyntax;

var obj1 = new A();
var obj2 = new B();
var obj3 = new C(12);

var d = new MultiTypeObject<A, B, C, int>(obj3);
Console.WriteLine(d.GetType());
Console.WriteLine(d.GetValue<C>());
Console.WriteLine((C)d);
d.SetValueT(obj2, true, false);
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