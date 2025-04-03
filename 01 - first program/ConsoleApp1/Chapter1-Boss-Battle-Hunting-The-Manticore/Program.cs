int cityHealth = 15;
int manticoreHealth = 10;
int gameRound = 1;
int manticoreDistance = 0;
int defaultManticoreDistance = 25;
int player2Choice = 0;
int canonDamage;
string directHit = "That round was a direct hit!";
string overshot = "That round OVERSHOT the target";
string undershot = "That round UNDERSHOT the target";
bool IsSinglePlayer = false;

//Game starts here
// GetManticoreRange();
chooseGameType();
if (!IsSinglePlayer)
{
    Console.WriteLine("Player 2, it is your turn.");
}


while (cityHealth > 0 && manticoreHealth > 0)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----------------------------------------------");
    StatusMessage();
    CanonDamageCalculator(gameRound);
    GetTargetRange();

        if (player2Choice == manticoreDistance)
        {
            DirectHitEvent();
        }
        
        else if (player2Choice > manticoreDistance)
        {
            cityHealth--;
            Console.ForegroundColor =  ConsoleColor.Red;
            Console.WriteLine(overshot);
        }

        else if (player2Choice < manticoreDistance)
        {
            cityHealth--;
            Console.ForegroundColor =  ConsoleColor.Red;
            Console.WriteLine(undershot);
        }

        gameRound++;
        
};

EndGame();

void EndGame()
{
    if (cityHealth == 0)
    {
        Console.WriteLine("The city has been destroyed. The manticore wins!");
        Console.WriteLine($"City Health: {cityHealth} | Manticore Health: {manticoreHealth}");
    }
    else
    {
        Console.WriteLine("The manticore has been defeated. The city wins!");
        Console.WriteLine($"City Health: {cityHealth} | Manticore Health: {manticoreHealth}");

    }
}

void CanonDamageCalculator(int gameRound)
{
    if (gameRound % 5 == 0 && gameRound % 3 == 0)
    {
        // Console.ForegroundColor =  ConsoleColor.Red;
        canonDamage = 10;
    }
    else if (gameRound % 5 == 0 || gameRound % 3 == 0)
    {
        // Console.ForegroundColor =  ConsoleColor.Yellow;
        canonDamage = 3;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        canonDamage = 1;
    }
    Console.WriteLine($"The canon is expected to deal {canonDamage} damage this round");
}

void chooseGameType()
{
    Console.WriteLine("Choose game type: ");
    Console.WriteLine("1. Singleplayer");
    Console.WriteLine("2. Multiplayer");
    string input = Console.ReadLine().Trim().ToLower();

    if (input == "1" || input == "singleplayer")
    {
        IsSinglePlayer = true;
        singlePlayerGame();
    }
    else
    {
        IsSinglePlayer = false;
        multiplayerGame();
    }
}

int singlePlayerGame()
{
    Random random = new Random();
    int range = random.Next(0, 101);
    manticoreDistance = range;
    Console.WriteLine(range);
    return manticoreDistance;
}

void multiplayerGame()
{
    GetManticoreRange();
}

int GetManticoreRange()
{
    bool isValidInput = false;
    while (!isValidInput)
    {
        Console.Write("Player 1, enter the distance of the manticore: ");
        
        string input = Console.ReadLine();
        
        isValidInput = int.TryParse(input, out manticoreDistance);

        if (input == "")
        {
            manticoreDistance = defaultManticoreDistance;
            // Console.WriteLine($"Default manticore distance is {defaultManticoreDistance}");
            return manticoreDistance;
        }
        else if (!isValidInput)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    Console.Clear();
    return manticoreDistance;
}

int GetTargetRange()
{
    bool isValidInput = false;
    while (!isValidInput)
    {
        Console.Write("Enter the desired canon range: ");
        string input = Console.ReadLine();
        isValidInput = int.TryParse(input, out player2Choice);
        
        if (!isValidInput)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    return player2Choice;
}

void StatusMessage()
{
    Console.WriteLine($"Status: Round {gameRound} | City: {cityHealth}/15 | Manticore: {manticoreHealth}/10");
}

void DirectHitEvent()
{

    if (manticoreHealth > 0 && IsSinglePlayer == false)
    {
        manticoreHealth -= canonDamage;
        Console.ForegroundColor =  ConsoleColor.Green;
        Console.WriteLine(directHit);
        Console.ForegroundColor =  ConsoleColor.White;
        Console.WriteLine("Player 2 Look away! Player 1 is entering the manticore's distance.");
        GetManticoreRange();
        Console.WriteLine("The Manticore has moved!");
    }
    else if (manticoreHealth > 0 && IsSinglePlayer == true)
    {
        manticoreHealth -= canonDamage;
        Console.ForegroundColor =  ConsoleColor.Green;
        Console.WriteLine(directHit);
        Console.ForegroundColor =  ConsoleColor.White;
        singlePlayerGame();
        Console.WriteLine("The Manticore has moved!");
    }
    else
    {
        EndGame();
    }
}






