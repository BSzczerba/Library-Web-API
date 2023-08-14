using FluentValidation;
using LibraryAPI.Entities;

namespace LibraryAPI.Models.Validators
{

        public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
        {
            public RegisterUserDtoValidator(LibraryDBContext dBContext)
            {
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).MinimumLength(6).NotEmpty();
                RuleFor(x => x.RepeatPassword).Equal(e => e.Password);
                RuleFor(x => x.Email).Custom((value, context) =>
                {
                    var emailUse = dBContext.Users.Any(u => u.Email == value);
                    if (emailUse)
                    {
                        context.AddFailure("Email", "That Email is taken");
                    }
                });
            }
        }
    
}
