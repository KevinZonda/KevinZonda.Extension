namespace KevinZonda.Extension.DataStructure.DFA;

public class DFAInstance<T> : INextStatable<T> where T : notnull
{
    public DFAState<T> InitState { get; set; }
    public DFAInstance(DFAState<T> initialState)
    {
        InitState = initialState;
    }

    public DFAState<T> NextState(T value)
    {
        return InitState.NextState(value);
    }

    private DFAState<T> NextStateFromIEnum(IEnumerable<T> values)
    {
        var n = InitState;
        foreach (var t in values)
        {
            n = n.NextState(t);
        }
        return n;
    }

    public DFAState<T> NextStates(params T[] values)
    {
        return NextStateFromIEnum(values);
    }

    public DFAState<T> NextStates(IEnumerable<T> values)
    {
        return NextStateFromIEnum(values);
    }

    public bool Matches(IEnumerable<T> values)
    {
        return NextStateFromIEnum(values).IsSuccess;
    }

    public bool Matches(params T[] values)
    {
        return NextStateFromIEnum(values).IsSuccess;
    }
}

