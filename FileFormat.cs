using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    internal class FileFormat
    {
        public List<Order> rendeles;
        public List<Product> termek;
        public List<Customer> ugyfel;

        public FileFormat() 
        {
            rendeles = new List<Order>();
            termek = new List<Product>();
            ugyfel = new List<Customer>();
        }
    }
}
