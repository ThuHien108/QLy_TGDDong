using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HopDongDAL
    {
        public HopDongDTO GetItem(string soHD)
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var hopDong = context.tb_HOPDONG
                    .Where(e => e.SOHD == soHD)
                    .Select(e => new HopDongDTO
                    {
                        MANV = e.MANV,
                        SOHD = e.SOHD,
                        NGAYBATDAU = e.NGAYBATDAU,
                        NGAYKETTHUC = e.NGAYKETTHUC,
                        NGAYKY = e.NGAYKY,
                        HESOLUONG = e.HESOLUONG,
                        THOIGIAN = e.THOIGIAN,
                        LANKY = e.LANKY,
                        NOIDUNG = e.NOIDUNG,
                        MACN = e.MACN,
                        HOTEN = e.tb_NHANVIEN != null ? e.tb_NHANVIEN.HOTEN : null,
                    })
                    .FirstOrDefault();
                return hopDong;
            }

        }
        public List<HopDongDTO> GetListDetails()
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var hopDongLists = context.tb_HOPDONG
                    .Select(e => new HopDongDTO
                    {
                        MANV = e.MANV,
                        SOHD = e.SOHD,
                        NGAYBATDAU = e.NGAYBATDAU,
                        NGAYKETTHUC = e.NGAYKETTHUC,
                        NGAYKY = e.NGAYKY,
                        HESOLUONG = e.HESOLUONG,
                        THOIGIAN = e.THOIGIAN,
                        LANKY = e.LANKY,
                        NOIDUNG = e.NOIDUNG,
                        HOTEN = e.tb_NHANVIEN != null ? e.tb_NHANVIEN.HOTEN : null,
                        MACN = e.MACN,
                    })
                    .ToList();
                return hopDongLists;
            }
        }
        public HopDongDTO AddItem(HopDongDTO e)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {

                tb_HOPDONG dt = new tb_HOPDONG
                {
                    MANV = e.MANV,
                    SOHD = e.SOHD,
                    NGAYBATDAU = e.NGAYBATDAU,
                    NGAYKETTHUC = e.NGAYKETTHUC,
                    NGAYKY = e.NGAYKY,
                    HESOLUONG = e.HESOLUONG,
                    THOIGIAN = e.THOIGIAN,
                    LANKY = e.LANKY,
                    NOIDUNG = e.NOIDUNG,
                    MACN = e.MACN,
                };
                db.tb_HOPDONG.Add(dt);
                db.SaveChanges();
                return e;
            };
        }

        public HopDongDTO UpdateItem(HopDongDTO hopDong)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var tp = db.tb_HOPDONG.FirstOrDefault(x => x.SOHD == hopDong.SOHD);
                if (tp == null)
                {
                    throw new Exception("Không tìm thấy nhân viên: " + hopDong.SOHD);
                }
                tp.MANV = hopDong.MANV;
                tp.SOHD = hopDong.SOHD;
                tp.NGAYBATDAU = hopDong.NGAYBATDAU;
                tp.NGAYKETTHUC = hopDong.NGAYKETTHUC;
                tp.NGAYKY = hopDong.NGAYKY;
                tp.HESOLUONG = hopDong.HESOLUONG;
                tp.THOIGIAN = hopDong.THOIGIAN;
                tp.LANKY = hopDong.LANKY;
                tp.NOIDUNG = hopDong.NOIDUNG;
                tp.MACN = hopDong.MACN;
                db.SaveChanges();
                return hopDong;
            }
        }
        public void DeleteItem(string _id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var hopDong = db.tb_HOPDONG.FirstOrDefault(x => x.SOHD == _id);
                if (hopDong != null)
                {
                    db.tb_HOPDONG.Remove(hopDong);
                    db.SaveChanges();
                }
                else throw new Exception("Xóa thất bại không tìm thấy hợp đồng");
            };
        }
        public string MaxSoHopDong()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var _hd = db.tb_HOPDONG.OrderByDescending(x => x.NGAYBATDAU).FirstOrDefault();
                if (_hd != null)
                    return _hd.SOHD;
                else
                    return "00001";
            };
        }
    }
}
