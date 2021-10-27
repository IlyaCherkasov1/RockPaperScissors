using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissors.Rule;

namespace RockPaperScissors
{
    class Game
    {
        private Rule rule;
        private string computerMove;
        private string key;
        private string hmac;

        public void Start(string[] args)
        {
            rule = new Rule(args);
            GameHelper gameHelper = new GameHelper(rule);
            gameHelper.CheckArgumentsData(args);

            while (true)
            {
                computerMove = gameHelper.GenerateComputerMove();
                key = KeyGenerator.GenerateKey();
                hmac = HMACGenerator.HashHMACHex(key, computerMove);
                Console.WriteLine($"HMAC: {hmac}");

                gameHelper.ShowGameMenu();
                string playerMove = gameHelper.GenerateUserMove();
                gameHelper.GenerateResultUserInformation(playerMove, computerMove);
                Console.WriteLine($"HMAC key: {key}");
                Console.WriteLine("================================================================");
                Console.WriteLine();
            }

        }

    }
}
