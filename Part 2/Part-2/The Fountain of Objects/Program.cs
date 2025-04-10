using System.Data;
using The_Fountain_of_Objects;

Map map = new Map();
map.InitializeMap(4,4);

IPlayer playerOne = new Player(0, 0, map);
playerOne.SetPlayerLocation(0, 0);

Goblin goblin = new Goblin(1, 0, map, 1, 100, 10);
goblin.SetLocation(2, 1);

GameLogic gameLogic = GameLogic.GetInstance(playerOne, map);

EntranceLocation entranceLocation = new EntranceLocation(map, gameLogic);
entranceLocation.SetLocation(0, 0);
entranceLocation.LocationDiscovered();

TheFountainOfObjectsLocation theFountainOfObjectsLocation = new TheFountainOfObjectsLocation(map, gameLogic);
theFountainOfObjectsLocation.SetLocation(0, 1);

PlayerInteractions playerInteractions = new PlayerInteractions(gameLogic, map);

gameLogic.AddEnemyToGameLogic(goblin);
gameLogic.AddLocationToGameLogic(theFountainOfObjectsLocation);
gameLogic.AddLocationToGameLogic(entranceLocation);

while (true)
{
    Console.Clear();
    map.DisplayMap();
    gameLogic.CheckPlayerLocation();
    Console.ForegroundColor = ConsoleColor.Gray;
    gameLogic.GetPlayerCommand();
}
