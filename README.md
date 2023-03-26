
# Shape Drawer

## About

### Basics

This little project of mine is designed to be a scaffold for projects of mine in the future.

It has a fair amount of utilities for use and I plan on maintaining it for a fair amount of time as until i stop working with the Windows Terminal as a medium for graphics.

### Requirements

C# knowledge because it isn't a game creator, only a scaffold.

A code editor. (Mine was Visual Studio 2022)

A way to compile after being built apon.

Relies on Windows Terminal/Command Prompt to work. So there's no guarantee of it working on Mac or Linux.

A way to view Data Base files for when it logs what was done. (To Make)

# How To Use

## `Board`

### About

This is what the shapes are layered on.

### Creation

```
string[][] BoardVar = Board.Create(int {Width}, int {Height});
```

### Printing

```
Board.Print(BoardVar);
```

### Nuances

When a `Board` is created, top left is `(0,0)` and bottom right is `({Width} - 1, {Height} - 1)` I think (Even though I made this I do not know).


## `Square`

### About

Technically a `Rectangle` maker

### Creation

```
Square SquareVar = Square.Create(int {Width}, int {Height}, Tuple<int, int> Tuple.Create({x},{y}));
```

### Printing

```
BoardVar = Square.Create(SquareVar, BoardVar);
```

### Nuances

Not the most optimal way done, could be better with 2 points and expanding from each point in the direction of the other point along the X and Y axis.

## `Circle`

### About

Tis `Circle`. Tis confusing, even when making.

### Creation

```
Circle CircleVar = Circle.Create({Radius}, Tuple<int, int> Tuple.Create({x},{y}));
```

### Printing

```
BoardVar = Square.Create(CircleVar, BoardVar);
```

### Nuances

If radius is too big, it might leave gaps in the circumference. This was the second most annoying to make.

## `Triangle`

### About

3 lines in-between 3 points.

### Creation

```
Triangle TriangleVar = Triangle.Create(
    Tuple<int, int> Tuple.Create({Point1X},{Point1Y}),
    Tuple<int, int> Tuple.Create({Point2X},{Point2Y}),
    Tuple<int, int> Tuple.Create({Point3X},{Point3Y})
);
```

### Printing

```
BoardVar = Triangle.Create(TriangleVar, BoardVar);
```

### Nuances

¯\\_(ツ)_/¯

## `Line`

### About

The bane of my being, took the longest to make, 3 different versions were tested before this worked.

### Creation

```
Line LineVar = Line.Create(
    Tuple<int, int> Tuple.Create({Point1X},{Point1Y}),
    Tuple<int, int> Tuple.Create({Point2X},{Point2Y})
);
```

### Printing

```
BoardVar = Line.Create(LineVar, BoardVar);
```

### Nuances

Uses the basis of the `Circle` formula and instead of changing the angle (which is found it a way i don't want to get into), it increments the distance.