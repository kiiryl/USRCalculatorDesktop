using System;
using System.Data;
using System.Windows.Forms;

namespace UsrCalculatorImba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Методы обработки
        private string TryCalculate(string expression)
        {
            var dt = new DataTable();
            try
            {
                return dt.Compute(expression, "").ToString();
            }
            catch (FormatException)
            {
                return "Неверный формат ввода!";
            }
            catch (OverflowException)
            {
                return "Слишком большое число.";
            }
            catch (Exception)
            {
                return "Ошибка!";
            }
        }
        private double TryConvertStringDouble(string str)
        {
            try
            {
                return Convert.ToDouble(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private void EngineeringFunc(int funcCode)
        {
            string result = TryCalculate(textBox1.Text);
            if (string.IsNullOrEmpty(result) == false)
            {
                double resConv = TryConvertStringDouble(result);

                switch (funcCode)
                {
                    case 1: // Синус
                        textBox2.Text = Math.Sin(resConv).ToString();
                        break;
                    case 2: // Косинус
                        textBox2.Text = Math.Cos(resConv).ToString();
                        break;
                    case 3: // Корень
                        textBox2.Text = Math.Sqrt(resConv).ToString();
                        break;
                    case 4: // Квадрат
                        textBox2.Text = Math.Pow(resConv, 2).ToString();
                        break;
                    case 5: // Факториал
                        if (resConv > 0)
                        {
                            long factRes = 1;
                            int resConvRound = (int)Math.Round(resConv);
                            textBox1.Text = resConvRound.ToString();
                            for (int i = resConvRound; i > 0; i--)
                            {
                                factRes *= i;
                            }
                            textBox2.Text = factRes.ToString();
                        }
                        else if (resConv == 0)
                        {
                            textBox2.Text = 1.ToString();
                        }
                        else if (resConv <= 0)
                        {
                            textBox2.Text = "факториал отрицательного числа";
                        }
                        break;
                    default:
                        textBox2.Text = "Ошибка!";
                        break;
                }
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
            if (textBox2.Text == "∞")
            {
                textBox1.Text = "Нельзя переместить ∞";
            }
            else
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
        }
        // Инженерные функции
        private void SinButton(object sender, EventArgs e)
        {
            EngineeringFunc(1);
        }

        private void CosButton(object sender, EventArgs e)
        {
            EngineeringFunc(2);
        }

        private void SqrtButton(object sender, EventArgs e)
        {
            EngineeringFunc(3);
        }

        private void SquaredButton(object sender, EventArgs e)
        {
            EngineeringFunc(4);
        }

        private void FactorialButton(object sender, EventArgs e)
        {
            EngineeringFunc(5);
        }
    }
}
