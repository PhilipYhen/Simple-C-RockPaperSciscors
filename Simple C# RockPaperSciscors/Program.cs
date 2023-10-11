using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace RockPaperSciscors;

public static class Program
{
    private static string[] validMoves = new string[] { "Rock", "Paper", "Sciscors" };
    private static string RandomMove()

    {
        Random random = new Random();
        return validMoves[random.Next(0, validMoves.Length)];
    }
    private static string playerMove;
    private static string computerMove;
    public static void Main()
    {
        StartGame(); //Initiates the game		
    }

    private static void StartGame(bool sleep = false) // Called to start or to restart the game
    {
        Console.Clear(); // Clears the Console
        playerMove = null; // We clean the previous moves
        computerMove = null;
        if (sleep)
            System.Threading.Thread.Sleep(1000);

        Console.WriteLine("Choose: Rock, Paper, or Sciscors\n");
        playerMove = PlayerMoveInput(); // User Move Input
        Console.WriteLine("\nYour Choice: " + playerMove + "\n");
        computerMove = RandomMove();
        Console.WriteLine("Computer's Choice: " + computerMove + "\n");

        EvaluateMove();
    }

    private static string PlayerMoveInput()
    {
        string inputMove = Console.ReadLine();

        for (int i = 0; i < validMoves.Length; i++)
        {
            if (validMoves[i] == inputMove)
                return inputMove;
        }
        return HandleWrongPlayerInput();
    }

    private static string HandleWrongPlayerInput()
    {
        Console.WriteLine("\nInvalid Input! Please check the spelling and retry again.\n");
        return PlayerMoveInput();
    }

    private static void EvaluateMove() //Decides whether the player wins or lose
    {
        if (playerMove == computerMove)
        {
            Console.WriteLine("\nIt is a Tie!\n");
        }
        else if (playerMove == "Rock" && computerMove == "Paper")
        {
            Console.WriteLine("\nYou lost! Paper beats Rock\n");
        }
        else if (playerMove == "Rock" && computerMove == "Sciscors")
        {
            Console.WriteLine("\nYou Won! Rock beats Sciscors\n");
        }
        else if (playerMove == "Paper" && computerMove == "Rock")
        {
            Console.WriteLine("\nYou Won! Paper beats Rock\n");
        }
        else if (playerMove == "Paper" && computerMove == "Sciscors")
        {
            Console.WriteLine("\nYou Lost! Sciscors beats Paper\n");
        }
        else if (playerMove == "Sciscors" && computerMove == "Paper")
        {
            Console.WriteLine("\nYou Won! Sciscors beats Paper\n");
        }
        else if (playerMove == "Sciscors" && computerMove == "Rock")
        {
            Console.WriteLine("\nYou Lost! Rock beats Sciscors\n");
        }

        RestartGame();
    }

    private static void RestartGame()
    {
        System.Threading.Thread.Sleep(3000);
        StartGame(true);

    }
}