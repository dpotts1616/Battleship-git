using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Grid
    {
        //member variables
        public string name;
        public string[,] gridArray;
        public int boardSize;


        //constructor
        public Grid(string name)
        {
            this.name = name;
            boardSize = 21;
            gridArray = new string[boardSize, boardSize];
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
        }

        //methods
       
    }
}
