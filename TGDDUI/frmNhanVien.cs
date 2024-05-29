using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Filtering.Templates;
using DevExpress.XtraReports.UI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TGDDUI
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBLL _nhanVien;
        ChiNhanhBLL _chiNhanh;
        PhongBanBLL _phongBan;
        ChucVuBLL _chucVu;
        bool _them;
        int _id;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void _ShowHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            layoutGThongTinNhanVien.Enabled = !kt;
            layoutGGioiTinh.Enabled = !kt;
            LayoutGHinhAnh.Enabled = !kt;
            layoutGthongTinLienHe.Enabled = !kt;

            btnThemExcel.Enabled = kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
            _chiNhanh = new ChiNhanhBLL();
            _phongBan = new PhongBanBLL();
            _chucVu = new ChucVuBLL();
            dateNgaySinh.Text = DateTime.Now.ToString("MM/dd/yyyy");
            _LoadDataSLK();
            _LoadData();
            _them = false;
            _ShowHide(true);
        }
        void _LoadDataSLK()
        {
            var cn = _chiNhanh.GetListDTOs();
            slkCN.Properties.DataSource = cn;
            slkCN.Properties.ValueMember = "MACN";
            slkCN.Properties.DisplayMember = "TENCN";
            slkCN.EditValue = cn.First().MACN;

            var cv = _chucVu.GetListDTOs();
            slkChucVu.Properties.DataSource = cv;
            slkChucVu.Properties.ValueMember = "MACV";
            slkChucVu.Properties.DisplayMember = "TENCV";
            slkChucVu.EditValue = cv.First().MACV;

            var pb = _phongBan.GetListDTOs();
            slkPhongBan.Properties.DataSource = pb;
            slkPhongBan.Properties.ValueMember = "MAPB";
            slkPhongBan.Properties.DisplayMember = "TENPB";
            slkPhongBan.EditValue = pb.First().MAPB;
        }


        private void _LoadData()
        {
            try
            {
                gvNhanVien.DataSource = _nhanVien.GetListDTOs();
                gvDataNhanVien.OptionsBehavior.Editable = false;
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
                NhanVienDTO dt = new NhanVienDTO();
                dt.HOTEN = txtHoten.Text;
                dt.CCCD = txtCccd.Text;
                dt.DIACHI = txtDiaChi.Text;
                dt.DIENTHOAI = txtSdt.Text;
                dt.EMAIL = txtMail.Text;
                dt.NGAYSINH = Convert.ToDateTime(dateNgaySinh.EditValue.ToString());
                dt.GIOITINH = Convert.ToBoolean(rbogGioiTinh.EditValue.ToString());
                dt.HINHANH = _fun.ImageToBase64(pictureHinhAnh.Image, ImageFormat.Png);
                dt.MACN = int.Parse(slkCN.EditValue.ToString());
                dt.MAPB = int.Parse(slkPhongBan.EditValue.ToString());
                dt.MACV = int.Parse(slkChucVu.EditValue.ToString());
                _nhanVien.AddItemDTO(dt);
                MessageBox.Show("thêm thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _LoadData();
            }
            else
            {
                NhanVienDTO dt = new NhanVienDTO();
                dt.MANV = _id;
                dt.HOTEN = txtHoten.Text;
                dt.CCCD = txtCccd.Text;
                dt.DIACHI = txtDiaChi.Text;
                dt.DIENTHOAI = txtSdt.Text;
                dt.EMAIL = txtMail.Text;
                dt.NGAYSINH = Convert.ToDateTime(dateNgaySinh.EditValue.ToString());
                dt.GIOITINH = Convert.ToBoolean(rbogGioiTinh.EditValue.ToString());
                dt.HINHANH = _fun.ImageToBase64(pictureHinhAnh.Image, ImageFormat.Png);
                dt.MACN = Convert.ToInt32(slkCN.EditValue.ToString());
                dt.MAPB = Convert.ToInt32(slkPhongBan.EditValue.ToString());
                dt.MACV = Convert.ToInt32(slkChucVu.EditValue.ToString());
                _nhanVien.UpdateItem(dt);
                MessageBox.Show("sửa thành công " + dt.MACN + dt.MAPB + dt.MACV, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            txtHoten.Text = string.Empty;
            txtCccd.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtSdt.Text = string.Empty;
            dateNgaySinh.Text = DateTime.Now.ToString("MM/dd/yyyy");
            rbogGioiTinh.SelectedIndex = 1;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            txtHoten.Focus();
            _ClearInput();
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
                if (_id == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _nhanVien.DeleteItem(_id);
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

        private void gvNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDataNhanVien.RowCount > 0)
                {
                    _id = int.Parse(gvDataNhanVien.GetFocusedRowCellValue("MANV").ToString());
                    var item = _nhanVien.GetItemDTO(_id);
                    txtHoten.Text = item.HOTEN;
                    txtCccd.Text = item.CCCD;
                    txtDiaChi.Text = item.DIACHI;
                    txtMail.Text = item.EMAIL;
                    txtSdt.Text = item.DIENTHOAI;
                    dateNgaySinh.EditValue = item.NGAYSINH.Value;
                    rbogGioiTinh.SelectedIndex = item.GIOITINH == true ? 0 : 1;
                    slkChucVu.EditValue = item.MACV;
                    pictureHinhAnh.EditValue = item.HINHANH;
                    slkCN.EditValue = item.MACN;
                    slkPhongBan.EditValue = item.MAPB;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}