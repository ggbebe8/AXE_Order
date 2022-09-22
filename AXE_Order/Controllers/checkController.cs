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
    public class checkController : ControllerBase
    {
        // GET: api/<checkController>
        [HttpGet]
        public Check Get()
        {
            Check check = new Check();
            var query = (from info in Models.Data.OrderInfo_DataList
                        orderby info.Seq
                        select info.Seq).ToList();

            int cntMissing = 0;
            for(int i = 1; i <= query.Count; i++)
            {
                if (i != query[cntMissing])
                    check.missing.Add(i);
                else
                    cntMissing++;
            }

            return check;
        }
    }
}
