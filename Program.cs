using CinemaCalc.API.Data;
using CinemaCalc.API.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // or the domain of your React frontend
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ValidateModelAttribute>(); // Register the custom filter
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        // Suppress the automatic validation error response
        options.SuppressModelStateInvalidFilter = true;
    });

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");
app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();