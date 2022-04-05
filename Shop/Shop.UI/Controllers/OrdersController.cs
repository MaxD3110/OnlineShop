﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.OrdersAdmin;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class OrdersController : Controller
    {
        [HttpGet("")]
        public IActionResult GetOrders(
            int status,
            [FromServices]GetOrders getOrders) => Ok(getOrders.Do(status));

        [HttpGet("{id}")]
        public IActionResult GetOrder(
            int id,
            [FromServices] GetOrder getOrder) => Ok(getOrder.Do(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(
            int id,
            [FromServices] UpdateOrder updateOrder)
        { 
            var success = await updateOrder.DoAsync(id) > 0;
            if(success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> DecreaseOrder(
            int id,
            [FromServices] DecreaseOrder decreaseOrder)
        {
            var success = await decreaseOrder.DoAsync(id) > 0;
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
