using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjectList
{
    public class Text
    {
        public System.Tuple<int, int> originPoint;
        public string content;
        /*public bool orientation;*/

        public Text(System.Tuple<int, int> originPointInput, string contentInput/*, bool orientationInput*/) {
            originPoint = originPointInput;
            content = contentInput;
            /*orientation = orientationInput;*/
        }
        public static Text InputCreate() {
            Text text = new Text(Tuple.Create(0,0),""/*,false*/);
            int tempInt;
            string tempString;
            FailedText1:
                Console.Write("Origin Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedText1;
            }
            text.originPoint = Tuple.Create(int.Parse(tempString), text.originPoint.Item2);
            FailedText2:
                Console.Write("Origin Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedText2;
            }
            text.originPoint = Tuple.Create(text.originPoint.Item1, int.Parse(tempString));
            Console.Write("Content of Text: ");
            text.content = Console.ReadLine();
            return text;
        }
        public static string[][] Create(Text Text, string[][] board) {

            int i = 0;
            int j = 0;

            for (i = 0; i < Math.Floor((decimal)(Text.content.Length/2)); i++) {
                board[Text.originPoint.Item1+i][Text.originPoint.Item2] = (string)(Text.content[j] + "" + Text.content[j+1]);
                j+=2;
            }

            if (Text.content.Length-1 > j) {
                board[Text.originPoint.Item1+i][Text.originPoint.Item2] = (string)(Text.content[Text.content.Length-1] + " ");
            }

            return board;
        }
    }
    public class Square
    {
        public int width;
        public int height;
        public System.Tuple<int, int> originPoint;
        public Square(int widthInput, int heightInput, System.Tuple<int, int> originPointInput)
        {
            width = widthInput;
            height = heightInput;
            originPoint = originPointInput;
        }
        public static Square InputCreate()
        {
            Square square = new Square(0,0,Tuple.Create(0,0));
            int tempInt;
            string tempString;
            FailedSquare1:
                Console.Write("Origin Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedSquare1;
            }
            square.originPoint = Tuple.Create(int.Parse(tempString), square.originPoint.Item2);
            FailedSquare2:
                Console.Write("Origin Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedSquare2;
            }
            square.originPoint = Tuple.Create(square.originPoint.Item1, int.Parse(tempString));
            FailedSquare3:
                Console.Write("Size of Square (Width): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedSquare3;
            }
            square.width = int.Parse(tempString);
            FailedSquare4:
                Console.Write("Size of Square (Height): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedSquare4;
            }
            square.height = int.Parse(tempString);
            return square;
        }
        public static string[][] Create(Square Square, string[][] board)
        {
            int X;
            int Y;
            //bottom side
            for (X = 0; X < Square.width; X++)
            {
                board[Square.originPoint.Item1 + X][Square.originPoint.Item2] = "██";
            }
            //top side
            for (X = 0; X < Square.width; X++)
            {
                board[Square.originPoint.Item1 + X][Square.originPoint.Item2 + Square.height - 1] = "██";
            }
            //left side
            for (Y = 0; Y < Square.height; Y++)
            {
                board[Square.originPoint.Item1][Square.originPoint.Item2 + Y] = "██";
            }
            //right side
            for (Y = 0; Y < Square.height; Y++)
            {
                board[Square.originPoint.Item1 + Square.width - 1][Square.originPoint.Item2 + Y] = "██";
            }
            return board;
        }
    }
    public class Circle
    {
        public int radius;
        public System.Tuple<int, int> originPoint;
        public Circle(int radiusInput, System.Tuple<int, int> originPointInput)
        {
            radius = radiusInput;
            originPoint = originPointInput;
        }
        public static Circle InputCreate()
        {
            Circle circle = new Circle(0, Tuple.Create(0, 0));
            int tempInt;
            string tempString;
            FailedCircle1:
                Console.Write("Size of Circle (Radius): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedCircle1;
            }
            circle.radius = int.Parse(tempString);
            FailedCircle2:
                Console.Write("Origin Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedCircle2;
            }
            circle.originPoint = Tuple.Create(int.Parse(tempString), circle.originPoint.Item2);
            FailedCircle3:
                Console.Write("Origin Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedCircle3;
            }
            circle.originPoint = Tuple.Create(circle.originPoint.Item1, int.Parse(tempString));
            
            return circle;
        }
        public static string[][] Create(Circle Circle, string[][] board)
        {
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
                    [Circle.originPoint.Item1 + X/* + Circle.radius*/]
                    [Circle.originPoint.Item2 + Y/* + Circle.radius*/]
                = "██";
            }
            return board;
        }
    }
    public class Triangle
    {
        public System.Tuple<int, int> pointOne;
        public System.Tuple<int, int> pointTwo;
        public System.Tuple<int, int> pointThree;
        public Triangle(System.Tuple<int, int> pnt1, System.Tuple<int, int> pnt2, System.Tuple<int, int> pnt3)
        {
            pointOne = pnt1;
            pointTwo = pnt2;
            pointThree = pnt3;
        }
        public static Triangle InputCreate()
        {
            Triangle triangle = new Triangle(Tuple.Create(0, 0), Tuple.Create(0, 0), Tuple.Create(0, 0));
            int tempInt;
            string tempString;
            FailedLine1:
                Console.Write("Point1 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine1;
            }
            triangle.pointOne = Tuple.Create(int.Parse(tempString), triangle.pointOne.Item2);
            FailedLine2:
                Console.Write("Point1 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine2;
            }
            triangle.pointOne = Tuple.Create(triangle.pointOne.Item1, int.Parse(tempString));
            FailedLine3:
                Console.Write("Point2 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine3;
            }
            triangle.pointTwo = Tuple.Create(int.Parse(tempString), triangle.pointTwo.Item2);
            FailedLine4:
                Console.Write("Point2 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine4;
            }
            triangle.pointTwo = Tuple.Create(triangle.pointTwo.Item1, int.Parse(tempString));
            FailedLine5:
                Console.Write("Point3 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine5;
            }
            triangle.pointThree = Tuple.Create(int.Parse(tempString), triangle.pointThree.Item2);
            FailedLine6:
                Console.Write("Point3 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine6;
            }
            triangle.pointThree = Tuple.Create(triangle.pointThree.Item1, int.Parse(tempString));
            return triangle;
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
    public class Line
    {
        public System.Tuple<int, int> pointOne;
        public System.Tuple<int, int> pointTwo;
        public Line(System.Tuple<int, int> pnt1, System.Tuple<int, int> pnt2)
        {
            pointOne = pnt1;
            pointTwo = pnt2;
        }
        public static Line InputCreate()
        {
            Line line = new Line(Tuple.Create(0, 0), Tuple.Create(0, 0));
            int tempInt;
            string tempString;
            FailedLine1:
                Console.Write("Point1 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine1;
            }
            line.pointOne = Tuple.Create(int.Parse(tempString), line.pointOne.Item2);
            FailedLine2:
                Console.Write("Point1 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine2;
            }
            line.pointOne = Tuple.Create(line.pointOne.Item1, int.Parse(tempString));
            FailedLine3:
                Console.Write("Point2 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine3;
            }
            line.pointTwo = Tuple.Create(int.Parse(tempString), line.pointTwo.Item2);
            FailedLine4:
                Console.Write("Point2 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine4;
            }
            line.pointTwo = Tuple.Create(line.pointTwo.Item1, int.Parse(tempString));
            return line;
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
            double angle = Math.Atan2(DifferenceX, DifferenceY);
            double angle_degrees = angle * 180 / Math.PI;
            double distance = Math.Sqrt(Math.Pow(line.pointTwo.Item1 - line.pointOne.Item1, 2) + Math.Pow(line.pointTwo.Item2 - line.pointOne.Item2, 2));
            for (int i = 0; i < distance; i++)
            {
                int X = (int)(Convert.ToDouble(i) * Math.Sin(angle));
                int Y = (int)(Convert.ToDouble(i) * Math.Cos(angle));
                board[X + line.pointOne.Item1][Y + line.pointOne.Item2] = "██";
            }
            return board;
        }
    }
    public class Pixel
    {
        public System.Tuple<int, int> point;
        public Pixel(System.Tuple<int, int> pnt)
        {
            point = pnt;
        }
        public static string[][] Create(Pixel pixel, string[][] board)
        {
            board[pixel.point.Item1][pixel.point.Item2] = "██";
            return board;
        }
    }
    public class Board
    {
        public static string[][] Create(int Width, int Height)
        {
            string[][] returnValue = new string[Width][];
            for (int x = 0; x < returnValue.Length; x++)
            {
                returnValue[x] = new string[Height];

                for (int y = 0; y < returnValue[x].Length; y++)
                {
                    returnValue[x][y] = "  ";
                }
            }

            return returnValue;
        }
        public static int[] InputCreate()
        {
            int tempInt;
            FailedInputBoardWidth:
                Console.Write("Size of board (Width): ");
                string width = Console.ReadLine();
            if (!int.TryParse(width, out tempInt))
            {
                goto FailedInputBoardWidth;
            }
            FailedInputBoardHeight:
                Console.Write("Size of board (Height): ");
                string height = Console.ReadLine();
            if (!int.TryParse(height, out tempInt))
            {
                goto FailedInputBoardHeight;
            }
            int[] temp = { int.Parse(width), int.Parse(height) };
            return temp;
        }
        public static void Print(string[][] board)
        {

            for (int y = board.Length-1; y >= 0; y--) {
                for (int x = 0; x < board.Length; x++) {
                    if (board[x][y] == null)
                    {
                        Console.Write("  ");
                    } else
                    {
                        Console.Write(board[x][y]);
                    }
                }
                Console.WriteLine("");
            }
            






            /*for (int x = 0; x < board.Length; x++)
            {
                for (int y = 0; y < board[x].Length; y++)
                {
                    if (board[x][y] == null)
                    {
                        Console.Write("[]");
                    } else
                    {
                        Console.Write(board[x][y]);
                    }
                }
                Console.Write("\n");
            }*/
        }
    }
}