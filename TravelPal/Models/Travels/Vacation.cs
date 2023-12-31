﻿using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models.PackingListItems;

namespace TravelPal.Models.Travels
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation()
        {

        }
        public Vacation(string destination, Country countries, int travellers, List<IPackingListItem> packinglist, bool allInclusive) : base(destination, countries, travellers, packinglist)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            if (AllInclusive == true)
            {
                return $"{Countries} - Vacation (All Inclusive) ";
            }
            return $"{Countries} - Vacation:";
        }


    }
}
