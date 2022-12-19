using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shop_app.api.Models;
using shop_app.contract.DTO;
using shop_app.entity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OAuthController: ControllerBase
    {
        private readonly ILogger _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IValidator<UserLoginDto> _validator;
        private IConfiguration _config;

        public OAuthController(ILogger logger, SignInManager<User> signInManager, UserManager<User> userManager, IValidator<LoginModel> validator, IConfiguration config)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _validator = validator;
            _config = config;
        }

        private string JSONWebToken(UserDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] UserLoginDto dto)
        {
            string token;
            var validation = await _validator.ValidateAsync(dto);
            if (validation.IsValid)
            {
                var dto = new UserDto() { Email = "ensar.makas@gmail.com", Name = "ensar", UserName = "emakas" };
                token = JSONWebToken(dto);
                Ok(token);
            }
            return BadRequest("invalid arguments");
        }
    }
}
