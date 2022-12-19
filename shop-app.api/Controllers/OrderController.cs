using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shop_app.api.Exceptions;
using shop_app.api.Models;
using shop_app.api.Requests.Abstract;
using shop_app.api.Requests.Commands;
using shop_app.api.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.shared.Utilities.Results.ComplexTypes;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using shop_app.api.ControllerExtensions;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<OrderDto> _validator;
        private IConfiguration _config;

        public OrderController(IMediator mediator, IValidator<OrderDto> validator, IConfiguration config)
        {
            _mediator = mediator;
            _validator = validator;
            _config = config;
        }

        private bool ValidateToken(string token)
        { // Validate JWT Token
            if (token.Equals("<token>"))
                return false;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("emakas");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = false,

                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("authorize")]
        public IActionResult Auth()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Produces("application/json")] //
        public async Task<IEnumerable<Order>> GetAllOrders() // Authorization - Authentication
        {//TODO: token'i header kısmından çek
            string token = Request.Headers.Authorization.FirstOrDefault("Bearer <token>").Split(' ')[1];
            if (ValidateToken(token))
            {
                var result = await _mediator.Send(new GetAllOrdersQuery());
                if (result.Status == ResultStatus.Success)
                    return result.Payload;
            }
            throw new BadRequestException(null,null);
        }

        [HttpPost]
        [Route("submit")] // url params
        public async Task<ActionResult<Order>> SubmitOrder([FromBody] OrderDto orderDto)
        {// TODO: Kod yerine exception at
            var validation = await _validator.ValidateAsync(orderDto);

            if (validation.IsValid)
            {
                var result = await _mediator.Send(new GetProductQuery(orderDto.ProductId));
                if (result.Status == ResultStatus.Success)
                {
                    var submitResult = await _mediator.Send(new SubmitOrderCommand()
                    {
                        Product = result.Payload,
                        UserId = orderDto.UserId,
                        Note = orderDto.Note,
                    });
                    if (submitResult.Status == ResultStatus.Success)
                        return Created("Siparişiniz kaydedildi.",null);
                    throw new InternalServerException("Bir hata meydana geldi.",submitResult.Exception);
                }
                throw new NotFoundException("Sipariş için kaydedilecek ürün bulunamadı.",result.Exception);
            }
            throw new BadRequestException("Gönderilen form uygunsuz bilgiler içeriyor.",null);
        }


        [HttpDelete]
        [Route("/delete/{uri}")]
        public async Task<StatusCodeResult> DeleteOrder([FromRoute] string uri)// From route param
        {
            var result = await _mediator.Send(new GetCategoryByURIQuery(uri));
            if (result.Status == ResultStatus.Success)
            {
                var commandResult = await _mediator.Send(new DeleteCategoryCommand() { URI = result.Payload.URI});
                if (commandResult.Status == ResultStatus.Success)
                    return StatusCode((int) HttpStatusCode.OK);
                throw commandResult.Exception;
            }
            throw result.Exception;

        }


        [HttpGet]
        [Route("throwjwt")]
        public IActionResult ThrowJwt([FromQuery]string uname, [FromQuery] string email)
        {
            UserViewModel user = null;
            //Validate the User Credentials  

            //Demo Purpose, This is  HardCoded User Information  you can use here dynamically data
            //Demo Purpose, This is  HardCoded User Information  you can use here dynamically data
            //Demo Purpose, This is  HardCoded User Information  you can use here dynamically data
            user = new UserViewModel { Username = uname, EmailAddress = email};
            string token = JSONWebToken(user);
            return Ok(token);
            
        }
        private string JSONWebToken(UserViewModel userInfo)
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

    }
}
