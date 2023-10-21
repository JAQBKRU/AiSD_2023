namespace Project_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //int wynik = Fib(16);
            int liczbaN = (int)ndNumFib.Value;
            long wynik = Fib2(liczbaN);

            MessageBox.Show(wynik.ToString());
        }

        int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }

        long Fib2(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            long[] arr = new long[n];
            arr[0] = 0;
            arr[1] = 1;

            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[n - 1] + arr[n - 2];
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}