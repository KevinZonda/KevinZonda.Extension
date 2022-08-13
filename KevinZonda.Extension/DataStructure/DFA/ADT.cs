namespace KevinZonda.Extension.DataStructure.DFA;

public class DFAState<T> : INextStatable<T> where T : notnull
{
    public string Label { get; }
    public virtual DFAStateType Type => DFAStateType.Normal;

    public bool IsSuccess => Type == DFAStateType.Success;
    public bool IsFailed => !IsSuccess;

    public Dictionary<T, DFAState<T>>? Transitions { get; set; }

    private static DFAFailedState<T>? _failedState = null;

    public virtual DFAState<T> NextState(T value)
    {

        if (Transitions is not null && Transitions.ContainsKey(value))
            return Transitions[value];
        if (_failedState == null) _failedState =
                new(default);
        return _failedState;
    }

    public DFAState(string label = "", Dictionary<T, DFAState<T>>? states = null)
    {
        Label = label;
        Transitions = states;
    }
}