using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_GUI
{
    public partial class Calculator : Form
    {
        double value = 0;
        string operation = "";
        bool operation_pressed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((result.Text == "0")||(operation_pressed))
            {
                if (b.Text == ".")
                {
                    result.Text += b.Text;
                }
                else
                {
                    result.Clear();
                }
            }

            operation_pressed = false;

            if (b.Text == ".")
            {
                if (!result.Text.Contains("."))
                {
                    result.Text += b.Text;
                }
            }
            else
            {
                result.Text += b.Text;
            }
        }

        private void Clear_Entry_Click(object sender, EventArgs e)
        {
            if (result.Text != "0")
            {
                int length = result.TextLength - 1;
                string text = result.Text;
                result.Clear();
                for (int i = 0; i < length; i++)
                {
                    result.Text = result.Text + text[i];
                }
                if (result.Text == "")
                {
                    result.Text = "0";
                }
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (value != 0)
            {
                equal_Button.PerformClick();
                operation_pressed = true;
                operation = b.Text;
                equation_display.Text = value + " " + operation;
            }
            else
            {
                operation = b.Text;
                value = double.Parse(result.Text);
                operation_pressed = true;
                equation_display.Text = value + " " + operation;
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {
            equation_display.Text = "";

            switch (operation)
            {
                case "+":
                    result.Text = (value + double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - double.Parse(result.Text)).ToString();
                    break;
                case "×":
                    result.Text = (value * double.Parse(result.Text)).ToString();
                    break;
                case "÷":
                    result.Text = (value / double.Parse(result.Text)).ToString();
                    if ((result.Text == "∞")||((result.Text == "NaN")))
                    {
                        result.Text = "0";
                        value = 0;
                        equation_display.Text = "";
                        MessageBox.Show("Math ERROR");
                    }
                    break;
                default:
                    break;
            }

            value = double.Parse(result.Text);
            operation = "";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            equation_display.Text = "";
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case ".":
                    dec.PerformClick();
                    break;
                case "+":
                    add.PerformClick();
                    break;
                case "-":
                    subtract.PerformClick();
                    break;
                case "*":
                    multiply.PerformClick();
                    break;
                case "/":
                    divide.PerformClick();
                    break;
                case "=":
                    equal_Button.PerformClick();
                    break;
                case "\b":
                    clear_entry.PerformClick();
                    break;
                case "c":
                    clear.PerformClick();
                    break;
                case "e":
                    equal_Button.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}
