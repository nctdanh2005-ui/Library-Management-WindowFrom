using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Library_Management
{
    public partial class FrmDangNhap : Form
    {
        // Biến đếm số lần đăng nhập sai liên tiếp
        private int soLanSai = 0;

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            // 1. Tự động khởi tạo thư mục và dữ liệu mẫu nếu chưa có
            DuLieuChung.KhoiTaoDuLieuMau();

            // 2. Đọc toàn bộ dữ liệu từ 5 file txt lên bộ nhớ (các static List)
            DuLieuChung.DocTatCa();

            // 3. Đọc Registry xem lần trước người dùng có chọn "Ghi nhớ đăng nhập" không
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\QuanLyThuVien");
                if (key != null)
                {
                    object val = key.GetValue("TaiKhoan");
                    if (val != null)
                    {
                        txtTaiKhoan.Text = val.ToString();
                        chkGhiNho.Checked = true;
                        this.ActiveControl = txtMatKhau; // Chuyển con trỏ tới ô Mật khẩu
                    }
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                DuLieuChung.GhiLog("Lỗi đọc Registry: " + ex.Message);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text;

            // Kiểm tra dữ liệu đầu vào không được để trống
            if (taiKhoan == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Tìm kiếm người dùng bằng vòng lặp foreach (không dùng LINQ)
            User userHopLe = null;
            foreach (User u in DuLieuChung.DanhSachUser)
            {
                if (u.TaiKhoan.ToLower() == taiKhoan.ToLower() && u.MatKhau == matKhau)
                {
                    userHopLe = u;
                    break; // Đã tìm thấy, thoát khỏi vòng lặp
                }
            }

            // Xử lý kết quả kiểm tra
            if (userHopLe != null)
            {
                // Đăng nhập thành công -> Lưu người dùng hiện tại
                DuLieuChung.NguoiDungHienTai = userHopLe;

                // Xử lý lưu/xóa Registry theo lựa chọn "Ghi nhớ"
                try
                {
                    if (chkGhiNho.Checked)
                    {
                        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\QuanLyThuVien");
                        if (key != null)
                        {
                            key.SetValue("TaiKhoan", taiKhoan);
                            key.Close();
                        }
                    }
                    else
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\QuanLyThuVien", true);
                        if (key != null)
                        {
                            key.DeleteValue("TaiKhoan", false);
                            key.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    DuLieuChung.GhiLog("Lỗi ghi Registry: " + ex.Message);
                }

                // Ẩn Form đăng nhập và mở Form chính MDI
                this.Hide();
                FrmMain fMain = new FrmMain();
                fMain.ShowDialog();
                this.Close(); // Đóng hẳn khi Main kết thúc
            }
            else
            {
                // Đăng nhập thất bại -> Tăng số lần sai
                soLanSai++;

                if (soLanSai >= 3)
                {
                    btnDangNhap.Enabled = false;
                    MessageBox.Show("Bạn đã nhập sai thông tin 3 lần liên tiếp!\nNút Đăng nhập đã bị khóa để đảm bảo an toàn.", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!\n(Số lần sai: " + soLanSai + "/3)", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi hệ thống?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

