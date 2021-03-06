﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Scanalyzers___Cory_and_Cory
{
    //Board
    //Used in Scanlyzer classes to print out the gameboard 
    //and keep track of the players view of the board
    class Board
    {
        private char[][] GameBoard;//board as viewed by player
        private int rows;//num rows in gameboard
        private int cols;//num columns in gameboard
        private char evidenceType;//char representing evidence type
                                  //IE fingerprint = '@'
        private int geusses;//geuses made by player

        public Board(int r, int c, char type)
        {
            rows = r;
            cols = c;
            evidenceType = type;
            geusses = 0;

            // Dynamically allocate board
            GameBoard = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                GameBoard[i] = new char[cols];
            }

            // Set Board to all ~
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    GameBoard[i][j] = '~';
            }
        }

        // Processes gameboard after a geuss is made
        public bool changeBoard(int r, int c, int evidenceR, int evidenceC)
        {
            // If user geussed right
            if (r == evidenceR && c == evidenceC)
            {
                GameBoard[r][c] = evidenceType;
                resetBoard();
                return true;
            }
            else
            {
                bool pointHoriz = true;  //if both row and col are wrong
                if (geusses++ % 2 == 1)  //will point in direction depending
                {                        //on number of geusses made 
                    pointHoriz = false;
                }

                if (r > evidenceR)
                {
                    if (c > evidenceC)
                    {
                        if (pointHoriz)
                            GameBoard[r][c] = '^';
                        else
                            GameBoard[r][c] = '<';
                    }
                    else if (c == evidenceC)
                    {
                        GameBoard[r][c] = '^';
                    }
                    else
                    {
                        if (pointHoriz)
                            GameBoard[r][c] = '^';
                        else
                            GameBoard[r][c] = '>';
                    }
                }
                else if (r == evidenceR)
                {
                    if (c > evidenceC)
                        GameBoard[r][c] = '<';
                    else
                        GameBoard[r][c] = '>';
                }
                else
                {
                    if (c > evidenceC)
                    {
                        if (pointHoriz)
                            GameBoard[r][c] = 'v';
                        else
                            GameBoard[r][c] = '<';
                    }
                    else if (c == evidenceC)
                    {
                        GameBoard[r][c] = 'v';
                    }
                    else
                    {
                        if (pointHoriz)
                            GameBoard[r][c] = 'v';
                        else
                            GameBoard[r][c] = '>';
                    }
                }
                    
            }
            return false;
        }

        //returns board as a string
        public string GameBoardToString()
        {
            string board = "";
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    board += "" + GameBoard[i][j] + ' ';
                }
                board += '\n';
            }
            return board;
        }

        //returns number of guesses
		public int getGeusses()
		{
			return geusses;
		}

        //returns specific char on the board
		public char getChar(int r, int c){
			return GameBoard[r][c];
		}

		//resets Board
		private void resetBoard()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (GameBoard[r][c] != evidenceType)
                        GameBoard[r][c] = '~';
                }
                    
            }
        }
    }
}
