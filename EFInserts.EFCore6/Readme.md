EFCore6 .Net 6 Results on Insert
--------------------------------

|                  Method | BatchSize |        Mean |       Error |      StdDev |        Median |
|------------------------ |---------- |------------:|------------:|------------:|--------------:|
|     AddOneByOneWithSave |       100 |    760.9 ms |  2,162.0 ms |  1,430.0 ms |    307.514 ms |
|             AddOneByOne |       100 |    226.1 ms |    929.6 ms |    614.9 ms |     28.174 ms |
|                AddRange |       100 |    217.3 ms |    921.4 ms |    609.4 ms |     21.368 ms |
| BulkExtensionBulkInsert |       100 |    171.6 ms |    777.2 ms |    514.1 ms |      2.851 ms |
|     AddOneByOneWithSave |      1000 | 11,739.2 ms |  8,542.8 ms |  5,650.6 ms | 12,237.097 ms |
|             AddOneByOne |      1000 |    364.5 ms |    833.5 ms |    551.3 ms |    184.663 ms |
|                AddRange |      1000 |    321.2 ms |    801.3 ms |    530.0 ms |    156.375 ms |
| BulkExtensionBulkInsert |      1000 |    149.4 ms |    675.6 ms |    446.9 ms |      7.650 ms |
|     AddOneByOneWithSave |      3000 | 91,074.5 ms | 72,519.0 ms | 47,966.8 ms | 87,874.854 ms |
|             AddOneByOne |      3000 |    633.8 ms |    836.2 ms |    553.1 ms |    424.228 ms |
|                AddRange |      3000 |    588.7 ms |    796.9 ms |    527.1 ms |    405.220 ms |
| BulkExtensionBulkInsert |      3000 |    164.2 ms |    676.4 ms |    447.4 ms |     21.368 ms |