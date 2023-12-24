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

        /*LINKI
         https://eduinf.waw.pl/inf/alg/001_search/0132.php
         https://www.algorytm.edu.pl/grafy
         */

        // --- DFS na drzewie ---
        //graf - przeszukiwanie grafu wszerz - BFS
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
        //https://www.algorytm.edu.pl/grafy/przeszukiwanie-w-glab.html
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
            drzewo.Add(4);
            drzewo.Add(8);
            drzewo.Add(6);
            drzewo.Add(7);
            drzewo.Add(2);
            drzewo.Add(3);
            drzewo.Add(5);
            drzewo.Add(1);
            drzewo.Add(10);
            drzewo.Add(9);
            drzewo.Add(12);

            /*MessageBox.Show("Zad1: " + drzewo.Znajdz(6).ToString()
                + "\nZad2: " + ZnajdzMin(drzewo.korzen).wartosc.ToString()
                + "\nZad3: " + ZnajdzMax(drzewo.korzen).wartosc.ToString()
                + "\nZad4[5]: " + Nastepnik(drzewo.Znajdz(5)).wartosc.ToString()*/

            //Wezel - brak dzieci
            //Usun(drzewo.korzen.praweDziecko.leweDziecko.leweDziecko);//Usun(5)
            //MessageBox.Show("Usun(5): " + ZnajdzMin(drzewo.korzen.praweDziecko.leweDziecko).wartosc.ToString());//Usun(5)

            //Wezel - 1 dziecko
            //Usun(drzewo.korzen.praweDziecko);//Usun(8)
            //MessageBox.Show("Usun(8): " + ZnajdzMin(drzewo.korzen.praweDziecko).wartosc.ToString());//Usun(8)

            //Wezel - 2 dzieci
            drzewo.Usun(drzewo.korzen.praweDziecko.leweDziecko);//Usun(6)
            MessageBox.Show("Usun(6): " + drzewo.korzen.praweDziecko.leweDziecko.wartosc.ToString());//Usun(6)
            //Usun(drzewo.korzen);//Usun(korzen)
            //MessageBox.Show("Usun(korzen): " + drzewo.korzen.wartosc.ToString());//Usun(korzen)
        }
        // --- BST - Binarne drzewo przeszukan ---


        // --- BST - Binarne drzewo przeszukan ---
        public class Wezel3
        {
            public int wartosc;
            public Wezel3 rodzic;
            public Wezel3 leweDziecko;
            public Wezel3 praweDziecko;

            public Wezel3(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return this.wartosc.ToString();
            }

            internal void Add(int liczba)
            {
                var dziecko = new Wezel3(liczba);
                dziecko.rodzic = this;

                if (liczba < wartosc)//w.wartosc ?
                {
                    this.leweDziecko = dziecko;
                }
                else
                {
                    this.praweDziecko = dziecko;
                }
                //throw new NotImplementedException();
            }

            public int getLiczbaDzieci()
            {
                int wynik = 0;
                if (this.leweDziecko != null)
                {
                    wynik++;
                }
                if (this.praweDziecko != null)
                {
                    wynik++;//++wynik
                }

                return wynik;
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
                Wezel3 rodzic = this.ZnajdzRodzica(liczba);
                rodzic.Add(liczba);
            }

            public Wezel3 ZnajdzRodzica(int liczba)
            {
                var w = this.korzen;
                //w = w.leweDziecko;
                //w = w.rodzic;//skok w gore z dziecka 3->5

                while (true)//for(;;)
                {
                    if (liczba < w.wartosc)
                    {
                        if (w.leweDziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.leweDziecko;
                        }
                    }
                    else
                    {
                        if (w.praweDziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.praweDziecko;
                        }
                    }
                }
            }

            //1. Wezel3 Znajdz(int liczba) - pierwsze wystapienie 3 ma byc zwrocone, jak nie ma to zwroc ze nie ma
            public Wezel3 Znajdz(int liczba)
            {
                var w = this.korzen;

                while (w != null && w.wartosc != liczba)
                {
                    if (liczba < w.wartosc)
                    {
                        w = w.leweDziecko;
                    }
                    else//liczba >= w.wartosc
                    {
                        w = w.praweDziecko;
                    }
                }
                return w != null ? w : new Wezel3(-999);
            }

            //2. Wezel3 ZnajdzMin(Wezel3 w) - np. podaje 5, najmniejszosc wartosc w tym poddrzewie, tu zwroci 1 - na max w lewo idziemy
            public Wezel3 ZnajdzMin(Wezel3 w)
            {
                while (w.leweDziecko != null)
                {
                    w = w.leweDziecko;
                }
                return w;
            }

            //3. Wezel3 ZnajdzMax(Wezel3 w) - to samo, na max w prawo
            public Wezel3 ZnajdzMax(Wezel3 w)
            {
                while (w.praweDziecko != null)
                {
                    w = w.praweDziecko;
                }
                return w;
            }

            //4. Wezel3 Nastepnik(Wezel3 w) - nastepny po, np po 1 2
            public Wezel3 Nastepnik(Wezel3 w)
            {
                //1) gdy jest prawe dziecko, to uzyj funkcji znajdzMin(w.praweDziecko)
                if (w.praweDziecko != null)
                {
                    return ZnajdzMin(w.praweDziecko);
                }

                //2) gdy nie ma prawego dziecka idz do gory az wyjdziesz jako lewe dziecko w rodzinie, nastepnik to ten rodzic
                //3) gdy nie ma prawego dziecka, ide do gory, gdy nie zachodzi(2) i nie moge isc do gory => nie ma nastepnika
                while (w.rodzic != null)
                {
                    if (w.rodzic.leweDziecko == w)
                    {
                        return w.rodzic;
                    }
                    w = w.rodzic;
                }
                return new Wezel3(-999);
            }

            //4. Wezel3 Poprzednik(Wezel3 w)
            public Wezel3 Poprzednik(Wezel3 w)
            {
                //1) gdy jest lewe dziecko, to uzyj funkcji znajdzMax(w.leweDziecko)
                if (w.leweDziecko != null)
                {
                    return ZnajdzMax(w.leweDziecko);
                }

                //2) gdy nie ma lewego dziecka idz do gory az wyjdziesz jako prawe dziecko w rodzinie, poprzednik to ten rodzic
                //3) gdy nie ma lewego dziecka, ide do gory, gdy nie zachodzi(2) i nie moge isc do gory => nie ma poprzednika
                while (w.rodzic != null)
                {
                    if (w.rodzic.praweDziecko == w)
                    {
                        return w.rodzic;
                    }
                    w = w.rodzic;
                }
                return new Wezel3(-999);
            }

            public Wezel3 Usun(Wezel3 w)
            {
                switch (w.getLiczbaDzieci())
                {
                    case 0:
                        w = this.UsunGdy0Dzieci(w);
                        break;
                    case 1:
                        w = this.UsunGdy1Dzieci(w);
                        break;
                    case 2:
                        w = this.UsunGdy2Dzieci(w);
                        break;
                }

                return w;
            }

            private Wezel3 UsunGdy0Dzieci(Wezel3 w)
            {
                if (w.rodzic == null)
                {
                    this.korzen = null;
                    return w;
                }

                if (w.rodzic.leweDziecko == w)
                    w.rodzic.leweDziecko = null;
                else
                    w.rodzic.praweDziecko = null;

                w.rodzic = null;
                return w;
            }

            private Wezel3 UsunGdy1Dzieci(Wezel3 w)
            {
                Wezel3 dziecko = null;
                if (w.leweDziecko != null)
                {
                    dziecko = w.leweDziecko;
                    w.leweDziecko = null;
                }
                else
                {
                    dziecko = w.praweDziecko;
                    w.praweDziecko = null;
                }

                if (w.rodzic != null)
                {
                    if (w.rodzic.leweDziecko == w)
                        w.rodzic.leweDziecko = dziecko;
                    else
                        w.rodzic.praweDziecko = dziecko;
                }

                else
                {
                    this.korzen = dziecko;
                    dziecko.rodzic = null;

                    return w;
                }

                dziecko.rodzic = w.rodzic;
                w.rodzic = null;

                return w;
            }

            private Wezel3 UsunGdy2Dzieci(Wezel3 w)
            {
                var zamiennik = this.Nastepnik(w);
                zamiennik = this.Usun(zamiennik);

                if (w.rodzic == null)
                {
                    this.korzen = zamiennik;

                    if (w.leweDziecko != null)
                    {
                        zamiennik.leweDziecko = w.leweDziecko;

                        w.leweDziecko.rodzic = zamiennik;
                        w.leweDziecko = null;
                    }

                    if (w.praweDziecko != null)
                    {
                        zamiennik.praweDziecko = w.praweDziecko;

                        w.praweDziecko.rodzic = zamiennik;
                        w.praweDziecko = null;
                    }
                    return w;
                }

                if (w.rodzic != null)
                {
                    zamiennik.rodzic = w.rodzic;

                    if (w == w.rodzic.praweDziecko)
                    {
                        w.rodzic.praweDziecko = zamiennik;

                        //doczepnienie leweDziecko
                        w.leweDziecko.rodzic = zamiennik;
                        zamiennik.leweDziecko = w.leweDziecko;

                        w.leweDziecko = null;
                    }

                    if (w == w.rodzic.leweDziecko)
                    {
                        w.rodzic.leweDziecko = zamiennik;

                        //odczepienie leweDziecko
                        w.leweDziecko.rodzic = zamiennik;
                        zamiennik.leweDziecko = w.leweDziecko;
                        w.leweDziecko = null;
                    }

                    if (w.praweDziecko != null)
                    {
                        zamiennik.praweDziecko = w.praweDziecko;
                        w.praweDziecko.rodzic = zamiennik;
                        w.praweDziecko = null;
                    }
                }

                w.rodzic = null;

                return w;
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


        // --- Dijkstry ---
        private void btn5_Click(object sender, EventArgs e)
        {

        }


        /*
        public class Graf
        {
           List<Wezel44> listaWezlow = new();
           List<Wezel44> listaKrawedzi = new();
        }

        public class Wezel44
        {
           int wartosc;
           List<Wezel44> listaKrawedzi = new();
        }

        public class Krawedz
        {
           int waga;
           int poczatek;
           int koniec;
        }*/
        // --- Dijkstry ---
        private void button1_Click(object sender, EventArgs e)
        {

        }


        // --- Kruskal algorithm ---
        //https://eduinf.waw.pl/inf/alg/001_search/0141.php
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Kruskal graf 1
            WezelKruskal w0 = new WezelKruskal(0);
            WezelKruskal w1 = new WezelKruskal(1);
            WezelKruskal w2 = new WezelKruskal(2);
            WezelKruskal w3 = new WezelKruskal(3);
            WezelKruskal w4 = new WezelKruskal(4);
            WezelKruskal w5 = new WezelKruskal(5);
            WezelKruskal w6 = new WezelKruskal(6);
            WezelKruskal w7 = new WezelKruskal(7);

            /*krawedzie wychodzace z danego wezla
            0: 1, 3, 6
            1: 0, 2, 4, 5, 7
            2: 1, 3, 4, 6, 7
            3: 0, 2, 6
            4: 1, 2, 5, 6
            5: 1, 4, 6
            6: 0, 2, 3, 4, 5, 7
            7: 1, 2, 6
            */

            w0.DodajKrawedz(new List<(WezelKruskal, int)> { (w1, 5), (w3, 9), (w6, 3) });
            w1.DodajKrawedz(new List<(WezelKruskal, int)> { (w0, 5), (w2, 9), (w4, 8), (w5, 6), (w7, 7) });
            w2.DodajKrawedz(new List<(WezelKruskal, int)> { (w1, 9), (w3, 9), (w4, 4), (w6, 5), (w7, 3) });
            w3.DodajKrawedz(new List<(WezelKruskal, int)> { (w0, 9), (w2, 9), (w6, 8) });
            w4.DodajKrawedz(new List<(WezelKruskal, int)> { (w1, 8), (w2, 4), (w5, 2), (w6, 1) });
            w5.DodajKrawedz(new List<(WezelKruskal, int)> { (w1, 6), (w4, 2), (w6, 6) });
            w6.DodajKrawedz(new List<(WezelKruskal, int)> { (w0, 3), (w2, 5), (w3, 8), (w4, 1), (w5, 6), (w7, 9) });
            w7.DodajKrawedz(new List<(WezelKruskal, int)> { (w1, 7), (w2, 3), (w6, 9) });

            Graf graf = new Graf();
            graf.listaWezlow.AddRange(new List<WezelKruskal> { w0, w1, w2, w3, w4, w5, w6, w7 });
            

            //Kruskal graf 2
            /*WezelKruskal w0 = new WezelKruskal(0);
            WezelKruskal w1 = new WezelKruskal(1);
            WezelKruskal w2 = new WezelKruskal(2);
            WezelKruskal w3 = new WezelKruskal(3);
            WezelKruskal w4 = new WezelKruskal(4);
            WezelKruskal w5 = new WezelKruskal(5);

            *//*krawedzie wychodzace z danego wezla
            0: 1, 2
            1: 0, 2
            2: 0, 1, 3, 4, 5
            3: 2, 5
            4: 2, 5
            5: 2, 3, 4
            *//*

            w0.DodajKrawedz(new List<(WezelKruskal, int)> { (w1, 4), (w2, 4) });
            w1.DodajKrawedz(new List<(WezelKruskal, int)> { (w0, 4), (w2, 2) });
            w2.DodajKrawedz(new List<(WezelKruskal, int)> { (w0, 4), (w1, 2), (w3, 2), (w4, 3), (w5, 4) });
            w3.DodajKrawedz(new List<(WezelKruskal, int)> { (w2, 2), (w5, 3) });
            w4.DodajKrawedz(new List<(WezelKruskal, int)> { (w2, 3), (w5, 3) });
            w5.DodajKrawedz(new List<(WezelKruskal, int)> { (w2, 4), (w3, 3), (w4, 3) });

            Graf graf = new Graf();
            graf.listaWezlow.AddRange(new List<WezelKruskal> { w0, w1, w2, w3, w4, w5});*/



            //umieszczenie wszystkich krawedzi (z duplikatami, np. 4-6 i 6-4) w notSortList
            List<Krawedz> notSortedKrawedzie = new();
            foreach(WezelKruskal wezelKruskal in graf.listaWezlow)
            {
                foreach(Krawedz krawedz in wezelKruskal.listaKrawedzi)
                {
                    if (!notSortedKrawedzie.Contains(krawedz))
                        notSortedKrawedzie.Add(krawedz);
                }
            }

            //sortowanie od A do Z
            List<Krawedz> sortedKrawedzie = notSortedKrawedzie.OrderBy(krawedz => krawedz.waga).ToList();

            //wyswietlenie notSortedKrawedzie
            /*string notSortedKrawedzieString = "";
            for (int i = 0; i < notSortedKrawedzie.Count - 1; i++)
            {
                notSortedKrawedzieString += $"{notSortedKrawedzie[i].poczatek.wartosc}-{notSortedKrawedzie[i].koniec.wartosc}: {notSortedKrawedzie[i].waga}\n";
            }
            MessageBox.Show("notSortedKrawedzie:\n" + notSortedKrawedzieString);*/

            //wyswietlenie sortedKrawedzie od A do Z
            /*string sortedKrawedzieString = "sortedKrawedzie:\n";
            foreach(Krawedz krawedz in sortedKrawedzie)
            {
                sortedKrawedzieString += $"{krawedz.poczatek.wartosc}-{krawedz.koniec.wartosc}: {krawedz.waga}\n";
            }
            MessageBox.Show(sortedKrawedzieString);*/

            //Wynikowe polecenie zwracajace utworzony graf rozpinajacy (bez cykli)
            Graf drzewoRozpinajace = graf.UtworzGrafRozpinajacy(sortedKrawedzie)[0];

            //sprawdzenie poszczegolnych stanow grafu rozpinajacego
            //wyswietlenie wagi
            int sumaWag = 0;
            foreach (Krawedz krawedz in drzewoRozpinajace.listaKrawedzi)
            {
                sumaWag += krawedz.waga;
            }
            //wyswietlenie krawedzi
            string wynikKrawedzie = "";
            for (int i = 0; i < drzewoRozpinajace.listaKrawedzi.Count; i++)
            {
                wynikKrawedzie += drzewoRozpinajace.listaKrawedzi[i].poczatek.wartosc.ToString() + " - " + drzewoRozpinajace.listaKrawedzi[i].koniec.wartosc.ToString() + "\n";
            }
            //wyswietlenie wezlow
            string wynikWezly = "";
            for (int i = 0; i < drzewoRozpinajace.listaWezlow.Count; i++)
            {
                wynikWezly += drzewoRozpinajace.listaWezlow[i].wartosc.ToString() + "\n";
            }
            MessageBox.Show("Krawedzie:\n" + wynikKrawedzie + "\nWezly:\n" + wynikWezly + "\nWaga drzewa rozpinajacego: " + sumaWag);
        }

        public class Graf
        {
            public List<WezelKruskal> listaWezlow = new();
            public List<Krawedz> listaKrawedzi = new();
            public List<Graf> listaGraf = new();//przechowuje osobne grafy rozpinajace, ktore nastepnie scalamy w jeden wynikowy

            public Graf()
            {
                listaWezlow = new List<WezelKruskal>();
            }

            public List<Graf> UtworzGrafRozpinajacy(List<Krawedz> krawedzie)
            {
                Graf graf = new();
                WezelKruskal wezel_p;
                WezelKruskal wezel_k;
                WezelKruskal tempWezel;

                foreach(Krawedz krawedz in krawedzie)
                {
                    
                    wezel_p = new WezelKruskal(krawedz.poczatek.wartosc);
                    wezel_k = new WezelKruskal(krawedz.koniec.wartosc);
                    wezel_p.DodajKrawedzSingle(krawedz);
                    wezel_k.DodajKrawedzSingle(krawedz);

                    //graf bez wezlow poczatkowych
                    if (listaGraf.Count == 0)
                    {
                        graf.listaWezlow.AddRange(new List<WezelKruskal>{ wezel_p, wezel_k });
                        graf.listaKrawedzi.Add(krawedz);
                        listaGraf.Add(graf);
                    }
                    else
                    {
                        //doczepienie wezla z krawedzia do istniejacego grafu
                        if (WezlyPasujace(krawedz) == 1)
                        {
                            for (int j = 0; j < listaGraf.Count; j++)
                            {
                                for (int k = 0; k < listaGraf[j].listaWezlow.Count; k++)
                                {
                                    /*MessageBox.Show("wezly w G(" + j.ToString() + "): "
                                        + listaGraf[j].listaWezlow.Count.ToString() 
                                        + "\n(" + krawedz.poczatek.wartosc.ToString() + ") == "
                                        + listaGraf[j].listaWezlow[k].wartosc.ToString()
                                        + " dla k: (" + krawedz.poczatek.wartosc.ToString()
                                        + ")-" + krawedz.koniec.wartosc.ToString());*/
                                    //czy krawedz (poczatek) ze stosu krawedzi laczy sie z danym wezlem w danym grafie
                                    if (krawedz.poczatek.wartosc == listaGraf[j].listaWezlow[k].wartosc)
                                    {
                                        listaGraf[j].listaKrawedzi.Add(krawedz);
                                        listaGraf[j].listaWezlow.Add(krawedz.koniec);
                                        break;
                                    }
                                    //czy krawedz (koniec) ze stosu krawedzi laczy sie z danym wezlem w danym grafie
                                    else if (krawedz.koniec.wartosc == listaGraf[j].listaWezlow[k].wartosc)
                                    {
                                        listaGraf[j].listaKrawedzi.Add(krawedz);
                                        listaGraf[j].listaWezlow.Add(krawedz.poczatek);
                                        break;
                                    }
                                }
                            }
                        }
                        //polaczenie dwoch grafow w jeden rozpinajacy
                        else if (WezlyPasujace(krawedz) == 2)
                        {
                            tempWezel = ZwrocWezelDoPodczepieniaSingle(listaGraf, krawedz.poczatek);
                            WezelKruskal tempWezel2 = ZwrocWezelDoPodczepieniaSingle(listaGraf, krawedz.koniec);
                            Graf grafScalony = new();

                            List<int> indexToRemove = new();
                            for (int j = 0; j < listaGraf.Count; j++)
                            {
                                //czy graf[j] zawiera krawedz.p/.k
                                if (listaGraf[j].listaWezlow.Contains(tempWezel))
                                {
                                    //przeniesienie krawedzi/wezlow do grafu scalonego
                                    for (int k = 0; k < listaGraf[j].listaKrawedzi.Count; k++)
                                    {
                                        grafScalony.listaKrawedzi.Add(listaGraf[j].listaKrawedzi[k]);
                                    }
                                    for (int k = 0; k < listaGraf[j].listaWezlow.Count; k++)
                                    {
                                        grafScalony.listaWezlow.Add(listaGraf[j].listaWezlow[k]);
                                    }

                                    indexToRemove.Add(j);
                                }

                                if (listaGraf[j].listaWezlow.Contains(tempWezel2))
                                {
                                    //przeniesienie krawedzi/wezlow do grafu scalonego
                                    for (int k = 0; k < listaGraf[j].listaKrawedzi.Count; k++)
                                    {
                                        grafScalony.listaKrawedzi.Add(listaGraf[j].listaKrawedzi[k]);
                                    }
                                    for (int k = 0; k < listaGraf[j].listaWezlow.Count; k++)
                                    {
                                        grafScalony.listaWezlow.Add(listaGraf[j].listaWezlow[k]);
                                    }

                                    indexToRemove.Add(j);
                                }
                            }

                            grafScalony.listaKrawedzi.Add(krawedz);
                            listaGraf.RemoveAt(indexToRemove[1]);
                            listaGraf.RemoveAt(indexToRemove[0]);
                            listaGraf.Insert(0, grafScalony);//prawdopodobnie zapobiega dla n>2 grafow rozpinajacych
                        }
                        //utworzenie odrebnego grafu rozpinajacego
                        else if (WezlyPasujace(krawedz) == 0)
                        {
                            graf = new Graf();
                            graf.listaWezlow.AddRange(new List<WezelKruskal> { wezel_p, wezel_k });
                            graf.listaKrawedzi.Add(krawedz);
                            listaGraf.Add(graf);
                        }
                        //przypadek likwidujacy powstanie cykli
                        /*else if (WezlyPasujace(krawedz) == -2)
                        {
                            //MessageBox.Show("Cykl");
                        }*/

                        /*MessageBox.Show(krawedz.poczatek.wartosc.ToString() + " --(" 
                            + krawedz.waga.ToString() + ")--> " + krawedz.koniec.wartosc.ToString()
                            + "\nIlosc grafow rozpinajacych: " + listaGraf.Count.ToString());*/
                    }
                }
                
                return listaGraf;
            }

            public int WezlyPasujace(Krawedz krawedz)
            {
                int sumaPasujacych = 0;
                foreach (Graf graf in listaGraf)
                {
                    int pasujaceWezly = graf.listaWezlow.Count(wezel =>
                        wezel.wartosc == krawedz.poczatek.wartosc || wezel.wartosc == krawedz.koniec.wartosc);//zapobiega powstawaniu cyklu

                    sumaPasujacych += pasujaceWezly;

                    if (pasujaceWezly == 2)
                        return -2; //w danym grafie mamy cykl
                }

                return sumaPasujacych;
            }

            public WezelKruskal ZwrocWezelDoPodczepieniaSingle(List<Graf> grafy, WezelKruskal krawedz_p_lub_k)
            {
                foreach (Graf graf in grafy)
                {
                    foreach(WezelKruskal wezel in graf.listaWezlow)
                    {
                        if(wezel.wartosc == krawedz_p_lub_k.wartosc)
                            return wezel;
                    }
                }

                return null;
            }
        }

        public class WezelKruskal
        {
            public int wartosc;
            public List<WezelKruskal> listaWezlow = new();
            public List<Krawedz> listaKrawedzi = new();

            public WezelKruskal(int wartosc)
            {
                this.wartosc = wartosc;
            }

            public void DodajKrawedz(List<(WezelKruskal, int)> krawedz)
            {
                foreach((WezelKruskal wezel, int waga) in krawedz)
                {
                    this.listaWezlow.Add(wezel);
                    this.listaKrawedzi.Add(new Krawedz(this, wezel, waga));
                } 
            }

            //metoda wykorzystywana w UtworzGrafRozpinajacy()
            public void DodajKrawedzSingle(Krawedz krawedz)
            {
                this.listaWezlow.Add(krawedz.poczatek);
                this.listaKrawedzi.Add(krawedz);
            }
        }

        public class Krawedz
        {
            public WezelKruskal poczatek;
            public WezelKruskal koniec;
            public int waga;

            public Krawedz(WezelKruskal poczatek, WezelKruskal koniec, int waga)
            {
                this.poczatek = poczatek;
                this.koniec = koniec;
                this.waga = waga;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Krawedz other = (Krawedz)obj;

                return (poczatek == other.poczatek && koniec == other.koniec) ||
                       (poczatek == other.koniec && koniec == other.poczatek);
            }
        }
        // --- Kruskal algorithm ---

        // [---] W DOMU DOKONCZYC [---]

        //kolokwium - x1 teoria i x1 praktyka, np. przeprowadz algorytm
        //praktyka - zad z nastepnikiem i poprzednikiem raczej

        // [---] W DOMU DOKONCZYC [---]
    }
}