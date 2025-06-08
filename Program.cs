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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("RenderPg");
if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("Error: Connection string 'RenderPg' is not set in configuration.");
    throw new Exception("Connection string 'RenderPg' is not set.");
}
Console.WriteLine($"Using connection string: {connectionString}"); // Log for debugging
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
           .EnableSensitiveDataLogging() // Debug DB issues
           .EnableDetailedErrors());     // Debug DB issues

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ProductionCors", policy =>
    {
        policy.WithOrigins("https://petflix-front.onrender.com")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register repositories (DI)
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

// Global exception handling
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

// Use CORS before other middleware
app.UseCors("ProductionCors");

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

// Disable HTTPS redirection for Render
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Use Render's port binding
app.Run($"http://0.0.0.0:{port}");