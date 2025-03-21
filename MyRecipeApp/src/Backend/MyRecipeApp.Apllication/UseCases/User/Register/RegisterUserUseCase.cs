using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyRecipeApp.Apllication.Services.Automapper;
using MyRecipeApp.Communications.Requests;
using MyRecipeApp.Communications.Responses;
using MyRecipeApp.Domain.Entities;
using MyRecipeApp.Exceptions.ExceptionsBase;

namespace MyRecipeApp.Apllication.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {
            ValidateUser(request);

            var mapper = new AutoMapper.MapperConfiguration(options =>
            { options.AddProfile(new MapperProfile()); 
            }).CreateMapper();

            var user = mapper.Map<Domain.Entities.User>(request);






            return new ResponseRegisteredUserJson 
            {
                Name = request.Name 
            };

        }


        private void ValidateUser(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }


    }
}
