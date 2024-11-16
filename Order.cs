using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        //just shit
        public override ListBox RenderDetails()
        {
            ListBox listBox = new ListBox();
            {
                Grid grid = new Grid();
                for (int i = 0; i < 2; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());

                var tb = new TextBlock()
                {
                    Text = "ugyfel_id: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = ugyfel_id.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.ugyfel_id = int.Parse(tbin.Text); };
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
                    Text = "termek_id: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = termek_id.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.termek_id = int.Parse(tbin.Text); };
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
                    Text = "datum: "
                };
                Grid.SetColumn(tb, 0);

                var tbin = new TextBox()
                {
                    Text = datum.ToString(),
                };
                tbin.TextChanged += (sender, e) => { this.datum = DateTime.Parse(tbin.Text); };
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
