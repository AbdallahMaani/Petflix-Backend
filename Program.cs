using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using FullPetflix.AnimalFiles;
using FullPetflix.AnimalReviewFiles;
using FullPetflix.FavoritesFiles;
using FullPetflix.FeedbackFiles;
using FullPetflix.OrderFiles;
using FullPetflix.ProductFiles;
using FullPetflix.ProductReviewFiles;
using FullPetflix.UserFiles;
using FullPetflix.Models;
using FullPetFlix.Repositories;
using FullPetflix.ReportFiles;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("RenderPg");
if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("Error: Connection string 'RenderPg' is not set in configuration.");
    throw new Exception("Connection string 'RenderPg' is not set.");
}
Console.WriteLine($"Using connection string: {connectionString}");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
           .EnableSensitiveDataLogging()
           .EnableDetailedErrors());

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("ProductionCors", policy =>
    {
        policy.WithOrigins(
                "https://petflix-front.onrender.com",  // Production frontend
                "http://localhost:3000"               // Local development
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetPreflightMaxAge(TimeSpan.FromSeconds(86400));
    });

    // Development policy for testing
    options.AddPolicy("DevelopmentCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAR_Repository, AR_Repository>();
builder.Services.AddScoped<IPR_Repository, PR_Repository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

var app = builder.Build();

// Get the PORT environment variable from Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
Console.WriteLine($"Starting server on port: {port}");

// Apply CORS based on environment
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevelopmentCors");
    Console.WriteLine("Using Development CORS policy");
}
else
{
    app.UseCors("ProductionCors");
    Console.WriteLine("Using Production CORS policy");
}

// Exception Handling
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (exception != null)
        {
            Console.WriteLine($"Error: {exception.Error.Message}");
            Console.WriteLine(exception.Error.StackTrace);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An error occurred. Check the server logs.");
        }
    });
});

// Security Headers
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    await next();
});

// Root endpoint
app.MapGet("/", () => "PetFlix Backend is running!");

// Swagger UI only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        dbContext.Database.Migrate();
        Console.WriteLine("Database migrations applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration failed: {ex.Message}");
        Console.WriteLine(ex.StackTrace);
        throw;
    }
}

// Authorization and controllers
app.UseAuthorization();
app.MapControllers();

// Handle OPTIONS requests for all API endpoints
app.MapMethods("/api/{*rest}", new[] { "OPTIONS" }, () => Results.Ok())
   .WithMetadata(new EnableCorsAttribute("ProductionCors"));

// Run the app
app.Run($"http://0.0.0.0:{port}");