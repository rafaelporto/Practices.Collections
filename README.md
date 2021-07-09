<h1 align="center">Welcome to Practices.Collections</h1>
<p>
  <img alt="Version" src="https://img.shields.io/badge/version- 1.0-blue.svg?cacheSeconds=2592000" />
  <a href="#" target="_blank">
    <img alt="License: MIT" src="https://img.shields.io/badge/License-MIT-yellow.svg" />
  </a>
  <a href="https://twitter.com/Rafael_M_Porto" target="_blank">
    <img alt="Twitter: Rafael\_M\_Porto" src="https://img.shields.io/twitter/follow/Rafael_M_Porto.svg?style=social" />
  </a>
</p>

> This repository contains benchmarks samples that exemplify the difference between some kid of dotnet collections when: add, replace and remove an item. Also has a comparison between different way to convert an array to an [ImmutableArray](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray?view=net-5.0).

## Author

👤 **Rafael Monteiro Porto**

* Twitter: [@Rafael\_M\_Porto](https://twitter.com/Rafael\_M\_Porto)
* Github: [@rafaelporto](https://github.com/rafaelporto)
* LinkedIn: [@rafael-monteiro-porto-858310b7](https://linkedin.com/in/rafael-monteiro-porto-858310b7)

## Benchmark Results

***

### Add Comparison

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1083 (21H1/May2021Update)
Intel Core i7-4510U CPU 2.00GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.410
  [Host]     : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT
  Job-LCMTJY : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT

IterationCount=1  

```
|                      Method |      Mean | Error | Rank | Gen 0 | Gen 1 | Gen 2 | Allocated | Completed Work Items | Lock Contentions |
|---------------------------- |----------:|------:|-----:|------:|------:|------:|----------:|---------------------:|-----------------:|
|              AddItemToArray |  5.368 ns |    NA |    2 |     - |     - |     - |         - |               0.0000 |                - |
| AddItemToArrayUsingSetValue | 41.702 ns |    NA |    6 |     - |     - |     - |         - |               0.0000 |                - |
|               AddItemToList |  4.227 ns |    NA |    1 |     - |     - |     - |         - |               0.0000 |                - |
|         AddItemToSortedList | 26.982 ns |    NA |    5 |     - |     - |     - |         - |               0.0000 |                - |
|         AddItemToDictionary | 14.560 ns |    NA |    3 |     - |     - |     - |         - |               0.0000 |                - |
|   AddItemToSortedDictionary | 22.273 ns |    NA |    4 |     - |     - |     - |         - |               0.0000 |                - |

***

### Replace Comparison

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1083 (21H1/May2021Update)
Intel Core i7-4510U CPU 2.00GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.410
  [Host]     : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT
  Job-LCMTJY : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT

IterationCount=1  

```
|                        Method |       Mean | Error | Rank | Gen 0 | Gen 1 | Gen 2 | Allocated | Completed Work Items | Lock Contentions |
|------------------------------ |-----------:|------:|-----:|------:|------:|------:|----------:|---------------------:|-----------------:|
|            ReplaceItemToArray |   4.391 ns |    NA |    1 |     - |     - |     - |         - |               0.0000 |                - |
|             ReplaceItemToList |   5.738 ns |    NA |    2 |     - |     - |     - |         - |               0.0000 |                - |
|       ReplaceItemToSortedList |  68.660 ns |    NA |    4 |     - |     - |     - |         - |               0.0000 |                - |
|       ReplaceItemToDictionary |  16.106 ns |    NA |    3 |     - |     - |     - |         - |               0.0000 |                - |
| ReplaceItemToSortedDictionary | 202.406 ns |    NA |    5 |     - |     - |     - |         - |               0.0000 |                - |

***

## Remove Comparison

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1083 (21H1/May2021Update)
Intel Core i7-4510U CPU 2.00GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.410
  [Host]     : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT
  Job-LCMTJY : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT

IterationCount=1  

```
|                       Method |            Mean | Error | Rank |   Gen 0 |   Gen 1 |   Gen 2 | Allocated | Completed Work Items | Lock Contentions |
|----------------------------- |----------------:|------:|-----:|--------:|--------:|--------:|----------:|---------------------:|-----------------:|
|            RemoveItemToArray |       0.0562 ns |    NA |    1 |       - |       - |       - |         - |               0.0000 |                - |
|   RemoveItemToImmutableArray | 964,891.6016 ns |    NA |    6 | 11.7188 | 11.7188 | 11.7188 | 800,016 B |               0.0039 |                - |
|             RemoveItemToList |      43.0663 ns |    NA |    3 |       - |       - |       - |         - |               0.0000 |                - |
|       RemoveItemToSortedList |      66.3406 ns |    NA |    4 |       - |       - |       - |         - |               0.0000 |                - |
|       RemoveItemToDictionary |      11.1428 ns |    NA |    2 |       - |       - |       - |         - |               0.0000 |                - |
| RemoveItemToSortedDictionary |     207.0704 ns |    NA |    5 |       - |       - |       - |         - |               0.0000 |                - |

***

## Convert Array to ImmutableArray

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1083 (21H1/May2021Update)
Intel Core i7-4510U CPU 2.00GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.410
  [Host]     : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT
  Job-LCMTJY : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT

IterationCount=1  

```
|                            Method |         Mean | Error | Rank |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated | Completed Work Items | Lock Contentions |
|---------------------------------- |-------------:|------:|-----:|---------:|---------:|---------:|-----------:|---------------------:|-----------------:|
|           ConvertArrayToImmutable | 283,974.5 μs |    NA |    3 | 156.2500 | 156.2500 | 156.2500 | 413,672 KB |               0.1250 |                - |
| ConvertArrayToImmutableExtensions | 240,791.0 μs |    NA |    2 | 125.0000 | 125.0000 | 125.0000 | 313,672 KB |               0.1250 |                - |
|     ConvertArrayToImmutableCreate |     519.5 μs |    NA |    1 |   4.8828 |   4.8828 |   4.8828 |     781 KB |               0.0020 |                - |

***

## How to run

> 1. Clone the repository
> 2. In your terminal, navegate to root of solution and run the command: 
```
dotnet run -p .\Practices.Collections\Practices.Collections.csproj -c Release
```

## Show your support

Give a ⭐️ if this project helped you!
