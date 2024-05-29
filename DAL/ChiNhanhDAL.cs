using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiNhanhDAL
    {

        public List<tb_CHINHANH> GetList()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_CHINHANH.ToList();
            }
        }
        public tb_CHINHANH GetItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_CHINHANH.FirstOrDefault(x => x.MACN == id);
            }
        }
        public bool IsDuplicateName(string tenChiNhanh)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_CHINHANH.Any(x => x.TENCN.ToLower().Trim() == tenChiNhanh.ToLower().Trim());
            }
        }
        public void AddItem(tb_CHINHANH newItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                if (IsDuplicateName(newItem.TENCN))
                {
                    throw new Exception("Tên chi nhánh đã tồn tại trong cơ sở dữ liệu.");
                }
                db.tb_CHINHANH.Add(newItem);
                db.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var itemToDelete = db.tb_CHINHANH.FirstOrDefault(x => x.MACN == id);
                if (itemToDelete != null)
                {
                    if (!IsForeignKeyConstraintSatisfied(id))
                    {
                        throw new Exception("Không thể xóa chi nhánh do có khóa ngoại hoặc điều kiện khác đang liên quan.");
                    }
                    db.tb_CHINHANH.Remove(itemToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy chi nhánh cần xóa.");
                }
            }
        }
        private bool IsForeignKeyConstraintSatisfied(int chiNhanhId)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                bool hasRelatedNhanVien = db.tb_NHANVIEN.Any(x => x.MACN == chiNhanhId);
                bool hasRelatedBangCong = db.tb_BANGCONG.Any(x => x.MACN == chiNhanhId);
                bool hasRelatedDanhSo = db.tb_DANHSO.Any(x => x.MACN == chiNhanhId);
                if (hasRelatedNhanVien || hasRelatedBangCong || hasRelatedDanhSo)
                    return false;
                return true;
            }
        }
        public void UpdateItem(tb_CHINHANH updatedItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var existingItem = db.tb_CHINHANH.FirstOrDefault(x => x.MACN == updatedItem.MACN);
                if (existingItem != null)
                {
                    if (IsDuplicateName(updatedItem.TENCN))
                    {
                        throw new Exception("Tên chi nhánh đã tồn tại trong cơ sở dữ liệu.");
                    }
                    existingItem.TENCN = updatedItem.TENCN;
                    existingItem.SDT = updatedItem.SDT;
                    existingItem.MAIL = updatedItem.MAIL;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy chi nhánh cần cập nhật.");
                }
            }
        }
    }
}
