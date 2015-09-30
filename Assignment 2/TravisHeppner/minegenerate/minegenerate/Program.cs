using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minegenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 0)
            {
                Console.Out.Write("Error usage: no arguements are to be passed");
                System.Environment.Exit(1);
            }

            Console.Out.Write(mineField(1,1,100));
            Console.Out.Write(mineField(1, 1, 0));
            Console.Out.Write(mineField(100, 100, 100));
            Console.Out.Write(mineField(100, 100, 0));
            Console.Out.Write(mineField(100, 100, 50));
            Console.Out.Write(mineField(50, 50, 100));
            Console.Out.Write(mineField(50, 50, 0));
            Console.Out.Write(mineField(50, 50, 50));


        }

        private static String mineField(int xmax, int ymax, int percentMines)
        {
            String map = xmax + " " + ymax + System.Environment.NewLine;
            Random rand = new Random();
            for (int i = 0; i < xmax; i++)
            {
                for(int j = 0; j < ymax; j++)
                {
                    if(rand.Next(100) <= percentMines && percentMines != 0)
                        map += "*";
                    else
                        map += ".";
                    
                }
                map += System.Environment.NewLine;
            }



            return map;
        }
    }
}
