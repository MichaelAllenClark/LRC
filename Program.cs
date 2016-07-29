using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRC
{
    class Program
    {
        static void Main(string[] args)
        {
            Int16 MinPlayers = 3;
            Int16 MaxPlayers = 12;
            Int32 Interations = 1000000;
            Int16 CurrentIterationPlayers = MinPlayers;

            while (CurrentIterationPlayers <= MaxPlayers)
            {

                Int32 TotalTurns = 0;
                Int32 TotalFinalToken = 0;
                Int32 TimesReturnedFromZero = 0;
                Int32 TimesHighTokenCountLost = 0;
                Int32 i = Interations;
                Dictionary<Int32, Int32> PlayerWinTotals = new Dictionary<Int32, Int32>();

                for (Int32 pwt = 0; pwt < CurrentIterationPlayers; pwt += 1)
                    PlayerWinTotals.Add(pwt, 0);

                while (i > 0)
                {
                    var game = new Game(CurrentIterationPlayers, 3);
                    while (game.Winner == null)
                    {
                        game.PlayNextTurn();
                    }
                    TotalTurns += game.NumberOfTurns;
                    TotalFinalToken += game.Winner.NumberOfTokens;
                    if (game.Winner.LowestTokens == 0)
                        TimesReturnedFromZero++;
                    if (PlayerWinTotals.ContainsKey(game.Winner.PlayerID))
                        PlayerWinTotals[game.Winner.PlayerID]++;
                    else
                        PlayerWinTotals.Add(game.Winner.PlayerID, 1);
                    if (game.HighestTokenPlayerID != game.Winner.PlayerID)
                        TimesHighTokenCountLost++;

                    i--;
                }
                Console.WriteLine("For " + CurrentIterationPlayers.ToString() + " players with " + Interations.ToString() + " iterations");
                Console.WriteLine("Average Number of Turns: " + (Convert.ToDecimal(TotalTurns) / Convert.ToDecimal(Interations)).ToString());
                Console.WriteLine("Average Number of Tokens at end: " + (Convert.ToDecimal(TotalFinalToken) / Convert.ToDecimal(Interations)).ToString("0.0000"));
                Console.WriteLine("Chances of returning from zero: " + ((Convert.ToDecimal(TimesReturnedFromZero) / Convert.ToDecimal(Interations)) * 100).ToString("0.0000") + "%");
                Console.WriteLine("Chances of losing even if you had the most tokens at some point: " + ((Convert.ToDecimal(TimesHighTokenCountLost) / Convert.ToDecimal(Interations)) * 100).ToString("0.0000") + "%");

                Decimal? HighestChanceOfWin = null;
                Int32 HighestPositionNumber = 0;
                foreach (KeyValuePair<Int32, Int32> kvp in PlayerWinTotals)
                {
                    Decimal ChanceOfWin = (Convert.ToDecimal(kvp.Value) / Convert.ToDecimal(Interations));
                    Decimal percentageOfPlayerPool = (Convert.ToDecimal(1) / Convert.ToDecimal(CurrentIterationPlayers));

                    Console.WriteLine("Chances of winning if player: " + kvp.Key.ToString() + " are " + (ChanceOfWin * 100).ToString("0.000") + "%, Diff: " + ((ChanceOfWin - percentageOfPlayerPool) * 100).ToString("0.0000") + "%");
                    if (HighestChanceOfWin == null || HighestChanceOfWin < ChanceOfWin)
                    {
                        HighestChanceOfWin = ChanceOfWin;
                        HighestPositionNumber = kvp.Key;
                    }
                }
                Console.WriteLine("Highest Chance of Winning is position: " + (HighestPositionNumber+1).ToString());
                CurrentIterationPlayers++;
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
