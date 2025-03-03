namespace The_Fountain_of_Objects;

public class GameLogic
{
    private readonly IPlayer _player;
    private readonly Map _map;
    private readonly List<Locations> _locations;
    private bool _fountainHasBeenDiscovered = false;

    public GameLogic(IPlayer player, Map map)
    {
        _player = player;
        _map = map;
        _locations = new List<Locations>();
    }
    
    

    public void AddLocationToGameLogic(Locations location)
    {
        _locations.Add(location);
    }

    // logic for if player moves into cell and discovers a location - location is discovered, show player icon, colour cell? 
    public void CheckPlayerLocation()
    {
        var playerLocation = _player.GetPlayerLocation();

        foreach (var location in _locations)
        {
            var locationLocation = location.GetLocation();

            if (playerLocation.Row == locationLocation.Row && playerLocation.Column == locationLocation.Column)
            {
                location.LocationDiscovered();
                
                Console.WriteLine($"You are in { location.LocationName }");
                _map.SetCell(playerLocation.Row, playerLocation.Column, _player.GetPlayerIcon());

                if (location.LocationName == "The Fountain of Objects")
                {
                    _fountainHasBeenDiscovered = true;
                }

                if (_fountainHasBeenDiscovered && location.LocationName == "Entrance")
                {
                    Console.WriteLine("You may leave the dungeon, are you ready?");
                }

            }
            else
            {
                _map.SetCell(locationLocation.Row, locationLocation.Column, location.GetLocationSymbol());
            }

            
        }
    }

    // move player move logic here?
    public void MovePlayer()
    {
        Console.WriteLine("Choose a direction: North, East, South, West");

        string direction = Console.ReadLine().ToLower();

        GetLocation playerLocation = _player.GetPlayerLocation();

        int previousRow = playerLocation.Row;
        int previousColumn = playerLocation.Column;

        if (direction == "north")
        {
            _player.SetPlayerLocation(playerLocation.Row--, playerLocation.Column);
        }
        else if (direction == "east")
        {
            _player.SetPlayerLocation(playerLocation.Row, playerLocation.Column++);
        }
        else if (direction == "south")
        {
            _player.SetPlayerLocation(playerLocation.Row++, playerLocation.Column);
        }
        else if (direction == "west")
        {
            _player.SetPlayerLocation(playerLocation.Row, playerLocation.Column--);
        }
        else
        {
            Console.WriteLine("Invalid direction");
        }

        if (!_player.IsValidMove())
        {
            playerLocation.Row = previousRow;
            playerLocation.Column = previousColumn;
        }
        else
        {
            
            _map.SetCell(previousRow, previousColumn, " ");
            _player.SetPlayerLocation(playerLocation.Row, playerLocation.Column);
        }
        CheckPlayerLocation();
    }
    
    // logic for if fountain is discovered and moved back to entrance
    
}