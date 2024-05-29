using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BangChamCongDAL
    {
        public List<BangChamCongDTO> getList(int makycong)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var listBangCong = db.tb_BangChamCong
                   .Select(kycongchitiet => new BangChamCongDTO
                   {
                       MANV = kycongchitiet.MANV,
                       HOTEN = kycongchitiet.tb_NHANVIEN.HOTEN,
                       MABC = makycong,
                       D1 = kycongchitiet.D1,
                       D2 = kycongchitiet.D2,
                       D3 = kycongchitiet.D3,
                       D4 = kycongchitiet.D4,
                       D5 = kycongchitiet.D5,
                       D6 = kycongchitiet.D6,
                       D7 = kycongchitiet.D7,
                       D8 = kycongchitiet.D8,
                       D9 = kycongchitiet.D9,
                       D10 = kycongchitiet.D10,
                       D11 = kycongchitiet.D11,
                       D12 = kycongchitiet.D12,
                       D13 = kycongchitiet.D13,
                       D14 = kycongchitiet.D14,
                       D15 = kycongchitiet.D15,
                       D16 = kycongchitiet.D16,
                       D17 = kycongchitiet.D17,
                       D18 = kycongchitiet.D18,
                       D19 = kycongchitiet.D19,
                       D20 = kycongchitiet.D20,
                       D21 = kycongchitiet.D21,
                       D22 = kycongchitiet.D22,
                       D23 = kycongchitiet.D23,
                       D24 = kycongchitiet.D24,
                       D25 = kycongchitiet.D25,
                       D26 = kycongchitiet.D26,
                       D27 = kycongchitiet.D27,
                       D28 = kycongchitiet.D28,
                       D29 = kycongchitiet.D29,
                       D30 = kycongchitiet.D30,
                       D31 = kycongchitiet.D31,
                   })
                   .ToList();
                return listBangCong;
            }
        }
        public bool UpdateColumnValue(int maKC, int maNV, string columnName, string newValue)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var bangChamCong = db.tb_BangChamCong.FirstOrDefault(x => x.MABC == maKC && x.MANV == maNV);

                if (bangChamCong != null)
                {
                    // Kiểm tra xem columnName có nằm trong danh sách các cột D1, D2, ... D31 không
                    if (columnName.StartsWith("D") && int.TryParse(columnName.Substring(1), out int day) && day >= 1 && day <= 31)
                    {
                        typeof(tb_BangChamCong).GetProperty(columnName)?.SetValue(bangChamCong, newValue);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }
        public BangChamCongDAL GetItem(int id, int manv)
        {
            BangChamCongDAL bangChamCongDAL = null;
            return bangChamCongDAL;
        }

        public void phatSinhKyCongChiTiet(int makc, int thang, int nam)
        {
            using (DB_QLTGDDEntities db = new DB_QLTGDDEntities())
            {
                var lstNV = db.tb_NHANVIEN.ToList();
                if (lstNV.Count == 0) return;

                foreach (var item in lstNV)
                {
                    List<string> listDay = new List<string>();

                    for (int j = 1; j <= GetDayNumber(thang, nam); j++)
                    {
                        DateTime newDate = new DateTime(nam, thang, j);

                        switch (newDate.DayOfWeek.ToString())
                        {
                            case "Sunday":
                                listDay.Add("CN");
                                break;
                            //case "Saturday":
                            //    listDay.Add("T7");
                            //    break;
                            default:
                                listDay.Add("X");
                                break;
                        }
                    }

                    switch (listDay.Count)
                    {
                        case 28:
                            listDay.Add("");
                            listDay.Add("");
                            listDay.Add("");
                            break;
                        case 29:
                            listDay.Add("");
                            listDay.Add("");
                            break;
                        case 30:
                            listDay.Add("");
                            break;
                    }

                    tb_BangChamCong kycongchitiet = new tb_BangChamCong();
                    kycongchitiet.MABC = makc;
                    kycongchitiet.MANV = item.MANV;
                    kycongchitiet.D1 = listDay[0];
                    kycongchitiet.D2 = listDay[1];
                    kycongchitiet.D3 = listDay[2];
                    kycongchitiet.D4 = listDay[3];
                    kycongchitiet.D5 = listDay[4];
                    kycongchitiet.D6 = listDay[5];
                    kycongchitiet.D7 = listDay[6];
                    kycongchitiet.D8 = listDay[7];
                    kycongchitiet.D9 = listDay[8];
                    kycongchitiet.D10 = listDay[9];
                    kycongchitiet.D11 = listDay[10];
                    kycongchitiet.D12 = listDay[11];
                    kycongchitiet.D13 = listDay[12];
                    kycongchitiet.D14 = listDay[13];
                    kycongchitiet.D15 = listDay[14];
                    kycongchitiet.D16 = listDay[15];
                    kycongchitiet.D17 = listDay[16];
                    kycongchitiet.D18 = listDay[17];
                    kycongchitiet.D19 = listDay[18];
                    kycongchitiet.D20 = listDay[19];
                    kycongchitiet.D21 = listDay[20];
                    kycongchitiet.D22 = listDay[21];
                    kycongchitiet.D23 = listDay[22];
                    kycongchitiet.D24 = listDay[23];
                    kycongchitiet.D25 = listDay[24];
                    kycongchitiet.D26 = listDay[25];
                    kycongchitiet.D27 = listDay[26];
                    kycongchitiet.D28 = listDay[27];
                    kycongchitiet.D29 = listDay[28];
                    kycongchitiet.D30 = listDay[29];
                    kycongchitiet.D31 = listDay[30];
                    db.tb_BangChamCong.Add(kycongchitiet);
                    db.SaveChanges();
                }
            }
        }
        private int GetDayNumber(int thang, int nam)
        {
            int dayNumber = 0;

            switch (thang)
            {
                case 2:
                    dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dayNumber = 30;
                    break;

                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayNumber = 31;
                    break;
            }

            return dayNumber;
        }
    }
}
