using System.Reflection.Metadata.Ecma335;

namespace Potion_Masters___Pattern_Matching;

public class PotionMaker
{
    public Potion CurrentPotion { get; set; } = Potion.Water;
    private readonly Array _potionIngredients = Enum.GetValues(typeof(PotionIndregients));
    private PotionIndregients ingredient;
    
    public void PotionIngredientsViewer()
    {
        Console.WriteLine($"Ingredients available: ");

        for (int i = 0; i < _potionIngredients.Length; i++)
        {
            Console.WriteLine($"{i}: {_potionIngredients.GetValue(i)}");
        }
    }

    public void potionMixer(string choice)
    {
        ingredient = _turnChoiceIntoIngredient(choice);
        CurrentPotion = makePotion(CurrentPotion, ingredient);
        endBrewing(CurrentPotion);
    }

    private PotionIndregients _turnChoiceIntoIngredient(string choice)
    {
        choice = choice.ToLower();
        PotionIndregients ingredient = choice switch
        {
            "0" or "stardust" => PotionIndregients.StarDust,
            "1" or "snakevenom" => PotionIndregients.SnakeVenom,
            "2" or "dragonbreath" => PotionIndregients.DragonBreath,
            "3" or "shadowglass" => PotionIndregients.ShadowGlass,
            "4" or "eyesinegem" => PotionIndregients.EyeshineGem
        };
        return ingredient;
    }

    private Potion makePotion(Potion currentPotion, PotionIndregients ingredient)
    {
        var newPotion = (currentPotion, ingredient) switch
        {
            (Potion.Water, PotionIndregients.StarDust) => Potion.Poison,
            (Potion.Elixir, PotionIndregients.SnakeVenom) => Potion.Poison,
            (Potion.Elixir, PotionIndregients.DragonBreath) => Potion.Flying,
            (Potion.Elixir, PotionIndregients.ShadowGlass) => Potion.Invisibility,
            (Potion.Elixir, PotionIndregients.EyeshineGem) => Potion.NightSight,
            (Potion.NightSight, PotionIndregients.ShadowGlass) => Potion.CloudyBrew,
            (Potion.Invisibility, PotionIndregients.EyeshineGem) => Potion.CloudyBrew,
            (Potion.CloudyBrew, PotionIndregients.StarDust) => Potion.Wraith,
            _ => Potion.Ruined
        };
        return newPotion;
    }

    private void endBrewing(Potion currentPotion)
    {
        if (currentPotion == Potion.Ruined)
        {
            Console.WriteLine($"You have a {CurrentPotion} potion");
            Environment.Exit(0);
        }
    }
    
}