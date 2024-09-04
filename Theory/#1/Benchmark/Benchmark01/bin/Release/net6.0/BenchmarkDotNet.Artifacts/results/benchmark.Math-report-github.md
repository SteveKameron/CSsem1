```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.203
  [Host]     : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2


```
|      Method |     Mean |   Error |  StdDev |
|------------ |---------:|--------:|--------:|
|   simpleSum | 144.3 ms | 2.17 ms | 1.92 ms |
| parallelSum | 151.8 ms | 1.76 ms | 1.65 ms |
