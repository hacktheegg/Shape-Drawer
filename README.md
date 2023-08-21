# NOT UP TO DATE README.md

# Shape Drawer

## About

### Basics

This little project of mine is designed to be a scaffold for projects of mine in the future.

It has a fair amount of utilities for use and I plan on maintaining it for a fair amount of time as until i stop working with the Windows Terminal as a medium for graphics.

### Requirements

C# knowledge because it isn't a game creator, only a scaffold.

A code editor. (Mine was Visual Studio 2022, swapped to Sublime Text)

A way to compile after being built apon.

Relies on Windows Terminal/Command Prompt to work. So there's no guarantee of it working on Mac or Linux.

A way to view Data Base files for when it logs what was done. (To Make)

# How To Use

## `Board`

### About

This is what the shapes are layered on.

### Creation

```csharp
string[][] BoardVar = Board.Create(int {Width}, int {Height});
```

### Printing

```csharp
Board.Print(BoardVar);
```

### Nuances

You will need to test the limits of the `Board` yourself, as it is hard to discribe that. Other than that, `(0, 0)` is the bottom left corner of the `Board`.


## `Square`

### About

Technically a `Rectangle` maker

### Creation

```csharp
Square SquareVar = Square.Create(int {Width}, int {Height}, Tuple<int, int> Tuple.Create({x},{y}));
```

### Printing

```csharp
BoardVar = Square.Create(SquareVar, BoardVar);
```

### Nuances

Not the most optimal way done, could be better with 2 points and expanding from each point in the direction of the other point along the X and Y axis.

## `Circle`

### About

Tis `Circle`. Tis confusing, even when making.

### Creation

```csharp
Circle CircleVar = Circle.Create(int {Radius}, Tuple<int, int> Tuple.Create({x},{y}));
```

### Printing

```csharp
BoardVar = Square.Create(CircleVar, BoardVar);
```

### Nuances

If radius is too big, it might leave gaps in the circumference. This was the second most annoying to make.

## `Triangle`

### About

3 lines in-between 3 points.

### Creation

```csharp
Triangle TriangleVar = Triangle.Create(
    Tuple<int, int> Tuple.Create({Point1X},{Point1Y}),
    Tuple<int, int> Tuple.Create({Point2X},{Point2Y}),
    Tuple<int, int> Tuple.Create({Point3X},{Point3Y})
);
```

### Printing

```csharp
BoardVar = Triangle.Create(TriangleVar, BoardVar);
```

### Nuances

¯\\_(ツ)\_/¯

## `Line`

### About

The bane of my being, took the longest to make, 3 different versions were tested before this worked.

### Creation

```csharp
Line LineVar = Line.Create(
    Tuple<int, int> Tuple.Create({Point1X},{Point1Y}),
    Tuple<int, int> Tuple.Create({Point2X},{Point2Y})
);
```

### Printing

```csharp
BoardVar = Line.Create(LineVar, BoardVar);
```

### Nuances

Uses the basis of the `Circle` formula and instead of changing the angle (which is found it a way i don't want to get into), it increments the distance.

## `Pixel`

### About

Literally a single `Pixel`.

### Creation

```csharp
Pixel PixelVar = Pixel.Create(
    Tuple<int, int> Tuple.Create({PointX},{PointY})
);
```

### Printing

```csharp
BoardVar = Pixel.Create(LineVar, PixelVar);
```

### Nuances

Not tested in the slightest.

## `Text`

### About



### Creation

```
Text TextVar = Text.Create(
    Tuple<int, int> Tuple.Create({PointX},{PointY}),
    string {Content}
);
```

### Printing

```
BoardVar = Text.Create(TextVar, BoardVar);
```

### Nuances

If `Text.Content.Length` is odd, it leaves a " " after the last char.