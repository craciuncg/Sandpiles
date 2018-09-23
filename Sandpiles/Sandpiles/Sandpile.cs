using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandpiles
{
    public class Sandpile
    {

        private int[,] sandpile;

        private int width, height;

        public Sandpile(int width, int height)
        {
            this.width = width;
            this.height = height;

            sandpile = new int[height, width];
        }
        
        public int[,] Data()
        {
            return sandpile;
        }

        public void Drop(int amount)
        {
            sandpile[height / 2, width / 2] = amount;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public void Topple()
        {
            bool finish = false;
            while (!finish)
            {
                bool once = false;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (sandpile[i, j] > 3)
                        {
                            if (j - 1 >= 0)
                                sandpile[i, j - 1] += sandpile[i, j] / 4;
                            if (j + 1 <= width)
                                sandpile[i, j + 1] += sandpile[i, j] / 4;
                            if (i - 1 >= 0)
                                sandpile[i - 1, j] += sandpile[i, j] / 4;
                            if (i + 1 <= height)
                                sandpile[i + 1, j] += sandpile[i, j] / 4;

                            sandpile[i, j] = sandpile[i, j] % 4;
                            finish = false;
                            once = true;
                            j -= 2;
                        }
                        else if (!once)
                        {
                            finish = true;
                        }


                        if (sandpile[j, i] > 3)
                        {
                            if (i - 1 >= 0)
                                sandpile[j, i - 1] += sandpile[j, i] / 4;
                            if (i + 1 <= width)
                                sandpile[j, i + 1] += sandpile[j, i] / 4;
                            if (j - 1 >= 0)
                                sandpile[j - 1, i] += sandpile[j, i] / 4;
                            if (j + 1 <= height)
                                sandpile[j + 1, i] += sandpile[j, i] / 4;

                            sandpile[j, i] = sandpile[j, i] % 4;
                            finish = false;
                            once = true;
                            j -= 2;
                        }
                        else if (!once)
                        {
                            finish = true;
                        }
                    }
                }
            }
        }
    }
}
