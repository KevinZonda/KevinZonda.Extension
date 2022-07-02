using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinZonda.Extension;

public static class TaskTExt<TResult>
{
    public static async Task<TResult> Delay(TimeSpan timeout, TResult? result = default)
    {
        await Task.Delay(timeout);
        return result;
    }

    public static async Task<TResult[]> DelayArr(TimeSpan timeout, TResult[]? result = default)
    {
        await Task.Delay(timeout);
        return result;
    }    

    public static Task<Task<TResult>> WhenAny(IEnumerable<Task<TResult>> tasks, TimeSpan timeout, TResult timeoutResult = default)
    {
        return Task<TResult>.WhenAny<TResult>(tasks.Append(Delay(timeout, timeoutResult)));
    }

    public static Task<Task<TResult>> WhenAny(TimeSpan timeout, params Task<TResult>[] tasks)
    {
        return WhenAny(tasks, timeout);
    }

    public static Task<Task<TResult>> WhenAny(Task<TResult> task1, Task<TResult> task2, TimeSpan timeout)
    {
        return WhenAny(new[] { task1, task2 }, timeout);
    }

    public static Task<Task<TResult[]>> WhenAll(IEnumerable<Task<TResult>> tasks, TimeSpan timeout)
    {
        return Task<TResult[]>.WhenAny<TResult[]>(
            Task<TResult>.WhenAll<TResult>(tasks),
            DelayArr(timeout));
    }

    public static Task<Task<TResult[]>> WhenAll(Task<TResult> task1, Task<TResult> task2, TimeSpan timeout)
    {
        return WhenAll(new[] { task1, task2 }, timeout);
    }

    public static Task<Task<TResult[]>> WhenAll(TimeSpan timeout, params Task<TResult>[] tasks)
    {
        return WhenAll(tasks, timeout);
    }
}
