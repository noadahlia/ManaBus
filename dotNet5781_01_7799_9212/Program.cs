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

            while (caseSwitch != 5)
            {
                switch (caseSwitch)
                {
                    case 1:  // case 1: recuperer l id du bus + date de debut pour le rentrer dans la liste des bus
                        Console.WriteLine("Enter the start date:");
                        string in_date = Console.ReadLine();
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        DateTime dt = DateTime.ParseExact(in_date,"dd/MM/yyyy",provider);
                        Console.WriteLine(dt);
                        break;
                    case 2:  // case 2: choisir son bus. comment? en demandant le b_id 
                        //le programme donnera de facon aleatoire de kilometrage de la nessia
                        //si b_id faux, on envoie un msg d erreur
                        Console.WriteLine("1");   // si b_id est bon, alors on enregistrera ce random dans les km parcourus par ce bus

                        break;
                    case 3:  // case 3: plein ou maintenance : cin b_id et cin plein ou maintenance
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
    }

    /*********************************Class Bus*************************************/
    public class Bus
    {
        private int b_id;

    }

}
