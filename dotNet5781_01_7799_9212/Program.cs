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
                        Console.WriteLine("Enter the date of commencement of activity:");
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
                            {  if (license.ToString().Length != 7 && dt.Year < 2018)
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

                        }
                            break;

                    case 2:  // case 2: choisir son bus. comment? en demandant le b_id 
                             //verifier si le bus existe
                             //le programme donnera de facon aleatoire de kilometrage de la nessia
                             //si b_id faux, on envoie un msg d erreur
                             // si b_id est bon, alors on enregistrera ce random dans les km parcourus par ce bus
                        Console.WriteLine("Enter the license number:");
                        Random r = new Random();
                        


                        break;
                    case 3:
                        Console.WriteLine("Enter the license number: ");
                        license= int.Parse(Console.ReadLine());
                       
                        bool isExist = busList.Exists(x => x.B_ID == lincense);
                        if (isExist)
                            Bus b1 =;
                        Console.WriteLine("Enter 0 to refuel and 1 to refresh");
                       
                        int choice = int.Parse(Console.ReadLine());
                        if(choice==0)
                        {
                            bus1.fuel_level = 1200;
                        }
                        if(choice==1)
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
                        Console.WriteLine("1");
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
            public int km_counter;
            public int fuel_level;
            public DateTime lastRefresh;

            public Bus(int id,DateTime date) {
                b_id = id;
                lastRefresh = date;
            }
            public Bus(int id) { b_id = id; }


        }

    }

}
