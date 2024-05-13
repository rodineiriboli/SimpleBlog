using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleBlog.Api.Configuration;
using SimpleBlog.Api.Settings;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Services;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleBlog.Api.Controllers
{
    public class UserController : MainController
    {
        private readonly AppJwtSettings _jwtSettings;
        
        public UserController(IOptions<AppJwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        [Route("create-user")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CreateUserViewModel>), 200)]
        [ProducesResponseType(404)]
        public IActionResult AuthenticateUser(CreateUserViewModel userViewModel, [FromServices] IUserService userService)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var userViewModelResponse = userService.CreateUser(userViewModel);

            return Ok(userViewModelResponse);
        }

        [HttpGet]
        [Route("get-user")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<UserLoginResponseViewModel>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetUserByEmail(string email, [FromServices] IUserService userService)
        {
            var userViewModelResponse = userService.GetUserByEmail(email);

            if (userViewModelResponse is not null)
            {
                var userLoginResponseViewModel = await GenerateJwt(userViewModelResponse, email, userService);

                return Ok(userLoginResponseViewModel);
            }

            return NotFound();

        }

        private async Task<UserLoginResponseViewModel> GenerateJwt(UserViewModelResponse user, string email, IUserService userService)
        {
            string encodedToken = EncodeToken();

            return GetResponseToken(user, encodedToken);
        }

        private string EncodeToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Sender,
                Audience = _jwtSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }

        private UserLoginResponseViewModel GetResponseToken(UserViewModelResponse user, string encodedToken)
        {
            return new UserLoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_jwtSettings.ExpirationHours).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Active = user.Active,
                    InclusionDate = user.InclusionDate
                }
            };
        }
    }
}
