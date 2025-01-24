namespace tictactoe;

public class GameBoard
{
    // public string[] grid = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

    private static readonly char[,] Board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    // public void DisplayBoard()
    // {
    //     Console.WriteLine();
    //
    //     for (var row = 0; row < 3; row++)
    //     {
    //         for (var col = 0; col < 3; col++)
    //         {
    //             Console.Write(Board[row, col]);
    //             if (col < 2) Console.Write(" | ");
    //         }
    //
    //         Console.WriteLine();
    //         if (row < 2) Console.WriteLine("--+---+--");
    //     }
    // }
    public void DisplayBoard()
    {
        Console.WriteLine();

        for (var row = 0; row < 3; row++)
        {
            for (var col = 0; col < 3; col++)
            {
                if (Board[row, col] == 'X')
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (Board[row, col] == 'O')
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(Board[row, col]);

                Console.ForegroundColor = ConsoleColor.White;

                if (col < 2) Console.Write(" | ");
            }

            Console.WriteLine();
            if (row < 2) Console.WriteLine("--+---+--");
        }

        Console.ForegroundColor = ConsoleColor.White;
    }


    public bool SetBoardPosition(int row, int col, Player currentPlayer)
    {
        if (Board[row, col] == 'X' || Board[row, col] == 'O')
        {
            Console.WriteLine("Invalid move. Please try again.");
            return false;
        }

        Board[row, col] = (char)currentPlayer.Symbol;
        return true;
    }

    public bool CheckRows()
    {
        return (Board[0, 0] == Board[0, 1] && Board[0, 1] == Board[0, 2]) ||
               (Board[1, 0] == Board[1, 1] && Board[1, 1] == Board[1, 2]) ||
               (Board[2, 0] == Board[2, 1] && Board[2, 1] == Board[2, 2]);
    }

    public bool CheckColumns()
    {
        return (Board[0, 0] == Board[1, 0] && Board[1, 0] == Board[2, 0]) ||
               (Board[0, 1] == Board[1, 1] && Board[1, 1] == Board[2, 1]) ||
               (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 2]);
    }

    public bool CheckDiagonals()
    {
        return (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2]) ||
               (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0]);
    }
}