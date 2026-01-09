int[] someNumbers = [1,9,2,8,3,7,4,6,5];

IEnumerable<int> onlyEvenFunc(int[] numberArray)
{
    if (numberArray is null)
    {
        return numberArray;
    }

    List<int> evenNumbers = new List<int>();
    foreach (int number in numberArray)
    {
        if (number % 2 == 0)
        {
            evenNumbers?.Add(number);
        }
    }

    return evenNumbers.AsEnumerable();
}

foreach (int num in onlyEvenFunc(someNumbers))
{
    Console.WriteLine(num);
}

Console.WriteLine();
Console.WriteLine("USING LINQ");
Console.WriteLine();

IEnumerable<int> evenNumbers = from num in someNumbers
    where num % 2 == 0
    select num;

foreach (int num in evenNumbers)
{
    Console.WriteLine(num);
}