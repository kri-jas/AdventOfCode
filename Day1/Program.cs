//---Day 1: Calorie Counting ---
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        long sum = 0;
        long MaxValue = 0;
        int num = 0;
        foreach (string line in File.ReadAllLines("calories_list.txt"))
        {
            if (line.Length != 0)
            {
                int calories = int.Parse(line);
                Console.WriteLine(calories);
                sum += calories;
            }
            else
            {
                Console.WriteLine($"Sum: {sum}");
                if (sum > MaxValue) MaxValue = sum;
                //Console.WriteLine($"MaxValue is: {MaxValue}");
                sum = 0;
                num += 1;
            }
        }
        Console.WriteLine($"----MaxCalories: {MaxValue} carried by the Elf no {num}----");
    }
}