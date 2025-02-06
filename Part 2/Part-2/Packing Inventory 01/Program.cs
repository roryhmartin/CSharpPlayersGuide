using Packing_Inventory_01;
using Packing_Inventory_01.derivedItems;


Pack pack = new Pack(5, 10, 10);

pack.GetPackCapacity();
Console.WriteLine();


while (true)
{
    
    pack.GetCurrentPackContents();
    
    Console.WriteLine($@"
What would you like to add:
1. Sword
2. Bow
3. Rope
0. View pack details");

    string userInput = Console.ReadLine();

    userSelection(userInput);
    
    void userSelection(string input)
    {
        if (input == "1")
        {
            Sword sword = new Sword(2, 5, "D-Money");
            pack.Add(sword);
        }

        if (input == "2")
        {
            Bow bow = new Bow(1, 4);
            pack.Add(bow);
        }

        if (input == "3")
        {
            rope rope = new rope(1, 4);
            pack.Add(rope);
        }

        if (input == "0")
        {
            pack.GetPackCapacity();
            Console.WriteLine();
            pack.GetCurrentPackContents();
        }
    }
}

