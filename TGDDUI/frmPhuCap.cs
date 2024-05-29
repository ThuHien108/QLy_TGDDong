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
    public partial class frmPhuCap : DevExpress.XtraEditors.XtraForm
    {

        PhuCapBLL _phuCap;
        bool _them;
        int _id;

        public frmPhuCap()
        {
            InitializeComponent();
        }

        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            _phuCap = new PhuCapBLL();
            _LoadData();
            _them = false;
            _ShowHide(true);
            spSoTien.Text = "1";
        }



        private void btnThemExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void _LoadData()
        {
            try
            {
                gvPhuCap.DataSource = _phuCap.GetListDTOs();
                gvDataPhuCap.OptionsBehavior.Editable = false;
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
            spSoTien.Enabled = !kt;
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
                        PhuCapDTO dt = new PhuCapDTO();
                        dt.TENPHUCAP = ten;
                        dt.SOTIEN = double.Parse(spSoTien.Value.ToString());

                        _phuCap.AddItem(dt);
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
                        PhuCapDTO dt = new PhuCapDTO();
                        dt.MAPC = _id;
                        dt.TENPHUCAP = ten;
                        dt.SOTIEN = double.Parse(spSoTien.Text.ToString());

                        _phuCap.UpdateItem(dt);
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
            spSoTien.Text = "1";
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
                    _phuCap.DeleteItem(_id);
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
                if (gvDataPhuCap.RowCount > 0)
                {
                    _id = int.Parse(gvDataPhuCap.GetFocusedRowCellValue("MAPC").ToString());
                    txtTen.Text = gvDataPhuCap.GetFocusedRowCellValue("TENPHUCAP").ToString();
                    spSoTien.Text = gvDataPhuCap.GetFocusedRowCellValue("SOTIEN").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}