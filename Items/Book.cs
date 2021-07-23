using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTest.ContainersForItems;

namespace InventoryTest.Items
{
    internal class Book : IItem, IReadable
    {
        private readonly string _name;
        private readonly float _weightKG;
        private readonly string _content;

        public Book(string name, float weightKG, string content)
        {
            if (name.Length < 1 || weightKG < 0 || content.Length < 1) throw new ArgumentException();
            _name = name;
            _weightKG = weightKG;
            _content = content;
        }

        public override string ToString()
        {
            return "Book: " + _name + ", weight: " + _weightKG + "\n";
        }

        void IItem.Interact(ItemsContainer containerOfItem)
        {
            {
                Console.WriteLine(
                    "1 Take or Drop \n" +
                    "2 Read \n" +
                    "3 Back");

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

                        case 2:
                            Console.WriteLine(_content);
                            Console.ReadKey();
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        string IItem.Name => _name;

        float IItem.WeightKG => _weightKG;

        string IReadable.Read() => _content;
    }
}