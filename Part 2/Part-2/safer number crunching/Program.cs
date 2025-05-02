// Console.Write("enter a number: ");
// string? input;
//
// while (true)
// {
//     input = Console.ReadLine();
//     if (int.TryParse(input, out int value))
//     {
//         Console.WriteLine($"You entered the number: {value}");
//         break;
//     }
//    
//     Console.WriteLine("Invalid input, please enter a valid number");
//     
// }


// int number;
//
// do
// {
//     Console.WriteLine("Enter a number");
// } while(!int.TryParse(Console.ReadLine(), out number));
//
// Console.WriteLine($"Number value is {number}");

double doubleNumber;

do
{
    Console.WriteLine("Enter a double");
} while (!double.TryParse(Console.ReadLine(), out doubleNumber));

Console.WriteLine($"Double value is {doubleNumber}");

// bool boolValue;
//
// do
// {
//     Console.WriteLine("Enter true or false");
// } while (!bool.TryParse(Console.ReadLine(), out boolValue));
//
// Console.WriteLine($"Your value is {boolValue}");