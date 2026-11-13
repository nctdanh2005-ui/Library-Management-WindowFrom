namespace Library_Management
{
    partial class FrmMuonTra
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
            this.pnlTrai = new System.Windows.Forms.Panel();
            this.grpThaoTac = new System.Windows.Forms.GroupBox();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnDatTruoc = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.btnXuatCSV = new System.Windows.Forms.Button();
            this.btnXoaPhieu = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.lblGoiNgayTra = new System.Windows.Forms.Label();
            this.txtNgayTra = new System.Windows.Forms.TextBox();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.lblGoiHanTra = new System.Windows.Forms.Label();
            this.txtHanTra = new System.Windows.Forms.TextBox();
            this.lblHanTra = new System.Windows.Forms.Label();
            this.lblGoiNgayMuon = new System.Windows.Forms.Label();
            this.txtNgayMuon = new System.Windows.Forms.TextBox();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.lblSach = new System.Windows.Forms.Label();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.lblDocGia = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.pnlPhai = new System.Windows.Forms.Panel();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lvPhieuMuon = new System.Windows.Forms.ListView();
            this.colSoPhieu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDocGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayMuon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHanTra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayTra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTienPhat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.lblChuThich = new System.Windows.Forms.Label();
            this.pnlTrai.SuspendLayout();
            this.grpThaoTac.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.pnlPhai.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTrai
            // 
            this.pnlTrai.Controls.Add(this.grpThaoTac);
            this.pnlTrai.Controls.Add(this.grpThongTin);
            this.pnlTrai.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTrai.Location = new System.Drawing.Point(0, 0);
            this.pnlTrai.Name = "pnlTrai";
            this.pnlTrai.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTrai.Size = new System.Drawing.Size(340, 681);
            this.pnlTrai.TabIndex = 0;
            // 
            // grpThaoTac
            // 
            this.grpThaoTac.Controls.Add(this.lblThongKe);
            this.grpThaoTac.Controls.Add(this.btnBaoCao);
            this.grpThaoTac.Controls.Add(this.btnDatTruoc);
            this.grpThaoTac.Controls.Add(this.btnLamMoi);
            this.grpThaoTac.Controls.Add(this.btnInPhieu);
            this.grpThaoTac.Controls.Add(this.btnXuatCSV);
            this.grpThaoTac.Controls.Add(this.btnXoaPhieu);
            this.grpThaoTac.Controls.Add(this.btnTraSach);
            this.grpThaoTac.Controls.Add(this.btnLapPhieu);
            this.grpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThaoTac.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThaoTac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpThaoTac.Location = new System.Drawing.Point(8, 283);
            this.grpThaoTac.Name = "grpThaoTac";
            this.grpThaoTac.Size = new System.Drawing.Size(324, 390);
            this.grpThaoTac.TabIndex = 1;
            this.grpThaoTac.TabStop = false;
            this.grpThaoTac.Text = "THAO TÁC MƯỢN - TRẢ";
            // 
            // lblThongKe
            // 
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblThongKe.Location = new System.Drawing.Point(10, 195);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(305, 80);
            this.lblThongKe.TabIndex = 8;
            this.lblThongKe.Text = "Tổng số phiếu: 0\r\nĐang mượn: 0   |   Quá hạn: 0\r\nPhạt đã thu: 0 đ\r\nPhạt quá hạn c" +
    "hưa thu: 0 đ";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.Location = new System.Drawing.Point(10, 148);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(145, 34);
            this.btnBaoCao.TabIndex = 10;
            this.btnBaoCao.Text = "📊 Thống kê / BC";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnDatTruoc
            // 
            this.btnDatTruoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnDatTruoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatTruoc.FlatAppearance.BorderSize = 0;
            this.btnDatTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatTruoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDatTruoc.ForeColor = System.Drawing.Color.White;
            this.btnDatTruoc.Location = new System.Drawing.Point(165, 68);
            this.btnDatTruoc.Name = "btnDatTruoc";
            this.btnDatTruoc.Size = new System.Drawing.Size(145, 34);
            this.btnDatTruoc.TabIndex = 9;
            this.btnDatTruoc.Text = "📌 Đặt trước sách";
            this.btnDatTruoc.UseVisualStyleBackColor = false;
            this.btnDatTruoc.Click += new System.EventHandler(this.btnDatTruoc_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(165, 148);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(145, 34);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnInPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInPhieu.FlatAppearance.BorderSize = 0;
            this.btnInPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnInPhieu.ForeColor = System.Drawing.Color.White;
            this.btnInPhieu.Location = new System.Drawing.Point(165, 108);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(145, 34);
            this.btnInPhieu.TabIndex = 5;
            this.btnInPhieu.Text = "🖨️ In phiếu .txt";
            this.btnInPhieu.UseVisualStyleBackColor = false;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXuatCSV
            // 
            this.btnXuatCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnXuatCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatCSV.FlatAppearance.BorderSize = 0;
            this.btnXuatCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatCSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatCSV.ForeColor = System.Drawing.Color.White;
            this.btnXuatCSV.Location = new System.Drawing.Point(10, 108);
            this.btnXuatCSV.Name = "btnXuatCSV";
            this.btnXuatCSV.Size = new System.Drawing.Size(145, 34);
            this.btnXuatCSV.TabIndex = 4;
            this.btnXuatCSV.Text = "📤 Xuất CSV";
            this.btnXuatCSV.UseVisualStyleBackColor = false;
            this.btnXuatCSV.Click += new System.EventHandler(this.btnXuatCSV_Click);
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaPhieu.FlatAppearance.BorderSize = 0;
            this.btnXoaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaPhieu.ForeColor = System.Drawing.Color.White;
            this.btnXoaPhieu.Location = new System.Drawing.Point(10, 68);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Size = new System.Drawing.Size(145, 34);
            this.btnXoaPhieu.TabIndex = 3;
            this.btnXoaPhieu.Text = "🗑️ Xóa phiếu";
            this.btnXoaPhieu.UseVisualStyleBackColor = false;
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTraSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraSach.FlatAppearance.BorderSize = 0;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(165, 28);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(145, 34);
            this.btnTraSach.TabIndex = 1;
            this.btnTraSach.Text = "↩️ Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnLapPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLapPhieu.FlatAppearance.BorderSize = 0;
            this.btnLapPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLapPhieu.Location = new System.Drawing.Point(10, 28);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(145, 34);
            this.btnLapPhieu.TabIndex = 0;
            this.btnLapPhieu.Text = "➕ Lập phiếu mượn";
            this.btnLapPhieu.UseVisualStyleBackColor = false;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblTonKho);
            this.grpThongTin.Controls.Add(this.lblGoiNgayTra);
            this.grpThongTin.Controls.Add(this.txtNgayTra);
            this.grpThongTin.Controls.Add(this.lblNgayTra);
            this.grpThongTin.Controls.Add(this.lblGoiHanTra);
            this.grpThongTin.Controls.Add(this.txtHanTra);
            this.grpThongTin.Controls.Add(this.lblHanTra);
            this.grpThongTin.Controls.Add(this.lblGoiNgayMuon);
            this.grpThongTin.Controls.Add(this.txtNgayMuon);
            this.grpThongTin.Controls.Add(this.lblNgayMuon);
            this.grpThongTin.Controls.Add(this.cboSach);
            this.grpThongTin.Controls.Add(this.lblSach);
            this.grpThongTin.Controls.Add(this.cboDocGia);
            this.grpThongTin.Controls.Add(this.lblDocGia);
            this.grpThongTin.Controls.Add(this.txtSoPhieu);
            this.grpThongTin.Controls.Add(this.lblSoPhieu);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpThongTin.Location = new System.Drawing.Point(8, 8);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(324, 275);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "THÔNG TIN PHIẾU MƯỢN";
            // 
            // lblTonKho
            // 
            this.lblTonKho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTonKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTonKho.Location = new System.Drawing.Point(15, 236);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(295, 38);
            this.lblTonKho.TabIndex = 15;
            this.lblTonKho.Text = "Tồn kho: --\r\nBỏ trống Ngày trả khi lập phiếu = chưa trả";
            // 
            // lblGoiNgayTra
            // 
            this.lblGoiNgayTra.AutoSize = true;
            this.lblGoiNgayTra.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGoiNgayTra.ForeColor = System.Drawing.Color.Gray;
            this.lblGoiNgayTra.Location = new System.Drawing.Point(246, 207);
            this.lblGoiNgayTra.Name = "lblGoiNgayTra";
            this.lblGoiNgayTra.Size = new System.Drawing.Size(103, 20);
            this.lblGoiNgayTra.TabIndex = 14;
            this.lblGoiNgayTra.Text = "(dd/MM/yyyy)";
            // 
            // txtNgayTra
            // 
            this.txtNgayTra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNgayTra.Location = new System.Drawing.Point(100, 204);
            this.txtNgayTra.Name = "txtNgayTra";
            this.txtNgayTra.Size = new System.Drawing.Size(140, 29);
            this.txtNgayTra.TabIndex = 13;
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgayTra.ForeColor = System.Drawing.Color.Black;
            this.lblNgayTra.Location = new System.Drawing.Point(15, 207);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(73, 21);
            this.lblNgayTra.TabIndex = 12;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // lblGoiHanTra
            // 
            this.lblGoiHanTra.AutoSize = true;
            this.lblGoiHanTra.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGoiHanTra.ForeColor = System.Drawing.Color.Gray;
            this.lblGoiHanTra.Location = new System.Drawing.Point(246, 172);
            this.lblGoiHanTra.Name = "lblGoiHanTra";
            this.lblGoiHanTra.Size = new System.Drawing.Size(103, 20);
            this.lblGoiHanTra.TabIndex = 11;
            this.lblGoiHanTra.Text = "(dd/MM/yyyy)";
            // 
            // txtHanTra
            // 
            this.txtHanTra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtHanTra.Location = new System.Drawing.Point(100, 169);
            this.txtHanTra.Name = "txtHanTra";
            this.txtHanTra.Size = new System.Drawing.Size(140, 29);
            this.txtHanTra.TabIndex = 10;
            // 
            // lblHanTra
            // 
            this.lblHanTra.AutoSize = true;
            this.lblHanTra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHanTra.ForeColor = System.Drawing.Color.Black;
            this.lblHanTra.Location = new System.Drawing.Point(15, 172);
            this.lblHanTra.Name = "lblHanTra";
            this.lblHanTra.Size = new System.Drawing.Size(64, 21);
            this.lblHanTra.TabIndex = 9;
            this.lblHanTra.Text = "Hạn trả:";
            // 
            // lblGoiNgayMuon
            // 
            this.lblGoiNgayMuon.AutoSize = true;
            this.lblGoiNgayMuon.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGoiNgayMuon.ForeColor = System.Drawing.Color.Gray;
            this.lblGoiNgayMuon.Location = new System.Drawing.Point(246, 137);
            this.lblGoiNgayMuon.Name = "lblGoiNgayMuon";
            this.lblGoiNgayMuon.Size = new System.Drawing.Size(103, 20);
            this.lblGoiNgayMuon.TabIndex = 8;
            this.lblGoiNgayMuon.Text = "(dd/MM/yyyy)";
            // 
            // txtNgayMuon
            // 
            this.txtNgayMuon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNgayMuon.Location = new System.Drawing.Point(100, 134);
            this.txtNgayMuon.Name = "txtNgayMuon";
            this.txtNgayMuon.Size = new System.Drawing.Size(140, 29);
            this.txtNgayMuon.TabIndex = 7;
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.AutoSize = true;
            this.lblNgayMuon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgayMuon.ForeColor = System.Drawing.Color.Black;
            this.lblNgayMuon.Location = new System.Drawing.Point(15, 137);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(96, 21);
            this.lblNgayMuon.TabIndex = 6;
            this.lblNgayMuon.Text = "Ngày mượn:";
            // 
            // cboSach
            // 
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(100, 99);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(210, 29);
            this.cboSach.TabIndex = 5;
            this.cboSach.SelectedIndexChanged += new System.EventHandler(this.cboSach_SelectedIndexChanged);
            // 
            // lblSach
            // 
            this.lblSach.AutoSize = true;
            this.lblSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSach.ForeColor = System.Drawing.Color.Black;
            this.lblSach.Location = new System.Drawing.Point(15, 102);
            this.lblSach.Name = "lblSach";
            this.lblSach.Size = new System.Drawing.Size(46, 21);
            this.lblSach.TabIndex = 4;
            this.lblSach.Text = "Sách:";
            // 
            // cboDocGia
            // 
            this.cboDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(100, 64);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(210, 29);
            this.cboDocGia.TabIndex = 3;
            // 
            // lblDocGia
            // 
            this.lblDocGia.AutoSize = true;
            this.lblDocGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDocGia.ForeColor = System.Drawing.Color.Black;
            this.lblDocGia.Location = new System.Drawing.Point(15, 67);
            this.lblDocGia.Name = "lblDocGia";
            this.lblDocGia.Size = new System.Drawing.Size(65, 21);
            this.lblDocGia.TabIndex = 2;
            this.lblDocGia.Text = "Độc giả:";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.txtSoPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoPhieu.Location = new System.Drawing.Point(100, 29);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(210, 29);
            this.txtSoPhieu.TabIndex = 1;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoPhieu.ForeColor = System.Drawing.Color.Black;
            this.lblSoPhieu.Location = new System.Drawing.Point(15, 32);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(74, 21);
            this.lblSoPhieu.TabIndex = 0;
            this.lblSoPhieu.Text = "Số phiếu:";
            // 
            // pnlPhai
            // 
            this.pnlPhai.Controls.Add(this.grpDanhSach);
            this.pnlPhai.Controls.Add(this.pnlTimKiem);
            this.pnlPhai.Controls.Add(this.lblChuThich);
            this.pnlPhai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhai.Location = new System.Drawing.Point(340, 0);
            this.pnlPhai.Name = "pnlPhai";
            this.pnlPhai.Padding = new System.Windows.Forms.Padding(8);
            this.pnlPhai.Size = new System.Drawing.Size(844, 681);
            this.pnlPhai.TabIndex = 1;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.lvPhieuMuon);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpDanhSach.Location = new System.Drawing.Point(8, 53);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(6);
            this.grpDanhSach.Size = new System.Drawing.Size(828, 598);
            this.grpDanhSach.TabIndex = 1;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "DANH SÁCH PHIẾU MƯỢN - TRẢ";
            // 
            // lvPhieuMuon
            // 
            this.lvPhieuMuon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSoPhieu,
            this.colDocGia,
            this.colSach,
            this.colNgayMuon,
            this.colHanTra,
            this.colNgayTra,
            this.colTienPhat,
            this.colTrangThai});
            this.lvPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvPhieuMuon.FullRowSelect = true;
            this.lvPhieuMuon.GridLines = true;
            this.lvPhieuMuon.HideSelection = false;
            this.lvPhieuMuon.Location = new System.Drawing.Point(6, 29);
            this.lvPhieuMuon.MultiSelect = false;
            this.lvPhieuMuon.Name = "lvPhieuMuon";
            this.lvPhieuMuon.Size = new System.Drawing.Size(816, 563);
            this.lvPhieuMuon.TabIndex = 0;
            this.lvPhieuMuon.UseCompatibleStateImageBehavior = false;
            this.lvPhieuMuon.View = System.Windows.Forms.View.Details;
            this.lvPhieuMuon.SelectedIndexChanged += new System.EventHandler(this.lvPhieuMuon_SelectedIndexChanged);
            // 
            // colSoPhieu
            // 
            this.colSoPhieu.Text = "Số phiếu";
            this.colSoPhieu.Width = 70;
            // 
            // colDocGia
            // 
            this.colDocGia.Text = "Độc giả";
            this.colDocGia.Width = 130;
            // 
            // colSach
            // 
            this.colSach.Text = "Sách";
            this.colSach.Width = 150;
            // 
            // colNgayMuon
            // 
            this.colNgayMuon.Text = "Ngày mượn";
            this.colNgayMuon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNgayMuon.Width = 84;
            // 
            // colHanTra
            // 
            this.colHanTra.Text = "Hạn trả";
            this.colHanTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHanTra.Width = 84;
            // 
            // colNgayTra
            // 
            this.colNgayTra.Text = "Ngày trả";
            this.colNgayTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNgayTra.Width = 84;
            // 
            // colTienPhat
            // 
            this.colTienPhat.Text = "Tiền phạt";
            this.colTienPhat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTienPhat.Width = 84;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng thái";
            this.colTrangThai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTrangThai.Width = 86;
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.Controls.Add(this.btnTatCa);
            this.pnlTimKiem.Controls.Add(this.cboLocTrangThai);
            this.pnlTimKiem.Controls.Add(this.lblLocTrangThai);
            this.pnlTimKiem.Controls.Add(this.btnTimKiem);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(8, 8);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(828, 45);
            this.pnlTimKiem.TabIndex = 0;
            // 
            // btnTatCa
            // 
            this.btnTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnTatCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTatCa.FlatAppearance.BorderSize = 0;
            this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTatCa.Location = new System.Drawing.Point(716, 8);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(104, 30);
            this.btnTatCa.TabIndex = 5;
            this.btnTatCa.Text = "Hiện tất cả";
            this.btnTatCa.UseVisualStyleBackColor = false;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Đang mượn",
            "Quá hạn",
            "Đã trả"});
            this.cboLocTrangThai.Location = new System.Drawing.Point(575, 10);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(135, 29);
            this.cboLocTrangThai.TabIndex = 4;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLocTrangThai.Location = new System.Drawing.Point(471, 14);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(91, 21);
            this.lblLocTrangThai.TabIndex = 3;
            this.lblLocTrangThai.Text = "Trạng thái:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(368, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(190, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(170, 30);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.Location = new System.Drawing.Point(8, 14);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(190, 21);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm (phiếu / ĐG / sách):";
            // 
            // lblChuThich
            // 
            this.lblChuThich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblChuThich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChuThich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChuThich.Location = new System.Drawing.Point(8, 651);
            this.lblChuThich.Name = "lblChuThich";
            this.lblChuThich.Size = new System.Drawing.Size(828, 22);
            this.lblChuThich.TabIndex = 2;
            this.lblChuThich.Text = "CẢNH BÁO MÀU:  HỒNG = quá hạn chưa trả   |   VÀNG = sắp đến hạn (còn tối đa 3 ngà" +
    "y)   |   XANH = đã trả xong";
            this.lblChuThich.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlPhai);
            this.Controls.Add(this.pnlTrai);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Mượn - Trả sách (Tồn kho & Tiền phạt)";
            this.Load += new System.EventHandler(this.FrmMuonTra_Load);
            this.pnlTrai.ResumeLayout(false);
            this.grpThaoTac.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.pnlPhai.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTrai;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Label lblSach;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.TextBox txtNgayMuon;
        private System.Windows.Forms.Label lblGoiNgayMuon;
        private System.Windows.Forms.Label lblHanTra;
        private System.Windows.Forms.TextBox txtHanTra;
        private System.Windows.Forms.Label lblGoiHanTra;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.TextBox txtNgayTra;
        private System.Windows.Forms.Label lblGoiNgayTra;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.GroupBox grpThaoTac;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Button btnXoaPhieu;
        private System.Windows.Forms.Button btnXuatCSV;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDatTruoc;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Panel pnlPhai;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.ListView lvPhieuMuon;
        private System.Windows.Forms.ColumnHeader colSoPhieu;
        private System.Windows.Forms.ColumnHeader colDocGia;
        private System.Windows.Forms.ColumnHeader colSach;
        private System.Windows.Forms.ColumnHeader colNgayMuon;
        private System.Windows.Forms.ColumnHeader colHanTra;
        private System.Windows.Forms.ColumnHeader colNgayTra;
        private System.Windows.Forms.ColumnHeader colTienPhat;
        private System.Windows.Forms.ColumnHeader colTrangThai;
        private System.Windows.Forms.Label lblChuThich;
    }
}
