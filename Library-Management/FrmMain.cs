using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Library_Management
{
    public partial class FrmMain : Form
    {
        // ================= TÙY CHỈNH GIAO DIỆN (COLOR / FONT DIALOG + REGISTRY) =================

        // Khóa lưu giao diện trong Registry: HKEY_CURRENT_USER\Software\LibraryManagement\GiaoDien
        private const string KhoaRegistry = @"Software\LibraryManagement\GiaoDien";

        // Màu nền và phông chữ mặc định của chương trình
        private readonly Color mauNenMacDinh = Color.White;
        private readonly Font fontMacDinh = new Font("Segoe UI", 9.5F);

        // Màu nền và phông chữ đang được áp dụng hiện tại
        private Color mauNenHienTai;
        private Font fontHienTai;

        public FrmMain()
        {
            InitializeComponent();

            mauNenHienTai = mauNenMacDinh;
            fontHienTai = fontMacDinh;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 0. Tải màu nền, phông chữ, kích thước và vị trí cửa sổ đã lưu ở lần mở trước
            TaiGiaoDienTuRegistry();

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

            // Chưa mở thì thiết lập Form cha MDI, áp dụng giao diện đang chọn và hiển thị
            formCon.MdiParent = this;
            formCon.BackColor = mauNenHienTai;
            ApDungFontTrenControl(formCon, fontHienTai);
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

            // Lưu màu nền, phông chữ, kích thước và vị trí cửa sổ vào Registry
            if (!e.Cancel)
            {
                LuuGiaoDienLenRegistry();
            }
        }

        // ================= CHỨC NĂNG CHỌN MÀU NỀN VÀ PHÔNG CHỮ =================

        // Chọn màu nền cho chương trình bằng ColorDialog
        private void mnuChonMauNen_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = mauNenHienTai;
                cd.FullOpen = true;

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    ApDungMauNen(cd.Color);
                    LuuGiaoDienLenRegistry();
                }
            }
        }

        // Chọn phông chữ cho chương trình bằng FontDialog
        private void mnuChonPhonChu_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.Font = fontHienTai;
                fd.ShowColor = false;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    // Tạo 1 bản sao Font mới để không phụ thuộc vào FontDialog
                    Font phMoi = new Font(fd.Font.FontFamily, fd.Font.Size, fd.Font.Style, fd.Font.Unit);
                    ApDungFont(phMoi);
                    LuuGiaoDienLenRegistry();
                }
            }
        }

        // Đặt lại màu nền và phông chữ về trạng thái mặc định
        private void mnuDatLaiGiaoDien_Click(object sender, EventArgs e)
        {
            ApDungMauNen(mauNenMacDinh);
            ApDungFont(fontMacDinh);
            LuuGiaoDienLenRegistry();

            MessageBox.Show("Đã đặt lại màu nền và phông chữ về trạng thái mặc định!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Áp dụng màu nền cho cửa sổ chính và các cửa sổ con đang mở
        private void ApDungMauNen(Color mau)
        {
            mauNenHienTai = mau;
            this.BackColor = mau;

            foreach (Form child in this.MdiChildren)
            {
                child.BackColor = mau;
            }
        }

        // Áp dụng phông chữ cho 1 control và toàn bộ control con của nó (đệ quy)
        private void ApDungFontTrenControl(Control cha, Font ph)
        {
            if (cha == null || ph == null)
            {
                return;
            }

            cha.Font = ph;
            foreach (Control con in cha.Controls)
            {
                ApDungFontTrenControl(con, ph);
            }
        }

        // Áp dụng phông chữ cho cửa sổ chính, menu, thanh trạng thái và các cửa sổ con
        private void ApDungFont(Font ph)
        {
            fontHienTai = ph;
            ApDungFontTrenControl(this, ph);

            foreach (Form child in this.MdiChildren)
            {
                ApDungFontTrenControl(child, ph);
            }
        }

        // ================= LƯU / TẢI GIAO DIỆN TỪ REGISTRY =================

        // Tải màu nền, phông chữ, kích thước và vị trí cửa sổ từ Registry (lần mở app)
        private void TaiGiaoDienTuRegistry()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(KhoaRegistry))
                {
                    if (key == null)
                    {
                        return; // Chưa từng lưu -> giữ nguyên giao diện mặc định
                    }

                    // 1. Màu nền (lưu dạng số ARGB)
                    object giaTriMau = key.GetValue("MauNen");
                    if (giaTriMau != null)
                    {
                        ApDungMauNen(Color.FromArgb(Convert.ToInt32(giaTriMau)));
                    }

                    // 2. Phông chữ (tên phông + cỡ chữ)
                    string tenFont = key.GetValue("FontFamily") as string;
                    float kichThuoc = 0;
                    object giaTriSize = key.GetValue("FontSize");
                    if (giaTriSize != null)
                    {
                        float.TryParse(giaTriSize.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out kichThuoc);
                    }

                    // Chỉ áp dụng nếu máy vẫn còn cài phông chữ đó
                    bool fontTonTai = false;
                    if (!string.IsNullOrEmpty(tenFont) && kichThuoc > 0)
                    {
                        foreach (FontFamily ff in FontFamily.Families)
                        {
                            if (ff.Name == tenFont)
                            {
                                fontTonTai = true;
                                break;
                            }
                        }
                    }
                    if (fontTonTai)
                    {
                        ApDungFont(new Font(tenFont, kichThuoc));
                    }

                    // 3. Kích thước và vị trí cửa sổ
                    object oX = key.GetValue("CuaSoX");
                    object oY = key.GetValue("CuaSoY");
                    object oRong = key.GetValue("CuaSoRong");
                    object oCao = key.GetValue("CuaSoCao");

                    if (oX != null && oY != null && oRong != null && oCao != null)
                    {
                        int x, y, rong, cao;
                        if (int.TryParse(oX.ToString(), out x) &&
                            int.TryParse(oY.ToString(), out y) &&
                            int.TryParse(oRong.ToString(), out rong) &&
                            int.TryParse(oCao.ToString(), out cao) &&
                            rong >= 400 && cao >= 300)
                        {
                            // Chỉ áp dụng nếu cửa sổ vẫn nằm trên 1 màn hình nào đó
                            Rectangle goc = new Rectangle(x, y, rong, cao);
                            bool trenManHinh = false;
                            foreach (Screen sc in Screen.AllScreens)
                            {
                                if (sc.WorkingArea.IntersectsWith(goc))
                                {
                                    trenManHinh = true;
                                    break;
                                }
                            }

                            if (trenManHinh)
                            {
                                this.StartPosition = FormStartPosition.Manual;
                                this.Bounds = goc;
                            }
                        }
                    }

                    // 4. Trạng thái thu nhỏ / phóng to cửa sổ
                    int trangThai = 0;
                    object oTrangThai = key.GetValue("CuaSoTrangThai");
                    if (oTrangThai != null)
                    {
                        int.TryParse(oTrangThai.ToString(), out trangThai);
                    }
                    if (trangThai == 1)
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                }
            }
            catch (Exception ex)
            {
                DuLieuChung.GhiLog("Lỗi tải giao diện từ Registry: " + ex.Message);
            }
        }

        // Lưu màu nền, phông chữ, kích thước và vị trí cửa sổ vào Registry
        private void LuuGiaoDienLenRegistry()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KhoaRegistry))
                {
                    key.SetValue("MauNen", mauNenHienTai.ToArgb(), RegistryValueKind.DWord);
                    key.SetValue("FontFamily", fontHienTai.FontFamily.Name, RegistryValueKind.String);
                    key.SetValue("FontSize", fontHienTai.Size.ToString(CultureInfo.InvariantCulture), RegistryValueKind.String);

                    // Đang phóng to thì lưu kích thước lúc thu nhỏ (RestoreBounds)
                    Rectangle goc = (this.WindowState == FormWindowState.Normal) ? this.Bounds : this.RestoreBounds;

                    key.SetValue("CuaSoX", goc.X, RegistryValueKind.DWord);
                    key.SetValue("CuaSoY", goc.Y, RegistryValueKind.DWord);
                    key.SetValue("CuaSoRong", goc.Width, RegistryValueKind.DWord);
                    key.SetValue("CuaSoCao", goc.Height, RegistryValueKind.DWord);
                    key.SetValue("CuaSoTrangThai", this.WindowState == FormWindowState.Maximized ? 1 : 0, RegistryValueKind.DWord);
                }
            }
            catch (Exception ex)
            {
                DuLieuChung.GhiLog("Lỗi lưu giao diện vào Registry: " + ex.Message);
            }
        }
    }
}

