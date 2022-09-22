using AXE_Order.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AXE_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class totalController : ControllerBase
    {
        // GET api/<totalController>/5
        [HttpGet("{byCode}")]
        public Total Get(string byCode)
        {
            var executionAmount = from info in Models.Data.OrderInfo_DataList
                      where info.CustomerCode == byCode
                                  select info.ExecutionAmount;

            Total total = new Models.Total();
            total.client_id = byCode;
            foreach(int amount in executionAmount)
                total.total += amount;
            
            return total;
        }

    }
}
