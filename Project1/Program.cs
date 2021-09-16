using System;
using System.IO;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {

        enum selection { experience = 1, education = 2, skills = 3, technology = 4, contact = 5, back = -1 };
        enum company { ceridian = 1, tenEleven = 2, back = -1 };
        enum uni { year1 = 1, year2 = 2, additionalTraining = 3, back = -1 }

        //implement class and interface for experience
        //education
        //admin mode
        //rewrite some files
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
         
        

        //function to display an intro in the guest mode
        public static void DisplayIntro()
        {
            var lines = File.ReadAllLines("..//..//..//intro.csv");

            foreach (var line in lines)
            {
                var values = line.Split(',');
                Console.WriteLine("Hello. My name is " + values[0] + " " + values[1] + ", I am a Software Engineering " +
                    "Student at the " + values[2]);

            }

            GuestMenu();


        }

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
            Console.WriteLine("-1. GO BACK");
            Console.WriteLine("*************");

            choice = int.Parse(Console.ReadLine());

            if (choice == (int)selection.experience)
            {

                ExperienceMenu();
            }
            else if (choice == (int)selection.education)
            {
                EducationMenu();
            }
            else if (choice == (int)selection.skills)
            {
                DisplayPSkills();
                GuestMenu();
            }
            else if (choice == (int)selection.technology)
            {
                DisplayTSkills();
                GuestMenu();
            }
            else if (choice == (int)selection.contact)
            {
                DisplayContact();
                GuestMenu();
            }
            else if (choice == (int)selection.back)
            {
                MainMenu();
            }


        }

        public static void ExperienceMenu()
        {

            Experience e = new Experience();

            Console.WriteLine("This is the experience section.");
            int choice;
            Console.WriteLine("Below are the job experiences I have had. Select (1 or 2) to learn more about the company: ");
            Console.WriteLine("1. Ceridian");
            Console.WriteLine("2. Ten Eleven Spare Parts");
            Console.WriteLine("-1. Back");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case (int)company.ceridian:
                    e.Ceridian();
                    break;
                case (int)company.tenEleven:
                    e.TenEleven();
                    break;
                case (int)company.back:
                    GuestMenu();
                    break;
                default:
                    Console.WriteLine("Error. Please select 1 or 2 only.");
                    ExperienceMenu();
                    Console.ReadLine();
                    break;



            }
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
                    GuestMenu();
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
                var values = lines[0].Split(',');
                foreach (var v in values)
                {
                    pskills.Add(v);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file does not exist");

            }

            Console.WriteLine("Below are the personal skills I possess: ");
            foreach (var x in pskills)
            {
                Console.WriteLine("- " + x);
            }
            GuestMenu();

            Console.ReadKey();
        }

        public static void DisplayTSkills()
        {
            Dictionary<int, string> tech = new Dictionary<int, string>();

            try
            {
                var lines = File.ReadAllLines("..//..//..//tskills.csv");


                var values = lines[0].Split(',');

                tech.Add(0, values[0]);
                tech.Add(1, values[1]);
                tech.Add(2, values[2]);
                tech.Add(3, values[3]);
                tech.Add(4, values[4]);
                tech.Add(5, values[5]);
                tech.Add(6, values[6]);
                tech.Add(7, values[7]);

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
            
            GuestMenu();
            Console.ReadLine();

        }


        public static void DisplayContact()
        {
            Console.Clear();
            //dictionary to store the contact details
            Dictionary<string, string> contact = new Dictionary<string, string>();

            //try to open file
            try
            {
                var lines = File.ReadAllLines("..//..//..//contact.csv");

                foreach (var line in lines)
                {
                    var values = line.Split(',');
                    contact.Add("Phone Number:", values[0]);
                    contact.Add("Home Number:", values[1]);
                    contact.Add("Address:", values[2]);
                    contact.Add("Email Address:", values[3]);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }

            Console.WriteLine("*************");
            Console.WriteLine("Contact details:");

            foreach (KeyValuePair<string, string> value in contact)
            {
                Console.WriteLine("{0} : {1}", value.Key, value.Value);
            }

            
            GuestMenu();
            Console.ReadLine();
        }


    }
}