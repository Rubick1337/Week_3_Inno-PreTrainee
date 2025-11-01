using FluentValidation;
using Week_3_Inno_PreTrainee.Application.Services;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Data.Repositories;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Data.Context;
using Microsoft.EntityFrameworkCore;
using Week_3_Inno_PreTrainee.Presentation.Validators.AuthorValidator;
using Week_3_Inno_PreTrainee.Presentation.Validators.BookValidator;
using Week_3_Inno_PreTrainee.Middleware;
using Week_3_Inno_PreTrainee.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.ConfigureExtasion(configuration);

builder.Services.DataExtasion();

builder.Services.ApplicationExtasion();

builder.Services.AddValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseException();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
