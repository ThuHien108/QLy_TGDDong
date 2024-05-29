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
    public partial class frmChucVu : DevExpress.XtraEditors.XtraForm
    {
        ChucVuBLL _chucVu;
        bool _them;
        int _id;
        public frmChucVu()
        {
            InitializeComponent();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            _chucVu = new ChucVuBLL();
            _LoadData();
            _them = false;
            _ShowHide(true);
        }



        private void _LoadData()
        {
            try
            {
                gvChucVu.DataSource = _chucVu.GetListDTOs();
                gvDataChucVu.OptionsBehavior.Editable = false;
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
                        ChucVuDTO dt = new ChucVuDTO();
                        dt.TENCV = ten;

                        _chucVu.AddItem(dt);
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
                        ChucVuDTO dt = new ChucVuDTO();
                        dt.MACV = _id;
                        dt.TENCV = ten;

                        _chucVu.UpdateItem(dt);
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
                    _chucVu.DeleteItem(_id);
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



        private void gvChucVu_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDataChucVu.RowCount > 0)
                {
                    _id = int.Parse(gvDataChucVu.GetFocusedRowCellValue("MACV").ToString());
                    txtTen.Text = gvDataChucVu.GetFocusedRowCellValue("TENCV").ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


    }
}