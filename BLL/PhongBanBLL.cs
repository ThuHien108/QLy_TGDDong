using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhongBanBLL
    {
        private PhongBanDAL _phongBan;
        public PhongBanBLL()
        {
            _phongBan = new PhongBanDAL();
        }
        public List<PhongBanDTO> GetListDTOs()
        {
            List<PhongBanDTO> lst = new List<PhongBanDTO>();
            List<tb_PHONGBAN> lstDAL = _phongBan.GetList();
            foreach (var item in lstDAL)
            {
                PhongBanDTO tp = new PhongBanDTO();
                tp.MAPB = item.MAPB;
                tp.TENPB = item.TENPB;
                tp.DIACHI = item.DIACHI;
                tp.SDT = item.SDT;
                tp.MAIL = item.MAIL;
                lst.Add(tp);
            }
            return lst;
        }
        public PhongBanDTO AddItem(PhongBanDTO newItem)
        {
            try
            {
                tb_PHONGBAN newChiNhanh = new tb_PHONGBAN
                {
                    TENPB = newItem.TENPB,
                    DIACHI = newItem.DIACHI,
                    SDT = newItem.SDT,
                    MAIL = newItem.MAIL
                };
                _phongBan.AddItem(newChiNhanh);
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
                _phongBan.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public PhongBanDTO UpdateItem(PhongBanDTO newItem)
        {
            try
            {
                tb_PHONGBAN newPhongBan = new tb_PHONGBAN
                {
                    MAPB = newItem.MAPB,
                    TENPB = newItem.TENPB,
                    DIACHI = newItem.DIACHI,
                    SDT = newItem.SDT,
                    MAIL = newItem.MAIL
                };
                _phongBan.UpdateItem(newPhongBan);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

    }
}
