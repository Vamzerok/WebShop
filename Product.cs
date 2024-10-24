using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    internal class Product : Record
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
