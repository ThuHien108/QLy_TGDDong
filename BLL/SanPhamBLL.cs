using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBLL
    {
        private SanPhamDAL _sanPham;
        public SanPhamBLL()
        {
            _sanPham = new SanPhamDAL();
        }
        public SanPhamDTO GetItemDTO(int id) => _sanPham.GetItem(id);

        public List<SanPhamDTO> GetListDTOs()
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            List<tb_SANPHAM> lstDAL = _sanPham.GetList();
            foreach (var item in lstDAL)
            {
                SanPhamDTO tp = new SanPhamDTO();
                tp.MASP = item.MASP;
                tp.TENSP = item.TENSP;
                tp.GIA = item.GIA;
                lst.Add(tp);
            }
            return lst;
        }
        public SanPhamDTO AddItem(SanPhamDTO newItem)
        {
            try
            {
                tb_SANPHAM newChiNhanh = new tb_SANPHAM
                {
                    TENSP = newItem.TENSP,
                    GIA = newItem.GIA,
                };
                _sanPham.AddItem(newChiNhanh);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Error add: " + ex.Message);
            }
        }
        public void DeleteItem(int id)
        {
            try
            {
                _sanPham.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete: " + ex.Message);
            }
        }
        public SanPhamDTO UpdateItem(SanPhamDTO newItem)
        {
            try
            {
                tb_SANPHAM newPhongBan = new tb_SANPHAM
                {
                    MASP = newItem.MASP,
                    TENSP = newItem.TENSP,
                    GIA = newItem.GIA,
                };
                _sanPham.UpdateItem(newPhongBan);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Error update: " + ex.Message);
            }
        }

    }
}
