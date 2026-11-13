using System;
using System.Configuration;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class FrmCaiDatHeThong : Form
    {
        public FrmCaiDatHeThong()
        {
            InitializeComponent();
        }

        private void FrmCaiDatHeThong_Load(object sender, EventArgs e)
        {
            // Nạp thông tin cấu hình hiện tại từ App.config
            txtTenThuVien.Text = ConfigurationManager.AppSettings["TenThuVien"];
            txtTienPhat.Text = ConfigurationManager.AppSettings["TienPhatMoiNgay"];
            txtThuMucData.Text = DuLieuChung.LayThuMucData();

            lblThongKe.Text = "Thống kê hệ thống hiện hành:\n" +
                              "• " + DuLieuChung.DanhSachSach.Count + " cuốn sách | " +
                              "• " + DuLieuChung.DanhSachTheLoai.Count + " thể loại | " +
                              "• " + DuLieuChung.DanhSachDocGia.Count + " độc giả | " +
                              "• " + DuLieuChung.DanhSachPhieuMuon.Count + " phiếu mượn | " +
                              "• " + DuLieuChung.DanhSachUser.Count + " tài khoản.";
        }

        // Lưu cấu hình vào App.config
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenThuVienMoi = txtTenThuVien.Text.Trim();
            if (string.IsNullOrEmpty(tenThuVienMoi))
            {
                MessageBox.Show("Vui lòng nhập Tên thư viện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuVien.Focus();
                return;
            }

            int tienPhatMoi;
            if (!int.TryParse(txtTienPhat.Text.Trim(), out tienPhatMoi) || tienPhatMoi <= 0)
            {
                MessageBox.Show("Tiền phạt mỗi ngày quá hạn phải là số nguyên dương lớn hơn 0!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienPhat.Focus();
                txtTienPhat.SelectAll();
                return;
            }

            try
            {
                // Cập nhật và lưu trực tiếp vào App.config của ứng dụng
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["TenThuVien"].Value = tenThuVienMoi;
                config.AppSettings.Settings["TienPhatMoiNgay"].Value = tienPhatMoi.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Đã lưu tham số cấu hình hệ thống thành công!\nTên thư viện và mức tiền phạt mới đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DuLieuChung.GhiLog("Lỗi lưu cấu hình: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
