namespace DescendingOrderTwo;

public class Descender
{
    public List<char> SplitNumber(int numberArg)
    {
        string numberString = numberArg.ToString();
        List<char> UnsortedCharList = new List<char>(); 

        foreach (char character in numberString)
        {
            Console.WriteLine(character);
            UnsortedCharList.Add(character);
        }

        Console.WriteLine(UnsortedCharList);
        return UnsortedCharList;
    }

    public void SplitAndDescend(int numberArg)
    {
        char[] digits = numberArg.ToString().ToCharArray();
        
        Array.Sort(digits);
        Array.Reverse(digits);

        string sortedString = new string(digits);

        foreach (char character in sortedString)
        {
            Console.WriteLine(character);
        }
    }
}