namespace Better_Random;

public static class RandomExtenstions
{
    public static double NextDouble(this Random random, double maxValue)
    {
        return random.NextDouble() * maxValue;
    }
    
    
}