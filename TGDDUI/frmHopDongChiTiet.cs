using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
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
    public partial class frmHopDongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        private NhanVienBLL _nhanVien;
        private HopDongBLL _hopDong;
        public bool _them;
        public string _soHD;
        private frmHopDongChiTiet _frmHopDong;
        public frmHopDongChiTiet()
        {
            InitializeComponent();
        }

        private void frmHopDongChiTiet_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
            _hopDong = new HopDongBLL();
            _LoadDataSlkNV();
            dateNgayKy.DateTime = DateTime.Now;
            dateNgayBatDau.DateTime = DateTime.Now;
            dateNgayKetThuc.DateTime = dateNgayBatDau.DateTime.AddMonths(3);
            spHeSo.Value = 1;
            _frmHopDong = (frmHopDongChiTiet)Application.OpenForms["frmHopDongChiTiet"];
            if (_soHD != null)
            {
                _LoadData();
                lbSoHD.Text = "SHD: " + _soHD;
            }
        }

        private void _LoadDataSlkNV()
        {
            var nv = _nhanVien.GetListDTOs();
            slkNhanVien.Properties.DataSource = nv;
            slkNhanVien.Properties.DisplayMember = "HOTEN";
            slkNhanVien.Properties.ValueMember = "MANV";
            slkNhanVien.EditValue = nv.First().MANV;
        }

        private void cboThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThoiGian.Text.ToLower().Contains("3"))
            {
                dateNgayKy.DateTime = DateTime.Now;
                dateNgayBatDau.DateTime = DateTime.Now;
                dateNgayKetThuc.DateTime = dateNgayBatDau.DateTime.AddMonths(3);
            }
            if (cboThoiGian.Text.ToLower().Contains("6"))
            {
                dateNgayKy.DateTime = DateTime.Now;
                dateNgayBatDau.DateTime = DateTime.Now;
                dateNgayKetThuc.DateTime = dateNgayBatDau.DateTime.AddMonths(6);
            }
            if (cboThoiGian.Text.ToLower().Contains("12"))
            {
                dateNgayKy.DateTime = DateTime.Now;
                dateNgayBatDau.DateTime = DateTime.Now;
                dateNgayKetThuc.DateTime = dateNgayBatDau.DateTime.AddMonths(12);
            }
        }

        private void _SaveData()
        {
            try
            {
                if (_them)
                {
                    HopDongDTO dt = new HopDongDTO();
                    dt.SOHD = _hopDong.SoHopDong();
                    dt.NGAYBATDAU = dateNgayBatDau.DateTime;
                    dt.NGAYKETTHUC = dateNgayKetThuc.DateTime;
                    dt.NGAYKY = dateNgayKy.DateTime;
                    dt.THOIGIAN = cboThoiGian.Text;
                    dt.HESOLUONG = double.Parse(spHeSo.EditValue.ToString());
                    dt.LANKY = int.Parse(spLanKy.EditValue.ToString());
                    dt.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                    dt.NOIDUNG = recHopDong.RtfText;
                    _hopDong.AddItemDTO(dt);
                    MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var dt = _hopDong.GetItemDTO(_soHD);
                    dt.SOHD = _hopDong.SoHopDong();
                    dt.NGAYBATDAU = dateNgayBatDau.DateTime;
                    dt.NGAYKETTHUC = dateNgayKetThuc.DateTime;
                    dt.NGAYKY = dateNgayKy.DateTime;
                    dt.THOIGIAN = cboThoiGian.Text;
                    dt.HESOLUONG = double.Parse(spHeSo.EditValue.ToString());
                    dt.LANKY = int.Parse(spLanKy.EditValue.ToString());
                    dt.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                    dt.NOIDUNG = recHopDong.RtfText;
                    MessageBox.Show("Sửa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _hopDong.UpdateItem(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _LoadData()
        {
            try
            {
                var hd = _hopDong.GetItemDTO(_soHD);
                lbSoHD.Text = _soHD;
                dateNgayBatDau.DateTime = hd.NGAYBATDAU.Value;
                dateNgayBatDau.DateTime = hd.NGAYKETTHUC.Value;
                dateNgayKy.DateTime = hd.NGAYKY.Value;
                spHeSo.Text = hd.HESOLUONG.ToString();
                spLanKy.Text = hd.LANKY.ToString();
                recHopDong.RtfText = hd.NOIDUNG.ToString();
                slkNhanVien.EditValue = hd.MANV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveData();
        }
    }
}