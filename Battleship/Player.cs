﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        //member variables
        public string name;
        public List<Grid> grids;
        public Ship ship;

        //constructor
        public Player(string name)
        {
            this.name = name;
            grids = new List<Grid>();
            grids.Add(new Grid("Ship Grid"));
            grids.Add(new Grid("Hit Grid"));
        }

        //methods
        public void PlaceShip(int[] array, int direction, Player player, Ship ship)
        {
            player.grids[0].gridArray[array[0], array[1]] = ship.identifier;
            if(direction == 1 && (array[1] + ship.length) < player.grids[0].boardSize)
            {
                for (int i = 1; i < ship.length; i++)
                {
                    player.grids[0].gridArray[array[0], array[1]+i] = ship.identifier;
                }
            }
            else if (direction == 2 && (array[0] + ship.length) < player.grids[0].boardSize)
            {
                for (int i = 1; i < ship.length; i++)
                {
                    player.grids[0].gridArray[array[0]+i, array[1]] = ship.identifier;
                }
            }
        }

        public bool CheckBoard(int [] target, Player player)
        {
            bool hit = false;
            if (player.grids[0].gridArray[target[0],target[1]] == "O")
            {
                return hit;
            }
            else if (player.grids[0].gridArray[target[0], target[1]] != "O")
            {
                hit = true;
                player.grids[0].gridArray[target[0], target[1]] = "X";
                return hit;
            }
            return hit;
        }

        public void UpdateHitBoard(int[] target, bool hit, Player player)
        {
            if (hit == true)
            {
                player.grids[1].gridArray[target[0], target[1]] = "H";
            }
            else if (hit == false)
            {
                player.grids[1].gridArray[target[0], target[1]] = "M";
            }
        }

    }
}
