using System.Data;
using The_Fountain_of_Objects;

// int[,] matrix = new int[5, 5];
//
// for (int row = 0; row < matrix.GetLength(0); row++)
// {
//     for(int column = 0; column < matrix.GetLength(1); column++)
//     {
//         Console.Write(matrix[row, column] + " ");
//     }
//
//     Console.WriteLine();
// }

Map map = new Map();
map.InitializeMap(10,10);
// map[1, 1] = "X";
Console.Write("cell before = ");
map.SetCell(1, 1, "X");
Console.WriteLine($"cell after = {map.GetCell(1, 1)}");
map.DisplayMap();

Locations theFountainOfObjectsLocation = new Locations(1, 1, map);
theFountainOfObjectsLocation.LocationDiscovered();
theFountainOfObjectsLocation.SetLocation(3,1, "X");

IPlayer playerOne = new Player(0, 0, map);
playerOne.SetPlayerLocation(3, 4);
map.DisplayMap();

playerOne.Move();
map.DisplayMap();
