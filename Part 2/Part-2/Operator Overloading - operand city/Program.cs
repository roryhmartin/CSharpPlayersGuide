using System.Globalization;
using Operator_Overloading___operand_city;

BlockCoordinate BC = new BlockCoordinate(2, 3);
BlockOffset BO = new BlockOffset(1, 1);

BlockCoordinate test = BC + BO;


Console.WriteLine(test);
Console.WriteLine(new BlockCoordinate(4, 3) + Direction.East);
Console.WriteLine(test[1]);

