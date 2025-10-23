using FluentValidation;
using Week_3_Inno_PreTrainee.Application.Dto.BookDto;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Validators.BookValidator
{
    public class BookForUpdateDtoValidator : AbstractValidator<BookForCreationDto>
    {
        public BookForUpdateDtoValidator(IRepositoryBase<Author> authors)
        {
            RuleFor(book => book.Title)
            .NotEmpty().WithMessage("Title обязательное поле");

            RuleFor(book => book.PublishedYear)
            .NotEmpty().WithMessage("Год издания обязательное поля")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Дата не может быть позже текущей.");

            RuleFor(book => book.AuthorId)
                .Must(id => authors.GetById(id) != null)
                .WithMessage("Указанный AuthorId не существует.");
        }
    }
}
