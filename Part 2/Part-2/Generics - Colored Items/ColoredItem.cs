namespace Generics___Colored_Items;

public class ColoredItem<T>
{
    public T Item { get; }
    public ConsoleColor Colour { get; }
    
    public ColoredItem( T item, ConsoleColor colour)
    {
        Item = item;
        Colour = colour;
    }

 public void Display()
    {
        Console.ForegroundColor = Colour;
        Console.WriteLine($@"{Item} is {Colour}");
    }
}