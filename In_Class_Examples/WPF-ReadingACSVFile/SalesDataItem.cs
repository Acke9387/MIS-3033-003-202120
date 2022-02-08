using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ReadingACSVFile
{
    internal class SalesDataItem
    {
        public DateTime Transaction_date { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public string Payment_Type { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Account_Created { get; set; }
        public string Last_Login { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public SalesDataItem()
        {
            Transaction_date = DateTime.Now;
            Product          = string.Empty;
            Price            = 0;
            Payment_Type     = string.Empty;
            Name             = string.Empty;
            City             = string.Empty;
            State            = string.Empty;
            Country          = string.Empty;
            Account_Created  = string.Empty;
            Last_Login       = string.Empty;
            Latitude         = string.Empty;
            Longitude        = string.Empty;

        }

        public SalesDataItem(string stuff, int lineNumber = 0)
        {
            
            //     0              1      2        3         4   5    6       7          8              9        10       11
            //Transaction_date,Product,Price,Payment_Type,Name,City,State,Country,Account_Created,Last_Login,Latitude,Longitude
            string[] pieces = stuff.Split(',');
            Transaction_date = Convert.ToDateTime(pieces[0]);
            Product             = pieces[1];
            Price               = Convert.ToDouble(pieces[2]);
            Payment_Type        = pieces[3];
            Name                = pieces[4];
            City                = pieces[5];
            State               = pieces[6];
            Country             = pieces[7];
            Account_Created     = pieces[8];
            Last_Login          = pieces[9];
            Latitude            = pieces[10];
            Longitude           = pieces[11];
        }

        public override string ToString()
        {
            return $"{Product} sold at {Price.ToString("C")} to {Name} with {Payment_Type}.";
        }


    }
}
