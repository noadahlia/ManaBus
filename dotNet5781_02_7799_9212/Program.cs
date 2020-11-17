using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class Program
    {
        static void Main(string[] args)
        {
            BuStation station1;
            Console.WriteLine("Enter the bus station key");
            int key = int.Parse(Console.ReadLine());
            while (key.ToString().Length != 6)
            {
                Console.WriteLine("ERROR. Enter a number with 6 digits:");
                key = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter the latitude position of the station");
            double latitude = double.Parse(Console.ReadLine());
            while (latitude < 31 || latitude>33.3)
            {
                Console.WriteLine("ERROR. Enter a number between 31 and 33.3:");
                latitude = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter the longitude position of the station");
            double longitude = double.Parse(Console.ReadLine());
            while (longitude < 34.3 || longitude < 35.5) 
            {
                Console.WriteLine("ERROR. Enter a number between 34.3 and 35.5:");
                longitude = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter the name of the station");
            string statioName= Console.ReadLine();

            station1 = new BusLineStation(key, latitude, longitude, statioName);
            BusLineStation x;
            int y = 10, c = 9;
            x = new BusLineStation(key, y);
        }

    }

   
}