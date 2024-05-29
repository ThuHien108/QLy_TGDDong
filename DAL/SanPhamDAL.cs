using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        public List<tb_SANPHAM> GetList()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_SANPHAM.ToList();
            }
        }
        public SanPhamDTO GetItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var product = db.tb_SANPHAM
                  .Where(e => e.MASP == id)
                  .Select(e => new SanPhamDTO
                  {
                      TENSP = e.TENSP,
                      MASP = e.MASP,
                      GIA = e.GIA,
                  })
                  .FirstOrDefault();
                return product;
            }
        }
        public bool IsDuplicateName(string ten)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_SANPHAM.Any(x => x.TENSP.ToLower().Trim() == ten.ToLower().Trim());
            }
        }
        public void AddItem(tb_SANPHAM newItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                if (IsDuplicateName(newItem.TENSP))
                {
                    throw new Exception("Tên sản phẩm đã tồn tại trong cơ sở dữ liệu.");
                }
                db.tb_SANPHAM.Add(newItem);
                db.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var itemToDelete = db.tb_SANPHAM.FirstOrDefault(x => x.MASP == id);
                if (itemToDelete != null)
                {
                    if (!IsForeignKeyConstraintSatisfied(id))
                    {
                        throw new Exception("Không thể xóa sản phẩm do có khóa ngoại hoặc điều kiện khác đang liên quan.");
                    }
                    db.tb_SANPHAM.Remove(itemToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy sản phẩm cần xóa.");
                }
            }
        }
        private bool IsForeignKeyConstraintSatisfied(int ma)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                bool hasRelatedDanhSoChiTiet = db.tb_DANHSOCHITIET.Any(x => x.MASP == ma);
                if (hasRelatedDanhSoChiTiet)
                    return false;
                return true;
            }
        }
        public void UpdateItem(tb_SANPHAM updatedItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var existingItem = db.tb_SANPHAM.FirstOrDefault(x => x.MASP == updatedItem.MASP);
                if (existingItem != null)
                {
                    existingItem.TENSP = updatedItem.TENSP;
                    existingItem.GIA = updatedItem.GIA;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy sản phẩm cần cập nhật.");
                }
            }
        }
    }
}
