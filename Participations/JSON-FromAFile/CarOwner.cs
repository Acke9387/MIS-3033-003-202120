using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_FromAFile
{
    public class CarOwner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public CarOwner()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Make = string.Empty;
            Model = string.Empty;
            Year = 0;
            Color = string.Empty;

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName[0]}. - {Color} {Make} {Model} {Year.ToString("G0")}";
        }
    }
}
