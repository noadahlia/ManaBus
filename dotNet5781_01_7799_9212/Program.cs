using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_7799_9212
{
    class Program
    {
        static void Main(string[] args)
        {
        Choices:
            int caseSwitch;
            Console.WriteLine("Press 1 to adding a bus to the list of buses in the company");
            Console.WriteLine("Press 2 to choose a bus for travel");
            Console.WriteLine("Press 3 to performe refueling or handling of a bus");
            Console.WriteLine("Press 4 to presente the traject since the last treatment for all vehicles in the company");
            Console.WriteLine("Press 5 to exit");
            caseSwitch = int.Parse(Console.ReadLine());

            List<Bus> busList = new List<Bus>();

            while (caseSwitch != 5)
            {
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Enter the date of commencement of activity (dd/MM/yyyy) :");
                        string in_date = Console.ReadLine();
                        CultureInfo provider = CultureInfo.InvariantCulture; //one of the parameter in  the function ParseExact
                        DateTime dt = DateTime.ParseExact(in_date, "dd/MM/yyyy", provider); //the string input date becomes a DateTime date

                        Console.WriteLine("Enter the license number:"); 
                        int license = int.Parse(Console.ReadLine());
                        bool flag = true;

                        while (flag)
                        {
                            if (license.ToString().Length != 8 && dt.Year >= 2018)
                            {
                                Console.WriteLine("You've entered a wrong license number, please enter a 8 digits license number");
                                license = int.Parse(Console.ReadLine());
                            }

                            else
                            {
                                if (license.ToString().Length != 7 && dt.Year < 2018)
                                {
                                    Console.WriteLine("You've entered a wrong license number, please enter a 7 digits license number");
                                    license = int.Parse(Console.ReadLine());
                                }
                            }
                            flag = false;
                        }

                        Bus bus = new Bus(license, dt);
                        busList.Add(bus);

                        break;

                    case 2:
                        if (!busList.Any()) //if the list is empty
                        {
                            Console.WriteLine("There are no buses in the list yet. Please add a new bus.");
                            goto Choices; //don't let the user travel and go to the main menu to enter a new bus in the list
                        }
                        Console.WriteLine("Enter the license number:");
                        license = int.Parse(Console.ReadLine());
                        while (!busList.Exists(x => x.B_ID == license)) //the function exists verifies if the input license exists in the list
                        {
                            Console.WriteLine("This licence nunmber doesn't exists. Enter the license number:"); //error msg
                            license = int.Parse(Console.ReadLine());
                        }
                        Random random = new Random(); 
                        int miles = random.Next(1200); //the random number of km of the new travel has to be < than 1200
                                                       //otherwise, the random is more often >1200 and the bus could'nt never travel
                        Bus bus1 = busList.Find(x => x.B_ID == license); //find in the list the bus identified by the input license

                        Console.WriteLine("The travel is {0} km", miles);
                        DateTime d1 = DateTime.Now;
                        DateTime d2 = bus1.lastRefresh;
                        TimeSpan gap = d1 - d2; //difference between the date of refreshing and today's date
                        int km = bus1.KM_C; //saves the number of km of the bus at this moment to compare it in the conditions (if)
                        int fuel = bus1.FUEL; // same thing with the fuel

                        if (gap.TotalDays > 365) 
                        {
                            Console.WriteLine("More than one year since the last checking, it cannot drive.");
                        }
                        else if ((km += miles) > 20000)
                        {                        
                            Console.WriteLine("This bus has driven more than 20000km since the last checking, it cannot drive.");
                        }
                        else if ((fuel -= miles) < 0)
                        {
                            Console.WriteLine("This bus has driven more than 1200 km since the last refueling, it cannot drive.");
                        }
                        else
                        {

                            bus1.KM_C += miles; //adds the new travel to the datas
                            bus1.FUEL -= miles;

                            Console.WriteLine("Travel saved");
                        }


                        break;
                    case 3:
                        if (!busList.Any())
                        {
                            Console.WriteLine("There are no buses in the list yet. Please add a new bus.");
                            goto Choices;
                        }
                        Console.WriteLine("Enter the license number: ");
                        license = int.Parse(Console.ReadLine());
                        while (!busList.Exists(x => x.B_ID == license))
                        {
                            Console.WriteLine("This licence nunmber doesn't exists. Enter the license number:");
                            license = int.Parse(Console.ReadLine());
                        }
                        Bus bus2 = busList.Find(x => x.B_ID == license);
                        Console.WriteLine("Enter 0 to refuel and 1 to refresh");

                        int choice = int.Parse(Console.ReadLine()); 
                        if (choice == 0)
                        {
                            bus2.FUEL = 1200;
                        }
                        if (choice == 1)
                        {
                            bus2.KM_C = 0;
                            bus2.lastRefresh = DateTime.Now;

                        }

                        break;
                    case 4:
                        if (!busList.Any())
                        {
                            Console.WriteLine("There are no buses in the list yet. Please add a new bus.");
                            goto Choices;
                        }
                        foreach (Bus element in busList)
                        {
                            if ((element.B_ID).ToString().Length == 8)
                            {
                                int tmp = (element.B_ID) / 100000;
                                int tmp1 = ((element.B_ID) / 1000) % 100;
                                int tmp2 = (element.B_ID) % 1000;
                                Console.WriteLine("{0}" + "-" + "{1}" + "-" + "{2}" + ": " + "{1}" + "km", tmp, tmp1, tmp2, element.KM_C);
                            }
                            if ((element.B_ID).ToString().Length == 7)
                            {
                                int tmp = (element.B_ID) / 100000;
                                int tmp1 = ((element.B_ID) / 100) % 1000;
                                int tmp2 = (element.B_ID) % 100;
                                Console.WriteLine("{0}" + "-" + "{1}" + "-" + "{2}" + ": " + "{1}" + "km", tmp, tmp1, tmp2, element.KM_C);
                            }
                        }
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
        /*********************************Class Bus*************************************/
        public class Bus
        {
            private int b_id;
            public int B_ID
            {
                get { return b_id; }
                set { b_id = value; }
            }
            private int km_counter;
            public int KM_C
            {
                get { return km_counter; }
                set { km_counter = value; }
            }

            private int fuel_level;
            public int FUEL  
            {
                get { return fuel_level; }
                set { fuel_level = value; }
            }

            public DateTime lastRefresh;
            public Bus(int id) { b_id = id; }
            public Bus(int id, DateTime date)
            {
                b_id = id;
                lastRefresh = date;
                km_counter = 0;
                fuel_level = 1200;
            }
           
        }

    }

}
