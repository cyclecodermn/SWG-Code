using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class ConsoleIO
    {

        public static void IntroScreen()
        {

            Console.WriteLine("                                     |__");
            Console.WriteLine("                                     |\\/");
            Console.WriteLine("                                     ---");
            Console.WriteLine("                                     / | [");
            Console.WriteLine("                              !      | |||");
            Console.WriteLine("                            _/|     _/|-++'");
            Console.WriteLine("                        +  +--|    |--|--|_ |-");
            Console.WriteLine("                     { /|__|  |/\\__|  |--- |||__/");
            Console.WriteLine("                    +---------------___[}-_===_.'____                 /\\");
            Console.WriteLine("                ____`-' ||___-{]_| _[}-  |     |_[___\\==--            \\/   _");
            Console.WriteLine(" __..._____--==/___]_|__|_____________________________[___\\==--____,------' .7");
            Console.WriteLine("|                                                                     BB-61/");
            Console.WriteLine(" \\_________________________________________________________________________|");
            Console.WriteLine("    ASCII art drawing ©  Matthew Bace, http://ascii.co.uk/art/battleship/.");
            Console.WriteLine("");
            Console.WriteLine("                          Welcome to Battleship.");
            Console.WriteLine("");
            Console.WriteLine("    This game follows the rules of the traditional Battleship boardgame.");
            Console.WriteLine("    There will be two players, but the comptuer will do all the scoring.");
            Console.WriteLine("    Here's how it works:");
            Console.WriteLine("      1) Each player will enther his or her name.");
            Console.WriteLine("      2) Each player will set 5 ships.");
            Console.WriteLine("      3) A player will be randomly selected to start.");
            Console.WriteLine("      4) Players take turns entering coordinates for their next.");
            Console.WriteLine("      5) The game continues until one player sinks all the ships of the other.");
            Console.WriteLine("");
            Console.WriteLine("                       Press Enter to being the game.");
            Console.ReadLine();
            Console.Clear();
                       
        }

        public static void DrawBoard(Player crntPlayer, Player otherPlayer)
        {
            Console.Clear();
            Console.WriteLine("Board for " + crntPlayer.name);
            Console.WriteLine("- - - - - - - - - - -");
            Console.WriteLine();
            Console.Write("In the board below, ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("H");
            Console.ResetColor();
            Console.Write(" shows a hit, and ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("W");
            Console.ResetColor();
            Console.WriteLine(" shows a miss.");
            Console.ResetColor();

            Console.WriteLine();

            string Letters = "ABCDEFGHIJ";
            Console.Write(" ");
            for (int row1 = 1; row1 <= 10; row1++) { Console.Write(" " + row1); }
            Console.WriteLine();

            string otherBoard = "";
            string crntXY;

            for (int x = 1; x <= 10; x++)
            {
                Console.Write(Letters.Substring(x - 1, 1) + " ");
                for (int y = 1; y <= 10; y++)
                {
                    //int a=currentCoord.XCoordinate;
                    Coordinate currentCoord = new Coordinate(x, y);
                    otherBoard = otherPlayer.playerBoard.CheckCoordinate(currentCoord).ToString();
                    crntXY = otherBoard.Substring(0, 1);


                    switch (crntXY)
                    {
                        case "U":
                            crntXY = ".";
                            //    Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case "H":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }

                    Console.Write(crntXY + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public static string SetName(int PlayerNum)
        {
            Console.Write($"What's the name of Player {PlayerNum}? ");
            return Console.ReadLine();
        }

        public static void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static Coordinate GetCoord()
        {
            Console.Write("Input a cordinate (Letter a-j and number 1-10). :");
            string cordInput;
            char letterCoord;
            string numberCoord;
            int yCoord;
            int xCoord;

            do
            {
                cordInput = Console.ReadLine();
                if (cordInput.Length > 3 || cordInput.Length <= 1)
                {
                    Console.WriteLine("You typed less than zero charaters or more than 3, please try again.");
                    continue;
                }
                else
                {
                    letterCoord = cordInput.ToUpper().ToCharArray()[0];
                    yCoord = letterCoord - 'A' + 1;
                    if (yCoord > 10 || yCoord < 1)
                    {
                        Console.WriteLine("Your letter is not between a-j, please try again.");
                        continue;
                    }

                    numberCoord = cordInput.Substring(1);
                    if (!int.TryParse(numberCoord, out xCoord))
                    {
                        Console.WriteLine("The number at the end of your coordinates is wrong, please try again.");
                        continue;
                    }
                    else
                    {
                        if (xCoord > 10 || xCoord < 1)
                        {
                            Console.WriteLine("Your number is not between 1-10, please try again.");
                            continue;
                        }
                    }
                }
                break;
            } while (true);

            return new Coordinate(yCoord, xCoord);
        }

        public static ShipDirection GetDirection()
        {
            ConsoleKeyInfo input;
            char direction;
            do
            {
                Console.WriteLine("Input direction(W,A,S,D)");
                input = Console.ReadKey();
                Console.WriteLine();
                direction = input.KeyChar;
                switch (direction)
                {
                    case 'w':
                    case 'W':
                        return ShipDirection.Up;
                    case 'd':
                    case 'D':
                        return ShipDirection.Right;
                    case 's':
                    case 'S':
                        return ShipDirection.Down;
                    case 'a':
                    case 'A':
                        return ShipDirection.Left;
                    default:
                        Console.WriteLine("Invalid input.");
                        continue;
                }
            } while (true);

        }

        public static bool AskToPlayAgain()
        {
            bool keepPlaying = true;
            Console.WriteLine("Would you like to play again? (y/n)");
            string answer=  Console.ReadLine();
            if (answer=="y"|| answer=="Y")
            {
                //GameFlow g = new GameFlow();
                //g.Run();
            }
            else
            {
                keepPlaying = false;
                Console.WriteLine("Thanks for playing Battleship.");
                Continue();
            }
            return keepPlaying;
        }
    }
}
