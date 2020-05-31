using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/orders/{orderId:int}/items")]
    public class OrderItemController:Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<OrderItemController> logger;
        private readonly IMapper mapper;

        public OrderItemController(IDutchRepository repository,ILogger<OrderItemController>logger,IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get(int orderId)
        {
            try
            {
                var order = repository.GetOrderById(orderId);
                if (order != null)
                    return Ok(mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
                else
                    return NotFound();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int orderId,int id)
        {
            try
            {
                var order = repository.GetOrderById(orderId);
                if (order != null)
                {
                    var item = order.Items.Where(x => x.Id == id).FirstOrDefault();
                    if (item!=null)
                        return Ok(mapper.Map<OrderItem, OrderItemViewModel>
                            (item));
                }
              
                    return NotFound();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

    }
}
