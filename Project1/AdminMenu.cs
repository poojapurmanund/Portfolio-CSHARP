using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class AdminMenu
    {
        enum files { AdditionalTraining = 1, Companies = 2, Contact = 3, PersonalSkills = 4, TechSkills = 5 };
        enum menu { add = 1, update = 2, delete = 3, back = -1 };
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO THE ADMIN MENU");
            ChooseOperation();

        }

        public void ChooseOperation()
        {
            Console.WriteLine("How do you wish to proceed?");
            Console.WriteLine("1.   Add records");
            Console.WriteLine("2.   Update existing records");
            Console.WriteLine("3.   Delete records");
            Console.WriteLine("-1.  Back");
            var choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case (int)menu.add:
                    Add();
                    break;
                case (int)menu.update:
                    Update();
                    break;
                case (int)menu.delete:
                    Delete();
                    break;
                case (int)menu.back:
                    Program.MainMenu();
                    break;
            }
        }

        public string ChooseFile(int choice)
        {

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


        public void Add()
        {
            Console.Clear();
            Console.WriteLine("Which file do you wish to add to?");
            Console.WriteLine("1. Additional Training");
            Console.WriteLine("2. Companies/Experience");
            Console.WriteLine("3. Contact");
            Console.WriteLine("4. Personal Skills");
            Console.WriteLine("5. Technological Skills");
            var choice = int.Parse(Console.ReadLine());
            string fileName = ChooseFile(choice);


            string newLine = "";
            //add function for additional training
            if (choice == (int)files.AdditionalTraining)
            {
                Console.WriteLine("Enter the additional training details: ");
                newLine = Console.ReadLine();
            }
            else if (choice == (int)files.Companies)
            {
                Console.WriteLine("Enter the company name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the company description: ");
                string desc = Console.ReadLine();
                Console.WriteLine("Enter the starting month: ");
                string sMonth = Console.ReadLine();
                Console.WriteLine("Enter the ending month: ");
                string eMonth = Console.ReadLine();
                Console.WriteLine("Enter the year: ");
                int year = int.Parse(Console.ReadLine());
                newLine = $"{name},{desc},{sMonth},{eMonth},{year}";
            }
            else if (choice == (int)files.Contact)
            {
                Console.WriteLine("Enter the new contact details:");
                newLine = Console.ReadLine();
            }
            else if (choice == (int)files.PersonalSkills)
            {
                Console.WriteLine("Enter a new personal skill to add:");
                newLine = Console.ReadLine();
            }
            else if (choice == (int)files.TechSkills)
            {
                Console.WriteLine("Enter a new techonological skill to add:");
                newLine = Console.ReadLine();
            }


            if (fileName == "")
            {
                Console.WriteLine("Error");
                Menu();
            }

            File.AppendAllText($"..//..//..//{fileName}", $"\n{newLine}");
            
            Menu();
            Console.ReadLine();
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Which file do you wish to update?");
            Console.WriteLine("1. Additional Training");
            Console.WriteLine("2. Companies/Experience");
            Console.WriteLine("3. Contact");
            Console.WriteLine("4. Personal Skills");
            Console.WriteLine("5. Technological Skills");
            var choice = int.Parse(Console.ReadLine());
            string fileName = ChooseFile(choice);

            switch (choice)
            {
                case (int)files.AdditionalTraining:
                    Console.WriteLine("Enter the record number you wish to edit: ");
                    int record = int.Parse(Console.ReadLine());
                    var lines = File.ReadAllLines($"..//..//..//{fileName}");
                    //create new temporary file for editing purposes
                    string newFile = "test.csv";

                    Console.WriteLine("Enter new training details for that record: ");
                    var newData = Console.ReadLine();


                    for (int i = 0; i < lines.Length; i++)
                    {
                        //update necessary record
                        if (i == record - 1)
                        {
                            File.AppendAllText(newFile, $"{newData}\n");
                        }
                        else
                        //else just re-enter the old data
                        {
                            File.AppendAllText(newFile, $"{lines[i]}\n");
                        }
                    }
                    File.Delete($"..//..//..//{fileName}");
                    File.Move(newFile, $"..//..//..//{fileName}");
                    break;
            }

        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Which file do you wish to delete from?");
            Console.WriteLine("1. Additional Training");
            Console.WriteLine("2. Companies/Experience");
            Console.WriteLine("3. Contact");
            Console.WriteLine("4. Personal Skills");
            Console.WriteLine("5. Technological Skills");
            var choice = int.Parse(Console.ReadLine());
            string fileName = ChooseFile(choice);

            switch (choice)
            {
                case (int)files.AdditionalTraining:
                    Console.WriteLine("Enter the record number for the training you wish to delete: ");
                    int record = int.Parse(Console.ReadLine());
                    String[] lines = File.ReadAllLines($"..//..//..//{fileName}");
                    List<string> existing = new List<string>(lines);
                    existing.RemoveAt(record - 1);
                    File.WriteAllLines($"..//..//..//{fileName}", existing.ToArray());
                    break;

                case (int)files.Companies:
                    Console.WriteLine("Enter the record number for the company you wish to delete: ");
                    record = int.Parse(Console.ReadLine());
                    lines = File.ReadAllLines($"..//..//..//{fileName}");
                    existing = new List<string>(lines);
                    existing.RemoveAt(record - 1);
                    File.WriteAllLines($"..//..//..//{fileName}", existing.ToArray());
                    break;
            }



        }
    }
}
