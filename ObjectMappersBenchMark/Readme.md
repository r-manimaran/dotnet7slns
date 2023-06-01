# Benchmarks on different Object Mappers
---
Used the Object mapper like 
	* AutoMapper
	* Tiny Mapper
	* Mapperly
	* Mapster


|           Method |      Mean |    Error |    StdDev |    Median | Allocated |
|----------------- |----------:|---------:|----------:|----------:|----------:|
| AutoMapperMethod | 331.87 ns | 4.052 ns |  3.592 ns | 332.28 ns |     192 B |
| TinyMapperMethod | 356.32 ns | 6.735 ns |  9.659 ns | 354.69 ns |     224 B |
|   MapperlyMethod |  52.93 ns | 1.144 ns |  2.363 ns |  52.77 ns |     136 B |
|          Mapster | 134.83 ns | 3.951 ns | 11.014 ns | 129.86 ns |     192 B |

