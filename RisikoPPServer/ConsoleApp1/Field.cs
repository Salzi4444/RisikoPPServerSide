using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Field
    {
        public static int defaultWidth = 32;
        public static int defaultHeight = 32;

        public Square[,] squares;

        public Field()
        {
            squares = new Square[defaultWidth, defaultHeight];

            for (int i = 0; i < defaultWidth; i++)
            {
                for (int j = 0; j < defaultHeight; j++)
                {
                    squares[i, j] = new Square(0, 0);
                }
            }
        }
    }
}
