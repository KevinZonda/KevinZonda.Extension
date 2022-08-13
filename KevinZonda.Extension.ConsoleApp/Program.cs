using KevinZonda.Extension.Syntax.TypeSyntax;
using KevinZonda.Extension.DataStructure;


var n = new DFANormalState<int>(1);
var n2 = new DFANormalState<int>(2);
var n3 = new DFANormalState<int>(3);
var n4 = new DFAFailedState<int>(4);
var n5 = new DFASuccessState<int>(5);

n.States = new()
{
    {1, n2 },
    {4, n5 }
};
var dfa = new DFA<int>(n);

Console.WriteLine(dfa.Matches(new[] { 4, 2, 7, 1 }));

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