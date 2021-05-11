using System;
using System.Threading;

namespace TicTacToe_Project
{
    class Program
    {
        static void DrawAlert(string alert)
        {
            float alertLenght = alert.Length / 2f;
            Console.WriteLine("############################################");
            Console.WriteLine("#                                          #");
            Console.Write("#");
            for (int i = 0; i < 21 - Math.Floor(alertLenght); i++) Console.Write(" ");
            Console.Write(alert);
            for (int i = 0; i < 21 - Math.Ceiling(alertLenght); i++) Console.Write(" ");
            Console.Write("#\n");
            Console.WriteLine("#                                          #");
            Console.WriteLine("############################################");
        }

        static void DrawScore(int round, string player1, string player2, int[] score)
        {
            Console.WriteLine("#                     #                    #");
            Console.Write("#");
            float playerLenght = player1.Length / 2f;
            for (int i = 0; i < 10 - Math.Floor(playerLenght); i++) Console.Write(" ");
            Console.Write(player1);
            for (int i = 0; i < 11 - Math.Ceiling(playerLenght); i++) Console.Write(" ");
            Console.Write("#");
            playerLenght = player2.Length / 2f;
            for (int i = 0; i < 10 - Math.Floor(playerLenght); i++) Console.Write(" ");
            Console.Write(player2);
            for (int i = 0; i < 10 - Math.Ceiling(playerLenght); i++) Console.Write(" ");
            Console.Write("#\n");
            Console.WriteLine("#                     #                    #");
            Console.WriteLine("#          " + score[0] + "          #          " + score[1] + "         #");
            Console.WriteLine("#                     #                    #");
            Console.WriteLine("############################################");
        }

        static void DrawBoard(char[] activeBoard)
        {
            Console.WriteLine("############################################");
            Console.WriteLine("#             #              #             #");
            Console.WriteLine("#      " + activeBoard[0] + "      #       " + activeBoard[1] + "      #      " + activeBoard[2] + "      #");
            Console.WriteLine("#             #              #             #");
            Console.WriteLine("############################################");
            Console.WriteLine("#             #              #             #");
            Console.WriteLine("#      " + activeBoard[3] + "      #       " + activeBoard[4] + "      #      " + activeBoard[5] + "      #");
            Console.WriteLine("#             #              #             #");
            Console.WriteLine("############################################");
            Console.WriteLine("#             #              #             #");
            Console.WriteLine("#      " + activeBoard[6] + "      #       " + activeBoard[7] + "      #      " + activeBoard[8] + "      #");
            Console.WriteLine("#             #              #             #");
            Console.WriteLine("############################################");
        }

        static string WinChecker(char[] activeBoard)
        {
            for (int i = 0; i < 3; i++)
            {
                if (activeBoard[i] == 'X' & activeBoard[i + 3] == 'X' & activeBoard[i + 6] == 'X') return "vict1";
                if (activeBoard[i] == 'O' & activeBoard[i + 3] == 'O' & activeBoard[i + 6] == 'O') return "vict2";
            }
            for (int i = 0; i < 7; i += 3)
            {
                if (activeBoard[i] == 'X' & activeBoard[i + 1] == 'X' & activeBoard[i + 2] == 'X') return "vict1";
                if (activeBoard[i] == 'O' & activeBoard[i + 1] == 'O' & activeBoard[i + 2] == 'O') return "vict2";
            }
            if (((activeBoard[2] == 'X' & activeBoard[6] == 'X') || (activeBoard[0] == 'X' & activeBoard[8] == 'X')) & activeBoard[4] == 'X') return "vict1";
            if (((activeBoard[2] == 'O' & activeBoard[6] == 'O') || (activeBoard[0] == 'O' & activeBoard[8] == 'O')) & activeBoard[4] == 'O') return "vict2";
            for (int i = 0; i < 9; i++)
            {
                if (activeBoard[i] != 'X' & activeBoard[i] != 'O') return "cont";
            }
            return "draw";
        }

        static void Main(string[] args)
        {
            char[] startBoard = { '1', '2', '3' ,'4', '5', '6', '7', '8', '9' };
            char[] activeBoard;
            string command;
            bool play = true;
            var rand = new Random();
            while (play)
            {
                Console.Clear();
                DrawAlert("Tic Tac Toe");
                Console.WriteLine("\n\n                Start");
                Console.WriteLine("                Exit\n\n");
                command = Console.ReadLine();
                switch (command)
                {
                    case "Start":
                        Console.Clear();
                        string[] player = new string[2]; 
                        for (int i = 0; i != 2;)
                        {
                            if (i == 0) DrawAlert("Enter 1st player's name");
                            else DrawAlert("Enter 2nd player's name");
                            player[i] = Console.ReadLine();
                            if (player[i] == null || player[i] == "")
                            {
                                player[i] = "Player " + (i + 1);
                                i++;
                            }
                            else if (player[i].Length > 15)
                            {
                                Console.Clear();
                                DrawAlert("Please enter a shorter name.");
                                Thread.Sleep(2000);
                            }
                            else i++;
                            Console.Clear();

                        }
                        int[] score = { 0, 0 };
                        for (int round = 1; ; round++)
                        {
                            activeBoard = startBoard.Clone() as Char[];
                            int firstMove = rand.Next(1, 3);
                            for (int move = firstMove; ; move++)
                            {
                                Console.Clear();
                                if (move % 2 == 0) DrawAlert(player[0] + "'s move!");
                                else DrawAlert(player[1] + "'s move!");
                                DrawScore(round, player[0], player[1], score);
                                DrawBoard(activeBoard);
                                int moveCord = 0;
                                while (true)
                                {
                                    string temp = Console.ReadLine();
                                    bool breaker = false;
                                    if (temp.Length == 1)
                                    {
                                        for (int i = 0; i < 9; i++)
                                        {
                                            if (temp[0] == activeBoard[i])
                                            {
                                                moveCord = Convert.ToInt32(temp) - 1;
                                                breaker = true;
                                                break;
                                            }
                                        }
                                        if (breaker) break;
                                        else
                                        {
                                            Console.Clear();
                                            DrawAlert("Please input valid coordinates!");
                                            DrawScore(round, player[0], player[1], score);
                                            DrawBoard(activeBoard);
                                        }
                                    }
                                    if (breaker) break;
                                    else
                                    {
                                        Console.Clear();
                                        DrawAlert("Please input valid coordinates!");
                                        DrawScore(round, player[0], player[1], score);
                                        DrawBoard(activeBoard);
                                    }
                                }
                                if (move % 2 == 0) activeBoard[moveCord] = 'X';
                                else activeBoard[moveCord] = 'O';
                                DrawBoard(activeBoard);
                                if (WinChecker(activeBoard) != "cont") break;
                            }
                            Console.Clear();
                            if (WinChecker(activeBoard) == "draw")
                            {
                                DrawAlert("Round ended in a draw!");
                            }
                            else if (WinChecker(activeBoard) == "vict1")
                            {
                                DrawAlert(player[0] + " won this round!");
                                score[0] += 1;
                            }
                            else
                            {
                                DrawAlert(player[1] + " won this round!");
                                score[1] += 1;
                            }
                            DrawScore(round, player[0], player[1], score);
                            DrawBoard(activeBoard);
                            DrawAlert("Do you want to continue? (Y/N)");
                            if (Console.ReadLine() != "Y") break;
                        }
                        break;

                    case "Exit":
                        Console.Clear();
                        DrawAlert("Exitting...");
                        Thread.Sleep(1000);
                        play = false;
                        break;

                    default:
                        Console.Clear();
                        DrawAlert("Unknown Command!");
                        Thread.Sleep(2000);
                        break;
                }
            }
            Environment.Exit(0);
        }
    }
}
