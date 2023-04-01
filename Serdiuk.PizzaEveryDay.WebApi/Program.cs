using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serdiuk.PizzaEveryDay.Application;
using Serdiuk.PizzaEveryDay.Infrastructure;
using Serdiuk.PizzaEveryDay.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
    {
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        config.Authority = "https://localhost:10001";
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
ApplicationDbContextSeed.Initialize(scope.ServiceProvider.GetService<ApplicationDbContext>());

app.Run();
