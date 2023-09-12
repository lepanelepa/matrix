using System;

namespace Matrix
{

    class Program
    {
        static int maxX = 2;
        static int maxY = 3;
        static int search = 1;


        static int[,] a = {
                    {1, 0},
                    {0, 1},
                    {1, 0}
                };

        static void Main(string[] args)
        {
            Console.Write("Write a string like \"1,0,1;0,0,0\": ") ;
            string res = Calculate();
            Console.WriteLine("Output value: "+res);
        }

        static int blank(int x, int y)
        {
            if ((x < 0) || (x >= maxX) || (y < 0) || (y >= maxY) || (a[y, x] == 0))
                return 0;

            a[y, x] = 0;

            return 1 + blank(x - 1, y) + blank(x + 1, y) + blank(x, y - 1) + blank(x, y + 1);
        }

        static string Calculate()
        {  
            int areas = 0;
            int i=0;
            int j=0;
            for (i = 0; i < maxX; ++i)
                for (j = 0; j < maxY; ++j)
                    if (a[j, i] == 1)
                        if (blank(i, j) >= search)
                            areas++;
            return areas.ToString();
        }
    }
}
