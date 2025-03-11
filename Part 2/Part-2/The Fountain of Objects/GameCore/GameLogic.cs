using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class GameLogic
{
    private readonly IPlayer _player;
    private readonly Map _map;
    private readonly List<Locations> _locations;
    public bool FountainHasBeenDiscovered { get; set; }

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

    // logic for if player moves into cell and discovers a location - location is discovered, show player icon, colour cell? 
    public void CheckPlayerLocation()
    {
        Console.WriteLine("DEBUG: CheckPlayerLocation() called");
        var playerLocation = _player.GetPlayerLocation();
        foreach (var location in _locations)
        {
            var locationLocation = location.GetLocation();
            if (playerLocation.Row == locationLocation.Row && playerLocation.Column == locationLocation.Column)
            {
                Console.Clear();
                _map.DisplayMap();
                location.LocationDiscovered();
                _map.SetCell(playerLocation.Row, playerLocation.Column, _player.GetPlayerIcon());
                Console.WriteLine($"You are in { location.LocationName }");
            }
            else
            {
                _map.SetCell(locationLocation.Row, locationLocation.Column, location.GetLocationSymbol());
            }
    
            Console.WriteLine($"DEBUG: Location -> {location.LocationName} at ({location.GetLocation().Row}, {location.GetLocation().Column})");
        }
    }
    
    // public List<Locations> CheckPlayerLocation()
    // {
    //     var playerLocation = _player.GetPlayerLocation();
    //     var discoveredLocations = new List<Locations>();
    //
    //     foreach (var location in _locations)
    //     {
    //         var locationLocation = location.GetLocation();
    //         if (playerLocation.Row == locationLocation.Row && playerLocation.Column == locationLocation.Column)
    //         {
    //             discoveredLocations.Add(location);
    //             _map.SetCell(playerLocation.Row, playerLocation.Column, _player.GetPlayerIcon());
    //         }
    //         else
    //         {
    //             _map.SetCell(locationLocation.Row, locationLocation.Column, location.GetLocationSymbol());
    //         }
    //     }
    //
    //     return discoveredLocations;
    // }


    // move player move logic here?
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
            // _player.SetPlayerLocation(playerLocation.Row--, playerLocation.Column);
            newRow--;
        }
        else if (direction == MovementDirection.EAST)
        {
            // _player.SetPlayerLocation(playerLocation.Row, playerLocation.Column++);
            newColumn++;
        }
        else if (direction == MovementDirection.SOUTH)
        {
            // _player.SetPlayerLocation(playerLocation.Row++, playerLocation.Column);
            newRow++;
        }
        else if (direction == MovementDirection.WEST)
        {
            
            // _player.SetPlayerLocation(playerLocation.Row, playerLocation.Column--);
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
            
            // _map.SetCell(previousRow, previousColumn, " ");
            
            string previousLocationSymbol = _locations
                .FirstOrDefault( locations => locations.GetLocation().Row == previousRow && locations.GetLocation().Column == previousColumn)
                ?.GetLocationSymbol() ?? " ";
            
            _map.SetCell(previousRow, previousColumn, previousLocationSymbol);
            
            _player.SetPlayerLocation(newRow, newColumn);
        }
        
        Console.WriteLine("DEBUG: Calling CheckPlayerLocation()");
        CheckPlayerLocation();
    }
    
    // logic for if fountain is discovered and moved back to entrance
    
}