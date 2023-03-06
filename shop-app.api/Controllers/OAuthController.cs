using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shop_app.contract.DTO;
using shop_app.contract.HttpExceptions;
using shop_app.entity;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OAuthController: ControllerBase
    {
        private readonly ILogger _logger;
        private readonly SignInManager<Seller> _signInManager;
        private readonly UserManager<Seller> _userManager;
        private readonly IValidator<UserLoginDto> _validator;
        private IConfiguration _config;

        public OAuthController(ILogger logger, SignInManager<Seller> signInManager, UserManager<Seller> userManager, IValidator<UserLoginDto> validator, IConfiguration config)
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
            var token = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
              claims: new Claim[] {new Claim("sub", userInfo.Id.ToString())},
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("Auth/Seller")]
        public async Task<IActionResult> AuthSeller([FromBody] UserLoginDto userLogin)
        {
            string token;
            var validation = await _validator.ValidateAsync(userLogin);
            if (validation.IsValid)
            {
                Seller user = await _userManager.FindByEmailAsync(userLogin.UserName);
                if (user == null)
                    user = await _userManager.FindByNameAsync(userLogin.UserName);
                if (user == null)
                    throw new NotFoundErrorException("User could't found");
                var signInResult = await _signInManager.PasswordSignInAsync(user,userLogin.Password,true,false);
                
                if (signInResult.Succeeded)
                {
                    var userDto = new UserDto() { Id=user.Id, Email = user.Email, Username = "emakas" };
                    token = JSONWebToken(userDto);
                    return Ok(new
                    {
                        Status = true,
                        Token = token
                    });
                }

                return Unauthorized("UnAuthorized");
            }
            return BadRequest("invalid arguments");
        }

        [HttpPost]
        [Route("Auth/Seller/SignUp")]
        public async Task<ActionResult<Seller>> CreateSeller([FromBody] SellerSignDto sellerDto)
        {
            Seller seller = new Seller
            {
                Name = sellerDto.Name,
                Surname= sellerDto.Surname,
                UserName = sellerDto.Username,
                Email = sellerDto.Email
            };
            seller.PasswordHash = _userManager.PasswordHasher.HashPassword(seller,sellerDto.Password);
            var createResult = await _userManager.CreateAsync(seller);
            if (createResult.Succeeded)
            { 
                var pwdToken = await _userManager.GeneratePasswordResetTokenAsync(seller);
                var result = await _userManager.ResetPasswordAsync(seller, pwdToken, sellerDto.Password);
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(seller);
                await _userManager.ConfirmEmailAsync(seller, emailToken);
                return Ok(seller);
            }
            return BadRequest("");
        }

        [HttpPost]
        [Route("Auth/Customer")]
        public async Task<IActionResult> AuthCustomer([FromBody] UserLoginDto userLogin)
        {
            string token;
            var validation = await _validator.ValidateAsync(userLogin);
            if (validation.IsValid)
            {
                Seller user = await _userManager.FindByEmailAsync(userLogin.UserName);
                if (user == null)
                    user = await _userManager.FindByNameAsync(userLogin.UserName);
                if (user == null)
                    throw new NotFoundErrorException("User could't found");
                // var signInResult = _signInManager.SignInAsync();
                var signInResult = await _signInManager.PasswordSignInAsync(user, userLogin.Password, true, false);
                if (signInResult.Succeeded)
                {
                    var userDto = new UserDto() { Email = user.Email, Username = "emakas" };
                    token = JSONWebToken(userDto);
                    return Ok(token);
                }
            }
            return BadRequest("invalid arguments");
        }
    }
}
