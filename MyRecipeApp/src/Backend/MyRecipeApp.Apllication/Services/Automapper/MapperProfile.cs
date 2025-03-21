using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyRecipeApp.Communications.Requests;

namespace MyRecipeApp.Apllication.Services.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            RequestToDomain();
        }


        void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
                .ForMember(destination => destination.Password, option => option.Ignore());     // Maps every property EXCEPT "Password"
        }

        void DomainToRequest()
        {

        }

    }
}
