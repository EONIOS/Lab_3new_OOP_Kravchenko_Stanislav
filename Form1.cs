using System;
using System.Windows.Forms;

namespace Lab3new_OOP_Kravchenko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int f1 = int.Parse(txtFirst1.Text);
                int s1 = int.Parse(txtSecond1.Text);
                int f2 = int.Parse(txtFirst2.Text);
                int s2 = int.Parse(txtSecond2.Text);

                Pair p1 = rbMoney.Checked ? (Pair)new Money(f1, s1) : new Fraction(f1, s1);
                Pair p2 = rbMoney.Checked ? (Pair)new Money(f2, s2) : new Fraction(f2, s2);
                Pair result = null;

                if (rbAdd.Checked) result = p1.Add(p2);
                else if (rbSub.Checked) result = p1.Subtract(p2);
                else if (rbMul.Checked) result = p1.Multiply(p2);
                else if (rbDiv.Checked) result = p1.Divide(p2);

                if (result != null) lblResult.Text = "Результат: " + result.ToString();
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }
    }
}
