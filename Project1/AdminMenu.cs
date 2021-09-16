using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class AdminMenu
    {
        enum files { AdditionalTraining = 1, Companies = 2, Contact = 3, PersonalSkills = 4, TechSkills = 5 };
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
                    string fileName = ChooseFile();
                    Update(fileName);
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

        public string ChooseFile()
        {
            
            Console.WriteLine("Which file do you wish to modify?");
            Console.WriteLine("1. Additional Training");
            Console.WriteLine("2. Companies");
            Console.WriteLine("3. Contact");
            Console.WriteLine("4. Personal Skills");
            Console.WriteLine("5. Technological Skills");
            var choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case (int)files.AdditionalTraining:
                    return "additionaltraining.csv";
                case (int)files.Companies:
                    return "companies.csv";
                case (int)files.Contact:
                    return "contact.csv";
                case (int)files.PersonalSkills:
                    return "pskills.csv";
                case (int)files.TechSkills:
                    return "tskills.csv";
                default:
                    return "";
            }

        }

        public void Update(string fileName)
        {
            Console.Clear();
            if (fileName == "")
            {
                Console.WriteLine("Error");
                ChooseFile();
            }
            Console.WriteLine($"Enter the data you wish to append to the following file: {fileName}");
            var data = Console.ReadLine();
            Console.WriteLine("Type 'YES' if you wish for the data to be added to the next line in the file");
            string answer = Console.ReadLine().ToUpper();

            if (answer.Equals("YES", StringComparison.InvariantCultureIgnoreCase))
            {
                File.AppendAllText($"..//..//..//{fileName}", data+Environment.NewLine);
            }
            else
            {
                File.AppendAllText($"..//..//..//{fileName}", $",{data}");
            }

            Menu();
            Console.ReadLine();

        }
    }
}
