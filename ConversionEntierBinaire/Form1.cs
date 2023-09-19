using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversionEntierBinaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool isBinaire(string text)
        {
            bool bin = true;
            for (int i=0; i<text.Length; i++)
            {
                if (text[i]!='0' && text[i]!='1')
                {
                    bin = false;
                    break;
                }
            }
            return bin;
        }
        private string conversionBase10ToBase2(int base10)
        {
            string base2 = "";
            while (base10!=0)
            {
                base2 = (base10 % 2) + base2;
                base10 /= 2;
            }
            if (base2=="")
            {
                base2 = "0";
            }
            return base2;
        }
        private int conversionBase2ToBase10(string base2)
        {
            int base10 = 0;
            if (isBinaire(base2))
            {
                for (int i=0; i<base2.Length; i++)
                {
                    base10 += int.Parse(base2.Substring(base2.Length - 1 - i, 1)) * (int)Math.Pow(2, i);
                }
            }
            else
            {
                base10= -1;
            }
            return base10;
        }

        private void txtBase10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int base10 = int.Parse(txtBase10.Text);
                txtBase2.Text = conversionBase10ToBase2(base10);
            }
            catch(Exception ex)
            {
                txtBase2.Text = "";
                txtBase10.Text = "";
            }
        }
        private void txtBase2_TextChanged(object sender, EventArgs e)
        {
            int b10 = conversionBase2ToBase10(txtBase2.Text);
            if (b10== -1)
            {
                txtBase10.Text = "";
                txtBase2.Text = "";
            }
            else
            {
                txtBase10.Text = b10.ToString();
            }
        }
    }
}
