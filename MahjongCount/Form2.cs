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
    public partial class Form2 : Form
    {
        public Form2(string WinName,string ChuckName)
        {
            InitializeComponent();
            lblWinName.Text = WinName;
            lblChuckName.Text = ChuckName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
                     
        }
    }
}
