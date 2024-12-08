Console.WriteLine("How many eggs were gathered?");
int eggs = Convert.ToInt32(Console.ReadLine());
int forSisters = eggs / 4;
int forDuckBear = eggs % 4;

Console.WriteLine($"Sisters get: {forSisters}");
Console.WriteLine($"DuckBear gets: {forDuckBear}");

