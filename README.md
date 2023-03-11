
# Shape Drawer

## Basics

### About

This little project of mine is designed to be built on from so you can easily make menu's over it

### Requirements

You need to have some knowledge of C# and have some way to compile or run it

I personally used Visual Studio 2022 to make it

Relies on the Terminal on windows to work

## How To Use

Create a new `board`

```
string[][] boardVar = Shape_Drawer.Board.Create({Width}, {Height});
```

Draw `Shape` on `board`

```
{Shape} myVar = new {Shape}({ShapeProperties});
board = {Shape}.Create(myVar, boardVar);
```

Update/Print `board`

```
Shape_Drawer.Board.Print(boardVar);
```

## Objects and their Parameters

### Square

```
Square(int widthInput, int heightInput, Tuple<int, int> originPointInput)
```

### Circle

```
Circle(int radiusInput, Tuple<int, int> originPointInput)
```

### Triangle

```
Triangle(Tuple<int, int> pnt1, Tuple<int, int> pnt2, Tuple<int, int> pnt3)
```

### Line

```
Line(Tuple<int, int> pnt1, Tuple<int, int> pnt2)
```