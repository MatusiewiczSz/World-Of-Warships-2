using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarships2
{
    internal class PvP
    {     
        public static void Play()
        {    
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            Game game = new Game();

            while (true)
            {
                game.SetCurrentPlayer(player1, player2);
                game.DeployShips();
                game.PlayersSwitch();
                game.TeamChange();
                game.DeployShips();
                Console.Clear();

                while (game.IsWon(player1, player2) == false)
                {
                    game.ContinueOnEnter();
                    game.PlayersSwitch();
                    game.TeamChange();
                    game.Fire();
                }
                if (player1.amountOfShips == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("The Navy Of Player 2 Came Out Victorious Of The Thrilling Battle.");
                    player2.win++;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The Navy Of Player 1 Came Out Victorious Of The Thrilling Battle.");
                    player1.win++;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Total Victories: \n");
                Console.ForegroundColor =    ConsoleColor.Cyan;
                Console.Write("Player 1: " + player1.win);
                Console.ForegroundColor =    ConsoleColor.Magenta;
                Console.Write("\nPlayer 2: " + player2.win);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nIf you want to play again press ENTER: \n");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}  
