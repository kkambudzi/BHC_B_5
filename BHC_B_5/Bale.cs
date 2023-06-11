using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHC_B_5
{
    class Bale
    {
        public string Barcode { get; set; }
        public string Grade { get; set; }
        public decimal Price { get; set; }
        public int Mass { get; set; }

        public Bale(string barcode, string grade, decimal price, int mass)
        {
            Barcode = barcode;
            Grade = grade;
            Price = price;
            Mass = mass;
        }
    }
}
