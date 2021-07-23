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
        private static Inventory _instance;
        private static readonly float _capacity = 100;

        private Inventory()
        {
        }

        public static Inventory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }

        public override float Capacity => _capacity;
    }
}