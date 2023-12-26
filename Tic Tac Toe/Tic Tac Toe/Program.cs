using System;
namespace Tic_Tac_Toe{
    class Program {
        static string[] board = new string[9];
        static int SquaresFree = 9, player = 0;
        public static void Main(string[] args)
        {
            Setup();
            int choice;
            while (true) {
                DrawBoard();
                if (PlayerWon()) {
                    Console.WriteLine($"Congratulations, Player {player+1}, you won!");
                    GameOver();
                }
                if (SquaresFree == 0)
                {
                    Console.WriteLine("Game was a Draw.");
                    GameOver();
                }
                player = (player + 1) % 2;
                //Choosing Logic.
                while (true)
                {
                    Console.WriteLine($"Player {player + 1} choose a field from 1-9");
                    if (Int32.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9)
                    {
                        if (Execute(choice)) 
                            break;
                        else
                            Console.WriteLine("Field already taken. Choose somewhere else.");
                    }

                    else {
                        Console.WriteLine($"Player {player+1}, you cannot choose that.");
                    }
                }
                
            }
        }
        public static void GameOver() {
            Console.WriteLine("Game Over, Press any key to reset.");
            Console.ReadKey();
            Setup();
            DrawBoard();
        }
        public static bool PlayerWon() {
            for (int i = 0; i < 9; i+=3) {
                //Horizontal Check
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2]) 
                    return true;
                //Vertical Check
                if (board[(i / 3)] == board[(i / 3) + 3] && board[(i / 3) + 3] == board[(i / 3) + 6]) 
                    return true;
            }
            if (board[0] == board[4] && board[4] == board[8])
                return true;
            if (board[2] == board[4] && board[4] == board[6])
                return true;

            return false;
        }
        //Executing what the player chose.
        public static bool Execute(int choice) {
            if (Int32.TryParse(board[choice - 1], out _))
            {
                switch (player)
                {
                    case 0:
                        board[choice - 1] = "X";
                        break;
                    case 1:
                        board[choice - 1] = "O";
                        break;
                }
                SquaresFree--;
                return true;
            }
            return false;
        }
        public static void DrawBoard() {
            int CurrentField = 0;
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (j == 1)
                        {
                            if (k != 2)
                                Console.Write($"  {board[CurrentField++]}  |");
                            else
                                Console.Write($"  {board[CurrentField++]}  ");
                        }
                        else
                        {
                            if (k != 2)
                                Console.Write($"     |");
                            else
                                Console.Write("     ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-----|-----|-----");
            }
        }
        public static void Setup() {
            player = -1;
            SquaresFree = 9;
            for (int i = 0; i < 9; i++) {
                board[i] = (i+1).ToString();
            }
        }
    }
    }