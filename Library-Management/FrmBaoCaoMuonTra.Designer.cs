namespace Library_Management
{
    partial class FrmBaoCaoMuonTra
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
            this.tabBaoCao = new System.Windows.Forms.TabControl();
            this.tabQuaHan = new System.Windows.Forms.TabPage();
            this.lvQuaHan = new System.Windows.Forms.ListView();
            this.lblQuaHanTongHop = new System.Windows.Forms.Label();
            this.tabTheLoai = new System.Windows.Forms.TabPage();
            this.lvTheLoai = new System.Windows.Forms.ListView();
            this.pnlTheLoai = new System.Windows.Forms.Panel();
            this.lblTheLoaiTongHop = new System.Windows.Forms.Label();
            this.rdoGop = new System.Windows.Forms.RadioButton();
            this.rdoChiTiet = new System.Windows.Forms.RadioButton();
            this.tabItMuon = new System.Windows.Forms.TabPage();
            this.lvItMuon = new System.Windows.Forms.ListView();
            this.pnlItMuon = new System.Windows.Forms.Panel();
            this.lblItMuonTongHop = new System.Windows.Forms.Label();
            this.nudNguong = new System.Windows.Forms.NumericUpDown();
            this.lblNguong = new System.Windows.Forms.Label();
            this.tabDatTruoc = new System.Windows.Forms.TabPage();
            this.lvDatTruoc = new System.Windows.Forms.ListView();
            this.pnlDatTruoc = new System.Windows.Forms.Panel();
            this.lblDatTruocTongHop = new System.Windows.Forms.Label();
            this.btnHuyDatTruoc = new System.Windows.Forms.Button();
            this.chkChiChoNhan = new System.Windows.Forms.CheckBox();
            this.pnlNut = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXuatCSV = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.tabBaoCao.SuspendLayout();
            this.tabQuaHan.SuspendLayout();
            this.tabTheLoai.SuspendLayout();
            this.pnlTheLoai.SuspendLayout();
            this.tabItMuon.SuspendLayout();
            this.pnlItMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNguong)).BeginInit();
            this.tabDatTruoc.SuspendLayout();
            this.pnlDatTruoc.SuspendLayout();
            this.pnlNut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.tabQuaHan);
            this.tabBaoCao.Controls.Add(this.tabTheLoai);
            this.tabBaoCao.Controls.Add(this.tabItMuon);
            this.tabBaoCao.Controls.Add(this.tabDatTruoc);
            this.tabBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabBaoCao.Location = new System.Drawing.Point(0, 0);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.SelectedIndex = 0;
            this.tabBaoCao.Size = new System.Drawing.Size(1084, 555);
            this.tabBaoCao.TabIndex = 0;
            // 
            // tabQuaHan
            // 
            this.tabQuaHan.Controls.Add(this.lvQuaHan);
            this.tabQuaHan.Controls.Add(this.lblQuaHanTongHop);
            this.tabQuaHan.Location = new System.Drawing.Point(4, 32);
            this.tabQuaHan.Name = "tabQuaHan";
            this.tabQuaHan.Padding = new System.Windows.Forms.Padding(6);
            this.tabQuaHan.Size = new System.Drawing.Size(1076, 519);
            this.tabQuaHan.TabIndex = 0;
            this.tabQuaHan.Text = "Độc giả quá hạn";
            this.tabQuaHan.UseVisualStyleBackColor = true;
            // 
            // lvQuaHan
            // 
            this.lvQuaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuaHan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvQuaHan.FullRowSelect = true;
            this.lvQuaHan.GridLines = true;
            this.lvQuaHan.HideSelection = false;
            this.lvQuaHan.Location = new System.Drawing.Point(6, 40);
            this.lvQuaHan.MultiSelect = false;
            this.lvQuaHan.Name = "lvQuaHan";
            this.lvQuaHan.Size = new System.Drawing.Size(1064, 473);
            this.lvQuaHan.TabIndex = 1;
            this.lvQuaHan.UseCompatibleStateImageBehavior = false;
            this.lvQuaHan.View = System.Windows.Forms.View.Details;
            // 
            // lblQuaHanTongHop
            // 
            this.lblQuaHanTongHop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQuaHanTongHop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblQuaHanTongHop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQuaHanTongHop.Location = new System.Drawing.Point(6, 6);
            this.lblQuaHanTongHop.Name = "lblQuaHanTongHop";
            this.lblQuaHanTongHop.Size = new System.Drawing.Size(1064, 34);
            this.lblQuaHanTongHop.TabIndex = 0;
            this.lblQuaHanTongHop.Text = "...";
            this.lblQuaHanTongHop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabTheLoai
            // 
            this.tabTheLoai.Controls.Add(this.lvTheLoai);
            this.tabTheLoai.Controls.Add(this.pnlTheLoai);
            this.tabTheLoai.Location = new System.Drawing.Point(4, 32);
            this.tabTheLoai.Name = "tabTheLoai";
            this.tabTheLoai.Padding = new System.Windows.Forms.Padding(6);
            this.tabTheLoai.Size = new System.Drawing.Size(1076, 519);
            this.tabTheLoai.TabIndex = 1;
            this.tabTheLoai.Text = "Lượt mượn theo thể loại";
            this.tabTheLoai.UseVisualStyleBackColor = true;
            // 
            // lvTheLoai
            // 
            this.lvTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvTheLoai.FullRowSelect = true;
            this.lvTheLoai.GridLines = true;
            this.lvTheLoai.HideSelection = false;
            this.lvTheLoai.Location = new System.Drawing.Point(6, 46);
            this.lvTheLoai.MultiSelect = false;
            this.lvTheLoai.Name = "lvTheLoai";
            this.lvTheLoai.Size = new System.Drawing.Size(1064, 467);
            this.lvTheLoai.TabIndex = 1;
            this.lvTheLoai.UseCompatibleStateImageBehavior = false;
            this.lvTheLoai.View = System.Windows.Forms.View.Details;
            // 
            // pnlTheLoai
            // 
            this.pnlTheLoai.Controls.Add(this.lblTheLoaiTongHop);
            this.pnlTheLoai.Controls.Add(this.rdoGop);
            this.pnlTheLoai.Controls.Add(this.rdoChiTiet);
            this.pnlTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTheLoai.Location = new System.Drawing.Point(6, 6);
            this.pnlTheLoai.Name = "pnlTheLoai";
            this.pnlTheLoai.Size = new System.Drawing.Size(1064, 40);
            this.pnlTheLoai.TabIndex = 0;
            // 
            // lblTheLoaiTongHop
            // 
            this.lblTheLoaiTongHop.AutoSize = true;
            this.lblTheLoaiTongHop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTheLoaiTongHop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTheLoaiTongHop.Location = new System.Drawing.Point(390, 11);
            this.lblTheLoaiTongHop.Name = "lblTheLoaiTongHop";
            this.lblTheLoaiTongHop.Size = new System.Drawing.Size(22, 21);
            this.lblTheLoaiTongHop.TabIndex = 2;
            this.lblTheLoaiTongHop.Text = "...";
            // 
            // rdoGop
            // 
            this.rdoGop.AutoSize = true;
            this.rdoGop.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdoGop.Location = new System.Drawing.Point(190, 9);
            this.rdoGop.Name = "rdoGop";
            this.rdoGop.Size = new System.Drawing.Size(179, 25);
            this.rdoGop.TabIndex = 1;
            this.rdoGop.Text = "Gộp theo thể loại gốc";
            this.rdoGop.CheckedChanged += new System.EventHandler(this.rdoCheDoTheLoai_CheckedChanged);
            // 
            // rdoChiTiet
            // 
            this.rdoChiTiet.AutoSize = true;
            this.rdoChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdoChiTiet.Location = new System.Drawing.Point(4, 9);
            this.rdoChiTiet.Name = "rdoChiTiet";
            this.rdoChiTiet.Size = new System.Drawing.Size(171, 25);
            this.rdoChiTiet.TabIndex = 0;
            this.rdoChiTiet.Text = "Chi tiết từng thể loại";
            this.rdoChiTiet.CheckedChanged += new System.EventHandler(this.rdoCheDoTheLoai_CheckedChanged);
            // 
            // tabItMuon
            // 
            this.tabItMuon.Controls.Add(this.lvItMuon);
            this.tabItMuon.Controls.Add(this.pnlItMuon);
            this.tabItMuon.Location = new System.Drawing.Point(4, 32);
            this.tabItMuon.Name = "tabItMuon";
            this.tabItMuon.Padding = new System.Windows.Forms.Padding(6);
            this.tabItMuon.Size = new System.Drawing.Size(1076, 519);
            this.tabItMuon.TabIndex = 2;
            this.tabItMuon.Text = "Sách ít được mượn";
            this.tabItMuon.UseVisualStyleBackColor = true;
            // 
            // lvItMuon
            // 
            this.lvItMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvItMuon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvItMuon.FullRowSelect = true;
            this.lvItMuon.GridLines = true;
            this.lvItMuon.HideSelection = false;
            this.lvItMuon.Location = new System.Drawing.Point(6, 46);
            this.lvItMuon.MultiSelect = false;
            this.lvItMuon.Name = "lvItMuon";
            this.lvItMuon.Size = new System.Drawing.Size(1064, 467);
            this.lvItMuon.TabIndex = 1;
            this.lvItMuon.UseCompatibleStateImageBehavior = false;
            this.lvItMuon.View = System.Windows.Forms.View.Details;
            // 
            // pnlItMuon
            // 
            this.pnlItMuon.Controls.Add(this.lblItMuonTongHop);
            this.pnlItMuon.Controls.Add(this.nudNguong);
            this.pnlItMuon.Controls.Add(this.lblNguong);
            this.pnlItMuon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlItMuon.Location = new System.Drawing.Point(6, 6);
            this.pnlItMuon.Name = "pnlItMuon";
            this.pnlItMuon.Size = new System.Drawing.Size(1064, 40);
            this.pnlItMuon.TabIndex = 0;
            // 
            // lblItMuonTongHop
            // 
            this.lblItMuonTongHop.AutoSize = true;
            this.lblItMuonTongHop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblItMuonTongHop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblItMuonTongHop.Location = new System.Drawing.Point(280, 11);
            this.lblItMuonTongHop.Name = "lblItMuonTongHop";
            this.lblItMuonTongHop.Size = new System.Drawing.Size(22, 21);
            this.lblItMuonTongHop.TabIndex = 2;
            this.lblItMuonTongHop.Text = "...";
            // 
            // nudNguong
            // 
            this.nudNguong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudNguong.Location = new System.Drawing.Point(200, 8);
            this.nudNguong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNguong.Name = "nudNguong";
            this.nudNguong.Size = new System.Drawing.Size(60, 29);
            this.nudNguong.TabIndex = 1;
            this.nudNguong.ValueChanged += new System.EventHandler(this.nudNguong_ValueChanged);
            // 
            // lblNguong
            // 
            this.lblNguong.AutoSize = true;
            this.lblNguong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNguong.Location = new System.Drawing.Point(4, 11);
            this.lblNguong.Name = "lblNguong";
            this.lblNguong.Size = new System.Drawing.Size(210, 21);
            this.lblNguong.TabIndex = 0;
            this.lblNguong.Text = "Hiện sách có số lượt mượn ≤";
            // 
            // tabDatTruoc
            // 
            this.tabDatTruoc.Controls.Add(this.lvDatTruoc);
            this.tabDatTruoc.Controls.Add(this.pnlDatTruoc);
            this.tabDatTruoc.Location = new System.Drawing.Point(4, 32);
            this.tabDatTruoc.Name = "tabDatTruoc";
            this.tabDatTruoc.Padding = new System.Windows.Forms.Padding(6);
            this.tabDatTruoc.Size = new System.Drawing.Size(1076, 519);
            this.tabDatTruoc.TabIndex = 3;
            this.tabDatTruoc.Text = "Đặt trước sách";
            this.tabDatTruoc.UseVisualStyleBackColor = true;
            // 
            // lvDatTruoc
            // 
            this.lvDatTruoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDatTruoc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvDatTruoc.FullRowSelect = true;
            this.lvDatTruoc.GridLines = true;
            this.lvDatTruoc.HideSelection = false;
            this.lvDatTruoc.Location = new System.Drawing.Point(6, 46);
            this.lvDatTruoc.MultiSelect = false;
            this.lvDatTruoc.Name = "lvDatTruoc";
            this.lvDatTruoc.Size = new System.Drawing.Size(1064, 467);
            this.lvDatTruoc.TabIndex = 1;
            this.lvDatTruoc.UseCompatibleStateImageBehavior = false;
            this.lvDatTruoc.View = System.Windows.Forms.View.Details;
            // 
            // pnlDatTruoc
            // 
            this.pnlDatTruoc.Controls.Add(this.lblDatTruocTongHop);
            this.pnlDatTruoc.Controls.Add(this.btnHuyDatTruoc);
            this.pnlDatTruoc.Controls.Add(this.chkChiChoNhan);
            this.pnlDatTruoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatTruoc.Location = new System.Drawing.Point(6, 6);
            this.pnlDatTruoc.Name = "pnlDatTruoc";
            this.pnlDatTruoc.Size = new System.Drawing.Size(1064, 40);
            this.pnlDatTruoc.TabIndex = 0;
            // 
            // lblDatTruocTongHop
            // 
            this.lblDatTruocTongHop.AutoSize = true;
            this.lblDatTruocTongHop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDatTruocTongHop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblDatTruocTongHop.Location = new System.Drawing.Point(385, 11);
            this.lblDatTruocTongHop.Name = "lblDatTruocTongHop";
            this.lblDatTruocTongHop.Size = new System.Drawing.Size(22, 21);
            this.lblDatTruocTongHop.TabIndex = 2;
            this.lblDatTruocTongHop.Text = "...";
            // 
            // btnHuyDatTruoc
            // 
            this.btnHuyDatTruoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHuyDatTruoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyDatTruoc.FlatAppearance.BorderSize = 0;
            this.btnHuyDatTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDatTruoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHuyDatTruoc.ForeColor = System.Drawing.Color.White;
            this.btnHuyDatTruoc.Location = new System.Drawing.Point(220, 4);
            this.btnHuyDatTruoc.Name = "btnHuyDatTruoc";
            this.btnHuyDatTruoc.Size = new System.Drawing.Size(150, 32);
            this.btnHuyDatTruoc.TabIndex = 1;
            this.btnHuyDatTruoc.Text = "✖ Hủy đặt trước";
            this.btnHuyDatTruoc.UseVisualStyleBackColor = false;
            this.btnHuyDatTruoc.Click += new System.EventHandler(this.btnHuyDatTruoc_Click);
            // 
            // chkChiChoNhan
            // 
            this.chkChiChoNhan.AutoSize = true;
            this.chkChiChoNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkChiChoNhan.Location = new System.Drawing.Point(4, 10);
            this.chkChiChoNhan.Name = "chkChiChoNhan";
            this.chkChiChoNhan.Size = new System.Drawing.Size(215, 25);
            this.chkChiChoNhan.TabIndex = 0;
            this.chkChiChoNhan.Text = "Chỉ hiện yêu cầu đang chờ";
            this.chkChiChoNhan.CheckedChanged += new System.EventHandler(this.chkChiChoNhan_CheckedChanged);
            // 
            // pnlNut
            // 
            this.pnlNut.Controls.Add(this.btnDong);
            this.pnlNut.Controls.Add(this.btnXuatCSV);
            this.pnlNut.Controls.Add(this.btnLamMoi);
            this.pnlNut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNut.Location = new System.Drawing.Point(0, 555);
            this.pnlNut.Name = "pnlNut";
            this.pnlNut.Size = new System.Drawing.Size(1084, 50);
            this.pnlNut.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(964, 8);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXuatCSV
            // 
            this.btnXuatCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnXuatCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatCSV.FlatAppearance.BorderSize = 0;
            this.btnXuatCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatCSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatCSV.ForeColor = System.Drawing.Color.White;
            this.btnXuatCSV.Location = new System.Drawing.Point(170, 8);
            this.btnXuatCSV.Name = "btnXuatCSV";
            this.btnXuatCSV.Size = new System.Drawing.Size(200, 34);
            this.btnXuatCSV.TabIndex = 1;
            this.btnXuatCSV.Text = "📤 Xuất CSV tab hiện tại";
            this.btnXuatCSV.UseVisualStyleBackColor = false;
            this.btnXuatCSV.Click += new System.EventHandler(this.btnXuatCSV_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(10, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(150, 34);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // FrmBaoCaoMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 605);
            this.Controls.Add(this.tabBaoCao);
            this.Controls.Add(this.pnlNut);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimizeBox = false;
            this.Name = "FrmBaoCaoMuonTra";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê - Báo cáo Mượn Trả ";
            this.Load += new System.EventHandler(this.FrmBaoCaoMuonTra_Load);
            this.tabBaoCao.ResumeLayout(false);
            this.tabQuaHan.ResumeLayout(false);
            this.tabTheLoai.ResumeLayout(false);
            this.pnlTheLoai.ResumeLayout(false);
            this.pnlTheLoai.PerformLayout();
            this.tabItMuon.ResumeLayout(false);
            this.pnlItMuon.ResumeLayout(false);
            this.pnlItMuon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNguong)).EndInit();
            this.tabDatTruoc.ResumeLayout(false);
            this.pnlDatTruoc.ResumeLayout(false);
            this.pnlDatTruoc.PerformLayout();
            this.pnlNut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabBaoCao;
        private System.Windows.Forms.TabPage tabQuaHan;
        private System.Windows.Forms.ListView lvQuaHan;
        private System.Windows.Forms.Label lblQuaHanTongHop;
        private System.Windows.Forms.TabPage tabTheLoai;
        private System.Windows.Forms.ListView lvTheLoai;
        private System.Windows.Forms.Panel pnlTheLoai;
        private System.Windows.Forms.Label lblTheLoaiTongHop;
        private System.Windows.Forms.RadioButton rdoGop;
        private System.Windows.Forms.RadioButton rdoChiTiet;
        private System.Windows.Forms.TabPage tabItMuon;
        private System.Windows.Forms.ListView lvItMuon;
        private System.Windows.Forms.Panel pnlItMuon;
        private System.Windows.Forms.Label lblItMuonTongHop;
        private System.Windows.Forms.NumericUpDown nudNguong;
        private System.Windows.Forms.Label lblNguong;
        private System.Windows.Forms.TabPage tabDatTruoc;
        private System.Windows.Forms.ListView lvDatTruoc;
        private System.Windows.Forms.Panel pnlDatTruoc;
        private System.Windows.Forms.Label lblDatTruocTongHop;
        private System.Windows.Forms.Button btnHuyDatTruoc;
        private System.Windows.Forms.CheckBox chkChiChoNhan;
        private System.Windows.Forms.Panel pnlNut;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXuatCSV;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
