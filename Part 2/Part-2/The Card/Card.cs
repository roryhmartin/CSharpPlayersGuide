using The_Card.Enumerations;

namespace The_Card;

public class Card
{
    public CardColourEnum Colour { get; }
    public CardRankEnum Rank { get; }
    
    public Card(CardColourEnum colour, CardRankEnum rank)
    {
        Colour = colour;
        Rank = rank;
    }

    public bool isSymbol()
    {
        if (Rank == CardRankEnum.Jack || Rank == CardRankEnum.Queen || Rank == CardRankEnum.King || Rank == CardRankEnum.Joker)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isNumber()
    {
        if (!isSymbol())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    
}