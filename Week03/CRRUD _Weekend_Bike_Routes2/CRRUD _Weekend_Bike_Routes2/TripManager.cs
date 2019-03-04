using CRRUD__Weekend_Bike_Routes2.DAL;
using CRRUD__Weekend_Bike_Routes2.Models;
using CRRUD__Weekend_Bike_Routes2.UI;
using CRRUD__Weekend_Bike_Routes2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRRUD__Weekend_Bike_Routes2

{
    class TripManager
    {

        public static void Run()
        {
            TripRepository repo = new TripRepository();
            //UserIO.MakeMainMenu();
            GetMainMenuChoice();
        }

        private static void GetMainMenuChoice()
        {

            int userChoice = 0;
            do
            {
                Console.Clear();
                TripRepository repo = new TripRepository();

                UserIO.MakeMainMenu();

                do
                {
                    string menuChoice = Console.ReadLine();

                    if (!int.TryParse(menuChoice, out userChoice))

                    {
                        // If wrong input set result to zero to show the err at bottom of swtich below.
                        userChoice = 0;
                    }
                } while ((userChoice <= 1) && (userChoice >= 4));


                switch (userChoice)
                {
                    case 1:
                        BikeTrip newTrip = new BikeTrip();
                        CreateTrip(repo);
                        break;
                    case 2:
                        // Read One
                        //int tripToShow = UserIO.PromptUserForInt("What is the ID of the trip you want to see?");
                        ReadTripById(repo);
                        //UserIO.DisplayTrip();
                        break;
                    case 3:
                        ListAllTrips(repo);
                        break;
                    case 4:
                        //update
                        ///BikeTrip updatedTrip = new BikeTrip();
                        int tripToUpdate = UserIO.PromptUserForInt("What the ID of the trip you want to update?");
                        BikeTrip updatedTrip = UserIO.PromptUserForNewTrip();
                        updatedTrip.Id = tripToUpdate;
                        // bikeTrips.Add(bikeTrip);

                        //BikeTrip updatedTrip = new BikeTrip();
                        repo.Update(tripToUpdate, updatedTrip);

                        break;
                    case 5:
                        //Delete;
                        //int tripToDelete = UserIO.PromptUserForInt("What the ID of the trip you want to delete?");
                        DeleteTrip(repo);

                        //updatedTrip.Id = tripToUpdate;
                        break;

                    case 6:
                        // Save data
                        SaveTrips(repo);
                        break;
                    case 7:
                        Console.WriteLine("Press any key to end the program");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1-6.");
                        break;
                }

            } while (userChoice != 7);
        }


        private static void ListAllTrips(TripRepository repo)
        {
            UserIO.PrintTrips(repo.ReadAll());
        }

        private static void ReadTripById(TripRepository repo)
        {
            BikeTrip tripInfo = repo.ReadById(UserIO.PromptUserForInt("Enter trip Id"));
            if (tripInfo != null)
            {
                UserIO.DisplayTrip(tripInfo);
                // Update Character
                //UpdateCharacter(repo, characterInfo);
            }
        }

        private static void UpdateTrip(TripRepository repo, BikeTrip tripInfo)
        {
            string name = UserIO.PromptUser("Please Enter an updated name");
            tripInfo.Name = name;
            repo.Update(tripInfo.Id, tripInfo);
            Console.Clear();
            UserIO.DisplayTrip(repo.ReadById(tripInfo.Id));
        }

        private static void CreateTrip(TripRepository repo)
        {
            //            BikeTrip newTrip = UserIO.PromptUserForNewCharacter();
            BikeTrip newTrip = UserIO.PromptUserForNewTrip();

            newTrip = repo.Create(newTrip);

            UserIO.DisplayTrip(repo.ReadById(newTrip.Id));
        }

        private static void DeleteTrip(TripRepository repo)
        {
            int id = UserIO.PromptUserForInt("Enter Id to remove");
            repo.Delete(id);
            //BikeTrip deletedInfo = repo.ReadById(UserIO.PromptUserForInt("Enter the trip ID to delete."));
            if (id == null)
            {
                Console.WriteLine("No character found");
            }
        }
        public static void SaveTrips(TripRepository repo)
        {
            FileIO.SaveFile(repo.ReadAll());
            UserIO.Continue();
        }

    }


}
