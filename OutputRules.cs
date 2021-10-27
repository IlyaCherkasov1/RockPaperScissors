using System;
using System.Data;
using DataTablePrettyPrinter;
using static RockPaperScissors.Rule;

namespace RockPaperScissors
{
    public static class OutputRules
    {
        public static void CreateGameTableRules(Rule ruleTable)
        {
            DataTable table = new DataTable("Rules");
            CreateTableColumns(ruleTable, table);
            CreateTableRows(ruleTable, table);
            Console.WriteLine(table.ToPrettyPrintedString());
        }

        private static void CreateTableColumns(Rule ruleTable, DataTable table)
        {
            table.Columns.Add("Move:", typeof(string));
            foreach (var move in ruleTable.gameElements)
            {
                table.Columns.Add(move, typeof(string));
                table.SetTitleTextAlignment(TextAlignment.Center);
            }
        }

        private static void CreateTableRows(Rule ruleTable, DataTable table)
        {
            foreach (var move in ruleTable.gameElements)
            {
                string[] data = new string[1 + ruleTable.gameElements.Length];
                data[0] = move;
                for (var j = 1; j < data.Length; j++)
                {
                    switch (ruleTable.GetGameResult(move,
                        ruleTable.gameElements[j - 1]))
                    {
                        case GameResult.Win:
                            data[j] = "Win";
                            break;
                        case GameResult.Lose:
                            data[j] = "lose";
                            break;
                        case GameResult.Draw:
                            data[j] = "Draw";
                            break;
                    }
                }
                table.Rows.Add(data);
            }
        }
    }
}
