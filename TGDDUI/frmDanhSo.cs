using BLL;
using DevExpress.XtraEditors;
using DTO;
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
    public partial class frmDanhSo : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBLL _nhanVien;
        ChiNhanhBLL _ChiNhanh;
        DanhSoBLL _danhSo;
        bool _them;
        string _maDS;
        public frmDanhSo()
        {
            InitializeComponent();
        }

        private void frmDanhSo_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
            _ChiNhanh = new ChiNhanhBLL();
            _danhSo = new DanhSoBLL();
            _them = false;
            cboThang.Text = DateTime.Now.Month.ToString();
            cboNam.Text = DateTime.Now.Year.ToString();
            _LoadDataSkl();
            _LoadDataGv();
        }

        void _LoadDataSkl()
        {
            var nv = _nhanVien.GetListDTOs();
            slkNhanVien.Properties.DataSource = nv;
            slkNhanVien.Properties.DisplayMember = "HOTEN";
            slkNhanVien.Properties.ValueMember = "MANV";
            var cn = _ChiNhanh.GetListDTOs();
            slkChiNhanh.Properties.DataSource = cn;
            slkChiNhanh.Properties.DisplayMember = "TENCN";
            slkChiNhanh.Properties.ValueMember = "MACN";
        }

        void _LoadDataGv()
        {
            gvDanhSo.DataSource = _danhSo.GetListDTOs();
            gvDataDanhSo.OptionsBehavior.Editable = false;
        }
        private void _SaveData()
        {
            //try
            //{
            if (_them)
            {
                DanhSoDTO dt = new DanhSoDTO();

                dt.MACN = int.Parse(slkChiNhanh.EditValue.ToString());
                dt.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                dt.MADS = _danhSo.SoHopDong();
                dt.NAM = int.Parse(cboNam.EditValue.ToString());
                dt.THANG = int.Parse(cboThang.EditValue.ToString());
                dt.KHOA = chkKhoa.Checked;
                dt.TRANGTHAI = chkTrangThai.Checked;
                _danhSo.AddItemDTO(dt);
                MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadDataGv();

            }
            else
            {
                var dt = _danhSo.GetItemDTO(_maDS);
                dt.MACN = int.Parse(slkChiNhanh.EditValue.ToString());
                dt.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                dt.NAM = int.Parse(cboNam.EditValue.ToString());
                dt.THANG = int.Parse(cboThang.EditValue.ToString());
                dt.KHOA = chkKhoa.Checked;
                _danhSo.UpdateItem(dt);
                MessageBox.Show("Sửa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadDataGv();
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void _ShowHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            chkTrangThai.Enabled = !kt;
            chkKhoa.Enabled = !kt;
            btnThemExcel.Enabled = kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
        }
        private void btnBangCongChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _danhSo.PhatSinhDanhSo(_nhanVien);
            _LoadDataGv();
        }


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _ShowHide(false);
        }


        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _ShowHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_maDS == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _danhSo.DeleteItem(_maDS);
                    _LoadDataGv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _SaveData();
            _ShowHide(true);
        }
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ShowHide(true);
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gvDataDanhSo_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            mnDanhSo.ShowPopup(Control.MousePosition);
        }

        private void btnCapNhatDanhSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSoChiTiet frm = new frmDanhSoChiTiet();
            frm._ID = _maDS;
            frm.ShowDialog();
        }

        private void gvDanhSo_Click(object sender, EventArgs e)
        {
            _maDS = gvDataDanhSo.GetFocusedRowCellValue("MADS").ToString();
        }
    }
}