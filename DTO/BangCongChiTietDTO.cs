using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangCongChiTietDTO
    {
        public int MABCCT { get; set; }
        public Nullable<int> MANCNV { get; set; }
        public Nullable<int> MABC { get; set; }
        public Nullable<double> SONGAYCONG { get; set; }
        public Nullable<double> TONGNGAYCONG { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { get; set; }
    }
}
