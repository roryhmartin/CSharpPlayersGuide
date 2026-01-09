namespace Better_Random;

public static class RandomExtenstions
{
    public static double NextDouble(this Random random, double maxValue)
    {
        return random.NextDouble() * maxValue;
    }
    
    public static int RollDie(this Random random, int sides = 6)
    {
        return random.Next(sides) + 1;
    }

    public static string NextString(this Random random, params string[] options)
    {
        int randomInt = random.Next(options.Length);
        return options[randomInt];
    }

    public static bool CoinFlip(this Random random, double headsChance = 0.5)
    {
        return random.NextDouble() < headsChance;
    }
}