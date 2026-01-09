int[] numberInput = new int[] { 4, 2, 1, 5 };

void SelectionSort(int[] inputArray)
{
    int lenghtOfInput = inputArray.Length;

    for (int i = 0; i < lenghtOfInput; i++)
    {
        int smallestValue = i;

        for (int j = i + 1; j < lenghtOfInput; j++)
        {
            if (inputArray[j] < inputArray[smallestValue])
            {
                smallestValue = j;
            }
        }

        if (smallestValue != i)
        {
            (inputArray[i], inputArray[smallestValue]) = (inputArray[smallestValue], inputArray[i]);
        }
    }

    for (int n = inputArray.Length - 1; n >= 0; n--)
    {
        Console.WriteLine(inputArray[n]);
    }
}


SelectionSort(numberInput);





