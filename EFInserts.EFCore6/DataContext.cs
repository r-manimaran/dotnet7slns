using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInserts.EFCore6;

public class DataContext:DbContext
{

    public DbSet<Person> People { get; set; } = null;
    private const int MaxBatchSize = 1000;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
                  .UseLogByEnvironment()
                  .UseNpgsql("Server=localhost;Database=postgres;User Id=postgres;password=postgres;", o => o.MaxBatchSize(MaxBatchSize));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
                    .ToTable("person-efc6", "public");
        modelBuilder.Entity<Person>()
                    .Property(p => p.PersonId)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();
        modelBuilder.Entity<Person>()
                    .Property(p => p.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode()
                    .IsRequired();
    }

    public virtual void MockableBulkInsert(IList<Person> batch)
    {
        this.BulkInsert(batch, c => { c.BatchSize = 1000; });
    }
}

public static class LoggingOptions
{
    public static DbContextOptionsBuilder UseLogByEnvironment(this DbContextOptionsBuilder builder)
    {
        if ((Environment.GetEnvironmentVariable("log2Console") ?? "false") == "true")
        {
            builder.LogTo(Console.WriteLine);
        }
        return builder;
    }
}
