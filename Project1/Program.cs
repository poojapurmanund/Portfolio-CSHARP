using System;
using System.IO;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {

        enum selection { experience = 1, education = 2, skills = 3, technology = 4, contact = 5, back = -1 };
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
            GuestMenu();
        }

        //function for the guest menu
        public static void GuestMenu()
        {
            int choice = -1;

            Console.WriteLine("*************");
            Console.WriteLine("Choose an option below:");
            Console.WriteLine("1. Experience/Job History");
            Console.WriteLine("2. Education/Training");
            Console.WriteLine("3. Skills");
            Console.WriteLine("4. Technology Skills");
            Console.WriteLine("5. Contact Details");
            Console.WriteLine("-1. Back");
            Console.WriteLine("*************");

            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case (int)selection.experience :
                    Submenus.ExperienceMenu();
                    break;

                case (int)selection.education:
                    Submenus.EducationMenu();
                    break;

                case (int)selection.skills:
                    Submenus.DisplayPSkills();
                    break;

                case (int)selection.technology:
                    Submenus.DisplayTSkills();
                    break;

                case (int)selection.contact:
                    Submenus.DisplayContact();
                    break;

                case (int)selection.back:
                    MainMenu();
                    break;


            }

        }



    }
}