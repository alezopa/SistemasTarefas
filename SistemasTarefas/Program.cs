using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemasTarefas.Data;
using SistemasTarefas.Repositorio;
using SistemasTarefas.Repositorio.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<SistemaTarefaDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
    );

builder.Services.AddScoped<IProjectsRepositorio, ProjectsRepositorio>();
builder.Services.AddScoped<ITasksRepositorio, TasksRepositorio>();
builder.Services.AddScoped<ITimeTrackersRepositorio, TimeTrackersRepositorio>();


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
