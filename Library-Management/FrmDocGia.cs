using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class FrmDocGia : Form
    {
        // Mã độc giả đang chọn trên ListView (dùng cho Sửa, Xóa, Gia hạn, Khóa/Mở khóa)
        private string maDangChon = "";

        // Cờ hiệu: form đang khởi tạo thì không xử lý sự kiện tìm kiếm / lọc
        private bool dangKhoiTao = false;

        public FrmDocGia()
        {
            InitializeComponent();
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            // Bật cờ chống sự kiện trong lúc đang nạp dữ liệu ban đầu
            dangKhoiTao = true;

            // Trạng thái mặc định khi thêm mới là "HoatDong"
            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }

            // Tự động nạp danh sách các lớp KHÔNG TRÙNG LẶP vào ComboBox
            NapComboBoxLop();

            // Đổ dữ liệu từ docgia.txt (qua DuLieuChung.DanhSachDocGia) lên ListView
            HienThiDanhSachDocGia();

            dangKhoiTao = false;
        }

        // ================= HIỂN THỊ DANH SÁCH LÊN LISTVIEW =================

        // Đổ dữ liệu từ DuLieuChung.DanhSachDocGia lên ListView (kiểu Details)
        // Kết hợp: LỌC THEO LỚP + TÌM THEO HỌ TÊN + TÔ MÀU CẢNH BÁO HẠN THẺ
        private void HienThiDanhSachDocGia()
        {
            lvDocGia.Items.Clear();

            // Từ khóa tìm theo họ tên (đã chuyển về chữ thường)
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            // Lớp đang chọn để lọc (mặc định mục đầu tiên là "Tất cả lớp")
            string lopLoc = "";
            if (cboLop.SelectedIndex > 0 && cboLop.SelectedItem != null)
            {
                lopLoc = cboLop.SelectedItem.ToString();
            }

            DateTime homNay = DateTime.Now;

            foreach (DocGia dg in DuLieuChung.DanhSachDocGia)
            {
                // 1. Lọc theo lớp
                if (lopLoc != "" && dg.Lop != lopLoc)
                {
                    continue;
                }

                // 2. Tìm kiếm theo HoTen (yêu cầu đề bài: .ToLower().Contains())
                if (tuKhoa != "" && !dg.HoTen.ToLower().Contains(tuKhoa))
                {
                    continue;
                }

                ListViewItem item = new ListViewItem(dg.Ma);
                item.SubItems.Add(dg.HoTen);
                item.SubItems.Add(dg.Lop);
                item.SubItems.Add(dg.NgayHetHan.ToString("dd/MM/yyyy"));
                item.SubItems.Add(dg.TrangThai);
                item.Tag = dg;

                // 3. Tô màu cảnh báo NGAY KHI DUYỆT TỪNG DÒNG:
                //    - Hết hạn HOẶC bị khóa  -> nền hồng (LightPink)
                //    - Sắp hết hạn (còn dưới 7 ngày) -> nền vàng (LightYellow)
                int soNgayConLai = (dg.NgayHetHan.Date - homNay.Date).Days;
                if (dg.TrangThai == "BiKhoa" || soNgayConLai < 0)
                {
                    item.BackColor = Color.LightPink;
                }
                else if (soNgayConLai < 7)
                {
                    item.BackColor = Color.LightYellow;
                }

                lvDocGia.Items.Add(item);
            }
        }

        // Tự động nạp danh sách các lớp KHÔNG TRÙNG LẶP vào ComboBox lọc
        private void NapComboBoxLop()
        {
            // Giữ lại lớp đang chọn (nếu còn)
            string lopDangChon = "";
            if (cboLop.SelectedItem != null)
            {
                lopDangChon = cboLop.SelectedItem.ToString();
            }

            cboLop.Items.Clear();
            cboLop.Items.Add("Tất cả lớp");

            // Thu thập các lớp khác nhau bằng vòng lặp foreach
            List<string> dsLop = new List<string>();
            foreach (DocGia dg in DuLieuChung.DanhSachDocGia)
            {
                if (!string.IsNullOrEmpty(dg.Lop) && !dsLop.Contains(dg.Lop))
                {
                    dsLop.Add(dg.Lop);
                }
            }
            dsLop.Sort();

            foreach (string lop in dsLop)
            {
                cboLop.Items.Add(lop);
            }

            // Chọn lại lớp cũ, không có thì về "Tất cả lớp"
            int viTri = 0;
            for (int i = 0; i < cboLop.Items.Count; i++)
            {
                if (cboLop.Items[i].ToString() == lopDangChon)
                {
                    viTri = i;
                    break;
                }
            }
            cboLop.SelectedIndex = viTri;
        }

        // ================= TÌM KIẾM & LỌC THEO LỚP =================

        // Tìm theo họ tên ngay khi người dùng gõ (hoặc bấm nút Tìm)
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao)
            {
                return;
            }
            HienThiDanhSachDocGia();
        }

        // Nhấn Enter trong ô tìm kiếm cũng thực hiện tìm kiếm
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HienThiDanhSachDocGia();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSachDocGia();
        }

        // Chọn lớp nào thì ListView chỉ hiện độc giả của lớp đó
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao)
            {
                return;
            }
            HienThiDanhSachDocGia();
        }

        // Xóa tìm kiếm + lọc lớp để hiện toàn bộ độc giả
        private void btnTatCa_Click(object sender, EventArgs e)
        {
            dangKhoiTao = true;
            txtTimKiem.Clear();
            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0;
            }
            dangKhoiTao = false;

            HienThiDanhSachDocGia();
            txtTimKiem.Focus();
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

            // Cập nhật lại ComboBox lớp (phát sinh lớp mới nếu có)
            NapComboBoxLop();

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

            // Cập nhật lại ComboBox lớp (độc giả có thể chuyển lớp)
            NapComboBoxLop();

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

                // Cập nhật lại ComboBox lớp (lớp có thể không còn độc giả)
                NapComboBoxLop();

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

        // Làm mới / nhập lại dữ liệu trên form (xóa tìm kiếm và lọc lớp)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dangKhoiTao = true;
            txtTimKiem.Clear();
            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0;
            }
            dangKhoiTao = false;

            HienThiDanhSachDocGia();
            LamMoiNhapLieu();
            txtMaDocGia.Focus();
        }

        // ================= XUẤT CSV (YÊU CẦU CHUNG SỐ 6) =================

        // Xuất danh sách độc giả ĐANG HIỂN THỊ trên ListView ra file .csv (UTF-8)
        private void btnXuatCSV_Click(object sender, EventArgs e)
        {
            if (lvDocGia.Items.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu độc giả để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách độc giả ra file CSV";
                sfd.Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*";
                sfd.FileName = "danh sach doc gia.csv";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    // UTF-8 có BOM để Excel mở không lỗi tiếng Việt
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        sw.WriteLine("Ma,HoTen,Lop,NgayHetHan,TrangThai");

                        foreach (ListViewItem item in lvDocGia.Items)
                        {
                            string dong = TaoCSV(item.Text) + "," +
                                          TaoCSV(item.SubItems[1].Text) + "," +
                                          TaoCSV(item.SubItems[2].Text) + "," +
                                          TaoCSV(item.SubItems[3].Text) + "," +
                                          TaoCSV(item.SubItems[4].Text);
                            sw.WriteLine(dong);
                        }
                    }

                    MessageBox.Show("Đã xuất " + lvDocGia.Items.Count + " độc giả ra file:\n" + sfd.FileName,
                        "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DuLieuChung.GhiLog("Lỗi xuất CSV độc giả: " + ex.Message);
                }
            }
        }

        // Escape 1 trường dữ liệu theo chuẩn CSV
        private string TaoCSV(string giaTri)
        {
            if (giaTri.Contains(",") || giaTri.Contains("\"") || giaTri.Contains(";"))
            {
                return "\"" + giaTri.Replace("\"", "\"\"") + "\"";
            }
            return giaTri;
        }

        // ================= IN THẺ ĐỘC GIẢ (ĐIỂM CỘNG) =================

        // Xuất thông tin chi tiết 1 độc giả đang chọn ra file .txt dạng khung thẻ thư viện
        private void btnInThe_Click(object sender, EventArgs e)
        {
            if (lvDocGia.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 độc giả trên danh sách để in thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGia dg = (DocGia)lvDocGia.SelectedItems[0].Tag;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "In thẻ độc giả";
                sfd.Filter = "Tập tin văn bản (*.txt)|*.txt";
                sfd.FileName = "the doc gia " + dg.Ma + ".txt";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    int rong = 56; // chiều rộng bên trong khung thẻ
                    StringBuilder sb = new StringBuilder();
                    string vien = "+" + new string('-', rong) + "+";

                    sb.AppendLine(vien);
                    sb.AppendLine("|" + CanGiua("THẺ ĐỘC GIẢ - THƯ VIỆN ĐẠI HỌC", rong) + "|");
                    sb.AppendLine(vien);
                    ThemDongThe(sb, "Mã độc giả", dg.Ma, rong);
                    ThemDongThe(sb, "Họ và tên", dg.HoTen, rong);
                    ThemDongThe(sb, "Lớp", dg.Lop, rong);
                    ThemDongThe(sb, "Ngày hết hạn", dg.NgayHetHan.ToString("dd/MM/yyyy"), rong);
                    ThemDongThe(sb, "Trạng thái", dg.TrangThai, rong);

                    // Tính tình trạng thẻ theo ngày hiện tại
                    int soNgayConLai = (dg.NgayHetHan.Date - DateTime.Now.Date).Days;
                    string tinhTrang;
                    if (dg.TrangThai == "BiKhoa")
                    {
                        tinhTrang = "Thẻ bị khóa";
                    }
                    else if (soNgayConLai < 0)
                    {
                        tinhTrang = "ĐÃ HẾT HẠN";
                    }
                    else if (soNgayConLai < 7)
                    {
                        tinhTrang = "SẮP HẾT HẠN (còn " + soNgayConLai + " ngày)";
                    }
                    else
                    {
                        tinhTrang = "Còn " + soNgayConLai + " ngày sử dụng";
                    }
                    ThemDongThe(sb, "Tình trạng", tinhTrang, rong);

                    sb.AppendLine(vien);
                    ThemDongThe(sb, "Ngày in", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), rong);
                    sb.AppendLine(vien);

                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        sw.Write(sb.ToString());
                    }

                    MessageBox.Show("Đã xuất thẻ độc giả ra file:\n" + sfd.FileName,
                        "In thẻ thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi in thẻ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DuLieuChung.GhiLog("Lỗi in thẻ độc giả " + dg.Ma + ": " + ex.Message);
                }
            }
        }

        // Thêm 1 dòng thông tin vào khung thẻ (căn cột cho đều)
        private void ThemDongThe(StringBuilder sb, string tenNhan, string noiDung, int rong)
        {
            int toiDa = rong - 19;
            if (noiDung.Length > toiDa)
            {
                noiDung = noiDung.Substring(0, toiDa - 3) + "...";
            }
            string dong = "|  " + (tenNhan + ":").PadRight(16) + noiDung;
            sb.AppendLine(dong.PadRight(rong + 1) + "|");
        }

        // Căn giữa 1 chuỗi trong khung thẻ có chiều rộng cho trước
        private string CanGiua(string chuoi, int rong)
        {
            if (chuoi.Length >= rong)
            {
                return chuoi.Substring(0, rong);
            }
            int le = (rong - chuoi.Length) / 2;
            return new string(' ', le) + chuoi + new string(' ', rong - chuoi.Length - le);
        }
    }
}
