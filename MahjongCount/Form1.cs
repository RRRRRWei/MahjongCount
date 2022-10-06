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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            User2Win.Click += new System.EventHandler(User1Win_Click);
            User3Win.Click += new System.EventHandler(User1Win_Click);
            User4Win.Click += new System.EventHandler(User1Win_Click);
            User2Chuck.Click += new System.EventHandler(User1Chuck_Click);
            User3Chuck.Click += new System.EventHandler(User1Chuck_Click);
            User4Chuck.Click += new System.EventHandler(User1Chuck_Click);
            User2SelfDrawn.Click += new System.EventHandler(User1SelfDrawn_Click);
            User3SelfDrawn.Click += new System.EventHandler(User1SelfDrawn_Click);
            User4SelfDrawn.Click += new System.EventHandler(User1SelfDrawn_Click);
        }

        MahjongCount User1 = new MahjongCount();
        MahjongCount User2 = new MahjongCount();
        MahjongCount User3 = new MahjongCount();
        MahjongCount User4 = new MahjongCount();
        int clicktimes = 0;
        Form2 f2;
        public string WinnerName, ChuckName, SelfDrawmName;

        private void User1Win_Click(object sender, EventArgs e)
        {
            Button BtnWin = (Button)sender;
            switch (BtnWin.Name)
            {
                case "User1Win":
                    lblUser1WinTimes.Text = User1.Winning();
                    WinnerName=label_User1.Text;
                    break;
                case "User2Win":
                    lblUser2WinTimes.Text = User2.Winning();
                    WinnerName = label_User2.Text;
                    break;
                case "User3Win":
                    lblUser3WinTimes.Text = User3.Winning();
                    WinnerName = label_User3.Text;
                    break;
                case "User4Win":
                    lblUser4WinTimes.Text = User4.Winning();
                    WinnerName = label_User4.Text;
                    break;

            }
            /*
            User2Win.Enabled = false;
            User2SelfDrawn.Enabled = false;
            User3Win.Enabled = false;
            User3SelfDrawn.Enabled = false;
            User4Win.Enabled = false;
            User4SelfDrawn.Enabled = false;
            */
            
        }


        private void User1Chuck_Click(object sender, EventArgs e)
        {
            Button BtnWin = (Button)sender;
            switch (BtnWin.Name)
            {
                case "User1Chuck":
                    lblUser1ChuckTimes.Text = User1.Chuck();
                    ChuckName=label_User1.Text;
                    break;
                case "User2Chuck":
                    lblUser2ChuckTimes.Text = User2.Chuck();
                    ChuckName = label_User2.Text;
                    break;
                case "User3Chuck":
                    lblUser3ChuckTimes.Text = User3.Chuck();
                    ChuckName = label_User3.Text;
                    break;
                case "User4Chuck":
                    lblUser4ChuckTimes.Text = User4.Chuck();
                    ChuckName = label_User4.Text;
                    break;

            }
            f2 = new Form2(WinnerName,ChuckName);
            f2.Show();
            
        }
       

        private void User1SelfDrawn_Click(object sender, EventArgs e)
        {
            Button BtnWin = (Button)sender;
            switch (BtnWin.Name)
            {
                case "User1SelfDrawn":
                    lblUser2SelfDrawnLossTimes.Text = User2.SelfDrawnLoss();
                    lblUser3SelfDrawnLossTimes.Text = User3.SelfDrawnLoss();
                    lblUser4SelfDrawnLossTimes.Text = User4.SelfDrawnLoss();                    
                    lblUser1SelfDrawnWinTimes.Text = User1.SelfDrawnWin();
                    break;
                case "User2SelfDrawn":
                    lblUser1SelfDrawnLossTimes.Text = User1.SelfDrawnLoss();
                    lblUser3SelfDrawnLossTimes.Text = User3.SelfDrawnLoss();
                    lblUser4SelfDrawnLossTimes.Text = User4.SelfDrawnLoss();
                    lblUser2SelfDrawnWinTimes.Text = User2.SelfDrawnWin();
                    break;
                case "User3SelfDrawn":
                    lblUser2SelfDrawnLossTimes.Text = User2.SelfDrawnLoss();
                    lblUser1SelfDrawnLossTimes.Text = User1.SelfDrawnLoss();
                    lblUser4SelfDrawnLossTimes.Text = User4.SelfDrawnLoss();
                    lblUser3SelfDrawnWinTimes.Text = User3.SelfDrawnWin();
                    break;
                case "User4SelfDrawn":
                    lblUser2SelfDrawnLossTimes.Text = User2.SelfDrawnLoss();
                    lblUser3SelfDrawnLossTimes.Text = User3.SelfDrawnLoss();
                    lblUser1SelfDrawnLossTimes.Text = User1.SelfDrawnLoss();
                    lblUser4SelfDrawnWinTimes.Text = User4.SelfDrawnWin();
                    break;
            }          
        }        
    }
}
