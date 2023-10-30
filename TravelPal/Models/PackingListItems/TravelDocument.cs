namespace TravelPal.Models.PackingListItems
{
    public class TravelDocument : IPackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public TravelDocument()
        {

        }
        public TravelDocument(string name, bool required)
        {
            Name = name;
            Required = required;
        }
        public string GetInfo()
        {
            if (Required == true)
            {
                return $"{Name} - Travel Document (Required) ";
            }
            return $"{Name} - Travel Document ";
        }
    }
}
