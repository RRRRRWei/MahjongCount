using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MahjongCount
{
    public partial class Form4 : Form
    {
        private Form1 f1;
        public Form4(Form1 form1)
        {
            f1 = form1;
            InitializeComponent();
            lblSelfDrawnName.Text = Form1.SelfDrawmName;
        }
        public static int Points;
        private void button1_Click(object sender, EventArgs e)
        {
            Points = Convert.ToInt16(textBox1.Text);
        }
    }
}
