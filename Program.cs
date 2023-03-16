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
        string[][] board = Shape_Drawer.Board.Create(int.Parse(SizeOfBoardWidth), int.Parse(SizeOfBoardHeight));


        //Adds Border
        Square Border = new Square(int.Parse(SizeOfBoardWidth), int.Parse(SizeOfBoardHeight), Tuple.Create(0,0));
        board = Square.Create(Border, board);

        //Shape 1
        Triangle triangle = new Triangle(
            Tuple.Create(int.Parse(SizeOfBoardWidth) / 2, 1), 
            Tuple.Create(1, int.Parse(SizeOfBoardHeight) - 2), 
            Tuple.Create(int.Parse(SizeOfBoardWidth) - 2, int.Parse(SizeOfBoardHeight) - 2)
        );
        board = Triangle.Create(triangle, board);

        board = smoothBoard(board);

        Board.Print(board);

        Console.ReadKey(true);
    }

    static string[][] smoothBoard(string[][] board)
    {
        string[][] returnBoard = new string[board.Length][];


        
        for (int x = 0; x < board.Length; x++)
        {
            for (int y = 0; y < board[x].Length; y++)
            {
                bool[] positions =
                    { false,
                false,      false,
                    false };

                if (board[y][x] == "██")
                {
                    if (y > 0) {
                        if (board[y - 1][x] == "██")
                        { positions[0] = true; }
                    }
                    if (x > 0) {
                        if (board[y][x - 1] == "██")
                        { positions[1] = true; }
                    }
                    if (y < board[x].Length - 1) {
                        if (board[y][x + 1] == "██")
                        { positions[2] = true; }
                    }
                    if (x < board.Length - 1) {
                        if (board[y + 1][x] == "██")
                        { positions[3] = true; }
                    }


                    if (positions[0])
                    {   if (positions[1])
                        {   if (positions[2])
                            {   if (positions[3])
                                {   returnBoard[y][x] = "╡╞";
                                } else {
                                    returnBoard[y][x] = "╧╧";
                                }
                            } else {
                                if (positions[3])
                                {   returnBoard[y][x] = "╡│";
                                } else {
                                    returnBoard[y][x] = "╧╛";
                                }
                            }
                        } else {
                            if (positions[2])
                            {   if (positions[3])
                                {   returnBoard[y][x] = "│╞";
                                } else {
                                    returnBoard[y][x] = "╘╧";
                                }
                            } else {
                                if (positions[3])
                                {   returnBoard[y][x] = "││";
                                } else {
                                    returnBoard[y][x] = "╚╝";
                                }
                            }
                        }
                    } else {
                        if (positions[1])
                        {   if (positions[2])
                            {   if (positions[3])
                                {   returnBoard[y][x] = "╤╤";
                                } else {
                                    returnBoard[y][x] = "══";
                                }
                            } else {
                                if (positions[3])
                                {   returnBoard[y][x] = "╤╕";
                                } else {
                                    returnBoard[y][x] = "╡│";
                                }
                            }
                        } else {
                            if (positions[2])
                            {   if (positions[3])
                                {   returnBoard[y][x] = "╒╤";
                                } else {
                                    returnBoard[y][x] = "│╞";
                                }
                            } else {
                                if (positions[3])
                                {   returnBoard[y][x] = "╔╗";
                                } else {
                                    returnBoard[y][x] = "◖◗";
                                }
                            }
                        }
                    }


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



//╔╗
//╚╝

//╒╤ ══ ╤╕
//││ ╡╞ ││
//╘╧ ══ ╧╛

//╤╤╡│
//│╞╧╧

//◖◗