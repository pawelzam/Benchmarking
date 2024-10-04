using FastOperations.Extensions;

namespace FastOperations.Scenarios;

public class Exceptions
{
    public async Task HandleAsync()
    {
        var taskCompletionSource = new TaskCompletionSource<int>();
        taskCompletionSource.SetException([
            new("First"),
            new("Second"),
            new("Third")
        ]);

        //await Task.WhenAll(taskCompletionSource.Task); // it takes only first exception into account and ignores the rest 

        _ = await new[] { taskCompletionSource.Task }.WhenAll(); // Extension method takes aggregated exception so we're not losing the information
    }
}
