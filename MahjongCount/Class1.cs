using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongCount
{
    public class MahjongCount
    {
        public int Total;              //多少輸贏
        public int WinningTime;        //胡牌次數
        public int ChuckTime;          //放槍次數
        public int SelfDrawnLossTime;  //被自摸次數
        public int SelfDrawnWinTime;   //自摸次數
        public int Banker=0;             //莊家

        public string SelfDrawmCount(int di, int setpoints, int points,int mybanker,int otherbanker)
        {
            if (mybanker!=0)
            {
                Total += (di + (points + (2 * mybanker -1)) * setpoints) * 3;
                return Total.ToString();
            }
            else
            {
                Total += (di + points * setpoints) * 3 + (2 * otherbanker - 1) * setpoints ;
                return Total.ToString();
            }
            
        }
        public string SelfDrawmLossCount(int di, int setpoints, int points,int mybanker)
        {
            if (mybanker == 0)
            {
                Total -= (di + points * setpoints);
                return Total.ToString();
            }
            else
            {
                mybanker -= 1;
                Total -= (di + (points + 2 * mybanker + 1) * setpoints);
                return Total.ToString();
            }
            
        }
        public string WinCount(int di,int setpoints,int points)
        {
            Total += di + points * setpoints;
            return Total.ToString();            
        }
        public string ChuckCount(int di, int setpoints, int points)
        {
            Total -= di + points * setpoints;
            return Total.ToString();
        }
        public string Winning()
        {
            WinningTime++;
            return("胡牌次數:" + WinningTime.ToString());
        }
        public string Chuck()
        {
            ChuckTime++;
            return("放槍次數:" + ChuckTime.ToString());
        }

        public string SelfDrawnWin()
        {
            SelfDrawnWinTime++;
            return ("自摸次數:" + SelfDrawnWinTime.ToString());
        }
        public string SelfDrawnLoss()
        {
            SelfDrawnLossTime++;
            return ("被自摸次數:" + SelfDrawnLossTime.ToString());
        }        
    }
}
