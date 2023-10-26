using System.Collections.Generic;
using TravelPal.Models.Travels;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        public static List<Travel>? Travels { get; set; } = new()
        {
           new Vacation ("stockholm", Enums.Country.Sweden, 5, true),
           new WorkTrip("stockholm", Enums.Country.Sweden, 5, "meeting att clarion hotel 5pm")
        };



        public static void AddTravel(Travel travel)
        {
            Travel newTravel = new(travel.Destination, travel.Countries, travel.Travellers);
            Travels.Add(newTravel);

        }


        //public void RemoveTravel(Travel travel)
        //{
        //}



    }
}
