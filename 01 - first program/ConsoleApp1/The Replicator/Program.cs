int[] array1 = new int[5];

for (int index = 0; index < 5; index++)
{
    Console.Write("Enter a number: ");
    int userNumber = Convert.ToInt32(Console.ReadLine());
    array1[index] = userNumber;
}

int[] array2 = new int[5];


    Console.WriteLine($"Final Array: {string.Join(",", array1)}");
