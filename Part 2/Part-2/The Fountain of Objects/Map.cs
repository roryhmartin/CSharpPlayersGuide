namespace The_Fountain_of_Objects;

public class Map
{
    private static string[,] map;
    
    public void InitializeMap(int rows, int columns)
    {
        if(map != null)
        {
            throw new Exception("Map has already been initialized");
        }
        map = new string[rows, columns];
    }

    public static void ResizeMap(int newRows, int newColumns)
    {
        string[,] newMap = new string[newRows, newColumns];
        
        map = newMap;
    }
    
    public static (int rows, int columns) GetMapSize()
    {
        return (map.GetLength(0), map.GetLength(1));
    }

    public void AltGetMapSize()
    {
        Console.WriteLine("Rows: " + map.GetLength(0));
        Console.WriteLine("Columns: " + map.GetLength(1));
    }

    public void DisplayMap()
    {
        for (int row = 0; row < map.GetLength(0); row++)
        {
            Console.Write("-");
            for (int column = 0; column < map.GetLength(1); column++)
            {
                Console.Write(map[row, column] + "|");
            }
            Console.WriteLine();
        }
    }

}