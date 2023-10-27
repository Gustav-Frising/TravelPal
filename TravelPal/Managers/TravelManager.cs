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
            Travels.Add(travel);
        }


        //public void RemoveTravel(Travel travel)
        //{
        //}



    }
}
