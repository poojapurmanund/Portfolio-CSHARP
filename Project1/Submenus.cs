using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1
{
    class Submenus
    {
        enum selection { experience = 1, education = 2, skills = 3, technology = 4, contact = 5, back = -1 };
        enum uni { year1 = 1, year2 = 2, additionalTraining = 3, back = -1 }

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
                case (int)selection.experience:
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
                    Program.MainMenu();
                    break;


            }

        }
        public static void ExperienceMenu()
        {
            Experience e = new Experience();
            e.SelectCompany();

        }


        public static void EducationMenu()
        {

            Education e = new Education();
            int choice;
            Console.WriteLine("This is the Education Section.");
            Console.WriteLine("Select the Year (1, 2) to learn about the modules and projects, or 3 for any additional training.");
            Console.WriteLine("Year 1: 6 Modules");
            Console.WriteLine("Year 2: 6 Modules");
            Console.WriteLine("Option 3: Additional Training");
            Console.WriteLine("-1: Back");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case (int)uni.year1:
                    e.DisplayYear((int)uni.year1);
                    break;
                case (int)uni.year2:
                    e.DisplayYear((int)uni.year2);
                    break;
                case (int)uni.additionalTraining:
                    e.AdditionalTraining();
                    break;
                case (int)uni.back:
                    Submenus.GuestMenu();
                    break;
                default:
                    Console.WriteLine("Error. Select again: ");
                    EducationMenu();
                    break;
            }

        }

        public static void DisplayPSkills()
        {
            Console.Clear();

            List<string> pskills = new List<string>();

            try
            {
                var lines = File.ReadAllLines("..//..//..//pskills.csv");
                foreach (var line in lines)
                {
                    pskills.Add(line);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file does not exist");

            }

            Console.WriteLine("Below are the personal skills I possess: ");

            pskills.ForEach(x => { Console.WriteLine("- " + x); });
            
            Submenus.GuestMenu();

            Console.ReadKey();
        }

        public static void DisplayTSkills()
        {
            Console.Clear();
            Dictionary<int, string> tech = new Dictionary<int, string>();

            try
            {
                var lines = File.ReadAllLines("..//..//..//tskills.csv");

                int i = 1;
                foreach (var line in lines)
                {
                    tech.Add(i++, line);
                }

                //outputting
                Console.WriteLine("--PROGRAMMING AND WEB SKILLS--");
                foreach (KeyValuePair<int, string> value in tech)
                {
                    Console.WriteLine("{0} : {1}", value.Key, value.Value);
                }


            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }

            Submenus.GuestMenu();
            Console.ReadLine();

        }




        public static void DisplayContact()
        {
            Console.Clear();

            //try to open file
            try
            {
                var lines = File.ReadAllLines("..//..//..//contact.csv");

                Console.WriteLine("Contact details:");

                foreach (var line in lines)
                {
                   
                    Console.WriteLine(line);

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }

            Submenus.GuestMenu();
            Console.ReadLine();
        }
    }
}
