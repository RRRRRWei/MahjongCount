using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongCount
{
    public class MahjongCount
    {
        public int Dolar;              //多少輸贏
        public int WinningTime;        //胡牌次數
        public int ChuckTime;          //放槍次數
        public int SelfDrawnLossTime;  //被自摸次數
        public int SelfDrawnWinTime;   //自摸次數

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
