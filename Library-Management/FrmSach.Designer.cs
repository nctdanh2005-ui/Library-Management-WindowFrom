namespace Library_Management
{
    partial class FrmSach
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
            this.pnlTrai = new System.Windows.Forms.Panel();
            this.grpTheLoai = new System.Windows.Forms.GroupBox();
            this.tvTheLoai = new System.Windows.Forms.TreeView();
            this.cmsTheLoai = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmThemCon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSua = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmThemGoc = new System.Windows.Forms.ToolStripMenuItem();
            this.grpThaoTacTheLoai = new System.Windows.Forms.GroupBox();
            this.btnTatCaSach = new System.Windows.Forms.Button();
            this.btnXoaTheLoai = new System.Windows.Forms.Button();
            this.btnSuaTheLoai = new System.Windows.Forms.Button();
            this.btnThemCon = new System.Windows.Forms.Button();
            this.btnThemGoc = new System.Windows.Forms.Button();
            this.txtTenTheLoai = new System.Windows.Forms.TextBox();
            this.lblTenTheLoai = new System.Windows.Forms.Label();
            this.txtMaTheLoai = new System.Windows.Forms.TextBox();
            this.lblMaTheLoai = new System.Windows.Forms.Label();
            this.pnlPhai = new System.Windows.Forms.Panel();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lvSach = new System.Windows.Forms.ListView();
            this.colMa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTacGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNamXB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTheLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAnh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnLamMoiDanhSach = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.grpThongTinSach = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnSuaSach = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.picBiaSach = new System.Windows.Forms.PictureBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.txtNamXB = new System.Windows.Forms.TextBox();
            this.lblNamXB = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.pnlTrai.SuspendLayout();
            this.grpTheLoai.SuspendLayout();
            this.cmsTheLoai.SuspendLayout();
            this.grpThaoTacTheLoai.SuspendLayout();
            this.pnlPhai.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            this.grpThongTinSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTrai
            // 
            this.pnlTrai.Controls.Add(this.grpTheLoai);
            this.pnlTrai.Controls.Add(this.grpThaoTacTheLoai);
            this.pnlTrai.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTrai.Location = new System.Drawing.Point(0, 0);
            this.pnlTrai.Name = "pnlTrai";
            this.pnlTrai.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTrai.Size = new System.Drawing.Size(320, 681);
            this.pnlTrai.TabIndex = 0;
            // 
            // grpTheLoai
            // 
            this.grpTheLoai.Controls.Add(this.tvTheLoai);
            this.grpTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTheLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpTheLoai.Location = new System.Drawing.Point(8, 8);
            this.grpTheLoai.Name = "grpTheLoai";
            this.grpTheLoai.Padding = new System.Windows.Forms.Padding(6);
            this.grpTheLoai.Size = new System.Drawing.Size(304, 435);
            this.grpTheLoai.TabIndex = 0;
            this.grpTheLoai.TabStop = false;
            this.grpTheLoai.Text = "CÂY THỂ LOẠI SÁCH";
            // 
            // tvTheLoai
            // 
            this.tvTheLoai.ContextMenuStrip = this.cmsTheLoai;
            this.tvTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tvTheLoai.HideSelection = false;
            this.tvTheLoai.Location = new System.Drawing.Point(6, 24);
            this.tvTheLoai.Name = "tvTheLoai";
            this.tvTheLoai.Size = new System.Drawing.Size(292, 405);
            this.tvTheLoai.TabIndex = 0;
            this.tvTheLoai.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTheLoai_AfterSelect);
            // 
            // cmsTheLoai
            // 
            this.cmsTheLoai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmThemCon,
            this.tsmSua,
            this.tsmXoa,
            this.toolStripSeparator3,
            this.tsmThemGoc});
            this.cmsTheLoai.Name = "cmsTheLoai";
            this.cmsTheLoai.Size = new System.Drawing.Size(185, 98);
            // 
            // tsmThemCon
            // 
            this.tsmThemCon.Name = "tsmThemCon";
            this.tsmThemCon.Size = new System.Drawing.Size(184, 22);
            this.tsmThemCon.Text = "Thêm thể loại con";
            this.tsmThemCon.Click += new System.EventHandler(this.btnThemCon_Click);
            // 
            // tsmSua
            // 
            this.tsmSua.Name = "tsmSua";
            this.tsmSua.Size = new System.Drawing.Size(184, 22);
            this.tsmSua.Text = "Sửa tên thể loại";
            this.tsmSua.Click += new System.EventHandler(this.btnSuaTheLoai_Click);
            // 
            // tsmXoa
            // 
            this.tsmXoa.Name = "tsmXoa";
            this.tsmXoa.Size = new System.Drawing.Size(184, 22);
            this.tsmXoa.Text = "Xóa thể loại";
            this.tsmXoa.Click += new System.EventHandler(this.btnXoaTheLoai_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // tsmThemGoc
            // 
            this.tsmThemGoc.Name = "tsmThemGoc";
            this.tsmThemGoc.Size = new System.Drawing.Size(184, 22);
            this.tsmThemGoc.Text = "Thêm thể loại gốc";
            this.tsmThemGoc.Click += new System.EventHandler(this.btnThemGoc_Click);
            // 
            // grpThaoTacTheLoai
            // 
            this.grpThaoTacTheLoai.Controls.Add(this.btnTatCaSach);
            this.grpThaoTacTheLoai.Controls.Add(this.btnXoaTheLoai);
            this.grpThaoTacTheLoai.Controls.Add(this.btnSuaTheLoai);
            this.grpThaoTacTheLoai.Controls.Add(this.btnThemCon);
            this.grpThaoTacTheLoai.Controls.Add(this.btnThemGoc);
            this.grpThaoTacTheLoai.Controls.Add(this.txtTenTheLoai);
            this.grpThaoTacTheLoai.Controls.Add(this.lblTenTheLoai);
            this.grpThaoTacTheLoai.Controls.Add(this.txtMaTheLoai);
            this.grpThaoTacTheLoai.Controls.Add(this.lblMaTheLoai);
            this.grpThaoTacTheLoai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpThaoTacTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpThaoTacTheLoai.Location = new System.Drawing.Point(8, 443);
            this.grpThaoTacTheLoai.Name = "grpThaoTacTheLoai";
            this.grpThaoTacTheLoai.Size = new System.Drawing.Size(304, 230);
            this.grpThaoTacTheLoai.TabIndex = 1;
            this.grpThaoTacTheLoai.TabStop = false;
            this.grpThaoTacTheLoai.Text = "QUẢN LÝ THỂ LOẠI";
            // 
            // btnTatCaSach
            // 
            this.btnTatCaSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnTatCaSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTatCaSach.FlatAppearance.BorderSize = 0;
            this.btnTatCaSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCaSach.ForeColor = System.Drawing.Color.White;
            this.btnTatCaSach.Location = new System.Drawing.Point(10, 185);
            this.btnTatCaSach.Name = "btnTatCaSach";
            this.btnTatCaSach.Size = new System.Drawing.Size(284, 32);
            this.btnTatCaSach.TabIndex = 8;
            this.btnTatCaSach.Text = "📋 Xem toàn bộ sách";
            this.btnTatCaSach.UseVisualStyleBackColor = false;
            this.btnTatCaSach.Click += new System.EventHandler(this.btnTatCaSach_Click);
            // 
            // btnXoaTheLoai
            // 
            this.btnXoaTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaTheLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaTheLoai.FlatAppearance.BorderSize = 0;
            this.btnXoaTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTheLoai.ForeColor = System.Drawing.Color.White;
            this.btnXoaTheLoai.Location = new System.Drawing.Point(155, 146);
            this.btnXoaTheLoai.Name = "btnXoaTheLoai";
            this.btnXoaTheLoai.Size = new System.Drawing.Size(139, 30);
            this.btnXoaTheLoai.TabIndex = 7;
            this.btnXoaTheLoai.Text = "Xóa thể loại";
            this.btnXoaTheLoai.UseVisualStyleBackColor = false;
            this.btnXoaTheLoai.Click += new System.EventHandler(this.btnXoaTheLoai_Click);
            // 
            // btnSuaTheLoai
            // 
            this.btnSuaTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnSuaTheLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaTheLoai.FlatAppearance.BorderSize = 0;
            this.btnSuaTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTheLoai.ForeColor = System.Drawing.Color.White;
            this.btnSuaTheLoai.Location = new System.Drawing.Point(10, 146);
            this.btnSuaTheLoai.Name = "btnSuaTheLoai";
            this.btnSuaTheLoai.Size = new System.Drawing.Size(139, 30);
            this.btnSuaTheLoai.TabIndex = 6;
            this.btnSuaTheLoai.Text = "Đổi tên TL";
            this.btnSuaTheLoai.UseVisualStyleBackColor = false;
            this.btnSuaTheLoai.Click += new System.EventHandler(this.btnSuaTheLoai_Click);
            // 
            // btnThemCon
            // 
            this.btnThemCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnThemCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemCon.FlatAppearance.BorderSize = 0;
            this.btnThemCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCon.ForeColor = System.Drawing.Color.White;
            this.btnThemCon.Location = new System.Drawing.Point(155, 110);
            this.btnThemCon.Name = "btnThemCon";
            this.btnThemCon.Size = new System.Drawing.Size(139, 30);
            this.btnThemCon.TabIndex = 5;
            this.btnThemCon.Text = "+ Thêm con";
            this.btnThemCon.UseVisualStyleBackColor = false;
            this.btnThemCon.Click += new System.EventHandler(this.btnThemCon_Click);
            // 
            // btnThemGoc
            // 
            this.btnThemGoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnThemGoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemGoc.FlatAppearance.BorderSize = 0;
            this.btnThemGoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemGoc.ForeColor = System.Drawing.Color.White;
            this.btnThemGoc.Location = new System.Drawing.Point(10, 110);
            this.btnThemGoc.Name = "btnThemGoc";
            this.btnThemGoc.Size = new System.Drawing.Size(139, 30);
            this.btnThemGoc.TabIndex = 4;
            this.btnThemGoc.Text = "+ Thêm gốc";
            this.btnThemGoc.UseVisualStyleBackColor = false;
            this.btnThemGoc.Click += new System.EventHandler(this.btnThemGoc_Click);
            // 
            // txtTenTheLoai
            // 
            this.txtTenTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenTheLoai.Location = new System.Drawing.Point(85, 68);
            this.txtTenTheLoai.Name = "txtTenTheLoai";
            this.txtTenTheLoai.Size = new System.Drawing.Size(209, 24);
            this.txtTenTheLoai.TabIndex = 3;
            // 
            // lblTenTheLoai
            // 
            this.lblTenTheLoai.AutoSize = true;
            this.lblTenTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenTheLoai.Location = new System.Drawing.Point(7, 71);
            this.lblTenTheLoai.Name = "lblTenTheLoai";
            this.lblTenTheLoai.Size = new System.Drawing.Size(51, 17);
            this.lblTenTheLoai.TabIndex = 2;
            this.lblTenTheLoai.Text = "Tên TL:";
            // 
            // txtMaTheLoai
            // 
            this.txtMaTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaTheLoai.Location = new System.Drawing.Point(85, 33);
            this.txtMaTheLoai.Name = "txtMaTheLoai";
            this.txtMaTheLoai.Size = new System.Drawing.Size(209, 24);
            this.txtMaTheLoai.TabIndex = 1;
            // 
            // lblMaTheLoai
            // 
            this.lblMaTheLoai.AutoSize = true;
            this.lblMaTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaTheLoai.Location = new System.Drawing.Point(7, 36);
            this.lblMaTheLoai.Name = "lblMaTheLoai";
            this.lblMaTheLoai.Size = new System.Drawing.Size(50, 17);
            this.lblMaTheLoai.TabIndex = 0;
            this.lblMaTheLoai.Text = "Mã TL:";
            // 
            // pnlPhai
            // 
            this.pnlPhai.Controls.Add(this.grpDanhSach);
            this.pnlPhai.Controls.Add(this.pnlTimKiem);
            this.pnlPhai.Controls.Add(this.grpThongTinSach);
            this.pnlPhai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhai.Location = new System.Drawing.Point(320, 0);
            this.pnlPhai.Name = "pnlPhai";
            this.pnlPhai.Padding = new System.Windows.Forms.Padding(8);
            this.pnlPhai.Size = new System.Drawing.Size(864, 681);
            this.pnlPhai.TabIndex = 1;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.lvSach);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpDanhSach.Location = new System.Drawing.Point(8, 290);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(6);
            this.grpDanhSach.Size = new System.Drawing.Size(848, 383);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "DANH SÁCH SÁCH";
            // 
            // lvSach
            // 
            this.lvSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMa,
            this.colTen,
            this.colTacGia,
            this.colNamXB,
            this.colTheLoai,
            this.colSoLuong,
            this.colAnh});
            this.lvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvSach.FullRowSelect = true;
            this.lvSach.GridLines = true;
            this.lvSach.HideSelection = false;
            this.lvSach.Location = new System.Drawing.Point(6, 24);
            this.lvSach.MultiSelect = false;
            this.lvSach.Name = "lvSach";
            this.lvSach.Size = new System.Drawing.Size(836, 353);
            this.lvSach.TabIndex = 0;
            this.lvSach.UseCompatibleStateImageBehavior = false;
            this.lvSach.View = System.Windows.Forms.View.Details;
            this.lvSach.SelectedIndexChanged += new System.EventHandler(this.lvSach_SelectedIndexChanged);
            // 
            // colMa
            // 
            this.colMa.Text = "Mã sách";
            this.colMa.Width = 75;
            // 
            // colTen
            // 
            this.colTen.Text = "Tên sách";
            this.colTen.Width = 230;
            // 
            // colTacGia
            // 
            this.colTacGia.Text = "Tác giả";
            this.colTacGia.Width = 145;
            // 
            // colNamXB
            // 
            this.colNamXB.Text = "Năm XB";
            this.colNamXB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNamXB.Width = 70;
            // 
            // colTheLoai
            // 
            this.colTheLoai.Text = "Thể loại";
            this.colTheLoai.Width = 145;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "Số lượng";
            this.colSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSoLuong.Width = 70;
            // 
            // colAnh
            // 
            this.colAnh.Text = "File ảnh bìa";
            this.colAnh.Width = 90;
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.Controls.Add(this.btnLamMoiDanhSach);
            this.pnlTimKiem.Controls.Add(this.btnTimKiem);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(8, 245);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(848, 45);
            this.pnlTimKiem.TabIndex = 1;
            // 
            // btnLamMoiDanhSach
            // 
            this.btnLamMoiDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnLamMoiDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiDanhSach.FlatAppearance.BorderSize = 0;
            this.btnLamMoiDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiDanhSach.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiDanhSach.Location = new System.Drawing.Point(542, 7);
            this.btnLamMoiDanhSach.Name = "btnLamMoiDanhSach";
            this.btnLamMoiDanhSach.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoiDanhSach.TabIndex = 3;
            this.btnLamMoiDanhSach.Text = "Tất cả sách";
            this.btnLamMoiDanhSach.UseVisualStyleBackColor = false;
            this.btnLamMoiDanhSach.Click += new System.EventHandler(this.btnTatCaSach_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(448, 7);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(145, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(295, 25);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.Location = new System.Drawing.Point(8, 14);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(126, 17);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm theo tên:";
            // 
            // grpThongTinSach
            // 
            this.grpThongTinSach.Controls.Add(this.btnLamMoi);
            this.grpThongTinSach.Controls.Add(this.btnXoaSach);
            this.grpThongTinSach.Controls.Add(this.btnSuaSach);
            this.grpThongTinSach.Controls.Add(this.btnThemSach);
            this.grpThongTinSach.Controls.Add(this.btnChonAnh);
            this.grpThongTinSach.Controls.Add(this.picBiaSach);
            this.grpThongTinSach.Controls.Add(this.txtSoLuong);
            this.grpThongTinSach.Controls.Add(this.lblSoLuong);
            this.grpThongTinSach.Controls.Add(this.cboTheLoai);
            this.grpThongTinSach.Controls.Add(this.lblTheLoai);
            this.grpThongTinSach.Controls.Add(this.txtNamXB);
            this.grpThongTinSach.Controls.Add(this.lblNamXB);
            this.grpThongTinSach.Controls.Add(this.txtTacGia);
            this.grpThongTinSach.Controls.Add(this.lblTacGia);
            this.grpThongTinSach.Controls.Add(this.txtTenSach);
            this.grpThongTinSach.Controls.Add(this.lblTenSach);
            this.grpThongTinSach.Controls.Add(this.txtMaSach);
            this.grpThongTinSach.Controls.Add(this.lblMaSach);
            this.grpThongTinSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTinSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpThongTinSach.Location = new System.Drawing.Point(8, 8);
            this.grpThongTinSach.Name = "grpThongTinSach";
            this.grpThongTinSach.Size = new System.Drawing.Size(848, 237);
            this.grpThongTinSach.TabIndex = 0;
            this.grpThongTinSach.TabStop = false;
            this.grpThongTinSach.Text = "THÔNG TIN CHI TIẾT SÁCH";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(403, 190);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 33);
            this.btnLamMoi.TabIndex = 17;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaSach.FlatAppearance.BorderSize = 0;
            this.btnXoaSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaSach.ForeColor = System.Drawing.Color.White;
            this.btnXoaSach.Location = new System.Drawing.Point(298, 190);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(95, 33);
            this.btnXoaSach.TabIndex = 16;
            this.btnXoaSach.Text = "🗑️ Xóa";
            this.btnXoaSach.UseVisualStyleBackColor = false;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // btnSuaSach
            // 
            this.btnSuaSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnSuaSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaSach.FlatAppearance.BorderSize = 0;
            this.btnSuaSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSuaSach.ForeColor = System.Drawing.Color.White;
            this.btnSuaSach.Location = new System.Drawing.Point(193, 190);
            this.btnSuaSach.Name = "btnSuaSach";
            this.btnSuaSach.Size = new System.Drawing.Size(95, 33);
            this.btnSuaSach.TabIndex = 15;
            this.btnSuaSach.Text = "✏️ Sửa";
            this.btnSuaSach.UseVisualStyleBackColor = false;
            this.btnSuaSach.Click += new System.EventHandler(this.btnSuaSach_Click);
            // 
            // btnThemSach
            // 
            this.btnThemSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnThemSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSach.FlatAppearance.BorderSize = 0;
            this.btnThemSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemSach.ForeColor = System.Drawing.Color.White;
            this.btnThemSach.Location = new System.Drawing.Point(88, 190);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(95, 33);
            this.btnThemSach.TabIndex = 14;
            this.btnThemSach.Text = "➕ Thêm";
            this.btnThemSach.UseVisualStyleBackColor = false;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnChonAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonAnh.FlatAppearance.BorderSize = 0;
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(685, 193);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(130, 30);
            this.btnChonAnh.TabIndex = 13;
            this.btnChonAnh.Text = "📁 Chọn ảnh bìa...";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // picBiaSach
            // 
            this.picBiaSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBiaSach.Location = new System.Drawing.Point(685, 25);
            this.picBiaSach.Name = "picBiaSach";
            this.picBiaSach.Size = new System.Drawing.Size(130, 162);
            this.picBiaSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBiaSach.TabIndex = 12;
            this.picBiaSach.TabStop = false;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoLuong.Location = new System.Drawing.Point(403, 142);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(245, 24);
            this.txtSoLuong.TabIndex = 11;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoLuong.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuong.Location = new System.Drawing.Point(335, 145);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 17);
            this.lblSoLuong.TabIndex = 10;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(88, 142);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(230, 24);
            this.cboTheLoai.TabIndex = 9;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTheLoai.ForeColor = System.Drawing.Color.Black;
            this.lblTheLoai.Location = new System.Drawing.Point(15, 145);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(57, 17);
            this.lblTheLoai.TabIndex = 8;
            this.lblTheLoai.Text = "Thể loại:";
            // 
            // txtNamXB
            // 
            this.txtNamXB.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNamXB.Location = new System.Drawing.Point(403, 103);
            this.txtNamXB.Name = "txtNamXB";
            this.txtNamXB.Size = new System.Drawing.Size(245, 24);
            this.txtNamXB.TabIndex = 7;
            // 
            // lblNamXB
            // 
            this.lblNamXB.AutoSize = true;
            this.lblNamXB.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNamXB.ForeColor = System.Drawing.Color.Black;
            this.lblNamXB.Location = new System.Drawing.Point(335, 106);
            this.lblNamXB.Name = "lblNamXB";
            this.lblNamXB.Size = new System.Drawing.Size(58, 17);
            this.lblNamXB.TabIndex = 6;
            this.lblNamXB.Text = "Năm XB:";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTacGia.Location = new System.Drawing.Point(88, 103);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(230, 24);
            this.txtTacGia.TabIndex = 5;
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTacGia.ForeColor = System.Drawing.Color.Black;
            this.lblTacGia.Location = new System.Drawing.Point(15, 106);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(52, 17);
            this.lblTacGia.TabIndex = 4;
            this.lblTacGia.Text = "Tác giả:";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenSach.Location = new System.Drawing.Point(88, 65);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(560, 24);
            this.txtTenSach.TabIndex = 3;
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenSach.ForeColor = System.Drawing.Color.Black;
            this.lblTenSach.Location = new System.Drawing.Point(15, 68);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(61, 17);
            this.lblTenSach.TabIndex = 2;
            this.lblTenSach.Text = "Tên sách:";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaSach.Location = new System.Drawing.Point(88, 28);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(230, 24);
            this.txtMaSach.TabIndex = 1;
            // 
            // lblMaSach
            // 
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaSach.ForeColor = System.Drawing.Color.Black;
            this.lblMaSach.Location = new System.Drawing.Point(15, 31);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(60, 17);
            this.lblMaSach.TabIndex = 0;
            this.lblMaSach.Text = "Mã sách:";
            // 
            // FrmSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlPhai);
            this.Controls.Add(this.pnlTrai);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Sách và Danh mục Thể loại";
            this.Load += new System.EventHandler(this.FrmSach_Load);
            this.Shown += new System.EventHandler(this.FrmSach_Shown);
            this.pnlTrai.ResumeLayout(false);
            this.grpTheLoai.ResumeLayout(false);
            this.cmsTheLoai.ResumeLayout(false);
            this.grpThaoTacTheLoai.ResumeLayout(false);
            this.grpThaoTacTheLoai.PerformLayout();
            this.pnlPhai.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.grpThongTinSach.ResumeLayout(false);
            this.grpThongTinSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTrai;
        private System.Windows.Forms.GroupBox grpTheLoai;
        private System.Windows.Forms.TreeView tvTheLoai;
        private System.Windows.Forms.GroupBox grpThaoTacTheLoai;
        private System.Windows.Forms.TextBox txtTenTheLoai;
        private System.Windows.Forms.Label lblTenTheLoai;
        private System.Windows.Forms.TextBox txtMaTheLoai;
        private System.Windows.Forms.Label lblMaTheLoai;
        private System.Windows.Forms.Button btnThemGoc;
        private System.Windows.Forms.Button btnThemCon;
        private System.Windows.Forms.Button btnSuaTheLoai;
        private System.Windows.Forms.Button btnXoaTheLoai;
        private System.Windows.Forms.Button btnTatCaSach;
        private System.Windows.Forms.ContextMenuStrip cmsTheLoai;
        private System.Windows.Forms.ToolStripMenuItem tsmThemCon;
        private System.Windows.Forms.ToolStripMenuItem tsmSua;
        private System.Windows.Forms.ToolStripMenuItem tsmXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmThemGoc;
        private System.Windows.Forms.Panel pnlPhai;
        private System.Windows.Forms.GroupBox grpThongTinSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.TextBox txtNamXB;
        private System.Windows.Forms.Label lblNamXB;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.PictureBox picBiaSach;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnSuaSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoiDanhSach;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.ListView lvSach;
        private System.Windows.Forms.ColumnHeader colMa;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colTacGia;
        private System.Windows.Forms.ColumnHeader colNamXB;
        private System.Windows.Forms.ColumnHeader colTheLoai;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colAnh;
    }
}
