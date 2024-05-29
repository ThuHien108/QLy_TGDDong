using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiNhanhBLL
    {
        private ChiNhanhDAL _chiNhanhDAL;


        public ChiNhanhBLL()
        {
            _chiNhanhDAL = new ChiNhanhDAL();
        }
        public List<ChiNhanhDTO> GetListDTOs()
        {
            List<ChiNhanhDTO> lst = new List<ChiNhanhDTO>();
            List<tb_CHINHANH> lstDAL = _chiNhanhDAL.GetList();
            foreach (var item in lstDAL)
            {
                ChiNhanhDTO tp = new ChiNhanhDTO();
                tp.MACN = item.MACN;
                tp.TENCN = item.TENCN;
                tp.DIACHI = item.DIACHI;
                tp.MAIL = item.MAIL;
                tp.SDT = item.SDT;
                lst.Add(tp);
            }
            return lst;
        }

        public List<ChiNhanhDTO> GetChiNhanhDTOs()
        {
            List<ChiNhanhDTO> lst = new List<ChiNhanhDTO>();
            List<tb_CHINHANH> lstDAL = _chiNhanhDAL.GetList();
            foreach (var item in lstDAL)
            {
                ChiNhanhDTO tp = new ChiNhanhDTO();
                tp.MACN = item.MACN;
                tp.TENCN = item.TENCN;
                tp.DIACHI = item.DIACHI;
                tp.SDT = item.SDT;
                tp.MAIL = item.MAIL;
                lst.Add(tp);
            }
            return lst;
        }
        public ChiNhanhDTO AddItem(ChiNhanhDTO newItem)
        {
            try
            {
                tb_CHINHANH newChiNhanh = new tb_CHINHANH
                {
                    TENCN = newItem.TENCN,
                    DIACHI = newItem.DIACHI,
                    SDT = newItem.SDT,
                    MAIL = newItem.MAIL
                };
                _chiNhanhDAL.AddItem(newChiNhanh);
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
                _chiNhanhDAL.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public ChiNhanhDTO UpdateItem(ChiNhanhDTO newItem)
        {
            try
            {
                tb_CHINHANH newChiNhanh = new tb_CHINHANH
                {
                    TENCN = newItem.TENCN,
                    DIACHI = newItem.DIACHI,
                    SDT = newItem.SDT,
                    MAIL = newItem.MAIL
                };
                _chiNhanhDAL.UpdateItem(newChiNhanh);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
