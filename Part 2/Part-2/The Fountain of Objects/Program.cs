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
map.InitializeMap(5,5);
map.DisplayMap();