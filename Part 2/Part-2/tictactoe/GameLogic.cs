namespace tictactoe;

public class GameLogic
{
    public string PlayersMove(string choice, GameBoard gameBoard, Player currentPlayer)
    {
        if (int.TryParse(choice, out var choiceInt))
        {
            var moveSuccessful = ConvertMoveToBoardPosition(choiceInt, gameBoard, currentPlayer);

            while (!moveSuccessful)
            {
                Console.WriteLine("That space is already taken. Please choose another space (1-9): ");
                choice = Console.ReadLine();
                if (int.TryParse(choice, out choiceInt))
                    moveSuccessful = ConvertMoveToBoardPosition(choiceInt, gameBoard, currentPlayer);
                else
                    return "Invalid input. Please enter a number between 1 and 9";
            }

            return $"Player {currentPlayer.Symbol} chose {choiceInt}";
        }

        return "Invalid input. Please enter a number between 1 and 9";
    }

    public bool ConvertMoveToBoardPosition(int choice, GameBoard gameBoard, Player currentPlayer)
    {
        switch (choice)
        {
            case 1:
                return gameBoard.SetBoardPosition(0, 0, currentPlayer);
                break;
            case 2:
                return gameBoard.SetBoardPosition(0, 1, currentPlayer);
                break;
            case 3:
                return gameBoard.SetBoardPosition(0, 2, currentPlayer);
                break;
            case 4:
                return gameBoard.SetBoardPosition(1, 0, currentPlayer);
                break;
            case 5:
                return gameBoard.SetBoardPosition(1, 1, currentPlayer);
                break;
            case 6:
                return gameBoard.SetBoardPosition(1, 2, currentPlayer);
                break;
            case 7:
                return gameBoard.SetBoardPosition(2, 0, currentPlayer);
                break;
            case 8:
                return gameBoard.SetBoardPosition(2, 1, currentPlayer);
                break;
            case 9:
                return gameBoard.SetBoardPosition(2, 2, currentPlayer);
                break;
            default:
                return false;
        }
    }

    public bool CheckForWinner(GameBoard gameBoard)
    {
        return gameBoard.CheckRows() || gameBoard.CheckColumns() || gameBoard.CheckDiagonals();
    }
}