using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXE_Order.Models
{
    public class List
    {
        public List<string> clients { get; set; }
        public List()
        {
            clients = new List<string>();
        }
    }
}
