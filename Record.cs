using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    internal abstract class Record
    {
        public int id { get; set; }

        public Record(int id)
        {
            this.id = id; 
        }
    }
}
