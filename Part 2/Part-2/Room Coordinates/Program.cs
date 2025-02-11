// See https://aka.ms/new-console-template for more information

using Room_Coordinates;

Coordinate coord1 = new Coordinate(2, 3);
Coordinate coord2 = new Coordinate(3, 3);
Coordinate coord3 = new Coordinate(2, 4);
Coordinate coord4 = new Coordinate(4, 3);

Console.WriteLine(coord1.IsAdjacentTo(coord1, coord2));
Console.WriteLine(coord1.IsAdjacentTo(coord1, coord3));
Console.WriteLine(coord1.IsAdjacentTo(coord1, coord4));