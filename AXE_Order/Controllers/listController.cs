using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AXE_Order.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AXE_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class listController : ControllerBase
    {
        // GET: api/<listController>
        [HttpGet]
        public List Get()
        {
            List list = new List();

            var query = from info in Models.Data.OrderInfo_DataList
                        orderby info.CustomerCode
                        group info by info.CustomerCode into data
                        select data.Key;


            foreach (string amount in query)
                list.clients.Add(amount);

            return list;
        }
    }
}
