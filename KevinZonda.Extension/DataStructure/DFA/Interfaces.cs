namespace KevinZonda.Extension.DataStructure.DFA;

public interface INextStatable<T> where T : notnull
{
    public DFAState<T> NextState(T value);
}