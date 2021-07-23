using InventoryTest.ContainersForItems;
using System;

namespace InventoryTest.Items
{
    internal class Amulet : IItem
    {
        private readonly string _name;

        private readonly float _weightKG;

        public Amulet(string name, float weightKG)
        {
            if (name.Length < 1 || weightKG < 0) throw new ArgumentException();
            _name = name;
            _weightKG = weightKG;
        }

        public override string ToString()
        {
            return "Amulet: " + _name + ", weight: " + _weightKG + "\n";
        }

        void IItem.Interact(ItemsContainer containerOfItem)
        {
            {
                Console.WriteLine(
                    "1 Take or Drop \n" +
                    "2 Back");

                if (int.TryParse(Console.ReadLine(), out int response))
                {
                    switch (response)
                    {
                        case 1:
                            if (containerOfItem is Inventory)
                                containerOfItem.RemoveItem(this);
                            else
                                Inventory.GetInstance().ReplaceItemToInventory(this, containerOfItem);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        string IItem.Name => _name;

        float IItem.WeightKG => _weightKG;
    }
}