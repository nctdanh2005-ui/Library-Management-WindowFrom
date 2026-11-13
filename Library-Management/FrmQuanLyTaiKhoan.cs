using System;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class FrmQuanLyTaiKhoan : Form
    {
        public FrmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void FrmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Nạp các lựa chọn vai trò vào ComboBox
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("QuanTri");
            cboVaiTro.Items.Add("NhanVien");
            cboVaiTro.SelectedIndex = 1;

            HienThiDanhSach();
        }

        // Hiển thị danh sách tài khoản lên ListView
        private void HienThiDanhSach()
        {
            lvTaiKhoan.Items.Clear();

            foreach (User u in DuLieuChung.DanhSachUser)
            {
                ListViewItem item = new ListViewItem(u.TaiKhoan);
                item.SubItems.Add(u.MatKhau);
                item.SubItems.Add(u.VaiTro);
                item.SubItems.Add(u.VaiTro == "QuanTri" ? "Toàn quyền quản trị hệ thống" : "Nhân viên nghiệp vụ (Bị hạn chế xóa)");
                item.Tag = u;

                lvTaiKhoan.Items.Add(item);
            }
        }

        // Đổ thông tin tài khoản khi click chọn trên ListView
        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0) return;

            ListViewItem item = lvTaiKhoan.SelectedItems[0];
            User u = (User)item.Tag;

            if (u != null)
            {
                txtTaiKhoan.Text = u.TaiKhoan;
                txtMatKhau.Text = u.MatKhau;
                cboVaiTro.SelectedItem = u.VaiTro;
            }
        }

        // Thêm tài khoản mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text.Trim();
            string mk = txtMatKhau.Text;

            if (tk == "" || mk == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên tài khoản và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            // Kiểm tra trùng tài khoản bằng foreach
            bool daTonTai = false;
            foreach (User u in DuLieuChung.DanhSachUser)
            {
                if (u.TaiKhoan.ToLower() == tk.ToLower())
                {
                    daTonTai = true;
                    break;
                }
            }

            if (daTonTai)
            {
                MessageBox.Show("Tên tài khoản '" + tk + "' đã tồn tại! Vui lòng chọn tên khác.", "Cảnh báo trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            string vaiTro = cboVaiTro.SelectedItem != null ? cboVaiTro.SelectedItem.ToString() : "NhanVien";
            User userMoi = new User(tk, mk, vaiTro);

            DuLieuChung.DanhSachUser.Add(userMoi);
            DuLieuChung.GhiUser();

            HienThiDanhSach();
            btnLamMoi_Click(sender, e);
            MessageBox.Show("Thêm tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Cập nhật mật khẩu hoặc vai trò
        private void btnSua_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text.Trim();
            string mk = txtMatKhau.Text;

            if (tk == "" || mk == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa và nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User userSua = null;
            foreach (User u in DuLieuChung.DanhSachUser)
            {
                if (u.TaiKhoan.ToLower() == tk.ToLower())
                {
                    userSua = u;
                    break;
                }
            }

            if (userSua == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản: " + tk, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string vaiTro = cboVaiTro.SelectedItem != null ? cboVaiTro.SelectedItem.ToString() : "NhanVien";
            userSua.MatKhau = mk;
            userSua.VaiTro = vaiTro;

            DuLieuChung.GhiUser();
            HienThiDanhSach();
            MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa tài khoản
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text.Trim();
            if (tk == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ràng buộc bảo mật: Không cho phép tự xóa tài khoản của chính mình đang đăng nhập
            if (DuLieuChung.NguoiDungHienTai != null && tk.ToLower() == DuLieuChung.NguoiDungHienTai.TaiKhoan.ToLower())
            {
                MessageBox.Show("Bạn không thể xóa tài khoản của chính bạn đang đăng nhập vào hệ thống!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản: " + tk + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int i = 0; i < DuLieuChung.DanhSachUser.Count; i++)
                {
                    if (DuLieuChung.DanhSachUser[i].TaiKhoan.ToLower() == tk.ToLower())
                    {
                        DuLieuChung.DanhSachUser.RemoveAt(i);
                        break;
                    }
                }

                DuLieuChung.GhiUser();
                HienThiDanhSach();
                btnLamMoi_Click(sender, e);
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Làm mới các ô nhập liệu
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedIndex = 1;
            txtTaiKhoan.Focus();
        }
    }
}
