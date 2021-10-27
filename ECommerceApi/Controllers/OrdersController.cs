using ECommerceApi.Filters;
using ECommerceApi.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{
    public class OrdersController : ControllerBase
    {
        [HttpPost("/orders")]
        [ValidateModel]
        public async Task<ActionResult> PlaceOrder([FromBody] OrderPostRequest orderPostRequest)
        {
           return StatusCode(201, new { });
        }
    }
}
