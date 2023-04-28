using BenchmarkDotNet.Running;
using EFInserts.EFCore7;

Console.WriteLine("Starting Application");

var summary = BenchmarkRunner.Run<InsertPersonModel>();
Console.WriteLine( summary);
