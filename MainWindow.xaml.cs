using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace WebShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataBase dataBase;
        private Record CurrentlyInDetailsView;
        public MainWindow()
        {
            InitializeComponent();

            dataBase = new DataBase("webshop.json");
            LoadListView(DataBase.Table.Orders);
        }

        //what desperation looks like
        private void LoadListView(DataBase.Table table) 
        {
            listbox.Items.Clear();
            switch (table)
            {
                case DataBase.Table.Orders:
                    listbox_label.Content = "Rendelések";
                    foreach(var r in dataBase.Orders)
                    {
                        var lbItem = new ListBoxItem();
                        lbItem.Selected += (sender, e) => { LoadDetailsView(r); };
                        lbItem.Content = $"Rendelés id: {r.id}";
                        listbox.Items.Add(lbItem);
                    }
                    break;
                case DataBase.Table.Customers:
                    listbox_label.Content = "Ügyfelek";
                    foreach(var r in dataBase.Customers)
                    {
                        var lbItem = new ListBoxItem();
                        lbItem.Selected += (sender, e) => { LoadDetailsView(r); };
                        lbItem.Content = $"{r.nev}";
                        listbox.Items.Add(lbItem);
                    }
                    break;
                case DataBase.Table.Products:
                    listbox_label.Content = "Termékek";
                    foreach(var r in dataBase.Products)
                    {
                        var lbItem = new ListBoxItem();
                        lbItem.Selected += (sender, e) => { LoadDetailsView(r); };
                        lbItem.Content = $"{r.megnevezes}";
                        listbox.Items.Add(lbItem);
                    }
                    break;
            }
        }

        private void LoadDetailsView(Record r)
        {
            btn_Copy.IsEnabled = true;
            btn_Delete.IsEnabled = true;
            btn_Save.IsEnabled = true;

            detailsViewMain.Children.Clear();
            detailsViewMain.Children.Add(r.RenderDetails());
        }

        //---------- events ----------  
        private void OrderClick(object sender, RoutedEventArgs e)
        {
            LoadListView(DataBase.Table.Orders);
        }
        private void ProductClick(object sender, RoutedEventArgs e)
        {
            LoadListView(DataBase.Table.Products);
        }
        private void CusotmerClick(object sender, RoutedEventArgs e)
        {
            LoadListView(DataBase.Table.Customers);
        } 

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            dataBase.Save("out.json");
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        } 
    }
}
