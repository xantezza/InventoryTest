using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTest.Items;

namespace InventoryTest.ContainersForItems
{
    internal abstract class ItemsContainer
    {
        protected List<IItem> _items = new List<IItem>();

        public abstract float Capacity { get; }

        public void AddItem(IItem item)
        {
            if (item.WeightKG > GetRemainingCapacity())
            {
                Console.WriteLine("The item is too heavy");
                return;
            }
            _items.Add(item);
        }

        public void InteractWith(int index)
        {
            _items[index].Interact(this);
        }

        public void ReplaceItemToInventory(IItem item, ItemsContainer wherefrom)
        {
            if (item.WeightKG > GetRemainingCapacity())
            {
                Console.WriteLine("The item is too heavy");
                Console.ReadKey();
                return;
            }
            if (item is ICurrency)
            {
                var items = Inventory.GetInstance().GetItems();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] is ICurrency && items[i].Name == item.Name)
                    {
                        var currencyInInventory = items[i] as ICurrency;
                        var currencyInItem = item as ICurrency;
                        currencyInInventory.Amount += currencyInItem.Amount;
                    }
                }
            }
            else
            {
                _items.Add(item);
            }
            wherefrom.RemoveItem(item);
        }

        public void RemoveItem(IItem item)
        {
            _items.Remove(item);
        }

        public IItem[] GetItems()
        {
            return _items.ToArray();
        }

        public float GetRemainingCapacity()
        {
            float summaryWeight = 0;
            foreach (var item in _items)
            {
                summaryWeight += item.WeightKG;
            }
            return Capacity - summaryWeight;
        }

        public string GetItemNames() => string.Join("", _items);
    }
}