using System.Text;

namespace Dijkstry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Wezel w0 = new Wezel(0);
            Wezel w1 = new Wezel(1);
            Wezel w2 = new Wezel(2);
            Wezel w3 = new Wezel(3);
            Wezel w4 = new Wezel(4);
            Wezel w5 = new Wezel(5);

            w0.Link(3, w1);
            w0.Link(3, w4);
            w0.Link(6, w5);
            w1.Link(1, w2);
            w1.Link(4, w3);
            w2.Link(3, w3);
            w2.Link(1, w5);
            w5.Link(2, w4);
            w5.Link(1, w3);

            Graf g = new Graf();
            g.listaWezlow.Add(w0);
            g.listaWezlow.Add(w1);
            g.listaWezlow.Add(w2);
            g.listaWezlow.Add(w3);
            g.listaWezlow.Add(w4);
            g.listaWezlow.Add(w5);

            DijkstryA dijkstry = new();
            dijkstry.g = g;
            dijkstry.DijkstryAlgorytm();

            //wyswietlenie
            StringBuilder wynik = new();
            foreach (var x in dijkstry.drogaDict)
            {
                wynik.Append(x.Key.wartosc + " ");
            }
            wynik.AppendLine();

            foreach (var x in dijkstry.drogaDict)
            {
                wynik.Append(x.Value + " ");
            }
            wynik.AppendLine();

            foreach (var x in dijkstry.poprzedniDict)
            {
                wynik.Append(x.Value != null ? x.Value.wartosc.ToString() + " " : "-1 ");

            }

            MessageBox.Show(wynik.ToString());


            /*StringBuilder wynik1 = new();
            foreach (var x in dijkstry.g.listaWezlow)
            {
                //wynik1.Append(x.wartosc);
                if(x.wartosc == 2)
                {
                    var x1 = dijkstry.g.listaWezlow[x.wartosc];
                    while (true)
                    {
                        var x2 = x1.listaKrawedzi[2];
                        var x3 = x2.koniec.wartosc;//x1.listaKrawedzi[x2.koniec.wartosc];
                        x1 = x2.koniec;
                        MessageBox.Show(x2.koniec.wartosc.ToString());
                    }
                }
            }
            MessageBox.Show(wynik1.ToString());*/
        }

        public class Krawedz
        {
            public int waga;
            public Wezel poczatek;
            public Wezel koniec;

            public Krawedz(int waga, Wezel poczatek, Wezel koniec)
            {
                this.waga = waga;
                this.poczatek = poczatek;
                this.koniec = koniec;
            }
        }

        public class Wezel
        {
            public int wartosc;
            public List<Krawedz> listaKrawedzi = new();

            public Wezel(int wartosc)
            {
                this.wartosc = wartosc;
            }

            public void Link(int waga, Wezel w)
            {
                this.listaKrawedzi.Add(new Krawedz(waga, this, w));
                w.listaKrawedzi.Add(new Krawedz(waga, w, this));
            }
        }
        
        public class Graf
        {
            public List<Wezel> listaWezlow = new();

            public Graf()
            {
                this.listaWezlow = new List<Wezel>();
            }

            public Graf(List<Wezel> listaWezlow)
            {
                this.listaWezlow = listaWezlow;
            }
        }

        public class DijkstryA
        {
            public Graf g;
            public Dictionary<Wezel, int> drogaDict = new();
            public Dictionary<Wezel, Wezel> poprzedniDict = new();

            public void DijkstryAlgorytm()
            {
                for(int i=0; i < g.listaWezlow.Count; i++)
                {
                    drogaDict.Add(g.listaWezlow[i], int.MaxValue);
                    poprzedniDict.Add(g.listaWezlow[i], null);
                }

                drogaDict[g.listaWezlow[0]] = 0; //start algorytmu
                poprzedniDict[g.listaWezlow[0]] = null;

                foreach(Wezel w in g.listaWezlow)
                {
                    foreach(Krawedz k in w.listaKrawedzi)
                    {
                        if (w == k.koniec) continue;
                        if (drogaDict[w] < drogaDict[k.koniec])
                        {
                            drogaDict[k.koniec] = drogaDict[w] + k.waga;
                            poprzedniDict[k.koniec] = w;
                        }
                    }
                }
            }
        }
    }
}