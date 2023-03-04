using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Drawer
{
    class Square
    {
        public int width;
        public int height;
        public Tuple<int, int> originPoint;

        public Square()
        {
            width = 0;
            height = 0;
            originPoint = Tuple.Create(0, 0);
        }
        
        public static string[][] Create(Square Square, string[][] board)
        {
            int X;
            int Y;

            //bottom side
            for (X = 0; X < Square.width; X++)
            {
                board[Square.originPoint.Item2][Square.originPoint.Item1 + X] = "██";
            }
            //top side
            for (X = 0; X < Square.width; X++)
            {
                board[Square.originPoint.Item2 + Square.height - 1][Square.originPoint.Item1 + X] = "██";
            }

            //left side
            for (Y = 0; Y < Square.height; Y++)
            {
                board[Square.originPoint.Item2 + Y][Square.originPoint.Item1] = "██";
            }
            //right side
            for (Y = 0; Y < Square.height; Y++)
            {
                board[Square.originPoint.Item2 + Y][Square.originPoint.Item1 + Square.width - 1] = "██";
            }

            return board;
        }
    }


    class Circle
    {
        int radius = 0;
        public Tuple<int, int> originPoint;
        public Circle()
        {
            radius = 0;
            originPoint = Tuple.Create(0, 0);
        }

    }
    class Triangle
    {
        public Tuple<int, int> pointTop;
        public Tuple<int, int> pointTwo;
        public Tuple<int, int> originPoint;
        public Triangle()
        {
            pointTop = Tuple.Create(0, 0);
            pointTwo = Tuple.Create(0, 0);
            originPoint = Tuple.Create(0, 0);
        }
    }



    public class Board
    {
        public static string[][] Create(int size)
        {

            string[][] returnValue = new string[size][];



            for (int i = 0; i < returnValue.Length; i++)
            {
                returnValue[i] = new string[size];
            }



            for (int i = 0; i < returnValue.Length; i++)
            {
                for (int j = 0; j < returnValue[i].Length; j++)
                {
                    returnValue[i][j] = "  ";
                }
            }



            return returnValue;
        }

        public static void Print(string[][] board)
        {
            for (int i = board.Length - 1; i > -1; i--)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == null)
                    {
                        Console.Write("  ");
                    } else
                    {
                        Console.Write(board[i][j]);
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
