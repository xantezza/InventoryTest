using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest.Items
{
    internal class Amulet : IItem
    {
        private string _name;

        private float _weightKG;

        public Amulet(string name, float weightKG)
        {
            if (name.Length < 1 || weightKG < 0) throw new ArgumentException();
            _name = name;
            _weightKG = weightKG;
        }

        public override string ToString()
        {
            return _name + " " + _weightKG + "\n";
        }

        void IItem.Interact()
        {
        }

        string IItem.Name => _name;

        float IItem.WeightKG => _weightKG;
    }
}