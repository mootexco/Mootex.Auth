using Microsoft.EntityFrameworkCore;
using Mootex.Auth.Models.Apps;

namespace Mootex.Auth.Data;

public class AppDbContext : DbContext
{
    public DbSet<AppModel> Apps { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppModel>(entity =>
        {
            _ = entity.ToTable("Apps");
            _ = entity.HasKey(x => x.Id);

            _ = entity.Property(x => x.UpdateTime)
                .IsConcurrencyToken();
        });
    }
}
