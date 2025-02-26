using System.Data;
using The_Fountain_of_Objects;



Map map = new Map();
map.InitializeMap(4,4);

Locations entranceLocation = new Locations(map, "Entrance");
entranceLocation.SetLocation(0, 0, "E");

Locations theFountainOfObjectsLocation = new Locations(map, "The Fountain of Objects");
theFountainOfObjectsLocation.SetLocation(0, 1, "F");

IPlayer playerOne = new Player(0, 0, map);
playerOne.SetPlayerLocation(0, 0);



map.DisplayMap();



