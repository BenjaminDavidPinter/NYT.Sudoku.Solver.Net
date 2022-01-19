``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.0.1 (21A559) [Darwin 21.1.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), Arm64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), Arm64 RyuJIT


```
|        Method | cacheSize |         Mean |     Error |    StdDev |
|-------------- |---------- |-------------:|----------:|----------:|
|   Easy_Puzzle |         9 |     9.823 μs | 0.0111 μs | 0.0099 μs |
| Medium_Puzzle |         9 | 4,080.303 μs | 2.4176 μs | 2.0188 μs |
|   Hard_Puzzle |         9 | 3,961.032 μs | 2.8230 μs | 2.5025 μs |

</br>
</br>

``` ini
BenchmarkDotNet=v0.13.1, OS=ubuntu 20.04
Intel Core i7-2640M CPU 2.80GHz (Sandy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
```

|        Method | cacheSize |        Mean |      Error |     StdDev |
|-------------- |---------- |------------:|-----------:|-----------:|
|   Easy_Puzzle |         9 |    16.43 us |   0.192 us |   0.179 us |
| Medium_Puzzle |         9 | 7,656.07 us | 135.085 us | 119.750 us |
|   Hard_Puzzle |         9 | 7,242.67 us |  98.220 us |  76.684 us |

