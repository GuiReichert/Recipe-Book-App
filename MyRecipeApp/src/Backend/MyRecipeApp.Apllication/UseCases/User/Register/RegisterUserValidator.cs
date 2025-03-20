using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyRecipeApp.Communications.Requests;
using MyRecipeApp.Exceptions;

namespace MyRecipeApp.Apllication.UseCases.User.Register
{
    internal class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>       //FluentValidations
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(u => u.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
            RuleFor(u => u.Email).EmailAddress().WithMessage(ResourceMessagesException.INVALID_EMAIL);
            RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_TOO_SHORT);
        }
    }
}
