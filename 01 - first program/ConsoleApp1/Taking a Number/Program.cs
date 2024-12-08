using System.Data;

int AskForNumber(string numberQuestion)
{
    Console.Write(numberQuestion);
    int userNumber = Convert.ToInt32(Console.ReadLine());
    return userNumber;
};



string AskForNumberInRange(string text, int minNum, int maxNum)
{
    string successMessage;
    
    int userNumber = AskForNumber($"Enter a number between {minNum} and {maxNum} ");
    
    while (userNumber < minNum || userNumber > maxNum )
    {
        Console.WriteLine("Try again.");
        userNumber = AskForNumber($"Enter a number between {minNum} and {maxNum}: ");
    }

    successMessage = $"Well done, your number is {userNumber}";
    return successMessage;

};


Console.WriteLine(AskForNumberInRange("Time for a number game", 5, 10));