using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiCongBLL
    {
        private LoaiCongDAL _loaiCong;
        public LoaiCongBLL()
        {
            _loaiCong = new LoaiCongDAL();
        }
        public List<LoaiCongDTO> GetListDTOs()
        {
            List<LoaiCongDTO> lst = new List<LoaiCongDTO>();
            List<tb_LOAICONG> lstDAL = _loaiCong.GetList();
            foreach (var item in lstDAL)
            {
                LoaiCongDTO tp = new LoaiCongDTO();
                tp.MALC = item.MALC;
                tp.TENLC = item.TENLC;
                tp.HESO = item.HESO;
                tp.KYHIEU = item.KYHIEU;
                lst.Add(tp);
            }
            return lst;
        }
        public LoaiCongDTO AddItem(LoaiCongDTO newItem)
        {
            try
            {
                tb_LOAICONG newLoaiCong = new tb_LOAICONG
                {
                    TENLC = newItem.TENLC,
                    HESO = newItem.HESO,
                    KYHIEU = newItem.KYHIEU,
                };
                _loaiCong.AddItem(newLoaiCong);
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
                _loaiCong.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete: " + ex.Message);
            }
        }
        public LoaiCongDTO UpdateItem(LoaiCongDTO newItem)
        {
            try
            {
                tb_LOAICONG newLoaiCong = new tb_LOAICONG
                {
                    MALC = newItem.MALC,
                    TENLC = newItem.TENLC,
                    HESO = newItem.HESO,
                    KYHIEU = newItem.KYHIEU,
                };
                _loaiCong.UpdateItem(newLoaiCong);
                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Update: " + ex.Message);
            }
        }

    }
}
