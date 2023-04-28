using BenchmarkDotNet.Running;
using EFInserts.EFCore6;

Console.WriteLine("Starting Application");

var summary = BenchmarkRunner.Run<InsertPersonModel>();
Console.WriteLine( summary);
