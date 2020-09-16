using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Platform
    {
        //member variables
        public List<Player> players;
        public Display display;

        //constructor
        public Platform()
        {
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
                //place ships
                //player 1 empty grid(hit/miss)
            //player 2 ship grid
                //place ships
                //player 2 hit/miss grid
        }


        public void PlaceShips(Player player)
        {

            int[] ship = display.AskForShipLocation();
            player.PlaceShip(ship);

        }

        public void PlaceDestroyer()
        {

        }

        public void PlaceSubmarine()
        {

        }

        public void PlaceBattleship()
        {

        }

        //in grid class
        public void SetUpGameBoard()
        {
            string[,] gridArray = new string[21, 21];
            gridArray[0, 0] = "0";
            string a;

            for (int i = 1; i < 21; i++)
            {
                a = Convert.ToString(i);
                gridArray[0, i] = a;
            }
            for (int i = 1; i < 21; i++)
            {
                a = Convert.ToString(i);
                gridArray[i, 0] = a;
            }

            for (int r = 1; r < 21; r++)
            {
                for (int c = 1; c < 21; c++)
                {
                    gridArray[r, c] = "O";
                }
            }

            for (int r = 0; r < gridArray.GetLength(0); r++)
            {
                for (int c = 0; c < gridArray.GetLength(1); c++)
                {
                    Console.Write(gridArray[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
