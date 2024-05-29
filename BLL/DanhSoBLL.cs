using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhSoBLL
    {
        private readonly DanhSoDAL _danhSo;

        public DanhSoBLL()
        {
            _danhSo = new DanhSoDAL();
        }

        public List<DanhSoDTO> GetListDTOs() => _danhSo.GetlistDetails();

        public DanhSoDTO GetItemDTO(string id) => _danhSo.GetItem(id);

        public DanhSoDTO AddItemDTO(DanhSoDTO hopDong)
        {
            _danhSo.AddItem(hopDong);
            return hopDong;
        }

        public void DeleteItem(string _id) => _danhSo.DeleteItem(_id);

        public void UpdateItem(DanhSoDTO hopDong) => _danhSo.UpdateItem(hopDong);
        public string SoHopDong()
        {
            var maxSoHD = _danhSo.MaxSoHopDong();
            int so = int.Parse(maxSoHD.Substring(0, 5)) + 1;
            string shd = so.ToString("00000") + $@"/{DateTime.Now.Year}{DateTime.Now.Month.ToString("00")}";
            return shd;
        }

        //public void PhatSinhDanhSo(NhanVienBLL nv)
        //{
        //    var list = nv.GetListDTOs();
        //    foreach (var item in list)
        //    {
        //        DanhSoDTO dt = new DanhSoDTO
        //        {
        //            MANV = item.MANV,
        //            MACN = item.MACN,
        //            KHOA = false,
        //            MADS = this.SoHopDong(),
        //            NAM = DateTime.Now.Year,
        //            THANG = DateTime.Now.Month,
        //        };
        //        _danhSo.AddItem(dt);
        //    }
        //}
        public void PhatSinhDanhSo(NhanVienBLL nv)
        {
            var danhSoList = _danhSo.GetlistDetails();
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;

            foreach (var item in nv.GetListDTOs())
            {
                bool danhSoExists = danhSoList.Any(ds => ds.MANV == item.MANV && ds.NAM == year && ds.THANG == month);

                if (!danhSoExists)
                {
                    DanhSoDTO dt = new DanhSoDTO
                    {
                        MANV = item.MANV,
                        MACN = item.MACN,
                        KHOA = false,
                        MADS = this.SoHopDong(),
                        NAM = year,
                        THANG = month,
                    };
                    _danhSo.AddItem(dt);
                }
            }
        }

    }
}
