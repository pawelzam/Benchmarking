using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastOperations.Scenarios;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Boxing
{
    [Benchmark]
    public void Heap()
    {
        var _ = Enumerable.Range(1, 100).Select(p => new ReferenceType()).ToArray();
    }

    [Benchmark]
    public void Stack()
    {
        var _ = Enumerable.Range(1, 100).Select(p=> new ValueType()).ToArray();
    }

    private class ReferenceType
    {
        public int Number {
            get;
            set;
        }
    }

    private struct ValueType
    {
        public int Number
        {
            get;
            set;
        }

    }
}
