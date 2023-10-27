﻿using TravelPal.Enums;

namespace TravelPal.Models.Travels
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }
        public WorkTrip(string destination, Country countries, int travellers, string meetingDetails) : base(destination, countries, travellers)
        {
            MeetingDetails = meetingDetails;
        }
        public override string GetInfo()
        {
            if (MeetingDetails != null)
            {
                return $"{Countries} - Work Trip ({MeetingDetails})";
            }
            return $"{Destination} - Country: {Countries} ";

        }
    }
}
