﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    public class GameLogic
    {

        protected string[,] board;
        protected List<string> availableMoves = new List<string>();
       
        
        
        public GameLogic()
        {
            
            availableMoves.Add("1");
            availableMoves.Add("2");
            availableMoves.Add("3");
            availableMoves.Add("4");
            availableMoves.Add("5");
            availableMoves.Add("6");
            availableMoves.Add("7");
            availableMoves.Add("8");
            availableMoves.Add("9");
            

            board = new string[3, 3]  
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"},
            };

        }

        
        /// <summary>
        /// Prints the board
        /// </summary>
        public void PrintBoard()
        {

            Console.WriteLine("   | " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " |");
            Console.WriteLine("   -------------");
            Console.WriteLine("   | " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " |");
            Console.WriteLine("   -------------");
            Console.WriteLine("   | " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " |");
            Console.WriteLine("   -------------");
        }
 
        /// <summary>
        /// Places the input by passing the players choice and the player(x or o)
        /// loops through the board to find the spot the player chose and sets that spot to the player
        /// then it removes that spot from the available moves 
        /// </summary>
        /// <param name="playerChoice"></param>
        /// <param name="player"></param>
        public void PlaceInput(string playerChoice, string player)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j].Equals(playerChoice))
                    {
                        board[i, j] = player;
                        availableMoves.Remove(playerChoice);
                    }
                }
            }
        } 

        
        /// <summary>
        /// checks for column wins, row wins, and diagonal wins and returns true if a win is found and false if not
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool CheckForWin(string player)
        {
            for (int i = 0; i < 3; i++)
            {
                //check column wins 
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                {
                    return true;
                    
                }

                //check row wins 
                else if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                {
                    return true;
                    
                }
            }

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
        }

        
        /// <summary>
        /// checks for a tie by returning true if each spot does not equal the original place holder 
        /// </summary>
        /// <returns></returns>
        public bool CheckForTie()
        {

            return board[0, 0] != "1" && board[0, 1] != "2" && board[0, 2] != "3" && board[1, 0] != "4" && board[1, 1] != "5" && board[1, 2] != "6" && board[2, 0] != "7" && board[2, 1] != "8" && board[2, 2] != "9";

        }

        
        /// <summary>
        /// Checks to see if the game is over by returning true if CheckForWin returns true for either player.
        /// Or if CheckForTie is true;
        /// </summary>
        /// <param name="playerX"></param>
        /// <param name="playerO"></param>
        /// <returns></returns>
        public bool IsGameOver(string playerX, string playerO)
        {
            return CheckForWin(playerX) == true || CheckForWin(playerO) == true || CheckForTie() == true;
        }

        public  void PlayGame()
        {
            string input;
            string playerX = "x";
            string pc = "o";
            var AI = new PcAi();
           
            
            AI.PrintBoard();

            do
            {
               
                Console.Write("Player " + playerX + " enter your move:");
                input = Console.ReadLine();

                AI.PlaceInput(input, playerX);
                AI.PrintBoard();

                if(AI.CheckForWin(playerX) == true)
                {
                    Console.WriteLine("You Win!");
                    break;
                }
                else if(CheckForTie() == true)
                {
                    Console.WriteLine("Tie!");
                    break;
                }
             
                AI.PcMove();
                Console.Clear();
                AI.PrintBoard();

                if (AI.CheckForWin(pc) == true)
                {
                    Console.WriteLine("You Lose!");
                    break;
                }
                else if (CheckForTie() == true)
                {
                    Console.WriteLine("Tie!");
                    break;
                }
                
                Console.WriteLine();
            } while (!AI.IsGameOver(playerX, pc));
        }
    }

}

