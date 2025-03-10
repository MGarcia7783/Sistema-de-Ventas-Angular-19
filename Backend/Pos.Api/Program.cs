
using Microsoft.EntityFrameworkCore;
using Pos.Model.Context;

var builder = WebApplication.CreateBuilder(args);

// Obtener y validar la cadena de conexi�n de la base de datos
var connetionsString = builder.Configuration.GetConnectionString("Connection");
if(string.IsNullOrEmpty(connetionsString))
{
    throw new InvalidOperationException("La cadena de conexi�n 'Conecction' no est� configurada");
}

builder.Services.AddDbContext<PosContext>(options =>
{
    options.UseNpgsql(connetionsString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
