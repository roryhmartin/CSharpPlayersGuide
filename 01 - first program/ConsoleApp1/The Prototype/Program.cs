Random rand = new Random();
int randomNumber = rand.Next(0, 101);
Console.WriteLine($"Random Number: {randomNumber}");
bool correctGuess = false;

do
{
   // Console.Clear();
    Console.Write("Guess the number of the opponent: ");
    int guess = Convert.ToInt32(Console.ReadLine());
    if (guess == randomNumber)
    {
        Console.WriteLine("Correct!");
        correctGuess = true;
    }
    else if (guess > randomNumber)
   {
       Console.WriteLine("Too High");
   }
    else if (guess < randomNumber)
    {
        Console.WriteLine("Too Low!");
    }
    
}
while(!correctGuess);