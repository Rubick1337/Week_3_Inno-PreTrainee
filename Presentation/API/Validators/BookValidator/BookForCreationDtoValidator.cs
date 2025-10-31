using FluentValidation;
using Week_3_Inno_PreTrainee.Application.Dto.BookDto;

namespace Week_3_Inno_PreTrainee.Presentation.Validators.BookValidator
{
    public class BookForCreationDtoValidator : AbstractValidator<BookForCreationDto>
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
