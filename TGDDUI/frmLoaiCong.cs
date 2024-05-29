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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TGDDUI
{
    public partial class frmLoaiCong : DevExpress.XtraEditors.XtraForm
    {

        LoaiCongBLL _loaiCong;
        bool _them;
        int _id;

        public frmLoaiCong()
        {
            InitializeComponent();
        }

        private void frmLoaiCong_Load(object sender, EventArgs e)
        {
            _loaiCong = new LoaiCongBLL();
            _LoadData();
            _them = false;
            _ShowHide(true);
            spHeSo.Text = "1";
        }



        private void btnThemExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void _LoadData()
        {
            try
            {
                gvLoaiCong.DataSource = _loaiCong.GetListDTOs();
                gvDataLoaiCong.OptionsBehavior.Editable = false;
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
            spHeSo.Enabled = !kt;
            txtKyHieu.Enabled = !kt;
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
                        LoaiCongDTO dt = new LoaiCongDTO();
                        dt.TENLC = ten;
                        dt.HESO = double.Parse(spHeSo.Value.ToString());
                        dt.KYHIEU = txtKyHieu.Text;
                        _loaiCong.AddItem(dt);
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
                        LoaiCongDTO dt = new LoaiCongDTO();
                        dt.MALC = _id;
                        dt.TENLC = ten;
                        dt.KYHIEU = txtKyHieu.Text;
                        dt.HESO = double.Parse(spHeSo.Text.ToString());

                        _loaiCong.UpdateItem(dt);
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
            spHeSo.Text = "1";
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
                    _loaiCong.DeleteItem(_id);
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



        private void gvLoaiCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDataLoaiCong.RowCount > 0)
                {
                    _id = int.Parse(gvDataLoaiCong.GetFocusedRowCellValue("MALC").ToString());
                    txtTen.Text = gvDataLoaiCong.GetFocusedRowCellValue("TENLC").ToString();
                    txtKyHieu.Text = gvDataLoaiCong.GetFocusedRowCellValue("KYHIEU").ToString();
                    spHeSo.Text = gvDataLoaiCong.GetFocusedRowCellValue("HESO").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}