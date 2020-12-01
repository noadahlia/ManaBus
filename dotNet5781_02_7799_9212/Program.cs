using System;
using System.Collections.Generic;

namespace dotNet5781_02_7799_9212
{
    class Program
    {

        static void Main(string[] args)
        {
            Random r = new Random();
            List<BusLineStation> allStations = new List<BusLineStation>(); //Contains all the stations in the program
            LinesList allLines = new LinesList();

            int i = 0;

            /* Create 40 stations */
            for (i = 0; i < 40; i++)
            {
                BusLineStation newSt = new BusLineStation(r.Next(300), r.Next(5), r.Next(100000, 999999), r.Next(31, 33) + r.NextDouble(), r.Next(34, 36) + r.NextDouble(), "station" + i);
                allStations.Add(newSt);
            }

            /* Create 10 lists of stations to 10 new lines */
            for (i = 0; i < 15; i++) // the loop will execute 10 times the code to create our 10 lines
            {
                List<BusLineStation> lst = new List<BusLineStation>(); // an object from BusLine class has to have a List of stations, so we create it
                for (int j = 0; j < 9; j++)
                { //every line has to stop at 1à stations
                    lst.Add(allStations[r.Next(0, 39)]); //so the loop with j add to the list 10 stations from the list AllStations
                }

                BusLine newLine = new BusLine(r.Next(1, 1000), lst, r.Next(1, 6)); // then we can create 10 different lines and every time that the loop for 
                                                                                   // increases i by 1, a new line is created and added to our LineList collection

                allLines.AddLine(newLine);

            }

            Console.WriteLine(allLines.ToString());


            int caseSwitch;
            Console.WriteLine("Press 1 to ADD");
            Console.WriteLine("Press 2 to DELETE");
            Console.WriteLine("Press 3 to SEARCH ");
            Console.WriteLine("Press 4 to PRINT");
            Console.WriteLine("Press 5 to exit");
            caseSwitch = int.Parse(Console.ReadLine());


            while (caseSwitch != 5)
            {
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Press 1 to add a new line or 2 to add a new station bus line");
                        int choice = int.Parse(Console.ReadLine());
                        while (choice != 1 && choice != 2)
                        {
                            Console.WriteLine("ERROR. Please try again. "); //EXCEPTION?
                            goto case 1;
                        }
                        if (choice == 1) //add a new bus line
                        {
                          LineNum:  Console.WriteLine("Enter the bus line number");
                            int id = int.Parse(Console.ReadLine());
                            try
                            {
                                if (id.ToString().Length > 3 || id.ToString().Length < 1)
                                {
                                    throw new ArgumentException("Invalide number of line");
                                    
                                }
                            }
                            catch (ArgumentException mess)
                            {
                                Console.WriteLine(mess.Message);
                                goto LineNum;
                            }

                        area:
                            Console.WriteLine("Enter the area (General(1) /North(2) /South(3) /Center(4) /Jerusalem(5)) :");
                            int area = int.Parse(Console.ReadLine());
                            if (area < 0 || area > 5)
                            {
                                Console.WriteLine("This area is wrong. Please try again."); //EXCEPTION?
                                goto area;
                            }

                        departure:
                            Console.WriteLine("Departure station");
                            Console.WriteLine("Station key: ");
                            int num = int.Parse(Console.ReadLine());
                            try
                            {
                                if (num.ToString().Length != 6)
                                {
                                    throw new ArgumentException("The Bus Station Key must be a number with 6 digits");
                                }
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto departure;
                            }

                            Console.WriteLine("Station name:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Latitude: ");
                            double lat = double.Parse(Console.ReadLine());
                            try
                            {
                                if (lat < 31 || lat > 33.3)
                                {
                                    throw new ArgumentException("The Latitude must be between 31 and 33.3 degrees");
                                }
                            }
                            catch (ArgumentException ex2)
                            {
                                Console.WriteLine(ex2.Message);
                                goto departure;
                            }
                            
                            Console.WriteLine("Longitude: ");
                            double lon = double.Parse(Console.ReadLine());
                            try
                            {
                                if (lon < 34 || lon > 36)
                                {
                                    throw new ArgumentException("The Longitude must be between 34.3 and 35.5 degrees");
                                }
                            }
                            catch (ArgumentException ex3)
                            {
                                Console.WriteLine(ex3.Message);
                                goto departure;
                            }
                            BusLineStation firstStation = new BusLineStation(r.Next(300), r.Next(5), num, lat, lon, name);
                            allStations.Add(firstStation);

                        arrival:
                            Console.WriteLine("Arrival station");
                            Console.WriteLine("Station key: ");
                            int num2 = int.Parse(Console.ReadLine());
                            try
                            {
                                if (num2.ToString().Length != 6)
                                {
                                    throw new ArgumentException("The Bus Station Key must be a number with 6 digits");
                                }
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto arrival;
                            }

                            Console.WriteLine("Station name:");
                            string nameS = Console.ReadLine();

                            Console.WriteLine("Latitude: ");
                            double latitude = double.Parse(Console.ReadLine());
                            try
                            {
                                if (latitude < 31 || latitude > 33.3)
                                {
                                    throw new ArgumentException("The Latitude must be between 31 and 33.3 degrees");
                                }
                            }
                            catch (ArgumentException ex2)
                            {
                                Console.WriteLine(ex2.Message);
                                goto arrival;
                            }

                            Console.WriteLine("Longitude: ");
                            double longitude = double.Parse(Console.ReadLine());
                            try
                            {
                                if (longitude < 34 || longitude > 36)
                                {
                                    throw new ArgumentException("The Longitude must be between 34.3 and 35.5 degrees");;
                                }
                            }
                            catch (ArgumentException ex3)
                            {
                                Console.WriteLine(ex3.Message);
                                goto arrival;
                            }
                            BusLineStation lastStation = new BusLineStation(r.Next(300), r.Next(5), num, lat, lon, name);
                            
                            allStations.Add(lastStation);
                            List<BusLineStation> newLstStat = new List<BusLineStation>();
                            newLstStat.Add(firstStation);
                            newLstStat.Add(lastStation);

                            BusLine newLine = new BusLine(id, newLstStat, area);

                        }
                        else
                        if (choice == 2)
                        {
                        addStation:
                            Console.WriteLine("Enter the bus line number");
                            int tmp = int.Parse(Console.ReadLine());
                            int counter = 0;
                            foreach (BusLine line in allLines)
                            {
                                if (line.BUSLINE == tmp)
                                    counter++;
                            }

                            if (counter == 2)
                            {
                                Console.WriteLine("This line already exists. Please try again. ");
                                goto addStation;
                            }

                            else
                            {
                            newLine:
                                Console.WriteLine("Station key: ");
                                int num = int.Parse(Console.ReadLine());
                                try
                                {
                                    if (num.ToString().Length != 6)
                                    {
                                        throw new ArgumentException("The Bus Station Key must be a number with 6 digits");
                                    }
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto newLine;
                                }

                                Console.WriteLine("Station name:");
                                string name = Console.ReadLine();

                                Console.WriteLine("Latitude: ");
                                double lat = double.Parse(Console.ReadLine());
                                try
                                {
                                    if (lat < 31 || lat > 33.3)
                                    {
                                        throw new ArgumentException("The Latitude must be between 31 and 33.3 degrees");
                                    }
                                }
                                catch (ArgumentException ex2)
                                {
                                    Console.WriteLine(ex2.Message);
                                    goto newLine;
                                }

                                Console.WriteLine("Longitude: ");
                                double lon = double.Parse(Console.ReadLine());
                                try
                                {
                                    if (lon < 34 || lon > 36)
                                    {
                                        throw new ArgumentException("The Longitude must be between 34.3 and 35.5 degrees");
                                    }
                                }
                                catch (ArgumentException ex3)
                                {
                                    Console.WriteLine(ex3.Message);
                                    goto newLine;
                                }


                                BusLineStation newStat = new BusLineStation(r.Next(300), r.Next(5), num, lat, lon, name);
                                allStations.Add(newStat);

                                Console.WriteLine("What kind station it will be in the line? (first/last/middle) ?");
                                string kind = Console.ReadLine();
                                switch (kind)
                                {
                                    case "first":
                                        allLines[tmp].AddFirstStation(newStat);
                                        Console.WriteLine("New first station added");
                                        break;
                                    case "last":
                                        allLines[tmp].AddLastStation(newStat);
                                        Console.WriteLine("New last station added");
                                        break;
                                    case "middle":
                                        Console.WriteLine("Enter the key of the station after which you want to add your new station");
                                        num = int.Parse(Console.ReadLine());
                                        allLines[tmp].AddMiddleStation(newStat, allLines[tmp].Find(num));
                                        Console.WriteLine("New middle station added");
                                        break;

                                    default:
                                        Console.WriteLine("ERROR. Try again");
                                        goto addStation;

                                }
                            }



                        }
                        break;

                    case 2:
                        Console.WriteLine("Press 1 to remove a new line or 2 to remove a station bus line");
                        choice = int.Parse(Console.ReadLine());


                        while (choice != 1 && choice != 2)
                        {
                            Console.WriteLine("ERROR. Please try again. ");

                        }


                        if (choice == 1)
                        {
                          Line: Console.WriteLine("Enter the bus line number");
                            int tmp = int.Parse(Console.ReadLine());
                            try
                            {
                                if (tmp.ToString().Length > 3 || tmp.ToString().Length < 1)
                                {
                                    throw new ArgumentException("Invalide number of line");
                                }
                              
                            }
                            catch (ArgumentException exx)
                            {
                                Console.WriteLine(exx.Message);
                                goto Line;
                            }
                            
                            int counter = 0;
                            foreach (BusLine line in allLines)
                            {
                                if (line.BUSLINE == tmp)
                                    counter++;
                            }

                            if (counter == 0)
                            {
                                Console.WriteLine("This bus line doesn't exist. Please try again.");
                            }

                            else
                            {
                                for (i = 0; i < counter; i++) //if there's just one line with the key tmp, the loop execute the code just one time.
                                {
                                    allLines.DeleteLine(allLines[tmp]);
                                    Console.WriteLine("Line removed");
                                }
                            }


                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("Enter the station key: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.WriteLine("From which line? ");
                            int num2 = int.Parse(Console.ReadLine());
                            BusLine in_line = allLines[num2];
                            in_line.DeleteStation(in_line.Find(num));

                            Console.WriteLine("Station removed from the lines.");
                        }


                        break;


                    case 3:
                        Console.WriteLine("Press 1 to find the lines of the station. Press 2 to find a direct ride between two stations");
                        int yourChoice = int.Parse(Console.ReadLine());
                        if (yourChoice == 1)
                        {
                            bool f = false;
                        enterKey:
                            Console.WriteLine("Enter the station key");
                            int num = int.Parse(Console.ReadLine());
                            foreach (BusLineStation item in allStations)
                            {
                                if (item.BSK == num)
                                {
                                    Console.WriteLine("Those lines stop in this station: ");
                                    f = true;  // true if the station exists in allStations
                                    foreach (BusLine it in allLines)
                                    {
                                        if (it.IsStatExists(item.BSK))
                                            Console.WriteLine(it.BUSLINE);

                                    }
                                    Console.WriteLine("\n");
                                }

                            }
                            if (!f)
                            {
                                Console.WriteLine("This station key doesn't exist. please try again.");
                                goto enterKey;
                            }

                        }
                        if (yourChoice == 2)
                        {
                            Console.WriteLine("Enter the departure station");
                            int departureStation = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the arrival station");
                            int arrivalStation = int.Parse(Console.ReadLine());
                            bool f = false;

                            List<BusLine> list = new List<BusLine>();

                            foreach (BusLine it in allLines)
                            {

                                if (it.IsStatExists(departureStation) && it.IsStatExists(arrivalStation))
                                {
                                    f = true;
                                    list.Add(it); //save this bus which contains the two stations

                                }

                            }

                            if (!f)
                            {
                                Console.WriteLine("No direct travel");
                                goto case 3;
                            }
                            else
                            {
                                Console.WriteLine("Direct travels sorted by travel time: ");
                                list.Sort();
                                foreach(BusLine item in list)
                                {
                                    Console.WriteLine(item.BUSLINE);
                                }
                                Console.WriteLine("\n");
                            }


                        }



                        break;
                    case 4:
                        Console.WriteLine("Press 1 to print all lines or 2 to print all stations and the lines which stop there: ");
                        choice = int.Parse(Console.ReadLine());
                        try
                        {
                            while (choice != 1 && choice != 2)
                            {
                                Console.WriteLine("ERROR. Please try again. ");
                                goto case 4;
                            }
                        }
                        catch (ArgumentException ex0)
                        {
                            Console.WriteLine(ex0.Message);
                        }
                        if (choice == 1)
                        {
                            Console.WriteLine(allLines.ToString());
                        }
                        else
                        {
                            foreach (BusLineStation item in allStations)
                            {
                                Console.WriteLine(item.ToString());
                                Console.WriteLine("Those lines stop in this station: \n");
                                foreach (BusLine element in allLines)
                                {
                                    if (allLines[element.BUSLINE].SearchByKey(item.BSK))
                                        Console.WriteLine("line " + element.BUSLINE + "\n");
                                }
                                Console.WriteLine("\n");
                            }
                        }


                        break;
                    default:
                        Console.WriteLine("Error, please enter a correct number");
                        break;
                }
                Console.WriteLine("Press 1 to ADD");
                Console.WriteLine("Press 2 to DELETE");
                Console.WriteLine("Press 3 to SEARCH ");
                Console.WriteLine("Press 4 to PRINT");
                Console.WriteLine("Press 5 to exit");
                caseSwitch = int.Parse(Console.ReadLine());

            }


        }

    }


}