﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ObjectList;
using SQLManagement;

class Program
{

    //public static string[][] board;

    static void Main(string[] args)
    {
        SQLManagement.values.CheckIfFile();
        int iteration = 1;
        int tempInt;


        string[][] board = Board.Create(2, 2);



        Console.WriteLine("Draw from file? Y/N");
        bool answer = Console.ReadKey(true).KeyChar.ToString().ToLower() == "y";

        if (answer)
        {

            while (iteration <= SQLManagement.values.LastValue())
            {
                Tuple<string, Tuple<int, int, int, int, int, int>, string> Row = SQLManagement.values.RetrieveRow(iteration);
                
                Console.WriteLine(Row.Item1);

                if (Row.Item1 == "Board")
                {
                    board = Board.Create(Row.Item2.Item1, Row.Item2.Item2);
                } else if (Row.Item1 == "Square")
                {
                    Square ReadFromFileSquare = new Square(Row.Item2.Item1, Row.Item2.Item2, Tuple.Create(Row.Item2.Item3, Row.Item2.Item4));
                    board = Square.Create(ReadFromFileSquare, board);
                } else if (Row.Item1 == "Circle")
                {
                    Circle ReadFromFileCircle = new Circle(Row.Item2.Item1, Tuple.Create(Row.Item2.Item2, Row.Item2.Item3));
                    board = Circle.Create(ReadFromFileCircle, board);
                } else if (Row.Item1 == "Triangle")
                {
                    Triangle ReadFromFileTriangle = new Triangle(Tuple.Create(Row.Item2.Item1, Row.Item2.Item2), Tuple.Create(Row.Item2.Item3, Row.Item2.Item4), Tuple.Create(Row.Item2.Item5, Row.Item2.Item6));
                    board = Triangle.Create(ReadFromFileTriangle, board);
                } else if (Row.Item1 == "Line")
                {
                    Line ReadFromFileLine = new Line(Tuple.Create(Row.Item2.Item1, Row.Item2.Item2), Tuple.Create(Row.Item2.Item3, Row.Item2.Item4));
                    board = Line.Create(ReadFromFileLine, board);
                } else if (Row.Item1 == "Pixel")
                {
                    Pixel ReadFromFilePixel = new Pixel(Tuple.Create(Row.Item2.Item1, Row.Item2.Item2));
                    board = Pixel.Create(ReadFromFilePixel, board);
                } else if (Row.Item1 == "Text")
                {
                    Text ReadFromFileText = new Text(Tuple.Create(Row.Item2.Item1, Row.Item2.Item2), Row.Item3);
                    board = Text.Create(ReadFromFileText, board);
                } else if (Row.Item1 == "NULL")
                {
                    break;
                }

                iteration++;
            }
        } else
        {
            //New Board
            int[] boardCreateTemp = Board.InputCreate();
            board = Board.Create(boardCreateTemp[0], boardCreateTemp[1]);
            SQLManagement.values.Add.Board(iteration, boardCreateTemp[0], boardCreateTemp[1]);
            iteration++;

            //Adds Border
            Square Border = new Square(boardCreateTemp[0], boardCreateTemp[1], Tuple.Create(0,0));
            board = Square.Create(Border, board);
            SQLManagement.values.Add.Square(iteration, Border);
            iteration++;
        }

        



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
                Console.WriteLine("5. Text");
                Console.Write("Which one? ");
                string inputInt = Console.ReadLine();
            if (!int.TryParse(inputInt, out tempInt))
            {
                Console.WriteLine("not valid input");
                goto loop;
            } else if (int.Parse(inputInt) < 1 || int.Parse(inputInt) > 5)
            {
                Console.WriteLine("not valid input");
                goto loop;
            }

            if (int.Parse(inputInt) == 1)
            {
                Square square = Square.InputCreate();

                board = Square.Create(square, board);

                SQLManagement.values.Add.Square(iteration, square);
            } else if (int.Parse(inputInt) == 2)
            {
                Circle circle = Circle.InputCreate();

                board = Circle.Create(circle, board);

                SQLManagement.values.Add.Circle(iteration, circle);
            } else if (int.Parse(inputInt) == 3)
            {
                Triangle triangle = Triangle.InputCreate();

                board = Triangle.Create(triangle, board);

                SQLManagement.values.Add.Triangle(iteration, triangle);
            } else if (int.Parse(inputInt) == 4)
            {
                Line line = Line.InputCreate();

                board = Line.Create(line, board);

                SQLManagement.values.Add.Line(iteration, line);
            } else if (int.Parse(inputInt) == 5)
            {
                Text text = Text.InputCreate();

                board = Text.Create(text, board);

                SQLManagement.values.Add.Text(iteration, text);
            }

            iteration++;
        }
    }

    static string[][] smoothBoard(string[][] Board)
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