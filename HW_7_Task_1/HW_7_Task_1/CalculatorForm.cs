using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_7_Task_1
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            textBox.Text += (sender as Button).Text;
        }

        private void button16Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }
    }
}
