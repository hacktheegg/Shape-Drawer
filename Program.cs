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
        /*Triangle triangle = new Triangle(
            Tuple.Create(int.Parse(SizeOfBoardWidth) / 2, 1), 
            Tuple.Create(1, int.Parse(SizeOfBoardHeight) - 2), 
            Tuple.Create(int.Parse(SizeOfBoardWidth) - 2, int.Parse(SizeOfBoardHeight) - 2)
        );
        board = Triangle.Create(triangle, board);*/

        Line line = new Line(
            Tuple.Create(15, 1),
            Tuple.Create(15, 28)
        );
        board = Line.Create(line, board);



        //board = smoothBoard(board);
        


        Shape_Drawer.Board.Print(board);

        Console.ReadKey(true);
    }

    static string[][] smoothBoard(string[][] board)
    {
        string[][] returnBoard = new string[board.Length][];

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {

            }
        }


        return board;
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