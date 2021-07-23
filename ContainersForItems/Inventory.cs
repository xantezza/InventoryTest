using InventoryTest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest.ContainersForItems
{
    internal class Inventory : ItemsContainer
    {
        private float _capacity;

        public Inventory(float capacity)
        {
            _capacity = capacity;
        }

        public override float Capacity => _capacity;
    }
}