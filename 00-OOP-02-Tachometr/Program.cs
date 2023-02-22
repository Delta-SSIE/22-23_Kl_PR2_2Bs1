namespace _00_OOP_Tachometr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vytvořte nový tachometr
            Tachometr t = new Tachometr();

            //zkuste jeho stav několikrát zvýšit a pak vypsat
            t.Ujed(100);
            Console.WriteLine(t.Stav);
            t.Ujed(500);
            Console.WriteLine(t.Stav);


            //zkuste také zvýšit o zápornou hodnotu
            t.Ujed(-100); //tady to "upadne"
            Console.WriteLine(t.Stav);
        }
    }
}