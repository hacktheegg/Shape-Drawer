using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Shape_Drawer;

class Program
{

    //public static string[][] board;

    static void Main(string[] args)
    {
        //SQLManagement.AddShape(0,7);

        int tempInt;

        FailedInputBoardWidth:
            Console.Write("Size of board (Width): ");
            string SizeOfBoardWidth = Console.ReadLine();

        if (!int.TryParse(SizeOfBoardWidth, out tempInt))
        { 
            goto FailedInputBoardWidth; 
        }

        FailedInputBoardHeight:
            Console.Write("Size of board (Height): ");
            string SizeOfBoardHeight = Console.ReadLine();

        if (!int.TryParse(SizeOfBoardHeight, out tempInt))
        {
            goto FailedInputBoardHeight;
        }



        //New Board
        string[][] board = Board.Create(int.Parse(SizeOfBoardWidth), int.Parse(SizeOfBoardHeight));

        //Adds Border
        Square Border = new Square(int.Parse(SizeOfBoardWidth), int.Parse(SizeOfBoardHeight), Tuple.Create(0,0));
        board = Square.Create(Border, board);



        int iteration = 1;

        while (true)
        {
            Board.Print(smoothBoard(board));
            Console.ReadKey(true);

            loop:
                Console.WriteLine("Which Shape would you like like to Draw?");
                Console.WriteLine("1. Square");
                Console.WriteLine("2. Circle");
                Console.WriteLine("3. Triangle");
                Console.WriteLine("4. Line");
                Console.Write("Which one? ");
                string inputInt = Console.ReadLine();
            if (!int.TryParse(SizeOfBoardHeight, out tempInt))
            {
                Console.WriteLine("not valid input");
                goto loop;
            } else if (int.Parse(inputInt) < 1 || int.Parse(inputInt) > 4)
            {
                Console.WriteLine("not valid input");
                goto loop;
            }

            if (int.Parse(inputInt) == 1)
            {
                Square square = Square.InputCreate();

                board = Square.Create(square, board);

                SQLManagement.Add.Square(iteration, square);
            } else if (int.Parse(inputInt) == 2)
            {
                board = Circle.Create(Circle.InputCreate(), board);
            } else if (int.Parse(inputInt) == 3)
            {
                board = Triangle.Create(Triangle.InputCreate(), board);
            } else if (int.Parse(inputInt) == 4)
            {
                board = Line.Create(Line.InputCreate(), board);
            }

            iteration++;
        }
    }

    static string[][] smoothBoard(string[][] board)
    {
        string[][] returnBoard = new string[board.Length][];

        for (int y = 0; y < board.Length; y++)
        {
            returnBoard[y] = new string[board[y].Length];

            for (int x = 0; x < board[y].Length; x++)
            {
                if (board[y][x] == "██")
                {
                    bool top = (y > 0) && (board[y - 1][x] == "██");
                    bool left = (x > 0) && (board[y][x - 1] == "██");
                    bool right = (x < board[y].Length - 1) && (board[y][x + 1] == "██");
                    bool bottom = (y < board.Length - 1) && (board[y + 1][x] == "██");

                    switch (top, left, right, bottom)
                    {
                        case (false, false, false, false):
                            returnBoard[y][x] = "┃┃";
                            break;
                        case (false, false, false, true):
                            returnBoard[y][x] = "╔╗";
                            break;
                        case (false, false, true, false):
                            returnBoard[y][x] = "==";
                            break;
                        case (false, false, true, true):
                            returnBoard[y][x] = "╔╦";
                            break;
                        case (false, true, false, false):
                            returnBoard[y][x] = "==";
                            break;
                        case (false, true, false, true):
                            returnBoard[y][x] = "╦╗";
                            break;
                        case (false, true, true, false):
                            returnBoard[y][x] = "══";
                            break;
                        case (false, true, true, true):
                            returnBoard[y][x] = "╦╦";
                            break;
                        case (true, false, false, false):
                            returnBoard[y][x] = "╚╝";
                            break;
                        case (true, false, false, true):
                            returnBoard[y][x] = "║║";
                            break;
                        case (true, false, true, false):
                            returnBoard[y][x] = "╚╩";
                            break;
                        case (true, false, true, true):
                            returnBoard[y][x] = "║╠";
                            break;
                        case (true, true, false, false):
                            returnBoard[y][x] = "╩╝";
                            break;
                        case (true, true, false, true):
                            returnBoard[y][x] = "╣║";
                            break;
                        case (true, true, true, false):
                            returnBoard[y][x] = "╩╩";
                            break;
                        case (true, true, true, true):
                            returnBoard[y][x] = "╬╬";
                            break;
                    }
                }
                else
                {
                    returnBoard[y][x] = board[y][x];
                }
            }
        }

        return returnBoard;
    }
}



//string[][] board = new string[5][];
//board[0] = new string[] { "1a", "1b", "1c", "1d", "1e" };
//board[1] = new string[] { "2a", "2b", "2c", "2d", "2e" };
//board[2] = new string[] { "3a", "3b", "3c", "3d", "3e" };
//board[3] = new string[] { "4a", "4b", "4c", "4d", "4e" };
//board[4] = new string[] { "5a", "5b", "5c", "5d", "5e" };

//Square mySquare = new Square(5,8,Tuple.Create<int,int> (1,1));
/*public Square(int x, int y, Tuple<int,int> mytup)
{
    width = x;
    height = y;
    originPoint = mytup;
}*/