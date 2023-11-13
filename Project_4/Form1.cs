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
    }
}