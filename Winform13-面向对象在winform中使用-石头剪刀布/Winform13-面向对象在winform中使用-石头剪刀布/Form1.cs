using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform13_面向对象在winform中使用_石头剪刀布
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStone_Click(object sender, EventArgs e)
        {
            string str = "石头";
            /* ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
             * 注意我们要把这些代码同样写在btnCloth_Click中，
             * 所以我们把它封装成函数了
             * 封装的方法就是选中-右键-重构-提取方法
             * ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            lblPlayer.Text = str;

            Player player = new Player();
            int playerNum = player.ShowFist(str);

            Computer computer = new Computer();
            int computerNum = computer.ShowFist();
            lblComputer.Text = computer.Fist;

            Judge judger = new Judge();
            Result result = judger.judge(playerNum, computerNum);
            lblJudge.Text = result.ToString(); */

            PlayGame(str);
        }

        /// <summary>
        /// z注意这不是我们一开始就这么构思成一个函数的，我们是重构，提取的方法
        /// </summary>
        /// <param name="str"></param>
        private void PlayGame(string str)
        {
            lblPlayer.Text = str;

            Player player = new Player();
            int playerNum = player.ShowFist(str);

            Computer computer = new Computer();
            int computerNum = computer.ShowFist();
            lblComputer.Text = computer.Fist;

            Judge judger = new Judge();
            Result result = judger.judge(playerNum, computerNum);
            lblJudge.Text = result.ToString();
            // MessageBox .Show (((int)result).ToString ());//注意理解枚举转int的方式 
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            string str = "剪刀";
                PlayGame (str);
        }

        private void btnCloth_Click(object sender, EventArgs e)
        {
            string str = "布";
            PlayGame(str);
        }
    }
}
