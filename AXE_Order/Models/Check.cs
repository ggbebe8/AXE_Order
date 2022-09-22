using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXE_Order.Models
{
    public class Check
    {
        public List<int> missing { get; set; }
        public Check()
        {
            missing = new List<int>();
        }
    }
}
