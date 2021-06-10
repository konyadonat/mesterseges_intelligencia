using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OA4R7U_2_25_Ketszemelyes
{
    public partial class Form1 : Form
    {
        Allapot allapot;
        Button[,] palya = new Button[3, 3];
        public Form1()
        {
            allapot = new Allapot();

            InitializeComponent();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button mezo = new Button();
                    mezo.Size = new Size(100, 100);
                    mezo.Location = new Point(j * 100, i * 100);
                    mezo.Font = new Font(this.Font.FontFamily, 40, FontStyle.Bold);

                    mezo.Tag = i + "," + j;
                    Controls.Add(mezo);

                    int x = i;
                    int y = j;
                    //mezo.Click += new EventHandler(mezoClick);
                    mezo.Click += (obj, e) => mezoClick(obj, x, y);
                    palya[i, j] = mezo;
                }
            }
        }

        public void kirajzol(Button mezo)
        {
            if (allapot.Jatekos == 1)
            {
                mezo.Text = "X";
                //mezo.Text = mezo.Tag.ToString().Split(',')[0] + "," + mezo.Tag.ToString().Split(',')[1];
                mezo.ForeColor = Color.Brown;
            }
            else
            {
                mezo.Text = "O";
                //mezo.Text = mezo.Tag.ToString().Split(',')[0] + "," + mezo.Tag.ToString().Split(',')[1];
                mezo.ForeColor = Color.Coral;
            }

        }

        public void vegeVaneJataknak()
        {
            if (allapot.celfeltetel() != 0)
            {
                if (allapot.celfeltetel() == -1)
                {
                    System.Windows.Forms.MessageBox.Show("Gratulálok! O nyert!");

                }
                else if (allapot.celfeltetel() == 1)
                {
                    System.Windows.Forms.MessageBox.Show("Gratulálok! X nyert!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Döntetlen");
                }
                this.Close();
                Environment.Exit(0);
            }
        }

        public void mezoClick(object sender, int x, int y)
        {
            Button mezo = (Button)sender;
            int X = int.Parse(mezo.Tag.ToString().Split(',')[0]);
            int Y = int.Parse(mezo.Tag.ToString().Split(',')[1]);

            Point pont = new Point(x, y);

            //Point pont = new Point(X, Y);

            Operator op = new Operator(allapot.Jatekos, pont);
            if (op.elofeltetel(allapot))
            {
                kirajzol(mezo);
                allapot = op.lerak(allapot);
                vegeVaneJataknak();

                //RandomHibaProba randomHibaProba = new RandomHibaProba();
                //Operator opGep = randomHibaProba.ajanl(allapot);

                Negamax negamax = new Negamax();
                Operator opGep = negamax.ajanl(allapot);
                Button mezoGep = palya[opGep.Hova.X, opGep.Hova.Y];
                kirajzol(mezoGep);
                allapot = opGep.lerak(allapot);
                vegeVaneJataknak();
            }
        }
    }
}

