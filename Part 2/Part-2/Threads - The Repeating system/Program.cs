
using System.Runtime.InteropServices.JavaScript;
using Threads___The_Repeating_system;

int randomNumber;
object lockObject = new object();
RecentNumbers recentNumbers = new RecentNumbers {A = 0, B = 0 };
Thread thread = new Thread(RandomNumbers);
thread.Start();

Thread inputThread = new Thread(inputHandler);
inputThread.Start();
    

void RandomNumbers()
{
    Random random = new Random();
    while (true)
    {
        lock (lockObject)
        {
            recentNumbers.B = recentNumbers.A;
            randomNumber = random.Next(4);
            recentNumbers.A = randomNumber;
            Console.WriteLine(randomNumber);
            Console.WriteLine($"recentNumber A: {recentNumbers.A}");
            Console.WriteLine($"recentNumber B: {recentNumbers.B}");
        }
        Thread.Sleep(1000);
    } 
}

void inputHandler()
{
    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey();
    
        lock (lockObject)
        {
            if (recentNumbers.A == recentNumbers.B)
            {
                Console.WriteLine("CONGRATULATIONS! the numbers are the same");
            }
            else
            {
                Console.WriteLine ("Pair do not match");
            }
        }
    }
}
