using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Models
{
    public class MenuInfoModel
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public string FrmName { get; set; }
        public string MKey { get; set; }
    }
}
