using The_Sieve__Delegates;

Console.WriteLine("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(IsMultipleOfTen)
};


while (true)
{
    
    Console.WriteLine("Enter a number");
    int number = Convert.ToInt32(Console.ReadLine());
    string goodOrEvil = sieve.IsGood(number) ? "Good" : "Evil";
    Console.WriteLine(goodOrEvil);
}

bool IsEven(int number) => number % 2 == 0;
bool IsPositive(int number) => number > 0;
bool IsMultipleOfTen(int number) => number % 10 == 0;