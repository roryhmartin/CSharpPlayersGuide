Console.Write("What is your name?");
string name = Console.ReadLine();
Console.WriteLine("What items do you want to see the prices for:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");

int response = Convert.ToInt32(Console.ReadLine());

bool discount = false;

if (name == "Rory")
{
    discount = true;
}

int cost;

// response = choice switch
// {
//     1 => 10,
//     2 => 15,
//     3 => 25,
//     4 => 1, 
//     5 => 20,
//     6 => 200,
//     7 => 1,
//     _ => "Unknown"
// };ben

switch (response)
{
    case 1:
        if (discount == true)
        {
             cost = 10 / 2;
             Console.WriteLine($"{cost}gp");
        }
        else
        {
            Console.WriteLine("10gp");
        }

        break;
}
