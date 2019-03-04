using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GameFlow
    {

        public void Run()
        {
            /////////////////////////
            /// This version does not continue when players want to play again.
            ///

            ConsoleIO.IntroScreen();
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            Player switchPlayer = player1;

            Player currentPlayer = player1;
            Player otherPlayer = player2;
            string turnResult = "";

            int selectedPlayer;
            selectedPlayer = ChooseStartingPlayer(player1, player2);
            if (selectedPlayer == 1)
            {
                currentPlayer = player1;
                otherPlayer = player2;
            }
            else
            {
                currentPlayer = player2;
                otherPlayer = player1;
            }

            bool keepPlaying = true;
            do
            {
                //Switch Players
                switchPlayer = currentPlayer;
                currentPlayer = otherPlayer;
                otherPlayer = switchPlayer;

                keepPlaying = RunOneTurn(currentPlayer, otherPlayer);
                //
                // Below, use "HitAndSunk" for testing and "Victory" for real game
            } while (keepPlaying);
        }


        public int ChooseStartingPlayer(Player player1, Player player2)
        {
            bool removeThisVar;
            Random rnd = new Random();
            int startingPlayer = rnd.Next(1, 3);
            if (startingPlayer == 1)
            {
                Console.Clear();
                Console.WriteLine(player1.name + " goes first.");
                ConsoleIO.Continue();
                removeThisVar = RunOneTurn(player1, player2);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(player2.name + " goes first.");
                ConsoleIO.Continue();
                removeThisVar = RunOneTurn(player2, player1);
            }
            return startingPlayer;
        }

        public bool RunOneTurn(Player otherPlayer, Player currentPlayer)
        {
            bool keepPlaying = true;
            ConsoleIO.DrawBoard(otherPlayer, currentPlayer);

            string status = "";
            ConsoleIO.DrawBoard(otherPlayer, currentPlayer);


            FireShotResponse ckShot = currentPlayer.Fire();
            ConsoleIO.DrawBoard(otherPlayer, currentPlayer);

            status = ckShot.ShotStatus.ToString();
            Console.WriteLine(status);
            switch (ckShot.ShotStatus)
            {
                case ShotStatus.Invalid:
                    break;
                case ShotStatus.Duplicate:
                    do
                    {
                        Console.WriteLine("Enter a coordinate you have not used.");
                        ckShot = currentPlayer.Fire();
                        ConsoleIO.DrawBoard(otherPlayer, currentPlayer);

                        status = ckShot.ShotStatus.ToString();
                    } while (status=="Duplicate");
                    break;
                case ShotStatus.Miss:
                    break;
                case ShotStatus.Hit:
                    break;
                case ShotStatus.HitAndSunk:
                    string otherName = currentPlayer.name;
                    Console.WriteLine($"You sunk {otherName}'s {ckShot.ShipImpacted}!");
                    break;
                case ShotStatus.Victory:
                    ConsoleIO.DrawBoard(currentPlayer, otherPlayer);
                    Console.WriteLine(currentPlayer.name + " wins!");
                    ConsoleIO.Continue();
                    keepPlaying = ConsoleIO.AskToPlayAgain();

                    //keepPlaying = true;
                    break;
            }
            //if (status == "HitAndSunk")
            //{
            //    string otherName = currentPlayer.name;
            //    Console.WriteLine($"You sunk {otherName}'s {ckShot.ShipImpacted}!");
            //}


            //ConsoleIO.DrawBoard(currentPlayer, otherPlayer);
            //Console.WriteLine(currentPlayer.name + " wins!");
            //ConsoleIO.Continue();
            //ConsoleIO.AskToPlayAgain();


            ConsoleIO.Continue();

            return keepPlaying;
        }

    }
}
