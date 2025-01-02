using The_Card;
using The_Card.Enumerations;

CardColourEnum[] colours = new CardColourEnum[]{CardColourEnum.blue, CardColourEnum.green, CardColourEnum.red, CardColourEnum.yellow};
CardRankEnum[] ranks = new CardRankEnum[]{CardRankEnum.One, CardRankEnum.Two, CardRankEnum.Three, CardRankEnum.Four, CardRankEnum.Five, CardRankEnum.Six, CardRankEnum.Seven, CardRankEnum.Eight, CardRankEnum.Nine, CardRankEnum.Ten, CardRankEnum.Jack, CardRankEnum.Queen, CardRankEnum.King, CardRankEnum.Joker};

foreach(CardColourEnum colour in colours)
{
    foreach(CardRankEnum rank in ranks)
    {
        Card card = new Card(colour, rank);
        Console.WriteLine($"Card: {card.Colour} {card.Rank}");
    }
}