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

namespace WPF_Classes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            bool validationIsSuccessfull = true;

            if (string.IsNullOrWhiteSpace(txtImage.Text) == true)
            {
                //MessageBox.Show("You need to enter a URL for the image.");
                //return;
                message += "You need to enter a URL for the image.\n";
                validationIsSuccessfull = false;
            }

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text) == true)
            {
                //MessageBox.Show("You need to enter a URL for the image.");
                //return;
                message += "You need to enter a valid value for the manufacturer.\n";
                validationIsSuccessfull = false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                //MessageBox.Show("You need to enter a URL for the image.");
                //return;
                message += "You need to enter a valid value for the name\n";
                validationIsSuccessfull = false;
            }
            double price;
            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                //MessageBox.Show("You need to enter a URL for the image.");
                //return;
                message += "You need to enter a valid value for the price.\n";
                validationIsSuccessfull = false;
            }

            if (validationIsSuccessfull == false)
            {
                MessageBox.Show(message);
                return;
            }

            Toy t = new Toy()
            {
                Image = txtImage.Text,
                Manufacturer = txtManufacturer.Text,
                Name = txtName.Text,
                Price = price
            };
            //t.Image = txtImage.Text;

            lstToys.Items.Add(t);
        }

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;

            imgPicture.Source = new BitmapImage(new Uri(selectedToy.Image));

            MessageBox.Show(selectedToy.GetAisle());


        }
    }
}
