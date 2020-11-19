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
        
            Console.WriteLine("Enter the latitude position of the station");
            double latitude = double.Parse(Console.ReadLine());
           
            Console.WriteLine("Enter the longitude position of the station");
            double longitude = double.Parse(Console.ReadLine());
         
            Console.WriteLine("Enter the name of the station");
            string statioName= Console.ReadLine();
            

        }

    }

   
}