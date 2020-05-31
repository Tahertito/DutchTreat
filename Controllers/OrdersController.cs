using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net;
using AutoMapper;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DutchTreat.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize( AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<OrdersController> logger;
        private readonly IMapper mapper;

        public OrdersController(IDutchRepository repository, ILogger<OrdersController> logger,IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               
               var orders = mapper.Map<IEnumerable<Order>,IEnumerable<OrderViewModel>>(repository.GetAllOrders());
                return Ok(orders);
            }
            catch (Exception e)
            {
                logger.LogInformation("faild to get orders : {0}", e);
                return BadRequest("faild to get orders");

            }
        }
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult Get(int id)
        {
            try
            {
                var order = repository.GetOrderById(id);
                if (order != null)
                    return Ok(mapper.Map<Order,OrderViewModel>(order));
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                logger.LogInformation("faild to get orders : {0}", e);
                return BadRequest("faild to get orders");

            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {

                var order = mapper.Map< OrderViewModel,Order>(model);
                if (order.OrderDate == DateTime.MinValue)
                {
                    order.OrderDate = DateTime.UtcNow;
                }
                repository.AddNewOrder(order);
                if (repository.SaveChanges())
                    return Created(HttpContext.Request.Host.Value + $"/api/orders/{order.Id}", mapper.Map<Order,OrderViewModel>(order));


            }
            catch (Exception e)
            {
                logger.LogInformation("faild to post new orders : {0}", e);

            }
            return BadRequest("faild to get orders");

        }

    }
}
