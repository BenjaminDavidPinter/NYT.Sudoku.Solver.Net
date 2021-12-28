A project to learn about the true performance capabilities of C#.

``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.0.1 (21A559) [Darwin 21.1.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), Arm64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), Arm64 RyuJIT


```
|         Method |     Mean |    Error |   StdDev |
|--------------- |---------:|---------:|---------:|
| Solve_A_Puzzle | 16.50 ms | 0.017 ms | 0.014 ms |
