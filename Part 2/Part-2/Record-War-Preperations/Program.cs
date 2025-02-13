
using Record_War_Preperations;
using Record_War_Preperations.Enumerations;

Sword basicSword = new Sword(SwordMaterial.Iron, SwordGem.None, 100, 25);

Sword LegendarySword = basicSword with { material = SwordMaterial.Binarium, gem = SwordGem.BitStone };

Console.WriteLine($@"Basic Sword 
Material: {basicSword.material}
Gem: {basicSword.gem}
Length: {basicSword.length}
Cross Guard Width: {basicSword.crossGuardWidth}");

Console.WriteLine(@$"
Legendary Sword 
Material: {LegendarySword.material}
Gem: {LegendarySword.gem}
Length: {LegendarySword.length}
Cross Guard Width: {LegendarySword.crossGuardWidth}");