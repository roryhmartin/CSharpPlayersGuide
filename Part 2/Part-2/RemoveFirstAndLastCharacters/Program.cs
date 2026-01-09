string input = "Busta Rhymes";

string returnChar(string input)
{
    if (input.Length <= 2)
    {
        return input;
    }

    char[] inputAsCharArray = input.ToCharArray();
    List<char> newInputArray = new List<char>();

    for (int i = 1; i < inputAsCharArray.Length - 1; i++)
    {
        newInputArray.Add(inputAsCharArray[i]);
    }

    string result = string.Join("", newInputArray);
    Console.WriteLine(result);
    return result;
}

returnChar(input);