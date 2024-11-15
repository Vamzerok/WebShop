using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    internal class Product : Record
    {
        public string megnevezes { get; set; }
        public double ar { get; set; }
        public int mennyiseg { get; set; }

        [JsonConstructor]
        public Product(int id, string megnevezes, double ar, int mennyiseg) : base(id)
        {
            this.megnevezes = megnevezes;
            this.ar = ar;
            this.mennyiseg = mennyiseg;
        }
        public Product(int id ) : base(id) { }
    }
}
