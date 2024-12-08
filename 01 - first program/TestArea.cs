namespace DefaultNamespace;

public class TestArea
{
    string enterUserName()
    {
        while (true)
        {
            Console.Write('Enter your User Name: ');
            string name = Console.ReadLine();
            
            if (name != '')
            {
                return 'Hello ${name}';
            }
            Console.WriteLine("Let's try that again.")
        }
    }
}