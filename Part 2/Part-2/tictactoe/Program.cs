using tictactoe;
using tictactoe.Enumerations;

var player1 = new Player(Cell.X);
var player2 = new Player(Cell.O);

var gameLogic = new GameLogic();
var gameBoard = new GameBoard();

var currentPlayer = player1;

Console.WriteLine($"Player 1 is: {player1.Symbol}");
Console.WriteLine($"Player 2 is: {player2.Symbol}");

var isGameOver = false;
var gameRound = 0;

while (!isGameOver && gameRound <= 9)
{
    if (gameRound == 9)
    {
        isGameOver = true;
        Console.WriteLine("The game is a draw!");
        break;
    }

    gameBoard.DisplayBoard();
    Console.WriteLine($"Player {currentPlayer.Symbol} make your move: ");
    var choice = Console.ReadLine();

    var result = gameLogic.PlayersMove(choice, gameBoard, currentPlayer);
    Console.WriteLine(result);

    if (!isGameOver) Console.Clear();

    if (gameLogic.CheckForWinner(gameBoard))
    {
        gameBoard.DisplayBoard();
        Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
        isGameOver = true;
    }

    currentPlayer = currentPlayer == player1 ? player2 : player1;

    gameRound++;
    Console.WriteLine($"Game round: {gameRound}");
}


// player1.PlayersMove();
//
// Console.WriteLine(gameBoard.getBoardPosition(0, 1));