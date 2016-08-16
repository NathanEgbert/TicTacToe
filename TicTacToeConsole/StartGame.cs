using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class StartGame
    {
       
        static void Main(string[] args)
        {
            var game1 = new GameLogic();
            game1.PlayGame();
            
        }
    }
}
