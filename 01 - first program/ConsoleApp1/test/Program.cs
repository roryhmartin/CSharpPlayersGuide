    string EnterUserName()
    {
        while (true)
        {
            Console.Write("Enter your User Name: ");
            string name = Console.ReadLine();
            string greeting = $"Hello {name}";
            
            if (name != "")
            {
                return greeting;
            }
            Console.WriteLine("Let's try that again.");
        }
    }

  Console.WriteLine(EnterUserName());
