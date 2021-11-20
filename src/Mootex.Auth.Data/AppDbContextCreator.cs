using Microsoft.EntityFrameworkCore;
using Mootex.Auth.Models.Apps;

namespace Mootex.Auth.Data;

public class AppDbContextCreator : AppDbContext
{
    private readonly string dsn;

    public AppDbContextCreator(string dsn) : base(new DbContextOptions<AppDbContext>())
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
        optionsBuilder.UseSqlite(this.dsn);
    }
}
