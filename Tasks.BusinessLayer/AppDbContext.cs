using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Models;

namespace Tasks.BusinessLayer;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<ActionItem> ActionItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Entity Task
        modelBuilder.Entity<ActionItem>(entity =>
        {
            entity.ToTable("ActionItem");
            entity.Property(e=>e.Title)
                  .IsRequired()
                  .HasMaxLength(100);
            entity.Property(e => e.Ts)
                  .HasColumnType("smalldatetime")
                  .HasColumnName("TS");
            entity.HasOne(d => d.User)
                  .WithMany(p => p.Tasks)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_ActionItem_User");
        });

        //Entity User
        modelBuilder.Entity<User>(entity =>
        {

        });

    }
}
