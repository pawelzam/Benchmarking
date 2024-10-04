# Benchmarking

| Method                       | Mean         | Error      | StdDev     | Rank | Gen0   | Allocated |
|----------------------------- |-------------:|-----------:|-----------:|-----:|-------:|----------:|
| RunWhenAnyAsync              |     7.550 ns |  0.1705 ns |  0.3285 ns |    1 |      - |         - |
| RunForEachAsync              |    25.204 ns |  0.4480 ns |  0.8524 ns |    2 |      - |         - |
| RunWhenAllAsync              |    75.295 ns |  1.4762 ns |  3.5934 ns |    3 | 0.0238 |     200 B |
| RunParallelForEachAsyncAsync | 2,558.329 ns | 20.9829 ns | 16.3821 ns |    4 | 0.0801 |     696 B |


| Method                | Mean     | Error    | StdDev   | Median   | Rank | Gen0   | Allocated |
|---------------------- |---------:|---------:|---------:|---------:|-----:|-------:|----------:|
| ConvertUsingSlice     | 19.89 ns | 0.392 ns | 0.367 ns | 19.82 ns |    1 |      - |         - |
| ConvertUsingSubstring | 32.00 ns | 0.889 ns | 2.566 ns | 30.75 ns |    2 | 0.0114 |      96 B |
