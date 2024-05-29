using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int MANV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string DIENTHOAI { get; set; }
        public string EMAIL { get; set; }
        public byte[] HINHANH { get; set; }
        public string CCCD { get; set; }
        public string DIACHI { get; set; }
        public string TENPB { get; set; }
        public string TENCV { get; set; }
        public string TENCN { get; set; }
        public Nullable<int> MAPB { get; set; }
        public Nullable<int> MACV { get; set; }
        public Nullable<int> MACN { get; set; }
    }
}
