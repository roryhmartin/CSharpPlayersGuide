using tictactoe.Enumerations;

namespace tictactoe;

public class Player
{
    public Player(Cell symbol)
    {
        Symbol = symbol;
    }

    public Cell Symbol { get; }
}