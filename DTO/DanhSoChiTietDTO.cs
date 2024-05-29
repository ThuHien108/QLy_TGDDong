using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhSoChiTietDTO
    {
        public int MADSCT { get; set; }
        public int MASP { get; set; }
        public string MADS { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public string GHICHU { get; set; }
        public string TENSP { get; set; }
        public Double GIA { get; set; }
    }
}
