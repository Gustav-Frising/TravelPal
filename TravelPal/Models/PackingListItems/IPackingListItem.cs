namespace TravelPal.Models.PackingListItems
{
    public interface IPackingListItem
    {
        public string Name { get; set; }

        public string GetInfo()
        {
            return "";
        }
    }

}
