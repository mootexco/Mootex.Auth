using Microsoft.EntityFrameworkCore;
using Mootex.Auth.Api.Extensions;
using Mootex.Auth.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var dsn = "Data Source=../../Mootex.Auth.db";
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(dsn));

builder.Services.AddTransient(
    typeof(Mootex.Auth.Models.Apps.IAppRepository),
    typeof(Mootex.Auth.Data.Apps.EfAppRepository));

var db = new AppDbContextCreator(dsn);
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
