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
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository, IMapper mapper, PasswordEncripter passwordEncripter)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
        }



        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            ValidateUser(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);
            

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
