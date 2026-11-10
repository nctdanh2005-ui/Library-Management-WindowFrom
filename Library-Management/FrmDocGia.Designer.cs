namespace Library_Management
{
    partial class FrmDocGia
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
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblThongBao
            // 
            this.lblThongBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblThongBao.Location = new System.Drawing.Point(0, 0);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(800, 100);
            this.lblThongBao.TabIndex = 0;
            this.lblThongBao.Text = "PHÂN HỆ QUẢN LÝ ĐỘC GIẢ\r\n(Sinh viên 2 phụ trách thực hiện)";
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblHuongDan.Location = new System.Drawing.Point(0, 100);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(800, 350);
            this.lblHuongDan.TabIndex = 1;
            this.lblHuongDan.Text = "Khung giao diện và dữ liệu mẫu (docgia.txt) đã được SV1 chuẩn bị sẵn trong DuLieuChung.\r\nSV2 kéo source về và bắt đầu xây dựng giao diện cùng các chức năng Thêm, Sửa, Xóa, Tìm kiếm độc giả tại Form này.";
            this.lblHuongDan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.lblThongBao);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Độc giả";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label lblHuongDan;
    }
}

