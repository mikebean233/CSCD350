using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_MichaelPeterson
{
    public class MineField
    {
        private int rows;
        private int cols;
        
        // True means that there is a mine
        private bool[,] field;

        public MineField(int Rows, int Cols)
        {
            rows = (Rows > 0) ? Rows : 0;
            cols = (Cols > 0) ? Cols : 0;
            field = new bool[Rows, Cols];
        }

        public void AddMine(int row, int col)
        {
            if (ValidCoordinates(row, col))
                field[row, col] = true;
        }

        private bool ValidCoordinates(int row, int col)
        {
            return ((row >= 0 && row < rows) && (col >= 0 && col < cols));
        }

        public override string ToString()
        {
            if (rows == 0 || cols == 0)
                return "";

            string outputString = "";

            for (int rowIndex = 0; rowIndex < rows; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < cols; ++colIndex)
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
