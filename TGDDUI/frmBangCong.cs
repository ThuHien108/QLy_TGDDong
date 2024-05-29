using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Filtering.Templates;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGDDUI
{
    public partial class frmBangCong : DevExpress.XtraEditors.XtraForm
    {
        ChiNhanhBLL _ChiNhanh;
        bool _them;
        int _id;
        BangCongBLL _BangCong;
        int _thang;
        int _nam;
        public frmBangCong()
        {
            InitializeComponent();
        }

        private void frmBangCong_Load(object sender, EventArgs e)
        {
            _ChiNhanh = new ChiNhanhBLL();
            _BangCong = new BangCongBLL();
            _LoadSlkChiNhanh();
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();
            _them = false;
            _LoadData();
            _ShowHide(true);
        }

        void _LoadSlkChiNhanh()
        {
            slkChiNhanh.Properties.DataSource = _ChiNhanh.GetChiNhanhDTOs();
            slkChiNhanh.Properties.DisplayMember = "TENCN";
            slkChiNhanh.Properties.ValueMember = "MACN";
        }


        private void btnBangCongChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangCongChiTiet frm = new frmBangCongChiTiet();
            frm._maBc = _id;
            frm._thang = int.Parse(cboThang.Text);
            frm._nam = int.Parse(cboNam.Text);
            frm.ShowDialog();
        }




        private void _ShowHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;


            btnThemExcel.Enabled = kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
        }




        private void _LoadData()
        {
            try
            {
                gvBangCong.DataSource = _BangCong.GetListDTOs();
                gvDataBangCong.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        void SaveData()
        {
            //try
            //{
            FunctionUI _fun = new FunctionUI();
            if (_them)
            {
                BangCongDTO dt = new BangCongDTO();
                dt.MABC = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text);
                dt.THANG = int.Parse(cboThang.Text);
                dt.NAM = int.Parse(cboNam.Text);
                dt.MACN = int.Parse(slkChiNhanh.EditValue.ToString());
                dt.TRANGTHAI = chkTrangThai.Checked;
                dt.KHOA = chkKhoa.Checked;
                dt.NGAYCONGTRONGTHANG = _BangCong.demSoNgayLamViecTrongThang(int.Parse(cboThang.Text), int.Parse(cboNam.Text));
                _BangCong.AddItemDTO(dt);
                MessageBox.Show("thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _LoadData();
            }
            else
            {
                BangCongDTO dt = new BangCongDTO();
                dt.MABC = _id;
                dt.THANG = int.Parse(cboThang.Text);
                dt.NAM = int.Parse(cboNam.Text);
                dt.MACN = int.Parse(slkChiNhanh.EditValue.ToString());
                dt.TRANGTHAI = chkTrangThai.Checked;
                dt.KHOA = chkKhoa.Checked;
                dt.NGAYCONGTRONGTHANG = _BangCong.demSoNgayLamViecTrongThang(int.Parse(cboThang.Text), int.Parse(cboNam.Text));
                _BangCong.UpdateItem(dt);
                MessageBox.Show("sửa thành công " + dt.MACN + dt.MABC, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _LoadData();

            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        void _ClearInput()
        {
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            slkChiNhanh.Focus();
            _ClearInput();
            _ShowHide(false);
        }


        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _ShowHide(true);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_id == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _BangCong.DeleteItem(_id);
                    _LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex.Message);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData(); _them = false; _ShowHide(false);
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



        private void gvBangCong_Click(object sender, EventArgs e)
        {
            if (gvDataBangCong.RowCount > 0)
            {
                _id = Convert.ToInt32(gvDataBangCong.GetFocusedRowCellValue("MABC"));
                cboThang.Text = gvDataBangCong.GetFocusedRowCellValue("THANG").ToString();
                cboNam.Text = gvDataBangCong.GetFocusedRowCellValue("NAM").ToString();
                chkKhoa.Checked = Convert.ToBoolean(gvDataBangCong.GetFocusedRowCellValue("KHOA"));
                chkTrangThai.Checked = Convert.ToBoolean(gvDataBangCong.GetFocusedRowCellValue("TRANGTHAI"));
            }
        }
    }
}
