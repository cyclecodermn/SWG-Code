using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Player
    {
        internal static object Board;
        public Board board = new Board();
        public string name { get; set; }

        public Player(int PlayerNum)
        {
            name = ConsoleIO.SetName(PlayerNum);
            //ShipSetup();
            AutoShipSetup();
        }

        public FireShotResponse Fire()
        {
            Coordinate newShotCoor = ConsoleIO.GetCoord();

            FireShotResponse CkShot = this.board.FireShot(newShotCoor);

            return CkShot;

        }

        public void AutoShipSetup()
        {
            int xCoord = 1;
            ShipDirection autoDirection = new ShipDirection();

            autoDirection = ShipDirection.Down;

            //User starting with b has ships on the bottom going up.
            if (name.Substring(0, 1) == "b")
            {
                xCoord = 10;
                autoDirection = ShipDirection.Up;
            }

            for (int i = 0; i < 5; i++)
            {
                // Console.WriteLine($"Place your {Enum.GetName(typeof(ShipType), (ShipType)i)}.");

                PlaceShipRequest shipPlaceFromCode = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(xCoord, i + 1),
                    Direction = autoDirection,
                    ShipType = (ShipType)i
                };

                ShipPlacement spotValidity = board.PlaceShip(shipPlaceFromCode);
                switch (spotValidity)
                {
                    case ShipPlacement.NotEnoughSpace:
                        i--;
                        Console.WriteLine("Not enough Space to place a ship there!");
                        continue;
                    case ShipPlacement.Overlap:
                        i--;
                        Console.WriteLine("This spot overlaps with another ship!");
                        break;
                    case ShipPlacement.Ok:
                        Console.WriteLine("Ship placement works!");
                        break;
                    default:
                        break;
                }
            }
            ConsoleIO.Continue();

        }


        public void ShipSetup()
        {
            Console.WriteLine($"Alright {name}, lets setup your ships.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Place your {Enum.GetName(typeof(ShipType), (ShipType)i)}.");

                PlaceShipRequest shipPlaceFromUsr = new PlaceShipRequest()
                {
                    Coordinate = ConsoleIO.GetCoord(),
                    Direction = ConsoleIO.GetDirection(),
                    ShipType = (ShipType)i
                };

                ShipPlacement spotValidity = board.PlaceShip(shipPlaceFromUsr);
                switch (spotValidity)
                {
                    case ShipPlacement.NotEnoughSpace:
                        i--;
                        Console.WriteLine("Not enough Space to place a ship there!");
                        continue;
                    case ShipPlacement.Overlap:
                        i--;
                        Console.WriteLine("This spot overlaps with another ship!");
                        break;
                    case ShipPlacement.Ok:
                        Console.WriteLine("Ship placement works!");
                        break;
                    default:
                        break;
                }
            }
            ConsoleIO.Continue();
        }

        public Board playerBoard
        {
            get
            {
                return board;
            }
        }

    }
}
