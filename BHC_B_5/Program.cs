using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHC_B_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of bales to select from
            List<Bale> bales = new List<Bale>();
            bales.Add(new Bale("110000010", "TMOS", 4.50m, 120));
            bales.Add(new Bale("110000011", "TLOS", 5.50m, 110));
            bales.Add(new Bale("110000012", "TXLF", 350.00m, 130));
            bales.Add(new Bale("110000013", "TMOX", 0.50m, 90));
            bales.Add(new Bale("110000014", "TM1L", 1.50m, 80));

            // Set the agreed price and number of bales dynamically
            decimal agreedPrice = 5.00m;
            int numberOfBales = 3;

            // Select the qualifying bales
            List<Bale> qualifyingBales = SelectBale(bales, agreedPrice, numberOfBales);

            // Get the totals for the selected bales
            Tuple<int, decimal, decimal, decimal> totals = GetTotals(qualifyingBales);

            Console.WriteLine("Total Number of Bales Selected: " + totals.Item1);
            Console.WriteLine("Total Mass Selected: " + totals.Item2);
            Console.WriteLine("Average Price Selected: " + totals.Item3);
            Console.WriteLine("Total Gross Selected: " + totals.Item4);

            Console.ReadLine();
        }
        static List<Bale> SelectBale(List<Bale> bales, decimal agreedPrice, int numberOfBales)
        {
            // Filter out the bales with grades containing X
            List<Bale> filteredBales = bales.Where(b => !b.Grade.Contains("X")).ToList();

            // Sort the filtered bales by price in descending order
            filteredBales.Sort((b1, b2) => -1 * b1.Price.CompareTo(b2.Price));

            // Select the qualifying bales
            List<Bale> qualifyingBales = filteredBales.Where(b => b.Price >= agreedPrice).Take(numberOfBales).ToList();

            return qualifyingBales;
        }
        static Tuple<int, decimal, decimal, decimal> GetTotals(List<Bale> selectedBales)
        {
            int totalNumber = selectedBales.Count;
            decimal totalMass = selectedBales.Sum(b => b.Mass);
            decimal averagePrice = selectedBales.Average(b => b.Price);
            decimal totalGross = selectedBales.Sum(b => (b.Mass * b.Price));

            return Tuple.Create(totalNumber, totalMass, averagePrice, totalGross);
        }
    }
}
