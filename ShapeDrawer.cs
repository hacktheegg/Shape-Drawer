using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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
        public static Board Create(Square Square, Board Board)
        {
            int X;
            int Y;
            //bottom side
            for (X = 0; X < Square.Width; X++)
            {
                Board.Grid[Square.OriginPoint.Item1 + X][Square.OriginPoint.Item2] = "██";
            }
            //top side
            for (X = 0; X < Square.Width; X++)
            {
                Board.Grid[Square.OriginPoint.Item1 + X][Square.OriginPoint.Item2 + Square.Height - 1] = "██";
            }
            //left side
            for (Y = 0; Y < Square.Height; Y++)
            {
                Board.Grid[Square.OriginPoint.Item1][Square.OriginPoint.Item2 + Y] = "██";
            }
            //right side
            for (Y = 0; Y < Square.Height; Y++)
            {
                Board.Grid[Square.OriginPoint.Item1 + Square.Width - 1][Square.OriginPoint.Item2 + Y] = "██";
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
        public static Board Create(Circle Circle, Board Board)
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
                Board.Grid
                    [Circle.OriginPoint.Item1 + X/* + Circle.radius*/]
                    [Circle.OriginPoint.Item2 + Y/* + Circle.radius*/]
                = "██";
            }
            return Board;
        }
    }
    public class Triangle
    {
        public System.Tuple<int, int> PointOne;
        public System.Tuple<int, int> PointTwo;
        public System.Tuple<int, int> PointThree;
        public Triangle(System.Tuple<int, int> pnt1, System.Tuple<int, int> pnt2, System.Tuple<int, int> pnt3)
        {
            PointOne = pnt1;
            PointTwo = pnt2;
            PointThree = pnt3;
        }
        public static Triangle InputCreate()
        {
            Triangle Triangle = new Triangle(Tuple.Create(0, 0), Tuple.Create(0, 0), Tuple.Create(0, 0));
            int tempInt;
            string tempString;
            FailedLine1:
                Console.Write("Point1 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine1;
            }
            Triangle.PointOne = Tuple.Create(int.Parse(tempString), Triangle.PointOne.Item2);
            FailedLine2:
                Console.Write("Point1 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine2;
            }
            Triangle.PointOne = Tuple.Create(Triangle.PointOne.Item1, int.Parse(tempString));
            FailedLine3:
                Console.Write("Point2 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine3;
            }
            Triangle.PointTwo = Tuple.Create(int.Parse(tempString), Triangle.PointTwo.Item2);
            FailedLine4:
                Console.Write("Point2 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine4;
            }
            Triangle.PointTwo = Tuple.Create(Triangle.PointTwo.Item1, int.Parse(tempString));
            FailedLine5:
                Console.Write("Point3 Position (X): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine5;
            }
            Triangle.PointThree = Tuple.Create(int.Parse(tempString), Triangle.PointThree.Item2);
            FailedLine6:
                Console.Write("Point3 Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedLine6;
            }
            Triangle.PointThree = Tuple.Create(Triangle.PointThree.Item1, int.Parse(tempString));
            return Triangle;
        }
        public static Board Create(Triangle Triangle, Board Board)
        {
            Line Line = new Line(Triangle.PointOne, Triangle.PointTwo);
            Board = Line.Create(Line, Board);
            Line = new Line(Triangle.PointTwo, Triangle.PointThree);
            Board = Line.Create(Line, Board);
            Line = new Line(Triangle.PointThree, Triangle.PointOne);
            Board = Line.Create(Line, Board);
            return Board;
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
        public static Board Create(Line Line, Board board)
        {
            //I dont care if this is chatGPT, I tried 3 different methods that all didnt work

            //there was the one that was used in a minecraft video (only drew x,y lines no diagonals)

            //there was also the one that used the default slope algorithm and flipped it so it worked
            // in all eight radians (only a dot was created)

            //and finally i tried to get an angle and length instead, but i want it to be as easy to use
            // as possible and having points is the easiest way

            double DifferenceX = Line.pointTwo.Item1 - Line.pointOne.Item1;
            double DifferenceY = Line.pointTwo.Item2 - Line.pointOne.Item2;
            double angle = Math.Atan2(DifferenceX, DifferenceY);
            double angle_degrees = angle * 180 / Math.PI;
            double distance = Math.Sqrt(Math.Pow(Line.pointTwo.Item1 - Line.pointOne.Item1, 2) + Math.Pow(Line.pointTwo.Item2 - Line.pointOne.Item2, 2));
            for (int i = 0; i < distance; i++)
            {
                int X = (int)(Convert.ToDouble(i) * Math.Sin(angle));
                int Y = (int)(Convert.ToDouble(i) * Math.Cos(angle));
                board.Grid[X + Line.pointOne.Item1][Y + Line.pointOne.Item2] = "██";
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
        public static Board Create(Pixel Pixel, Board Board)
        {
            Board.Grid[Pixel.Point.Item1][Pixel.Point.Item2] = "██";
            return Board;
        }
    }
    public class Text
    {
        public System.Tuple<int, int> OriginPoint;
        public string Content;
        /*public bool orientation;*/
        public Text(System.Tuple<int, int> OriginPointInput, string ContentInput/*, bool OrientationInput*/) {
            OriginPoint = OriginPointInput;
            Content = ContentInput;
            /*Orientation = OrientationInput;*/
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
            text.OriginPoint = Tuple.Create(int.Parse(tempString), text.OriginPoint.Item2);
            FailedText2:
                Console.Write("Origin Position (Y): ");
                tempString = Console.ReadLine();
            if (!int.TryParse(tempString, out tempInt))
            {
                goto FailedText2;
            }
            text.OriginPoint = Tuple.Create(text.OriginPoint.Item1, int.Parse(tempString));
            Console.Write("Content of Text: ");
            text.Content = Console.ReadLine();
            return text;
        }
        public static Board Create(Text Text, Board Board) {
            int i = 0;
            int j = 0;
            for (i = 0; i < Math.Floor((decimal)(Text.Content.Length/2)); i++) {
                if (
                    Text.OriginPoint.Item1+i < Board.Width &&
                    Text.OriginPoint.Item1+i > -1 &&
                    Text.OriginPoint.Item2 < Board.Height &&
                    Text.OriginPoint.Item2 > -1
                ) {
                    Board.Grid[Text.OriginPoint.Item1+i][Text.OriginPoint.Item2] = (string)(Text.Content[j] + "" + Text.Content[j+1]);
                }
                j+=2;
            }
            if (i*2 != Text.Content.Length) {
                if (
                    Text.OriginPoint.Item1+i < Board.Width &&
                    Text.OriginPoint.Item1+i > -1 &&
                    Text.OriginPoint.Item2 < Board.Height &&
                    Text.OriginPoint.Item2 > -1
                ) {
                    Board.Grid[Text.OriginPoint.Item1+i][Text.OriginPoint.Item2] = (string)(Text.Content[Text.Content.Length-1] + " ");
                }
            }
            return Board;
        }
    }
    /* public class Menu
    {
        public string[] Values;
        private int SelectedOption = 0;
        public System.Tuple<int, int> OriginPoint;

        public Menu(int NumberOfValues, System.Tuple<int, int> OriginPointInput) {
            Values = new string[NumberOfValues];
            OriginPoint = OriginPointInput;
        }
        public static Board Create(Menu Menu, Board Board) {
            Text TempText = new Text(Tuple.Create(0,0), "");

            for (int i = 0; i < Menu.Values.Length; i++) {
                if (Menu.SelectedOption == i) {
                    TempText.Content = "><" + Menu.Values[i];
                } else {
                    TempText.Content = "[]" + Menu.Values[i];
                }
                
                TempText.OriginPoint = Tuple.Create(Menu.OriginPoint.Item1, Menu.OriginPoint.Item2+i);
                Board = Text.Create(TempText, Board);
            }

            //Console.WriteLine(Menu.SelectedOption);

            return Board;
        }
        public Tuple<int, string> Activate(Board Board)
        {
            Board SavedBoard = Board;
            //SavedBoard.Width = Board.Width+1;

            Utilities.KeyListener listener = new Utilities.KeyListener();

            Thread thread = new Thread(() =>
            {
                listener.StartListening();
            });

            thread.Start();

            bool UpContinuousPress = false;
            bool DownContinuousPress = false;

            Text TempText = new Text(Tuple.Create(1, 1), "");

            Board = Create(this, Board);
            TempText.Content = listener.TypedTextValue; // Access TypedText using the TypedTextValue property
            Board = Text.Create(TempText, Board);
            Board.Print(Board.smoothBoard(Board), true);

            string typedText = string.Empty; // Move this declaration outside the while loop

            while (!listener.GetKeyState(Keys.Enter))
            {
                // Do something with the typed text
                typedText = listener.GetTypedText();

                if (listener.GetKeyState(Keys.Up) && (UpContinuousPress == false))
                {
                    SelectedOption++;
                    if (SelectedOption >= this.Values.Length)
                    {
                        SelectedOption = 0;
                    }

                    UpContinuousPress = true;

                }
                else if (!listener.GetKeyState(Keys.Up))
                {
                    UpContinuousPress = false;
                }


                if (listener.GetKeyState(Keys.Down) && (DownContinuousPress == false))
                {

                    SelectedOption--;
                    if (SelectedOption < 0)
                    {
                        SelectedOption = this.Values.Length - 1;
                    }

                    DownContinuousPress = true;

                }
                else if (!listener.GetKeyState(Keys.Down))
                {
                    DownContinuousPress = false;
                }

                if (listener.GetKeyState(Keys.Down) || listener.GetKeyState(Keys.Up) || TempText.Content != typedText.ToString().ToLower() + " ") {
                    Board = Create(this, Board);
                    TempText.Content = typedText.ToString().ToLower() + " ";
                    Board = Text.Create(TempText, Board);
                    Board.Print(Board.smoothBoard(Board), true);
                }

                Thread.Sleep(50); // Sleep for a short duration to avoid excessive CPU usage

            }

            listener.StopListening();
            thread.Join();

            Board = SavedBoard;

            return new Tuple<int, string>(SelectedOption, typedText); // Use the corrected 'typedText' variable
        }
    } */
    public class Board
    {
        public int Width;
        public int Height;
        public string[][] Grid;
        public Board(int WidthInput, int HeightInput) {
            Width = WidthInput;
            Height = HeightInput;
            Grid = new string[Width][];

            for (int x = 0; x < Width; x++)
            {
                Grid[x] = new string[Height];

                for (int y = 0; y < Height; y++)
                {
                    Grid[x][y] = "  ";
                }
            }
        }
        public static Board InputCreate()
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
            return new Board(temp[0], temp[1]);
        }
        public static void Print(Board board, bool ClearConsole = false)
        {
            if (ClearConsole) {
                Console.Clear();
            }

            int x = 0;
            for (int y = board.Height-1; y >= 0; y--) {
                for (x = 0; x < board.Width; x++) {
                    if (board.Grid[x][y] == null)
                    {
                        Console.Write("  ");
                    } else
                    {
                        Console.Write(board.Grid[x][y]);
                    }
                }
                Console.WriteLine("");
            }
        }
        public static Board smoothBoard(Board Board)
        {
            

            Board ReturnBoard = new Board(Board.Width, Board.Height);

            // Console.WriteLine(Board.Length);

            for (int x = 0; x < Board.Width; x++)
            {

                // Console.WriteLine("x: " + x);

                for (int y = 0; y < Board.Height; y++)
                {
                    // ObjectList.Board.Print(ReturnBoard);

                    // Console.WriteLine("y: " + y);

                    if (Board.Grid[x][y] == "██")
                    {
                        bool top = false;
                        bool left = false;
                        bool right = false;
                        bool bottom = false;

                        if (y<Board.Height-1) { top = (Board.Grid[x][y+1] == "██"); }
                        if (x>0) { left = (Board.Grid[x-1][y] == "██"); }
                        if (x<Board.Width-1) { right = (Board.Grid[x+1][y] == "██"); }
                        if (y>0) { bottom = (Board.Grid[x][y-1] == "██"); }



                        if (top && left && right && bottom) {
                            ReturnBoard.Grid[x][y] = "╬╬";
                        } else if (top && left && right && !bottom) {
                            ReturnBoard.Grid[x][y] = "╩╩";
                        } else if (top && left && !right && bottom) {
                            ReturnBoard.Grid[x][y] = "╣║";
                        } else if (top && left && !right && !bottom) {
                            ReturnBoard.Grid[x][y] = "╩╝";
                        } else if (top && !left && right && bottom) {
                            ReturnBoard.Grid[x][y] = "║╠";
                        } else if (top && !left && right && !bottom) {
                            ReturnBoard.Grid[x][y] = "╚╩";
                        } else if (top && !left && !right && bottom) {
                            ReturnBoard.Grid[x][y] = "║║";
                        } else if (top && !left && !right && !bottom) {
                            ReturnBoard.Grid[x][y] = "╚╝";
                        } else if (!top && left && right && bottom) {
                            ReturnBoard.Grid[x][y] = "╦╦";
                        } else if (!top && left && right && !bottom) {
                            ReturnBoard.Grid[x][y] = "══";
                        } else if (!top && left && !right && bottom) {
                            ReturnBoard.Grid[x][y] = "╦╗";
                        } else if (!top && left && !right && !bottom) {
                            ReturnBoard.Grid[x][y] = "==";
                        } else if (!top && !left && right && bottom) {
                            ReturnBoard.Grid[x][y] = "╔╦";
                        } else if (!top && !left && right && !bottom) {
                            ReturnBoard.Grid[x][y] = "==";
                        } else if (!top && !left && !right && bottom) {
                            ReturnBoard.Grid[x][y] = "╔╗";
                        } else if (!top && !left && !right && !bottom) {
                            ReturnBoard.Grid[x][y] = "<>";
                        }
                    }
                    else
                    {
                        ReturnBoard.Grid[x][y] = Board.Grid[x][y];
                    }
                }
            }

            return ReturnBoard;
        }
    }
    public class Utilities
    {
        /* public class KeyListener
        {
            private Dictionary<Keys, bool> KeyStates = new Dictionary<Keys, bool>();
            private Form Form;
            private StringBuilder TypedText = new StringBuilder();
            private readonly object lockObject = new object();

            public bool GetKeyState(Keys key)
            {
                lock (lockObject)
                {
                    return KeyStates.ContainsKey(key) && KeyStates[key];
                }
            }

            public string TypedTextValue // Public property to access TypedText
            {
                get
                {
                    lock (lockObject)
                    {
                        return TypedText.ToString();
                    }
                }
            }

            public string GetTypedText()
            {
                lock (lockObject)
                {
                    return TypedText.ToString();
                }
            }

            public void ClearTypedText()
            {
                lock (lockObject)
                {
                    TypedText.Clear();
                }
            }


            public void StartListening()
            {
                Form = new Form();
                Form.ShowInTaskbar = false;
                Form.FormBorderStyle = FormBorderStyle.None;
                Form.Load += (s, e) => { Form.Size = new System.Drawing.Size(0, 0); };
                Form.Show();

                Form.KeyDown += (s, e) =>
                {
                    lock (lockObject)
                    {
                        if (!KeyStates.ContainsKey(e.KeyCode))
                            KeyStates.Add(e.KeyCode, true);
                        else
                            KeyStates[e.KeyCode] = true;

                        if (!char.IsControl((char)e.KeyCode) && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                            TypedText.Append((char)e.KeyCode);
                        else if (e.KeyCode == Keys.Back && TypedText.Length > 0)
                            TypedText.Remove(TypedText.Length - 1, 1);
                    }
                };

                Form.KeyUp += (s, e) =>
                {
                    lock (lockObject)
                    {
                        if (!KeyStates.ContainsKey(e.KeyCode))
                            KeyStates.Add(e.KeyCode, false);
                        else
                            KeyStates[e.KeyCode] = false;
                    }
                };

                Application.Run(Form);
            }

            public void StopListening()
            {
                Form.Close();
                Form.Dispose();
            }
        } */
    }
}