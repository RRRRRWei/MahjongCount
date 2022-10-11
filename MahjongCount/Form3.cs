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

        private void button1_Click(object sender, EventArgs e)
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
}
