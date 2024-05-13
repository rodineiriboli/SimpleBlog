using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleBlog.Api.Settings;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
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
        public async Task<ActionResult> AuthenticateUserAsync(CreateUserViewModel userViewModel, [FromServices] IUserService userService)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var userViewModelResponse = await userService.CreateUser(userViewModel);

            if (userViewModelResponse is not null)
            {
                return Ok(userViewModelResponse);
            }

            return NoContent();

        }

        [HttpGet]
        //[AllowAnonymous]
        [Route("get-user")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<UserLoginResponseViewModel>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetUserByEmailAsync(string email, [FromServices] IUserService userService)
        {
            var userViewModelResponse = await userService.GetUserByEmail(email);

            if (userViewModelResponse is not null)
            {
                var userLoginResponseViewModel = await GenerateJwt(userViewModelResponse, email);

                return Ok(userLoginResponseViewModel);
            }

            return NotFound();

        }

        private async Task<UserLoginResponseViewModel> GenerateJwt(UserViewModelResponse user, string email)
        {
            string encodedToken = EncodeToken(user);

            return GetResponseToken(user, encodedToken);
        }

        private string EncodeToken(UserViewModelResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
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
