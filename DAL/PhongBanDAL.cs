using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhongBanDAL
    {
        public List<tb_PHONGBAN> GetList()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_PHONGBAN.ToList();
            }
        }
        public tb_PHONGBAN GetItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_PHONGBAN.FirstOrDefault(x => x.MAPB == id);
            }
        }
        public bool IsDuplicateName(string ten)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_PHONGBAN.Any(x => x.TENPB.ToLower().Trim() == ten.ToLower().Trim());
            }
        }
        public void AddItem(tb_PHONGBAN newItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                if (IsDuplicateName(newItem.TENPB))
                {
                    throw new Exception("Tên phòng ban đã tồn tại trong cơ sở dữ liệu.");
                }
                db.tb_PHONGBAN.Add(newItem);
                db.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var itemToDelete = db.tb_PHONGBAN.FirstOrDefault(x => x.MAPB == id);
                if (itemToDelete != null)
                {
                    if (!IsForeignKeyConstraintSatisfied(id))
                    {
                        throw new Exception("Không thể xóa phòng ban do có khóa ngoại hoặc điều kiện khác đang liên quan.");
                    }
                    db.tb_PHONGBAN.Remove(itemToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy phòng ban cần xóa.");
                }
            }
        }
        private bool IsForeignKeyConstraintSatisfied(int chiNhanhId)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                bool hasRelatedNhanVien = db.tb_NHANVIEN.Any(x => x.MAPB == chiNhanhId);
                if (hasRelatedNhanVien)
                    return false;
                return true;
            }
        }
        public void UpdateItem(tb_PHONGBAN updatedItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var existingItem = db.tb_PHONGBAN.FirstOrDefault(x => x.MAPB == updatedItem.MAPB);
                if (existingItem != null)
                {
                    existingItem.TENPB = updatedItem.TENPB;
                    existingItem.SDT = updatedItem.SDT;
                    existingItem.MAIL = updatedItem.MAIL;
                    existingItem.DIACHI = updatedItem.DIACHI;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy Phòng ban cần cập nhật.");
                }
            }
        }
    }
}
