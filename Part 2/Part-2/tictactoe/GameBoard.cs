namespace tictactoe
{
    public class GameBoard
    {
        public string[] grid = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        public void DisplayBoard()
        {
            Console.WriteLine();
            Console.WriteLine("+--+---+---+");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {grid[j]} |");
                }
                Console.WriteLine();
                Console.WriteLine("+--+---+---+");
            }
        }
    }
}