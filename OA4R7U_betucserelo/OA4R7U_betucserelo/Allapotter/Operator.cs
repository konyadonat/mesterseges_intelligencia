using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Operator
    {
        private int mit;
        private char mire;

        public int Mit { get => mit; set => mit = value; }
        public char Mire { get => mire; set => mire = value; }

        public Operator(int mit, char mire)
        {
            this.mit = mit;
            this.mire = mire;
        }

        public Allapot atir(Allapot allapot)
        {
            Allapot ujallapot = new Allapot();

            for (int i = 0; i < 5; i++)
            {
                ujallapot.Karakterek[i] = allapot.Karakterek[i];
            }
            ujallapot.Karakterek[mit] = mire;
            return ujallapot;
        }

        public bool Elofeltetel(Allapot allapot)
        {
            if (allapot.Karakterek[mit] == mire)
            {
                return false;
            }
            char voltállapot = allapot.Karakterek[mit];
            allapot.Karakterek[mit] = mire;
            if (!allapot.szavak.Contains(new string(allapot.Karakterek)))
            {
                allapot.Karakterek[mit] = voltállapot;
                return false;
            }
            allapot.Karakterek[mit] = voltállapot;
            return true;
        }
    }
}
