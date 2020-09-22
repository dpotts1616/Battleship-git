using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Display
    {
        //member variables

        //constructor

        //methods
        public void WelcomeScreen()
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("First one to sink all of the other teams ships wins!");
            Console.ReadLine();
        }

        public int[] AskForShipLocation(Ship ship, Player player)
        {
            int row;
            int column;
            int[] location = new int[2];
            do
            {
                Console.WriteLine($"Where would you like your {ship.name} to start?");
                Console.Write("Row: "); row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Column: "); column = Convert.ToInt32(Console.ReadLine());
                location[0] = row;
                location[1] = column;
                
            } while (ParameterCheck(row, column, ship, player) == false);
            return location;
        }

        public bool ParameterCheck(int row, int column, Ship ship, Player player)
        {
            bool validPlacement = true;
            if (row > (player.grids[0].boardSize - ship.length) && column > (player.grids[0].boardSize - ship.length))
            {
                validPlacement = false;
            }
            if ((row == 0 || column == 0))
            {
                validPlacement = false;
            }
            if (row > player.grids[0].boardSize || column > player.grids[0].boardSize)
            {
                validPlacement = false;
            }
            return validPlacement;
        }

        public int AskForShipDirection(int[] array,Ship ship, Player player)
        {
            bool valid = false;
            do
            {
                Console.WriteLine("Please select which direction this ship should face?");
                Console.WriteLine("1) Right");
                Console.WriteLine("2) Down");
                int direction = Convert.ToInt32(Console.ReadLine());

                switch (direction)
                {
                    case 1:
                        if((array[1] + ship.length) > player.grids[0].boardSize)
                        {
                            Console.WriteLine($"Sorry, that would put your {ship.name} outside the board");
                            break;
                        }
                        return 1;
                    case 2:
                        if ((array[0] + ship.length) > player.grids[0].boardSize)
                        {
                            Console.WriteLine($"Sorry, that would put your {ship.name} outside the board");
                            break;
                        }
                        return 2;
                    default:
                        Console.WriteLine("Sorry this is not a valid selection. Please enter 1 or 2.");
                        break;
                } 
            } while (valid == false);
            return 0;
        }

        public int[] GetTargetLocation(Player player)
        {
            int row;
            int column;
            int[] location = new int[2];
            do
            {
                Console.WriteLine($"Where would you like to target?");
                Console.Write("Row: "); row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Column: "); column = Convert.ToInt32(Console.ReadLine());
                location[0] = row;
                location[1] = column;

            } while (row < 1 || row > player.grids[0].boardSize || column < 1 || column > player.grids[0].boardSize);
            return location;
        }


        public void PrintBoard(Grid grid, Player player)
        {
            Console.Clear();
            Console.WriteLine(player.name + " " + grid.name);
            Console.WriteLine();
            for (int r = 0; r < grid.gridArray.GetLength(0); r++)
            {
                for (int c = 0; c < grid.gridArray.GetLength(1); c++)
                {
                    Console.Write($"{grid.gridArray[r, c], 5}");
                }
                Console.WriteLine();
            }
        }

        public void SwitchPlayers(Player player)
        {
            Console.Clear();
            Console.WriteLine($"Please give the computer to {player.name}");
            Console.ReadLine();
        }

        public void PrintAttackResult(bool hit)
        {
            Console.WriteLine(hit == true ? "Hit!!" : "Miss");
            //if (hit ==true)
            //{
            //    Console.WriteLine("Hit!!");
            //}
            //else
            //{
            //    Console.WriteLine("Miss");
            //}
        }

        public void ShowEnemyShipsRemaining(int d, int s, int b)
        {
            Console.WriteLine("Enemy Ships Remaining:");
            Console.WriteLine(d > 0 ? "Destroyer" : "Destroyer: Sunk!");
            Console.WriteLine(s > 0 ? "Submarine" : "Submarine: Sunk!");
            Console.WriteLine(b > 0 ? "BattleShip" : "BattleShip: Sunk!");
        }


        public void DeclareWinner(string winner)
        {
            Console.WriteLine($"{winner} is the winner!!");
        }

    }
}
