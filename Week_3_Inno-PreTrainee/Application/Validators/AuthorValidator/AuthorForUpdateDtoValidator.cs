using FluentValidation;
using Week_3_Inno_PreTrainee.Application.Dto.AuthorDto;

namespace Week_3_Inno_PreTrainee.Application.Validators.AuthorValidator
{
    public class AuthorForUpdateDtoValidator : AbstractValidator<AuthorForUpdateDto>
    {
        public AuthorForUpdateDtoValidator()
        {
            RuleFor(author => author.Name)
            .NotEmpty().WithMessage("Name обязательное поле");

            RuleFor(author => author.DateOfBirth)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Дата не может быть позже текущей.");
        }
    }
}
