using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn2D_Click(object sender, EventArgs e)
        {
            int[,] matrix = {
        { 1, 2, 3 },
        { -4, 5, 6 },
        { 7, 8, -9 }
    };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // 🔹 Верхній правий
            int topRight = matrix[0, cols - 1];

            // 🔹 Будь-який інший (наприклад центр)
            int other = matrix[1, 1];

            string result = "";

            if (Math.Abs(topRight) > Math.Abs(other))
                result += "Верхній правий більший по модулю\n";
            else
                result += "Інший більший по модулю\n";

            // 🔹 Порівняння двох будь-яких
            int a = matrix[0, 0];
            int b = matrix[2, 2];

            if (a < b)
                result += $"{a} менше за {b}";
            else
                result += $"{b} менше за {a}";

            textBoxResult.Text = result;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 1. Зчитуємо масив з TextBox
            string[] parts = textBoxArray.Text.Split(' ');
            double[] arr = parts.Select(double.Parse).ToArray();

            // 🔹 а) Сума елементів з непарними індексами
            double sumOddIndex = 0;
            for (int i = 1; i < arr.Length; i += 2)
            {
                sumOddIndex += arr[i];
            }

            // 🔹 б) Сума між першим і останнім від’ємними
            int firstNeg = -1, lastNeg = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    if (firstNeg == -1) firstNeg = i;
                    lastNeg = i;
                }
            }

            double sumBetween = 0;
            if (firstNeg != -1 && lastNeg != -1 && firstNeg < lastNeg)
            {
                for (int i = firstNeg + 1; i < lastNeg; i++)
                {
                    sumBetween += arr[i];
                }
            }

            // 🔹 Стиснення масиву
            List<double> newArr = new List<double>();

            foreach (double x in arr)
            {
                if (Math.Abs(x) > 1)
                    newArr.Add(x);
            }

            // Заповнення нулями
            while (newArr.Count < arr.Length)
            {
                newArr.Add(0);
            }

            // Вивід
            textBoxResult.Text =
                $"Сума непарних індексів: {sumOddIndex}\r\n" +
                $"Сума між від’ємними: {sumBetween}\r\n" +
                $"Новий масив: {string.Join(" ", newArr)}";
        }
    }
}