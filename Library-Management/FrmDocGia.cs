using System;
using System.Globalization;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class FrmDocGia : Form
    {
        // Mã độc giả đang chọn trên ListView (dùng cho Sửa, Xóa, Gia hạn, Khóa/Mở khóa)
        private string maDangChon = "";

        public FrmDocGia()
        {
            InitializeComponent();
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            // Trạng thái mặc định khi thêm mới là "HoatDong"
            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }

            // Đổ dữ liệu từ docgia.txt (qua DuLieuChung.DanhSachDocGia) lên ListView
            HienThiDanhSachDocGia();
        }

        // ================= HIỂN THỊ DANH SÁCH LÊN LISTVIEW =================

        // Đổ dữ liệu từ DuLieuChung.DanhSachDocGia lên ListView (kiểu Details)
        private void HienThiDanhSachDocGia()
        {
            lvDocGia.Items.Clear();

            foreach (DocGia dg in DuLieuChung.DanhSachDocGia)
            {
                ListViewItem item = new ListViewItem(dg.Ma);
                item.SubItems.Add(dg.HoTen);
                item.SubItems.Add(dg.Lop);
                item.SubItems.Add(dg.NgayHetHan.ToString("dd/MM/yyyy"));
                item.SubItems.Add(dg.TrangThai);
                item.Tag = dg;

                lvDocGia.Items.Add(item);
            }
        }

        // Tìm đối tượng Độc giả theo mã (vòng lặp foreach)
        private DocGia TimDocGia(string ma)
        {
            foreach (DocGia dg in DuLieuChung.DanhSachDocGia)
            {
                if (dg.Ma.ToLower() == ma.ToLower())
                {
                    return dg;
                }
            }
            return null;
        }

        // Khi người dùng click chọn 1 dòng trên ListView
        private void lvDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDocGia.SelectedItems.Count == 0)
            {
                return;
            }

            DocGia dg = (DocGia)lvDocGia.SelectedItems[0].Tag;
            maDangChon = dg.Ma;

            txtMaDocGia.Text = dg.Ma;
            txtHoTen.Text = dg.HoTen;
            txtLop.Text = dg.Lop;
            txtNgayHetHan.Text = dg.NgayHetHan.ToString("dd/MM/yyyy");

            // Chọn đúng trạng thái trong ComboBox
            cboTrangThai.SelectedItem = dg.TrangThai;

            CapNhatNutKhoaMoKhoa();
        }

        // Cập nhật chữ trên nút Khóa / Mở khóa theo trạng thái thẻ hiện tại
        private void CapNhatNutKhoaMoKhoa()
        {
            DocGia dg = (maDangChon == "") ? null : TimDocGia(maDangChon);
            if (dg != null && dg.TrangThai == "BiKhoa")
            {
                btnKhoaMoKhoa.Text = "🔓 Mở khóa thẻ";
            }
            else
            {
                btnKhoaMoKhoa.Text = "🔒 Khóa / Mở khóa";
            }
        }

        // Xóa trắng các ô nhập liệu và bỏ chọn trên ListView
        private void LamMoiNhapLieu()
        {
            maDangChon = "";
            txtMaDocGia.Clear();
            txtHoTen.Clear();
            txtLop.Clear();
            txtNgayHetHan.Clear();
            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }
            CapNhatNutKhoaMoKhoa();
        }

        // ================= THÊM, SỬA, XÓA ĐỘC GIẢ =================

        // Thêm độc giả mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra các ô không được để trống và .Focus() về ô sai
            string ma = txtMaDocGia.Text.Trim();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng nhập Mã độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGia.Focus();
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            if (hoTen == "")
            {
                MessageBox.Show("Vui lòng nhập Họ và tên độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            string lop = txtLop.Text.Trim();
            if (lop == "")
            {
                MessageBox.Show("Vui lòng nhập Lớp của độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLop.Focus();
                return;
            }

            // 2. Kiểm tra ngày hết hạn theo định dạng dd/MM/yyyy
            DateTime ngayHetHan;
            if (!DateTime.TryParseExact(txtNgayHetHan.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayHetHan))
            {
                MessageBox.Show("Ngày hết hạn không hợp lệ!\nVui lòng nhập theo định dạng dd/MM/yyyy (ví dụ: 31/12/2026).", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayHetHan.Focus();
                txtNgayHetHan.SelectAll();
                return;
            }

            // 3. Kiểm tra trùng mã độc giả bằng vòng lặp foreach
            if (TimDocGia(ma) != null)
            {
                MessageBox.Show("Mã độc giả '" + ma + "' đã tồn tại! Vui lòng nhập mã khác.", "Cảnh báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGia.Focus();
                txtMaDocGia.SelectAll();
                return;
            }

            string trangThai = (cboTrangThai.SelectedItem != null) ? cboTrangThai.SelectedItem.ToString() : "HoatDong";

            // Tạo đối tượng độc giả mới và thêm vào danh sách chung
            DocGia dgMoi = new DocGia(ma, hoTen, lop, ngayHetHan, trangThai);
            DuLieuChung.DanhSachDocGia.Add(dgMoi);

            // Ghi đè file docgia.txt
            DuLieuChung.GhiDocGia();

            HienThiDanhSachDocGia();
            LamMoiNhapLieu();
            MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sửa thông tin độc giả đang chọn
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn độc giả cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra các ô nhập liệu
            string maMoi = txtMaDocGia.Text.Trim();
            if (maMoi == "")
            {
                MessageBox.Show("Vui lòng nhập Mã độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGia.Focus();
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            if (hoTen == "")
            {
                MessageBox.Show("Vui lòng nhập Họ và tên độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            string lop = txtLop.Text.Trim();
            if (lop == "")
            {
                MessageBox.Show("Vui lòng nhập Lớp của độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLop.Focus();
                return;
            }

            DateTime ngayHetHan;
            if (!DateTime.TryParseExact(txtNgayHetHan.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayHetHan))
            {
                MessageBox.Show("Ngày hết hạn không hợp lệ!\nVui lòng nhập theo định dạng dd/MM/yyyy (ví dụ: 31/12/2026).", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayHetHan.Focus();
                txtNgayHetHan.SelectAll();
                return;
            }

            DocGia dgSua = TimDocGia(maDangChon);
            if (dgSua == null)
            {
                MessageBox.Show("Không tìm thấy độc giả có mã: " + maDangChon, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu đổi mã thì phải kiểm tra mã mới không được trùng với mã khác
            if (maMoi.ToLower() != maDangChon.ToLower())
            {
                if (TimDocGia(maMoi) != null)
                {
                    MessageBox.Show("Mã độc giả '" + maMoi + "' đã tồn tại! Vui lòng nhập mã khác.", "Cảnh báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDocGia.Focus();
                    txtMaDocGia.SelectAll();
                    return;
                }
            }

            // Cập nhật thông tin
            dgSua.Ma = maMoi;
            dgSua.HoTen = hoTen;
            dgSua.Lop = lop;
            dgSua.NgayHetHan = ngayHetHan;
            dgSua.TrangThai = (cboTrangThai.SelectedItem != null) ? cboTrangThai.SelectedItem.ToString() : dgSua.TrangThai;

            // Ghi đè file docgia.txt
            DuLieuChung.GhiDocGia();

            maDangChon = maMoi;
            HienThiDanhSachDocGia();
            CapNhatNutKhoaMoKhoa();
            MessageBox.Show("Cập nhật thông tin độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa độc giả đang chọn (hỏi xác nhận MessageBox)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGia dgXoa = TimDocGia(maDangChon);
            if (dgXoa == null)
            {
                MessageBox.Show("Không tìm thấy độc giả có mã: " + maDangChon, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hỏi xác nhận trước khi xóa
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa độc giả:\n'" + dgXoa.HoTen + "' (Mã: " + dgXoa.Ma + ")?",
                "Xác nhận xóa độc giả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                DuLieuChung.DanhSachDocGia.Remove(dgXoa);

                // Ghi đè file docgia.txt
                DuLieuChung.GhiDocGia();

                LamMoiNhapLieu();
                HienThiDanhSachDocGia();
                MessageBox.Show("Đã xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ================= GIA HẠN THẺ & KHÓA / MỞ KHÓA =================

        // Gia hạn thẻ: cộng thêm 6 tháng hoặc 1 năm vào NgayHetHan bằng .AddMonths()
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (maDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn độc giả cần gia hạn thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGia dg = TimDocGia(maDangChon);
            if (dg == null)
            {
                MessageBox.Show("Không tìm thấy độc giả có mã: " + maDangChon, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hỏi người dùng thời gian gia hạn: Có = 6 tháng, Không = 1 năm, Hủy = thôi
            DialogResult dr = MessageBox.Show(
                "Chọn thời gian gia hạn thẻ cho:\n" + dg.HoTen + " (" + dg.Ma + ")\n\n" +
                "- Bấm CÓ: cộng thêm 6 THÁNG\n" +
                "- Bấm KHÔNG: cộng thêm 1 NĂM\n" +
                "- Bấm HUY: không gia hạn",
                "Gia hạn thẻ độc giả",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Cancel)
            {
                return;
            }

            int soThang = (dr == DialogResult.Yes) ? 6 : 12;

            // Thẻ đã hết hạn thì tính hạn mới từ hôm nay, thẻ còn hạn thì cộng thêm vào hạn cũ
            DateTime dungLamGoc = dg.NgayHetHan;
            if (dg.NgayHetHan.Date < DateTime.Now.Date)
            {
                dungLamGoc = DateTime.Now;
            }

            // Yêu cầu đề bài: dùng hàm .AddMonths()
            dg.NgayHetHan = dungLamGoc.AddMonths(soThang);

            // Ghi đè file docgia.txt và cập nhật lại List
            DuLieuChung.GhiDocGia();

            HienThiDanhSachDocGia();
            txtNgayHetHan.Text = dg.NgayHetHan.ToString("dd/MM/yyyy");

            MessageBox.Show(
                "Đã gia hạn thêm " + soThang + " tháng cho " + dg.HoTen + "!\n" +
                "Ngày hết hạn mới: " + dg.NgayHetHan.ToString("dd/MM/yyyy"),
                "Gia hạn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Khóa / Mở khóa thẻ: chuyển nhanh TrangThai giữa "HoatDong" và "BiKhoa"
        private void btnKhoaMoKhoa_Click(object sender, EventArgs e)
        {
            if (maDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn thẻ cần khóa hoặc mở khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGia dg = TimDocGia(maDangChon);
            if (dg == null)
            {
                MessageBox.Show("Không tìm thấy độc giả có mã: " + maDangChon, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dg.TrangThai == "BiKhoa")
            {
                dg.TrangThai = "HoatDong";
            }
            else
            {
                dg.TrangThai = "BiKhoa";
            }

            // Ghi đè file docgia.txt
            DuLieuChung.GhiDocGia();

            HienThiDanhSachDocGia();
            cboTrangThai.SelectedItem = dg.TrangThai;
            CapNhatNutKhoaMoKhoa();

            MessageBox.Show(
                (dg.TrangThai == "BiKhoa" ? "Đã KHÓA thẻ của " : "Đã MỞ KHÓA thẻ của ") + dg.HoTen + "!",
                "Trạng thái thẻ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Làm mới / nhập lại dữ liệu trên form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiNhapLieu();
            txtMaDocGia.Focus();
        }
    }
}
