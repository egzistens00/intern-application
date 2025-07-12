using InternAPI.Data;
using InternAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// STEP 1: Fetch credentials from Vault
var vaultService = new VaultService();
var (username, password) = await vaultService.GetDbCredentialsAsync();

// STEP 2: Build SQL connection string using Vault credentials
var connectionString = $"Server=intern-db-server.database.windows.net;Database=InternAppDB;User Id={username};Password={password};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

// STEP 3: Register services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton(vaultService);

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

// STEP 4: Build app
var app = builder.Build();

app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Health check & default routes
app.MapGet("/", () => "🎉 Welcome to Alif's Intern API!");
app.MapGet("/test", () => "✅ Intern API is running on Azure!");

app.Run();
