namespace The_Sieve__Delegates;

public class Sieve
{
    private Func<int, bool> _decisionFunction;

    public Sieve(Func<int, bool> decisionFunction)
    {
        _decisionFunction = decisionFunction;
    } 
    
    public bool IsGood(int number)
    {
        return _decisionFunction(number);
    }
}