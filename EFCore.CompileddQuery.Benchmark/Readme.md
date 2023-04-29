# Used EFCore7 with Postgresql
# Used Bogus to create Fake Data
================================

Get Customer By Id with Normal and Compiled Query
--------------------------------------------------

|                     Method |     Mean |    Error |   StdDev |    Gen0 | Allocated |
|--------------------------- |---------:|---------:|---------:|--------:|----------:|
|            GetCustomerById | 841.7 us | 14.01 us | 11.70 us | 33.2031 |     52 KB |
| GetCustomerByIdCompiledQry | 679.7 us | 13.35 us | 24.74 us | 29.2969 |  47.42 KB |

Get Customer By Id with Tracking disabled in EFCore
----------------------------------------------------
|                               Method |       Mean |     Error |    StdDev |     Median |    Gen0 | Allocated |
|------------------------------------- |-----------:|----------:|----------:|-----------:|--------:|----------:|
|                      GetCustomerById | 1,876.2 us | 112.91 us | 331.14 us | 1,770.0 us |       - |  57.66 KB |
|           GetCustomerByIdCompiledQry |   730.3 us |  14.23 us |  38.96 us |   722.4 us | 29.2969 |  47.42 KB |
|            GetCustomerByIdNoTracking |   823.5 us |  16.07 us |  20.89 us |   816.2 us | 33.2031 |  51.31 KB |
| GetCustomerByIdCompiledQryNoTracking |   665.1 us |  13.30 us |  23.98 us |   671.3 us | 29.2969 |  46.18 KB |

Get a Customer By Name and Age
------------------------------
|                          Method |     Mean |     Error |    StdDev |    Gen0 | Allocated |
|-------------------------------- |---------:|----------:|----------:|--------:|----------:|
|         GetCustomerByNameAndAge | 1.937 ms | 0.0320 ms | 0.0267 ms | 35.1563 |  59.36 KB |
| GetCustomerByNameAndAgeCompiled | 1.788 ms | 0.0345 ms | 0.0339 ms | 35.1563 |  53.82 KB |
