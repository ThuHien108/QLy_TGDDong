using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChucVuDAL
    {
        public List<tb_CHUCVU> GetList()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_CHUCVU.ToList();
            }
        }
        public tb_CHUCVU GetItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_CHUCVU.FirstOrDefault(x => x.MACV == id);
            }
        }
        public bool IsDuplicateName(string ten)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_CHUCVU.Any(x => x.TENCV.ToLower().Trim() == ten.ToLower().Trim());
            }
        }
        public void AddItem(tb_CHUCVU newItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                if (IsDuplicateName(newItem.TENCV))
                {
                    throw new Exception("Tên chức vụ đã tồn tại trong cơ sở dữ liệu.");
                }
                db.tb_CHUCVU.Add(newItem);
                db.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var itemToDelete = db.tb_CHUCVU.FirstOrDefault(x => x.MACV == id);
                if (itemToDelete != null)
                {
                    if (!IsForeignKeyConstraintSatisfied(id))
                    {
                        throw new Exception("Không thể xóa chức vụ do có khóa ngoại hoặc điều kiện khác đang liên quan.");
                    }
                    db.tb_CHUCVU.Remove(itemToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy chức vụ cần xóa.");
                }
            }
        }
        private bool IsForeignKeyConstraintSatisfied(int ma)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                bool hasRelatedNhanVien = db.tb_NHANVIEN.Any(x => x.MACV == ma);
                if (hasRelatedNhanVien)
                    return false;
                return true;
            }
        }
        public void UpdateItem(tb_CHUCVU updatedItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var existingItem = db.tb_CHUCVU.FirstOrDefault(x => x.MACV == updatedItem.MACV);
                if (existingItem != null)
                {
                    existingItem.TENCV = updatedItem.TENCV;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy chức vụ cần cập nhật.");
                }
            }
        }
    }
}
