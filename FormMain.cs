using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormMain : Form
    {
        bool OperateFirstTime = false;
        string Operate = string.Empty;
        string Result = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Text.Equals("-") || btn.Text.Equals("+"))
            {
                if (!string.IsNullOrEmpty(Result) && !string.IsNullOrEmpty(Operate) && !OperateFirstTime)
                {
                    Compute();
                }

                if (!OperateFirstTime)
                {
                    Result = textBox.Text;
                }

                Operate = btn.Text;
                OperateFirstTime = true;
            }
            else if (btn.Text.Equals("="))
            {
                Compute();
            }
            else if (btn.Text.Equals("C"))
            {
                Operate = string.Empty;
                Result = string.Empty;
                textBox.Clear();
            }
            else
            {
                if(OperateFirstTime)
                {
                    textBox.Clear();
                }

                string oldResult = textBox.Text;
                textBox.Text = oldResult + btn.Text;
                OperateFirstTime = false;
            }
        }

        private void Compute()
        {
            if (!string.IsNullOrEmpty(Result) && !string.IsNullOrEmpty(Operate))
            {
                int result = 0;
                int textInt = int.Parse(textBox.Text);

                switch (Operate)
                {
                    case "-":
                        result = int.Parse(Result) - textInt;
                        break;
                    case "+":
                        result = int.Parse(Result) + textInt;
                        break;
                }

                Result = string.Empty;
                textBox.Text = result.ToString();
            }
        }
    }
}
