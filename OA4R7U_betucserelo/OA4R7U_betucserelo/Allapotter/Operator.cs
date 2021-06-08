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

        public Allapot átír(Allapot állapot)
        {
            Allapot újállapot = new Allapot();

            for (int i = 0; i < 5; i++)
            {
                újállapot.Karakterek[i] = állapot.Karakterek[i];
            }
            újállapot.Karakterek[mit] = mire;
            return újállapot;
        }

        public bool Elofeltetel(Allapot állapot)
        {
            if (állapot.Karakterek[mit] == mire)
            {
                return false;
            }
            char voltállapot = állapot.Karakterek[mit];
            állapot.Karakterek[mit] = mire;
            if (!állapot.szavak.Contains(new string(állapot.Karakterek)))
            {
                állapot.Karakterek[mit] = voltállapot;
                return false;
            }
            állapot.Karakterek[mit] = voltállapot;
            return true;
        }
    }
}
