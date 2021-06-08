using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    abstract class Kereso
    {
        private List<Allapot> ut = new List<Allapot>();
        private List<Operator> operatorok = new List<Operator>();

        public string angolabc = "abcdefghijklmnopqrstuvwxyz";

        internal List<Allapot> Ut { get => ut; set => ut = value; }
        internal List<Operator> Operatorok { get => operatorok; set => operatorok = value; }
        public Kereso()
        {
            operatorfeltoltes();
        }

        private void operatorfeltoltes()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < angolabc.Length; j++)
                {
                    operatorok.Add(new Operator(i, angolabc[j]));
                }
            }
        }
        public abstract void Kereses();
    }
}
