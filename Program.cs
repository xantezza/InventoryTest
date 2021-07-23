using System;
using System.Runtime;
using InventoryTest.Items;
using InventoryTest.ContainersForItems;

namespace InventoryTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                ItemsContainer _table = new Table(50f);

                ItemsContainer _inventory = new Inventory(100f);

                _table.AddItem(new Amulet("Deathfire Dragon Amulet", 0.3f));
                _table.AddItem(new Coins("Floren", 0, 33));
                _table.AddItem(new Book(
                    "Lorem ipsum",
                    0.5f,
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));

                Console.WriteLine(
                    $"You enter the room and see the following items on the table: \n\n"
                    + _table.GetItemNames() + "\n"
                    + "What item do you want to interact with? (number from 1 to last)");

                if (int.TryParse(Console.ReadLine(), out int response))
                {
                    if (response > 0 && response < _table.GetItems().Length)
                    {
                        _table.InteractWith(response + 1);
                    }
                    else
                    {
                        Console.WriteLine("Wrong number");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}