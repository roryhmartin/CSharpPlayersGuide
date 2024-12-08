Console.Title = "The Defense of Consolas";
Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;

Console.Write("Target row: ");
int targetRow = Convert.ToInt32(Console.ReadLine());

Console.Write("Target column: ");
int targetColumn = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"{targetRow}, {targetColumn - 1}");
Console.WriteLine($"{targetColumn}, {targetRow + 1}");
Console.WriteLine($"{targetRow}, {targetColumn + 1}");
Console.WriteLine($"{targetColumn}, {targetRow - 1}");

Console.Beep();

