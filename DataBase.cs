using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Security.Permissions;
using Newtonsoft.Json.Linq;
using System.CodeDom;
using System.Windows;

namespace WebShop
{
    internal class DataBase
    {
        public enum Table
        {
            Orders,
            Products,
            Customers
        }        

        JsonSerializer serializer;
        string path;

        [JsonProperty("rendeles")]
        public List<Order> Orders;

        [JsonProperty("termek")]
        public List<Product> Products;
        
        [JsonProperty("ugyfel")]
        public List<Customer> Customers;

        public DataBase()
        {
            serializer = new JsonSerializer() { Formatting = Formatting.Indented};
        }

        public DataBase(string path) : this() 
        {
            this.path = path;

            Orders = new List<Order>();
            Products = new List<Product>();
            Customers = new List<Customer>();

            Deserialize();
        }

        [JsonConstructor]
        public DataBase(List<Order> rendeles, List<Customer> ugyfel, List<Product> termek) : this()
        {
            Orders = rendeles; 
            Products = termek;
            Customers = ugyfel;
        }

/*        public List<string> GetKeys(Table table)
        {
            List<string> keys = new List<string>();
            JObject jsonObject = JObject.Parse(File.ReadAllText(path));
            switch (table)
            {
                case Table.Orders:
                    keys = (jsonObject["rendeles"] as JObject).Properties().Select(p => p.Name).ToList();
                    break;
                case Table.Products:

                    break;
                case Table.Customers:
                    JObject ugyfelObj = (JObject)jsonObject["ugyfel"];
                    keys = ugyfelObj.Properties().Select(p => p.Name).ToList();
                    break;
            }
            return keys;
        }
*/
        private void Deserialize()
        {
            using (StreamReader reader = File.OpenText(this.path))
            {
                JObject file = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                //deserializing orders
                var orders = file["rendeles"].Children().ToList();
                orders.ForEach(e => Orders.Add(e.ToObject<Order>()));
                //OrderHeaders = (file["rendeles"].First() as JObject).Properties().Select(p => p.Name).ToList();

                //deserializing products 
                List<JToken> products = file["termek"].Children().ToList();
                products.ForEach(e => Products.Add(e.ToObject<Product>()));
                //ProductHeaders = (file["termek"].First() as JObject).Properties().Select(p => p.Name).ToList();

                //deserializing customers 
                List<JToken> customers = file["ugyfel"].Children().ToList();
                customers.ForEach(e => Customers.Add(e.ToObject<Customer>()));
                //CustomerHeaders = (file["ugyfel"].First() as JObject).Properties().Select(p => p.Name).ToList();
            }

        }
        public void Save(string path)
        {
            this.Serialize(path);
            MessageBox.Show($"Data successfully saved to: {path}");
        }
        private void Serialize(string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                serializer.Serialize(file, this);
            } 
        }
    }
}
