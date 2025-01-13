// See https://aka.ms/new-console-template for more information


using Rock_Paper_Scissors;
using Rock_Paper_Scissors.enumerations;

Console.WriteLine("Welcome to Rock, Paper, Scissors!");
Console.WriteLine("Player 1, enter your name: ");
string player1Name = Console.ReadLine();
Player player1 = new Player(player1Name);
Console.WriteLine("Player 2, enter your name: ");
string player2Name = Console.ReadLine();
Player player2 = new Player(player2Name);
Console.WriteLine($"{player1.PlayerName} and {player2.PlayerName}, let's play!");;

Game game = new Game();

bool keepPlaying = true;
int roundNumber = 1;

while (keepPlaying)
{
    Console.WriteLine($"Round {roundNumber}");
    Console.WriteLine($"{player1.PlayerName} {player1.PlayerScore} || {player2.PlayerName} {player2.PlayerScore}");
    game.makeMove(player1, player2);
    game.play(player1, player2);
    roundNumber++;
}