using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    internal class Order : Record
    {

        public int ugyfel_id { get; set; }
        public int termek_id { get; set; }
        public DateTime datum { get; set; }
        public int mennyiseg { get; set; }

        [JsonConstructor]
        public Order(int id, int ugyfel_id, int termek_id, DateTime datum, int mennyiseg) : base(id)
        {
            this.ugyfel_id = ugyfel_id;
            this.termek_id = termek_id;
            this.datum = datum;
            this.mennyiseg = mennyiseg;
        }
        public Order(int id) : base(id) { }

    }
}
