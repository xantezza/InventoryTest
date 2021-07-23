using InventoryTest.ContainersForItems;
using InventoryTest.Items;
using System;

namespace InventoryTest
{
    internal class Program
    {
        private static void Main()
        {
            ItemsContainer _table = new Table(3000f);

            _table.AddItem(new Amulet(
                "Deathfire Dragon Amulet",
                1000f));

            _table.AddItem(new Coins(
                "Florens",
                0,
                33));
            _table.AddItem(new Coins(
                "Rubles",
                0,
                51));

            _table.AddItem(new Book(
                "Lorem ipsum",
                0.5f,
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                ));

            Inventory.GetInstance().AddItem(new Coins(
                "Florens",
                0,
                38));

            while (true)
            {
                Console.Clear();
                if (_table.GetItems().Length > 0)
                {
                    Console.WriteLine(
                        $"You enter the room and see the following items on the table: \n\n"
                        + _table.GetItemNames() + "\n"
                        + $"What item do you want to interact with? (number from 1 to {_table.GetItems().Length}), 0 shows your inventory)");
                }
                else
                {
                    Console.WriteLine("You enter the room and see empty table");
                    Console.ReadKey();
                }
                if (int.TryParse(Console.ReadLine(), out int firstResponse))
                {
                    if (firstResponse > 0 && firstResponse <= _table.GetItems().Length)
                    {
                        _table.InteractWith(firstResponse - 1);
                    }
                    else if (firstResponse == 0)
                    {
                        var inventoryItems = Inventory.GetInstance().GetItemNames();
                        if (inventoryItems.Length > 0)
                        {
                            ;
                            Console.WriteLine(
                                inventoryItems
                                + $"What item do you want to interact with? (number from 1 to {Inventory.GetInstance().GetItems().Length})"
                                );
                            if (int.TryParse(Console.ReadLine(), out int secondResponse))
                            {
                                if (secondResponse > 0 && secondResponse <= Inventory.GetInstance().GetItems().Length)
                                {
                                    Inventory.GetInstance().InteractWith(secondResponse - 1);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Inventory is empty");
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Wrong number \n\n");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}