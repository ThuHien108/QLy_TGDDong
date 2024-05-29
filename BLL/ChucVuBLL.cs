using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChucVuBLL
    {
        ChucVuDAL _chucVu;
        public ChucVuBLL()
        {
            _chucVu = new ChucVuDAL();
        }
        public List<ChucVuDTO> GetListDTOs()
        {
            List<ChucVuDTO> lst = new List<ChucVuDTO>();
            List<tb_CHUCVU> lstDAL = _chucVu.GetList();
            foreach (var item in lstDAL)
            {
                ChucVuDTO tp = new ChucVuDTO();
                tp.MACV = item.MACV;
                tp.TENCV = item.TENCV;

                lst.Add(tp);
            }
            return lst;
        }
        public ChucVuDTO AddItem(ChucVuDTO newItem)
        {
            try
            {
                tb_CHUCVU newChiNhanh = new tb_CHUCVU
                {
                    TENCV = newItem.TENCV,
                };
                _chucVu.AddItem(newChiNhanh);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public void DeleteItem(int id)
        {
            try
            {
                _chucVu.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public ChucVuDTO UpdateItem(ChucVuDTO newItem)
        {
            try
            {
                tb_CHUCVU newPhongBan = new tb_CHUCVU
                {
                    TENCV = newItem.TENCV,
                    MACV = newItem.MACV,
                };
                _chucVu.UpdateItem(newPhongBan);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
