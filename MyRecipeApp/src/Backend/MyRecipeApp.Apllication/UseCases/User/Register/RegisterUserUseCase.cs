using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyRecipeApp.Apllication.Services.Automapper;
using MyRecipeApp.Apllication.Services.Criptography;
using MyRecipeApp.Communications.Requests;
using MyRecipeApp.Communications.Responses;
using MyRecipeApp.Domain.Entities;
using MyRecipeApp.Domain.Repositories.User;
using MyRecipeApp.Exceptions.ExceptionsBase;

namespace MyRecipeApp.Apllication.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            var mapper = new AutoMapper.MapperConfiguration(options => options.AddProfile(new MapperProfile())).CreateMapper();
            var passwordCriptography = new PasswordEncripter();

            ValidateUser(request);

            var user = mapper.Map<Domain.Entities.User>(request);
            user.Password = passwordCriptography.Encrypt(request.Password);
            

            await _userWriteOnlyRepository.Add(user);



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
