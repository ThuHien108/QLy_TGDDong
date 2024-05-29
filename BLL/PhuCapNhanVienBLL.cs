using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhuCapNhanVienBLL
    {

        private readonly PhuCapNhanVienDAL _phuCapNhanVien;

        public PhuCapNhanVienBLL()
        {
            _phuCapNhanVien = new PhuCapNhanVienDAL();
        }

        public List<PhuCapNhanVienDTO> GetListDTOs() => _phuCapNhanVien.GetListDetails();

        public PhuCapNhanVienDTO GetItemDTO(int id) => _phuCapNhanVien.GetItem(id);

        public PhuCapNhanVienDTO AddItemDTO(PhuCapNhanVienDTO phuCapNhanVien)
        {
            _phuCapNhanVien.AddItem(phuCapNhanVien);
            return phuCapNhanVien;
        }

        public void DeleteItem(int _id) => _phuCapNhanVien.DeleteItem(_id);

        public void UpdateItem(PhuCapNhanVienDTO phuCapNhanVien) => _phuCapNhanVien.UpdateItem(phuCapNhanVien);
    }
}
