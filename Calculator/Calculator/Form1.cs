using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string input = ""; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "1";
                input = "1";
            }
            else
            {
                textBox_Result.Text += "1";
                input += "1";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "4";
                input = "4";
            }
            else
            {
                textBox_Result.Text += "4";
                input += "4";
            }
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "7";
                input = "7";
            }
            else
            {
                textBox_Result.Text += "7";
                input += "7";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "8";
                input = "8";
            }
            else
            {
                textBox_Result.Text += "8";
                input += "8";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "5";
                input = "5";
            }
            else
            {
                textBox_Result.Text += "5";
                input += "5";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "2";
                input = "2";
            }
            else
            {
                textBox_Result.Text += "2";
                input += "2";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "9";
                input = "9";
            }
            else
            {
                textBox_Result.Text += "9";
                input += "9";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "6";
                input = "6";
            }
            else
            {
                textBox_Result.Text += "6";
                input += "6";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "3";
                input = "3";
            }
            else
            {
                textBox_Result.Text += "3";
                input += "3";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != "0" && textBox_Result.Text != null)
            {
                textBox_Result.Text += "/";
                input += "/";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != "0" && textBox_Result.Text != null)
            {
                textBox_Result.Text += "*";
                input += "*";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "-";
                input = "-";
            }
            else
            {
                textBox_Result.Text += "-";
                input += "-";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != "0" && textBox_Result.Text != null)
            {
                textBox_Result.Text += "+";
                input += "+";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" && textBox_Result.Text != null || input == "")
            {
                textBox_Result.Text = "(";
                input = "(";
            }
            else
            {
                textBox_Result.Text += "(";
                input += "(";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != "0" && textBox_Result.Text != null)
            {
                textBox_Result.Text += "0";
                input += "0";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != "0" && textBox_Result.Text != null)
            {
                textBox_Result.Text += ")";
                input += ")";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            CalculatorManager parser = new CalculatorManager();
            string[] notation = parser.ConvertToPostfixNotation(input);
            string result = CalculatorManager.Calculate(notation);
            label1.Text = input + " = " + result;
            textBox_Result.Text = "0";
            input = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            input = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (input.Length == 1 || input.Length == 0)
            {
                textBox_Result.Text = "0";
                input = "";
            }
            else
            {
                textBox_Result.Text = input.Remove(input.Length - 1);
                input = input.Remove(input.Length - 1);
            }
        }
    }
}

