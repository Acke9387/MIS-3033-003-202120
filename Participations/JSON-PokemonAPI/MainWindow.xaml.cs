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

namespace JSON_PokemonAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {

                string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=0&limit=1200").Result;

                AllPokemonAPI api = JsonConvert.DeserializeObject<AllPokemonAPI>(json);

                cboPokemon.ItemsSource = api.results;

                //api.results.ForEach( poke => cboPokemon.Items.Add(poke));
                //foreach (var poke in api.results)
                //{
                //    cboPokemon.Items.Add(poke);
                //}
            }
        }

        private void cboPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Pokemon pokemon = cboPokemon.SelectedItem as Pokemon;
            PokemonInfoWIndow info = new PokemonInfoWIndow();

            info.PopulateData(pokemon);

            info.ShowDialog();


        }


    }
}
