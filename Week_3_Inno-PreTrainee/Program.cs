using FluentValidation;
using Week_3_Inno_PreTrainee.Application.Services;
using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Data.Repositories;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Data.Context;
using Microsoft.EntityFrameworkCore;
using Week_3_Inno_PreTrainee.Presentation.Validators.AuthorValidator;
using Week_3_Inno_PreTrainee.Presentation.Validators.BookValidator;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

builder.Services.AddValidatorsFromAssemblies(new[]
{
    typeof(AuthorForCreationDtoValidator).Assembly,
    typeof(BookForCreationDtoValidator).Assembly
});

builder.Services.AddScoped<IRepositoryAuthor, RepositoryAuthor>();
builder.Services.AddScoped<IRepositoryBook, RepositoryBook>();


builder.Services.AddScoped<IServiceAuthor, ServiceAuthor>();
builder.Services.AddScoped<IServiceBook, ServiceBook>();

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
