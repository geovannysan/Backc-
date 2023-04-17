using Microsoft.EntityFrameworkCore;
using Backrest.Models;
using Backrest.Data;
using System.Text.Json.Serialization;
using MySql.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//conecion sql
builder.Services.AddDbContext<DataContext>(opt=>opt.UseMySQL(builder.Configuration.GetConnectionString("Dataconnetion")));


//eliminar referencias ciclicas
builder.Services.AddControllers().AddJsonOptions(opt=>{
opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
//cors del proyecto
var reglas = "CorsReglas";
builder.Services.AddCors(opt =>{
opt.AddPolicy(name: reglas,builder=>{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
});
var app = builder.Build();

/*/ Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
 app.UseSwagger();
    app.UseSwaggerUI();
app.UseCors(reglas);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
