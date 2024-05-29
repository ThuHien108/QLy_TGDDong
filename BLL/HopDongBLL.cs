using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HopDongBLL
    {
        private readonly HopDongDAL _hopDong;

        public HopDongBLL()
        {
            _hopDong = new HopDongDAL();
        }

        public List<HopDongDTO> GetListDTOs() => _hopDong.GetListDetails();

        public HopDongDTO GetItemDTO(string id) => _hopDong.GetItem(id);

        public HopDongDTO AddItemDTO(HopDongDTO hopDong)
        {
            _hopDong.AddItem(hopDong);
            return hopDong;
        }

        public void DeleteItem(string _id) => _hopDong.DeleteItem(_id);

        public void UpdateItem(HopDongDTO hopDong) => _hopDong.UpdateItem(hopDong);
        public string SoHopDong()
        {
            var maxSoHD = _hopDong.MaxSoHopDong();
            int so = int.Parse(maxSoHD.Substring(0, 5)) + 1;
            string shd = so.ToString("00000") + $@"/{DateTime.Now.Year}/HDLD";
            return shd;
        }


    }
}
