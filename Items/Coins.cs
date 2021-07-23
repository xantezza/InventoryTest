using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InventoryTest.ContainersForItems;

namespace InventoryTest.Items
{
    internal class Coins : IItem, ICurrency
    {
        private readonly string _name;
        private readonly float _weightKG;
        private float _amount;

        public Coins(string name, float weightKG, float amount)
        {
            if (name.Length < 1 || weightKG < 0 || amount < 0) throw new ArgumentException();
            _name = name;
            _weightKG = weightKG;
            _amount = amount;
        }

        public override string ToString()
        {
            return "Coins: " + _name + ", amount: " + _amount + "\n";
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

        float ICurrency.Amount { get => _amount; set => _amount = value; }
    }
}