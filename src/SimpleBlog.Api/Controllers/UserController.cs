using Microsoft.AspNetCore.Authorization;
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
        //private readonly IHubContext<HubProvider> _hubContext;

        public UserController(IOptions<AppJwtSettings> jwtSettings)//, IHubContext<HubProvider> hubContext)
        {
            _jwtSettings = jwtSettings.Value;
            //_hubContext = hubContext;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("authentication")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserLoginResponseViewModel), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetUserAuthorized(string email, string password, [FromServices] IUserService userService)
        {
            try
            {
                var userViewModelResponse = await userService.GetUserByEmailPassword(email, password);
                if (userViewModelResponse is not null)
                {
                    var userLoginResponseViewModel = GenerateJwt(userViewModelResponse);

                    return Ok(userLoginResponseViewModel);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return CustomResponse(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("create-user")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserViewModelResponse), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> AuthenticateUserAsync(CreateUserViewModel userViewModel, [FromServices] IUserService userService)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }
                var userViewModelResponse = await userService.CreateUser(userViewModel);
                if (userViewModelResponse is not null)
                {
                    var userLoginResponseViewModel = GenerateJwt(userViewModelResponse);

                    return Ok(userLoginResponseViewModel);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return CustomResponse(ex.Message);
            }
        }

        private UserLoginResponseViewModel GenerateJwt(UserViewModelResponse user)
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
                    new Claim(ClaimTypes.Email, user.Email),
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
