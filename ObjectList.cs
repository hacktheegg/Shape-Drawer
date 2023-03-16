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
        public Triangle(Tuple<int, int> pnt1, Tuple<int, int> pnt2, Tuple<int, int> pnt3)
        {
            pointOne = pnt1;
            pointTwo = pnt2;
            pointThree = pnt3;
        }
        public static string[][] Create(Triangle triangle, string[][] board)
        {
            Line line = new Line(triangle.pointOne, triangle.pointTwo);
            board = Line.Create(line, board);
            line = new Line(triangle.pointTwo, triangle.pointThree);
            board = Line.Create(line, board);
            line = new Line(triangle.pointThree, triangle.pointOne);
            board = Line.Create(line, board);

            return board;
        }
    }
    class Line
    {
        public Tuple<int, int> pointOne;
        public Tuple<int, int> pointTwo;
        public Line(Tuple<int, int> pnt1, Tuple<int, int> pnt2)
        {
            pointOne = pnt1;
            pointTwo = pnt2;
        }
        public static string[][] Create(Line line, string[][] board)
        {

            //I dont care if this is chatGPT, I tried 3 different methods that all didnt work

            //there was the one that was used in a minecraft video (only drew x,y lines no diagonals)

            //there was also the one that used the default slope algorithm and flipped it so it worked
            // in all eight radians (only a dot was created)

            //and finally i tried to get an angle and length instead, but i want it to be as easy to use
            // as possible and having points is the easiest way



            double DifferenceX = line.pointTwo.Item1 - line.pointOne.Item1;
            double DifferenceY = line.pointTwo.Item2 - line.pointOne.Item2;

            double angle = Math.Atan2(DifferenceY, DifferenceX);

            double angle_degrees = angle * 180 / Math.PI;


            double distance = Math.Sqrt(Math.Pow(line.pointTwo.Item1 - line.pointOne.Item1, 2) + Math.Pow(line.pointTwo.Item2 - line.pointOne.Item2, 2));


            for (int i = 0; i < distance; i++)
            {

                int X = (int)(Convert.ToDouble(i) * Math.Sin(angle));
                int Y = (int)(Convert.ToDouble(i) * Math.Cos(angle));

                board[X + line.pointOne.Item2][Y + line.pointOne.Item1] = "██";
            }

            return board;
        }
    }
    class Pixel
    {
        public Tuple<int, int> point;
        public Pixel(Tuple<int, int> pnt)
        {
            point = pnt;
        }
        public static string[][] Create(Pixel pixel, string[][] board)
        {
            board[pixel.point.Item2][pixel.point.Item2] = "██";

            return board;
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
