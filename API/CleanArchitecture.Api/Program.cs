using CleanArchitecture.Api.Middlewares;
using CleanArchitecture.Application;
using CleanArchitecture.Identity;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

#region Swagger
builder.Services.AddSwaggerGen(c =>
{

c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
Description = "Jwt Authorization",
Name = "Authorization",
In = ParameterLocation.Header,
Type = SecuritySchemeType.ApiKey,
Scheme = "Bearer"
});

c.AddSecurityRequirement(new OpenApiSecurityRequirement()
{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
});

c.SwaggerDoc("v1", new OpenApiInfo
{
Version = "v1",
Title = "Clean Architecture Api"
});
});  
#endregion

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();


