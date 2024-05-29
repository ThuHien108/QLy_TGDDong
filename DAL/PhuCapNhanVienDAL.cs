using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhuCapNhanVienDAL
    {

        public PhuCapNhanVienDTO GetItem(int MaPhuCapNV)
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var phuCap = context.tb_PHUCAP_NHANVIEN
                    .Where(e => e.MAPCNV == MaPhuCapNV)
                    .Select(e => new PhuCapNhanVienDTO
                    {
                        MAPCNV = e.MAPCNV,
                        SOTIEN = e.SOTIEN,
                        NGAY = e.NGAY,
                        NOIDUNG = e.NOIDUNG,
                        MAPC = e.MAPC,
                        MANV = e.MANV,
                        TENPC = e.tb_PHUCAP != null ? e.tb_PHUCAP.TENPHUCAP : null,
                        HOTEN = e.tb_NHANVIEN != null ? e.tb_NHANVIEN.HOTEN : null,
                    })
                    .FirstOrDefault();
                return phuCap;
            }
        }

        public List<PhuCapNhanVienDTO> GetListDetails()
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var phuCaps = context.tb_PHUCAP_NHANVIEN
                    .Select(e => new PhuCapNhanVienDTO
                    {
                        MAPCNV = e.MAPCNV,
                        SOTIEN = e.SOTIEN,
                        NGAY = e.NGAY,
                        NOIDUNG = e.NOIDUNG,
                        MANV = e.MANV,
                        MAPC = e.MAPC,
                        TENPC = e.tb_PHUCAP != null ? e.tb_PHUCAP.TENPHUCAP : null,
                        HOTEN = e.tb_NHANVIEN != null ? e.tb_NHANVIEN.HOTEN : null,
                    })
                    .ToList();
                return phuCaps;
            }
        }
        public PhuCapNhanVienDTO AddItem(PhuCapNhanVienDTO phuCap)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {

                tb_PHUCAP_NHANVIEN dt = new tb_PHUCAP_NHANVIEN
                {
                    MANV = phuCap.MANV,
                    MAPC = phuCap.MAPC,
                    NOIDUNG = phuCap.NOIDUNG,
                    SOTIEN = phuCap.SOTIEN,
                    NGAY = phuCap.NGAY,
                };
                db.tb_PHUCAP_NHANVIEN.Add(dt);
                db.SaveChanges();
                return phuCap;
            };
        }

        public PhuCapNhanVienDTO UpdateItem(PhuCapNhanVienDTO phuCap)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var tp = db.tb_PHUCAP_NHANVIEN.FirstOrDefault(x => x.MAPCNV == phuCap.MAPCNV);
                if (tp == null)
                {
                    throw new Exception("Không tìm thấy phụ cấp nhân viên: " + phuCap.MAPCNV + ", " + phuCap.HOTEN);
                }
                tp.MANV = phuCap.MANV;
                tp.MAPC = phuCap.MAPC;
                tp.NOIDUNG = phuCap.NOIDUNG;
                tp.SOTIEN = phuCap.SOTIEN;
                tp.NGAY = phuCap.NGAY;
                db.SaveChanges();
                return phuCap;
            }
        }

        public void DeleteItem(int _id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var phuCap = db.tb_PHUCAP_NHANVIEN.FirstOrDefault(x => x.MAPCNV == _id);
                if (phuCap != null)
                {
                    db.tb_PHUCAP_NHANVIEN.Remove(phuCap);
                    db.SaveChanges();
                }
                else throw new Exception("Xóa thất bại không tìm thấy phụ cấp nhân viên");
            };
        }
    }
}
