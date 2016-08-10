using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class PCAI : GameLogic
    {

        public void pcMove()
        {
            //pc takes the center if available 
            if (board[1, 1] != "o" && board[1, 1] != "x")
            {

                board[1, 1] = "o";
                availableMoves.Remove("5");

                return;
            }//end if 

            pcwinBlockcheck("x", "o");

        }//end pcMove

        public void pcwinBlockcheck(string player, string PC)
        {

            //checks for win
            for (int i = 0; i <= 2; i++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    string original;

                    //checks if spot is taken already
                    if (board[i, k] == PC || board[i, k] == player)
                    {

                        continue;
                    }//end if

                    original = board[i, k];
                    board[i, k] = PC;

                    if (checkForwin(PC) == true)
                    {

                        return;

                    }//end if
                    board[i, k] = original;

                }//end for
            }//end for


            //checks for block 
            for (int i = 0; i <= 2; i++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    //checks if spot is taken already
                    if (board[i, k] == PC || board[i, k] == player)
                    {

                        continue;
                    }

                    //saves the current position on the board to revert back to it
                    string original = board[i, k];

                    
                    board[i, k] = player;
                    if (checkForwin(player) == true)
                    {

                        board[i, k] = PC;
                        availableMoves.Remove(board[i, k]);
                        return;
                    }

                    //sets the board back to original spot if there is no block
                    board[i, k] = original;

                }//end for
            }//end for

            randomMove();

        }//end pc win block check

        public void pcForkcheck()
        {
           

            
        }//end fork check 

        public void randomMove()
        {
            
            Random rnum = new Random();
            int number = rnum.Next(0, availableMoves.Count);
            string move = availableMoves.ElementAt(number);

            placeInput(move, "o");


        }//end random move
       
        

    }
}
