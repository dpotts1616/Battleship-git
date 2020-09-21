using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Platform
    {
        //member variables
        public List<Player> players;
        public Display display;
        public int[] placement;

        //constructor
        public Platform()
        {
            display = new Display();
            players = new List<Player>();
            players.Add(new Player("player1"));
            players.Add(new Player("player2"));
        }

        //methods
        //run game
        public void PlayBattleship()
        {
            //set up board(done in constructor)
                //player 1 ship grid
            SetUpBoard(players[0]);
            //player 2 ship grid
            SetUpBoard(players[1]);

            //player 1 turn
            //print hit/miss board
            PlayerOneTurn(players[0], players[1]);
            
                //ask where to target
            

                //compare to player 2 board
                //announce hit/miss
                //update boards
                
            PrintBoard(players[0].grids[0]);
            PrintBoard(players[1].grids[0]);
        }


        public void SetUpBoard(Player player)
        {
            do
            {
                Console.Clear();
                PrintBoard(player.grids[0]);
                PlaceDestroyer(player);
                PlaceSubmarine(player);
                PlaceBattleship(player);
                if (CountGrid(player.grids[0].gridArray) > 391)
                {
                    player.grids.Remove(player.grids[0]);
                    player.grids.Insert(0, new Grid("shipGrid"));
                }
            } while (CountGrid(player.grids[0].gridArray) > 391);

        }

        public void PlaceDestroyer(Player player)
        {
            Destroyer destroyer = new Destroyer();
            GetShipInfo(player, destroyer);
        }

        public void PlaceSubmarine(Player player)
        {
            Submarine submarine = new Submarine();
            GetShipInfo(player, submarine);
        }

        public void PlaceBattleship(Player player)
        {
            Battleship battleship = new Battleship();
            GetShipInfo(player, battleship);

        }

        public void GetShipInfo(Player player, Ship ship)
        {
            placement = display.AskForShipLocation(ship, player);
            int direction = display.AskForShipDirection(placement, ship, player);
            player.PlaceShip(placement, direction, player, ship);
        }

        public void PrintBoard(Grid grid)
        {
            display.PrintBoard(grid);
        }

        public int CountGrid(string[,] gridArray)
        {
            int count = 0;
            for (int r = 1; r < 21; r++)
            {
                for (int c = 1; c < 21; c++)
                {
                    if (gridArray[r, c] == "O")
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void PlayerOneTurn(Player player1, Player player2)
        {
            PrintBoard(player1.grids[1]);
            placement = display.GetTargetLocation(player1);
            //check player 2 board
            //if target != "O"
            CheckBoard(placement, player2);
            
        }

        public void CheckBoard(int [] target, Player player)
        {
            player.CheckBoard(target, player);
        }

    }
}
