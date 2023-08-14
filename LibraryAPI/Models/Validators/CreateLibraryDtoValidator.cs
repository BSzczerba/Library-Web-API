using FluentValidation;
using LibraryAPI.Entities;

namespace LibraryAPI.Models.Validators
{
    public class CreateLibraryDtoValidator:AbstractValidator<CreateLibraryDto>
    {
        public CreateLibraryDtoValidator(LibraryDBContext dBContext)
        {
            RuleFor(x => x.Name).MaximumLength(25).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.City).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Strett).MaximumLength(50).NotEmpty();
            RuleFor(x => x.ZipCode).NotEmpty();
        }
    }
}
