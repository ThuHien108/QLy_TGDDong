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
    public partial class frmPhongBan : DevExpress.XtraEditors.XtraForm
    {
        PhongBanBLL _phongBan;
        bool _them;
        int _id;
        public frmPhongBan()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            try
            {
                gvPhongBan.DataSource = _phongBan.GetListDTOs();
                gvDataPhongBan.OptionsBehavior.Editable = false;
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
            txtDiaChi.Enabled = !kt;
            txtMail.Enabled = !kt;
            txtSdt.Enabled = !kt;
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
                        PhongBanDTO dt = new PhongBanDTO();
                        dt.TENPB = ten;
                        dt.SDT = txtSdt.Text;
                        dt.DIACHI = txtDiaChi.Text;
                        dt.MAIL = txtMail.Text;
                        _phongBan.AddItem(dt);
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
                        PhongBanDTO dt = new PhongBanDTO();
                        dt.MAPB = _id;
                        dt.TENPB = ten;
                        dt.SDT = txtSdt.Text;
                        dt.DIACHI = txtDiaChi.Text;
                        dt.MAIL = txtMail.Text;
                        _phongBan.UpdateItem(dt);
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
            txtSdt.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMail.Text = string.Empty;
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
                    _phongBan.DeleteItem(_id);
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



        private void gvPhongBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDataPhongBan.RowCount > 0)
                {
                    _id = int.Parse(gvDataPhongBan.GetFocusedRowCellValue("MAPB").ToString());
                    txtTen.Text = gvDataPhongBan.GetFocusedRowCellValue("TENPB").ToString();
                    txtDiaChi.Text = gvDataPhongBan.GetFocusedRowCellValue("DIACHI").ToString();
                    txtMail.Text = gvDataPhongBan.GetFocusedRowCellValue("MAIL").ToString();
                    txtSdt.Text = gvDataPhongBan.GetFocusedRowCellValue("SDT").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {

            _phongBan = new PhongBanBLL();
            _LoadData();
            _them = false;
            _ShowHide(true);
        }
    }
}