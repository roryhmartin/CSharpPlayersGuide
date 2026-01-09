
using Potion_Masters___Pattern_Matching;

string? brewersChoice;
PotionMaker potionMaker = new PotionMaker();
Boolean continueBrewing = true;

while (continueBrewing)
{
    Console.WriteLine($"You currently have a {potionMaker.CurrentPotion} potion");
    endGame();
    potionMaker.PotionIngredientsViewer();
    brewersChoice = Console.ReadLine();
    potionMaker.potionMixer(brewersChoice);
    
}


void endGame()
{
    Console.WriteLine("Do you want to add an ingredient?");
    brewersChoice = Console.ReadLine()?.ToLower();

    // if (potion == Potion.Ruined)
    // {
    //     Console.WriteLine($"you have a {potion} potion");
    //     Environment.Exit(0);
    // }
    
    if (brewersChoice == "no")
    {
        Environment.Exit(0);
    }

    return;
}




