using Microsoft.EntityFrameworkCore;
using Mootex.Auth.Models.Apps;

namespace Mootex.Auth.Data;

public class AuthDbContextCreator : AuthDbContext
{
    private readonly string dsn;

    public AuthDbContextCreator(string dsn) : base(new DbContextOptions<AuthDbContext>())
    {
        this.dsn = dsn;
    }

    public void Create()
    {
        _ = this.Database.EnsureDeleted();
        _ = this.Database.EnsureCreated();
    }

    public void CreateSampleData()
    {
        this.Apps.Add(new AppModel()
        {
            Name = "First App",
        });

        this.Apps.Add(new AppModel()
        {
            Name = "Second App",
        });

        this.SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(this.dsn);
    }
}
