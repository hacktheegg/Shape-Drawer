using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shape_Drawer;

class Program
{
    
    public static Array[] Board = Array.Empty<Array>();
    
    static void Main(string[] args)
    {
        int tempInt;

        FailedIntInput:
            Console.Write("Size of board (square): ");
            string SizeOfBoardInput = Console.ReadLine();

        if (!int.TryParse(SizeOfBoardInput, out tempInt))
        {
            goto FailedIntInput;
        }

        




        while (true)
        {

        }
    }
}



//Square mySquare = new Square(5,8,Tuple.Create<int,int> (1,1));
/*public Square(int x, int y, Tuple<int,int> mytup)
{
    width = x;
    height = y;
    originPoint = mytup;
}*/