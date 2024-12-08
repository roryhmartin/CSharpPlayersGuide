
// while loop to keep the console running
// a variable to hold the state of the box
// a variable to hold the users answer
// a variaable to hold the question saying "the chest is {StateOfChest}, what do you want to do? 

using System.Runtime.CompilerServices;

bool variableToKeepConsoleRunning = true;
StateOfChest _StateOfChest = StateOfChest.closed;
bool _isChestLocked = true;

string usersAnswer = "";

// need to reassign state of chest. 
while (variableToKeepConsoleRunning)
{
    string question = $"The chest is { _StateOfChest }, what do you want to do?";
    Console.WriteLine(question);
    usersAnswer = Console.ReadLine() ?? String.Empty;

    if (usersAnswer == "close")
    {
        if (_StateOfChest == StateOfChest.closed && _isChestLocked == true)
        {
            Console.WriteLine("the chest is already closed and locked");
        }
        else if (_StateOfChest == StateOfChest.closed && _isChestLocked == false)
        {
            Console.WriteLine("The chest is already closed and unlocked");
        } 
        else
        {
            _StateOfChest = StateOfChest.closed;
            Console.WriteLine("The chest is now closed");
        }
    }

    if (usersAnswer == "open")
    {
        if (_StateOfChest == StateOfChest.open)
        {
            Console.WriteLine("the chest is already open");
        }
        else if (_StateOfChest == StateOfChest.closed && _isChestLocked == true)
        {
            Console.WriteLine("The chest is locked, you need to unlock it first");
        }
        else if (_StateOfChest == StateOfChest.closed && _isChestLocked == false)
        {
            _StateOfChest = StateOfChest.open;
            Console.WriteLine("The chest is now open");
        }
        
    }

    if (usersAnswer == "lock")
    {
        if (_StateOfChest == StateOfChest.closed && _isChestLocked == true)
        {
            Console.WriteLine("The chest is already locked");
        }
        if (_StateOfChest == StateOfChest.closed && _isChestLocked == false)
        {
            _isChestLocked = true;
            Console.WriteLine("The chest is now locked");
        }
    }

    if (usersAnswer == "unlock")
    {
        if (_StateOfChest == StateOfChest.closed && _isChestLocked == false)
        {
            Console.WriteLine("The chest is already unlocked");            
        }

        if (_StateOfChest == StateOfChest.closed && _isChestLocked == true)
        {
            _isChestLocked = false;
            Console.WriteLine("The chest is now unlocked");
        }
    }
   
}

enum StateOfChest
{
    closed,
    open,
}