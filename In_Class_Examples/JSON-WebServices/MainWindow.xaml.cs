using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON_WebServices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://rickandmortyapi.com/api/character";

            //HttpClient client = new HttpClient();
            //client.Dispose();

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                RickAndMortyApi api = JsonConvert.DeserializeObject<RickAndMortyApi>(json);

                foreach (var character in api.results)
                {
                    lstCharacters.Items.Add(character);
                }

            }


        }

        private void lstCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selected = (Character)lstCharacters.SelectedItem;

            imgCharacter.Source = new BitmapImage(new Uri(selected.image));
        }
    }
}
