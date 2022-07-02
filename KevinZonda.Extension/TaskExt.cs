using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinZonda.Extension;

public static class TaskExt
{
    public static Task<Task> WhenAny(IEnumerable<Task> tasks, TimeSpan timeout)
    {
        return Task.WhenAny(tasks.Append(Task.Delay(timeout)));
    }

    public static Task<Task> WhenAny(TimeSpan timeout, params Task[] tasks)
    {
        return WhenAny(tasks, timeout);
    }

    public static Task<Task> WhenAny(Task task1, Task task2, TimeSpan timeout)
    {
        return WhenAny(new[] { task1, task2 }, timeout);
    }


    public static Task WhenAll(IEnumerable<Task> tasks, TimeSpan timeout)
    {
        return WhenAny(timeout, Task.WhenAll(tasks));
    }

    public static Task WhenAll(TimeSpan timeout, params Task[] tasks)
    {
        return WhenAll(tasks, timeout);
    }

    public static Task WhenAll(Task task1, Task task2, TimeSpan timeout)
    {
        return WhenAll(new[] { task1, task2 }, timeout);
    }
}
