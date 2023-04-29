using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CompileddQuery.Benchmark;
[MemoryDiagnoser]
public class CompiledBenchMark
{
    private const long customerId = 5000;
    private const string name = "Everett Homenick";
    private const int age = 59;
    //[Benchmark]
    public Customer? GetCustomerById()
    {
        using var dbContext = new AppDbContext();
        return dbContext.GetCustomerById(customerId);
    }
    //[Benchmark]
    public Customer? GetCustomerByIdCompiledQry()
    {
        using var dbContext = new AppDbContext();
        return dbContext.GetCustomerUsingCompiledQuery(customerId);
    }

   // [Benchmark]
    public Customer? GetCustomerByIdNoTracking()
    {
        using var dbContext = new AppDbContext();
        return dbContext.GetCustomerByIdNoTracking(customerId);
    }
   // [Benchmark]
    public Customer? GetCustomerByIdCompiledQryNoTracking()
    {
        using var dbContext = new AppDbContext();
        return dbContext.GetCustomerUsingCompiledQueryNoTrack(customerId);
    }
    [Benchmark]
    public async Task<Customer?> GetCustomerByNameAndAge()
    {
        using var dbContext = new AppDbContext();
        return await dbContext.GetCustomerByNameAndAgeAsync(name, age);
    }
    [Benchmark]
    public async Task<Customer?> GetCustomerByNameAndAgeCompiled()
    {
        using var dbContext = new AppDbContext();
        return await dbContext.GetCustomerByNameAndAgeAsyncCompiled(name, age);
    }



}
