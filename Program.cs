using System.Text;
using Microsoft.EntityFrameworkCore;
using Backrest.Models;
using DotNetEnv;
using Microsoft.Extensions.Configuration;
using Backrest.Data;
using System.Text.Json.Serialization;
using MySql.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
Env.Load(); // carga las variables de entorno desde el archivo .env

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = builder.Configuration.GetConnectionString("Dataconnetion");
connectionString = connectionString
    .Replace("{HOST_DB}", Environment.GetEnvironmentVariable("HOST_DB"))
    .Replace("{PORT_DB}", Environment.GetEnvironmentVariable("PORT_DB"))
    .Replace("{DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME"))
    .Replace("{USER_DB}", Environment.GetEnvironmentVariable("USER_DB"))
    .Replace("{PASSWORD}", Environment.GetEnvironmentVariable("PASSWORD"));

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexión SQL
builder.Services.AddDbContext<DataContext>(opt => opt.UseMySQL(connectionString));

//eliminar referencias cíclicas
builder.Services
    .AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

//cors del proyecto
var reglas = "CorsReglas";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(
        name: reglas,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});
var secrekey = Environment.GetEnvironmentVariable("SECREKEY");
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secrekey));
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = symmetricSecurityKey,
            ValidateIssuer = false,
            ValidIssuer = "",
            ValidateAudience = false,
            ValidAudience = "",
            ClockSkew = TimeSpan.Zero
        };
    });
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    //dbContext.Database.EnsureCreated();
     dbContext.Database.Migrate();

    // Crea todas las tablas correspondientes a los modelos si no existen en la base de datos

    // Resto de la lógica de tu aplicación
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(reglas);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
