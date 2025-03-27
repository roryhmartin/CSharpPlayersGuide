namespace The_Fountain_of_Objects;

public class EntranceLocation : Locations
{
    public EntranceLocation(Map map, GameLogic gameLogic) : base(map, "Entrance", "E", gameLogic)
    {
    }
    
    public override void AddLocationActions()
    {
        LocationDictionary.Add(1, (LeaveDungeon, "Leave Dungeon"));
    }

    public override void LocationDiscovered()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        base.LocationDiscovered();
        string playerChoice;

        LocationDescription();
        LeaveDungeon();
        Console.ResetColor();
    }
    
    public void LeaveDungeon()
    {
        if (GameLogic.IsFountainActivated)
        {
            Console.WriteLine("Light pours through the open doors of the Entrance to the dungeon");
            if (PlayerInteractions.GetYesOrNoResponse("The Fountain of Objects is Active! Do you want to leave?"))
            {
                Console.WriteLine("You have successfully left the dungeon!");
                Environment.Exit(0);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You find yourself at the entrance to the dungeon, the way out is sealed.");
            Console.WriteLine("You must find the Fountain of Objects to leave.");
            Console.ResetColor();

        }
    }
}