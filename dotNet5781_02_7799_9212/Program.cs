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
                        while(choice != 1 && choice != 2)
                        {
                            Console.WriteLine("ERROR. Please try again. ");
                            goto case 1;
                        }
                        if (choice == 1) //add a new bus line
                        {
                            Console.WriteLine("Enter the bus line number");
                            int bnum = int.Parse(Console.ReadLine());

                        area:
                            Console.WriteLine("Enter the area (General(1)/North(2)/South(3)/Center(4)/Jerusalem(5)) :");
                            int barea = int.Parse(Console.ReadLine());
                            if (barea<0 || barea>5){
                                Console.WriteLine("This area is wrong. Please try again.");
                                goto area;
                            }

                            Console.WriteLine("Add a new departure station:");
                            Console.WriteLine("");

                            
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("Enter the bus line number");
                            int tmp = int.Parse(Console.ReadLine());

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
           
        }

    }

   
}