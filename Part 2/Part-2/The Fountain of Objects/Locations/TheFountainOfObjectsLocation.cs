namespace The_Fountain_of_Objects;

public class TheFountainOfObjectsLocation : Locations
{
    // public bool IsActivated { get; set; } = false;
    
    public TheFountainOfObjectsLocation(Map map, GameLogic gameLogic) : base(map, "The Fountain of Objects", "F", gameLogic)
    {
    }
    
    public override void AddLocationActions()
    {
        LocationDictionary.Add(1, (ActivateTheFountain, "Activate the Fountain"));
    }

    public override void LocationDiscovered()
    {
        // Console.Clear();
        // Console.ResetColor();
        // base.Map.DisplayMap();
        
        Console.ForegroundColor = ConsoleColor.Magenta;

        base.LocationDiscovered();

        
        if (!GameLogic.IsFountainActivated)
        {
            Console.WriteLine("You hear water dripping in this room.");
            Console.WriteLine("You have discovered the Lost Fountain.");
            Console.ResetColor();
            
            // base.Map.DisplayMap();

            
        }
        
    }


    public void ActivateTheFountain()
    {
        if (PlayerInteractions.GetYesOrNoResponse("Would you like to activate it?"))
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            GameLogic.IsFountainActivated = true;
            Console.WriteLine("The rejuvenating waters of the fountain flow freely again.");
            Console.WriteLine("Somewhere a door opens, You may now leave");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Map.DisplayMap();
        }
    }
}