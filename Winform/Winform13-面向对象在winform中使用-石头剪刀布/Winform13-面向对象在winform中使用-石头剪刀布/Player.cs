#region
// ===============================================================================
// Project Name        :    Winform13_面向对象在winform中使用_石头剪刀布
// Project Description :   
// ===============================================================================
// Class Name          :    Player
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-5-18 18:27:26
// Update Time         :    2018-5-18 18:27:26
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
    class Player
    {
        
        public int ShowFist(string fist)
        {
            int num = 0;
            switch (fist)
            {
                case "石头":num=1;
                    break ;
                case "剪刀":num =2;
                    break ;
               case "布":num=3;
                    break;
            }
            return num;
        }

    }
}
