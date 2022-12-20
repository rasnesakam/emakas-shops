using MediatR;
using shop_app.api.Models;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.Requests.Commands
{
    public class SubmitOrderRequest: IRequest<ServiceResult<Order>>
    {
        public OrderDto Order { get; }
    }
}
