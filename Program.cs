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

var connectionString = builder.Configuration.GetConnectionString("DBConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string 'DBConnection' is not set.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
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
app.UseCors("AllowAll");

// Swagger UI only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
