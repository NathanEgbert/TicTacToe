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
            
            
            
            PCAI AI = new PCAI();

            AI.printBoard();

            do
            {

                Console.Write("Player " + playerX + " enter your move:");
                input = Console.ReadLine();

                AI.placeInput(input, playerX);
                AI.printBoard();

                if(AI.checkForwin(playerX) == true)
                {
                    Console.WriteLine("Player " + playerX + " wins!");
                    break;
                }
                else if (AI.checkFortie() == true)
                {
                    Console.WriteLine("Tie!");
                    break;
                }

                
                AI.pcMove();
                Console.Clear();
                AI.printBoard();

                if (AI.checkForwin("o") == true)
                {
                    Console.WriteLine("You Lose");
                    break;
                }

                 if (AI.checkFortie() == true)
                {
                    Console.WriteLine("Tie!");
                    break;
                }
              
                Console.WriteLine();
            } while(!AI.isGameover(playerX,"o"));
        }
    }
}
