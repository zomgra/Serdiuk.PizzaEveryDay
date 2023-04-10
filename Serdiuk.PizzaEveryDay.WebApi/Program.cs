using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serdiuk.PizzaEveryDay.Application;
using Serdiuk.PizzaEveryDay.Infrastructure;
using Serdiuk.PizzaEveryDay.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(b =>
    {
        b.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
    {
        config.SaveToken = true;
        config.Audience = "PizzaApi";
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = "PizzaApi",
            ValidIssuer = "https://localhost:10001",
            ClockSkew = TimeSpan.Zero,
            SaveSigninToken = true,
        };

        config.Authority = "https://localhost:10001";
    });

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

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
app.UseCors();

app.MapControllers();

var scope = app.Services.CreateScope();
ApplicationDbContextSeed.Initialize(scope.ServiceProvider.GetService<ApplicationDbContext>());

app.Run();
