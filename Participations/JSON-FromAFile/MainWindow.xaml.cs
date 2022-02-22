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

namespace JSON_FromAFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CarOwner> CarOwners;

        public MainWindow()
        {
            InitializeComponent();

            string json = File.ReadAllText("Mock_Data_Car_Owners.json");

            CarOwners = JsonConvert.DeserializeObject<List<CarOwner>>(json);

            cboColors.Items.Add("All");
            cboColors.SelectedIndex = 0;

            foreach (CarOwner carOwner in CarOwners)
            {
                if (cboColors.Items.Contains(carOwner.Color) == false)
                {
                    cboColors.Items.Add(carOwner.Color);
                }

                lstResults.Items.Add(carOwner);
            }



        }

        private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboColors.SelectedItem == null)
            {
                return;
            }
            string selectedColor = cboColors.SelectedItem.ToString();
            lstResults.Items.Clear();
            foreach (CarOwner carOwner in CarOwners)
            {
                if (carOwner.Color == selectedColor)
                {
                    lstResults.Items.Add(carOwner);
                }
                else if (selectedColor == "All")
                {
                    lstResults.Items.Add(carOwner);
                }

            }
        }

        private void lstResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowCarOwnerDetails wnd = new WindowCarOwnerDetails();
            CarOwner selected = (CarOwner) lstResults.SelectedItem;

            //wnd.SelectedOwner = selected; 
            wnd.PopulateData(selected);
            wnd.ShowDialog();
        }
    }
}
