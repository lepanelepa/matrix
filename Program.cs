using System;
using System.Linq;

namespace Matrix
{

    class Program
    {
        static int search = 1;        

        static void Main(string[] args)
        {
            Console.Write("Write a string like \"1,0,1;0,0,0\": ") ;
            string inputString = Console.ReadLine();

            int rowsCount = inputString.ToCharArray().Count(c => c == ';');
            int maxY = rowsCount + 1;
            int position = inputString.IndexOf(";");
            string calcString = "";
            if (position > 0)
            {
                calcString = inputString.Substring(0, position);
            }
            else
            {
                calcString = inputString;
            }
            int maxX = calcString.ToCharArray().Count(c => c == ',')+1;
            Console.WriteLine("rows count: " + maxY);
            Console.WriteLine("column count: " + maxX);

            if (maxY <= 100 && maxX <= 100)
            {

                string[] rows = inputString.Split(';');

                int[,] a = new int[maxY, maxX];
                int i = 0;
                foreach (var row in rows)
                {
                    string[] columns = row.Split(',');
                    int j = 0;
                    foreach (var column in columns)
                    {
                        a[i, j] = Convert.ToInt32(column);
                        System.Console.Write($"{a[i, j]}");
                        j++;
                    }
                    System.Console.WriteLine("");
                    i++;
                }


                string res = Calculate(maxX, maxY, a);
                Console.WriteLine("Output value: " + res);
            }
            else {
                Console.WriteLine("Error: maximum size of Matrix must be less than 100x100");
            }
        }

        static int blank(int x, int y, int maxX, int maxY, int[,] a)
        {
            if ((x < 0) || (x >= maxX) || (y < 0) || (y >= maxY) || (a[y, x] == 0))
                return 0;

            a[y, x] = 0;

            return 1 + blank(x - 1, y,  maxX,  maxY,  a) + blank(x + 1, y, maxX, maxY, a) + blank(x, y - 1, maxX, maxY, a) + blank(x, y + 1, maxX, maxY, a);
        }

        static string Calculate(int maxX, int maxY, int[,] a)
        {
            int areas = 0;
            int i = 0;
            int j = 0;
            for (i = 0; i < maxX; ++i)
                for (j = 0; j < maxY; ++j)
                    if (a[j, i] == 1)
                        if (blank(i, j, maxX, maxY, a) >= search)
                            areas++;
            return areas.ToString();
        }
    }
}