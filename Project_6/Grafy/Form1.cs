using System.Linq;
using static Grafy.Form1;

namespace Grafy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // --- DFS na drzewie ---
        //grafy, przeszukiwanie grafow wszerz
        //https://www.algorytm.edu.pl/grafy/bfs.html
        private void btn1_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel(1);
            var w2 = new Wezel(2);
            var w3 = new Wezel(3);
            var w4 = new Wezel(4);
            var w5 = new Wezel(5);
            var w7 = new Wezel(7);
            w1.dzieci.Add(w2);//1->2
            w1.dzieci.Add(w7);//1->7
            w1.dzieci.Add(w3);//1->3
            w2.dzieci.Add(w4);//2->4
            w2.dzieci.Add(w5);//2->5

            A(w1);
            MessageBox.Show(string.Join(", ", wynik.ToCharArray()));//1,2,4,5,7,3
            wynik = "";
        }

        // --- Graf z cyklem ---
        private void btn2_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel2(5);
            var w2 = new Wezel2(1);
            var w3 = new Wezel2(2);
            var w4 = new Wezel2(3);
            var w5 = new Wezel2(8);
            var w6 = new Wezel2(4);
            w1.Addd(w2);//5->1
            w2.Addd(w4);//1->3
            w2.Addd(w5);//1->8
            w4.Addd(w6);//3->4
            w6.Addd(w3);//4->2
            w3.Addd(w1);//2->5

            odwiedzone.Clear();
            A2(w1);
            MessageBox.Show(string.Join(", ", wynik.ToCharArray()));//5,1,3,4,2,8
            wynik = "";
        }

        // --- DFS na drzewie ---
        void A(Wezel w)//method
        {
            wynik += w.wartosc.ToString();
            foreach (var dziecko in w.dzieci) A(dziecko);
        }

        public class Wezel
        {
            public int wartosc;
            public List<Wezel> dzieci = new();

            public Wezel(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return this.wartosc.ToString();
            }
        }
        // --- DFS na drzewie ---


        // --- Graf z cyklem ---
        //https://eduinf.waw.pl/inf/alg/001_search/0132.php
        //https://www.algorytm.edu.pl/grafy/przeszukiwanie-w-glab.html
        //https://www.algorytm.edu.pl/grafy/bfs.html
        string wynik = "";
        List<Wezel2> odwiedzone = new();
        void A2(Wezel2 w)
        {
            odwiedzone.Add(w);

            wynik += w.wartosc.ToString();
            foreach (var sasiad in w.sasiedzi)
            {
                if (!odwiedzone.Contains(sasiad))
                {
                    A2(sasiad);
                }
            }
        }
        // --- Graf z cyklem ---


        // --- Graf z cyklem ---
        public class Wezel2
        {
            public int wartosc;
            public List<Wezel2> sasiedzi = new();

            public Wezel2(int liczba)
            {
                this.wartosc = liczba;
            }

            public void Addd(Wezel2 w)
            {
                w.sasiedzi.Add(this);//this - obiekt nadrzedny, w - ten w Add()
                this.sasiedzi.Add(w);
            }

            public override string ToString()
            {
                return this.wartosc.ToString();
            }
        }
        // --- Graf z cyklem ---


        // --- BST - Binarne drzewo przeszukan ---
        private DrzewoBinarne drzewo;
        private void btn3_Click(object sender, EventArgs e)
        {
            if (drzewo == null)
            {
                drzewo = new DrzewoBinarne(5);
            }

            drzewo.Add(3);
            drzewo.Add(3);
            drzewo.Add(6);
            drzewo.Add(7);
            drzewo.Add(-3);
            drzewo.Add(2);
            drzewo.Add(0);
            drzewo.Add(1);
        }
        // --- BST - Binarne drzewo przeszukan ---


        // --- BST - Binarne drzewo przeszukan ---
        public class Wezel3
        {
            public int wartosc;
            public Wezel3 rodzic;
            public Wezel3 dzieckoLewe;
            public Wezel3 dzieckoPrawe;

            public Wezel3(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return this.wartosc.ToString();
            }
        }

        public class DrzewoBinarne
        {
            public Wezel3 korzen;
            public int liczbaWezlow;

            public DrzewoBinarne(int liczba)
            {
                this.korzen = new Wezel3(liczba);
                this.liczbaWezlow = 1;
            }

            public void Add(int liczba)
            {
                if (korzen == null)
                {
                    korzen = new Wezel3(liczba);
                    liczbaWezlow = 1;
                    return;
                }

                Wezel3 obecnyWezel = korzen;

                while (true)
                {
                    if (liczba < obecnyWezel.wartosc)
                    {
                        if (obecnyWezel.dzieckoLewe == null)
                        {
                            obecnyWezel.dzieckoLewe = new Wezel3(liczba);
                            obecnyWezel.dzieckoLewe.rodzic = obecnyWezel;
                            liczbaWezlow++;
                            return;
                        }
                        else
                        {
                            obecnyWezel = obecnyWezel.dzieckoLewe;
                        }
                    }
                    else//else if (liczba >= obecnyWezel.wartosc)
                    {
                        if (obecnyWezel.dzieckoPrawe == null)
                        {
                            obecnyWezel.dzieckoPrawe = new Wezel3(liczba);
                            obecnyWezel.dzieckoPrawe.rodzic = obecnyWezel;
                            liczbaWezlow++;
                            return;
                        }
                        else
                        {
                            obecnyWezel = obecnyWezel.dzieckoPrawe;
                        }
                    }
                }
            }
        }
        // --- BST - Binarne drzewo przeszukan ---


        // --- BFS ---
        //https://www.programiz.com/dsa/graph-bfs
        string wynik_bfs = "";
        List<Wezel4> odwiedzone_bfs = new();
        Queue<Wezel4> kolejka_bfs = new();//List
        private void btn4_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel4(0);
            var w2 = new Wezel4(1);
            var w3 = new Wezel4(2);
            var w4 = new Wezel4(3);
            var w5 = new Wezel4(4);
            w1.sasiedzi.Add(w2);//0->1
            w1.sasiedzi.Add(w3);//0->2
            w1.sasiedzi.Add(w4);//0->3
            w2.sasiedzi.Add(w3);//1->2
            w3.sasiedzi.Add(w5);//2->4

            A4(w1);
        }

        void A4(Wezel4 w)
        {
            kolejka_bfs.Enqueue(w);//Add

            while (kolejka_bfs.Count > 0)
            {
                var aktualny = kolejka_bfs.Dequeue();//kolejka_bfs[0]
                //kolejka_bfs.RemoveAt(0);
                odwiedzone_bfs.Add(aktualny);
                wynik_bfs += aktualny.wartosc.ToString() + " ";

                foreach (var sasiad in aktualny.sasiedzi)
                {
                    if (!odwiedzone_bfs.Contains(sasiad) && !kolejka_bfs.Contains(sasiad))
                    {
                        kolejka_bfs.Enqueue(sasiad);//Add
                    }
                }
            }

            MessageBox.Show(wynik_bfs);
        }

        public class Wezel4
        {
            public int wartosc;
            public List<Wezel4> sasiedzi = new();

            public Wezel4(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return this.wartosc.ToString();
            }
        }
        // --- BFS ---


        // [---] W DOMU DOKONCZYC [---]

        // [---] W DOMU DOKONCZYC [---]
    }
}