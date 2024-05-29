namespace TGDDUI
{
    partial class frmQuanLyChung
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyChung));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnChiNhanh = new DevExpress.XtraBars.BarButtonItem();
            this.btnChucVu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhongBan = new DevExpress.XtraBars.BarButtonItem();
            this.btSanPham = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoaiCong = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhuCap = new DevExpress.XtraBars.BarButtonItem();
            this.btnTest = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnHopDong = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhuCapNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnBangCong = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.btnDanhSo = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnChiNhanh,
            this.btnChucVu,
            this.btnPhongBan,
            this.btSanPham,
            this.btnLoaiCong,
            this.btnPhuCap,
            this.btnTest,
            this.btnNhanVien,
            this.btnHopDong,
            this.btnPhuCapNhanVien,
            this.btnBangCong,
            this.barButtonItem1,
            this.btnDanhSo});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1091, 170);
            // 
            // btnChiNhanh
            // 
            this.btnChiNhanh.Caption = "Chi nhánh";
            this.btnChiNhanh.Id = 1;
            this.btnChiNhanh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChiNhanh.ImageOptions.SvgImage")));
            this.btnChiNhanh.Name = "btnChiNhanh";
            this.btnChiNhanh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChiNhanh_ItemClick);
            // 
            // btnChucVu
            // 
            this.btnChucVu.Caption = "Chức vụ";
            this.btnChucVu.Id = 2;
            this.btnChucVu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChucVu.ImageOptions.SvgImage")));
            this.btnChucVu.Name = "btnChucVu";
            this.btnChucVu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChucVu_ItemClick);
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.Caption = "Phòng ban";
            this.btnPhongBan.Id = 3;
            this.btnPhongBan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhongBan.ImageOptions.SvgImage")));
            this.btnPhongBan.Name = "btnPhongBan";
            this.btnPhongBan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhongBan_ItemClick);
            // 
            // btSanPham
            // 
            this.btSanPham.Caption = "Sản phẩm";
            this.btSanPham.Id = 4;
            this.btSanPham.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btSanPham.ImageOptions.SvgImage")));
            this.btSanPham.Name = "btSanPham";
            this.btSanPham.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btSanPham_ItemClick);
            // 
            // btnLoaiCong
            // 
            this.btnLoaiCong.Caption = "Loại Công";
            this.btnLoaiCong.Id = 5;
            this.btnLoaiCong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLoaiCong.ImageOptions.SvgImage")));
            this.btnLoaiCong.Name = "btnLoaiCong";
            this.btnLoaiCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnPhuCap
            // 
            this.btnPhuCap.Caption = "Phụ Cấp";
            this.btnPhuCap.Id = 6;
            this.btnPhuCap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhuCap.ImageOptions.SvgImage")));
            this.btnPhuCap.Name = "btnPhuCap";
            this.btnPhuCap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhuCap_ItemClick);
            // 
            // btnTest
            // 
            this.btnTest.Caption = "Kiểm tra";
            this.btnTest.Id = 7;
            this.btnTest.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTest.ImageOptions.SvgImage")));
            this.btnTest.Name = "btnTest";
            this.btnTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTest_ItemClick);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Caption = "Nhân Viên";
            this.btnNhanVien.Id = 8;
            this.btnNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNhanVien.ImageOptions.SvgImage")));
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhanVien_ItemClick);
            // 
            // btnHopDong
            // 
            this.btnHopDong.Caption = "Hợp đồng";
            this.btnHopDong.Id = 9;
            this.btnHopDong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHopDong.ImageOptions.SvgImage")));
            this.btnHopDong.Name = "btnHopDong";
            this.btnHopDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHopDong_ItemClick);
            // 
            // btnPhuCapNhanVien
            // 
            this.btnPhuCapNhanVien.Caption = "Phụ Cấp Nhân Viên";
            this.btnPhuCapNhanVien.Id = 10;
            this.btnPhuCapNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhuCapNhanVien.ImageOptions.SvgImage")));
            this.btnPhuCapNhanVien.Name = "btnPhuCapNhanVien";
            this.btnPhuCapNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhuCapNhanVien_ItemClick);
            // 
            // btnBangCong
            // 
            this.btnBangCong.Caption = "Bảng Công";
            this.btnBangCong.Id = 11;
            this.btnBangCong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBangCong.ImageOptions.SvgImage")));
            this.btnBangCong.Name = "btnBangCong";
            this.btnBangCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBangCong_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Nhân sự";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnChiNhanh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnChucVu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPhongBan);
            this.ribbonPageGroup1.ItemLinks.Add(this.btSanPham);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLoaiCong);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPhuCap);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhanVien);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnHopDong);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPhuCapNhanVien);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBangCong);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Danh mục chung";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTest);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDanhSo);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // btnDanhSo
            // 
            this.btnDanhSo.Caption = "Danh Số";
            this.btnDanhSo.Id = 13;
            this.btnDanhSo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.btnDanhSo.Name = "btnDanhSo";
            this.btnDanhSo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDanhSo_ItemClick);
            // 
            // frmQuanLyChung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 741);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmQuanLyChung";
            this.Ribbon = this.ribbonControl1;
            this.Text = "QUẢN LÝ LƯƠNG NHÂN VIÊN - THẾ GIỚI DI ĐỘNG";
            this.Load += new System.EventHandler(this.frmQuanLyChung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnChiNhanh;
        private DevExpress.XtraBars.BarButtonItem btnChucVu;
        private DevExpress.XtraBars.BarButtonItem btnPhongBan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btSanPham;
        private DevExpress.XtraBars.BarButtonItem btnLoaiCong;
        private DevExpress.XtraBars.BarButtonItem btnPhuCap;
        private DevExpress.XtraBars.BarButtonItem btnTest;
        private DevExpress.XtraBars.BarButtonItem btnNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnHopDong;
        private DevExpress.XtraBars.BarButtonItem btnPhuCapNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnBangCong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnDanhSo;
    }
}

