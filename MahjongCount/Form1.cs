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
        Form3 f3;
        public static string WinnerName, ChuckName, SelfDrawmName;
        public static string btnWinName, btnChuckName;

        private void User1Win_Click(object sender, EventArgs e)
        {
            Button BtnWin = (Button)sender;
            switch (BtnWin.Name)
            {
                case "User1Win":
                    lblUser1WinTimes.Text = User1.Winning();
                    btnWinName = BtnWin.Name;
                    WinnerName =label_User1.Text;
                    break;
                case "User2Win":
                    lblUser2WinTimes.Text = User2.Winning();
                    btnWinName = BtnWin.Name;
                    WinnerName = label_User2.Text;
                    break;
                case "User3Win":
                    lblUser3WinTimes.Text = User3.Winning();
                    btnWinName = BtnWin.Name;
                    WinnerName = label_User3.Text;
                    break;
                case "User4Win":
                    lblUser4WinTimes.Text = User4.Winning();
                    btnWinName = BtnWin.Name;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            f3=new Form3();
            f3.ShowDialog();
            f3.Focus();
            if(f3.DialogResult == DialogResult.OK)
            {
                label_User1.Text = Form3.User1Name;
                label_User2.Text = Form3.User2Name;
                label_User3.Text = Form3.User3Name;
                label_User4.Text = Form3.User4Name;
                lblDi.Text += Form3.SetDi;
                lblPoints.Text += Form3.SetPoints;
            }
            
        }

        private void User1Chuck_Click(object sender, EventArgs e)
        {
            Button BtnChuck = (Button)sender;
            switch (BtnChuck.Name)
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
            f2 = new Form2(this);
            f2.ShowDialog();
            if (DialogResult != DialogResult.Cancel)
            {
                int setdi =Convert.ToInt16(Form3.SetDi);
                int setpoints = Convert.ToInt16(Form3.SetPoints);
                switch (BtnChuck.Name)
                {
                    case "User1Chuck":
                        lblUser1Score.Text = "合計輸贏 : " + User1.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User2Chuck":
                        lblUser2Score.Text = "合計輸贏 : " + User2.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User3Chuck":
                        lblUser3Score.Text = "合計輸贏 : " + User3.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User4Chuck":
                        lblUser4Score.Text = "合計輸贏 : " + User4.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                }
                switch (btnWinName)
                {
                    case "User1Win":
                            lblUser1Score.Text = "合計輸贏 : " + User1.WinCount(setdi, setpoints, Form2.Points);
                            break;
                    case "User2Win":
                        lblUser2Score.Text = "合計輸贏 : " + User2.WinCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User3Win":
                        lblUser3Score.Text = "合計輸贏 : " + User3.WinCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User4Win":
                        lblUser4Score.Text = "合計輸贏 : " + User4.WinCount(setdi, setpoints, Form2.Points);
                        break;
                }
            }
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
