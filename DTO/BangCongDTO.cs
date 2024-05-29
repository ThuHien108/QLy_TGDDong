using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangCongDTO
    {
        public int MABC { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<bool> KHOA { get; set; }
        public Nullable<double> NGAYCONGTRONGTHANG { get; set; }
        public Nullable<int> MACN { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public string TENCN { get; set; }

    }
}
