using Newtonsoft.Json;
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
        public string nev { get; set; }
        public string cim { get; set; }
        public string rang { get; set; }

        [JsonConstructor]
        public Customer(int id, string nev, string cim, string rang) : base(id)
        {
            this.nev = nev;
            this.cim = cim;
            this.rang = rang;
        }
        public Customer(int id) : base(id) { }
    }
}
