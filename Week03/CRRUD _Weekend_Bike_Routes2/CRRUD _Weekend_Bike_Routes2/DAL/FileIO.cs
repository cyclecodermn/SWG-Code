using CRRUD__Weekend_Bike_Routes2.Models;
using CRRUD__Weekend_Bike_Routes2.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRRUD__Weekend_Bike_Routes2.DAL
{
    class FileIO
    {

        public static void SaveFile(List<BikeTrip> tripList)
        {
            //C:\Users\steve\source\repos\CRRUD _Weekend_Bike_Routes2\CRRUD _Weekend_Bike_Routes2\DAL
            string path = "list.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (BikeTrip BikeTrip in tripList)
                {
                    DateTime timeNow = DateTime.Now;
                    TimeSpan age = timeNow - BikeTrip.CreateDate;

                    writer.Write(BikeTrip.Id + "\t");
                    writer.Write(BikeTrip.Name + "\t");
                    writer.Write(BikeTrip.CloseCity + "\t");

                    writer.Write(BikeTrip.NightlyCost + " \t");
                    writer.Write(BikeTrip.Distance + " \t");
                    writer.Write(BikeTrip.Difficulty + " \t");
                    writer.WriteLine(age + " \t");

                }
            }
        }




        //public static void SaveFile(List<BikeTrip> tripList)
        //{
        //    foreach (BikeTrip BikeTrip in tripList)
        //    {
        //        DateTime timeNow = DateTime.Now;
        //        TimeSpan age = timeNow - BikeTrip.CreateDate;

        //        Console.Write(BikeTrip.Id + "\t");
        //        Console.Write(BikeTrip.Name + "\t");
        //        Console.Write(BikeTrip.CloseCity + "\t");

        //        Console.Write(BikeTrip.NightlyCost + " \t");
        //        Console.Write(BikeTrip.Distance + " \t");
        //        Console.Write(BikeTrip.Difficulty + " \t");
        //        Console.WriteLine(age + " \t");

        //    }
        //}



        //// try putting the line below in the menu call
        //public static void ListAllTrips(TripRepository repo)
        //{
        //    UserIO.SaveFile(repo.ReadAll());
        //}


        //public static void DisplayTrip(BikeTrip BikeTrip)
        //{
        //    DateTime timeNow = DateTime.Now;
        //    TimeSpan age = timeNow - BikeTrip.CreateDate;
        //    Console.WriteLine("-----------------------------");
        //    Console.WriteLine("BikeTrip ID: {0}", BikeTrip.Id);
        //    Console.WriteLine("BikeTrip Name: {0}", BikeTrip.Name);
        //    Console.WriteLine("\t: Closest City: {0}", BikeTrip.CloseCity);

        //    Console.WriteLine("\tWeekend Cost ${0} - Distance {1} miles",
        //        BikeTrip.NightlyCost.ToString("###.##"), BikeTrip.Distance.ToString());
        //    Console.WriteLine("\tRoute difficulty: {0}", BikeTrip.Difficulty);
        //    Console.WriteLine("Days since the trip was created {0}", age);
        //    Console.WriteLine("-----------------------------");
        //    Continue();
        //}


    }
}
