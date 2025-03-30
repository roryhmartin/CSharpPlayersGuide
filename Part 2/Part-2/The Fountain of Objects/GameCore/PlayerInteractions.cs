using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class PlayerInteractions
{

    private GameLogic _gameLogic;
    private Map _map;
    public PlayerInteractions(GameLogic gameLogic, Map map)
    {
        _gameLogic = gameLogic;
        _map = map;
    }
    public static bool GetYesOrNoResponse(string question)
    {
        while (true)
        {
            Console.WriteLine(question);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            
            Console.ResetColor();

            Console.Write("Input: ");
            string input = Console.ReadLine()?.Trim().ToLower();
            
            if (input == "yes" || input == "1" || input == "y")
            {

                return true;
            }
            if (input == "no" || input == "2" || input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'Yes', 'No', '1', or '2'.");
            }
            Console.ResetColor();
        }
        
    }

    public static MovementDirection GetPlayerDirection()
    {
        Console.WriteLine("Choose a direction:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. North");
        Console.WriteLine("2. East");
        Console.WriteLine("3. South");
        Console.WriteLine("4. West");
        Console.ResetColor();

        Console.Write("Input: ");
        string input = Console.ReadLine()?.Trim().ToLower();
        Console.WriteLine($"Your input: { input }");
        
        if (input == "1" || input == "north" || input == "n") return MovementDirection.NORTH;
        if (input == "2" || input == "east" || input == "e") return MovementDirection.EAST;
        if (input == "3" || input == "south" || input == "s") return MovementDirection.SOUTH;
        if (input == "4" || input == "west" || input == "w") return MovementDirection.WEST;
        
        return MovementDirection.INVALID;

    }

    public static PlayerActions GetPlayerCommandInput()
    {
        Console.WriteLine("Enter a command: (M: Move, A: Actions, etc.): ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("M: Move");
        Console.WriteLine("A: Attack");
        Console.WriteLine("E: Environments Panel");
        Console.ResetColor();
        string command = Console.ReadLine().ToLower().Trim();

        if (command == "move" || command == "m")
        {
            return PlayerActions.MOVE;
        }
        
        if (command == "environments" || command == "e")
        {
            return PlayerActions.ACTIONS_PANEL;
        }

        if (command == "attack" || command == "a")
        {
            return PlayerActions.ATTACK;
        }

        return PlayerActions.DEFAULT;
    }
}