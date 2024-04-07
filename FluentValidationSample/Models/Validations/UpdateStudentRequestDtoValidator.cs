using FluentValidation;
using FluentValidationSample.Models.DTO;

namespace FluentValidationSample.Models.Validations
{
    public class UpdateStudentRequestDtoValidator : AbstractValidator<UpdateStudentRequestDto>
    {
        public UpdateStudentRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not valid");

        }
    }
}
