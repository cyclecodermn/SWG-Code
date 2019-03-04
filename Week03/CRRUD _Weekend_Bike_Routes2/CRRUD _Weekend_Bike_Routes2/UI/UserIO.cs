using CRRUD__Weekend_Bike_Routes2.Models;
using CRRUD__Weekend_Bike_Routes2.DAL;
using CRRUD__Weekend_Bike_Routes2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRRUD__Weekend_Bike_Routes2.UI
{
    public class UserIO
    {
        public static int PromptUserForInt(string message)
        {
            int result;
            int.TryParse(PromptUser(message), out result);
            return result;
        }


        public static void MakeMainMenu()
        {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\t1. Create a bike trip");
                Console.WriteLine("\t2. Read one bike trip");
                Console.WriteLine("\t3. Read all bike trips");
                Console.WriteLine("\t4. Update a bike trip");
                Console.WriteLine("\t5. Delete a bike trip");
                Console.WriteLine("\t6. Save bike trip data");
                Console.WriteLine("\t7. Exit");

        }

        public static BikeTrip PromptUserForNewTrip()
        {
            string name = PromptUser("What is the name of the weekend bike trip?");
            string closeCity = PromptUser("Which large city is closest to the campsite for this trip ? ");
            string campName = PromptUser("What is the name of the camping site or campground for this trip?");
            int nightlyCost = int.Parse(PromptUser("What is the weekend cost of the campsite in dollars (no cents)?"));
            int distance = int.Parse(PromptUser("What's the distance in miles from the large city to the compsite?"));
            string difficulty = PromptUser("Considering hills and traffice, how difficult is this route (hard, medium, easy)?");

            BikeTrip result = new BikeTrip();

            result.Name = name;
            result.CloseCity = closeCity;
            result.CampName = campName;
            result.NightlyCost = nightlyCost;
            result.Distance = distance;
            result.Difficulty = difficulty;

            return result;
        }

        public static string PromptUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void Continue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        public static void PrintTrips(List<BikeTrip> tripList)
        {
            foreach (BikeTrip BikeTrip in tripList)
            {
                DisplayTrip(BikeTrip);
            }
        }

        public static void DisplayTrip(BikeTrip BikeTrip)
        {
            DateTime timeNow = DateTime.Now;
            TimeSpan age = timeNow - BikeTrip.CreateDate;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("BikeTrip ID: {0}", BikeTrip.Id);
            Console.WriteLine("BikeTrip Name: {0}", BikeTrip.Name);
            Console.WriteLine("\t: Closest City: {0}", BikeTrip.CloseCity);

            Console.WriteLine("\tWeekend Cost ${0} - Distance {1} miles",
                BikeTrip.NightlyCost.ToString("###.##"), BikeTrip.Distance.ToString());
            Console.WriteLine("\tRoute difficulty: {0}", BikeTrip.Difficulty);
            Console.WriteLine("Days since the trip was created {0}", age);
            Console.WriteLine("-----------------------------");
            Continue();
        }

        public static void ReadTrips(BikeTrip BikeTrip)
        {
            TimeSpan age = DateTime.Now - BikeTrip.CreateDate;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("BikeTrip ID: {0}", BikeTrip.Id);
            Console.WriteLine("BikeTrip Name: {0}", BikeTrip.Name);
            Console.WriteLine("\t: Closest City: {0}", BikeTrip.CloseCity);

            Console.WriteLine("\tWeekend Cost ${0} - Distance {1} miles",
                BikeTrip.NightlyCost.ToString("###.##"), BikeTrip.Distance.ToString());
            Console.WriteLine("\tRoute difficulty: {0}", BikeTrip.Difficulty);
            Console.WriteLine("Days since the trip was created {0}", age);
            Console.WriteLine("-----------------------------");

            Continue();
        }
           
    }
}
