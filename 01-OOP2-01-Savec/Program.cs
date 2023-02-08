namespace _01_OOP2_01_Savec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kun zeryk = new Kun();
            zeryk.Cvalej();
            zeryk.Dychej();

            Console.WriteLine();
            Velryba mobyDick = new Velryba();
            mobyDick.Dychej();
            mobyDick.Plav();

            //mobyDick.Cvalej();

            Savec konik = new Kun();
            //Console.WriteLine(konik);
            //konik.Cvalej(); //nejde, savec nema Cvalani
            Kun konikJinak = (Kun)konik; //zkompiluje se a je OK, protože konik je Kun
            konikJinak.Cvalej();

            //Kun hybrid = (Kun)mobyDick; //nelze přetypovat - velryba neni potomek Kun

            Savec[] zvirata = new Savec[2];
            zvirata[0] = zeryk;
            zvirata[1] = mobyDick;

            for (int i = 0; i < zvirata.Length; i++)
            {
                Savec tohleZvire = zvirata[i];
                tohleZvire.Dychej();
            }
        }
    }
}