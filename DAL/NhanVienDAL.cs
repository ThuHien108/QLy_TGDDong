using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DAL
{
    public class NhanVienDAL
    {
        public NhanVienDTO GetItem(int employeeId)
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var employee = context.tb_NHANVIEN
                    .Where(e => e.MANV == employeeId)
                    .Select(e => new NhanVienDTO
                    {
                        MANV = e.MANV,
                        HOTEN = e.HOTEN,
                        GIOITINH = e.GIOITINH,
                        NGAYSINH = e.NGAYSINH,
                        DIENTHOAI = e.DIENTHOAI,
                        EMAIL = e.EMAIL,
                        HINHANH = e.HINHANH,
                        CCCD = e.CCCD,
                        DIACHI = e.DIACHI,
                        TENPB = e.tb_PHONGBAN != null ? e.tb_PHONGBAN.TENPB : null,
                        TENCV = e.tb_CHUCVU != null ? e.tb_CHUCVU.TENCV : null,
                        TENCN = e.tb_CHINHANH != null ? e.tb_CHINHANH.TENCN : null,
                        MAPB = e.MAPB,
                        MACV = e.MACV,
                        MACN = e.MACN
                    })
                    .FirstOrDefault();
                return employee;
            }

        }
        public List<NhanVienDTO> GetEmployeesWithDetails()
        {
            using (DB_QLTGDDEntities context = new DB_QLTGDDEntities())
            {
                var employeeList = context.tb_NHANVIEN
                    .Select(e => new NhanVienDTO
                    {
                        MANV = e.MANV,
                        HOTEN = e.HOTEN,
                        GIOITINH = e.GIOITINH,
                        NGAYSINH = e.NGAYSINH,
                        DIENTHOAI = e.DIENTHOAI,
                        EMAIL = e.EMAIL,
                        HINHANH = e.HINHANH,
                        CCCD = e.CCCD,
                        DIACHI = e.DIACHI,
                        TENPB = e.tb_PHONGBAN != null ? e.tb_PHONGBAN.TENPB : null,
                        TENCV = e.tb_CHUCVU != null ? e.tb_CHUCVU.TENCV : null,
                        TENCN = e.tb_CHINHANH != null ? e.tb_CHINHANH.TENCN : null,
                        MAPB = e.MAPB,
                        MACV = e.MACV,
                        MACN = e.MACN
                    })
                    .ToList();
                return employeeList;
            }
        }
        public NhanVienDTO AddItem(NhanVienDTO nhanVien)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {

                tb_NHANVIEN dt = new tb_NHANVIEN
                {
                    MACN = nhanVien.MACN,
                    MAPB = nhanVien.MAPB,
                    MACV = nhanVien.MACV,
                    HOTEN = nhanVien.HOTEN,
                    GIOITINH = nhanVien.GIOITINH,
                    NGAYSINH = nhanVien.NGAYSINH,
                    EMAIL = nhanVien.EMAIL,
                    HINHANH = nhanVien.HINHANH,
                    DIENTHOAI = nhanVien.DIENTHOAI,
                    CCCD = nhanVien.CCCD,
                    DIACHI = nhanVien.DIACHI,
                };
                db.tb_NHANVIEN.Add(dt);
                db.SaveChanges();
                return nhanVien;
            };
        }

        public NhanVienDTO UpdateItem(NhanVienDTO nhanVien)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var tp = db.tb_NHANVIEN.FirstOrDefault(x => x.MANV == nhanVien.MANV);
                if (tp == null)
                {
                    throw new Exception("Không tìm thấy nhân viên: " + nhanVien.MANV + ", " + nhanVien.HOTEN);
                }
                tp.MACN = nhanVien.MACN;
                tp.MAPB = nhanVien.MAPB;
                tp.MACV = nhanVien.MACV;
                tp.HOTEN = nhanVien.HOTEN;
                tp.GIOITINH = nhanVien.GIOITINH;
                tp.NGAYSINH = nhanVien.NGAYSINH;
                tp.EMAIL = nhanVien.EMAIL;
                tp.HINHANH = nhanVien.HINHANH;
                tp.DIENTHOAI = nhanVien.DIENTHOAI;
                tp.CCCD = nhanVien.CCCD;
                tp.DIACHI = nhanVien.DIACHI;
                db.SaveChanges();
                return nhanVien;
            }
        }

        public void DeleteItem(int _id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var nhanVien = db.tb_NHANVIEN.FirstOrDefault(x => x.MANV == _id);
                if (nhanVien != null)
                {
                    db.tb_NHANVIEN.Remove(nhanVien);
                    db.SaveChanges();
                }
                else throw new Exception("xóa thất bại không tìm thấy nhân viên nhân viên");
            };
        }
    }
}