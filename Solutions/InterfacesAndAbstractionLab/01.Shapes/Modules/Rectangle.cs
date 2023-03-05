using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes.Modules
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                char[] temp = new char[width];

                if (i == 0 || i == height - 1)
                {
                    Array.Fill(temp, '*');
                }
                else
                {
                    temp[0] = '*';
                    temp[width - 1] = '*';

                    Array.Fill(temp, ' ', 1, width - 2);
                }
                Console.WriteLine(String.Join("", temp));
            }
        }
    }
}
