int[] numbers  = new int [3];

numbers = new []{1, 2, 2};

int SquareSum(int[] numbers)
{
    int sum = 0;
    for(int i = 0; i < numbers.Length; i++)
    {
       int squaredNumbers = numbers[i] * numbers[i]; 
       sum += squaredNumbers;
    }
    return sum;
}

Console.WriteLine(SquareSum(numbers));

