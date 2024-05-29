using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DanhSoChiTietDAL
    {
        public DanhSoChiTietDTO GetItem(int MaPhuCapNV)
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var danhSo = context.tb_DANHSOCHITIET
                    .Where(e => e.MADSCT == MaPhuCapNV)
                    .Select(e => new DanhSoChiTietDTO
                    {
                        MADSCT = e.MADSCT,
                        MASP = e.MASP,
                        MADS = e.MADS,
                        GHICHU = e.GHICHU,
                        TENSP = e.tb_SANPHAM != null ? e.tb_SANPHAM.TENSP : String.Empty,
                        GIA = e.tb_SANPHAM != null ? (double)e.tb_SANPHAM.GIA : double.NaN,
                    })
                    .FirstOrDefault();
                return danhSo;
            }
        }

        public List<DanhSoChiTietDTO> GetListDetails()
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var danhSos = context.tb_DANHSOCHITIET
                    .Select(e => new DanhSoChiTietDTO
                    {
                        MADSCT = e.MADSCT,
                        MASP = e.MASP,
                        MADS = e.MADS,
                        GHICHU = e.GHICHU,
                        TENSP = e.tb_SANPHAM != null ? e.tb_SANPHAM.TENSP : String.Empty,
                        GIA = e.tb_SANPHAM != null ? (double)e.tb_SANPHAM.GIA : double.NaN,
                    })
                    .ToList();
                return danhSos;
            }
        }
        public DanhSoChiTietDTO AddItem(DanhSoChiTietDTO danhSo)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {

                tb_DANHSOCHITIET dt = new tb_DANHSOCHITIET
                {
                    MADS = danhSo.MADS,
                    MASP = danhSo.MASP,
                    GHICHU = danhSo.GHICHU,
                    NGAY = danhSo.NGAY,
                };
                db.tb_DANHSOCHITIET.Add(dt);
                db.SaveChanges();
                return danhSo;
            };
        }

        public DanhSoChiTietDTO UpdateItem(DanhSoChiTietDTO danhSo)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var tp = db.tb_DANHSOCHITIET.FirstOrDefault(x => x.MADSCT == danhSo.MADSCT);
                if (tp == null)
                {
                    throw new Exception("Không tìm thấy danh số nhân viên: " + danhSo.MADSCT + ", " + danhSo.MADS);
                }
                tp.MADS = danhSo.MADS;
                tp.MASP = danhSo.MASP;
                tp.GHICHU = danhSo.GHICHU;
                tp.NGAY = danhSo.NGAY;
                db.SaveChanges();
                return danhSo;
            }
        }

        public void DeleteItem(int _id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var danhSo = db.tb_DANHSOCHITIET.FirstOrDefault(x => x.MADSCT == _id);
                if (danhSo != null)
                {
                    db.tb_DANHSOCHITIET.Remove(danhSo);
                    db.SaveChanges();
                }
                else throw new Exception("Xóa thất bại không tìm thấy danh số nhân viên");
            };
        }
    }
}
