using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mootex.Auth.Models;
using Mootex.Auth.Models.Apps;

namespace Mootex.Auth.Data;

public class AuthDbContext : DbContext
{
    public DbSet<AppModel> Apps { get; set; } = null!;

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppModel>(entity =>
        {
            _ = entity.ToTable(nameof(this.Apps));
            this.ConfigureModelPrimaryKey(entity);
        });
    }

    private void ConfigureModelPrimaryKey<TModel>(EntityTypeBuilder<TModel> entity)
        where TModel : class, IModelWithNumericId
    {
        _ = entity.HasKey(x => x.Id);
        _ = entity.Property(x => x.Id).HasColumnType(PostgreColumnTypes.Bigint);
    }
}
