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
using System.Windows.Shapes;

namespace JSON_PokemonAPI
{
    /// <summary>
    /// Interaction logic for PokemonInfoWIndow.xaml
    /// </summary>
    public partial class PokemonInfoWIndow : Window
    {
        PokemonInfo info = null;
        string status = "";
        public PokemonInfoWIndow()
        {
            InitializeComponent();
        }

        public void PopulateData(Pokemon pokemon)
        {

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(pokemon.url).Result;

                info = JsonConvert.DeserializeObject<PokemonInfo>(json);

                lblTitle.Content = info.name;
                txtHeight.Text = info.height.ToString("N");
                txtWeight.Text = info.weight.ToString("N");
                imgPic.Source = new BitmapImage(new Uri(info.sprites.front_default));
                status = "back";
                //imgPic.Tag = "back";
            }

        }

        private void btnDance_Click(object sender, RoutedEventArgs e)
        {
            if (status == "back")
            {
                imgPic.Source = new BitmapImage(new Uri(info.sprites.back_default));
                status = "front";
            }
            else
            {
                imgPic.Source = new BitmapImage(new Uri(info.sprites.front_default));
                status = "back";
            }
        }
    }
}
