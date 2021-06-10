using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OA4R7U_2_25_Ketszemelyes
{
    class Operator
    {
        int mit;
        Point hova;

        int suly;

        public int Mit { get => mit; set => mit = value; }
        public Point Hova { get => hova; set => hova = value; }
        public int Suly { get => suly; set => suly = value; }

        public Operator(int mit, Point hova)
        {
            this.mit = mit;
            this.hova = hova;
        }
        public bool elofeltetel(Allapot allapot)
        {
            if (allapot.Palya[hova.X, hova.Y] == 0)
            {
                allapot.Mezoallapot = 1;
            }
            if (allapot.Palya[hova.X, hova.Y] == 1)
            {
                allapot.Mezoallapot = 2;
            }
        }
        public Allapot lerak(Allapot allapot)
        {
            Allapot ujallapot = new Allapot();
            ujallapot.Palya = (int[,])allapot.Palya.Clone();
            ujallapot.Palya[hova.X, hova.Y] = mit;
            ujallapot.Jatekos = (-1) * allapot.Jatekos;
            ujallapot.Mezoallapot++;
            return ujallapot;
        }
    }
}
