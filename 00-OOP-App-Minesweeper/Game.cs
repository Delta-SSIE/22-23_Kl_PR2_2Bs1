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
            //mělo by zde být hlídání neplatných - záporných hodnot a exception
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

            RandomizeMap();
            StoreNeighbourCount();
        }

        private void RandomizeMap ()
        {
            //projit cele pole
            //ke kazdemu prvku vytvorit nahodne souradnice a prohdodit

            Random rnd = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int targetX = rnd.Next(width);
                    int targetY = rnd.Next(height);

                    Tile tmp = tiles[targetX, targetY];
                    tiles[targetX, targetY] = tiles[x, y];
                    tiles[x, y] = tmp;

                    //(tiles[x, y], tiles[targetX, targetY]) = (tiles[targetX, targetY], tiles[x, y]);
                    //jiny zpusob prohozeni - pomoci tuple
                }
            }
        }
        /// <summary>
        /// For each tile calculates neighbouring mines and stores them
        /// </summary>
        private void StoreNeighbourCount()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];
                    tile.Neighbours = CountNeighbours(x, y);
                }
            }
        }

        /// <summary>
        /// calculates neighbour count for a single tile
        /// </summary>
        private int CountNeighbours(int x, int y)
        {
            int count = 0;

            for (int shiftX = -1; shiftX < 2; shiftX++)
            {
                for (int shiftY = -1; shiftY < 2; shiftY++)
                {
                    if (shiftX == 0 && shiftY == 0) //nepocitej stred
                        continue;

                    int neighbourX = x + shiftX;
                    int neighbourY = y + shiftY;

                    if (
                        neighbourX > -1 && neighbourX < width
                        && neighbourY > -1 && neighbourY < height
                        && tiles[x, y].IsMine
                    )
                        count++;
                }
            }

            return count;
        }

        public void Run()
        {

        }

    }
}
