using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.WinPM.FModels
{
    public class FInfoModel
    {
        //主键值
        public int FId { get; set; }
        //刷新列表页数据的委托
        public Action ReLoadList { get; set; }
    }
}
