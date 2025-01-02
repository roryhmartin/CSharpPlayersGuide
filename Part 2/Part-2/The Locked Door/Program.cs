// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using The_Locked_Door;
using The_Locked_Door.enumerations;

Console.WriteLine("Set Your password: ");
string usersPassword = Console.ReadLine();
Door.SetPassCode(usersPassword);

Door TheDoor = new Door(DoorStateEnum.Closed, usersPassword);

bool varToKeepLoopGoing = true;

while (varToKeepLoopGoing)
{
    Console.WriteLine($"The door is {TheDoor.DoorState}, what would you like to do?");
    Console.WriteLine("1. Open");
    Console.WriteLine("2. Close");
    Console.WriteLine("3. Lock");
    Console.WriteLine("4. Unlock");
    
    string userChoice = Console.ReadLine();
    
    switch (userChoice)
    {
        case "1":
            TheDoor.Open();
            break;
        case "2":
            TheDoor.Close();
            break;
        case "3":
            Console.WriteLine("Enter your password: ");
            string passcode = Console.ReadLine();
            TheDoor.Lock(passcode);
            break;
        case "4":
            Console.WriteLine("Enter your password: ");
            passcode = Console.ReadLine();
            TheDoor.Unlock(passcode);
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}