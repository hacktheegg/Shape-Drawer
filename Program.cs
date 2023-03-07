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


        string[][] board = Shape_Drawer.Board.Create(int.Parse(SizeOfBoardWidth), int.Parse(SizeOfBoardHeight));



        Square Border = new Square();
        Border.width = int.Parse(SizeOfBoardWidth);
        Border.height = int.Parse(SizeOfBoardHeight);
        Border.originPoint = Tuple.Create(0,0);
        board = Square.Create(Border, board);



        Circle circle = new Circle();
        circle.radius = 20;
        circle.originPoint = Tuple.Create(2,2);
        
        board = Circle.Create(circle, board);


        
        
        Shape_Drawer.Board.Print(board);

        Console.ReadKey(true);
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