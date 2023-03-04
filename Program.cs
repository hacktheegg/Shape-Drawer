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


        string[][] board = Shape_Drawer.Board.Create(int.Parse(SizeOfBoardInput));


        Square square = new Square();
        square.width = 5;
        square.height = 5;
        square.originPoint = Tuple.Create(1,1);

        
        //string[][] board = new string[5][];
        //board[0] = new string[] { "1a", "1b", "1c", "1d", "1e" };
        //board[1] = new string[] { "2a", "2b", "2c", "2d", "2e" };
        //board[2] = new string[] { "3a", "3b", "3c", "3d", "3e" };
        //board[3] = new string[] { "4a", "4b", "4c", "4d", "4e" };
        //board[4] = new string[] { "5a", "5b", "5c", "5d", "5e" };



        board = Square.Create(square, board);
         
        Shape_Drawer.Board.Print(board);

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