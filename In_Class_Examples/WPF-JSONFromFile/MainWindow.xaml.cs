using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF_JSONFromFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string json = File.ReadAllText("MOCK_DATA.json");

            List<Person> peeps = JsonConvert.DeserializeObject<List<Person>>(json);

            //lstPeeps.ItemsSource = peeps;

            foreach (Person person in peeps)
            {
                if (person.city.ToUpper()[0] == 'R')
                {
                    lstPeeps.Items.Add(person);

                }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string serializedData = JsonConvert.SerializeObject(lstPeeps.Items, Formatting.Indented);

            File.WriteAllText("filteredData.json", serializedData);
        }
    }
}
