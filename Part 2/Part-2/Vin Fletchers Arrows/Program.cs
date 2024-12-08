namespace Vin_Fletchers_Arrows;

public class Program
{
    public static void Main(string[] args)
    {
        // method to call all methods
        // method to select arrow head
        // method to select fletching
        // method to select arrow length
        // return arrow
        
        Arrow myArrow = CreateArrow();
        
        static Arrow CreateArrow()
        {
            ArrowHead arrowHead =  SelectArrowHead();
            Fletching fletching = SelectFletching();
            float length = GetLength();
            return new Arrow(arrowHead, fletching, length);
        }
        Console.WriteLine($"Arrow Head: {myArrow.GetArrowHead()}");
        Console.WriteLine($"Fletching: {myArrow.GetFletching()}");
        Console.WriteLine($"Arrow Length: {myArrow.GetLength()}");
        Console.WriteLine($"The total cost of this arrow is £{myArrow.GetCost()}");
        Console.WriteLine("Setting the arrow head to Wood");
        myArrow.SetArrowHead(ArrowHead.Wood);
        Console.WriteLine($"My arrowhead is now: {myArrow.GetArrowHead()}");
    }

     static ArrowHead SelectArrowHead()
    {
        Console.WriteLine("Please select an arrow head: Steel, Wood, Obsidian");
        string _arrowhead = Console.ReadLine();
        return _arrowhead switch
        {
            "Steel" => ArrowHead.Steel,
            "Wood" => ArrowHead.Wood,
            "Obsidian" => ArrowHead.Obsidian
        };
    }

    static Fletching SelectFletching()
    {
        Console.WriteLine("Please select a fletching: Plastic, Feather, GooseFeathers");
        string _fletching = Console.ReadLine();
        return _fletching switch
        {
            "Plastic" => Fletching.Plastic,
            "Feather" => Fletching.Feather,
            "GooseFeathers" => Fletching.GooseFeathers
        };
    }
    
    static float GetLength()
    {
        float length = 0;
        while (length < 60 || length > 100)
        {
            Console.WriteLine("Please enter a shaft length between 60cm and 100cm");
            string input = Console.ReadLine();
            
            if (float.TryParse(input, out length))
            {
                return length;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number");
            }
        }
        return length;
    }
}