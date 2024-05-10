using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Api.Controllers
{
    public class AuthController : MainController
    {
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser(UserViewModel userViewModel, [FromServices] IAuthAppService authAppService)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var sigInResponse = await authAppService.SignInResultVerify(userViewModel);
            return Ok(sigInResponse);
        }
    }
}
