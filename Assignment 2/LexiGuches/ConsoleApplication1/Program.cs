/*
 * Author: Lexi Guches
 * Date: September 30, 2015
 * 
 * CSCD350 Fall Quarter
 * Assignment 2: Minesweeper
 * Description: Input is console representation of a minefield. Output is the minefield with mines noted, and the total number of mines surrounding safe coordinates.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperLexiG
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            String inputAsString = "";
            String[] inputByChar = new String[100];

            int fieldNumber = 0;
            int fieldRows = 0;
            int fieldColumns = 0;
            int[,] mineField = null;

            //Use a count to determine when the minefield has been completely filled.
            int rowCount = 0;
            int columnCount = 0;

            String output = "";

            do
            {
                inputAsString = Console.ReadLine();

                //Input == 'n m'
                if (!inputAsString.Contains('*') && !inputAsString.Contains('.') && !inputAsString.Equals("0 0"))
                {
                    fieldNumber++;
                    rowCount = 0;

                    inputByChar = inputAsString.Split(' ');

                    fieldRows = Convert.ToInt32(inputByChar[0]);
                    fieldColumns = Convert.ToInt32(inputByChar[1]);

                    mineField = new int[fieldRows, fieldColumns];
                }

               //Input == Field
                else if (inputAsString.Contains('*') || inputAsString.Contains('.'))
                {
                    columnCount = 0;

                    foreach (char mineFieldSymbol in inputAsString)
                    {
                        mineField[rowCount, columnCount] = mineFieldSymbol;
                        columnCount++;
                    }

                    rowCount++;

                    //Once rowCount = 0, field has been filled. Proceed to converting field's symbolic representation to numeric.
                    if (rowCount == fieldRows)
                    {
                        output = ConvertMineField(mineField, fieldRows, fieldColumns, fieldNumber, output);
                    }
                }

               //Input = invalid --> change inputAsString to 0 to END program
                else
                {
                    inputAsString = "0 0";
                }
            } while (inputAsString != "0 0");

            //Print output to console
            Console.Write(output);
        }

        /// <param name="mineField">The filled in 2D array filled with '.' and '*' symbols.</param>
        /// <param name="fieldRows">Number of rows in mineField.</param>
        /// <param name="fieldColumns">Number of columns in mineField.</param>
        /// <param name="fieldNumber">Current minefield being worked on.</param>
        /// <param name="output">All completed fields contained in a string.</param>
        /// <returns>String</returns>
        /// <summary>ConvertMineField takes the filled mineField and adds the hint totals to the output string.</summary>
        static String ConvertMineField(int[,] mineField, int fieldRows, int fieldColumns, int fieldNumber, String output)
        {
            int hintTotal;

            output += ("Field #" + fieldNumber + ":\n");

            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    hintTotal = 0;

                    //If this space does not have a mine on it, check each cardinal direction for bombs and increase hintTotal accordingly.
                    if (mineField[i, j] == '.')
                    {
                        //North
                        if (i - 1 > -1)
                        {
                            if (mineField[i - 1, j] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        //North-East
                        if ((i - 1 > -1) && (j + 1 < fieldColumns))
                        {
                            if (mineField[i - 1, j + 1] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        //East
                        if (j + 1 < fieldColumns)
                        {
                            if (mineField[i, j + 1] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        //South-East
                        if ((i + 1 < fieldRows) && (j + 1 < fieldColumns))
                        {
                            if (mineField[i + 1, j + 1] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        //South
                        if (i + 1 < fieldRows)
                        {
                            if (mineField[i + 1, j] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        //South-West
                        if ((i + 1 < fieldRows) && (j - 1 > -1))
                        {
                            if (mineField[i + 1, j - 1] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        //West
                        if (j - 1 > -1)
                        {
                            if (mineField[i, j - 1] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        //North-West
                        if ((i - 1 > -1) && (j - 1 > -1))
                        {
                            if (mineField[i - 1, j - 1] == '*')
                            {
                                hintTotal++;
                            }
                        }

                        output += hintTotal;
                    }

                    else
                    {
                        output += '*';
                    }
                }

                output += "\n";
            }

            output += "\n";
            return output;
        }
    }
}
