using System.Reflection.Metadata.Ecma335;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            lbl.Text = "";
            int[] arr = { 5, 7, 2, 4, 1 };
            if (tb.Text != "") arr = tb.Text.Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
            sortowanieBombelkowe(arr);
            lbl.Text += string.Join(", ", arr);
        }

        void sortowanieBombelkowe(int[] arr)
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
            }
        }

        int[] minValue(int[] arr, int index)
        {
            int[] minElement = { arr[index], index};

            for(int i=index; i< arr.Length; i++)
            {
                if (arr[i] < minElement[0]) (minElement[0], minElement[1]) = (arr[i], i);
            }

            return minElement;
        }

        void selectionSort(int[] arr)
        {
            for(int i = 0; i < arr.Length - 1; i++)
            {
                int[] minElement = minValue(arr, i);
                (arr[i], arr[minElement[1]]) = (minElement[0], arr[i]);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lbl.Text = "";
            int[] arr = { 5, 7, 2, 4, 1 };
            if (tb.Text != "") arr = tb.Text.Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
            selectionSort(arr);
            lbl.Text += string.Join(", ", arr);
        }

        private void button1_Click(object sender, EventArgs e)
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

            AA(w1);
        }

        void A(Wezel w)
        {
            //A(w);
            MessageBox.Show(w.wartosc.ToString());
            foreach(var dziecko in w.dzieci) A(dziecko);//1,2,4,5,7,3
        }

        string AA(Wezel w)
        {
            string wynik = "";
            //A(w);
            //MessageBox.Show(w.wartosc.ToString());
            wynik += w.wartosc.ToString();
            foreach (var dziecko in w.dzieci)
            {
                AA(dziecko);//1,2,4,5,7,3
            }

            return wynik;
        }
    }

    //grafy
    public class Wezel
    {
        public int wartosc;
        public List<Wezel>dzieci = new List<Wezel>();
        
        public Wezel(int liczba)
        {
            this.wartosc = liczba;
        }

        //var w1 = new Wezel(5);
    }
}


//przeszukiwanie grafow wszerz
//https://www.algorytm.edu.pl/grafy/bfs.html
