using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.PrintBoard();
            game.Play();
        }

    }

    public class TicTacToe
    {

        private const int BOARDSIZE = 3; // Size of the board
        private int[,] board = new int[BOARDSIZE, BOARDSIZE]; // Board representation

        public TicTacToe()
        {
            board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public void PrintBoard()
        {
            Console.WriteLine("-----------------------\n" +
                              "|       |       |       |\n" +
                              "|   {0}   |   {1}   |   {2}   |\n" +
                              "|_______|_______|_______|\n" +
                              "|       |       |       |\n" +
                              "|   {3}   |   {4}   |   {5}   |\n" +
                              "|_______|_______|_______|\n" +
                              "|       |       |       |\n" +
                              "|   {6}   |   {7}   |   {8}   |\n" +
                              "|_______|_______|_______|\n",
                              board[0, 0], board[0, 1], board[0, 2],
                              board[1, 0], board[1, 1], board[1, 2],
                              board[2, 0], board[2, 1], board[2, 2]);
            //throw new NotImplementedException();
        }

        public void Play()
        {
            Boolean player1Turn = true;
            Boolean player2Turn = false;
            String playerInput;
            int player1Row, player1Column, player2Row, player2Column;
            int player1Piece = 1;
            int player2Piece = 2;

            while (true)
            {
                while (player1Turn)
                {
                    if (checkWinConditon(player2Piece))
                    {
                        Console.WriteLine("Player 2 Wins!");
                        player1Turn = false;
                        player2Turn = false;
                        break;
                    }
                    else if (checkCatsGame(board, player1Piece, player2Piece))
                    {
                        Console.WriteLine("Cats Game!");
                        player1Turn = false;
                        player2Turn = false;
                        break;
                    }
                    Console.WriteLine("Player 1's turn.");
                    Console.WriteLine("Player 1: Enter row ( 0 <= row < 3): ");
                    playerInput = Console.ReadLine();
                    if (int.TryParse(playerInput, out player1Row) && player1Row >= 0 && player1Row < 3)
                    {
                        player1Row = Convert.ToInt32(playerInput);
                        Console.WriteLine("Player 1: Enter column ( 0 <= row < 3): ");
                        playerInput = Console.ReadLine();
                        player1Column = Convert.ToInt32(playerInput);
                        if (makeMove(player1Row, player1Column, player1Piece))
                        {
                            player1Turn = false;
                            player2Turn = true;
                        }
                        else
                        {
                            continue;
                        }
                        PrintBoard();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! \nPlease try again.");
                    }

                    
                }
                while (player2Turn)
                {
                    if (checkWinConditon(player1Piece))
                    {
                        Console.WriteLine("Player 1 Wins!");
                        player1Turn = false;
                        player2Turn = false;
                        break;
                    }
                    else if (checkCatsGame(board, player1Piece, player2Piece))
                    {
                        Console.WriteLine("Cats Game!");
                        player1Turn = false;
                        player2Turn = false;
                        break;
                    }
                    Console.WriteLine("Player 2's turn.");
                    Console.WriteLine("Player 2: Enter row ( 0 <= row < 3): ");
                    playerInput = Console.ReadLine();
                    if (int.TryParse(playerInput, out player2Row) && player2Row >= 0 && player2Row < 3)
                    {
                        player1Row = Convert.ToInt32(playerInput);
                        Console.WriteLine("Player 2: Enter column ( 0 <= row < 3): ");
                        playerInput = Console.ReadLine();
                        player2Column = Convert.ToInt32(playerInput);
                        if (makeMove(player2Row, player2Column, player2Piece))
                        {
                            player1Turn = true;
                            player2Turn = false;
                        }
                        else
                        {
                            continue;
                        }
                        PrintBoard();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! \nPlease try again.");
                    }
 
                }
            }
            //throw new NotImplementedException();
        }
        public Boolean makeMove(int playerRow, int playerColumn, int playerPiece)
        {
            if (board[playerRow, playerColumn] == 0)
            {
                board[playerRow, playerColumn] = playerPiece;
                return true;
            }
            else
            {
                Console.WriteLine("You can't make a move there.  \nPlease try again.");
                return false;
            }
        }

        public Boolean checkWinConditon(int playerPiece)
        {
            // check rows
            if (board[0, 0] == playerPiece && board[0, 1] == playerPiece && board[0, 2] == playerPiece) { return true; }
            if (board[1, 0] == playerPiece && board[1, 1] == playerPiece && board[1, 2] == playerPiece) { return true; }
            if (board[2, 0] == playerPiece && board[2, 1] == playerPiece && board[2, 2] == playerPiece) { return true; }

            // check columns
            if (board[0, 0] == playerPiece && board[1, 0] == playerPiece && board[2, 0] == playerPiece) { return true; }
            if (board[0, 1] == playerPiece && board[1, 1] == playerPiece && board[2, 1] == playerPiece) { return true; }
            if (board[0, 2] == playerPiece && board[1, 2] == playerPiece && board[2, 2] == playerPiece) { return true; }

            // check diaganals
            if (board[0, 0] == playerPiece && board[1, 1] == playerPiece && board[2, 2] == playerPiece) { return true; }
            if (board[0, 2] == playerPiece && board[1, 1] == playerPiece && board[2, 0] == playerPiece) { return true; }

            return false;
        }

        public Boolean checkCatsGame(int[,] board, int player1Piece, int player2Piece)
        {
            int moveCount = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (board[i, j].Equals(player1Piece) || board[i, j].Equals(player2Piece))
                    {
                        moveCount++;
                    }                      
                }
            }
            if (moveCount == 9)
            {
                return true;
            }
            else 
                return false;
        }

    }

}
