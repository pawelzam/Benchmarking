using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastOperations.Scenarios;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Arrays
{
    int[] _array = Enumerable.Range(0, 10).ToArray();

    [Benchmark(Baseline = true)]
    public int SumOddsUsingMod()
    {
        var sum = 0;
        for (var i = 0; i < _array.Length; i++)
        {
            var element = _array[i];
            if (element % 2 != 0)
            {
                sum += element;
            }
        }

        return sum;
    }

    [Benchmark]
    public int SumOddsUsingAndOperator()
    {
        var sum = 0;
        for (var i = 0; i < _array.Length; i++)
        {
            var element = _array[i];
            var odd = element & 1;
            sum += (odd * element);
        }

        return sum;
    }


    [Benchmark]
    public int SumOddsUsingParallelism()
    {
        var sumA = 0;
        var sumB = 0;
        for (var i = 0; i < _array.Length; i += 2)
        {
            var elementA = _array[i];
            var elementB = _array[i + 1];
            var oddA = elementA & 1;
            var oddB = elementB & 1;
            sumA += (oddA * elementA);
            sumB += (oddB * elementB);
        }

        return sumA + sumB;
    }

    [Benchmark]
    public int SumOddsUsingParallelismAndShiftLeftOperator()
    {
        var sumA = 0;
        var sumB = 0;
        for (var i = 0; i < _array.Length; i += 2)
        {
            var elementA = _array[i];
            var elementB = _array[i + 1];

            sumA += (elementA << (elementA & 1)) - elementA;
            sumB += (elementB << (elementB & 1)) - elementB;
        }

        return sumA + sumB;
    }

    [Benchmark]
    public int SumOddsUsingParallelismAndNoBoundsChecks()
    {
        var sumA = 0;
        var sumB = 0;
        unsafe
        {
            fixed (int* data = &_array[0])
            {
                var p = (int*)data;
                for (var i = 0; i < _array.Length; i += 2)
                {
                    sumA += (p[0] & 1) * p[0];
                    sumA += (p[1] & 1) * p[1];

                    p += 2;
                }
            }
        }

        return sumA + sumB;
    }

    [Benchmark]
    public int SumOddsUsingParallelismAndNoBoundsChecksMaximizePorts()
    {
        var sumA = 0;
        var sumB = 0;
        unsafe
        {
            fixed (int* data = &_array[0])
            {
                var p = (int*)data;
                var n = (int*)data;
                for (var i = 0; i < _array.Length; i += 2)
                {
                    sumA += (n[0] & 1) * p[0];
                    sumA += (n[1] & 1) * p[1];

                    p += 2;
                    n += 2;
                }
            }
        }

        return sumA + sumB;
    }
}
