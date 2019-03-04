using CRRUD__Weekend_Bike_Routes2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRRUD__Weekend_Bike_Routes2.DAL
{
    // Repository - abstract away how to get a CRUD of object
    // CREATE
    // READALL
    // READBY
    // UPDATE
    // DELETE

    class TripRepository
    {
        private static List<BikeTrip> bikeTrips;

        public TripRepository()
        {
            if (bikeTrips == null)
            {
                bikeTrips = new List<BikeTrip>();
                for (int i = 0; i < 10; i++)
                {
                    BikeTrip biketrip = new BikeTrip
                    {                        
                        Id = i + 1,
                        CloseCity="St. Paul",
                        Difficulty="Medium",
                        CreateDate = DateTime.Now.AddMonths(-1 * i)
                    };
                    //biketrip.Add(biketrip);
                }
            }
        }

        private int nextId()
        {
            int id = 0;
            foreach (BikeTrip bikeTrip in bikeTrips)
            {
                if (bikeTrip.Id > id)
                {
                    id = bikeTrip.Id;
                }
            }
            id = id + 1;
            return id;
        }

        // CREATE
        public BikeTrip Create(BikeTrip bikeTrip)
        {
            bikeTrip.Id = nextId();
            bikeTrip.CreateDate = DateTime.Now;
            bikeTrips.Add(bikeTrip);
            return bikeTrip;
        }

        // READALL
        public List<BikeTrip> ReadAll()
        {
            return bikeTrips;
        }

        // READBY
        public BikeTrip ReadById(int id)
        {

            foreach (BikeTrip bikeTrip in bikeTrips)
            {
                if (bikeTrip.Id == id)
                {
                    return bikeTrip;
                }
            }
            return null;
        }
        // UPDATE
        public void Update(int idToUpdate, BikeTrip newTripInfo)
        {
            // Loop until find the index, and modify way
            int currentID = 0;
            for (int i = 0; i < bikeTrips.Count; i++)
            {
                currentID = bikeTrips[i].Id;
                if (currentID != idToUpdate) continue;
                bikeTrips[i] = newTripInfo;
                break;
            }

            //int index = bikeTrips.FindIndex((BikeTrip c) => c.Id == id);
            //if (index >= 0)
            //{
            //    bikeTrips[index] = newTripInfo;
            //}

        }
        // DELETE
        public void Delete(int idToDelete)
        {
            //characters.RemoveAll((Character characterInfo) => characterInfo.Id == id);

            bikeTrips.RemoveAll((BikeTrip characterInfo) => characterInfo.Id == idToDelete);
        }


    }
}
