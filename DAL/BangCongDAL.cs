using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BangCongDAL
    {
        public BangCongDTO GetItem(int id)
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var bangCong = context.tb_BANGCONG
                    .Where(e => e.MABC == id)
                    .Select(e => new BangCongDTO
                    {
                        MABC = e.MABC,
                        THANG = e.THANG,
                        NAM = e.NAM,
                        KHOA = e.KHOA,
                        TRANGTHAI = e.TRANGTHAI,
                        MACN = e.MACN,
                        NGAYCONGTRONGTHANG = e.NGAYCONGTRONGTHANG,
                        TENCN = e.tb_CHINHANH != null ? e.tb_CHINHANH.TENCN : null,
                    })
                    .FirstOrDefault();
                return bangCong;
            }

        }
        public List<BangCongDTO> GetLists()
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var bangCong = context.tb_BANGCONG
                    .Select(e => new BangCongDTO
                    {
                        MABC = e.MABC,
                        THANG = e.THANG,
                        NAM = e.NAM,
                        KHOA = e.KHOA,
                        TRANGTHAI = e.TRANGTHAI,
                        MACN = e.MACN,
                        NGAYCONGTRONGTHANG = e.NGAYCONGTRONGTHANG,
                        TENCN = e.tb_CHINHANH != null ? e.tb_CHINHANH.TENCN : null,
                    })
                    .ToList();
                return bangCong;
            }
        }
        public BangCongDTO AddItem(BangCongDTO bangCong)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {

                tb_BANGCONG dt = new tb_BANGCONG
                {
                    MABC = bangCong.MABC,
                    THANG = bangCong.THANG,
                    NAM = bangCong.NAM,
                    KHOA = bangCong.KHOA,
                    TRANGTHAI = bangCong.TRANGTHAI,
                    MACN = bangCong.MACN,
                    NGAYCONGTRONGTHANG = bangCong.NGAYCONGTRONGTHANG,
                };
                db.tb_BANGCONG.Add(dt);
                db.SaveChanges();
                return bangCong;
            };
        }

        public BangCongDTO UpdateItem(BangCongDTO bangCong)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var tp = db.tb_BANGCONG.FirstOrDefault(x => x.MABC == bangCong.MABC);
                if (tp == null)
                {
                    throw new Exception("Không tìm thấy bảng công " + bangCong.MABC + ", " + bangCong.MABC);
                }
                tp.MABC = bangCong.MABC;
                tp.MACN = bangCong.MACN;
                tp.THANG = bangCong.THANG;
                tp.NAM = bangCong.NAM;
                tp.KHOA = bangCong.KHOA;
                tp.TRANGTHAI = bangCong.TRANGTHAI;
                tp.NGAYCONGTRONGTHANG = bangCong.NGAYCONGTRONGTHANG;
                db.SaveChanges();
                return bangCong;
            }
        }

        public void DeleteItem(int _id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var bangCong = db.tb_BANGCONG.FirstOrDefault(x => x.MABC == _id);
                if (bangCong != null)
                {
                    db.tb_BANGCONG.Remove(bangCong);
                    db.SaveChanges();
                }
                else throw new Exception("xóa thất bại không tìm thấy Bản công ");
            };
        }
    }
}
