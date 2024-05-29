using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DanhSoDAL
    {
        public DanhSoDTO GetItem(string _id)
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var danhSo = context.tb_DANHSO
                    .Where(e => e.MADS == _id)
                    .Select(e => new DanhSoDTO
                    {
                        MANV = e.MANV,
                        HOTEN = e.tb_NHANVIEN != null ? e.tb_NHANVIEN.HOTEN : null,
                        TENCN = e.tb_CHINHANH != null ? e.tb_CHINHANH.TENCN : null,
                        MACN = e.MACN,
                        KHOA = e.KHOA,
                        MADS = e.MADS,
                        NAM = e.NAM,
                        THANG = e.THANG,
                        TONGDS = e.TONGDS,
                        TRANGTHAI = e.TRANGTHAI
                    })
                    .FirstOrDefault();
                return danhSo;
            }

        }
        public List<DanhSoDTO> GetlistDetails()
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var danhSo = context.tb_DANHSO
                    .Select(e => new DanhSoDTO
                    {
                        MANV = e.MANV,
                        HOTEN = e.tb_NHANVIEN != null ? e.tb_NHANVIEN.HOTEN : null,
                        TENCN = e.tb_CHINHANH != null ? e.tb_CHINHANH.TENCN : null,
                        MACN = e.MACN,
                        KHOA = e.KHOA,
                        MADS = e.MADS,
                        NAM = e.NAM,
                        THANG = e.THANG,
                        TONGDS = e.TONGDS,
                        TRANGTHAI = e.TRANGTHAI
                    })
                    .ToList();
                return danhSo;
            }
        }
        public DanhSoDTO AddItem(DanhSoDTO e)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                bool danhSoExists = db.tb_DANHSO.Any(ds => ds.MANV == e.MANV && ds.NAM == e.NAM && ds.THANG == e.THANG);
                if (!danhSoExists)
                {
                    tb_DANHSO dt = new tb_DANHSO
                    {
                        MANV = e.MANV,
                        MACN = e.MACN,
                        KHOA = e.KHOA,
                        MADS = e.MADS,
                        NAM = e.NAM,
                        THANG = e.THANG,
                        TONGDS = e.TONGDS,
                        TRANGTHAI = e.TRANGTHAI
                    };
                    db.tb_DANHSO.Add(dt);
                    db.SaveChanges();
                    return e;
                }
                return null;
            }
        }

        public DanhSoDTO UpdateItem(DanhSoDTO e)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var tp = db.tb_DANHSO.FirstOrDefault(x => x.MADS == e.MADS);
                if (tp == null)
                {
                    throw new Exception("Không tìm thấy danh số: " + e.MADS + ", " + e.HOTEN);
                }
                tp.MANV = e.MANV;
                tp.MACN = e.MACN;
                tp.KHOA = e.KHOA;
                tp.MADS = e.MADS;
                tp.NAM = e.NAM;
                tp.THANG = e.THANG;
                tp.TONGDS = e.TONGDS;
                tp.TRANGTHAI = e.TRANGTHAI;
                db.SaveChanges();
                return e;
            }
        }

        public void DeleteItem(string _id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var danhSo = db.tb_DANHSO.FirstOrDefault(x => x.MADS == _id);
                if (danhSo != null)
                {
                    db.tb_DANHSO.Remove(danhSo);
                    db.SaveChanges();
                }
                else throw new Exception("xóa thất bại không tìm thấy danh số");
            };
        }
        public string MaxSoHopDong()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var _hd = db.tb_DANHSO.OrderByDescending(x => x.MADS).FirstOrDefault();
                if (_hd != null)
                    return _hd.MADS;
                else
                    return "00001";
            };
        }

    }
}
