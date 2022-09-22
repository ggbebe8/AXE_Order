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
    public class calcController : ControllerBase
    {

        // GET api/<calcController>/5
        [HttpGet("({id}, {id2})")]
        public Calc Get(int id, int id2)
        {
            Calc calc = new Calc();
            var query = (from info in Models.Data.OrderInfo_DataList
                         where info.ExecutionAmount >= id && info.ExecutionAmount < id2
                         select info.ExecutionVolumn).ToList();
            calc.average = query.Average();
            double sum = query.Sum(d => Math.Pow(d - calc.average, 2));
            calc.std = Math.Sqrt((sum) / query.Count());
            return calc;
        }

    }
}
