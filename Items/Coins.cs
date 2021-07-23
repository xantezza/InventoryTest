using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest.Items
{
    internal class Coins : IItem, ICurrency
    {
        private string _name;
        private float _weightKG;
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
            return _name + " " + _amount + "\n";
        }

        void IItem.Interact()
        {
        }

        string IItem.Name => _name;

        float IItem.WeightKG => _weightKG;

        float ICurrency.Amount => _amount;
    }
}