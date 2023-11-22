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
            w1.dzieci.Add(w2);
            w1.dzieci.Add(w7);
            w1.dzieci.Add(w3);
            w2.dzieci.Add(w4);
            w2.dzieci.Add(w5);

            A(w1);
            MessageBox.Show(string.Join(", ", wynik.ToCharArray()));//1,2,4,5,7,3
            wynik = "";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel2(5);
            var w2 = new Wezel2(1);
            var w3 = new Wezel2(2);
            var w4 = new Wezel2(3);
            var w5 = new Wezel2(8);
            var w6 = new Wezel2(4);
            w1.Add(w2);
            w2.Add(w4);
            w2.Add(w5);
            w4.Add(w6);
            w6.Add(w3);
            w3.Add(w1);

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

        // --- Drzewo z cyklem ---
        public class Wezel2
        {
            public int wartosc;
            public List<Wezel2> sasiedzi = new();

            public Wezel2(int liczba)
            {
                this.wartosc = liczba;
            }
            
            public void Add(Wezel2 w)
            {
                w.sasiedzi.Add(this);
                this.sasiedzi.Add(w);
            }

            public override string ToString()
            {
                return this.wartosc.ToString();
            }
        }

        // --- Drzewo binarne przeszukan ---
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

            //w domu
            //5 3 3 6 7 -3 2 0 1
            //1 dodal do 0 i w prawo podpial
            public void Add(int liczba)
            {

            }
        }

        // [---] W DOMU DOKONCZYC [---]
        // [---] W DOMU DOKONCZYC [---]
        // [---] W DOMU DOKONCZYC [---]


        //BFS w domu z gifa po prawej
        //https://en.wikipedia.org/wiki/Breadth-first_search

        //teraz przeszukiwanie binarne


        //od bartka
        //PD BFS !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
        //https://pl.wikipedia.org/wiki/Przeszukiwanie_wszerz
        //nie uzywa sie foreach bo nie da sie zmienic dlugosci listy
        //oraz zrobic metode ADD do klasy drzewo binarne

        // [---] W DOMU DOKONCZYC [---]
        // [---] W DOMU DOKONCZYC [---]
        // [---] W DOMU DOKONCZYC [---]
    }
}