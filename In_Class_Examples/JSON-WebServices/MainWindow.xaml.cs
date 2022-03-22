using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
