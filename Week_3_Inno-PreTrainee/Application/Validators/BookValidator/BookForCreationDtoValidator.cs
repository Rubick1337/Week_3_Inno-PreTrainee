using FluentValidation;
using Week_3_Inno_PreTrainee.Application.Dto.BookDto;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Validators.BookValidator
{
    public class BookForCreationDtoValidator : AbstractValidator<BookUpdateDto>
    {
        public BookForCreationDtoValidator()
        {
            RuleFor(book => book.Title)
            .NotEmpty().WithMessage("Title обязательное поле");

            RuleFor(book => book.PublishedYear)
            .NotEmpty().WithMessage("Год издания обязательное поля")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Дата не может быть позже текущей.");

        }
    }
}
