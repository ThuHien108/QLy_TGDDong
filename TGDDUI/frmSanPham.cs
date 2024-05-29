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
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        SanPhamBLL _sanPham;
        bool _them;
        int _id;
        public frmSanPham()
        {
            InitializeComponent();

        }


        private void frmSanPham_Load(object sender, EventArgs e)
        {
            _sanPham = new SanPhamBLL();
            _LoadData();
            _them = false;
            _ShowHide(true);

        }

        private void _LoadData()
        {
            try
            {
                gvSanPham.DataSource = _sanPham.GetListDTOs();
                gvDataSanPham.OptionsBehavior.Editable = false;
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
            txtTen.Enabled = !kt;
            spGia.Enabled = !kt;
            btnThemExcel.Enabled = kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
        }
        private void _SaveData()
        {
            try
            {
                if (_them)
                {
                    string ten = txtTen.Text;
                    if (ten != null)
                    {
                        SanPhamDTO dt = new SanPhamDTO();
                        dt.TENSP = ten;
                        dt.GIA = double.Parse(spGia.Value.ToString());

                        _sanPham.AddItem(dt);
                        _LoadData();
                    }
                }
                else
                {
                    string ten = txtTen.Text;
                    if (_id == null)
                    {
                        MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                    }
                    else
                    if (ten != null)
                    {
                        SanPhamDTO dt = new SanPhamDTO();
                        dt.MASP = _id;
                        dt.TENSP = ten;
                        dt.GIA = double.Parse(spGia.Text.ToString());

                        _sanPham.UpdateItem(dt);
                        _LoadData();
                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        void _ClearInput()
        {
            txtTen.Text = string.Empty;
            spGia.Text = "0";
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            txtTen.Focus();
            _ShowHide(false);
            _ClearInput();
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
                    _sanPham.DeleteItem(_id);
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
            _SaveData();
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



        private void gvSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDataSanPham.RowCount > 0)
                {
                    _id = int.Parse(gvDataSanPham.GetFocusedRowCellValue("MASP").ToString());
                    txtTen.Text = gvDataSanPham.GetFocusedRowCellValue("TENSP").ToString();
                    spGia.Text = gvDataSanPham.GetFocusedRowCellValue("GIA").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


    }
}