using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeApp.Apllication.UseCases.User.Register;
using MyRecipeApp.Communications;
using MyRecipeApp.Communications.Requests;
using MyRecipeApp.Communications.Responses;

namespace MyRecipeApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {



            var useCase = new RegisterUserUseCase();

            var result = useCase.Execute(request);

            return Created(string.Empty, result);

        }
    }
}
