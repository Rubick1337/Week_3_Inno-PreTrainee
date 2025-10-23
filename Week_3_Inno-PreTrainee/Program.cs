using FluentValidation;
using Week_3_Inno_PreTrainee.Application.Services;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Infrastructure.Repositories;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddSingleton<IRepositoryBase<Author>, RepositoryAuthor>();
builder.Services.AddSingleton<IRepositoryBase<Book>, RepositoryBook>();

builder.Services.AddSingleton<IServiceAuthor, ServiceAuthor>();
builder.Services.AddSingleton<IServiceBook, ServiceBook>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
