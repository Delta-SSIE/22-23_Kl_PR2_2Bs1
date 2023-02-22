using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_OOP_Archiv
{
    internal class Archiv
    {
        /// <summary>
        /// kapacita police
        /// </summary>
        private int _kapacita;
        
        /// <summary>
        /// počet polic ve skříni
        /// </summary>
        private int _police;

        public int Pocet { get; private set; }

        public int Pozice
        {
            get
            {
                int pristi = Pocet + 1;
                return pristi % _kapacita;
            }
        }

        public int Police
        {
            get
            {
                int pristi = Pocet;
                return pristi / _kapacita + 1;
            }
        }

        public Archiv(int kapacita, int police)
        {
            if (kapacita < 1)
                throw new ArgumentOutOfRangeException("Kapacita ´police musí být aspoň 1 časopis");

            _kapacita = kapacita;

            if (police < 1)
                throw new ArgumentOutOfRangeException("Kapacita skříně musí být aspoň 1 police");

            _police = police;
        }

        public void Uloz(int kolik)
        {
            if (kolik < 0)
                throw new ArgumentOutOfRangeException("Nalze ukládat záporný počet časopisů");

            Pocet += kolik;
        }

        public void Reset()
        {
            Pocet = 0;
        }
    }
}
