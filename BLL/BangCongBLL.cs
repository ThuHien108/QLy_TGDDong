using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BangCongBLL
    {
        private readonly BangCongDAL _bangCong;

        public BangCongBLL()
        {
            _bangCong = new BangCongDAL();
        }

        public List<BangCongDTO> GetListDTOs() => _bangCong.GetLists();

        public BangCongDTO GetItemDTO(int id) => _bangCong.GetItem(id);

        public BangCongDTO AddItemDTO(BangCongDTO nhanVien)
        {
            _bangCong.AddItem(nhanVien);
            return nhanVien;
        }
        public int demSoNgayLamViecTrongThang(int thang, int nam)
        {
            int dem = 0;
            DateTime f = new DateTime(nam, thang, 01);
            int x = f.Month + 1;
            while (f.Month < x)
            {
                dem = dem + 1;
                if (f.DayOfWeek == DayOfWeek.Sunday)
                {
                    dem = dem - 1;
                }
                f = f.AddDays(1);
            }
            return dem;
        }
        public void DeleteItem(int _id) => _bangCong.DeleteItem(_id);

        public void UpdateItem(BangCongDTO nhanVien) => _bangCong.UpdateItem(nhanVien);
    }
}
