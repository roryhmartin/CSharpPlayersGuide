using tictactoe;
using tictactoe.Enumerations;


Player player1 = new Player(Cell.X);
Player player2 = new Player(Cell.O);

Console.WriteLine($"Player 1 is: {player1.Symbol}");
Console.WriteLine($"Player 2 is: {player2.Symbol}");

GameBoard gameBoard = new GameBoard();

gameBoard.DisplayBoard();


