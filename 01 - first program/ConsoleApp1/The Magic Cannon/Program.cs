for (int i = 0; i <= 100; i++)
{
    if (i % 3 == 0)
    {
        Console.ForegroundColor =  ConsoleColor.Red;
        Console.WriteLine("Fire");
        continue;
    }
    else if (i % 5 == 0) 
    {
        Console.ForegroundColor =  ConsoleColor.Yellow;
        Console.WriteLine("Electric");
        continue;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(i);
    }
}