namespace The_Properties_Of_Arrows;

public class Program
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Welcome to the Arrow Shop! What arrow would you like to create?");
        Console.WriteLine("Enter a number to select an arrow: ");
        Console.WriteLine("1. Elite Arrow");
        Console.WriteLine("2. Beginner Arrow");
        Console.WriteLine("3. Marksman Arrow");
        Console.WriteLine("4. Custom Arrow");
        string userSelection = Console.ReadLine();

    
        if (userSelection == "1")
        {
            Arrow eliteArrow = Arrow.CreateEliteArrow();
            Console.WriteLine("Elite Arrow Created!");
            Console.WriteLine($"Arrow Head: {eliteArrow.ArrowHead}");
            Console.WriteLine($"Fletching: {eliteArrow.Fletching}");
            Console.WriteLine($"Arrow Length: {eliteArrow.Length}");
        }
        else if (userSelection == "2")
        {
            Arrow beginnerArrow = Arrow.CreateBeginnerArrow();
            Console.WriteLine("Beginner Arrow Created!");
            Console.WriteLine($"Arrow Head: {beginnerArrow.ArrowHead}");
            Console.WriteLine($"Fletching: {beginnerArrow.Fletching}");
            Console.WriteLine($"Arrow Length: {beginnerArrow.Length}");
        }
        else if (userSelection == "3")
        {
            Arrow marksmanArrow = Arrow.CreateMarksmanArrow();
            Console.WriteLine("Marksman Arrow Created!");
            Console.WriteLine($"Arrow Head: {marksmanArrow.ArrowHead}");
            Console.WriteLine($"Fletching: {marksmanArrow.Fletching}");
            Console.WriteLine($"Arrow Length: {marksmanArrow.Length}");
        }
        else if (userSelection == "4")
        {
            Arrow myArrow = CreateArrow();
            Console.WriteLine("Custom Arrow Created!");
            Console.WriteLine($"Arrow Head: {myArrow.ArrowHead}");
            Console.WriteLine($"Fletching: {myArrow.Fletching}");
            Console.WriteLine($"Arrow Length: {myArrow.Length}");
            Console.WriteLine($"The total cost of this arrow is £{myArrow.GetCost()}");
        }
        
        static Arrow CreateArrow()
        {
            ArrowHead arrowHead =  SelectArrowHead();
            Fletching fletching = SelectFletching();
            float length = GetLength();
            return new Arrow(arrowHead, fletching, length);
        }
    }

     static ArrowHead SelectArrowHead()
    {
        Console.WriteLine("Please select an arrow head: Steel, Wood, Obsidian");
        string arrowhead = Console.ReadLine();
        return arrowhead switch
        {
            "Steel" => ArrowHead.Steel,
            "Wood" => ArrowHead.Wood,
            "Obsidian" => ArrowHead.Obsidian
        };
    }

    static Fletching SelectFletching()
    {
        Console.WriteLine("Please select a fletching: Plastic, Feather, GooseFeathers");
        string fletching = Console.ReadLine();
        return fletching switch
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