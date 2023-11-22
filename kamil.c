//2211 KAMILA

namespace graf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        private void btnStart_Click(object sender, EventArgs e)
        {
            var w1 = new Węzeł(5);
            var w2 = new Węzeł(3);
            var w3 = new Węzeł(1);
            var w4 = new Węzeł(2);
            var w5 = new Węzeł(6);
            var w6 = new Węzeł(4);
            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);
            //A(w1);
            var s1 = new Węzeł2(1);
            var s2 = new Węzeł2(2);
            var s3 = new Węzeł2(3);
            var s4 = new Węzeł2(4);
            var s5 = new Węzeł2(5);
            var s6 = new Węzeł2(6);
            var s7 = new Węzeł2(7);
            s1.Add(s2);
            s2.Add(s3);
            s3.Add(s1);
            s3.Add(s4);
            s4.Add(s5);
            s5.Add(s6);
            s5.Add(s7);
            //B(s1);
            var b1 = new Węzeł2(1);
            var b2 = new Węzeł2(2);
            var b3 = new Węzeł2(3);
            var b4 = new Węzeł2(4);
            var b5 = new Węzeł2(5);
            var b6 = new Węzeł2(6);
            b1.Add(b2);
            b1.Add(b3);
            b2.Add(b4);
            b2.Add(b5);
            b3.Add(b6);
            C(b1);
 
        }
        public List<Węzeł2> odwiedzone = new List<Węzeł2>();
        void A(Węzeł w)
        {
            MessageBox.Show(w.wartość.ToString());
            for (int i = 0; i < w.dzieci.Count; i++)
            {
                A(w.dzieci[i]);
            }
        }
 
        void B(Węzeł2 s)
        {
            if (!odwiedzone.Contains(s))
            {
                MessageBox.Show(s.wartość.ToString());
                odwiedzone.Add(s);
 
                foreach (var sąsiad in s.sąsiedzi)
                {
                    B(sąsiad);
                }
            }
        }
        void C(Węzeł2 s)
        {
            if (!odwiedzone.Contains(s))
            {
                MessageBox.Show(s.wartość.ToString());
 
 
                foreach (var sąsiad in s.sąsiedzi)
                {
                    B(sąsiad);
                    odwiedzone.Add(s);
                }
            }
        }
 
 
 
    }
    public class Węzeł
    {
        public int wartość;
        public List<Węzeł> dzieci = new List<Węzeł>();
        public Węzeł(int liczba)
        {
            this.wartość = liczba;
        }
    }
    public class Węzeł2
    {
        public int wartość;
        public List<Węzeł2> sąsiedzi = new List<Węzeł2>();
        public Węzeł2(int liczba)
        {
            this.wartość = liczba;
        }
 
 
        public void Add(Węzeł2 w)
        {
            if (this == w)
            {
                return;
            }
            if (!this.sąsiedzi.Contains(w))
            {
                this.sąsiedzi.Add(w);
            }
            if(!w.sąsiedzi.Contains(this))
            {
                w.sąsiedzi.Add(this);
            }
        }
    }
}
