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

</br>
</br>

## Macbook Air (M2)
```ini
BenchmarkDotNet=v0.13.1, OS=macOS 14.3 (23D5033f) [Darwin 23.3.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT
```

|        Method | cacheSize |         Mean |      Error |     StdDev |
|-------------- |---------- |-------------:|-----------:|-----------:|
|   Easy_Puzzle |         9 |     6.540 us |  0.1295 us |  0.2368 us |
| Medium_Puzzle |         9 | 2,680.624 us |  7.6334 us |  6.7668 us |
|   Hard_Puzzle |         9 | 2,648.034 us | 12.1237 us | 10.7473 us |

## Work Laptop (2025)
```ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.26100
Unknown processor
.NET SDK=9.0.306
  [Host]     : .NET 8.0.21 (8.0.2125.47513), X64 RyuJIT
  DefaultJob : .NET 8.0.21 (8.0.2125.47513), X64 RyuJIT
```

|        Method | cacheSize |         Mean |      Error |     StdDev |
|-------------- |---------- |-------------:|-----------:|-----------:|
|   Easy_Puzzle |         9 |     4.732 us |  0.0586 us |  0.0548 us |
| Medium_Puzzle |         9 | 2,079.595 us | 30.1661 us | 28.2174 us |
|   Hard_Puzzle |         9 | 1,933.478 us | 15.2173 us | 13.4898 us |
