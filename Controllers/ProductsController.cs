using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 [Produces("application/json")]
    public class ProductsController:Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IDutchRepository repository,ILogger<ProductsController>logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
       [HttpGet ]
       [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult Get()
        {
            try
            {
                
                return Ok(repository.GetAllProducts());

            }
            catch (Exception ex)
            {

                logger.LogInformation("logging exceptions : {0}", ex);
               return BadRequest("Bad Request");
            }
        }

        
    }
}
