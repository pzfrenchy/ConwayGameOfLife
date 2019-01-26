using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            GameBoard b = game.SetupBoard(50, 50);
            b.CreateRandomSeed(50);
            game.RunGame(b, 50);
            Console.ReadLine();
        }
    }
}
