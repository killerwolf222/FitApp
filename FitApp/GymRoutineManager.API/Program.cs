using GymRoutineManager.Application.Services;
using GymRoutineManager.Infrastructure.Data;
using GymRoutineManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<GymContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("GymRoutineManager.Infrastructure")
    )
);


builder.Services.AddScoped<RoutineService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<ProgressRepository>();
builder.Services.AddScoped<IProgressService, ProgressService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5500",
        policy =>
        {
            policy.WithOrigins("http://localhost:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
     
    });

var app = builder.Build();

app.UseCors("AllowLocalhost5500");


app.UseStaticFiles();


app.MapControllers();


app.MapFallbackToFile("frontend/login.html");

app.Run();
