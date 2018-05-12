using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator1
{
    public partial class Form1 : Form
    {
        Double resultval = 0;
        String operationperformed = null;
        bool isoperationperformed = false;//this is for operator status
        Double memory;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isoperationperformed))
                textBox_Result.Clear();
            isoperationperformed = false;//after numberclick event it must be false
            Button b = (Button)sender;
            if (b.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result + b.Text;
            }
            else if (textBox_Result.Text == "0")
            {
                textBox_Result.Text = textBox_Result + b.Text;
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + b.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (resultval != 0)
            {
                button21.PerformClick();
                operationperformed = b.Text;
                label1.Text = resultval + " " + operationperformed;
                isoperationperformed = true;
            }
            else
            {
                operationperformed = b.Text;
                resultval = Convert.ToDouble(textBox_Result.Text);//this is for convert text to double
                label1.Text = resultval + " " + operationperformed;
                isoperationperformed = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)//for clearend
        {
            textBox_Result.Text = "0";
        }

        private void button21_Click(object sender, EventArgs e)
        {
             switch (operationperformed)
            {
                case "+": textBox_Result.Text = (resultval + Convert.ToDouble(textBox_Result.Text)).ToString();//this is for convert in to text
                    break;
                case "-": textBox_Result.Text = (resultval - Convert.ToDouble(textBox_Result.Text)).ToString();
                    break;
                case "*": textBox_Result.Text = (resultval * Convert.ToDouble(textBox_Result.Text)).ToString();
                    break;
                case "/": textBox_Result.Text = (resultval / Convert.ToDouble(textBox_Result.Text)).ToString();
                    break;
                case "%":textBox_Result.Text = (resultval % Convert.ToDouble(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultval = Convert.ToDouble(textBox_Result.Text);//textboxresult to value
            label1.Text = "";
        }

        private void button_mcclick(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void buttonm_click(object sender, EventArgs e)//for m+
        {
            memory = memory + (Convert.ToDouble(textBox_Result.Text));
        }

        private void buttonmm_Click(object sender, EventArgs e)// for m-
        {
            memory = memory - (Convert.ToDouble(textBox_Result.Text));
        }

        private void buttonsqrt_click(object sender, EventArgs e)
        {
            Double ans = System.Math.Sqrt(Convert.ToDouble(textBox_Result.Text));
            textBox_Result.Text = ans.ToString();
        }

        private void button_mrClick(object sender, EventArgs e)
        {
            textBox_Result.Text = memory.ToString();
        }

        private void button24_Click(object sender, EventArgs e)//this is for memory storage
        {
            memory = Convert.ToDouble(textBox_Result.Text);
        }

        private void button7_Click(object sender, EventArgs e)//this is for backspace
        {
            if (textBox_Result.Text.Length > 0)
            {
                textBox_Result.Text = textBox_Result.Text.Remove(textBox_Result.Text.Length - 1, 1);
            }
        }

        private void button25_Click(object sender, EventArgs e)//this is for clear
        {
            textBox_Result.Text = "0";
            resultval = 0;
        }

     }

  }

