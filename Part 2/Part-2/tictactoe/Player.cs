using tictactoe.Enumerations;

namespace tictactoe;

public class Player
{
    public Cell Symbol { get; }
    
    public Player(Cell symbol)
    {
        Symbol = symbol;
    }
}