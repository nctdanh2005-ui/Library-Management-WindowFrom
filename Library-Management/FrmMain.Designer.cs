namespace Library_Management
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChonMauNen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChonPhonChu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatLaiGiaoDien = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocGia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMuonTra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinhHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDongTatCa = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTenThuVien = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPhanCach = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDongHo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerDongHo = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanLy,
            this.mnuQuanTri,
            this.mnuCuaSo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.mnuCuaSo;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.toolStripSeparator1,
            this.mnuChonMauNen,
            this.mnuChonPhonChu,
            this.mnuDatLaiGiaoDien,
            this.toolStripSeparator3,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(79, 23);
            this.mnuHeThong.Text = "&Hệ thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuDangXuat.Size = new System.Drawing.Size(193, 24);
            this.mnuDangXuat.Text = "Đăng &xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(193, 24);
            this.mnuThoat.Text = "&Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuChonMauNen
            // 
            this.mnuChonMauNen.Name = "mnuChonMauNen";
            this.mnuChonMauNen.Size = new System.Drawing.Size(193, 24);
            this.mnuChonMauNen.Text = "Chọn &màu nền...";
            this.mnuChonMauNen.Click += new System.EventHandler(this.mnuChonMauNen_Click);
            // 
            // mnuChonPhonChu
            // 
            this.mnuChonPhonChu.Name = "mnuChonPhonChu";
            this.mnuChonPhonChu.Size = new System.Drawing.Size(193, 24);
            this.mnuChonPhonChu.Text = "Chọn &phông chữ...";
            this.mnuChonPhonChu.Click += new System.EventHandler(this.mnuChonPhonChu_Click);
            // 
            // mnuDatLaiGiaoDien
            // 
            this.mnuDatLaiGiaoDien.Name = "mnuDatLaiGiaoDien";
            this.mnuDatLaiGiaoDien.Size = new System.Drawing.Size(193, 24);
            this.mnuDatLaiGiaoDien.Text = "Đặt lại giao diện &mặc định";
            this.mnuDatLaiGiaoDien.Click += new System.EventHandler(this.mnuDatLaiGiaoDien_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuQuanLy
            // 
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSach,
            this.mnuDocGia,
            this.mnuMuonTra});
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new System.Drawing.Size(70, 23);
            this.mnuQuanLy.Text = "&Quản lý";
            // 
            // mnuSach
            // 
            this.mnuSach.Name = "mnuSach";
            this.mnuSach.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSach.Size = new System.Drawing.Size(256, 24);
            this.mnuSach.Text = "Quản lý &Sách (SV1)";
            this.mnuSach.Click += new System.EventHandler(this.mnuSach_Click);
            // 
            // mnuDocGia
            // 
            this.mnuDocGia.Name = "mnuDocGia";
            this.mnuDocGia.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDocGia.Size = new System.Drawing.Size(256, 24);
            this.mnuDocGia.Text = "Quản lý &Độc giả (SV2)";
            this.mnuDocGia.Click += new System.EventHandler(this.mnuDocGia_Click);
            // 
            // mnuMuonTra
            // 
            this.mnuMuonTra.Name = "mnuMuonTra";
            this.mnuMuonTra.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuMuonTra.Size = new System.Drawing.Size(256, 24);
            this.mnuMuonTra.Text = "&Mượn - Trả sách (SV3)";
            this.mnuMuonTra.Click += new System.EventHandler(this.mnuMuonTra_Click);
            // 
            // mnuQuanTri
            // 
            this.mnuQuanTri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCauHinhHeThong});
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(130, 23);
            this.mnuQuanTri.Text = "Quản &trị hệ thống";
            // 
            // mnuCauHinhHeThong
            // 
            this.mnuCauHinhHeThong.Name = "mnuCauHinhHeThong";
            this.mnuCauHinhHeThong.Size = new System.Drawing.Size(225, 24);
            this.mnuCauHinhHeThong.Text = "Cấu hình & phân quyền";
            this.mnuCauHinhHeThong.Click += new System.EventHandler(this.mnuCauHinhHeThong_Click);
            // 
            // mnuCuaSo
            // 
            this.mnuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.toolStripSeparator2,
            this.mnuDongTatCa});
            this.mnuCuaSo.Name = "mnuCuaSo";
            this.mnuCuaSo.Size = new System.Drawing.Size(65, 23);
            this.mnuCuaSo.Text = "&Cửa sổ";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(206, 24);
            this.mnuCascade.Text = "Sắp xếp theo &Tầng";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
            // 
            // mnuTileHorizontal
            // 
            this.mnuTileHorizontal.Name = "mnuTileHorizontal";
            this.mnuTileHorizontal.Size = new System.Drawing.Size(206, 24);
            this.mnuTileHorizontal.Text = "Sắp xếp theo &Ngang";
            this.mnuTileHorizontal.Click += new System.EventHandler(this.mnuTileHorizontal_Click);
            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(206, 24);
            this.mnuTileVertical.Text = "Sắp xếp theo &Dọc";
            this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuDongTatCa
            // 
            this.mnuDongTatCa.Name = "mnuDongTatCa";
            this.mnuDongTatCa.Size = new System.Drawing.Size(206, 24);
            this.mnuDongTatCa.Text = "Đó&ng tất cả cửa sổ";
            this.mnuDongTatCa.Click += new System.EventHandler(this.mnuDongTatCa_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTenThuVien,
            this.lblPhanCach,
            this.lblNguoiDung,
            this.lblSpring,
            this.lblDongHo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 699);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTenThuVien
            // 
            this.lblTenThuVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenThuVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTenThuVien.Name = "lblTenThuVien";
            this.lblTenThuVien.Size = new System.Drawing.Size(117, 17);
            this.lblTenThuVien.Text = "Thư viện Đại học";
            // 
            // lblPhanCach
            // 
            this.lblPhanCach.Name = "lblPhanCach";
            this.lblPhanCach.Size = new System.Drawing.Size(11, 17);
            this.lblPhanCach.Text = "|";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(161, 17);
            this.lblNguoiDung.Text = "Người dùng: Chưa xác định";
            // 
            // lblSpring
            // 
            this.lblSpring.Name = "lblSpring";
            this.lblSpring.Size = new System.Drawing.Size(567, 17);
            this.lblSpring.Spring = true;
            // 
            // lblDongHo
            // 
            this.lblDongHo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDongHo.Name = "lblDongHo";
            this.lblDongHo.Size = new System.Drawing.Size(137, 17);
            this.lblDongHo.Text = "00/00/0000 00:00:00";
            // 
            // timerDongHo
            // 
            this.timerDongHo.Enabled = true;
            this.timerDongHo.Interval = 1000;
            this.timerDongHo.Tick += new System.EventHandler(this.timerDongHo_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 721);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Thư viện Đại học - MDI Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuChonMauNen;
        private System.Windows.Forms.ToolStripMenuItem mnuChonPhonChu;
        private System.Windows.Forms.ToolStripMenuItem mnuDatLaiGiaoDien;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuSach;
        private System.Windows.Forms.ToolStripMenuItem mnuDocGia;
        private System.Windows.Forms.ToolStripMenuItem mnuMuonTra;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinhHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuDongTatCa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTenThuVien;
        private System.Windows.Forms.ToolStripStatusLabel lblPhanCach;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel lblSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblDongHo;
        private System.Windows.Forms.Timer timerDongHo;
    }
}

