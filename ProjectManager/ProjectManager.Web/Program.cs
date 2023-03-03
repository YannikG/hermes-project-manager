using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using ProjectManager.Core;

var builder = WebApplication.CreateBuilder(args);

// configuration
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile($"appsettings.json", false, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddEnvironmentVariables();

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Core
builder.Services.ConfigureCore(builder.Configuration);

var app = builder.Build();

app.CoreInitDatabase();

app.UseSwagger();
app.UseSwaggerUI();

// Controllers
app.MapControllers();

app.Run();

