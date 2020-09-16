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
        public int[] ship;

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
            //place ships
            PlaceShips(players[0]);
            PlaceShips(players[1]);
                //player 1 empty grid(hit/miss)
            //player 2 ship grid
                //place ships
                //player 2 hit/miss grid
        }


        public void PlaceShips(Player player)
        {
            PlaceDestroyer(player);
            PlaceSubmarine(player);
            PlaceBattleship(player);

            //ship = display.AskForShipLocation();
            //int direction = display.AskForShipDirection();
            //player.PlaceShip(ship, direction, player);

        }

        public void PlaceDestroyer(Player player)
        {
            Destroyer destroyer = new Destroyer();
            ship = display.AskForShipLocation(destroyer);
            int direction = display.AskForShipDirection();
            player.PlaceShip(ship, direction, player, destroyer);
        }

        public void PlaceSubmarine(Player player)
        {
            Submarine submarine = new Submarine();
            ship = display.AskForShipLocation(submarine);
            int direction = display.AskForShipDirection();
            player.PlaceShip(ship, direction, player, submarine);
        }

        public void PlaceBattleship(Player player)
        {
            Battleship battleship = new Battleship();
            ship = display.AskForShipLocation(battleship);
            int direction = display.AskForShipDirection();
            player.PlaceShip(ship, direction, player, battleship);

        }

        
    }
}
