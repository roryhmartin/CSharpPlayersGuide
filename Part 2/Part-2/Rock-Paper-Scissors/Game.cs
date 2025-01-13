using Rock_Paper_Scissors.enumerations;

namespace Rock_Paper_Scissors;

public class Game
{
    
    public string play(Player player1, Player player2)
    {
        string outcome = string.Empty;
        
        if(player1.PlayerMove == MoveEnums.Rock && player2.PlayerMove == MoveEnums.Scissors)
        {
            player1.IncrementScore();
            outcome = $"{player1.PlayerName} wins!";
            Console.WriteLine(outcome);
            return outcome;
        }
        else if(player1.PlayerMove == MoveEnums.Scissors && player2.PlayerMove == MoveEnums.Paper)
        {
            player1.IncrementScore();
            outcome = $"{player1.PlayerName} wins!";
            Console.WriteLine(outcome);
            return outcome;
        }
        else if(player1.PlayerMove == MoveEnums.Paper && player2.PlayerMove == MoveEnums.Rock)
        {
            player1.IncrementScore();
            outcome = $"{player1.PlayerName} wins!";
            Console.WriteLine(outcome);
            return outcome;
        }
        else if(player2.PlayerMove == MoveEnums.Rock && player1.PlayerMove == MoveEnums.Scissors)
        {
            player2.IncrementScore();
            outcome = $"{player2.PlayerName} wins!";
            Console.WriteLine(outcome);
            return outcome;
        }
        else if(player2.PlayerMove == MoveEnums.Scissors && player1.PlayerMove == MoveEnums.Paper)
        {
            player2.IncrementScore();
            outcome = $"{player2.PlayerName} wins!";
            Console.WriteLine(outcome);
            return outcome;
        }
        else if(player2.PlayerMove == MoveEnums.Paper && player1.PlayerMove == MoveEnums.Rock)
        {
            player2.IncrementScore();
            outcome = $"{player2.PlayerName} wins!";
            Console.WriteLine(outcome);
            return outcome;
        }
        else
        {
            outcome = "It's a tie!";
            Console.WriteLine(outcome);
            return outcome;
        }
    }
    
    
    
    public string determineRoundWinner(Player player1, Player player2)
    {
        Player winningplayer = null;
        Player losingplayer = null;
        if (player1.PlayerScore == 11)
        {
            winningplayer = player1;
            return endOfGame(winningplayer, losingplayer);
        } else if (player2.PlayerScore == 11)
        {
            winningplayer = player2;
            return endOfGame(winningplayer, losingplayer);
        }
        
        
        if(player1.PlayerScore > player2.PlayerScore)
        {
            return player1.PlayerName;
        }
        else if(player1.PlayerScore < player2.PlayerScore)
        {
            return player2.PlayerName;
        }
        else
        {
            return "It's a tie!";
        }
    }
    
    public string endOfGame(Player winningplayer, Player losingplayer)
    {
        string winnerStatement = $"The winner is {winningplayer.PlayerName}";
        winningplayer.resetScore();
        losingplayer.resetScore();
        return winnerStatement;
    }


    public void makeMove(Player player1, Player player2)
    {
        string MoveOptions = @"
        1. Rock
        2. Paper
        3. Scisssors";
        
        Console.WriteLine($"{player1.PlayerName}, enter your move: ");
        Console.WriteLine(MoveOptions);
        string player1Move = Console.ReadLine().ToLower();
        player1.PlayerMove = player1Move switch
        {
            "1" => MoveEnums.Rock,
            "2" => MoveEnums.Paper,
            "3" => MoveEnums.Scissors,
            "rock" => MoveEnums.Rock,
            "paper" => MoveEnums.Paper,
            "scissors" => MoveEnums.Scissors,
            _ => MoveEnums.Rock
        };
        
        Console.WriteLine($"{player2.PlayerName}, enter your move: ");
        Console.WriteLine(MoveOptions);
        string player2Move = Console.ReadLine().ToLower();
        player2.PlayerMove = player2Move switch
        {
            "1" => MoveEnums.Rock,
            "2" => MoveEnums.Paper,
            "3" => MoveEnums.Scissors,
            "rock" => MoveEnums.Rock,
            "paper" => MoveEnums.Paper,
            "scissors" => MoveEnums.Scissors,
            _ => MoveEnums.Rock
        };
        Console.WriteLine($"{player1.PlayerName} chose: {player1.PlayerMove}");
        Console.WriteLine($"{player2.PlayerName} chose: {player2.PlayerMove}");

        
    }
    
}