using TravelPal.Models.Travels;
using TravelPal.Models.Users;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        //public static List<Travel>? Travels { get; set; } = new()
        //{
        //   new Vacation ("stockholm", Enums.Country.Sweden, 5, true),
        //   new WorkTrip("stockholm", Enums.Country.Sweden, 5, "meeting att clarion hotel 5pm")
        //};



        public static void AddTravel(Travel travel)
        {
            User user = (User)UserManager.SignedInUser;
            user.Travels.Add(travel);

        }


        //public void RemoveTravel(Travel travel)
        //{
        //}



    }
}
