using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Repositories.Interfaces;
using ProductivityTrackerBackend.Repositories;
using ProductivityTrackerBackend.Services.Interfaces;
using System.Text;
using ProductivityTrackerBackend.Services;
using ProductivityTrackerBackend.Utilities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add repositories
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<ITimeLogRepository, TimeLogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<ITimeLogService, TimeLogService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<TokenService>();


// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Add Authorization
builder.Services.AddAuthorization();



builder.Services.AddSwaggerGen(options =>
{
    // Add JWT Authentication to Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid JWT token."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();


// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred seeding the database: {ex.Message}");
    }
}







// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
