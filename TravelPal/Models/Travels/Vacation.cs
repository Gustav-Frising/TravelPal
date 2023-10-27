using TravelPal.Enums;

namespace TravelPal.Models.Travels
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(string destination, Country countries, int travellers, bool allInclusive) : base(destination, countries, travellers)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            if (AllInclusive == true)
            {
                return $"{Countries} - Vacation (All Inclusive) ";
            }
            return $"{Destination} - Country: {Countries} ";
        }
    }
}
