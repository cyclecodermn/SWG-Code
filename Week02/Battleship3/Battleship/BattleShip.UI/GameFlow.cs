using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GameFlow
    {
        Player Player1 = new Player();
        Player Player2 = new Player();
        public GameFlow()
        {

        }

        public void Run()
        {
            ConsoleIO.DrawBoard(Player1);
            Console.ReadLine();
            Console.ReadKey();

            while (true)
            {
                //check whos turn it is
                ConsoleIO.DrawBoard(Player1);
                //ask for cord for firing
                //return hit miss 
                //check if anyone won
                //clear console
                ConsoleIO.Continue();
            }
        }
    }       
}
