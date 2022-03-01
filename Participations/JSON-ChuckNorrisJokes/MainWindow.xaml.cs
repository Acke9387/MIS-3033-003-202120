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

namespace JSON_ChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



            string url = "https://api.chucknorris.io/jokes/categories";
            cboCategories.Items.Add("All");
            cboCategories.SelectedIndex = 0;

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);
                foreach (string category in categories)
                {
                    cboCategories.Items.Add(category);
                }
            }

        }

        private void cboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string category = cboCategories.SelectedItem.ToString();
            //Get random joke from a category: https://api.chucknorris.io/jokes/random?category={category}
            //Get random joke: https://api.chucknorris.io/jokes/random

            string url = "https://api.chucknorris.io/jokes/random";
            txtJoke.Text = string.Empty;
            if (category != "All")
            {
                url += $"?category={category}";
            }

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                ChuckNorrisAPI joke = JsonConvert.DeserializeObject<ChuckNorrisAPI>(json);

                txtJoke.Text = joke.Joke;
            }
        }
    }
}
