using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1
{
    class Education
    {

        public void DisplayYear(int year)
        {
            Console.Clear();
            var lines = File.ReadAllLines("..//..//..//uni.csv");
          
            //check which year is to be displayed
            switch (year)
            {
                case 1:
                    if (lines[0] == "")
                    {
                        Console.WriteLine("No information available");
                    }
                    else
                    {
                        Console.WriteLine("Below are the modules covered in Year 1 of Software Engineering: ");
                        var modules = lines[0].Split(',');
                        for (int i = 0; i < 6; i++)
                        {
                            Console.WriteLine("- " + modules[i]);
                        }
                    }

                    // read line 3 for year 1 projects
                    var projects = lines[2].Split(',');
                    Console.WriteLine("Below are all the projects covered in that year: ");
                    foreach (var value in projects)
                    {
                        Console.WriteLine($"- {value}");
                    }

                    Submenus.EducationMenu();
                    Console.ReadLine();

                    break;

                case 2:

                    //check if there is data in the file
                    if (lines[1] == "")
                    {
                        Console.WriteLine("No information available");
                    }
                    else
                    {
                        Console.WriteLine("Below are the modules covered in Year 2 of Software Engineering: ");
                        var modules = lines[1].Split(',');
                        for (int i = 0; i < 6; i++)
                        {
                            Console.WriteLine("- " + modules[i]);
                        }
                    }

                    // read line 4 for year 2 projects
                    var projects2 = lines[3].Split(',');
                    Console.WriteLine("Below are all the projects covered in that year: ");
                    foreach (var value in projects2)
                    {
                        Console.WriteLine($"- {value}");
                    }

                    Console.WriteLine("___________________________");
                    Submenus.EducationMenu();
                    Console.ReadLine();
                    break;
            }
            
        }

        public void AdditionalTraining()
        {
            Console.Clear();
            var lines = File.ReadAllLines("..//..//..//additionaltraining.csv");
            Console.WriteLine("In addition to the two years at the University, below are the additional training I have done: ");
            foreach(var line in lines)
            {
                var values = line.Split(',');
                foreach (var v in values)
                {
                    Console.WriteLine($"- {v}");
                }
            }

            Console.WriteLine("___________________________");
            Submenus.EducationMenu();
            Console.ReadLine();

        }

    }
}
