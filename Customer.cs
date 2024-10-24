using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    internal class Customer : Record
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
