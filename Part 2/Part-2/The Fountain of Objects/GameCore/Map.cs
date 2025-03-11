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
    
    public (int rows, int columns) GetMapSize()
    {
        return (map.GetLength(0), map.GetLength(1));
    }

    public void AltGetMapSize()
    {
        Console.WriteLine("Map Size:");
        Console.WriteLine("Rows: " + map.GetLength(0));
        Console.WriteLine("Columns: " + map.GetLength(1));
    }

    public void DisplayMap()
    {
        int rows = map.GetLength(0);
        int columns = map.GetLength(1);
        
        Console.Write('+');
        
        for(int row = 0; row< rows; row++)
        {
            Console.Write("---+");
        }
        Console.WriteLine();
        
        for (int row = 0; row < rows; row++)
        {
            Console.Write("|");
            
            for (int column = 0; column < columns; column++)
            {
                string cell = map[row, column] ?? " ";
                Console.Write($" {cell} |");
            }

            Console.WriteLine();

            Console.Write("+");
            for (int i = 0; i < columns; i++)
            {
                Console.Write("---+");
            }

            Console.WriteLine();
        }
    }

    public string GetCell(int row, int column)
    {
        return map[row, column];
    }
    
    public void SetCell(int row, int column, string value)
    {
        map[row, column] = value;
    }
}