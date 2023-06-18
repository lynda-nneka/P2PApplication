using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using P2P.Data.Implementations;
using P2P.Data.Interfaces;
using P2P.Services.Implementations;
using P2P.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<P2PDatabaseSettings>(builder.Configuration.GetSection(nameof(P2PDatabaseSettings)));
builder.Services.AddSingleton<IP2PDatabaseSettings>(sp => sp.GetRequiredService<IOptions<P2PDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("P2PDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IP2PServices, P2PServices>();

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
// c.EnableAnnotations();
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "P2P", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

