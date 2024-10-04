using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastOperations.Scenarios;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Dates
{
    private const string DateAsText = "2024-10-04";

    [Benchmark]
    public DateTime ConvertUsingSubstring()
    {
        var day = int.Parse(DateAsText.Substring(8, 2));
        var month = int.Parse(DateAsText.Substring(5, 2));
        var year = int.Parse(DateAsText[..4]);

        return new DateTime(year, month, day);
    }

    [Benchmark]
    public DateTime ConvertUsingSlice()
    {
        ReadOnlySpan<char> span = DateAsText;
        var day = int.Parse(span.Slice(8,2));
        var month = int.Parse(span.Slice(5,2));
        var year = int.Parse(span.Slice(0,4));

        return new DateTime(year, month, day);
    }
}
