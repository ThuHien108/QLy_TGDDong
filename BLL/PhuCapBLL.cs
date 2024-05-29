using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhuCapBLL
    {
        private PhuCapDAL _phuCap;
        public PhuCapBLL()
        {
            _phuCap = new PhuCapDAL();
        }
        public PhuCapDTO GetItemDTO(int id)
        {

            var item = _phuCap.GetItem(id);
            PhuCapDTO tp = new PhuCapDTO();
            tp.MAPC = item.MAPC;
            tp.TENPHUCAP = item.TENPHUCAP;
            tp.SOTIEN = item.SOTIEN;
            return tp;
        }
        public List<PhuCapDTO> GetListDTOs()
        {
            List<PhuCapDTO> lst = new List<PhuCapDTO>();
            List<tb_PHUCAP> lstDAL = _phuCap.GetList();
            foreach (var item in lstDAL)
            {
                PhuCapDTO tp = new PhuCapDTO();
                tp.MAPC = item.MAPC;
                tp.TENPHUCAP = item.TENPHUCAP;
                tp.SOTIEN = item.SOTIEN;
                lst.Add(tp);
            }
            return lst;
        }
        public PhuCapDTO AddItem(PhuCapDTO newItem)
        {
            try
            {
                tb_PHUCAP newPhuCap = new tb_PHUCAP
                {
                    TENPHUCAP = newItem.TENPHUCAP,
                    SOTIEN = newItem.SOTIEN,
                };
                _phuCap.AddItem(newPhuCap);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Add: " + ex.Message);
            }
        }
        public void DeleteItem(int id)
        {
            try
            {
                _phuCap.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("delete: " + ex.Message);
            }
        }
        public PhuCapDTO UpdateItem(PhuCapDTO newItem)
        {
            try
            {
                tb_PHUCAP newPhuCap = new tb_PHUCAP
                {
                    MAPC = newItem.MAPC,
                    TENPHUCAP = newItem.TENPHUCAP,
                    SOTIEN = newItem.SOTIEN,
                };
                _phuCap.UpdateItem(newPhuCap);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("update: " + ex.Message);
            }
        }

    }
}
