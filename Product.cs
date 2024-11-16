using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public override ListBox RenderDetails()
        {
            ListBox listBox = new ListBox();

            {
                Grid grid = new Grid();
                for (int i = 0; i < 2; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());

                var tb = new TextBlock()
                {
                    Text = "megnevezes: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = megnevezes.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.megnevezes = tbin.Text; };
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
                    Text = "ar: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = ar.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.ar = double.Parse(tbin.Text); };
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
                    Text = "mennyiseg: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = mennyiseg.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.mennyiseg = int.Parse(tbin.Text); };
                Grid.SetColumn(tbin, 1);

                grid.Children.Add(tb);
                grid.Children.Add(tbin);
                listBox.Items.Add(grid);
            }

            return listBox;
        }
    }
}
