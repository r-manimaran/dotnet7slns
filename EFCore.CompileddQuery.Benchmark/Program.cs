using BenchmarkDotNet.Running;
using EFCore.CompileddQuery.Benchmark;

Console.WriteLine("Starting the Application");
//using var dbContext = new AppDbContext();
//var customer =dbContext.GetCustomerById(5000);
var summary = BenchmarkRunner.Run<CompiledBenchMark>();
Console.WriteLine(  summary);
