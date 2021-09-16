using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class AdminMenu
    {
        enum menu { update=1,overwrite=2,delete=3,back=-1 };
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO THE ADMIN MENU");
            Console.WriteLine("How do you wish to proceed?");
            Console.WriteLine("     1.Update records");
            Console.WriteLine("2.Overwrite existing records");
            Console.WriteLine("     3.Delete records");
            Console.WriteLine("     -1. Back");
            var choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case (int)menu.update:
                    break;
                case (int)menu.overwrite:
                    break;
                case (int)menu.delete:
                    break;
                case (int)menu.back:
                    Program.MainMenu();
                    break;
            }
        }
    }
}
