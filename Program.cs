using InternAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 👉 Add services to the container

// Use InMemory database (can replace with SQL later)
// NEW (Azure SQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Enable CORS for all origins (for frontend/API access)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 👉 Configure the HTTP request pipeline

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles(); // 🔥 Important for serving /resumes/<filename>

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// ✅ Homepage
app.MapGet("/", () => "🎉 Welcome to Alif's Intern API!");

// ✅ Health check route
app.MapGet("/test", () => "✅ Intern API is running on Azure!");

app.Run();
