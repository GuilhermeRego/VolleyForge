using Microsoft.EntityFrameworkCore;
using VolleyForge.Application.Abstractions.Repositories;
using VolleyForge.Infrastructure.Persistence;
using VolleyForge.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VolleyForgeContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("VolleyForgeDb")));

builder.Services.AddScoped<IClubRepository, ClubRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
