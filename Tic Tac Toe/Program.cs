using BoardLogic;
using System;

namespace TicTacToe;

class Program
{
    static Board game = new Board();
    static void Main(string[] args)
    {
        int userTurn = -1;
        int computerTurn = -1;

        Random rand = new Random(); // random is type, like int
        //keep playing untill someone wins
        while (game.checkForWinner() == 0) 
        {
            //get valid input from the user
            while (userTurn == -1 || game.Grid[userTurn] != 0)
            {
                Console.WriteLine("Please enter a number from 0 to 8");
                userTurn = int.Parse(Console.ReadLine());
                Console.WriteLine($"You typed {userTurn}");
            }

            game.Grid[userTurn] = 1;

            if (game.isBoardFull())
                break;

            //don't let the computer pick an invalid number
            //get a random move from the computer
            while (computerTurn == -1 || game.Grid[computerTurn] != 0) 
            {
                computerTurn = rand.Next(9);
                Console.WriteLine($"Computer chooses {computerTurn}");
            }
            game.Grid[computerTurn] = 2;

            if (game.isBoardFull())
                break;
            //show the board
            printBoard();
        }
        //while is done
        Console.WriteLine($"The game is over. Player {game.checkForWinner()} is the winner!");
        Console.ReadLine();
         
    }
    
    

    private static void printBoard()
    {
        for (int i = 0; i < game.Grid.Length; i++)
        {
            // Console.WriteLine("Square " + i + " contains " + board[i]);
            // Console.WriteLine($"Square {i} contains {board[i]}");
            // print x or o for each square
            // 0 means unoccupied. 1 means player 1(x), 2 means player 2 (o)

            if (game.Grid[i] == 0)
            {
                Console.Write(".");
            }
            if (game.Grid[i] == 1)
            {
                Console.Write("x");
            }
            if (game.Grid[i] == 2)
            {
                Console.Write("o");
            }
            // print a new line every 3rd character
            if (i == 2 || i == 5 || i == 8)
            {
                Console.WriteLine();
            }
        }
    }
}

