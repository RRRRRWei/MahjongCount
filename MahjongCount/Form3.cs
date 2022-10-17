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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public static string User1Name;
        public static string User2Name;
        public static string User3Name;
        public static string User4Name;
        public static string SetDi;
        public static string SetPoints;
        public static string StartBanker;
        public static DialogResult dialogResult;

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUser1.Text == "" || txtUser2.Text == "" || txtUser3.Text == "" || txtUser4.Text == "")
            {
                dialogResult = MessageBox.Show("請輸入玩家姓名", "提示訊息", MessageBoxButtons.OK);
            }
            else if(checkBox1.Checked==false&& checkBox2.Checked == false&& checkBox3.Checked == false && checkBox4.Checked == false)
            {
                dialogResult = MessageBox.Show("請勾選起始莊家", "提示訊息", MessageBoxButtons.OK);
            }
            else if (txtDi.Text=="")
            {
                dialogResult = MessageBox.Show("請輸入底", "提示訊息", MessageBoxButtons.OK);
            }
            else if (txtPoints.Text == "")
            {
                dialogResult = MessageBox.Show("請輸入台", "提示訊息", MessageBoxButtons.OK);
            }
            else
            {
                User1Name = txtUser1.Text;
                User2Name = txtUser2.Text;
                User3Name = txtUser3.Text;
                User4Name = txtUser4.Text;
                SetDi = txtDi.Text;
                SetPoints = txtPoints.Text;
                this.Close();
            }            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == false)
            {
                switch (checkBox.Name)
                {
                    case "checkBox1":
                        StartBanker = "User1";
                        checkBox.Checked = true;
                        checkBox2.Enabled = false;
                        checkBox3.Enabled = false;
                        checkBox4.Enabled = false;
                        break;
                    case "checkBox2":
                        StartBanker = "User2";
                        checkBox.Checked = true;
                        checkBox1.Enabled = false;
                        checkBox3.Enabled = false;
                        checkBox4.Enabled = false;
                        break;
                    case "checkBox3":
                        StartBanker = "User3";
                        checkBox.Checked = true;
                        checkBox2.Enabled = false;
                        checkBox1.Enabled = false;
                        checkBox4.Enabled = false;
                        break;
                    case "checkBox4":
                        StartBanker = "User4";
                        checkBox.Checked = true;
                        checkBox2.Enabled = false;
                        checkBox3.Enabled = false;
                        checkBox1.Enabled = false;
                        break;
                }
            }
            else
            {
                switch (checkBox.Name)
                {
                    case "checkBox1":
                        checkBox.Checked = false;
                        checkBox2.Enabled = true;
                        checkBox3.Enabled = true;
                        checkBox4.Enabled = true;
                        break;
                    case "checkBox2":
                        checkBox.Checked = false;
                        checkBox1.Enabled = true;
                        checkBox3.Enabled = true;
                        checkBox4.Enabled = true;
                        break;
                    case "checkBox3":
                        checkBox.Checked = false;
                        checkBox2.Enabled = true;
                        checkBox1.Enabled = true;
                        checkBox4.Enabled = true;
                        break;
                    case "checkBox4":
                        checkBox.Checked = false;
                        checkBox2.Enabled = true;
                        checkBox3.Enabled = true;
                        checkBox1.Enabled = true;
                        break;
                }
            }
        }

        private void txtDi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
        }        
    }
}
