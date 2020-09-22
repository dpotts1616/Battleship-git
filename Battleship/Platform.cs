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
            players.Add(new Player("Player 1"));
            players.Add(new Player("Player 2"));
        }

        //methods
        //run game
        public void PlayBattleship()
        {
            display.WelcomeScreen();
            SetUpBoard(players[0]);
            SetUpBoard(players[1]);
            string winner = RunAttackRounds(players[0], players[1]);
            display.DeclareWinner(winner);
        }


        public void SetUpBoard(Player player)
        {
            do
            {
                PlaceDestroyer(player);
                PlaceSubmarine(player);
                PlaceBattleship(player);
                if (CountGrid(player.grids[0].gridArray, "O") > 391)
                {
                    player.grids.Remove(player.grids[0]);
                    player.grids.Insert(0, new Grid("Ship Grid"));
                }
            } while (CountGrid(player.grids[0].gridArray, "O") > 391);

        }

        public void PlaceDestroyer(Player player)
        {
            Destroyer destroyer = new Destroyer();
            display.PrintBoard(player.grids[0], player);
            GetShipInfo(player, destroyer);
        }

        public void PlaceSubmarine(Player player)
        {
            Submarine submarine = new Submarine();
            display.PrintBoard(player.grids[0], player);
            GetShipInfo(player, submarine);
        }

        public void PlaceBattleship(Player player)
        {
            Battleship battleship = new Battleship();
            display.PrintBoard(player.grids[0], player);
            GetShipInfo(player, battleship);

        }

        public void GetShipInfo(Player player, Ship ship)
        {
            placement = display.AskForShipLocation(ship, player);
            int direction = display.AskForShipDirection(placement, ship, player);
            player.PlaceShip(placement, direction, player, ship);
        }

        public int CountGrid(string[,] gridArray, string identifier)
        {
            int count = 0;
            for (int r = 1; r < 21; r++)
            {
                for (int c = 1; c < 21; c++)
                {
                    if (gridArray[r, c] == identifier)
                    {
                        count++;
                    }
                }
            }
            return count;
        }


        public string RunAttackRounds(Player player1, Player player2)
        {
            bool playerOneturn = true;
            do
            {
                if (playerOneturn == true)
                {
                    PlayerTurn(player1, player2);
                }
                else
                {
                    PlayerTurn(player2, player1);
                }
                playerOneturn = !playerOneturn;
            } while (TotalGrid(player1) < 400 && TotalGrid(player2) < 400);
            if(TotalGrid(player1) < TotalGrid(player2))
            {
                return player1.name;
            }
            else { return player2.name; }
        }

        public void PlayerTurn(Player attackPlayer, Player defendPlayer)
        {
            display.SwitchPlayers(attackPlayer);
            display.PrintBoard(attackPlayer.grids[0], attackPlayer);
            Console.ReadLine();
            display.PrintBoard(attackPlayer.grids[1], attackPlayer);
            ShowEnemyShipsRemaining(defendPlayer);
            placement = display.GetTargetLocation(attackPlayer);
            bool hit = defendPlayer.CheckBoard(placement, defendPlayer);
            display.PrintAttackResult(hit);
            attackPlayer.UpdateHitBoard(placement, hit, attackPlayer);
            Console.ReadLine();
            
        }

        public void ShowEnemyShipsRemaining(Player player)
        {
            int d = CountGrid(player.grids[0].gridArray, "D");
            int s = CountGrid(player.grids[0].gridArray, "S");
            int b = CountGrid(player.grids[0].gridArray, "B");
            display.ShowEnemyShipsRemaining(d, s, b);
        }

        public int TotalGrid(Player player)
        {
            int i = (CountGrid(player.grids[0].gridArray, "O") + CountGrid(player.grids[0].gridArray, "X"));
            return i;
        }
    }
}
