using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_minsweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
                Console.Out.Write("Error usage: no arguements are to be passed in.");

            string input;
            string output = "";
            int xmax, ymax;
            int[,] field;

            
            input = Console.ReadLine();
            for (int k = 1; input != null; k++)
            {
                xmax = int.Parse(input.Substring(0, input.IndexOf(" ")));
                ymax = int.Parse(input.Substring(input.IndexOf(" ") + 1, input.Length - input.IndexOf(" ") - 1));

                Console.Out.Write(Environment.NewLine + xmax + " " + ymax);
                field = new int[xmax, ymax];
                for (int i = 0; i < ymax; i++)
                {
                    input = Console.ReadLine();
                    Console.Out.Write(Environment.NewLine);
                    for (int j = 0; j < xmax; j++)
                    {
                        if (input.Substring(j, 1).Contains("*"))
                        {
                            field[j, i] = -1;
                            Console.Out.Write("*");
                        }
                        else
                        {
                            field[j, i] = 0;
                            Console.Out.Write(".");
                        }
                    }

                }
                calcField(field);
                output += fieldToString(field, k) + Environment.NewLine;
                input = Console.ReadLine();

            }
            Console.Out.Write(Environment.NewLine + Environment.NewLine + Environment.NewLine + output);




        }

        /// <summary>
        /// Converns a 2d array into a string
        /// </summary>
        /// <param name="field">int[,]</param>
        /// <returns>string</returns>
        private static string fieldToString(int[,] field, int fieldNum)
        {
            string output = "Field #" + fieldNum + ":" + Environment.NewLine;
            for(int i = 0; i < field.GetLength(1); i++) 
            {
                for(int j = 0; j < field.GetLength(0); j++)
                {
                    if(field[j,i] == -1)
                        output += "*";
                    else
                        output += field[j,i];

                }

                output += System.Environment.NewLine;
            }

            return output;
                
        }


        /// <summary>
        /// fills in numbers on a minesweeper board (2d array) where -1 is a mine and 0 is not
        /// </summary>
        /// <param name="field"> int[,]</param>
        /// <returns>void</returns>
        private static void calcField(int[,] field)
        {
            for(int i = 0; i < field.GetLength(1); i++)
                for(int j = 0; j < field.GetLength(0); j++)
                {
                    if(field[j,i] == -1)
                    {
                        incSquare(field, j,i);
                    }
                }
        }

        /// <summary>
        /// increments the squares arount the coordinates
        /// </summary>
        /// <param name="field">int[,]</param>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        private static void incSquare(int[,] field, int x, int y)
        {
            for(int i = -1 ;i<2;i++)
            {
                for(int j = -1; j < 2 ;j++)
                {
                    
                    if(x + j >= 0 && x + j < field.GetLength(0)
                        && y + i >= 0 && y + i < field.GetLength(1) )
                        if(field[x + j,y + i] != -1)
                            field[x + j,y + i]++;
                }
            }
        }
    }
}
