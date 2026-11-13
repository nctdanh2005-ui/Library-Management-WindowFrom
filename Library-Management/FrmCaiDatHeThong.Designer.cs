namespace Library_Management
{
    partial class FrmCaiDatHeThong
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTenThuVien = new System.Windows.Forms.Label();
            this.txtTenThuVien = new System.Windows.Forms.TextBox();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblThuMuc = new System.Windows.Forms.Label();
            this.txtThuMucData = new System.Windows.Forms.TextBox();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlTop.Controls.Add(this.lblTieuDe);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(564, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(564, 55);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CÀI ĐẶT THAM SỐ THƯ VIỆN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenThuVien
            // 
            this.lblTenThuVien.AutoSize = true;
            this.lblTenThuVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenThuVien.Location = new System.Drawing.Point(30, 80);
            this.lblTenThuVien.Name = "lblTenThuVien";
            this.lblTenThuVien.Size = new System.Drawing.Size(94, 19);
            this.lblTenThuVien.TabIndex = 1;
            this.lblTenThuVien.Text = "Tên thư viện:";
            // 
            // txtTenThuVien
            // 
            this.txtTenThuVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenThuVien.Location = new System.Drawing.Point(180, 77);
            this.txtTenThuVien.Name = "txtTenThuVien";
            this.txtTenThuVien.Size = new System.Drawing.Size(340, 25);
            this.txtTenThuVien.TabIndex = 2;
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienPhat.Location = new System.Drawing.Point(30, 125);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(138, 19);
            this.lblTienPhat.TabIndex = 3;
            this.lblTienPhat.Text = "Tiền phạt quá hạn:";
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTienPhat.Location = new System.Drawing.Point(180, 122);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(230, 25);
            this.txtTienPhat.TabIndex = 4;
            // 
            // lblDonVi
            // 
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDonVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblDonVi.Location = new System.Drawing.Point(420, 125);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(95, 17);
            this.lblDonVi.TabIndex = 5;
            this.lblDonVi.Text = "VNĐ / 1 ngày trễ";
            // 
            // lblThuMuc
            // 
            this.lblThuMuc.AutoSize = true;
            this.lblThuMuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThuMuc.Location = new System.Drawing.Point(30, 170);
            this.lblThuMuc.Name = "lblThuMuc";
            this.lblThuMuc.Size = new System.Drawing.Size(126, 19);
            this.lblThuMuc.TabIndex = 6;
            this.lblThuMuc.Text = "Thư mục dữ liệu:";
            // 
            // txtThuMucData
            // 
            this.txtThuMucData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.txtThuMucData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtThuMucData.Location = new System.Drawing.Point(180, 168);
            this.txtThuMucData.Name = "txtThuMucData";
            this.txtThuMucData.ReadOnly = true;
            this.txtThuMucData.Size = new System.Drawing.Size(340, 23);
            this.txtThuMucData.TabIndex = 7;
            // 
            // lblThongKe
            // 
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblThongKe.Location = new System.Drawing.Point(30, 215);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(490, 45);
            this.lblThongKe.TabIndex = 8;
            this.lblThongKe.Text = "Thống kê hệ thống...";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(180, 280);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(160, 36);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "💾 Lưu cấu hình";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(360, 280);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(160, 36);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmCaiDatHeThong
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 341);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblThongKe);
            this.Controls.Add(this.txtThuMucData);
            this.Controls.Add(this.lblThuMuc);
            this.Controls.Add(this.lblDonVi);
            this.Controls.Add(this.txtTienPhat);
            this.Controls.Add(this.lblTienPhat);
            this.Controls.Add(this.txtTenThuVien);
            this.Controls.Add(this.lblTenThuVien);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCaiDatHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt tham số hệ thống";
            this.Load += new System.EventHandler(this.FrmCaiDatHeThong_Load);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenThuVien;
        private System.Windows.Forms.TextBox txtTenThuVien;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblThuMuc;
        private System.Windows.Forms.TextBox txtThuMucData;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
    }
}
