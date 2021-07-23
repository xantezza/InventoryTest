using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest.Items
{
    internal interface IItem
    {
        public string Name { get; }
        public float WeightKG { get; }

        public void Interact();
    }
}