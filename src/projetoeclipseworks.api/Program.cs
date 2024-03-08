using Microsoft.EntityFrameworkCore;
using projetoeclipseworks.Application.Mapper;
using projetoeclipseworks.Dados;
using projetoeclipseworks.Dados.Repositorios;
using projetoeclipseworks.Application.Services;
using projetoeclipseworks.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
builder.Services.AddScoped<DbContext>();
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
