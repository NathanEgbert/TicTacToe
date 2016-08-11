using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class PcAi : GameLogic
    {

        /*
         * makes the pc move
         * the pc takes the center if available
         * if not then it calls the PcWinBlockCheck method
         */
        public void PcMove()
        {
            //pc takes the center if available 
            if (board[1, 1] != "o" && board[1, 1] != "x")
            {

                board[1, 1] = "o";
                availableMoves.Remove("5");

                return;
            }

            PcWinBlockCheck("x", "o");
        }

        /*
         * 
         */ 
        public void PcWinBlockCheck(string player, string PC)
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
                    }

                    original = board[i, k];
                    board[i, k] = PC;

                    if (CheckForWin(PC) == true)
                    {

                        return;

                    }
                    board[i, k] = original;

                }
            }


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
                    if (CheckForWin(player) == true)
                    {

                        board[i, k] = PC;
                        availableMoves.Remove(board[i, k]);
                        return;
                    }

                    //sets the board back to original spot if there is no block
                    board[i, k] = original;

                }
            }

            RandomMove();

        }

        public void PcForkCheck()
        {
           

            
        } 

        /*
         * creates a random move based on the available moves that are left in te available moves list
         */ 
        public void RandomMove()
        {
            
            Random rnum = new Random();
            int number = rnum.Next(0, availableMoves.Count);
            string move = availableMoves.ElementAt(number);

            PlaceInput(move, "o");


        }
       
        

    }
}
