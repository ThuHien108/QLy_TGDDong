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
    public partial class frmPhuCapNhanVien : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBLL _nhanVien;
        PhuCapBLL _phuCap;
        PhuCapNhanVienBLL _phuCapNhanVien;
        bool _them;
        int _id;
        int _idNV;
        public frmPhuCapNhanVien()
        {
            InitializeComponent();
        }

        private void frmPhuCapNhanVien_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
            _phuCap = new PhuCapBLL();
            _phuCapNhanVien = new PhuCapNhanVienBLL();
            LoadSLK();
            _them = false;
            _ShowHide(true);
            _LoadData();
        }

        void LoadSLK()
        {
            var nv = _nhanVien.GetListDTOs();
            slkNhanVien.Properties.DataSource = nv;
            slkNhanVien.Properties.ValueMember = "MANV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
            slkNhanVien.EditValue = nv.First().MANV;

            var pc = _phuCap.GetListDTOs();
            slkPhuCap.Properties.DataSource = _phuCap.GetListDTOs();
            slkPhuCap.Properties.ValueMember = "MAPC";
            slkPhuCap.Properties.DisplayMember = "TENPHUCAP";
            slkPhuCap.EditValue = pc.First().MAPC;
        }

        private void slkPhuCap_EditValueChanged(object sender, EventArgs e)
        {
            var pc = _phuCap.GetItemDTO(Convert.ToInt32(slkPhuCap.EditValue));
            spSoTien.Text = pc.SOTIEN.ToString();
        }
        private void btnThemExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void _LoadData()
        {
            try
            {
                gvPhuCapNV.DataSource = _phuCapNhanVien.GetListDTOs();
                gvDataPhuCapNV.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void _ShowHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            slkPhuCap.Enabled = !kt;
            txtNoiDung.Enabled = !kt;
            spSoTien.Enabled = !kt;
            btnThemExcel.Enabled = kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
        }
        private void _SaveData()
        {
            //try
            //{
            if (_them)
            {
                PhuCapNhanVienDTO item = new PhuCapNhanVienDTO
                {
                    MANV = int.Parse(slkNhanVien.EditValue.ToString()),
                    MAPC = int.Parse(slkPhuCap.EditValue.ToString()),
                    SOTIEN = double.Parse(spSoTien.Value.ToString()),
                    NGAY = DateTime.Now,
                    NOIDUNG = txtNoiDung.Text,
                };
                _phuCapNhanVien.AddItemDTO(item);
                _LoadData();
            }
            else
            {
                PhuCapNhanVienDTO item = new PhuCapNhanVienDTO
                {
                    MANV = int.Parse(slkNhanVien.EditValue.ToString()),
                    MAPC = int.Parse(slkPhuCap.EditValue.ToString()),
                    SOTIEN = double.Parse(spSoTien.Value.ToString()),
                    NGAY = DateTime.Now,
                    NOIDUNG = txtNoiDung.Text,
                };
                _phuCapNhanVien.UpdateItem(item);
                _LoadData();
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
        }
        void _ClearInput()
        {

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            slkNhanVien.Focus();
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
                    _phuCapNhanVien.DeleteItem(_id);
                    _LoadData();
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
            _ClearInput();
            _ShowHide(true);

        }
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ShowHide(true);
            _ClearInput();
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gvPhuCap_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDataPhuCapNV.RowCount > 0)
                {
                    _id = int.Parse(gvDataPhuCapNV.GetFocusedRowCellValue("MAPCNV").ToString());
                    var item = _phuCapNhanVien.GetItemDTO(_id);
                    slkNhanVien.EditValue = item.MANV;
                    slkPhuCap.EditValue = item.MAPC;
                    spSoTien.EditValue = item.MAPC;
                    txtNoiDung.EditValue = item.NOIDUNG;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


    }
}