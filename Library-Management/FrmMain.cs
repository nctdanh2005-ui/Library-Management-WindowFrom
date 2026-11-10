using System;
using System.Configuration;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 1. Đọc tên thư viện từ App.config và gán vào StatusStrip
            string tenThuVien = ConfigurationManager.AppSettings["TenThuVien"];
            if (!string.IsNullOrEmpty(tenThuVien))
            {
                lblTenThuVien.Text = tenThuVien;
            }

            // 2. Hiển thị thông tin người dùng đang đăng nhập
            if (DuLieuChung.NguoiDungHienTai != null)
            {
                lblNguoiDung.Text = "Người dùng: " + DuLieuChung.NguoiDungHienTai.TaiKhoan + 
                                    " (" + (DuLieuChung.NguoiDungHienTai.VaiTro == "QuanTri" ? "Quản trị viên" : "Nhân viên") + ")";

                // 3. Phân quyền người dùng: Nhân viên thì vô hiệu hóa mục Quản trị hệ thống
                if (DuLieuChung.NguoiDungHienTai.VaiTro == "NhanVien")
                {
                    mnuQuanTri.Enabled = false;
                }
                else
                {
                    mnuQuanTri.Enabled = true;
                }
            }

            // 4. Khởi tạo đồng hồ ban đầu
            lblDongHo.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // 5. Tự động mở phân hệ Quản lý Sách khi khởi động
            mnuSach_Click(sender, e);
        }

        // Cập nhật đồng hồ mỗi giây qua Timer
        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // Hàm mở Form con chống trùng lặp (duyệt foreach qua MdiChildren)
        private void MoFormCon(Form formCon)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == formCon.GetType())
                {
                    child.Activate(); // Đã mở rồi thì kích hoạt hiển thị lên trên
                    return;
                }
            }

            // Chưa mở thì thiết lập Form cha MDI và hiển thị
            formCon.MdiParent = this;
            formCon.Show();
        }

        // Mở Form Sách (Phân hệ chính của SV1)
        private void mnuSach_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmSach());
        }

        // Mở Form Độc giả (Chờ SV2 làm tiếp)
        private void mnuDocGia_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmDocGia());
        }

        // Mở Form Mượn Trả (Chờ SV3 làm tiếp)
        private void mnuMuonTra_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmMuonTra());
        }

        // Chức năng quản trị hệ thống
        private void mnuCauHinhHeThong_Click(object sender, EventArgs e)
        {
            string thongTin = "CẤU HÌNH HỆ THỐNG HIỆN TẠI:\n\n" +
                              "- Tên thư viện: " + ConfigurationManager.AppSettings["TenThuVien"] + "\n" +
                              "- Thư mục dữ liệu: " + ConfigurationManager.AppSettings["ThuMucData"] + "\n" +
                              "- Tiền phạt mỗi ngày quá hạn: " + ConfigurationManager.AppSettings["TienPhatMoiNgay"] + " VNĐ\n" +
                              "- Tổng số đầu sách: " + DuLieuChung.DanhSachSach.Count + "\n" +
                              "- Tổng số độc giả: " + DuLieuChung.DanhSachDocGia.Count;
            MessageBox.Show(thongTin, "Quản trị hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sắp xếp cửa sổ con theo tầng (Cascade)
        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        // Sắp xếp cửa sổ con theo chiều ngang (Tile Horizontal)
        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        // Sắp xếp cửa sổ con theo chiều dọc (Tile Vertical)
        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        // Đóng tất cả các form con đang mở
        private void mnuDongTatCa_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        // Đăng xuất khỏi hệ thống
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất tài khoản hiện tại?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DuLieuChung.NguoiDungHienTai = null;
                this.Hide();

                FrmDangNhap fLogin = new FrmDangNhap();
                fLogin.ShowDialog();

                this.Close();
            }
        }

        // Thoát phần mềm
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DuLieuChung.NguoiDungHienTai != null)
            {
                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát chương trình Quản lý Thư viện?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

