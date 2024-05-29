using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL _nhanVien;

        public NhanVienBLL()
        {
            _nhanVien = new NhanVienDAL();
        }

        public List<NhanVienDTO> GetListDTOs() => _nhanVien.GetEmployeesWithDetails();

        public NhanVienDTO GetItemDTO(int id) => _nhanVien.GetItem(id);

        public NhanVienDTO AddItemDTO(NhanVienDTO nhanVien)
        {
            _nhanVien.AddItem(nhanVien);
            return nhanVien;
        }

        public void DeleteItem(int _id) => _nhanVien.DeleteItem(_id);

        public void UpdateItem(NhanVienDTO nhanVien) => _nhanVien.UpdateItem(nhanVien);
    }
}
