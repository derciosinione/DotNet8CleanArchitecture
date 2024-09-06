using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            entity.HasIndex(x => x.Name).IsUnique();
            entity.HasIndex(x => x.CodeI18N).IsUnique();
        });

        base.OnModelCreating(modelBuilder);
    }
}