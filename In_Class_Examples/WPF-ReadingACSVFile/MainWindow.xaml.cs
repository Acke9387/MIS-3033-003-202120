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

namespace WPF_ReadingACSVFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<SalesDataItem> Data = new List<SalesDataItem>();
        public MainWindow()
        {
            InitializeComponent();
            lstSalesData.Items.Clear();

            string[] linesOfFile = File.ReadAllLines("SalesJan2009.csv");

            for (int i = 1; i < linesOfFile.Length; i++)
            {
                SalesDataItem item = new SalesDataItem(linesOfFile[i], i);
                //     0              1      2        3         4   5    6       7          8              9        10       11
                //Transaction_date,Product,Price,Payment_Type,Name,City,State,Country,Account_Created,Last_Login,Latitude,Longitude
                //string[] pieces = linesOfFile[i].Split(',');
                //item.Transaction_date = Convert.ToDateTime(pieces[0]);
                //item.Product = pieces[1];


                if (cboPaymentTypes.Items.Contains(item.Payment_Type) == false)
                {
                    cboPaymentTypes.Items.Add(item.Payment_Type);
                }

                lstSalesData.Items.Add(item);
                Data.Add(item);
            }


        }

        private void cboPaymentTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string paymentType = cboPaymentTypes.SelectedItem.ToString();

            lstSalesData.Items.Clear();
            foreach (SalesDataItem item in Data)
            {

                if (item.Payment_Type == paymentType)
                {
                    lstSalesData.Items.Add(item); 
                }
            }

        }

        private void lstSalesData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SalesDataItem selectedItem = (SalesDataItem)lstSalesData.SelectedItem;

            MessageBox.Show($"You selected {selectedItem}");
        }
    }
}
