using LiteDB;
using Microsoft.Extensions.Options;
using src.Application.Common.Repositories;
using src.Infrastructure;
using src.Infrastructure.LiteDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configure LiteDb
builder.Services.Configure<LiteDbOptions>(builder.Configuration.GetSection("LiteDb"));
builder.Services.AddSingleton<ILiteDatabase>(sp =>
{
    var env  = sp.GetRequiredService<IHostEnvironment>();
    var opts = sp.GetRequiredService<IOptions<LiteDbOptions>>().Value;
    
    var conn = opts.ConnectionString;
    var absolutePath = Path.Combine(env.ContentRootPath, "data", "app.db");

    Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);
    
    conn = conn.Replace("Filename=./data/app.db", $"Filename={absolutePath}");

    return new LiteDatabase(conn);
});

builder.Services.AddScoped<ICommandRepository, CommandLiteDbRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();