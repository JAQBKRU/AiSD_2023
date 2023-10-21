using System;

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
            int[] arr = { 4, 2, 0, 7, 9, 1 };
            if(arrayInput.Text != "") arr = arrayInput.Text.Split(',').Select(s => int.Parse(s)).ToArray();//userInput
            selectionSort(arr);
            labelAfter.Text += string.Join(", ", arr);
        }

        private int[] minValue(int[] arr, int index)
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}