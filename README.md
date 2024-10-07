# Benchmarking

Async operations:

| Method                       | Mean         | Error      | StdDev     | Rank | Gen0   | Allocated |
|----------------------------- |-------------:|-----------:|-----------:|-----:|-------:|----------:|
| RunWhenAnyAsync              |     7.550 ns |  0.1705 ns |  0.3285 ns |    1 |      - |         - |
| RunForEachAsync              |    25.204 ns |  0.4480 ns |  0.8524 ns |    2 |      - |         - |
| RunWhenAllAsync              |    75.295 ns |  1.4762 ns |  3.5934 ns |    3 | 0.0238 |     200 B |
| RunParallelForEachAsyncAsync | 2,558.329 ns | 20.9829 ns | 16.3821 ns |    4 | 0.0801 |     696 B |


Dates:

| Method                | Mean     | Error    | StdDev   | Median   | Rank | Gen0   | Allocated |
|---------------------- |---------:|---------:|---------:|---------:|-----:|-------:|----------:|
| ConvertUsingSlice     | 19.89 ns | 0.392 ns | 0.367 ns | 19.82 ns |    1 |      - |         - |
| ConvertUsingSubstring | 32.00 ns | 0.889 ns | 2.566 ns | 30.75 ns |    2 | 0.0114 |      96 B |

Boxing:

| Method | Mean      | Error     | StdDev    | Rank | Gen0   | Gen1   | Allocated |
|------- |----------:|----------:|----------:|-----:|-------:|-------:|----------:|
| Stack  |  77.09 ns |  1.479 ns |  1.235 ns |    1 | 0.0612 |      - |     512 B |
| Heap   | 576.34 ns | 18.352 ns | 53.532 ns |    2 | 0.3958 | 0.0048 |    3312 B |

Enums:

| Method      | Mean     | Error    | StdDev   | Rank | Gen0   | Allocated |
|------------ |---------:|---------:|---------:|-----:|-------:|----------:|
| AndOperator | 260.3 ns |  5.23 ns |  5.14 ns |    1 | 0.0095 |     120 B |
| Contains    | 740.1 ns | 14.65 ns | 26.78 ns |    2 | 0.0019 |      32 B |

Arrays:

| Method                                                | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Rank | Allocated | Alloc Ratio |
|------------------------------------------------------ |---------:|----------:|----------:|---------:|------:|--------:|-----:|----------:|------------:|
| SumOddsUsingParallelismAndNoBoundsChecks              | 2.849 ns | 0.0830 ns | 0.0776 ns | 2.826 ns |  0.35 |    0.01 |    1 |         - |          NA |
| SumOddsUsingParallelismAndNoBoundsChecksMaximizePorts | 3.067 ns | 0.0800 ns | 0.0709 ns | 3.055 ns |  0.38 |    0.01 |    2 |         - |          NA |
| SumOddsUsingParallelism                               | 4.053 ns | 0.1099 ns | 0.2933 ns | 3.933 ns |  0.50 |    0.04 |    3 |         - |          NA |
| SumOddsUsingParallelismAndShiftLeftOperator           | 4.270 ns | 0.0893 ns | 0.0836 ns | 4.256 ns |  0.52 |    0.02 |    3 |         - |          NA |
| SumOddsUsingAndOperator                               | 4.632 ns | 0.1814 ns | 0.5320 ns | 4.467 ns |  0.57 |    0.07 |    3 |         - |          NA |
| SumOddsUsingMod                                       | 8.151 ns | 0.1950 ns | 0.2603 ns | 8.120 ns |  1.00 |    0.04 |    4 |         - |          NA |

Types:

| Method         | Mean       | Error    | StdDev    | Rank | Gen0   | Allocated |
|--------------- |-----------:|---------:|----------:|-----:|-------:|----------:|
| Struct         |   256.2 ns |  5.13 ns |   9.63 ns |    1 |      - |         - |
| RecordStruct   |   264.5 ns |  5.31 ns |  13.13 ns |    1 |      - |         - |
| ImmutableClass | 1,921.4 ns | 44.72 ns | 129.03 ns |    2 | 1.9112 |   24000 B |
| Record         | 1,951.6 ns | 54.38 ns | 155.16 ns |    2 | 1.9112 |   24000 B |
| MutableClass   | 2,311.4 ns | 63.97 ns | 184.58 ns |    3 | 1.9112 |   24000 B |