using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models.PackingListItems;

namespace TravelPal.Models.Travels
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }
        public WorkTrip()
        {

        }
        public WorkTrip(string destination, Country countries, int travellers, List<IPackingListItem> packinglist, string meetingDetails) : base(destination, countries, travellers, packinglist)
        {
            MeetingDetails = meetingDetails;
        }
        public override string GetInfo()
        {
            if (MeetingDetails != null)
            {
                return $"{Countries} - Work Trip ({MeetingDetails})";
            }
            return $"{Countries} - Work Trip";

        }
    }
}
