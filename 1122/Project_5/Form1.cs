using System;

namespace MainProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] convertData()
        {
            return tb.Text.Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (tb.Text != "")
            {
                lbl.Text = "";
                int[] arr = convertData();
                bubbleSort(arr);
                lbl.Text += string.Join(", ", arr);
            }
        }

        void bubbleSort(int[] arr)
        {
            int cbz = 1;
            while (cbz == 1)
            {
                cbz = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                        cbz = 1;
                    }
                }
                if (cbz == 0)
                {
                    break;
                }
            }
        }

        int[] minValue(int[] arr, int index)
        {
            int[] minElement = { arr[index], index };

            for (int i = index; i < arr.Length; i++)
            {
                if (arr[i] < minElement[0]) (minElement[0], minElement[1]) = (arr[i], i);
            }

            return minElement;
        }

        void selectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int[] minElement = minValue(arr, i);
                (arr[i], arr[minElement[1]]) = (minElement[0], arr[i]);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (tb.Text != "")
            {
                lbl.Text = "";
                int[] arr = convertData();
                selectionSort(arr);
                lbl.Text += string.Join(", ", arr);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (tb.Text != "")
            {
                lbl.Text = "";
                int[] arr = convertData();
                insertionSort(arr);
                lbl.Text += string.Join(", ", arr);
            }
        }

        void insertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                /*//moje wersja
                  int aktualny = arr[i + 1];
                    bool aktualnyMIN = true;
                    for (int j = 0; j <= i; j++)
                    {
                        if (arr[i - j] < aktualny)
                        {
                            arr[i - j + 1] = aktualny;
                            aktualnyMIN = false;
                            break;
                        }
                        arr[i - j + 1] = arr[i - j];
                    }

                    if (aktualnyMIN) arr[0] = aktualny;*/
                int aktualny = arr[i + 1];
                int j = i;
                while (j >= 0 && arr[j] > aktualny)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = aktualny;
            }
        }

        //margeSort
        // Merge two subarrays L and M into arr
        void merge(int[] arr, int p, int q, int r)
        {
            // Create L ← A[p..q] and M ← A[q+1..r]
            int n1 = q - p + 1;
            int n2 = r - q;

            int[] L = new int[n1];
            int[] M = new int[n2];

            for (int ii = 0; ii < n1; ii++)
                L[ii] = arr[p + ii];
            for (int jj = 0; jj < n2; jj++)
                M[jj] = arr[q + 1 + jj];

            // Maintain current index of sub-arrays and main array
            int i, j, k;
            i = 0;
            j = 0;
            k = p;

            // Until we reach either end of either L or M, pick larger among
            // elements L and M and place them in the correct position at A[p..r]
            while (i < n1 && j < n2)
            {
                if (L[i] <= M[j]) arr[k++] = L[i++];
                else arr[k++] = M[j++];
            }

            // When we run out of elements in either L or M,
            // pick up the remaining elements and put in A[p..r]
            while (i < n1)
            {
                arr[k++] = L[i++];
            }

            while (j < n2)
            {
                arr[k++] = M[j++];
            }
        }

        void mergeSort(int[] arr, int l, int size)//execute like: mergeSort(arr, 0, arr.Length - 1);
        {
            if (l < size)
            {
                int indexDividingSubarrays = l + (size - l) / 2;
                mergeSort(arr, l, indexDividingSubarrays);
                mergeSort(arr, indexDividingSubarrays + 1, size);

                //merging sorted subarrays
                merge(arr, l, indexDividingSubarrays, size);
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lbl.Text = "";
            if (tb.Text != "")
            {
                lbl.Text = "";
                int[] arr = convertData();
                mergeSort(arr, 0, arr.Length - 1);
                lbl.Text += string.Join(", ", arr);
            }
        }

        private void btn5_Click(object sender, EventArgs e)
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

            MessageBox.Show(string.Join(", ", A(w1).ToString().Select(c => c.ToString())));//MessageBox.Show(string.Join(", ", AA(w1).ToString().ToCharArray()));

        }

        string A(Wezel w)//1,2,4,5,7,3
        {
            string wynik = w.wartosc.ToString();
            foreach(var dziecko in w.dzieci) wynik += A(dziecko);

            return wynik;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel2(5);
            var w2 = new Wezel2(1);
            var w3 = new Wezel2(2);
            var w4 = new Wezel2(3);
            var w5 = new Wezel2(8);
            var w6 = new Wezel2(4);
            /*w1.sasiedzi.Add(w2);
            //w1.sasiedzi.Add(w3);
            w2.sasiedzi.Add(w4);
            w2.sasiedzi.Add(w5);
            w4.sasiedzi.Add(w6);
            w6.sasiedzi.Add(w3);*/

            w1.Add(w2);
            //w1.sasiedzi.Add(w3);
            w2.Add(w4);
            w2.Add(w5);
            w4.Add(w6);
            w6.Add(w3);
            //w2.Add(w4);//hmm

            A2(w1);
            //MessageBox.Show(string.Join(", ", A2(w1).ToString().Select(c => c.ToString())));
        }


        //BFS w domu z gifa po prawej
        //https://en.wikipedia.org/wiki/Breadth-first_search

        //teraz przeszukiwanie binarne

        string A2(Wezel2 w)//5,1,3,4,2,8
        {
            List<Wezel2> odwiedzone = new List<Wezel2>();
            
            odwiedzone.Add(w);

            string wynik = w.wartosc.ToString();
            foreach (var sasiad in w.sasiedzi)
            {
                if (!odwiedzone.Contains(sasiad)) {
                    wynik += A2(sasiad);
                }
            }

            return wynik;
        }

        
    }

    //grafy
    //przeszukiwanie grafow wszerz
    //https://www.algorytm.edu.pl/grafy/bfs.html
    public class Wezel
    {
        public int wartosc;
        public List<Wezel> dzieci = new List<Wezel>();

        public Wezel(int liczba)
        {
            this.wartosc = liczba;
        }

        //var w1 = new Wezel(5);
    }

    //11222023
    public class Wezel2
    {
        public int wartosc;
        public List<Wezel2> sasiedzi = new List<Wezel2>();

        public Wezel2(int liczba)
        {
            this.wartosc = liczba;
        }
        //override ???
        public void Add(Wezel2 w)
        {
            w.sasiedzi.Add(this);
            this.sasiedzi.Add(w);
        }
    }

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
    }

    class DrzewoBinarne
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
}