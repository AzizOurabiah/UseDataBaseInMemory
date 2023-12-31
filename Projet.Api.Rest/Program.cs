using Microsoft.EntityFrameworkCore;
using Projet.Api.Rest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Ajout de service DbContext pour pouvoir utiliser et cr�e les tables in memory
builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("MyDataBase"));

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
