using System;
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

        //constructor
        public Player(string name)
        {
            this.name = name;
            grids = new List<Grid>();
            grids.Add(new Grid("shipGrid"));
            grids.Add(new Grid("hitGrid"));
        }

        //methods
        public void PlaceShip(int[] array)
        {

        }

    }
}
