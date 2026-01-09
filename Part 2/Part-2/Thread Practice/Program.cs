Thread thread = new Thread(CountTo100);
		
void CountTo100()
{
    for(int i = 0; i < 100; i++)
    {
        Console.WriteLine(i + 1);
    }
}
		
thread.Start();
Console.WriteLine("Main thread over");
Thread threadTwo = new Thread(CountTo100);
threadTwo.Start();
