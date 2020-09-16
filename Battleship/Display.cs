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
        public int[] AskForShipLocation(Ship ship)
        {
            int[] location = new int[2];
            Console.WriteLine($"Where would you like your {ship.name} to start?");
            Console.Write("Row: ");int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Column: "); int column = Convert.ToInt32(Console.ReadLine());
            location[0] = row;
            location[1] = column;
            return location;
        }

        public int AskForShipDirection()
        {
            bool valid = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Please select which direction this ship should face?");
                Console.WriteLine("1) Right");
                Console.WriteLine("2) Down");
                //Console.WriteLine("3) Up");
                //Console.WriteLine("4) Left");
                int direction = Convert.ToInt32(Console.ReadLine());

                switch (direction)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    //case 3:
                      //  return 3;
                    //case 4:
                      //  return 4;
                    default:
                        Console.WriteLine("Sorry this is not a valid selection. Please enter 1 or 2.");
                        break;
                } 
            } while (valid == false);
            return 0;
        }

    }
}
