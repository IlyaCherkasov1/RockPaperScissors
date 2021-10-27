using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Rule
    {
        public string[] gameElements { get; }
        private readonly GameResult[,] gamerules;

        public Rule(string[] posibleMoves)
        {
            gameElements = posibleMoves;
            int delta = posibleMoves.Length / 2;

            gamerules = new GameResult[posibleMoves.Length, posibleMoves.Length];
            for (var i = 0; i < posibleMoves.Length; i++)
            {
                gamerules[i, i] = GameResult.Draw;
                for (var j = 0; j < 2 * delta; j++)
                    gamerules[i, (i + j + 1) % posibleMoves.Length] =
                        j < delta ? GameResult.Lose : GameResult.Win;
            }
        }

        public GameResult GetGameResult(string playerMove, string pcMove)
        {
            if (!gameElements.Contains(playerMove) || !gameElements.Contains(pcMove))
                throw new Exception();

            int index1 = Array.IndexOf(gameElements, playerMove);
            int index2 = Array.IndexOf(gameElements, pcMove);

            return gamerules[index1, index2];
        }
    }

 
}
