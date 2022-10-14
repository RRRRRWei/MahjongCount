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
            lblSelfDrawnName.Text = "自摸 : " + Form1.SelfDrawmName;
        }
        public static int Points;
        public static DialogResult dialogResult;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dialogResult = MessageBox.Show("請輸入自摸台數", "提示訊息", MessageBoxButtons.OK);
            }
            else
            {
                Points = Convert.ToInt16(textBox1.Text);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
        }
    }
}
