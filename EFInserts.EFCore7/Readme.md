EFCore7 Insert Results with .Net 7
----------------------------------

|                  Method | BatchSize |        Mean |       Error |      StdDev |        Median |
|------------------------ |---------- |------------:|------------:|------------:|--------------:|
|     AddOneByOneWithSave |       100 |    576.7 ms |  1,488.8 ms |    984.8 ms |    268.231 ms |
|             AddOneByOne |       100 |    177.7 ms |    711.3 ms |    470.5 ms |     22.746 ms |
|                AddRange |       100 |    175.7 ms |    714.8 ms |    472.8 ms |     28.378 ms |
| BulkExtensionBulkInsert |       100 |    150.1 ms |    701.4 ms |    463.9 ms |      2.606 ms |
|     AddOneByOneWithSave |      1000 |  9,311.8 ms |  6,119.9 ms |  4,047.9 ms | 10,185.304 ms |
|             AddOneByOne |      1000 |    361.9 ms |    854.1 ms |    564.9 ms |    195.662 ms |
|                AddRange |      1000 |    317.3 ms |    676.3 ms |    447.3 ms |    179.537 ms |
| BulkExtensionBulkInsert |      1000 |    159.6 ms |    693.7 ms |    458.8 ms |      9.437 ms |
|     AddOneByOneWithSave |      3000 | 67,514.9 ms | 53,839.4 ms | 35,611.4 ms | 68,149.402 ms |
|             AddOneByOne |      3000 |    598.3 ms |    766.4 ms |    507.0 ms |    407.065 ms |
|                AddRange |      3000 |    583.2 ms |    740.2 ms |    489.6 ms |    404.147 ms |
| BulkExtensionBulkInsert |      3000 |    156.5 ms |    642.0 ms |    424.6 ms |     17.540 ms |
