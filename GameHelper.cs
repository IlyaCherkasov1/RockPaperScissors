using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissors.Rule;

namespace RockPaperScissors
{
    class GameHelper
    {
        private Rule rule;
      

        public GameHelper(Rule rule)
        {
            this.rule = rule;
        }

        public void GenerateResultUserInformation(string playerMove, string computerMove)
        {
            Console.WriteLine();
            Console.WriteLine($"you move: {playerMove}");
            Console.WriteLine($"computer move: {computerMove}");

            switch (rule.GetGameResult(playerMove, computerMove))
            {
                case GameResult.Win:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("you won!");
                    break;
                case GameResult.Lose:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lose!");
                    break;
                case GameResult.Draw:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("draw!");
                    break;

            }
            Console.ResetColor();
        }

        public string GenerateUserMove()
        {
            string playerMove;
            while (true)
            {
                Console.Write("select menu item: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {

                    if (number >= 0 && number <= rule.gameElements.Length - 1)
                    {
                        playerMove = rule.gameElements[number];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("no such menu item");
                        Console.WriteLine();
                    }
                }

                if (input == "?")
                {
                    ShowGameHelp();
                }
            }

            return playerMove;
        }

        public void CheckArgumentsData(string[] args)
        {
            if (!IsAmountOfElementsValid(args) || !IsNoDublicateElementsValid(args))
            {
                Console.WriteLine("Сheck the correctness of the arguments");
                Environment.Exit(0);
            }
        }

        public void ShowGameHelp()
        {
            OutputRules.CreateGameTableRules(rule);
        }

        public void ShowGameMenu()
        {
            Console.WriteLine();
            for (var i = 0; i < rule.gameElements.Length; i++)
            {
                Console.WriteLine($"{i}. {rule.gameElements[i]}");
            }
            Console.WriteLine("?. help");
            Console.WriteLine();
        }

        public string GenerateComputerMove()
        {
            int index = RandomNumberGenerator.GetInt32(0, rule.gameElements.Length);
            string computerMove = rule.gameElements[index];
            return computerMove;
        }

        private  bool IsAmountOfElementsValid(string[] moves)
        {
            if (moves.Length % 2 == 0 || moves.Length < 3)
            {
                return false;
            }
            return true;
        }

        private  bool IsNoDublicateElementsValid(string[] moves)
        {
            if (moves.GroupBy(m => m).Any(m => m.Count() > 1))
            {
                return false;
            }
            return true;
        }

    }
}
