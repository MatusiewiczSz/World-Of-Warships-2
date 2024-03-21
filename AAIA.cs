using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorldOfWarships2
{
    internal class AAIA
    {
        public static void Play()
        {
            Player player1 = new Player(1);
            Player AI = new Player(3);
            Game game = new Game();

            while (true)
            {
                game.SetCurrentPlayer(player1, AI);
                game.DeployShips();      
                game.PlayersSwitch();    
                game.TeamChange();    
                game.ShipsForAI();    
                Console.Clear();

                while (game.IsWon(player1, AI) == false)
                {
                    game.ContinueOnEnter();      
                    game.PlayersSwitch();    
                    game.TeamChange();    
                    game.Fire();    
                    game.PlayersSwitch();    
                    game.TeamChange();    
                    game.AIFire();
                }
                if (player1.amountOfShips == 0)
                {
                    Console.WriteLine("The English Came Out On Top!");
                    AI.win++;
                }
                else  
                {  
                    Console.WriteLine("Truly A Beautiful, Glorious Victory It Was For Player's Fleet.");  // u :3 //  
                    player1.win++;  
                }  

                Console.Write("Current ratio: \nPlayer: " + player1.win + "\nComputer: " + AI.win + "\nIf you want to play again press ENTER: \n");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
