using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1
{
    class Experience : IExperience
    {
        private string companyName;
        private string companyDesc;
        private string start, end;
        private int year;

        public void SelectCompany()
        {
            Console.Clear();
            Console.WriteLine("This is the experience section.");
            //i.e: the first company in the file is ceridian, hence the index 0
            var lines = File.ReadAllLines("..//..//..//companies.csv");
            Console.WriteLine("Select the company to learn more about by typing in the name: ");
            foreach (var l in lines)
            {
                var value = l.Split(',');
                Console.WriteLine($"-{value[0]}");
            }
            var choice = Console.ReadLine().ToLower();
            DisplayCompany(choice);

        }

        public void DisplayCompany(string choice)
        {

            //check if there is data in the file
            var lines = File.ReadAllLines("..//..//..//companies.csv");
            foreach (var line in lines)
            {
                if (line == "")
                {
                    Console.WriteLine("No information available");
                }
                else
                {
                    var values = line.Split(',');
                    companyName = (string)values[0];
                    companyDesc = values[1];
                    start = values[2];
                    end = values[3];
                    year = int.Parse(values[4]);

                    if (companyName.Equals(choice, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //display info about the company
                        Console.WriteLine($"Company Name: {companyName}");
                        Console.WriteLine($"Company Description: {companyDesc}");
                        Console.WriteLine($"Start Month: {start}");
                        Console.WriteLine($"End Month: {end}");
                        Console.WriteLine($"Year: {year}");
                        Console.WriteLine("Press Enter to go back to the Guest Menu");
                        Console.ReadLine();
                    }

                        
                    
                }

            }
            Program.GuestMenu();

            Console.ReadLine();

        }
    }
}