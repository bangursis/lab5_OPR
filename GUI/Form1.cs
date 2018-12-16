using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form2();

            form2.min = (int)min.Value;
            form2.max = (int)max.Value;
            form2.years = (int)years.Value;
            form2.currentT = (int)start.Value;
            form2.I.Add((int)I0.Value);
            form2.R.Add((int)R0.Value);
            form2.C.Add((int)C0.Value);
            form2.S.Add((int)I0.Value);

            form2.rateOfC = (int)rateOfC.Value;
            form2.rateOfR = (int)rateOfR.Value;
            form2.rateOfI = (int)rateOfI.Value;
            form2.rateOfS = (int)rateOfS.Value;
            form2.fillLists();
            form2.setSize();

            form2.calculate();

            form2.Show();
        }

        private void I0_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
