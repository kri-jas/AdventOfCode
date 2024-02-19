using System;
using System.IO;

namespace Day2
{
    class Day2
    {
        static void Main(string[] args)
        {
            int handShapeToPoints (char shape)
            {
                switch (shape)
                {
                    case 'A': return 1; //rock
                    case 'X': return 1;
                    case 'B': return 2; //paper
                    case 'Y': return 2;
                    case 'C': return 3; //scissors
                    case 'Z': return 3;
                    default: return -1;
                }
            }

            bool victory(char player1, char player2) //+ 6 because you won
            {
                switch (player1,player2)
                {
                    case ('A', 'Z'): return true; //rock & scissors
                    case ('B', 'X'): return true; //paper & rock
                    case ('C','Y'): return true; //scissors & paper
                    default: return false;
                }
            }

            bool draw(char player1, char player2)
            {
                switch (player1, player2)
                {
                    case ('A', 'X'): return true; 
                    case ('B', 'Y'): return true;
                    case ('C', 'Z'): return true; 
                    default: return false;
                }
            }

            int score(char player1, char player2)
            {
                int myPoints = handShapeToPoints(player1);
                if (victory(player1, player2))
                    myPoints += 6; 
                else if (draw(player1, player2))
                    myPoints += 3; 
                return myPoints;
            }


            string fileName = "inputTest.txt";
            int total = 0;
            if (File.Exists(fileName))
            {
                Console.WriteLine("--- A/X for Rock, B/Y for Paper, and C/Z for Scissors ---");
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length == 2)
                        {
                            char symbol1 = parts[0][0];
                            char symbol2 = parts[1][0];

                            int pointsOfPlayer1 = handShapeToPoints(symbol1);
                            int pointsOfPlayer2 = handShapeToPoints(symbol2);

                            int pointsPerRound = score(symbol1, symbol2);

                            Console.WriteLine($"{symbol1} and { symbol2} -> {pointsPerRound}");
                            total += pointsPerRound;
                        }
                    }
                    Console.WriteLine($"Total score = {total}");
                }
            }
            else
            {
                Console.WriteLine("The file does not exist :(");
            }


        }
    }
}
