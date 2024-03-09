using Base_code.Domain.Entities;
using Base_code.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Base_code.Application.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Base_code.Domain.Exceptions;
using log4net;
using Base_code.Api.Services.Extensions;
using Base_code.Api.Services.Filters;
using FluentValidation.AspNetCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Base_code.Application.Common;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/*builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidationFilter));
}).AddFluentValidation();

*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationModules();
//Jwt
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Cấu hình bảo mật Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [Space] then your token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
        });
});

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});




//ConnectStrings
builder.Services.AddDbContext<Base_Context>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("Base_Context")));
var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<Base_Context>();

    await dbContext.Database.MigrateAsync();

    if (!dbContext.Users.Any())
    {
        DateTime now = DateTime.Now;
        string password = "12345678";
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        using (MD5 md5 = MD5.Create())
        {
            byte[] hashedBytes = md5.ComputeHash(passwordBytes);
            string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            await dbContext.Users.AddAsync(
                new User
                {
                    createdAt = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second),
                    FullName = "Phạm Khắc Huy",
                    Email = "Phamkhachuy240702@gmail.com",
                    Password = hashedPassword,
                    Gender = true,
                    Role = "Admin",
                    Address = "Hải phòng",
                    Avatar = "",
                    PhoneNumber = "0325472224",
                    UserId = 0,
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionMiddleware();

app.UseAuthentication();
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
