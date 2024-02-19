using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    class Day4
    {
        static void Main(string[] args)
        {
            //  string[] parts = input.Split('-');
            // int start = int.Parse();

            int[] ExtractNum(string input)
            {
                var matches = Regex.Matches(input, @"\d+");     //\d is short for [0-9], + one or more of the expression
                var num = new int[matches.Count];
                int i = 0;
                foreach (var match in matches)
                {
                    num[i++] = int.Parse(match.ToString());
                }
                return num;
            }

            bool Contains(int start1, int end1, int start2, int end2)
            {
                if ((start1 - start2 <= 0 && end1 - end2 >= 0) || (start1 - start2 >= 0 && end1 - end2 <= 0))
                {
                    //Console.WriteLine($"{start1}-{end1} and {start2}-{end2} - YES, one range fully contains the other");
                    return true;
                }
                else
                {
                    //Console.WriteLine($"{start1}-{end1} and {start2}-{end2} - one range NOT fully contains the other");
                    return false;
                }
            }

            bool Overlaps(int start1, int end1, int start2, int end2)
            {
                if ((end1 == start2) || (end1 - start2 > 0 && start1 - end2 <= 0) || (end1 - start2 >= 0 && start1 - end2 < 0 ))
                {
                    //Console.WriteLine($"{start1}-{end1} and {start2}-{end2} - YES");
                    return true;
                }
                else
                {
                    //Console.WriteLine($"{start1}-{end1} and {start2}-{end2} - NO");
                    return false;
                }
            }


            string fileName = "intputDay4.txt";
            string[] lines = File.ReadAllLines(fileName);
            int k = 0, o = 0;
            foreach (string line in File.ReadAllLines(fileName))
            {
                var numbers = ExtractNum(line);
                //Console.WriteLine(numbers[0]+ "-"+ numbers[1]+" AND "+ numbers[2] + "-" + numbers[3]);
                //Contains(numbers[0], numbers[1], numbers[2], numbers[3]);
                if (Contains(numbers[0], numbers[1], numbers[2], numbers[3]))
                {
                    k++;
                }
                if (Overlaps(numbers[0], numbers[1], numbers[2], numbers[3]))
                {
                    o++;
                }
            }
        Console.WriteLine($"In how many assignment pairs does one range fully contain the other? {k}");
        Console.WriteLine($"In how many assignment pairs do the ranges overlap? {o}");
        }
    }
}
