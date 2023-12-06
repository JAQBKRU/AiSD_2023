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

            /*drzewo.Add(3);
            drzewo.Add(3);
            drzewo.Add(6);
            drzewo.Add(7);
            drzewo.Add(-3);
            drzewo.Add(2);
            drzewo.Add(0);
            drzewo.Add(1);*/
            drzewo.Add(3);
            drzewo.Add(4);
            drzewo.Add(8);
            drzewo.Add(6);
            drzewo.Add(7);
            drzewo.Add(2);
            drzewo.Add(3);
            drzewo.Add(5);
            drzewo.Add(1);

            /*MessageBox.Show("Zad1: " + drzewo.Znajdz(6).ToString()
                + "\nZad2: " + ZnajdzMin(drzewo.korzen).wartosc.ToString()
                + "\nZad3: " + ZnajdzMax(drzewo.korzen).wartosc.ToString()
                + "\nZad4[5]: " + Nastepnik(drzewo.Znajdz(5)).wartosc.ToString()
                + "\nZad4[3]: " + Nastepnik(drzewo.Znajdz(3)).wartosc.ToString()
                + "\nZad4[4]: " + Nastepnik(drzewo.Znajdz(4)).wartosc.ToString()
                + "\nZad4[8]: " + Nastepnik(drzewo.Znajdz(8)).wartosc.ToString()
                + "\nZad4[6]: " + Nastepnik(drzewo.Znajdz(6)).wartosc.ToString()
                + "\nZad4[7]: " + Nastepnik(drzewo.Znajdz(7)).wartosc.ToString()
                + "\nZad4[2]: " + Nastepnik(drzewo.Znajdz(2)).wartosc.ToString()
                + "\nZad4[3]: " + Nastepnik(drzewo.korzen.leweDziecko.praweDziecko.leweDziecko).wartosc.ToString()
                + "\nZad4[5]: " + Nastepnik(drzewo.korzen.praweDziecko.leweDziecko.leweDziecko).wartosc.ToString()
                + "\nZad4[1]: " + Nastepnik(drzewo.Znajdz(1)).wartosc.ToString());*/

            /*MessageBox.Show("Zad4[5]: " + Poprzednik(drzewo.Znajdz(5)).wartosc.ToString()
                + "\nZad4[3]: " + Poprzednik(drzewo.Znajdz(3)).wartosc.ToString()
                + "\nZad4[4]: " + Poprzednik(drzewo.Znajdz(4)).wartosc.ToString()
                + "\nZad4[8]: " + Poprzednik(drzewo.Znajdz(8)).wartosc.ToString()
                + "\nZad4[6]: " + Poprzednik(drzewo.Znajdz(6)).wartosc.ToString()
                + "\nZad4[7]: " + Poprzednik(drzewo.Znajdz(7)).wartosc.ToString()
                + "\nZad4[2]: " + Poprzednik(drzewo.Znajdz(2)).wartosc.ToString()
                + "\nZad4[3]: " + Poprzednik(drzewo.korzen.leweDziecko.praweDziecko.leweDziecko).wartosc.ToString()
                + "\nZad4[5]: " + Poprzednik(drzewo.korzen.praweDziecko.leweDziecko.leweDziecko).wartosc.ToString()
                + "\nZad4[1]: " + Poprzednik(drzewo.Znajdz(1)).wartosc.ToString());*/

            //Usun(drzewo.korzen.leweDziecko.leweDziecko.leweDziecko);
            //MessageBox.Show("Usun(1): " + ZnajdzMin(drzewo.korzen).wartosc.ToString());
            Usun(drzewo.korzen.praweDziecko.leweDziecko.leweDziecko);
            MessageBox.Show("Usun(5): " + ZnajdzMin(drzewo.korzen.praweDziecko.leweDziecko).wartosc.ToString());
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

            private Wezel3 ZnajdzRodzica(int liczba)
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
        }
        // --- BST - Binarne drzewo przeszukan ---


        //2. Wezel3 ZnajdzMin(Wezel3 w) - np. podaje 5, najmniejszosc wartosc w tym poddrzewie, tu zwroci 1 - na max w lewo idziemy
        /*public Wezel3 ZnajdzMin(Wezel3 w)
        {
            if (w.leweDziecko != null)
            {
                Wezel3 w1 = w.leweDziecko;
                return ZnajdzMin(w1);
            }
            return new Wezel3(w.wartosc);
        }*/
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
            if (w.praweDziecko != null)
            {
                Wezel3 w1 = w.praweDziecko;
                return ZnajdzMax(w1);
            }
            return new Wezel3(w.wartosc);
        }

        //bedzie na kolosie
        //4. Wezel3 Nastepnik(Wezel3 w) - nastepny po, np po 1 2
        public Wezel3 Nastepnik(Wezel3 w)
        {
            //1) gdy jest prawe dziecko, to uzyj funkcji znajdzMin(w.praweDziecko)
            var dziecko = w;
            if (w.praweDziecko != null)
            {
                return ZnajdzMin(w.praweDziecko);
            }

            //2) gdy nie ma prawego dziecka idz do gory az wyjdziesz jako lewe dziecko w rodzinie, nastepnik to ten rodzic
            //3) gdy nie ma prawego dziecka, ide do gory, gdy nie zachodzi(2) i nie moge isc do gory => nie ma nastepnika
            while (dziecko.rodzic != null && dziecko == dziecko.rodzic.praweDziecko)
            {
                dziecko = dziecko.rodzic;
            }
            if (dziecko.rodzic == null) return new Wezel3(-999);
            return dziecko.rodzic;

            // [kod z cw] - nastepnik
            /*if(w.leweDziecko != null) {
                return this.ZnajdzMin(w.praweDziecko);
             }
            while (w.rodzic != null)
            {
                if(w.rodzic.leweDziecko == w)
                {
                    return w.rodzic;
                }
                w = w.rodzic;
            }
            return null;*/
            // [kod z cw] - nastepnik

            // --- [moj kod] ---
            //var x = WyjdzDoGory(w.rodzic, w.wartosc);
            //return x != null ? x : new Wezel3(-999);
            // --- [moj kod] ---
        }

        //4. Wezel3 Poprzednik(Wezel3 w)
        public Wezel3 Poprzednik(Wezel3 w)
        {
            //1) gdy jest prawe dziecko, to uzyj funkcji znajdzMax(w.leweDziecko)
            var dziecko = w;
            if (w.leweDziecko != null)
            {
                return ZnajdzMax(w.leweDziecko);
            }

            //2) gdy nie ma lewego dziecka idz do gory az wyjdziesz jako prawe dziecko w rodzinie, poprzednik to ten rodzic
            //3) gdy nie ma lewego dziecka, ide do gory, gdy nie zachodzi(2) i nie moge isc do gory => nie ma poprzednika
            while (dziecko.rodzic != null && dziecko == dziecko.rodzic.leweDziecko)
            {
                dziecko = dziecko.rodzic;
            }
            if (dziecko.rodzic == null) return new Wezel3(-999);
            return dziecko.rodzic;

            // --- [moj kod] ---
            //var x = WyjdzDoGory(w.rodzic, w.wartosc);
            //return x != null ? x : new Wezel3(-999);
            // --- [moj kod] ---
        }

        // --- [moj kod] ---
        /*public Wezel3 WyjdzDoGory(Wezel3 rodzic, int wartoscDziecka)
        {
            if(rodzic.leweDziecko != null)
            {
                if(rodzic.leweDziecko.wartosc == wartoscDziecka)
                {
                    return rodzic;
                }
            }
            if (rodzic.rodzic != null) return WyjdzDoGory(rodzic.rodzic, rodzic.wartosc);

            return null;
        }*/
        // --- [moj kod] ---

        public Wezel3 Usun(Wezel3 w)
        {
            //1) gdy nie ma dzieci, to odwiaz
            if(w.leweDziecko == null && w.praweDziecko == null)
            {
                if(w == w.rodzic.leweDziecko)
                {
                    w.rodzic.leweDziecko = null;
                    w.rodzic = null;
                }

                else if (w == w.rodzic.praweDziecko)
                {
                    w.rodzic.praweDziecko = null;
                    w.rodzic = null;
                }
            }

            return null;

            
            //2) gdy 1 dziecko, to dziecko wchodzi na miejsce rodzica
            //3) gdy 2 dzieci, to albo nastepnik albo poprzednik i on powiniem byc w 1) lub 2)
        }


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

        //kolokwium - x1 teoria i x1 praktyka, np. przeprowadz algorytm
        //praktyka - zad z nastepnikiem i poprzednikiem raczej

        // [---] W DOMU DOKONCZYC [---]
    }
}