using projetoeclipseworks.Application.Mapper;
using projetoeclipseworks.Application.Services;
using projetoeclipseworks.Application.Services.Interfaces;
using projetoeclipseworks.Dados.Repositorios;
using Tarefaeclipseworks.Dados.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITarefaService, TarefaService>();
builder.Services.AddTransient<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddTransient<IProjetoService, ProjetoService>();
builder.Services.AddTransient<IProjetoRepositorio, ProjetoRepositorio>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsapp");
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
