namespace KevinZonda.Extension.DataStructure.DFA;


public class DFAFailedState<T> : DFAState<T> where T : notnull
{
    public DFAFailedState(string label = "", Dictionary<T, DFAState<T>>? states = null)
        : base(label, states)
    {
    }

    public override DFAState<T> NextState(T value)
    {
        if (Transitions == null || Transitions.Count == 0) return this;
        return base.NextState(value);
    }

    public override DFAStateType Type => DFAStateType.Failed;
}

public class DFASuccessState<T> : DFAState<T> where T : notnull
{
    public DFASuccessState(string label = "", Dictionary<T, DFAState<T>>? states = null)
        : base(label, states)
    {
    }

    public override DFAStateType Type => DFAStateType.Success;
}
