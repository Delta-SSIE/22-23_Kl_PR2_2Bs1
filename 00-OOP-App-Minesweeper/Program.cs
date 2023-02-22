namespace _00_OOP_App_Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen(10, 10);
            screen.Prepare();

            Tile t1 = new Tile(false);
            
            Tile t2 = new Tile(true);
            t2.Reveal();

            Tile t3 = new Tile(false);
            t3.Neighbours = 4;
            t3.Reveal();

            Tile t4 = new Tile(false);
            t4.Flag();

            screen.Render(t1, 0, 0);
            screen.Render(t2, 1, 1);
            screen.Render(t3, 2, 2);
            screen.Render(t4, 3, 3);

            Console.ReadKey();
            Console.Clear();
        }
    }
}