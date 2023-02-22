using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_OOP_App_Minesweeper
{
    internal class Game
    {
        private int width;
        private int height;
        private int mineCnt;
        private Tile[,] tiles;

        public Game(int width, int height, int mineCnt)
        {
            //mělo by být hlídání neplatných - záporných hodnot a exception
            this.width = width;
            this.height = height;
            this.mineCnt = mineCnt;

            CreateMap();
        }

        private void CreateMap()
        {
            tiles = new Tile[width, height];
            int count = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(count < mineCnt);
                    count++;
                }
            }

            //ToDo: Randomize array
        }
    }
}
