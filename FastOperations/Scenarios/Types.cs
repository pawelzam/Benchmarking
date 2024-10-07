using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastOperations.Scenarios;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Types
{
    private class A
    {
        public int Id { get; set; }
    }

    private class B
    {
        public int Id { get; private set; }

        public B(int id) { Id = id; }
    }

    private struct C
    {
        public int Id { get; set; }
    }

    private record D (int ID);

    private record struct E(int ID);


    [Benchmark]
    public void MutableClass()
    {
        for (int i = 0; i < 1000; i++)
        {
            var _ = new A { Id = i };
        }
    }

    [Benchmark]
    public void ImmutableClass()
    {
        for (int i = 0; i < 1000; i++)
        {
            var _ = new B(i);
        }
    }

    [Benchmark]
    public void Struct()
    {
        for (int i = 0; i < 1000; i++)
        {
            var _ = new C { Id = i };
        }
    }

    [Benchmark]
    public void Record()
    {
        for (int i = 0; i < 1000; i++)
        {
            var _ = new D(i);
        }
    }

    [Benchmark]
    public void RecordStruct()
    {
        for (int i = 0; i < 1000; i++)
        {
            var _ = new E(i);
        }
    }
}
