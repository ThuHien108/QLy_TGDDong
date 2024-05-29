using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhuCapDAL
    {
        public List<tb_PHUCAP> GetList()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_PHUCAP.ToList();
            }
        }
        public tb_PHUCAP GetItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_PHUCAP.FirstOrDefault(x => x.MAPC == id);
            }
        }
        public bool IsDuplicateName(string ten)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_PHUCAP.Any(x => x.TENPHUCAP.ToLower().Trim() == ten.ToLower().Trim());
            }
        }
        public void AddItem(tb_PHUCAP newItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                if (IsDuplicateName(newItem.TENPHUCAP))
                {
                    throw new Exception("Tên phụ cấp đã tồn tại trong cơ sở dữ liệu.");
                }
                db.tb_PHUCAP.Add(newItem);
                db.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var itemToDelete = db.tb_PHUCAP.FirstOrDefault(x => x.MAPC == id);
                if (itemToDelete != null)
                {
                    if (!IsForeignKeyConstraintSatisfied(id))
                    {
                        throw new Exception("Không thể xóa phụ cấp do có khóa ngoại hoặc điều kiện khác đang liên quan.");
                    }
                    db.tb_PHUCAP.Remove(itemToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy phụ cấp cần xóa.");
                }
            }
        }
        private bool IsForeignKeyConstraintSatisfied(int ma)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                bool hasRelatedPhuCap_NhanVien = db.tb_PHUCAP_NHANVIEN.Any(x => x.MAPC == ma);
                if (hasRelatedPhuCap_NhanVien)
                    return false;
                return true;
            }
        }
        public void UpdateItem(tb_PHUCAP updatedItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var existingItem = db.tb_PHUCAP.FirstOrDefault(x => x.MAPC == updatedItem.MAPC);
                if (existingItem != null)
                {
                    existingItem.TENPHUCAP = updatedItem.TENPHUCAP;
                    existingItem.SOTIEN = updatedItem.SOTIEN;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy phụ cấp cần cập nhật.");
                }
            }
        }
    }
}
