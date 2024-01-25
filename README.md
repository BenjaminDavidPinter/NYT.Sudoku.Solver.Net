## Mac Mini (M1)
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

## Lenovo Thinkpad X220
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

</br>
</br>

## Work Laptop (2022)
``` ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19045
12th Gen Intel Core i5-1235U, 1 CPU, 12 logical and 10 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT
  DefaultJob : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT
```

|        Method | cacheSize |         Mean |      Error |     StdDev |
|-------------- |---------- |-------------:|-----------:|-----------:|
|   Easy_Puzzle |         9 |     8.059 us |  0.1603 us |  0.3345 us |
| Medium_Puzzle |         9 | 3,759.834 us | 25.2988 us | 23.6645 us |
|   Hard_Puzzle |         9 | 3,802.206 us | 26.2186 us | 24.5249 us |
