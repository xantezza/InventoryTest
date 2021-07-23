using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest.Items
{
    internal class Book : IItem, IReadable
    {
        private string _name;
        private float _weightKG;
        private string _content;

        public Book(string name, float weightKG, string content)
        {
            if (name.Length < 1 || weightKG < 0 || content.Length < 1) throw new ArgumentException();
            _name = name;
            _weightKG = weightKG;
            _content = content;
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

        string IReadable.Read() => _content;
    }
}