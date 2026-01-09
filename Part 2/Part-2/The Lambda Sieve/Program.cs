using The_Lambda_Sieve;

Console.WriteLine("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve;
switch (choice)
{
    case 1:
        sieve = new Sieve(number => number % 2 == 0);
        break;
    case 2:
        sieve = new Sieve(number => number > 0);
        break;
    case 3:
        sieve = new Sieve(number => number % 10 == 0);
        break;
    default:
        throw new ArgumentOutOfRangeException(nameof(choice));
}

while (true)
{
    
    Console.WriteLine("Enter a number");
    int number = Convert.ToInt32(Console.ReadLine());
    string goodOrEvil = sieve.IsGood(number) ? "Good" : "Evil";
    Console.WriteLine(goodOrEvil);
}
