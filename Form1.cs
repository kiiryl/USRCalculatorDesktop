using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsrCalculatorImba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Вспомогательные методы
        private string TryCalculate(string expression)
        {
            var dt = new DataTable();
            try
            {
                return dt.Compute(expression, "").ToString();
            }
            catch (Exception)
            {
                return "Ошибка!";
            }
        }
        // Основные кнопки
        private void InputButtonsClick(object sender, EventArgs e)
        {
            var currentButton = sender as Button;
            textBox1.Text += currentButton.Text;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            textBox2.Text = TryCalculate(textBox1.Text);
        }

        private void DeleteButton(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (string.IsNullOrEmpty(str)) textBox1.Text = "";
            else textBox1.Text = str.Substring(0, str.Length - 1);
        }

        private void DeleteAllButton(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void SwapResultToInput(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text;
            textBox2.Text = "";
        }
        // Инженерные функции
        private void SinButton(object sender, EventArgs e)
        {
            string result = TryCalculate(textBox1.Text);
            textBox2.Text = Math.Sin(Convert.ToDouble(result)).ToString();
        }

        private void CosButton(object sender, EventArgs e)
        {
            string result = TryCalculate(textBox1.Text);
            textBox2.Text = Math.Cos(Convert.ToDouble(result)).ToString();
        }

        private void SqrtButton(object sender, EventArgs e)
        {
            string result = TryCalculate(textBox1.Text);
            textBox2.Text = Math.Sqrt(Convert.ToDouble(result)).ToString();
        }

        private void SquaredButton(object sender, EventArgs e)
        {
            string result = TryCalculate(textBox1.Text);
            textBox2.Text = Math.Exp(Convert.ToDouble(result)).ToString();
        }


    }
}
