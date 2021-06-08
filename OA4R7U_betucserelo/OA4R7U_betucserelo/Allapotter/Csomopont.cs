using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Csomopont
    {
        Allapot allapot;
        Csomopont szulo;
        int koltseg;
        int operatorIndex;

        public Csomopont(Allapot allapot, int operatorIndex)
        {
            this.allapot = allapot;
            this.operatorIndex = operatorIndex;
        }

        public Csomopont(Allapot allapot, Csomopont szulo)
        {
            this.allapot = allapot;
            this.szulo = szulo;

            if (szulo == null)
                koltseg = 0;
            else
                this.koltseg = this.szulo.koltseg + 1;
        }

        public int Koltseg { get => koltseg; set => koltseg = value; }
        public int OperatorIndex { get => operatorIndex; set => operatorIndex = value; }
        internal Allapot Allapot { get => allapot; set => allapot = value; }
        internal Csomopont Szulo { get => szulo; set => szulo = value; }

        public override bool Equals(object obj)
        {
            Csomopont masik = (Csomopont)obj;
            return Allapot.Equals(masik.Allapot);
        }
    }
}
