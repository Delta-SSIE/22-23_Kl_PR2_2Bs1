using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_OOP_Role
{
    internal class Role
    {
        public string Barva;
        public double Delka;

        public Role(string barva, double delka)
        {
            Barva = barva;
            Delka = delka;
        }

        public override string ToString()
        {
            return $"Role papíru, barva {Barva}, zbývá {Delka} cm";
        }
    }
}
