using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjectList
{
    public class Square
    {
        public int Width;
        public int Height;
        public System.Tuple<int, int> OriginPoint;
        public Square(int WidthInput, int HeightInput, System.Tuple<int, int> OriginPointInput)
        {
            Width = WidthInput;
            Height = HeightInput;
            OriginPoint = OriginPointInput;
        }
        public static Square InputCreate()
        {
            Square Square = new Square(0,0,Tuple.Create(0,0));
            int TempInt;
            string TempString;
            FailedSquare1:
                Console.Write("Origin Position (X): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedSquare1;
            }
            Square.OriginPoint = Tuple.Create(int.Parse(TempString), Square.OriginPoint.Item2);
            FailedSquare2:
                Console.Write("Origin Position (Y): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedSquare2;
            }
            Square.OriginPoint = Tuple.Create(Square.OriginPoint.Item1, int.Parse(TempString));
            FailedSquare3:
                Console.Write("Size of Square (Width): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedSquare3;
            }
            Square.Width = int.Parse(TempString);
            FailedSquare4:
                Console.Write("Size of Square (Height): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedSquare4;
            }
            Square.Height = int.Parse(TempString);
            return Square;
        }
        public static string[][] Create(Square Square, string[][] Board)
        {
            int X;
            int Y;
            //bottom side
            for (X = 0; X < Square.Width; X++)
            {
                Board[Square.OriginPoint.Item1 + X][Square.OriginPoint.Item2] = "██";
            }
            //top side
            for (X = 0; X < Square.Width; X++)
            {
                Board[Square.OriginPoint.Item1 + X][Square.OriginPoint.Item2 + Square.Height - 1] = "██";
            }
            //left side
            for (Y = 0; Y < Square.Height; Y++)
            {
                Board[Square.OriginPoint.Item1][Square.OriginPoint.Item2 + Y] = "██";
            }
            //right side
            for (Y = 0; Y < Square.Height; Y++)
            {
                Board[Square.OriginPoint.Item1 + Square.Width - 1][Square.OriginPoint.Item2 + Y] = "██";
            }
            return Board;
        }
    }
    public class Circle
    {
        public int Radius;
        public System.Tuple<int, int> OriginPoint;
        public Circle(int RadiusInput, System.Tuple<int, int> OriginPointInput)
        {
            Radius = RadiusInput;
            OriginPoint = OriginPointInput;
        }
        public static Circle InputCreate()
        {
            Circle Circle = new Circle(0, Tuple.Create(0, 0));
            int TempInt;
            string TempString;
            FailedCircle1:
                Console.Write("Size of Circle (Radius): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedCircle1;
            }
            Circle.Radius = int.Parse(TempString);
            FailedCircle2:
                Console.Write("Origin Position (X): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedCircle2;
            }
            Circle.OriginPoint = Tuple.Create(int.Parse(TempString), Circle.OriginPoint.Item2);
            FailedCircle3:
                Console.Write("Origin Position (Y): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedCircle3;
            }
            Circle.OriginPoint = Tuple.Create(Circle.OriginPoint.Item1, int.Parse(TempString));
            
            return Circle;
        }
        public static string[][] Create(Circle Circle, string[][] Board)
        {
            for (double I = 1; I < 361; I++)
            {
                //copied from Baconzilla#1103 who prob found it on StackOverflow
                //adaped from Python of course
                //original code:
                // dX = distance*math.sin(math.radians(angle))
                // dY = distance*math.cos(math.radians(angle))
                int X = (int)(Convert.ToDouble(Circle.Radius) * Math.Sin(I));
                int Y = (int)(Convert.ToDouble(Circle.Radius) * Math.Cos(I));
                Board
                    [Circle.OriginPoint.Item1 + X/* + Circle.radius*/]
                    [Circle.OriginPoint.Item2 + Y/* + Circle.radius*/]
                = "██";
            }
            return Board;
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
        public System.Tuple<int, int> Point;
        public Pixel(System.Tuple<int, int> PointInput)
        {
            Point = PointInput;
        }
        public static Pixel InputCreate() {
            Pixel Pixel = new Pixel(Tuple.Create(0,0));
            int TempInt;
            string TempString;
            FailedPixel1:
                Console.Write("Point Position (X): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedPixel1;
            }
            Pixel.Point = Tuple.Create(int.Parse(TempString), Pixel.Point.Item2);
            FailedPixel2:
                Console.Write("Point Position (Y): ");
                TempString = Console.ReadLine();
            if (!int.TryParse(TempString, out TempInt))
            {
                goto FailedPixel2;
            }
            Pixel.Point = Tuple.Create(Pixel.Point.Item1, int.Parse(TempString));
            return Pixel;
        }
        public static string[][] Create(Pixel Pixel, string[][] Board)
        {
            Board[Pixel.Point.Item1][Pixel.Point.Item2] = "██";
            return Board;
        }
    }
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
            if (i*2 != Text.content.Length) {
                board[Text.originPoint.Item1+i][Text.originPoint.Item2] = (string)(Text.content[Text.content.Length-1] + " ");
            }
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
            int x = 0;
            for (int y = board[x].Length-1; y >= 0; y--) {
                for (x = 0; x < board.Length; x++) {
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
        }
        public static string[][] smoothBoard(string[][] Board)
        {
            

            string[][] ReturnBoard = new string[Board.Length][];

            // Console.WriteLine(Board.Length);

            for (int x = 0; x < Board.Length; x++)
            {
                ReturnBoard[x] = new string[Board[x].Length];

                // Console.WriteLine("x: " + x);

                for (int y = 0; y < Board[x].Length; y++)
                {
                    // ObjectList.Board.Print(ReturnBoard);

                    // Console.WriteLine("y: " + y);

                    if (Board[x][y] == "██")
                    {
                        bool top = false;
                        bool left = false;
                        bool right = false;
                        bool bottom = false;

                        if (y<Board[x].Length-1) { top = (Board[x][y+1] == "██"); }
                        if (x>0) { left = (Board[x-1][y] == "██"); }
                        if (x<Board.Length-1) { right = (Board[x+1][y] == "██"); }
                        if (y>0) { bottom = (Board[x][y-1] == "██"); }



                        if (top && left && right && bottom) {
                            ReturnBoard[x][y] = "╬╬";
                        } else if (top && left && right && !bottom) {
                            ReturnBoard[x][y] = "╩╩";
                        } else if (top && left && !right && bottom) {
                            ReturnBoard[x][y] = "╣║";
                        } else if (top && left && !right && !bottom) {
                            ReturnBoard[x][y] = "╩╝";
                        } else if (top && !left && right && bottom) {
                            ReturnBoard[x][y] = "║╠";
                        } else if (top && !left && right && !bottom) {
                            ReturnBoard[x][y] = "╚╩";
                        } else if (top && !left && !right && bottom) {
                            ReturnBoard[x][y] = "║║";
                        } else if (top && !left && !right && !bottom) {
                            ReturnBoard[x][y] = "╚╝";
                        } else if (!top && left && right && bottom) {
                            ReturnBoard[x][y] = "╦╦";
                        } else if (!top && left && right && !bottom) {
                            ReturnBoard[x][y] = "══";
                        } else if (!top && left && !right && bottom) {
                            ReturnBoard[x][y] = "╦╗";
                        } else if (!top && left && !right && !bottom) {
                            ReturnBoard[x][y] = "==";
                        } else if (!top && !left && right && bottom) {
                            ReturnBoard[x][y] = "╔╦";
                        } else if (!top && !left && right && !bottom) {
                            ReturnBoard[x][y] = "==";
                        } else if (!top && !left && !right && bottom) {
                            ReturnBoard[x][y] = "╔╗";
                        } else if (!top && !left && !right && !bottom) {
                            ReturnBoard[x][y] = "<>";
                        }
                    }
                    else
                    {
                        ReturnBoard[x][y] = Board[x][y];
                    }
                }
            }

            return ReturnBoard;
        }
    }
}