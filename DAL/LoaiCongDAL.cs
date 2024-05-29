using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiCongDAL
    {
        public List<tb_LOAICONG> GetList()
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_LOAICONG.ToList();
            }
        }
        public tb_LOAICONG GetItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_LOAICONG.FirstOrDefault(x => x.MALC == id);
            }
        }
        public bool IsDuplicateName(string ten)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                return db.tb_LOAICONG.Any(x => x.TENLC.ToLower().Trim() == ten.ToLower().Trim());
            }
        }
        public void AddItem(tb_LOAICONG newItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                if (IsDuplicateName(newItem.TENLC))
                {
                    throw new Exception("Tên loại công đã tồn tại trong cơ sở dữ liệu.");
                }
                db.tb_LOAICONG.Add(newItem);
                db.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var itemToDelete = db.tb_LOAICONG.FirstOrDefault(x => x.MALC == id);
                if (itemToDelete != null)
                {
                    if (!IsForeignKeyConstraintSatisfied(id))
                    {
                        throw new Exception("Không thể xóa loại công do có khóa ngoại hoặc điều kiện khác đang liên quan.");
                    }
                    db.tb_LOAICONG.Remove(itemToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy loại công cần xóa.");
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
        public void UpdateItem(tb_LOAICONG updatedItem)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var existingItem = db.tb_LOAICONG.FirstOrDefault(x => x.MALC == updatedItem.MALC);
                if (existingItem != null)
                {
                    existingItem.TENLC = updatedItem.TENLC;
                    existingItem.HESO = updatedItem.HESO;
                    existingItem.KYHIEU = updatedItem.KYHIEU;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy loại công cần cập nhật.");
                }
            }
        }
    }
}
