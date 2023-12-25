namespace MainProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            labelAfter.Text = "WYNIK: ";
            int[] arr = { 5, 7, 2, 4, 1 };
            arr = arrayInput.Text.Split(',').Select(s => int.Parse(s)).ToArray();
            sortowanieBombelkowe(arr);
            labelAfter.Text += string.Join(", ", arr);
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}