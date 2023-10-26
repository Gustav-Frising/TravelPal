using System.Collections.Generic;
using TravelPal.Models.Travels;

namespace TravelPal.Managers
{
    internal class TravelManager
    {
        public List<Travel> Travels { get; set; }



        public void AddTravel(Travel travel)
        {
            Travel newTravel = new(travel.Destination, travel.Countries, travel.Travellers);
            Travels.Add(newTravel);

        }


        //public void RemoveTravel(Travel travel)
        //{
        //}



    }
}
