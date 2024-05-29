using BLL;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
    public partial class frmHopDong : DevExpress.XtraEditors.XtraForm
    {
        HopDongBLL _hopDong;
        frmHopDongChiTiet frm;
        string _soHD;
        public frmHopDong()
        {
            InitializeComponent();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            _hopDong = new HopDongBLL();
            frm = new frmHopDongChiTiet();
            _LoaData();

        }

        void _LoaData()
        {
            gvHopDong.DataSource = _hopDong.GetListDTOs();
            gvDataHopDong.OptionsBehavior.Editable = false;
        }


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._them = true;
            frm.ShowDialog();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._them = false;
            frm._soHD = _soHD;
            frm.ShowDialog();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _hopDong.DeleteItem(_soHD);
            _LoaData();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _LoaData();
        }

        private void gvHopDong_Click(object sender, EventArgs e)
        {
            _soHD = gvDataHopDong.GetFocusedRowCellValue("SOHD").ToString();
        }

        private void mnbtnXemChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._them = false;
            frm._soHD = _soHD;
            frm.ShowDialog();
        }

        private void gvDataHopDong_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            mnHopDong.ShowPopup(Control.MousePosition);
        }
    }
}