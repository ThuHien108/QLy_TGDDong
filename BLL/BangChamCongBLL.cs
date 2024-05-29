using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BangChamCongBLL
    {
        private BangChamCongDAL _BangChamCongDAL;
        public BangChamCongBLL()
        {
            _BangChamCongDAL = new BangChamCongDAL();
        }
        public void PhatSinhBangCong(int mabc, int thang, int nam)
        {
            _BangChamCongDAL.phatSinhKyCongChiTiet(mabc, thang, nam);
        }
        public List<BangChamCongDTO> GetLists(int mabc) => _BangChamCongDAL.getList(mabc);
    }
}
