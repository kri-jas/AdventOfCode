using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day3
{
    class Day6c
    {
        static void Main(string[] args)
        {

            bool DifferentChar (string line)
            {
                if (line.Distinct().Count() == line.Length)
                { 
                    return true;
                }
                else
                {
                    return false;
                }
            }

            int num = 4; // 4 or 14 distinct characters
            //string fileName = "Day6InputTest.txt";
            //string fileName = "Day6InputTest2.txt";
            string fileName = "Day6Input.txt";
            string input = File.ReadAllText(fileName);
            for (int i = 0; i <= input.Length - num; i++)
            {
                string segment = input.Substring(i, num);
                if(DifferentChar(segment))
                {
                    Console.WriteLine($"First marker after character: {i+num}");
                    break;
                }
            }
        }
    }
}
