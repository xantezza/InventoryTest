using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTest.ContainersForItems;

namespace InventoryTest.Items
{
    internal interface IItem
    {
        string Name { get; }
        float WeightKG { get; }

        void Interact(ItemsContainer containerOfItem);
    }
}