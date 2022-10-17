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
        int Banker = 0;
        Form2 f2;
        Form3 f3;
        Form4 f4;
        public static string WinnerName, ChuckName, SelfDrawmName;
        public static string btnWinName, btnChuckName;
        public static int setdi, setpoints;
        string[] words = { "東", "南", "西", "北" };
        int word1, word2;

        private string round()
        {
            if (word2 != 3)
                word2++;
            else
            {
                word1++;
                word2 = 0;
                if (word1 > 3)
                    word1 = 0;
            }
            return words[word1] + "風" + words[word2];
        }

        private int otherbanker()
        {
            switch (Banker)
            {
                case 1:
                    return User1.Banker;
                case 2:
                    return User2.Banker;
                case 3:
                    return User3.Banker;
                case 4:
                    return User4.Banker;

            }
            return 0;
        }
        private int CB(int b)
        {
            if (b != 4)
                return ++b;
            else
                return 1;
        }
        private void continuebanker()
        {
            switch (Banker)
            {
                case 1:
                    User1.Banker++;
                    lblUser1Banker.Text = "莊連" + (User1.Banker - 1).ToString();
                    break;
                case 2:
                    User2.Banker++;
                    lblUser2Banker.Text = "莊連" + (User2.Banker - 1).ToString();
                    break;
                case 3:
                    User3.Banker++;
                    lblUser3Banker.Text = "莊連" + (User3.Banker - 1).ToString();
                    break;
                case 4:
                    User4.Banker++;
                    lblUser4Banker.Text = "莊連" + (User4.Banker - 1).ToString();
                    break;
            }
        }


        private void changebanker()
        {
            switch (Banker)
            {
                case 1:
                    lblUser1Banker.Visible = false;
                    lblUser1Banker.Text = "莊";
                    User1.Banker = 0;
                    User2.Banker = 1;
                    lblUser2Banker.Visible = true;
                    break;
                case 2:
                    lblUser2Banker.Visible = false;
                    lblUser2Banker.Text = "莊";
                    User2.Banker = 0;
                    User3.Banker = 1;
                    lblUser3Banker.Visible = true;
                    break;
                case 3:
                    lblUser3Banker.Visible = false;
                    lblUser3Banker.Text = "莊";
                    User3.Banker = 0;
                    User4.Banker = 1;
                    lblUser4Banker.Visible = true;
                    break;
                case 4:
                    lblUser4Banker.Visible = false;
                    lblUser4Banker.Text = "莊";
                    User4.Banker = 0;
                    User1.Banker = 1;
                    lblUser1Banker.Visible = true;
                    break;
            }
            Banker = CB(Banker);
            label1.Text = round();
        }

        private void User1Win_Click(object sender, EventArgs e)
        {
            User1Win.Enabled = false;
            User2Win.Enabled = false;
            User3Win.Enabled = false;
            User4Win.Enabled = false;
            User1SelfDrawn.Enabled = false;
            User2SelfDrawn.Enabled = false;
            User3SelfDrawn.Enabled = false;
            User4SelfDrawn.Enabled = false;
            User1Chuck.Enabled = true;
            User2Chuck.Enabled = true;
            User3Chuck.Enabled = true;
            User4Chuck.Enabled = true;
            Button BtnWin = (Button)sender;
            switch (BtnWin.Name)
            {
                case "User1Win":
                    User1Chuck.Enabled = false;
                    btnWinName = BtnWin.Name;
                    WinnerName = label_User1.Text;
                    break;
                case "User2Win":
                    User2Chuck.Enabled = false;
                    btnWinName = BtnWin.Name;
                    WinnerName = label_User2.Text;
                    break;
                case "User3Win":
                    User3Chuck.Enabled = false;
                    btnWinName = BtnWin.Name;
                    WinnerName = label_User3.Text;
                    break;
                case "User4Win":
                    User4Chuck.Enabled = false;
                    btnWinName = BtnWin.Name;
                    WinnerName = label_User4.Text;
                    break;

            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
            f3 = new Form3();
            f3.ShowDialog();
            f3.Focus();            
            while (Form3.dialogResult == DialogResult.OK)
            {
                Form3.dialogResult = DialogResult.Cancel;
                f3 = new Form3();
                f3.ShowDialog();
            }
            if (f3.DialogResult == DialogResult.OK)
            {
                label_User1.Text = Form3.User1Name;
                label_User2.Text = Form3.User2Name;
                label_User3.Text = Form3.User3Name;
                label_User4.Text = Form3.User4Name;
                lblDi.Text += Form3.SetDi;
                lblPoints.Text += Form3.SetPoints;
                setdi = Convert.ToInt16(Form3.SetDi);
                setpoints = Convert.ToInt16(Form3.SetPoints);
                switch (Form3.StartBanker)
                {
                    case "User1":
                        Banker = 1;
                        User1.Banker = 1;
                        lblUser1Banker.Visible = true;
                        break;
                    case "User2":
                        Banker = 2;
                        User2.Banker = 1;
                        lblUser2Banker.Visible = true;
                        break;
                    case "User3":
                        Banker = 3;
                        User3.Banker = 1;
                        lblUser3Banker.Visible = true;
                        break;
                    case "User4":
                        Banker = 4;
                        User4.Banker = 1;
                        lblUser4Banker.Visible = true;
                        break;
                }
            }
        }


        private void User1Chuck_Click(object sender, EventArgs e)
        {
            User1Win.Enabled = true;
            User2Win.Enabled = true;
            User3Win.Enabled = true;
            User4Win.Enabled = true;
            User1SelfDrawn.Enabled = true;
            User2SelfDrawn.Enabled = true;
            User3SelfDrawn.Enabled = true;
            User4SelfDrawn.Enabled = true;
            User1Chuck.Enabled = false;
            User2Chuck.Enabled = false;
            User3Chuck.Enabled = false;
            User4Chuck.Enabled = false;
            Button BtnChuck = (Button)sender;
            switch (BtnChuck.Name)
            {
                case "User1Chuck":
                    ChuckName = label_User1.Text;
                    break;
                case "User2Chuck":

                    ChuckName = label_User2.Text;
                    break;
                case "User3Chuck":
                    ChuckName = label_User3.Text;
                    break;
                case "User4Chuck":
                    ChuckName = label_User4.Text;
                    break;

            }
            f2 = new Form2(this);
            f2.ShowDialog();
            while (Form2.dialogResult == DialogResult.OK)
            {
                Form2.dialogResult = DialogResult.Cancel;
                f2 = new Form2(this);
                f2.ShowDialog();
            }
            if (f2.DialogResult == DialogResult.OK)
            {
                switch (BtnChuck.Name)
                {
                    case "User1Chuck":
                        lblUser1ChuckTimes.Text = User1.Chuck();
                        lblUser1Score.Text = "合計輸贏 : " + User1.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User2Chuck":
                        lblUser2ChuckTimes.Text = User2.Chuck();
                        lblUser2Score.Text = "合計輸贏 : " + User2.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User3Chuck":
                        lblUser3ChuckTimes.Text = User3.Chuck();
                        lblUser3Score.Text = "合計輸贏 : " + User3.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User4Chuck":
                        lblUser4ChuckTimes.Text = User4.Chuck();
                        lblUser4Score.Text = "合計輸贏 : " + User4.ChuckCount(setdi, setpoints, Form2.Points);
                        break;
                }
                switch (btnWinName)
                {
                    case "User1Win":
                        if (Banker == 1)
                            continuebanker();
                        else
                            changebanker();
                        lblUser1WinTimes.Text = User1.Winning();
                        lblUser1Score.Text = "合計輸贏 : " + User1.WinCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User2Win":
                        if (Banker == 2)
                            continuebanker();
                        else
                            changebanker();
                        lblUser2WinTimes.Text = User2.Winning();
                        lblUser2Score.Text = "合計輸贏 : " + User2.WinCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User3Win":
                        if (Banker == 3)
                            continuebanker();
                        else
                            changebanker();
                        lblUser3WinTimes.Text = User3.Winning();
                        lblUser3Score.Text = "合計輸贏 : " + User3.WinCount(setdi, setpoints, Form2.Points);
                        break;
                    case "User4Win":
                        if (Banker == 4)
                            continuebanker();
                        else
                            changebanker();
                        lblUser4WinTimes.Text = User4.Winning();
                        lblUser4Score.Text = "合計輸贏 : " + User4.WinCount(setdi, setpoints, Form2.Points);
                        break;
                }
            }
        }
       

        private void User1SelfDrawn_Click(object sender, EventArgs e)
        {
            Button BtnSelfDrawn = (Button)sender;
            switch (BtnSelfDrawn.Name)
            {
                case "User1SelfDrawn":
                    SelfDrawmName = label_User1.Text;                    
                    break;
                case "User2SelfDrawn":
                    SelfDrawmName = label_User2.Text;                    
                    break;
                case "User3SelfDrawn":
                    SelfDrawmName = label_User3.Text;                    
                    break;
                case "User4SelfDrawn":
                    SelfDrawmName = label_User4.Text;                    
                    break;
            }
            f4 = new Form4(this);
            f4.ShowDialog();
            while (Form4.dialogResult == DialogResult.OK)
            {
                Form4.dialogResult = DialogResult.Cancel;
                f4 = new Form4(this);
                f4.ShowDialog();
            }
            if (f4.DialogResult == DialogResult.OK)
            {                
                switch (BtnSelfDrawn.Name)
                {
                    case "User1SelfDrawn":                        
                        lblUser2SelfDrawnLossTimes.Text = User2.SelfDrawnLoss();
                        lblUser3SelfDrawnLossTimes.Text = User3.SelfDrawnLoss();
                        lblUser4SelfDrawnLossTimes.Text = User4.SelfDrawnLoss();
                        lblUser1SelfDrawnWinTimes.Text = User1.SelfDrawnWin();
                        lblUser1Score.Text = "合計輸贏 : " + User1.SelfDrawmCount(setdi, setpoints, Form4.Points, User1.Banker, otherbanker());
                        lblUser2Score.Text = "合計輸贏 : " + User2.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User2.Banker);
                        lblUser3Score.Text = "合計輸贏 : " + User3.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User3.Banker);
                        lblUser4Score.Text = "合計輸贏 : " + User4.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User4.Banker);
                        if (Banker == 1)
                            continuebanker();
                        else
                            changebanker();
                        break;                        
                    case "User2SelfDrawn":
                        lblUser1SelfDrawnLossTimes.Text = User1.SelfDrawnLoss();
                        lblUser3SelfDrawnLossTimes.Text = User3.SelfDrawnLoss();
                        lblUser4SelfDrawnLossTimes.Text = User4.SelfDrawnLoss();
                        lblUser2SelfDrawnWinTimes.Text = User2.SelfDrawnWin();
                        lblUser2Score.Text = "合計輸贏 : " + User2.SelfDrawmCount(setdi, setpoints,Form4.Points,User2.Banker,otherbanker());
                        lblUser1Score.Text = "合計輸贏 : " + User1.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User1.Banker);
                        lblUser3Score.Text = "合計輸贏 : " + User3.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User3.Banker);
                        lblUser4Score.Text = "合計輸贏 : " + User4.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User4.Banker);
                        if (Banker == 2)
                            continuebanker();
                        else
                            changebanker();
                        break;
                    case "User3SelfDrawn":
                        lblUser2SelfDrawnLossTimes.Text = User2.SelfDrawnLoss();
                        lblUser1SelfDrawnLossTimes.Text = User1.SelfDrawnLoss();
                        lblUser4SelfDrawnLossTimes.Text = User4.SelfDrawnLoss();
                        lblUser3SelfDrawnWinTimes.Text = User3.SelfDrawnWin();
                        lblUser3Score.Text = "合計輸贏 : " + User3.SelfDrawmCount(setdi,setpoints,Form4.Points,User3.Banker,otherbanker());
                        lblUser2Score.Text = "合計輸贏 : " + User2.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User2.Banker);
                        lblUser1Score.Text = "合計輸贏 : " + User1.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User1.Banker);
                        lblUser4Score.Text = "合計輸贏 : " + User4.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User4.Banker);
                        if (Banker == 3)
                            continuebanker();
                        else
                            changebanker();
                        break;
                    case "User4SelfDrawn":
                        lblUser2SelfDrawnLossTimes.Text = User2.SelfDrawnLoss();
                        lblUser3SelfDrawnLossTimes.Text = User3.SelfDrawnLoss();
                        lblUser1SelfDrawnLossTimes.Text = User1.SelfDrawnLoss();
                        lblUser4SelfDrawnWinTimes.Text = User4.SelfDrawnWin();
                        lblUser4Score.Text = "合計輸贏 : " + User4.SelfDrawmCount(setdi, setpoints,Form4.Points,User4.Banker,otherbanker());
                        lblUser2Score.Text = "合計輸贏 : " + User2.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User2.Banker);
                        lblUser3Score.Text = "合計輸贏 : " + User3.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User3.Banker);
                        lblUser1Score.Text = "合計輸贏 : " + User1.SelfDrawmLossCount(setdi, setpoints, Form4.Points, User1.Banker);
                        if (Banker == 4)
                            continuebanker();
                        else
                            changebanker();
                        break;
                }
            }
        }        
    }
}
