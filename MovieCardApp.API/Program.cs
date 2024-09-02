using Microsoft.EntityFrameworkCore;
using MovieCardApp.API.Data;
using MovieCardApp.API.Extensions;
using MovieCardApp.API.Repositories.MovieRep;
using MovieCardApp.API.Services.MovieServ;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieCardAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieCardAppContext") ?? throw new InvalidOperationException("Connection string 'MovieCardAppContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.SeedDataAsync();
}

await app.SeedDataAsync();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
