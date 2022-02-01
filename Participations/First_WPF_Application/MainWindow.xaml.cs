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

namespace First_WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lblOutput.Visibility = Visibility.Hidden;

            for (int i = 0; i < 100; i++)
            {
                lstData.Items.Add(i);
            }
            
            cboChoices.Items.Add(5);
            cboChoices.Items.Add("Red");

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string choice = cboChoices.Text;
            MessageBox.Show($"You selected {choice}");

            string searchItem = txtName.Text;
            webGoogle.Source = new Uri($"https://www.google.com/search?q={searchItem}");

            if (chk1.IsChecked == true)
            {
                MessageBox.Show("You checked the first checkbox");
            }
            else
            {
                MessageBox.Show("You did NOT check the first checkbox");
            }

            return;
            string name = txtName.Text;
            string dobAsString = txtDOB.Text;
            DateTime dobAsDateTime;
            if (dtpDOB.SelectedDate.HasValue == true)
            {
                dobAsDateTime = dtpDOB.SelectedDate.Value; 
            }
            else
            {
                MessageBox.Show("You must select a birthdate!");
                return;
            }

            TimeSpan age = DateTime.Now - Convert.ToDateTime(dobAsString);
            TimeSpan age2 = DateTime.Now - dobAsDateTime;
            double yearsDiff = age.TotalDays / 365;
            int years = Convert.ToInt32(Math.Floor(yearsDiff));
            //years = (int)Math.Floor(yearsDiff); casting

            if (years == 0 )
            {
                lblOutput.Content = $"Hello {name}, you have not been born yet!"; 
            }
            else if (years > 1)
            {
                lblOutput.Content = $"Hello {name}, you are {years} years old!!";
            }
            else
            {
                lblOutput.Content = $"Hello {name}, you are {years} year old!!";
            }

            lblOutput.Visibility = Visibility.Visible;
        }

        private void txtName_MouseEnter(object sender, MouseEventArgs e)
        {
            txtName.Background = Brushes.Yellow;
        }

        private void txtName_MouseLeave(object sender, MouseEventArgs e)
        {
            txtName.Background = Brushes.White;
        }
    }
}
