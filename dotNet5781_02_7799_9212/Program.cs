using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7799_9212
{
    class Program
    {
        enum zone  { General , North, South, Center, Jerusalem };

        static void Main(string[] args)
        {
            int caseSwitch;
            Console.WriteLine("Press 1 to ADD");
            Console.WriteLine("Press 2 to DELETE");
            Console.WriteLine("Press 3 to SEARCH ");
            Console.WriteLine("Press 4 PRINT");
            Console.WriteLine("Press 5 to exit");
            caseSwitch = int.Parse(Console.ReadLine());
          

            while (caseSwitch != 5)
            {
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Press 1 to add a new line or 2 to add a new station bus line");
                        int choice = int.Parse(Console.ReadLine());
                        while(choice != 1 || choice != 2)
                        {
                            Console.WriteLine("ERROR. Please try again. ");
                            goto case 1;
                        }
                        if (choice == 1) //add a new bus line
                        {
                            Console.WriteLine("Enter the bus line number");
                            int bnum = int.Parse(Console.ReadLine());
                            //Console.WriteLine("Enter the first station of the bus:");
                            //string bfirst = Console.ReadLine();
                            //Console.WriteLine("Enter the last station of the bus");
                            //string blast = Console.ReadLine();
                            Console.WriteLine("Enter the area (General/North/South/Center/Jerusalem) :");
                            string barea = Console.ReadLine();
                            //BusLine newLine = new BusLine(bnum, bfirst, blast, barea);
                        }

                        break;

                    case 2:
                        


                        break;
                    case 3:
                       

                        break;
                    case 4:
                        
                        break;
                    default:
                        Console.WriteLine("Error, please enter a correct number");
                        break;
                }
                Console.WriteLine("Press 1 to adding a bus to the list of buses in the company");
                Console.WriteLine("Press 2 to choose a bus for travel");
                Console.WriteLine("Press 3 to performe refueling or handling of a bus");
                Console.WriteLine("Press 4 to presente the traject since the last treatment for all vehicles in the company");
                Console.WriteLine("Press 5 to exit");
                caseSwitch = int.Parse(Console.ReadLine());

            }
            //BuStation station1;
            //Console.WriteLine("Enter the bus station key");
            //int key = int.Parse(Console.ReadLine());
            //while (key.ToString().Length != 6)
            //{
            //    Console.WriteLine("ERROR. Enter a number with 6 digits:");
            //    key = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Enter the latitude position of the station");
            //double latitude = double.Parse(Console.ReadLine());
            //while (latitude < 31 || latitude>33.3)
            //{
            //    Console.WriteLine("ERROR. Enter a number between 31 and 33.3:");
            //    latitude = double.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Enter the longitude position of the station");
            //double longitude = double.Parse(Console.ReadLine());
            //while (longitude < 34.3 || longitude < 35.5) 
            //{
            //    Console.WriteLine("ERROR. Enter a number between 34.3 and 35.5:");
            //    longitude = double.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Enter the name of the station");
            //string statioName= Console.ReadLine();

            //station1 = new BusLineStation(key, latitude, longitude, statioName, );
            //BusLineStation x;
            //int y = 10, c = 9;
            //x = new BusLineStation(key, y);
        }

    }

   
}