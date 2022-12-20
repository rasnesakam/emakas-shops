﻿using MediatR;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.Requests.Queries
{
    public class GetProductsRequest: IRequest<ServiceResult<IEnumerable<Product>>>
    {
        public int Section { get; set; }
        public int Size { get; set; }
    }
}
