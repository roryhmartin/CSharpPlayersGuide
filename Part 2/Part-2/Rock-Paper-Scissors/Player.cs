using Rock_Paper_Scissors.enumerations;

namespace Rock_Paper_Scissors;

public class Player
{
    public string PlayerName { get; set; }
    public int PlayerScore { get; set; }
    
    public MoveEnums PlayerMove { get; set; }
    
    public Player(string name)
    {
        PlayerName = name;
    }

    public void IncrementScore()
    {
        PlayerScore++;
    }
    
    public void resetScore()
    {
        PlayerScore = 0;
    }
    
    
    
}