using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1
{
    class Experience
    {
        private string companyName;
        private string companyDesc;
        private string start, end;
        private int year;

        public void Ceridian()
        {
            Console.Clear();
            //i.e: the first company in the file is ceridian, hence the index 0
            var lines = File.ReadAllLines("ceridian.csv");

            //check if there is data in the file
            if (lines[0] == "")
            {
                Console.WriteLine("No information available");
            }
            else
            {
                var values = lines[0].Split(',');
                Console.WriteLine(values[0] + " is a " + values[1] + " company. I started an internship programme " +
                        "for the position of a " + values[2] + " starting from " + values[3] + " and ending in " + values[4] + ". The" +
                        "main programming language we are being taught is " + values[5]);
            }


            Console.ReadLine();

        }
    }
}