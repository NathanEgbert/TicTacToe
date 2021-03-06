﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class PcAi : GameLogic
    {

        
        /// <summary>
        /// Makes the PCs move
        /// The PC takes the center if available
        /// If not then it calls the PCWinBlockCheck method
        /// </summary>
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

        
        /// <summary>
        /// Checks if the PC can win at the current spot,
        /// then checks if the PC cna block the player
        /// at the current spot.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="pc"></param>
        public void PcWinBlockCheck(string player, string pc)
        {
            //checks for win
            for (int i = 0; i <= 2; i++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    //saves the current position on the board to revert back to it
                    string original = board[i, k];

                    //checks if spot is taken already
                    if (board[i, k] == pc || board[i, k] == player)
                    {

                        continue;
                    }

                    //sets the current board position to the PCs move
                    board[i, k] = pc;

                    if (CheckForWin(pc) == true)
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
                    if (board[i, k] == pc || board[i, k] == player)
                    {

                        continue;
                    }

                    //saves the current position on the board to revert back to it
                    string original = board[i, k];


                    board[i, k] = player;
                    if (CheckForWin(player) == true)
                    {

                        board[i, k] = pc;
                        availableMoves.Remove(board[i, k]);
                        return;
                    }

                    //sets the board back to original spot if there is no block
                    board[i, k] = original;

                }
            }

            PcForkCheck();
            RandomMove();
        }

        /// <summary>
        /// Checks for doubble win scenarios and blocks the plyer from playing them.
        /// </summary>
        public void PcForkCheck()
        {

            // if spots 1 & 9 are x's and spot 5 is an o then it will pc to not play a corner move
            if (board[0, 0] == "x" && board[2, 2] == "x" && board[1, 1] == "o")
            {
                availableMoves.Remove("3");
                availableMoves.Remove("7");

            }

            // if spots 3 & 7 are x's and spot 5 is an o then it will pc to not play a corner move
            else if (board[0, 2] == "x" && board[2, 0] == "x" && board[1, 1] == "o")
            {
                availableMoves.Remove("1");
                availableMoves.Remove("9");
            }
        }

        /// <summary>
        /// Creates a random move based on the available moves that are left in the available moves list
        /// </summary>
        public void RandomMove()
        {

            Random rnum = new Random();
            int number = rnum.Next(0, availableMoves.Count);
            string move = availableMoves.ElementAt(number);

            PlaceInput(move, "o");
        }
    }
}
