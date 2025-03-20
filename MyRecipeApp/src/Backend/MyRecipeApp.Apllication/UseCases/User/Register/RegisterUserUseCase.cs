using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeApp.Communications.Requests;
using MyRecipeApp.Communications.Responses;
using MyRecipeApp.Exceptions.ExceptionsBase;

namespace MyRecipeApp.Apllication.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {
            ValidateUser(request);


            return new ResponseRegisteredUserJson 
            {
                Name = request.Name 
            };

        }


        private void ValidateUser(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }


    }
}
