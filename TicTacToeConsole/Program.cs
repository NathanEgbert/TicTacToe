using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            PlayGame();
            
        }

        public static void PlayGame()
        {
            string input;
            string playerX = "x";
            string playerO = "o";
            
            GameLogic b1 = new GameLogic();

            b1.printBoard();

            do
            {

                Console.Write("Player " + playerX + " enter your move:");
                input = Console.ReadLine();

                b1.placeInput(input, playerX);
                b1.printBoard();

                if(b1.checkForwin(playerX) == true)
                {
                    Console.WriteLine("Player " + playerX + " wins!");
                    break;
                }
                else if (b1.checkFortie() == true)
                {
                    Console.WriteLine("Tie!");
                    break;
                }

                Console.WriteLine("Player o enter a move: ");
                input = Console.ReadLine();
                b1.placeInput(input, playerO);
                b1.printBoard();

                if (b1.checkForwin("o") == true)
                {
                    Console.WriteLine("Player o wins!");
                    break;
                }

                 if (b1.checkFortie() == true)
                {
                    Console.WriteLine("Tie!");
                    break;
                }
              
                Console.WriteLine();
            } while(!b1.isGameover(playerX,"o"));
        }
    }
}
