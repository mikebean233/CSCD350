using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_MichaelPeterson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MineField> mines = new List<MineField>();
            while(true)
            {
                MineField thisMineField;
                String[] dimensions = Console.ReadLine().Split(new char[] { ' ' });

                int rows, cols;
                int.TryParse(dimensions[0], out rows);
                int.TryParse(dimensions[1], out cols);

                if (rows > 0 && cols > 0)
                {
                    thisMineField = new MineField(rows, cols);
                    for(int row = 0; row < rows; ++row)
                    {
                        string thisRow = Console.ReadLine();
                        for(int col = 0; col < cols; ++col)
                        {
                            if (thisRow[col] == '*')
                                thisMineField.AddMine(row, col);
                        }
                    }
                    mines.Add(thisMineField);
                }
                else
                    break;
            }// end while
        
            int fieldNumber = 0;
            string output = "";
            foreach (MineField thisMineField in mines)
            {
                output += "Field #" + (++fieldNumber) + ":" + Environment.NewLine;
                output += thisMineField.ToString();
                if (mines.Count > fieldNumber)
                    output += Environment.NewLine;
            }

            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
