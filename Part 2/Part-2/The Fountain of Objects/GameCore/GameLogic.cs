using System.Runtime.CompilerServices;
using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class GameLogic
{
    private static GameLogic? _instance;
    private readonly IPlayer _player;
    private readonly Map _map;
    private readonly List<Locations> _locations;
    private readonly List<Enemy> _enemies;
    public bool FountainHasBeenDiscovered { get; set; }
    private DateTime startingTime; 
    private DateTime endTime; 

    public static bool IsFountainActivated { get; set; } = false;

    private GameLogic(IPlayer player, Map map)
    {
        _player = player;
        _map = map;
        _locations = new List<Locations>();
        _enemies = new List<Enemy>();
        startingTime = DateTime.Now;
        getTime();
        Console.ResetColor();
    }

    public static GameLogic GetInstance(IPlayer player, Map map)
    {
        if (_instance == null)
        {
            _instance = new GameLogic(player, map);
        }

        return _instance;
    }

    void getTime()
    {
        TimeSpan timeSpent = endTime - startingTime;
        Console.WriteLine($"Time in Dungeon: {timeSpent.Days} days, {timeSpent.Hours} hours, {timeSpent.Minutes} minutes, {timeSpent.Seconds} seconds");
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
        bool actionsAvailable = false;

        foreach (Locations location in _locations)
        {
            if (location.GetLocation().Row == _player.GetPlayerLocation().Row && 
                location.GetLocation().Column == _player.GetPlayerLocation().Column)
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
                string input = Console.ReadLine();
                if(int.TryParse(input, out int actionNumber) && location.LocationDictionary.ContainsKey(actionNumber))
                {
                    location.LocationDictionary[actionNumber].action();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number from the list.");
                    Console.ReadKey();
                    Console.ResetColor();
                }

                actionsAvailable = true;
                break; 
            }
        }

        if (!actionsAvailable)
        {
            Console.WriteLine("No actions available at this location.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }


    private void AttackAction()
    {
        GetLocation playerlocation = _player.GetPlayerLocation();
        
        Console.WriteLine("Choose a direction to shoot your bow:");
        Console.WriteLine("1. North");
        Console.WriteLine("2. East");
        Console.WriteLine("3. South");
        Console.WriteLine("4. West");
        Console.WriteLine("5. North East");
        Console.WriteLine("6. South East");
        Console.WriteLine("7. South West");
        Console.WriteLine("8. North West");
        Console.Write("Input: ");

        string? input = Console.ReadLine()?.Trim().ToLower();
        Console.WriteLine($"Your input: { input }");
        bool hit = false;

        List<Enemy> deadEnemies = new List<Enemy>();

        foreach (Enemy enemy in _enemies)
        {
            GetLocation enemyLocation = enemy.GetLocation();
            int rowDiff = playerlocation.Row - enemyLocation.Row;
            int colDiff = playerlocation.Column - enemyLocation.Column;
            
            if (Math.Abs(rowDiff) <= 1 && Math.Abs(colDiff) <= 1 && !(rowDiff == 0 && colDiff == 0))
            {
                if (input == "1" && rowDiff == 1 && colDiff == 0)
                {
                  Console.WriteLine("You hit an enemy to the north!");
                    hit = true;
                    Console.ReadKey();
                }
                if (input == "2" && rowDiff == 0 && colDiff == -1) 
                {
                    enemy.ReduceHealth(100);
                    Console.WriteLine("You hit an enemy to the east!");
                    hit = true;
                    Console.ReadKey();
                }
                if (input == "3" && rowDiff == -1 && colDiff == 0) 
                {
                    enemy.ReduceHealth(100);
                    Console.WriteLine("You hit an enemy to the south!");
                    hit = true;
                    Console.ReadKey();
                }
                if (input == "4" && rowDiff == 0 && colDiff == 1)
                {
                    enemy.ReduceHealth(100);
                    Console.WriteLine("You hit an enemy to the west!");
                    hit = true;
                    Console.ReadKey();
                }
                if (input == "5" && rowDiff == 1 && colDiff == -1) 
                {
                    enemy.ReduceHealth(100);
                    Console.WriteLine("You hit an enemy to the northeast!");
                    hit = true;
                    Console.ReadKey();
                }
                if (input == "6" && rowDiff == -1 && colDiff == -1) 
                {
                    enemy.ReduceHealth(200);
                    Console.WriteLine("You hit an enemy to the southeast!");
                    hit = true;
                    Console.ReadKey();
                }
                if (input == "7" && rowDiff == -1 && colDiff == 1) 
                {
                    enemy.ReduceHealth(100);
                    Console.WriteLine("You hit an enemy to the southwest!");
                    hit = true;
                    Console.ReadKey();
                }
                if (input == "8" && rowDiff == 1 && colDiff == 1)
                {
                    enemy.ReduceHealth(100);
                    Console.WriteLine("You hit an enemy to the northwest!");
                    hit = true;
                    Console.ReadKey();
                }
            }

            if (enemy.IsDead)
            {
                deadEnemies.Add(enemy);
            }

        }

        foreach (var enemy in deadEnemies)
        {
            _enemies.Remove(enemy);
            Console.WriteLine($"You slayed {enemy.Name}");
            Console.ReadKey();
        }

        if (!hit)
        {
            Console.WriteLine("You missed! No enemies in that direction.");
            Console.ReadKey();
        }
    
}

    private void CheckGameOver()
    {
        if (_player.GetHealth() == 0)
        {
            Console.WriteLine("Game Over");
            EndGame();
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

            if (Math.Abs(rowDiff) <= 1 && Math.Abs(colDiff) <= 1 && !(rowDiff == 0 && colDiff == 0))
            {
                if (rowDiff == 1 && colDiff == 0) direction = "north";     
                else if (rowDiff == -1 && colDiff == 0) direction = "south";  
                else if (rowDiff == 0 && colDiff == 1) direction = "west";    
                else if (rowDiff == 0 && colDiff == -1) direction = "east";    

                
                else if (rowDiff == 1 && colDiff == 1) direction = "northwest";  
                else if (rowDiff == 1 && colDiff == -1) direction = "northeast";  
                else if (rowDiff == -1 && colDiff == 1) direction = "southwest";  
                else if (rowDiff == -1 && colDiff == -1) direction = "southeast";

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You sense an enemy nearby to the { direction }");
                Console.ResetColor();
                // enemyNearby = true;
            }

        }
    }

    public void EndGame()
    {
        endTime = DateTime.Now;
        getTime();
        Environment.Exit(0);
    }
    
}