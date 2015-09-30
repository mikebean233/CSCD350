/*
 * Author: Michael Peterson
 * Team: The Bynars
 * Date: September 30, 2015
 * 
 * CSCD350 Fall Quarter
 * Assignment 2: Minefield
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_MichaelPeterson
{
    public class MineField
    {
        private int _rows;
        private int _cols;
        
        // True means that there is a mine
        private bool[,] field;

        /// <param name="row">The number of rows that the field will hold</param>
        /// <param name="cols">The number of columns that the field will hold</param>
        public MineField(int rows, int cols)
        {
            _rows = (rows > 0) ? rows : 0;
            _cols = (cols > 0) ? cols : 0;
            field = new bool[_rows, _cols];
        }

        /// <param name="row">The row in which to place the min</param>
        /// <param name="col">The column in which to place the mine</param>
        /// <summary>Places a mine in the mine field</summary>
        public void AddMine(int row, int col)
        {
            if (ValidCoordinates(row, col))
                field[row, col] = true;
        }

        private bool ValidCoordinates(int row, int col)
        {
            return ((row >= 0 && row < _rows) && (col >= 0 && col < _cols));
        }

        /// <summary>Return a String representation of the mine field</summary>
        public override string ToString()
        {
            if (_rows == 0 || _cols == 0)
                return "";

            string outputString = "";

            for (int rowIndex = 0; rowIndex < _rows; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < _cols; ++colIndex)
                {
                    if (ContainsMine(rowIndex, colIndex))
                        outputString += "*";
                    else
                        outputString += AdjacentMineCount(rowIndex, colIndex).ToString();
                }
                outputString += Environment.NewLine;
            }

            return outputString;
        }

        private int AdjacentMineCount(int row, int col)
        {
            if (!ValidCoordinates(row, col))
                return 0;

            int mineCount = 0;

            for (int rowIndex = row - 1; rowIndex <= row + 1; ++rowIndex)
            {
                for (int colIndex = col - 1; colIndex <= col + 1; ++colIndex)
                {
                    if (!(rowIndex == row && colIndex == col) && ContainsMine(rowIndex, colIndex))
                        ++mineCount;
                }
            }

            return mineCount;
        }

        private bool ContainsMine(int row, int col)
        {
            if (!ValidCoordinates(row, col))
                return false;

            return field[row, col];
        }
    }
}
