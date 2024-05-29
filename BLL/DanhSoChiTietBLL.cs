using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhSoChiTietBLL
    {
        private readonly DanhSoChiTietDAL _danhSoChiTiet;

        public DanhSoChiTietBLL()
        {
            _danhSoChiTiet = new DanhSoChiTietDAL();
        }

        public List<DanhSoChiTietDTO> GetListDTOs() => _danhSoChiTiet.GetListDetails();

        public DanhSoChiTietDTO GetItemDTO(int id) => _danhSoChiTiet.GetItem(id);

        public DanhSoChiTietDTO AddItemDTO(DanhSoChiTietDTO phuCapNhanVien)
        {
            _danhSoChiTiet.AddItem(phuCapNhanVien);
            return phuCapNhanVien;
        }

        public void DeleteItem(int _id) => _danhSoChiTiet.DeleteItem(_id);

        public void UpdateItem(DanhSoChiTietDTO phuCapNhanVien) => _danhSoChiTiet.UpdateItem(phuCapNhanVien);
    }
}
