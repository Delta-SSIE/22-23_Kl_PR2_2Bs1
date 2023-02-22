using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_OOP_App_Minesweeper
{
    internal class Screen
    {
        public enum Direction { Up, Down, Left, Right }

        private int width;
        private int height;

        public int CursorX { get; private set; }
        public int CursorY { get; private set; }

        public Screen(int width, int height)
        {
            this.width = width;
            this.height = height;
            CursorX = width / 2;
            CursorY = height / 2;
        }

        public void Prepare() //draw border
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.Write('╔');
            Console.Write("".PadRight(width, '═'));
            Console.Write('╗');
            Console.WriteLine();

            for (int i = 0; i < height; i++)
            {
                Console.Write('║');
                Console.Write("".PadRight(width, ' '));
                Console.Write('║');
                Console.WriteLine();
            }

            Console.Write('╚');
            Console.Write("".PadRight(width, '═'));
            Console.Write('╝');
            Console.WriteLine();
        }

        public void Render(Tile tile, int x, int y)
        {
            Console.SetCursorPosition(x + 1, y + 1); // +1, +1 due to border
            char symbol = ' ';

            switch (tile.State)
            {
                case Tile.TileState.Intact:
                    symbol = '.';
                    break;

                case Tile.TileState.Revealed:
                    if (tile.IsMine)
                        symbol = '*';
                    else if (tile.Neighbours == 0)
                        symbol = ' ';
                    else
                        symbol = (char) (tile.Neighbours + '0');
                    break;

                case Tile.TileState.Flagged:
                    symbol = 'F';
                    break;
            }

            if (x == CursorX && y == CursorY)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            Console.Write(symbol);

            Console.ResetColor();
        }

        public void MoveCursor(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    CursorY -= 1;
                    if (CursorY == -1)
                        CursorY = height - 1;
                    break;

                case Direction.Down:
                    CursorY += 1;
                    if (CursorY == height)
                        CursorY = 0;
                    break;

                case Direction.Left:
                    CursorX -= 1;
                    if (CursorX == -1)
                        CursorX = width - 1; 
                    break;

                case Direction.Right:
                    CursorX += 1;
                    if (CursorX == width)
                        CursorX = 0;
                    break;
            }
        }
    }
}
