using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1
{
    class Experience:IExperience
    {
        private string companyName;
        private string companyDesc;
        private string start, end;
        private int year;



        public void Ceridian()
        {
            Console.Clear();
            //i.e: the first company in the file is ceridian, hence the index 0
            var lines = File.ReadAllLines("..//..//..//companies.csv");

            //check if there is data in the file
            if (lines[0] == "")
            {
                Console.WriteLine("No information available");
            }
            else
            {
                var values = lines[0].Split(',');
                companyName = values[0];
                companyDesc = values[1];
                start = values[2];
                end = values[3];
                year = int.Parse(values[4]);
            }

            Console.WriteLine($"Company Name: {companyName}");
            Console.WriteLine($"Company Description: {companyDesc}");
            Console.WriteLine($"Start Month: {start}");
            Console.WriteLine($"End Month: {end}");
            Console.WriteLine($"Year: {year}");


            Program.ExperienceMenu();

            Console.ReadLine();

        }

        public void TenEleven()
        {
            Console.Clear();
            //i.e: the second company in the file is ten eleven, hence the index 1
            var lines = File.ReadAllLines("..//..//..//companies.csv");

            //check if there is data in the file
            if (lines[1] == "")
            {
                Console.WriteLine("No information available");
            }
            else
            {
                var values = lines[1].Split(',');
                companyName = values[0];
                companyDesc = values[1];
                start = values[2];
                end = values[3];
                year = int.Parse(values[4]);
            }

            Console.WriteLine($"Company Name: {companyName}");
            Console.WriteLine($"Company Description: {companyDesc}");
            Console.WriteLine($"Start Month: {start}");
            Console.WriteLine($"End Month: {end}");
            Console.WriteLine($"Year: {year}");

            Program.ExperienceMenu();


            Console.ReadLine();

        }
    }
}