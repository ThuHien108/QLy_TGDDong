using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhuCapNhanVienDTO
    {
        public int MAPCNV { get; set; }
        public int MANV { get; set; }
        public int MAPC { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<double> SOTIEN { get; set; }
        public string HOTEN { get; set; }
        public string TENPC { get; set; }
    }
}
