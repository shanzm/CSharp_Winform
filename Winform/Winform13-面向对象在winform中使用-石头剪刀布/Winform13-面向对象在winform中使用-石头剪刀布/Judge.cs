#region
// ===============================================================================
// Project Name        :    Winform13_面向对象在winform中使用_石头剪刀布
// Project Description :   
// ===============================================================================
// Class Name          :    Judge
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-5-18 19:36:36
// Update Time         :    2018-5-18 19:36:36
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winform13_面向对象在winform中使用_石头剪刀布
{
    //使用一个结构体存储，结果
    public enum Result {玩家赢,电脑赢,平手}

    class Judge
    {
        public  Result judge(int PlayNum, int ComputerNum)
        {
            if (PlayNum-ComputerNum==-1||PlayNum -ComputerNum ==1)
            {
                return Result.玩家赢;
            }
            else if (PlayNum -ComputerNum ==0)
            {
                return Result.平手;
            }
            else
            {
                return Result.电脑赢;
            }
        }
    }
}
