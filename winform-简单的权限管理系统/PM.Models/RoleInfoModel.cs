using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Models
{
    public class RoleInfoModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Remark { get; set; }
        public int IsAdmin { get; set; }
    }
}
