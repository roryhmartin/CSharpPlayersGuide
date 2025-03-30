using System.Runtime.CompilerServices;
using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class GameLogic
{
    private readonly IPlayer _player;
    private readonly Map _map;
    private readonly List<Locations> _locations;
    private readonly List<Enemy> _enemies;
    public bool FountainHasBeenDiscovered { get; set; }

    public static bool IsFountainActivated { get; set; } = false;

    public GameLogic(IPlayer player, Map map)
    {
        _player = player;
        _map = map;
        _locations = new List<Locations>();
        _enemies = new List<Enemy>();
        Console.ResetColor();
    }
    
    

    public void AddLocationToGameLogic(Locations location)
    {
        _locations.Add(location);
    }

    public void AddEnemyToGameLogic(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void CheckPlayerLocation()
    {
        var playerLocation = _player.GetPlayerLocation();
        CheckForEnemies(playerLocation);
        SenseEnemy(playerLocation);
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
        }
    }

    public void CheckForEnemies(GetLocation playerLocation)
    {
        foreach (var enemy in _enemies)
        {
            var enemyLocation = enemy.GetLocation();
            if (playerLocation.Row == enemy.GetLocation().Row && playerLocation.Column == enemy.GetLocation().Column)
            {
                enemy.EnemyIsDiscovered();
                Console.WriteLine($"You have encountered {enemy.Name}");
                enemy.AttackPlayer(_player);
                CheckGameOver();
            }
            
            if (enemy._isEnemyDiscovered) 
            {
                _map.SetCell(enemyLocation.Row, enemyLocation.Column, enemy.GetIcon());
            }
            else
            {
                _map.SetCell(enemyLocation.Row, enemyLocation.Column, enemy.enemyNotDiscoveredSymbol);
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
                case PlayerActions.ATTACK:
                    AttackAction();
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
   
        
    }
    
    public void GetActions()
    {
        foreach (Locations location in _locations)
        {
            if (location.GetLocation().Row == _player.GetPlayerLocation().Row && location.GetLocation().Column == _player.GetPlayerLocation().Column)
            {
                Console.WriteLine("Available actions: ");
                int actionIndex = 1;
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var kvp in location.LocationDictionary)
                {
                    Console.WriteLine($"{actionIndex}: {kvp.Value.description}");
                    actionIndex++;
                }
                Console.ResetColor();
                
                Console.Write("Enter the number of the action you would like to take: ");
                int input = Convert.ToInt32(Console.ReadLine());
                location.LocationDictionary[input].action();
                
            }

            if(location.GetLocation().Row != _player.GetPlayerLocation().Row && location.GetLocation().Column != _player.GetPlayerLocation().Column)
            {
                Console.WriteLine("No actions available at this location.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            
        } 
    }

    private void AttackAction()
    {
        Console.WriteLine("ATTACK!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void CheckGameOver()
    {
        if (_player.GetHealth() == 0)
        {
            Console.WriteLine("Game Over");
            Environment.Exit(0);
        }
    }

    private void SenseEnemy(GetLocation playerlocation)
    {
        // bool enemyNearby = false;
        foreach (var enemy in _enemies)
        {
            var enemyLocation = enemy.GetLocation();

            int rowDiff = playerlocation.Row - enemyLocation.Row;
            int colDiff = playerlocation.Column - enemyLocation.Column;

            string direction = "";

            if (rowDiff <= 1 && colDiff <= 1)
            {
                if (rowDiff == -1 && colDiff == 0) direction = "north";
                else if (rowDiff == 1 && colDiff == 0) direction = "south";
                else if (rowDiff == 0 && colDiff == -1) direction = "west";
                else if (rowDiff == 0 && colDiff == 1) direction = "east";
                else if (rowDiff == -1 && colDiff == -1) direction = "northwest";
                else if (rowDiff == -1 && colDiff == 1) direction = "northeast";
                else if (rowDiff == 1 && colDiff == -1) direction = "southwest";
                else if (rowDiff == 1 && colDiff == 1) direction = "southeast";

                Console.WriteLine($"You sense an enemy nearby to the { direction }");
                // enemyNearby = true;
            }

        }
    }
    
}