using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Day5c
{
    class Day5
    {
        static void Main(string[] args)
        {
            List<List<string>> stacksNum(string line)
            {
                List<List<string>> col = new();
                int num = (1 + line.Length) / 4;
                int k = 0;
                while (k < num)
                {
                    col.Add(new List<string>());
                    k++;
                }
                return col;
            }


            string fileName = "inputDay5test.txt";
            string[] lines = File.ReadAllLines(fileName);
            int l = 0;
            var numbers = movementDirections("");
            foreach (string row in File.ReadAllLines(fileName))
            {
                //stacksNum(row);
                //Console.WriteLine(row);
                //Console.WriteLine($"It is: {row}");
                if (puzzleOrNot(row))
                {
                    letterPosition(row, l);
                    l++;
                }
                else if (instructionsOrNot(row))
                {
                    numbers = movementDirections(row);
                    Console.WriteLine("move" + numbers[0] + " from " + numbers[1] + " to " + numbers[2]);
                   // move(numbers[1], numbers[2],stacksNum();
                }
            }
            Console.WriteLine(numbers[2]);
        }
        static void letterPosition(string lines, int lineNum)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                char symbol = lines[i];
                if (symbol != ' ' && symbol != ']' && symbol != '[')
                {
                    Console.WriteLine($"Letter at line [{lineNum + 1}], column [{1 + i / 4}]: {symbol}");
                }
            }
        }
/*
        void parseContainer(string row, List<List<char>> stacks)
        {
            for (int i = 0; i < stacks.Count; i++)
            {
                int colx = i * 4 + 1;
                char ch = row[colx];
                if (ch != ' ')
                {
                    stacks[i].Add(ch);
                }
            }
                
        }
*/
        static bool puzzleOrNot(string line)
        {
            return line.Contains("[");
        }

        static bool instructionsOrNot(string line)
        {
            return line.Contains("move");
        }

        static List<int> movementDirections(string line)
        {
            List<int> directions = new List<int>();
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (int.TryParse(word, out int number))
                {
                    directions.Add(number);
                    //Console.WriteLine($"{number}");
                }
            }
            return directions;
        }
        void move(int from, int to, List<List<string>> stacks)
        {
            string crate = stacks[from - 1][0];
            stacks[from - 1].RemoveAt(0);
            stacks[to - 1].Insert(0, crate);
        }
        void rearrangement(move dir, )
        {
            move(int from, int to, List < List<string> > stacks)
        }
    }
}
