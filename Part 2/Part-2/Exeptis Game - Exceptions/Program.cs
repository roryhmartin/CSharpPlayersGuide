Random rng = new Random();
int randomInt = rng.Next(0, 10);
int playerOneGuess = 0;
int playerTwoGuess = 0;
bool playerOnesTurn = false;

Console.WriteLine($"Random number shhh {randomInt}");


do
{
    if (playerOneGuess == randomInt || playerTwoGuess == randomInt)
    {
        Console.WriteLine("You win");
        Environment.Exit(0);
    }

    playerOnesTurn = !playerOnesTurn;
    PlayerGuess(playerOnesTurn);
} while (playerOneGuess != randomInt || playerTwoGuess != randomInt);

void PlayerGuess(bool playersTurn)
{
    if (playersTurn)
    {
        Console.WriteLine("Player 1, Pick a number between 1 and 10");
        try
        {
            playerOneGuess = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Wrong Input, try again");
            // PlayerGuess(playersTurn);
            throw new Exception();
        }
    }
    else
    {
        Console.WriteLine("Player 2, Pick a number between 1 and 10");
        try
        {
            playerTwoGuess = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Wrong Input, try again");
            PlayerGuess(playersTurn);
        }
    }
}