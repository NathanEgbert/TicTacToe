using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class GameLogic
    {

        
        private int count = 0;
        private string[,] board; 
            

        public GameLogic()
        {
          board = new string[,]  
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"},
            };

        }//end constructor

        public void printBoard()
        {
          
            Console.WriteLine("   | " + board[0,0] + " | " + board[0,1] + " | " + board[0,2] + " |");
            Console.WriteLine("   -------------");
            Console.WriteLine("   | " + board[1,0] + " | " + board[1,1] + " | " + board[1,2] + " |");
            Console.WriteLine("   -------------");
            Console.WriteLine("   | " + board[2,0] + " | " + board[2,1] + " | " + board[2,2] + " |");
            Console.WriteLine("   -------------");
        }//end print board

        public void placeInput(string pChoice, string player)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j].Equals(pChoice))
                    {
                        count++;
                        board[i, j] = player;
                    }
                }
            }
        }//end place input 
        public bool checkForwin(string player)
        {
            
            for (int i = 0; i < 3;i++)
            {
                //check column wins 
                if(board[0, i] == player && board[1, i] == player && board[2, i] == player)
                {
                    return true;
                }

                //check row wins 
                else  if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                {
                    return true;
                }

            }//end for 
        
            //check Diagonal wins
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            else if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }
            
                return false;

        }//end check for win method

        public bool checkFortie()
        {       
                return count == 9;
        }//end check for tie

        public bool isGameover(string playerX, string playerO)
        {            
                return checkForwin(playerX) == true || checkForwin(playerO) == true || checkFortie() == true;
        }//end game over

       

        
    }
		  
}

