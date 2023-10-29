﻿namespace TravelPal.Models.PackingListItems
{
    class OtherItem : IPackingListItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public OtherItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public string GetInfo()
        {
            return $"{Name} - Quantity: {Quantity}";
        }
    }
}
