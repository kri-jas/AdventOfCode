using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day8c
{
    class Day8c
    {
        static void Main(string[] args)
        {
            static int[,] LinesToArray(string[] lines)
            {
                int RowNum = lines.Length;
                int ColNum = lines[0].Length;
                int[,] AllInOne = new int[RowNum, ColNum];
                int i = 0;
                foreach (string line in lines)
                {
                    int j = 0;
                    foreach(char CharInt in line)
                    {
                        AllInOne[i, j] = int.Parse(CharInt.ToString());
                        //Console.WriteLine($"{AllInOne[i, j]}");
                       j++;
                    }
                    i++;
                }
                return AllInOne;
            }

            static bool IsVisibleRight(int[,] Map, int Row, int Col)
            {
                int Height = Map[Row, Col];
                int CountCol = Map.GetLength(1);
                for (int k = Col + 1; k < CountCol; k++)
                {
                    int OtherTreeHeight = Map[Row, k];
                    if (Height <= OtherTreeHeight)
                    {
                        return false;  //invisible
                    }
                }
                return true;
            }

            static bool IsVisibleLeft(int[,] Map, int Row, int Col)
            {
                int Height = Map[Row, Col];
                for (int k = Col - 1; k >= 0; k--)
                {
                    int OtherTreeHeight = Map[Row, k];
                    if (Height <= OtherTreeHeight)
                    {
                        return false;  //invisible
                    }
                }
                return true;
            }

            static bool IsVisibleUp(int[,] Map, int Row, int Col)
            {
                int Height = Map[Row, Col];
                for (int k = Row - 1; k >= 0; k--)
                {
                    int OtherTreeHeight = Map[k, Col];
                    if (Height <= OtherTreeHeight)
                    {
                        return false;  //invisible
                    }
                }
                return true;
            }


            static bool IsVisibleDown(int[,] Map, int Row, int Col)
            {
                int Height = Map[Row, Col];
                int CountRow = Map.GetLength(0);
                for (int k = Row + 1; k < CountRow; k++)
                {
                    int OtherTreeHeight = Map[k, Col];
                    if (Height <= OtherTreeHeight)
                    {
                        return false;  //invisible
                    }
                }
                return true;
            }

            static bool IsVisible(int[,] Map, int Row, int Col)
            {
                return IsVisibleLeft(Map, Row, Col) || IsVisibleRight(Map, Row, Col) || IsVisibleUp(Map, Row, Col) || IsVisibleDown(Map, Row, Col);
            }


            //string fileName = "inputDay8Test.txt";
            string fileName = "inputDay8.txt";
            string[] lines = File.ReadAllLines(fileName);
            int[,] input = LinesToArray(lines);
            int num = 0;
            int RowNum = input.GetLength(0);
            int ColNum = input.GetLength(1);
            for (int i = 0; i < RowNum; i++)
            {
                for (int j = 0; j < ColNum; j++)
                {
                    if (IsVisible(input, i, j))
                    {
                        num++;
                    }
                }
            }
            Console.WriteLine($"How many trees are visible? {num}");


        }
    }
}
