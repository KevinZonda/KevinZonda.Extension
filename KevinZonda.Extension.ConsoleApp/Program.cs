using KevinZonda.Extension.Syntax.TypeSyntax;
using KevinZonda.Extension.DataStructure.DFA;

// double machine
// 0 -(+|-)-> 1
// 0 -\d   -> 1
// 1 -\d   -> 1
// 1 -.    -> 2
// 2 -\d   -> 3
// 3 -\d   -> 3
var n0 = new DFAState<char>('0');
var n1 = new DFAState<char>('1');
var n2 = new DFAState<char>('2');
var n3 = new DFASuccessState<char>('2');
n0.Transitions = autoMathTable(n1);
n0.Transitions['+'] = n1;
n0.Transitions['-'] = n1;
n1.Transitions = autoMathTable(n1);
n1.Transitions['.'] = n2;
n2.Transitions = n3.Transitions = autoMathTable(n3);


Dictionary<T, DFAState<T>> autoTransTable<T>(DFAState<T> target, params T[] p)
{
    var d = new Dictionary<T, DFAState<T>>();
    foreach (var  t in p)
    {
        d[t] = target;
    }
    return d;
}

Dictionary<char, DFAState<char>> autoMathTable(DFAState<char> target)
{
    return autoTransTable(target, '0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
}

var dfa = new DFAInstance<char>(n0);

Console.WriteLine(dfa.Matches("+1.1".ToCharArray()));
Console.WriteLine(dfa.Matches("1.1".ToCharArray()));
Console.WriteLine(dfa.Matches("x.1".ToCharArray()));
Console.WriteLine(dfa.Matches("-1.1".ToCharArray()));
Console.WriteLine(dfa.Matches("+1.1x".ToCharArray()));


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