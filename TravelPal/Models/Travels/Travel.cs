using System;
using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models.PackingListItems;

namespace TravelPal.Models.Travels
{
    public class Travel
    {
        public string Destination { get; set; }
        public Country Countries { get; set; }
        public int Travellers { get; set; }
        public List<IPackingListItem> Packinglist { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint TravelDays { get; set; }

        public Travel(string destination, Country country, int travellers)
        {
            Destination = destination;
            Countries = country;
            Travellers = travellers;
        }
        public virtual string GetInfo()
        {
            return $"{Destination} - Country: {Countries} - Travellers: {Travellers}"; ;
        }
        private int CalculateTravelDays()
        {
            return 0;
        }

    }

}
