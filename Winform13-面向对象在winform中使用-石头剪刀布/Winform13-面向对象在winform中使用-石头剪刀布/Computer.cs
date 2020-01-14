#region
// ===============================================================================
// Project Name        :    Winform13_面向对象在winform中使用_石头剪刀布
// Project Description :   
// ===============================================================================
// Class Name          :    Computer
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-5-18 18:33:06
// Update Time         :    2018-5-18 18:33:06
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
    class Computer
    {
        public string Fist
        {
            set;
            get;
        }

        public int ShowFist()
        {
            Random r = new Random();
            int num = r.Next(1, 4);

            switch (num)
            {
                case 1: this.Fist = "石头";
                    break;
                case 2: this.Fist = "剪刀";
                    break;
                case 3:this.Fist ="布";
                    break;
            }
            return num;
        }
    }
}
