using System.Data;
using The_Fountain_of_Objects;

Map map = new Map();
map.InitializeMap(4,4);

Locations entranceLocation = new Locations(map, "Entrance", "E");
entranceLocation.SetLocation(0, 0);
entranceLocation.LocationDiscovered();

Locations theFountainOfObjectsLocation = new Locations(map, "The Fountain of Objects", "F");

theFountainOfObjectsLocation.SetLocation(0, 1);



IPlayer playerOne = new Player(0, 0, map);
playerOne.SetPlayerLocation(0, 0);

GameLogic gameLogic = new GameLogic(playerOne, map);


gameLogic.AddLocationToGameLogic(theFountainOfObjectsLocation);
gameLogic.AddLocationToGameLogic(entranceLocation);

map.DisplayMap();

while (true)
{
    gameLogic.MovePlayer();
    
    
    map.DisplayMap();
    
}



