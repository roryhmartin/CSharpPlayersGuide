
Random random = new Random();

async Task<int> RandomlyRecreateAsync(string word)
{
    List<char> letter = new List<char>();
    string generatedWord = string.Empty;

    DateTime startTime;
    DateTime endTime;

    return await Task.Run(() =>
    {
        startTime = DateTime.Now;
        int attempts = 0;
        while (generatedWord != word)
        {
            for (int i = word.Length; i > 0; i--)
            {
                // Console.WriteLine(i);
                letter?.Add((char)('a' + random.Next(26)));
                // attempts++;
            }

            generatedWord = string.Join("", letter);

            if (generatedWord != word)
            {
                letter.Clear();
                attempts++;
            }
        }
        
        Console.WriteLine($"generated word: { generatedWord }");
        endTime = DateTime.Now;
        Console.WriteLine($"Start time: { startTime }");
        Console.WriteLine($"End time: { endTime }");
        Console.WriteLine($"Time taken { endTime - startTime}");
        Console.WriteLine($"Attempts: { attempts }");
        return attempts;
    });
}

int result = await RandomlyRecreateAsync("yo");

Console.WriteLine(result);