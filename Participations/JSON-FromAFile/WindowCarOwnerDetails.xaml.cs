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
using System.Windows.Shapes;

namespace JSON_FromAFile
{
    /// <summary>
    /// Interaction logic for WindowCarOwnerDetails.xaml
    /// </summary>
    public partial class WindowCarOwnerDetails : Window
    {

        public CarOwner SelectedOwner { get; set; }

        public WindowCarOwnerDetails()
        {
            InitializeComponent();
        }

        public void PopulateData(CarOwner owner)
        {
            txtColor.Text = owner.Color;
            txtMake.Text = owner.Make;
            txtModel.Text = owner.Model;
            txtYear.Text = owner.Year.ToString("G0");
            lblTitle.Content = $"{owner.FirstName} {owner.LastName} Car Details";
        }
    }
}
