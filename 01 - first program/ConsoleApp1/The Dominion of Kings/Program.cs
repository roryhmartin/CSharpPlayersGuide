Console.WriteLine("Provinces: ");
int Provinces = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Duchies: ");
int Duchies = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Estates: ");
int Estates = Convert.ToInt32(Console.ReadLine());

int TotalScore = (Provinces * 1) + (Duchies * 3) + ( Estates * 6);

Console.WriteLine($"Total Score: {TotalScore}");