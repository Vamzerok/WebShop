using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public override ListBox RenderDetails()
        {
            ListBox listBox = new ListBox();
            {
                Grid grid = new Grid();
                for (int i = 0; i < 2; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());

                var tb = new TextBlock()
                {
                    Text = "nev: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = nev.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.nev = tbin.Text; };
                Grid.SetColumn(tbin, 1);

                grid.Children.Add(tb);
                grid.Children.Add(tbin);
                listBox.Items.Add(grid);
            }

            {
                Grid grid = new Grid();
                for (int i = 0; i < 2; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());

                var tb = new TextBlock()
                {
                    Text = "cim: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = cim.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.cim = tbin.Text; };
                Grid.SetColumn(tbin, 1);

                grid.Children.Add(tb);
                grid.Children.Add(tbin);
                listBox.Items.Add(grid);
            }

            {
                Grid grid = new Grid();
                for (int i = 0; i < 2; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());

                var tb = new TextBlock()
                {
                    Text = "rang: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = rang.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.rang = tbin.Text; };
                Grid.SetColumn(tbin, 1);

                grid.Children.Add(tb);
                grid.Children.Add(tbin);
                listBox.Items.Add(grid);
            }

            return listBox;
        }
    }
}
