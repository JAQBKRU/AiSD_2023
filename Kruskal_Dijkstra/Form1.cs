using System.Linq;
using System.Text;
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


        // --- Dijkstra algorithm - Szypul ---
        //https://eduinf.waw.pl/inf/alg/001_search/0138.php
        private void button2_Click(object sender, EventArgs e)
        {
            WezelDijkstra w0 = new WezelDijkstra(0);
            WezelDijkstra w1 = new WezelDijkstra(1);
            WezelDijkstra w2 = new WezelDijkstra(2);
            WezelDijkstra w3 = new WezelDijkstra(3);
            WezelDijkstra w4 = new WezelDijkstra(4);
            WezelDijkstra w5 = new WezelDijkstra(5);

            w0.DodajKrawedz(w1, 3);
            w0.DodajKrawedz(w4, 3);
            w1.DodajKrawedz(w2, 1);
            w2.DodajKrawedz(w3, 3);
            w2.DodajKrawedz(w5, 1);
            w3.DodajKrawedz(w1, 4);
            w4.DodajKrawedz(w5, 2);
            w5.DodajKrawedz(w3, 1);
            w5.DodajKrawedz(w0, 6);

            GrafDijkstra grafDijkstra = new();
            grafDijkstra.listaWezlow = new List<WezelDijkstra> { w0, w1, w2, w3, w4, w5 };
            var tabela = grafDijkstra.DijkstraTabela(w0);
            grafDijkstra.DijkstraAlgorytm(tabela);

            MessageBox.Show(grafDijkstra.WyswietlTabele(tabela));
            MessageBox.Show(grafDijkstra.SciezkaDoWezla(tabela, w3));
        }

        public class GrafDijkstra
        {
            public List<WezelDijkstra> listaWezlow = new();
            public List<WezelDijkstra> listaKrawedzi = new();

            public GrafDijkstra()
            {
                this.listaWezlow = new List<WezelDijkstra>();
                this.listaKrawedzi = new List<WezelDijkstra>();
            }

            //utworzenie domyslnej tabeli
            public Dictionary<WezelDijkstra, Element> DijkstraTabela(WezelDijkstra w)
            {
                var tabela = new Dictionary<WezelDijkstra, Element>();

                foreach (WezelDijkstra wezel in this.listaWezlow)
                {
                    var e = new Element();

                    if (wezel == w)
                    {
                        e.d = 0;
                        e.p = new WezelDijkstra(-1);
                    }
                    tabela.Add(wezel, e);
                }
                return tabela;
            }

            public void DijkstraAlgorytm(Dictionary<WezelDijkstra, Element> tabela)
            {
                while (true)
                {
                    var niezrobione = tabela.Where(item => !item.Value.czyZrobione);

                    if (niezrobione.Count() == 0)
                        break;

                    var min = niezrobione.OrderBy(item => item.Value.d).First();
                    min.Value.czyZrobione = true;

                    foreach (KrawedzDijkstra krawedz in min.Key.listaKrawedzi)
                    {
                        var nowyD = min.Value.d + krawedz.waga;

                        if (nowyD < tabela[krawedz.koniec].d)
                        {
                            tabela[krawedz.koniec].d = nowyD;
                            tabela[krawedz.koniec].p = min.Key;

                        }
                    }
                }
            }

            public string WyswietlTabele(Dictionary<WezelDijkstra, Element> tab)
            {
                string N = "";
                string d = "";
                string p = "";
                for (int i = 0; i < tab.Count(); i++)
                {
                    N += i + " ";
                    d += tab[this.listaWezlow[i]].d + " ";
                    p += tab[this.listaWezlow[i]].p.wartosc + " ";
                }

                return $"N: {N}\nd: {d}\np: {p}";
            }

            public string SciezkaDoWezla(Dictionary<WezelDijkstra, Element> tabela, WezelDijkstra wezel)
            {
                WezelDijkstra aktualnyWezel = tabela[wezel].p;
                StringBuilder sciezka = new(wezel.wartosc.ToString());

                while (aktualnyWezel.wartosc != -1)
                {
                    sciezka.Insert(0, aktualnyWezel.wartosc);
                    aktualnyWezel = tabela[aktualnyWezel].p;
                }

                return $"Sciezka do {wezel.wartosc}: {sciezka}";
            }
        }

        public class WezelDijkstra
        {
            public int wartosc;
            public List<KrawedzDijkstra> listaKrawedzi = new();

            public WezelDijkstra() { }

            public WezelDijkstra(int liczba)
            {
                this.wartosc = liczba;
            }

            public void DodajKrawedz(WezelDijkstra w, int waga)
            {
                this.listaKrawedzi.Add(new KrawedzDijkstra(this, w, waga));
                w.listaKrawedzi.Add(new KrawedzDijkstra(w, this, waga));
            }
        }

        public class Element
        {
            public int d;
            public WezelDijkstra p = new();
            public bool czyZrobione;

            public Element()
            {
                this.d = int.MaxValue;
                this.p = null;
                this.czyZrobione = false;
            }
        }

        public class KrawedzDijkstra
        {
            public WezelDijkstra poczatek;
            public WezelDijkstra koniec;
            public int waga;

            public KrawedzDijkstra(WezelDijkstra poczatek, WezelDijkstra koniec, int waga)
            {
                this.poczatek = poczatek;
                this.koniec = koniec;
                this.waga = waga;
            }
        }
        // --- Dijkstra algorithm - Szypul ---

        /*// --- Dijkstra algorithm ---
        //https://eduinf.waw.pl/inf/alg/001_search/0138.php
        private void button2_Click(object sender, EventArgs e)
        {
            WezelDijkstra w0 = new WezelDijkstra(0);
            WezelDijkstra w1 = new WezelDijkstra(1);
            WezelDijkstra w2 = new WezelDijkstra(2);
            WezelDijkstra w3 = new WezelDijkstra(3);
            WezelDijkstra w4 = new WezelDijkstra(4);
            WezelDijkstra w5 = new WezelDijkstra(5);

            w0.DodajKrawedz(new List<(WezelDijkstra, int)> { (w1, 3), (w4, 3) });
            w1.DodajKrawedz(new List<(WezelDijkstra, int)> { (w2, 1) });
            w2.DodajKrawedz(new List<(WezelDijkstra, int)> { (w3, 3), (w5, 1) });
            w3.DodajKrawedz(new List<(WezelDijkstra, int)> { (w1, 3) });
            w4.DodajKrawedz(new List<(WezelDijkstra, int)> { (w5, 2) });
            w5.DodajKrawedz(new List<(WezelDijkstra, int)> { (w3, 1), (w0, 6) });

            GrafDijkstra grafDijkstra = new();
            grafDijkstra.listaWezlow.AddRange(new List<WezelDijkstra> { w0, w1, w2, w3, w4, w5 });
            grafDijkstra.DijkstraAlgorithm();
        }

        public class GrafDijkstra
        {
            public List<WezelDijkstra> listaWezlow = new();
            public List<WezelDijkstra> listaKrawedzi = new();
            public List<int> listaD = new();//zawiera najmniejsze koszty dojscia do danego wezla
            public List<WezelDijkstra> listaP = new();//zawiera poprzedni wezel od aktualnego

            public List<int> listaS = new();//wezly po operacji
            public List<int> listaQ = new();//wezly oczekujace przed operacji

            public GrafDijkstra()
            {
                this.listaWezlow = new List<WezelDijkstra>();
            }

            public void DijkstraAlgorithm()
            {
                //inicjalizacja podstawowych danych
                for (int i = 0; i < listaWezlow.Count; i++)
                {
                    listaQ.Add(listaWezlow[i].wartosc);
                    listaD.Add(int.MaxValue);//int.MaxValue to +inf
                    listaP.Add(new WezelDijkstra(-1));
                }

                listaD[0] = 0;//najkrotsza droga z 0 do ...

                //N: 0...5
                for (int i = 0; i < listaWezlow.Count; i++)
                {
                    int kosztMin = NajmniejszyKoszt(listaD);
                    string listaPwynik = "";
                    foreach (WezelDijkstra w in listaP) listaPwynik += w.wartosc.ToString() + " ";
                    MessageBox.Show($"S: {string.Join(", ", listaS)}\nQ: {string.Join(", ", listaQ)}\nd: {string.Join(", ", listaD)}\np: {listaPwynik}");//wyswietlanie stanu tabel po kazdej iteracji

                    //iterujemy po sasiadach, po krawedziach w najmniejszym listaD
                    foreach (KrawedzDijkstra krawedz in listaWezlow[kosztMin].listaKrawedzi)
                    {
                        int wezel_p = krawedz.poczatek.wartosc;
                        int wezel_k = krawedz.koniec.wartosc;

                        //aktualizowanie tabeli - porownywanie wezlow na krawedzi
                        if (listaD[wezel_k] > (listaD[wezel_p] + krawedz.waga))
                        {
                            listaD[wezel_k] = listaD[wezel_p] + krawedz.waga;
                            listaP[wezel_k] = krawedz.poczatek;
                        }
                    }
                }

                //wyswietlenie koncowej tabeli i sciezki do danego wezla
                string N = "";
                string d = "";
                string p = "";
                foreach (WezelDijkstra x in listaWezlow) N += x.wartosc.ToString() + " ";
                foreach (int x in listaD) d += x.ToString() + " ";
                foreach (WezelDijkstra x in listaP) p += x.wartosc.ToString() + " ";
                MessageBox.Show($"N: {N}\nd: {d}\np: {p}\n{SciezkaDojsciaDoWezla(2)}");
            }

            public int NajmniejszyKoszt(List<int> listaD)
            {
                List<int> kopiaD = listaD.ToList();
                int min = kopiaD.Min();
                int minIndex = listaD.IndexOf(min);

                if (!listaQ.Contains(minIndex))
                {
                    kopiaD[minIndex] = int.MaxValue;
                    return NajmniejszyKoszt(kopiaD);
                }

                listaS.Add(minIndex);
                listaQ.Remove(minIndex);

                return minIndex;
            }

            public string SciezkaDojsciaDoWezla(int wezel)
            {
                WezelDijkstra aktualnyWezel = listaP[wezel];
                StringBuilder sciezka = new(wezel.ToString());

                while (aktualnyWezel.wartosc != -1)
                {
                    sciezka.Append(aktualnyWezel.wartosc);
                    aktualnyWezel = listaP[aktualnyWezel.wartosc];
                }

                return $"sciezka do  {wezel}: {new string(sciezka.ToString().Reverse().ToArray())}";
            }
        }

        public class WezelDijkstra
        {
            public List<KrawedzDijkstra> listaKrawedzi = new();
            public int wartosc;

            public WezelDijkstra(int liczba)
            {
                this.wartosc = liczba;
            }

            public void DodajKrawedz(List<(WezelDijkstra, int)> krawedz)
            {
                foreach ((WezelDijkstra wezel, int waga) in krawedz)
                {
                    this.listaKrawedzi.Add(new KrawedzDijkstra(this, wezel, waga));
                    //wezel.listaKrawedzi.Add(new KrawedzDijkstra(wezel, this, waga));//bez tego dla grafu skierowanego
                }
            }
        }

        public class KrawedzDijkstra
        {
            public WezelDijkstra poczatek;
            public WezelDijkstra koniec;
            public int waga;

            public KrawedzDijkstra(WezelDijkstra poczatek, WezelDijkstra koniec, int waga)
            {
                this.poczatek = poczatek;
                this.koniec = koniec;
                this.waga = waga;
            }
        }
        // --- Dijkstra algorithm ---*/



        // --- Kruskal algorithm ---
        //https://eduinf.waw.pl/inf/alg/001_search/0141.php
        private void button1_Click_1(object sender, EventArgs e)
        {
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

            Graf graf = new();
            graf.listaWezlow = new List<WezelKruskal> { w0, w1, w2, w3, w4, w5, w6, w7 };
            graf.listaKrawedzi = new List<KrawedzKruskal>
            {
                new KrawedzKruskal(w4, w6, 1),
                new KrawedzKruskal(w4, w5, 2),
                new KrawedzKruskal(w2, w7, 3),
                new KrawedzKruskal(w0, w6, 3),
                new KrawedzKruskal(w2, w4, 4),
                new KrawedzKruskal(w0, w1, 5),
                new KrawedzKruskal(w2, w6, 5),
                new KrawedzKruskal(w1, w5, 6),
                new KrawedzKruskal(w5, w6, 6),
                new KrawedzKruskal(w1, w7, 7),
                new KrawedzKruskal(w1, w4, 8),
                new KrawedzKruskal(w3, w6, 8),
                new KrawedzKruskal(w0, w3, 9),
                new KrawedzKruskal(w1, w2, 9),
                new KrawedzKruskal(w2, w3, 9),
                new KrawedzKruskal(w6, w7, 9)
            };

            //Wynikowe polecenie zwracajace utworzony graf rozpinajacy (bez cykli)
            Graf drzewoRozpinajace = graf.UtworzGrafRozpinajacy()[0];

            //sprawdzenie poszczegolnych stanow grafu rozpinajacego
            //wyswietlenie wagi
            int sumaWag = 0;
            foreach (KrawedzKruskal krawedz in drzewoRozpinajace.listaKrawedzi)
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
            public List<KrawedzKruskal> listaKrawedzi = new();
            public List<Graf> listaGrafow = new();//przechowuje osobne grafy rozpinajace, ktore nastepnie scalamy w jeden wynikowy

            public Graf()
            {
                listaWezlow = new List<WezelKruskal>();
            }

            public List<Graf> UtworzGrafRozpinajacy()
            {
                Graf graf = new();

                //posortowanie krawedzi wg wagi ASC
                listaKrawedzi = listaKrawedzi.OrderBy(k => k.waga).ToList();

                foreach (KrawedzKruskal krawedz in listaKrawedzi)
                {
                    WezelKruskal wezel_p = new(krawedz.poczatek.wartosc);
                    WezelKruskal wezel_k = new(krawedz.koniec.wartosc);
                    wezel_p.DodajKrawedz(krawedz, 'k');
                    wezel_k.DodajKrawedz(krawedz, 'p');

                    int wezlyPasujace = WezlyPasujace(krawedz);//return: 0,1,2

                    //graf bez wezlow poczatkowych
                    if (listaGrafow.Count == 0)
                    {
                        graf.listaWezlow.AddRange(new List<WezelKruskal> { wezel_p, wezel_k });
                        graf.listaKrawedzi.Add(krawedz);
                        listaGrafow.Add(graf);
                    }
                    else
                    {
                        //doczepienie wezla z krawedzia do istniejacego grafu
                        if (wezlyPasujace == 1)
                        {
                            foreach (var g in listaGrafow)
                            {
                                foreach (var wezel in g.listaWezlow)
                                {
                                    var aktualnyWierzcholek = krawedz.poczatek;

                                    if (aktualnyWierzcholek.wartosc == wezel.wartosc)
                                    {
                                        wezel.listaWezlow.Add(krawedz.koniec);
                                        wezel.listaKrawedzi.Add(krawedz);

                                        g.listaKrawedzi.Add(krawedz);
                                        var x1 = new WezelKruskal(krawedz.koniec.wartosc);
                                        x1.DodajKrawedz(krawedz, 'p');
                                        g.listaWezlow.Add(x1);
                                        aktualnyWierzcholek.listaWezlow.Add(x1);
                                        break;
                                    }

                                    aktualnyWierzcholek = krawedz.koniec;

                                    if (aktualnyWierzcholek.wartosc == wezel.wartosc)
                                    {
                                        wezel.listaWezlow.Add(krawedz.poczatek);
                                        wezel.listaKrawedzi.Add(krawedz);

                                        g.listaKrawedzi.Add(krawedz);
                                        var x2 = new WezelKruskal(krawedz.poczatek.wartosc);
                                        x2.DodajKrawedz(krawedz, 'k');
                                        g.listaWezlow.Add(x2);
                                        aktualnyWierzcholek.listaWezlow.Add(x2);
                                        break;
                                    }
                                }
                            }
                        }
                        //polaczenie dwoch grafow w jeden rozpinajacy
                        else if (wezlyPasujace == 2)
                        {
                            WezelKruskal tempWezel = ZwrocWezelDoPodczepienia(krawedz.poczatek);
                            WezelKruskal tempWezel2 = ZwrocWezelDoPodczepienia(krawedz.koniec);
                            Graf grafScalony = new();

                            List<int> indexToRemove = new();
                            for (int j = 0; j < listaGrafow.Count; j++)
                            {
                                if (listaGrafow[j].listaWezlow.Contains(tempWezel) || listaGrafow[j].listaWezlow.Contains(tempWezel2))
                                {
                                    if (listaGrafow[j].listaWezlow.Contains(tempWezel))
                                    {
                                        tempWezel.listaWezlow.Add(tempWezel2);
                                        tempWezel.listaKrawedzi.Add(krawedz);
                                    }
                                    if (listaGrafow[j].listaWezlow.Contains(tempWezel2))
                                    {
                                        tempWezel2.listaWezlow.Add(tempWezel);
                                        tempWezel2.listaKrawedzi.Add(krawedz);
                                    }

                                    //przeniesienie krawedzi/wezlow do grafu scalonego
                                    grafScalony.listaKrawedzi.AddRange(listaGrafow[j].listaKrawedzi);
                                    grafScalony.listaWezlow.AddRange(listaGrafow[j].listaWezlow);
                                    indexToRemove.Add(j);
                                }
                            }

                            grafScalony.listaKrawedzi.Add(krawedz);
                            listaGrafow.RemoveAt(indexToRemove[1]);
                            listaGrafow.RemoveAt(indexToRemove[0]);
                            listaGrafow.Insert(0, grafScalony);//prawdopodobnie zapobiega dla n>2 grafow rozpinajacych
                        }
                        //utworzenie odrebnego grafu rozpinajacego
                        else if (wezlyPasujace == 0)
                        {
                            graf = new Graf();
                            graf.listaWezlow.AddRange(new List<WezelKruskal> { wezel_p, wezel_k });
                            graf.listaKrawedzi.Add(krawedz);
                            listaGrafow.Add(graf);
                        }
                    }
                }

                return listaGrafow;
            }

            public int WezlyPasujace(KrawedzKruskal krawedz)
            {
                int sumaPasujacych = 0;
                foreach (Graf graf in listaGrafow)
                {
                    int pasujaceWezly = graf.listaWezlow.Count(wezel =>
                        wezel.wartosc == krawedz.poczatek.wartosc || wezel.wartosc == krawedz.koniec.wartosc);//zapobiega powstawaniu cyklu

                    sumaPasujacych += pasujaceWezly;

                    if (pasujaceWezly == 2)
                        return -2; //w danym grafie mamy cykl
                }

                return sumaPasujacych;
            }

            public WezelKruskal ZwrocWezelDoPodczepienia(WezelKruskal krawedz_p_lub_k)
            {
                foreach (Graf graf in listaGrafow)
                {
                    foreach (WezelKruskal wezel in graf.listaWezlow)
                    {
                        if (wezel.wartosc == krawedz_p_lub_k.wartosc)
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
            public List<KrawedzKruskal> listaKrawedzi = new();

            public WezelKruskal(int wartosc)
            {
                this.wartosc = wartosc;
            }

            public void DodajKrawedz(KrawedzKruskal krawedz, char znak)
            {
                this.listaKrawedzi.Add(krawedz);

                if(znak == 'p')
                    this.listaWezlow.Add(krawedz.poczatek);
                else
                    this.listaWezlow.Add(krawedz.koniec);
            }
        }

        public class KrawedzKruskal
        {
            public WezelKruskal poczatek;
            public WezelKruskal koniec;
            public int waga;

            public KrawedzKruskal(WezelKruskal poczatek, WezelKruskal koniec, int waga)
            {
                this.poczatek = poczatek;
                this.koniec = koniec;
                this.waga = waga;
            }
        }
        // --- Kruskal algorithm ---

        // [---] W DOMU DOKONCZYC [---]
        //listy jednokierunkowe i dwukierunkowe - operacje na nich
        //https://eduinf.waw.pl/inf/alg/001_search/0086.php

        //kolokwium - x1 teoria i x1 praktyka, np. przeprowadz algorytm
        //praktyka - zad z nastepnikiem i poprzednikiem raczej

        // [---] W DOMU DOKONCZYC [---]
    }
}