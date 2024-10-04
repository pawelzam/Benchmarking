namespace FastOperations.Extensions;
public static class TaskExtensions
{
    //public static async Task<IEnumerable<T>> WhenAll<T>(this Task<T>[] tasks)
    //{
    //    var all = Task.WhenAll(tasks);
    //    try
    //    {
    //        return await all;
    //    }
    //    catch
    //    {
    //        //ignored
    //    }

    //    throw all.Exception ?? throw new Exception("Exception in parallel execution"); // all.Exception is aggregate exceptions
    //}

    public static async Task WhenAll(this Task[] tasks)
    {
        var all = Task.WhenAll(tasks);
        try
        {
            await all;
        }
        catch
        {
            //ignored
        }

        throw all.Exception ?? throw new Exception("Exception in parallel execution"); // all.Exception is aggregate exceptions
    }
}
