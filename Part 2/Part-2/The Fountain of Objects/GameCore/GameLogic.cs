using System.Runtime.CompilerServices;
using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class GameLogic
{
    private readonly IPlayer _player;
    private readonly Map _map;
    private readonly List<Locations> _locations;
    public bool FountainHasBeenDiscovered { get; set; }
    public bool InCombat { get; set; } = false;

    public static bool IsFountainActivated { get; set; } = false;

    public GameLogic(IPlayer player, Map map)
    {
        _player = player;
        _map = map;
        _locations = new List<Locations>();
        Console.ResetColor();
    }
    
    

    public void AddLocationToGameLogic(Locations location)
    {
        _locations.Add(location);
    }

    public void CheckPlayerLocation()
    {
        var playerLocation = _player.GetPlayerLocation();
        foreach (var location in _locations)
        {
            var locationLocation = location.GetLocation();
            if (playerLocation.Row == locationLocation.Row && playerLocation.Column == locationLocation.Column)
            {
                Console.Clear();
                location.LocationDiscovered();
                _map.SetCell(playerLocation.Row, playerLocation.Column, _player.GetPlayerIcon());
                _map.DisplayMap();
                Console.WriteLine($"You are in { location.LocationName }");
            }
            else
            {
                _map.SetCell(locationLocation.Row, locationLocation.Column, location.GetLocationSymbol());
            }
        }
    }

    public void MovePlayer()
    {
        MovementDirection direction = PlayerInteractions.GetPlayerDirection();
        
        GetLocation playerLocation = _player.GetPlayerLocation();

        int previousRow = playerLocation.Row;
        int previousColumn = playerLocation.Column;

        int newRow = playerLocation.Row;
        int newColumn = playerLocation.Column;

        if (direction == MovementDirection.NORTH)
        {
            newRow--;
        }
        else if (direction == MovementDirection.EAST)
        {
            newColumn++;
        }
        else if (direction == MovementDirection.SOUTH)
        {
            newRow++;
        }
        else if (direction == MovementDirection.WEST)
        {
            
            newColumn--;
        }
        if (direction == MovementDirection.INVALID)
        {
            Console.WriteLine("Invalid direction. Please try again.");
            return;
        }

        if (!_player.IsValidMove(newRow, newColumn))
        {
            playerLocation.Row = previousRow;
            playerLocation.Column = previousColumn;
        }
        else
        {
            string previousLocationSymbol = _locations
                .FirstOrDefault( locations => locations.GetLocation().Row == previousRow && locations.GetLocation().Column == previousColumn)
                ?.GetLocationSymbol() ?? " ";
            
            _map.SetCell(previousRow, previousColumn, previousLocationSymbol);
            
            _player.SetPlayerLocation(newRow, newColumn);
        }
        
        // CheckPlayerLocation();
    }


    public void GetPlayerCommand()
    {
         PlayerActions userInput = PlayerInteractions.GetPlayerCommandInput();
         
            switch (userInput)
            {
                case PlayerActions.MOVE:
                    MovePlayer();
                    break;
                case PlayerActions.ACTIONS_PANEL:
                    GetActions();
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
   
        
    }
    
    public void GetActions()
    {
        if (!InCombat) 
        {
            LocationActions();
        }
        
        
    }

    private void LocationActions()
    {
        foreach (var location in _locations)
        {
            if (location.GetLocation().Row == _player.GetPlayerLocation().Row && location.GetLocation().Column == _player.GetPlayerLocation().Column)
            {
                Console.Clear();
                _map.DisplayMap();
                List<string> actions = location.GetAvailableActions();
                
                if (actions.Count == 0)
                {
                    Console.WriteLine("No actions available at this location.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Available actions:");
                for (int i = 0; i < actions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {actions[i]}");
                }

                string userInput = Console.ReadLine()?.ToLower().Trim();

                if (userInput != null)
                {
                    location.ExecuteAction(userInput);
                }
            }
        } 
    }

}