int counter = 0;
string playerName;
string directoryPath = @"/Users/rorymartin/repos/CSharpPlayersGuide/Part 2/Part-2/The Long Game - Files/scores";

if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

Console.WriteLine("Enter your name: ");
playerName = Console.ReadLine();


while (true)
{

    if (!File.Exists($"{directoryPath}/{playerName}.txt"))
    {
        File.WriteAllText($"{directoryPath}/{playerName}.txt", counter.ToString());
    }
    else
    {
        string previous = File.ReadAllText($"{directoryPath}/{playerName}.txt");
        counter = Convert.ToInt32(previous);
        
        Console.WriteLine(counter);
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            counter++;
        }
        
        File.WriteAllText($"{directoryPath}/{playerName}.txt", counter.ToString());
        
    }
    
}
