using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shape_Drawer;

class Program
{

    //public static string[][] board;

    static void Main(string[] args)
    {
        int tempInt;

        FailedInputBoardSize:
            Console.Write("Size of board (square): ");
            string SizeOfBoardInput = Console.ReadLine();

        if (!int.TryParse(SizeOfBoardInput, out tempInt))
        { 
            goto FailedInputBoardSize; 
        }


        //string[][] board = Shape_Drawer.Board.BoardCreate(int.Parse(SizeOfBoardInput));


        //Square square = new Square();
        //square.width = 4;
        //square.height = 3;
        //square.originPoint = Tuple.Create(1,1);

        //board = Square.SquareDrawer(square, board);

        string[][] boardABC = new string[][]
        { 
            { "1a", "1b", "1c", "1d", "1e" },
            { "2a", "2b", "2c", "2d", "2e" },
            { "3a", "3b", "3c", "3d", "3e" },
            { "4a", "4b", "4c", "4d", "4e" },
            { "5a", "5b", "5c", "5d", "5e" }
        };

         
        Shape_Drawer.Board.PrintBoard(boardABC);

        Console.ReadKey(true);

        /*while (true)
        {
            
        }*/
    }
}



//Square mySquare = new Square(5,8,Tuple.Create<int,int> (1,1));
/*public Square(int x, int y, Tuple<int,int> mytup)
{
    width = x;
    height = y;
    originPoint = mytup;
}*/