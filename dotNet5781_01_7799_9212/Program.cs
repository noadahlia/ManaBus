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
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        DateTime dt = DateTime.ParseExact(in_date, "dd/MM/yyyy", provider);

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

                        {
                          
                            Bus bus= new Bus(license,dt);
                            busList.Add(bus);

                        break;

                    case 2:
                        if (!busList.Any())
                        {
                            Console.WriteLine("There are no buses in the list yet. Please add a new bus.");
                            goto Choices;
                        }
                        Console.WriteLine("Enter the license number:");
                        license = int.Parse(Console.ReadLine());
                        while (!busList.Exists(x => x.B_ID == license))
                        {
                            Console.WriteLine("This licence nunmber doesn't exists. Enter the license number:");
                            license = int.Parse(Console.ReadLine());
                        }
                        Random random = new Random();
                        int miles = random.Next(1200); //the random number of km of the new travel has to be < than 1200
                                                       //otherwise, the random is more often >1200 and the bus could'nt never travel
                        Bus bus1 = busList.Find(x => x.B_ID == license);

                        Console.WriteLine(miles);
                        DateTime d1 = DateTime.Now;
                        DateTime d2 = bus1.lastRefresh;
                        TimeSpan gap = d1 - d2;
                        int b_km = bus1.km_counter;
                        int b_fuel = bus1.fuel_level;
                        if (gap.TotalDays > 365)
                        {
                            Console.WriteLine("More than one year since the last checking, it cannot drive.");
                        }
                        else if ((b_km += miles) > 20000)
                        {
                            Console.WriteLine("This bus has driven more than 20000km since the last checking, it cannot drive.");
                        }
                        else if ((b_fuel -= miles) < 0)
                        {
                            Console.WriteLine("This bus has driven more than 1200 km since the last refreshing, it cannot drive.");
                        }
                        else
                        {
                            bus1.km_counter += miles;
                            bus1.fuel_level -= miles;
                            Console.WriteLine("Travel saved");
                        }


                        break;
                    case 3:
                        Console.WriteLine("Enter the license number: ");
                        license= int.Parse(Console.ReadLine());
                       
                        bool isExist = busList.Exists(x => x.B_ID == lincense);
                        if (isExist)
                            Bus b1 =;
                        Console.WriteLine("Enter 0 to refuel and 1 to refresh");
                       
                        int choice = int.Parse(Console.ReadLine());
                        if (choice == 0)
                        {
                            bus1.fuel_level = 1200;
                        }
                        if (choice == 1)
                        {
                            bus1.km_counter = 0;
                            bus1.year = DateTime.Now;

                        }
                        // case 3: plein ou maintenance : cin b_id et cin plein ou maintenance
                        //si plein, alors maj un flag a true , flag qui montre s'il y a plein
                        //      si maintenance, enregistrer la date actuelle avec datetime() et enregistrer le trajet dans lequel a ete fait ce tipoul
                        Console.WriteLine("1"); ;
                        break;
                    case 4:      // case 4: afficher pour tous les bus leur trajet depuis le dernier tipoul
                                 //pour chaque bus, il faut afficher le b_id et le trajet
                        if (!busList.Any())
                        {
                            Console.WriteLine("There are no buses in the list yet. Please add a new bus.");
                            goto Choices;
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




            //Main menu en boucle


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
            public int km_counter = 0;
            public int fuel_level = 1200;
            public DateTime lastRefresh;

            public Bus(int id, DateTime date)
            {
                b_id = id;
                lastRefresh = date;
            }
            public Bus(int id) { b_id = id; }


        }

    }

}
