﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shop_app.api.Models;
using shop_app.api.Requests.Abstract;
using shop_app.api.Requests.Commands;
using shop_app.api.Requests.Queries;
using shop_app.entity;
using shop_app.shared.Utilities.Results.ComplexTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<OrderDto> _validator;

        public OrderController(IMediator mediator, IValidator<OrderDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
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

        [HttpGet("orders")]
        [Route("GetAllOrders")] //
        public async Task<IEnumerable<Order>> GetAllOrders() // Authorization - Authentication
        {//TODO: token'i header kısmından çek
            string token = Request.Headers.Authorization.FirstOrDefault("Bearer <token>").Split(' ')[1];
            if (ValidateToken(token))
            {
                var result = await _mediator.Send(new GetAllOrdersQuery());
                if (result.Status == ResultStatus.Success)
                    return result.Payload;
            }
            return new List<Order>();
        }

        [HttpPost("submit")]
        [Route("")] // url params
        public async Task<StatusCodeResult> SubmitOrder([FromBody] OrderDto orderDto)
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
                        return StatusCode(201);
                    return StatusCode(500);
                }
                return StatusCode(404);
            }
            else
                return StatusCode(401);
        }


        [HttpDelete("{uri}")]
        public async Task<StatusCodeResult> DeleteOrder(string uri)//
        {
            var result = await _mediator.Send(new GetCategoryByURIQuery(uri));
            if (result.Status == ResultStatus.Success)
            {

                var result = await _mediator.Send(new DeleteCategoryCommand(uri));
            }
        
        }

        [HttpPut()]
        //şalsdkaşd


    }
}
