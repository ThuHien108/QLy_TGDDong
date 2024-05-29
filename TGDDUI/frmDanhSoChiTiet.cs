using BLL;
using DevExpress.XtraEditors;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGDDUI
{
    public partial class frmDanhSoChiTiet : DevExpress.XtraEditors.XtraForm
    {
        SanPhamBLL _sanPham;
        DanhSoChiTietBLL _danhSoChiTiet;
        bool _them;
        public string _ID;
        public string _tenNhanVien;
        int _iddsct;
        public frmDanhSoChiTiet()
        {
            InitializeComponent();
        }
        void LoadSLK()
        {
            var sp = _sanPham.GetListDTOs();
            slkSanPham.Properties.DataSource = sp;
            slkSanPham.Properties.ValueMember = "MASP";
            slkSanPham.Properties.DisplayMember = "TENSP";
            slkSanPham.EditValue = sp.First().MASP;
        }
        private void frmDanhSoChiTiet_Load(object sender, EventArgs e)
        {
            _sanPham = new SanPhamBLL();
            _danhSoChiTiet = new DanhSoChiTietBLL();
            LoadSLK();
            _LoadData();
            dateNgay.DateTime = DateTime.Now;
            this.Text = "Danh số chi tiết - " + _ID;
            barHeaderItemDS.Caption = "Danh số chi tiết - " + _ID;
            _ShowHide(true);
        }

        private void _LoadData()
        {
            try
            {
                gvDsChiTiet.DataSource = _danhSoChiTiet.GetListDTOs();
                gvDataDsChiTiet.OptionsBehavior.Editable = false;
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
            slkSanPham.Enabled = !kt;
            dateNgay.Enabled = !kt;
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
                DanhSoChiTietDTO item = new DanhSoChiTietDTO
                {
                    MASP = int.Parse(slkSanPham.EditValue.ToString()),
                    MADS = _ID,
                    NGAY = dateNgay.DateTime,
                    GHICHU = txtNoiDung.Text,
                };
                _danhSoChiTiet.AddItemDTO(item);
                _LoadData();
            }
            else
            {
                DanhSoChiTietDTO item = new DanhSoChiTietDTO
                {
                    MADSCT = _iddsct,
                    MASP = int.Parse(slkSanPham.EditValue.ToString()),
                    MADS = _ID,
                    NGAY = dateNgay.DateTime,
                    GHICHU = txtNoiDung.Text,
                };
                _danhSoChiTiet.UpdateItem(item);
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
            slkSanPham.Focus();
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
                if (_iddsct == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _danhSoChiTiet.DeleteItem(_iddsct);
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

        private void slkSanPham_EditValueChanged(object sender, EventArgs e)
        {
            spSoTien.Value = (decimal)_sanPham.GetItemDTO(int.Parse(slkSanPham.EditValue.ToString())).GIA;
        }
    }
}