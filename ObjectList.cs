using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Drawer
{
    class Square
    {
        public int width;
        public int height;
        public Tuple<int, int> originPoint;

        public Square(int widthInput, int heightInput, Tuple<int, int> originPointInput)
        {
            width = widthInput;
            height = heightInput;
            originPoint = originPointInput;
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
        public int radius;
        public Tuple<int, int> originPoint;
        public Circle(int radiusInput, Tuple<int, int> originPointInput)
        {
            radius = radiusInput;
            originPoint = originPointInput;
        }

        public static string[][] Create(Circle Circle, string[][] board)
        {
            ////////
            for (double i = 1; i < 361; i++)
            {
                //copied from Baconzilla#1103 who prob found it on StackOverflow
                //adaped from Python of course
                //original code:
                // dX = distance*math.sin(math.radians(angle))
                // dY = distance*math.cos(math.radians(angle))

                int X = (int)(Convert.ToDouble(Circle.radius) * Math.Sin(i));
                int Y = (int)(Convert.ToDouble(Circle.radius) * Math.Cos(i));

                board
                    [Circle.originPoint.Item2 + Y + Circle.radius]
                    [Circle.originPoint.Item1 + X + Circle.radius]
                = "██";
            }
            ////////

            return board;
        }
    }
    class Triangle
    {
        public Tuple<int, int> pointOne;
        public Tuple<int, int> pointTwo;
        public Tuple<int, int> pointThree;
        public Triangle()
        {
            pointOne = Tuple.Create(0, 0);
            pointTwo = Tuple.Create(0, 0);
            pointThree = Tuple.Create(0, 0);
        }
    }



    public class Board
    {
        public static string[][] Create(int Width, int Height)
        {

            string[][] returnValue = new string[Height][];



            for (int i = 0; i < returnValue.Length; i++)
            {
                returnValue[i] = new string[Width];
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
            for (int i = 0; i < board.Length; i++)
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
                Console.Write("\n");
            }
        }
    }
}
