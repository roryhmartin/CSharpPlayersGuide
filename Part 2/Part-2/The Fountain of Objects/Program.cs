using System.Data;
using The_Fountain_of_Objects;

Map map = new Map();
map.InitializeMap(4,4);

EntranceLocation entranceLocation = new EntranceLocation(map);
entranceLocation.SetLocation(0, 0);
entranceLocation.LocationDiscovered();

TheFountainOfObjectsLocation theFountainOfObjectsLocation = new TheFountainOfObjectsLocation(map);
theFountainOfObjectsLocation.SetLocation(0, 1);

IPlayer playerOne = new Player(0, 0, map);
playerOne.SetPlayerLocation(0, 0);

GameLogic gameLogic = new GameLogic(playerOne, map);

gameLogic.AddLocationToGameLogic(theFountainOfObjectsLocation);
gameLogic.AddLocationToGameLogic(entranceLocation);


while (true)
{
    Console.Clear();
    map.DisplayMap();
    gameLogic.CheckPlayerLocation();
    Console.ForegroundColor = ConsoleColor.Gray;
    gameLogic.MovePlayer();
}



