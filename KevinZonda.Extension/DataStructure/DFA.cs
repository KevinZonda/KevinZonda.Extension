namespace KevinZonda.Extension.DataStructure;

public class DFA<T> : INextStatable<T> where T : notnull
{
    public DFANormalState<T> InitState { get; set; }
    public DFA(DFANormalState<T> initialState)
    {
        InitState = initialState;
    }

    public DFANormalState<T> NextState(T value)
    {
        return InitState.NextState(value);
    }

    private DFANormalState<T> NextStateFromIEnum(IEnumerable<T> values)
    {
        var n = InitState;
        foreach (var t in values)
        {
            n = n.NextState(t);
        }
        return n;
    }

    public DFANormalState<T> NextStates(params T[] values)
    {
        return NextStateFromIEnum(values);
    }

    public DFANormalState<T> NextStates(IEnumerable<T> values)
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

public enum DFAStateType
{
    Failed,
    Normal,
    Success
}

public class DFANormalState<T> : INextStatable<T> where T : notnull
{
    public T Value { get; }
    public virtual DFAStateType Type => DFAStateType.Normal;

    public bool IsSuccess => Type == DFAStateType.Success;
    public bool IsFailed => !IsSuccess;

    public Dictionary<T, DFANormalState<T>>? States { get; set; }

    private static DFANormalState<T>? _failedState = null;

    public virtual DFANormalState<T> NextState(T value)
    {
        
        if (States is not null && States.ContainsKey(value))
            return States[value];
        if (_failedState == null) _failedState =
                new DFAFailedState<T>(default);
        return _failedState;
    }

    public DFANormalState(T value, Dictionary<T, DFANormalState<T>>? states = null)
    {
        Value = value;
        States = states;
    }
}

public class DFAFailedState<T> : DFANormalState<T> where T : notnull
{
    public DFAFailedState(T value, Dictionary<T, DFANormalState<T>>? states = null) 
        : base(value, states)
    {
    }

    public override DFANormalState<T> NextState(T value)
    {
        if (States == null || States.Count == 0) return this;
        return base.NextState(value);
    }

    public override DFAStateType Type => DFAStateType.Failed;
}

public class DFASuccessState<T> : DFANormalState<T> where T : notnull
{
    public DFASuccessState(T value, Dictionary<T, DFANormalState<T>>? states = null) 
        : base(value, states)
    {
    }

    public override DFAStateType Type => DFAStateType.Success;
}

public interface INextStatable<T> where T : notnull
{
    public DFANormalState<T> NextState(T value);
}