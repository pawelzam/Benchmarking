using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastOperations.Scenarios;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Enums
{
    enum Part
    {
        None = 0,
        Engine = 1,
        Breaks = 2,
        Clutch = 4,
        Gearbox = 8
    }

    record Vehicle(Part[] Parts); // Parts stored using enums
    record Vehicle1(int Parts); // Parts stored using binary notation

    private Vehicle[] _vehicles = new Vehicle[100];
    private Vehicle1[] _vehicles1 = new Vehicle1[100];

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random();
        var arr = Array.ConvertAll((int[])Enum.GetValues(typeof(Part)), Convert.ToInt32);

        var partsArr = Enumerable.Range(0, 100).Select(i =>
            new[] { arr[rnd.Next(arr.Length)], arr[rnd.Next(arr.Length)] });

        _vehicles = partsArr.Select(i => 
            new Vehicle([(Part)i[0], (Part)i[1]])).ToArray();

        _vehicles1 = partsArr.Select(i =>
            new Vehicle1(i[0] | i[1])).ToArray();
    }



    [Benchmark]
    public int Contains()
    {
        return _vehicles.Count(p => p.Parts.Contains(Part.Gearbox));
    }

    [Benchmark]
    public int AndOperator()
    {
        var gearbox = (int)Part.Gearbox;
        return _vehicles1.Count(p => (p.Parts & gearbox) == gearbox);
    }
}
