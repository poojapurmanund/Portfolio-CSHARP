using System;
using System.IO;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        enum company { ceridian = 1, tenEleven = 2, back = -1 };
        
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();
            char choice;

            //main menu for guest or admin choice
            Console.WriteLine("--------------------------");
            Console.WriteLine("         WELCOME          ");
            Console.WriteLine("--------------------------");
            Console.WriteLine(" ARE YOU A GUEST OR ADMIN? ");
            Console.WriteLine("'G' FOR GUEST; 'A' FOR ADMIN");
            choice = char.Parse(Console.ReadLine().ToUpper());

            switch (choice)
            {
                case 'G':
                    OpenGuest();
                    break;
                case 'A':
                    OpenAdmin();
                    break;
                default:
                    Console.WriteLine("Error. Please enter G(Guest) or A(Admin)");
                    MainMenu();
                    break;
            }
        }

        //function for the guest mode
        public static void OpenGuest()
        {
            Console.Clear();
            Console.WriteLine("You have selected the guest mode.");
            DisplayIntro();
            Console.ReadLine();

        }

        //function for the admin mode

        public static void OpenAdmin()
        {
            AdminMenu a = new AdminMenu();
            a.Menu();
        }
         
        

        //function to display an intro in the guest mode - only once
        public static void DisplayIntro()
        {
            var lines = File.ReadAllLines("..//..//..//intro.csv");

            foreach (var line in lines)
            {
                var values = line.Split(',');
                Console.WriteLine($"Hello. My name is {values[0]} {values[1]}, I am a Software Engineering Student at the {values[2]}");

            }
            Submenus.GuestMenu();
        }

        //function for the guest menu
        



    }
}