using System;
using System.IO;
using System.Linq; // to use Intersect

namespace Day3
{
    class Day3
    {
        static void Main(string[] args)
        {
            string fileName = "rucksacksTest.txt";

            (string, string) parts(string rucksacks)
            {
                int len = rucksacks.Length;
                string firstHalf = rucksacks.Substring(0, len / 2);
                string secondtHalf = rucksacks.Substring((len / 2));
                return (firstHalf, secondtHalf);
            }

            char sameSymbol(string firstString, string secondString)
            {
                return firstString.Intersect(secondString).First();
            }

            int priorityPoints(char letter)
            {
                if (char.IsLower(letter))
                {
                    return letter - 'a' + 1;
                }
                else
                { 
                    return letter - 'A' + 27;
                }
                
            }

            int totalScore = 0;
            foreach (string line in File.ReadAllLines(fileName))
            {
                if (line.Length != 0)
                {
                    parts(line);
                    (string part1, string part2) = parts(line);
                    char symbol = sameSymbol(part1, part2);
                    int points = priorityPoints(symbol);
                    Console.WriteLine($" {symbol} ({points}) <= {part1} &  {part2}");
                    totalScore += points;
                }
            }
            Console.WriteLine($"----Total priority score: {totalScore} ");

        }
    }
}
