// See https://aka.ms/new-console-template for more information

using Better_Random;

Random random = new Random();

Console.WriteLine(random.NextDouble(10));

Console.WriteLine($"Dice roll: {random.RollDie(20)}");

Console.WriteLine($"Random string stuff: {random.NextString("Red", "Green", "Blue")}");

Console.WriteLine($"Coin flip: {random.CoinFlip()}");