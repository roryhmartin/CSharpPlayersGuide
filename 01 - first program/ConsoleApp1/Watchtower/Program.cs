Console.Write("Enter X: ");
int X = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter Y: ");
int Y = Convert.ToInt32(Console.ReadLine());

if (X < 0 && Y > 0)
{
    Console.WriteLine("NW");
} 
else if (X == 0 && Y > 0)
{
    Console.WriteLine("N");    
}
else if (X > 0 && Y > 0)
{
    Console.WriteLine("NE");
}
else if (X < 0 && Y == 0)
{
    Console.WriteLine("W");
}
else if (X == 0 && Y == 0)
{
    Console.WriteLine("!");
}
else if (X > 0 && Y == 0)
{
    Console.WriteLine("E");
}
else if (X < 0 && Y < 0)
{
    Console.WriteLine("SW");
}
else if (X == 0 && Y < 0)
{
    Console.WriteLine("S");
}
else
{
    Console.WriteLine("SE");
}