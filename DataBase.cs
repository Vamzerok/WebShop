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
        StreamReader sr;
        string path;

        public List<Order> Orders;
        public List<Product> Products;
        public List<Customer> Customers;

        public DataBase(string path) 
        {
            serializer = new JsonSerializer();
            sr = new StreamReader(path);
            this.path = path;

            Orders = new List<Order>();
            Products = new List<Product>();
            Customers = new List<Customer>();

            Deserialize();
        }

/*        public List<T> Select<T>(Table from, Func<T,bool> where) where T : Record
        {
            switch (from)
            {
                case Table.Orders:
                    return Orders.Where(where);
                    break;
                case Table.Products:
                    break;
                case Table.Customers:
                    break;
            }
        }
*/        

        public List<string> GetKeys(Table table)
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

        private void Deserialize()
        {
            JObject file = JObject.Parse(sr.ReadToEnd());

            //deserializing orders
            List<JToken> orders = file["rendeles"].Children().ToList();
            orders.ForEach(e => Orders.Add(e.ToObject<Order>()));

            //deserializing products 
            List<JToken> products = file["termek"].Children().ToList();
            products.ForEach(e => Products.Add(e.ToObject<Product>()));

            //deserializing customers 
            List<JToken> customers = file["ugyfel"].Children().ToList();
            customers.ForEach(e => Customers.Add(e.ToObject<Customer>()));
        }
    }
}
