namespace KevinZonda.Extension.Utils;

public class BinaryStateManagement
{
    public static int SetState(int source, int shift, bool value)
    {
        var state = IsState(source, shift);
        return state == value
            ? source
            : state
                ? RemoveState(source, shift)
                : AddState(source, shift);
    }
    public static bool IsState(int source, int shift)
    {
        // 1 & 1 -> 1
        // 0 & 1 -> 0
        return (source & 1 << shift) != 0;
    }

    public static int AddState(int source, int shift)
    {
        // 1 | 0 -> 1
        // 1 | 1 -> 1
        return source | (1 << shift);
    }

    public static int RemoveState(int source, int shift)
    {
        //        src = 100101
        //        sft = 000100
        //       ~sft = 111011
        // src & ~sft = 100001
        source &= ~(1 << shift);
        return source;
    }

    public static int ReverseState(int source, int shift)
    {
        // XOR
        // 1 ^ 0 -> 1
        // 0 ^ 0 == 1 ^ 1 = 0
        // Ex 1
        //       src = 100101
        //       sft = 000100
        // src ^ sft = 100001
        // Ex 1
        //       src = 100101
        //       sft = 000010
        // src ^ sft = 100111
        return source ^ (1 << shift);
    }
}
