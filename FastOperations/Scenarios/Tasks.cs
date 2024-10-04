using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastOperations.Scenarios;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Tasks
{
    private readonly List<Task<int>> _tasks = Enumerable.Range(1, 5).Select(ProcessAsync).ToList();
    private readonly List<Task<int>> _removableTasks = Enumerable.Range(1, 5).Select(ProcessAsync).ToList();

    [Benchmark]
    public async Task RunForEachAsync()
    {
        foreach (var task in _tasks)
        {
            _ = await task;
        }
    }

    [Benchmark]
    public async Task RunWhenAllAsync()
    {
        await Task.WhenAll(_tasks);
    }

    [Benchmark]
    public async Task RunWhenAnyAsync()
    {
        while (_removableTasks.Any())
        {
            var finished = await Task.WhenAny(_removableTasks);
            _removableTasks.Remove(finished);
        }
    }

    [Benchmark]
    public async Task RunParallelForEachAsyncAsync()
    {
        await Parallel.ForEachAsync(_tasks, async (task, _) => await task);
    }

    private static async Task<int> ProcessAsync(int delay)
    {
        await Task.Delay(delay * 100);
        return delay;
    }
}