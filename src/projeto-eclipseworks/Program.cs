using Microsoft.EntityFrameworkCore;
using projeto_eclipseworks.Application.Mapper;
using projeto_eclipseworks.Application.Services;
using projeto_eclipseworks.Application.Services.Interfaces;
using projeto_eclipseworks.Dados;
using projeto_eclipseworks.Dados.Repositorios;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ITarefaService, TarefaService>();
builder.Services.AddTransient<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddTransient<IProjetoService, ProjetoService>();
builder.Services.AddTransient<IProjetoRepositorio, ProjetoRepositorio>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<DbContext, AppDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrganizacaoTarefas API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
