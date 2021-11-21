using Microsoft.EntityFrameworkCore;
using Mootex.Auth.Api.Extensions;
using Mootex.Auth.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var dsn = "Host=127.0.0.1;Database=mootexauth;Username=postgres;Password=postgres";
builder.Services.AddDbContext<AuthDbContext>(opt => opt.UseNpgsql(dsn));

builder.Services.AddTransient(
    typeof(Mootex.Auth.Models.Apps.IAppRepository),
    typeof(Mootex.Auth.Data.Apps.EfAppRepository));

var db = new AuthDbContextCreator(dsn);
db.Create();
db.CreateSampleData();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
