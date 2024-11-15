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

namespace WebShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var product = new Product(0) {
                megnevezes = "laptop",
                ar = 100,
                mennyiseg = 10
            };

            string json = JsonConvert.SerializeObject(product);
            using (StreamWriter sw = new StreamWriter("test.json"))
            using (StreamReader sr = new StreamReader("webshop.json"))
            {
                ITraceWriter traceWriter = new MemoryTraceWriter();
                JsonSerializer serializer = new JsonSerializer();
                JsonReader jsonReader = new JsonTextReader(sr);

                serializer.TraceWriter = traceWriter;
                FileFormat file = (FileFormat)serializer.Deserialize(jsonReader, typeof(FileFormat));

                serializer.Serialize(sw, file);

                File.WriteAllText("log.txt", traceWriter.ToString());


            }
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        } 
    }
}
