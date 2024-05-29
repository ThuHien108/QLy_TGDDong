using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGDDUI
{
    public partial class frmBangCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public int _thang;
        public int _nam;
        public int _maBc;
        public int _maCN;

        BangCongBLL _BangCong;
        BangChamCongBLL _ChamCongBLL;
        public frmBangCongChiTiet()
        {
            InitializeComponent();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmBangCongChiTiet_Load(object sender, EventArgs e)
        {
            _BangCong = new BangCongBLL();
            _ChamCongBLL = new BangChamCongBLL();
            _LoadData();
            CustomView(_thang, _nam);
        }
        void _LoadData()
        {
            gvBangChamCong.DataSource = _ChamCongBLL.GetLists(_maBc);
            gvDataBangChamCong.OptionsBehavior.Editable = false;
        }

        private void btnBangCongChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ChamCongBLL.PhatSinhBangCong(_maBc, _thang, _nam);
            _LoadData();

        }

        private void gvBangChamCong_Click(object sender, EventArgs e)
        {

        }
        private void SetupGridColumn(GridColumn column, string caption, bool allowEdit, Color headerForeColor,
            Color headerBackColor, Color headerBackColor2, Color cellForeColor, Color cellBackColor, bool allowFocus)
        {
            column.Caption = caption;
            column.OptionsColumn.AllowEdit = allowEdit;
            column.AppearanceHeader.ForeColor = headerForeColor;
            column.AppearanceHeader.BackColor = headerBackColor;
            column.AppearanceHeader.BackColor2 = headerBackColor2;
            column.AppearanceCell.ForeColor = cellForeColor;
            column.AppearanceCell.BackColor = cellBackColor;
            column.OptionsColumn.AllowFocus = allowFocus;
        }
        private void CustomView(int thang, int nam)
        {
            gvDataBangChamCong.RestoreLayoutFromXml(Application.StartupPath + @"\BangCong_Layout.xml");
            int i;
            foreach (GridColumn gridColumn in gvDataBangChamCong.Columns)
            {
                if (gridColumn.FieldName == "HOTEN") continue;

                RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
                textEdit.Mask.MaskType = MaskType.RegEx;
                textEdit.Mask.EditMask = @"\p{Lu}+";
                gridColumn.ColumnEdit = textEdit;
            }
            for (i = 1; i <= GetDayNumber(thang, nam); i++)
            {
                DateTime newDate = new DateTime(nam, thang, i);
                string fieldName = "D" + i;
                GridColumn column = gvDataBangChamCong.Columns[fieldName];

                switch (newDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        SetupGridColumn(column, "T.Hai " + Environment.NewLine + i, true, Color.DarkGray, Color.Transparent, Color.Transparent, Color.Black, Color.Transparent, true);
                        break;
                    case DayOfWeek.Tuesday:
                        SetupGridColumn(column, "T.Ba " + Environment.NewLine + i, true, Color.DarkGray, Color.Transparent, Color.Transparent, Color.Black, Color.Transparent, true);
                        break;
                    case DayOfWeek.Wednesday:
                        SetupGridColumn(column, "T.Tư " + Environment.NewLine + i, true, Color.DarkGray, Color.Transparent, Color.Transparent, Color.Black, Color.Transparent, true);
                        break;
                    case DayOfWeek.Thursday:
                        SetupGridColumn(column, "T.Năm " + Environment.NewLine + i, true, Color.DarkGray, Color.Transparent, Color.Transparent, Color.Black, Color.Transparent, true);
                        break;
                    case DayOfWeek.Friday:
                        SetupGridColumn(column, "T.Sáu " + Environment.NewLine + i, true, Color.DarkGray, Color.Transparent, Color.Transparent, Color.Black, Color.Transparent, true);
                        break;
                    case DayOfWeek.Saturday:
                        SetupGridColumn(column, "T.Bảy " + Environment.NewLine + i, true, Color.White, Color.LightYellow, Color.OrangeRed, Color.Black, Color.LightYellow, true);
                        break;
                    case DayOfWeek.Sunday:
                        SetupGridColumn(column, "CN " + Environment.NewLine + i, false, Color.White, Color.OrangeRed, Color.OrangeRed, Color.White, Color.Orange, false);
                        break;
                }

            }

            while (i <= 31)
            {
                gvDataBangChamCong.Columns[i + 1].Visible = false;
                i++;
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

        private void gvDataBangChamCong_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != null)
            {
                string cellValue = e.CellValue.ToString().Trim();

                if (cellValue == "VR")
                {
                    e.Appearance.BackColor = Color.SkyBlue;
                    e.Appearance.ForeColor = Color.DarkRed;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;

                }
                if (cellValue == "P")
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.DarkRed;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
                if (cellValue == "V")
                {
                    e.Appearance.BackColor = Color.IndianRed;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;

                }
            }
        }
    }
}