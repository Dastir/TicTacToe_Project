using System;
using System.Threading;

namespace TicTacToe_Project
{
    class Program
    {
        static void DrawAlert(string alert)
        {
            float alertLength = alert.Length / 2;
            Console.WriteLine("############################################");
            Console.WriteLine("#                                          #");
            Console.Write("#");
            for (int i = 0; i < 20 - Math.Floor(alertLength); i++) Console.Write(" ");
            Console.Write(alert);
            for (int i = 0; i < 21 - Math.Ceiling(alertLength); i++) Console.Write(" ");
            Console.Write("#\n");
            Console.WriteLine("#                                          #");
            Console.WriteLine("############################################");
        }

        static void Main(string[] args)
        {
            char[,] startBoard = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            char[,] activeBoard = startBoard.Clone() as Char[,];
            string command;
            bool play = true;
            while (play)
            {
                Console.Clear();
                DrawAlert("Tic Tac Toe");
                Console.WriteLine("\n\n                Start");
                Console.WriteLine("                Exit\n\n");
                command = Console.ReadLine();
                switch(command)
                {
                    case "Start":
                        break;

                    case "Exit":
                        Console.Clear();
                        DrawAlert("Exitting...");
                        Thread.Sleep(2000);
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
