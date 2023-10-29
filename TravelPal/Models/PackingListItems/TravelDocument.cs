namespace TravelPal.Models.PackingListItems
{
    public class TravelDocument : IPackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public TravelDocument(string name, bool required)
        {
            Name = name;
            Required = required;
        }
        public string GetInfo()
        {
            if (Required == true)
            {
                return $"{Name} - Required) ";
            }
            return $"{Name}";
        }
    }
}
