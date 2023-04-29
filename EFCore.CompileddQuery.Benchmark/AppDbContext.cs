using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CompileddQuery.Benchmark;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Server=localhost;Database=postgres;User Id=postgres;password=postgres;");
            //UseSqlite(@"Data Source=.\\customers.db;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Customer>()
        //            .ToTable("customers", "public");

        modelBuilder.Entity<Customer>(builder =>
        {
            var faker = new Faker();
            var customers = new List<Customer>();
            for(int i = 0; i < 10_000; i++)
            {
                customers.Add(new Customer
                {
                    Id=i+1,
                    Name=faker.Name.FullName(gender:Bogus.DataSets.Name.Gender.Male),
                    Age = faker.Random.Number(10,100)
                });
            }
            builder.HasData(customers);
        });
    }
    public DbSet<Customer> Customers { get; set;}


   

    //Define Compiled Query for above
    private static readonly Func<AppDbContext, long, Customer?> GetById =
        EF.CompileQuery(
            (AppDbContext context, long id) =>
            context.Set<Customer>().FirstOrDefault(c => c.Id == id));


    public Customer? GetCustomerById(long id)
    {
        return Set<Customer>().FirstOrDefault(c => c.Id == id);
    }
    //call this compiled Query
    public Customer? GetCustomerUsingCompiledQuery(long id)
    {
        return GetById(this, id);
    }

    //No Tracking Enabled
    private static readonly Func<AppDbContext, long, Customer?> GetByIdNoTracking =
       EF.CompileQuery(
           (AppDbContext context, long id) =>
           context.Set<Customer>().AsNoTracking().FirstOrDefault(c => c.Id == id));
    public Customer? GetCustomerByIdNoTracking(long id)
    {
        return Set<Customer>().AsNoTracking().FirstOrDefault(c => c.Id == id);
    }
    //call this compiled Query
    public Customer? GetCustomerUsingCompiledQueryNoTrack(long id)
    {
        return GetByIdNoTracking(this, id);
    }

    private static readonly Func<AppDbContext, string, int, Task<Customer?>> GetByNameAndAgeCompiled =
          EF.CompileAsyncQuery(
              (AppDbContext context, string name, int age) =>
              context.Set<Customer>().FirstOrDefault(c=>c.Name == name && c.Age == age));
    public async Task<Customer?> GetCustomerByNameAndAgeAsync(string name,int age)
    {
        return await Set<Customer>()
            .FirstOrDefaultAsync(c=>c.Name == name &&  c.Age == age);
    }

    public async Task<Customer?> GetCustomerByNameAndAgeAsyncCompiled(string name, int age)
    {
        return await GetByNameAndAgeCompiled(this,name, age);
    }
}
