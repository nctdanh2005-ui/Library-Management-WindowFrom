using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class FrmMuonTra : Form
    {
        // Số phiếu đang chọn trên ListView (dùng cho Trả sách, Tính phạt, Xóa, In)
        private string soPhieuDangChon = "";

        // Cờ hiệu: form đang khởi tạo thì không xử lý sự kiện tìm kiếm / lọc
        private bool dangKhoiTao = false;

        // Số ngày mượn mặc định khi lập phiếu mới
        private const int SoNgayMuonMacDinh = 14;

        // Số ngày còn lại tối đa để tô vàng cảnh báo "sắp đến hạn"
        private const int SoNgayCanhBao = 3;

        public FrmMuonTra()
        {
            InitializeComponent();
        }

        private void FrmMuonTra_Load(object sender, EventArgs e)
        {
            dangKhoiTao = true;

            // 1. Nạp danh mục độc giả và sách vào ComboBox
            NapComboBoxDocGia();
            NapComboBoxSach();

            // 2. Mặc định lọc "Tất cả"
            if (cboLocTrangThai.Items.Count > 0)
            {
                cboLocTrangThai.SelectedIndex = 0;
            }

            // 3. Đưa ngày mượn / hạn trả mặc định vào ô nhập
            DatNgayMacDinh();
            DatTrangThaiThongTinPhieu(true);

            // 4. Hiển thị danh sách phiếu mượn
            HienThiDanhSachPhieuMuon();
            CapNhatThongKe();

            // Phân quyền: Nhân viên không được phép xóa lịch sử phiếu mượn (chỉ Quản trị viên mới được xóa)
            if (DuLieuChung.NguoiDungHienTai != null && DuLieuChung.NguoiDungHienTai.VaiTro == "NhanVien")
            {
                btnXoaPhieu.Enabled = false;
                btnXoaPhieu.Text = "🗑️ Xóa (Chỉ Admin)";
            }

            dangKhoiTao = false;
        }

        // ================= NẠP DỮ LIỆU VÀO COMBOBOX =================

        // Nạp toàn bộ độc giả vào ComboBox (hiển thị dạng "Mã - Họ tên" qua ToString)
        private void NapComboBoxDocGia()
        {
            string maDangChon = "";
            if (cboDocGia.SelectedItem != null)
            {
                DocGia dgCu = (DocGia)cboDocGia.SelectedItem;
                maDangChon = dgCu.Ma;
            }

            cboDocGia.Items.Clear();
            foreach (DocGia dg in DuLieuChung.DanhSachDocGia)
            {
                cboDocGia.Items.Add(dg);
            }

            // Chọn lại độc giả cũ nếu còn trong danh sách
            if (maDangChon != "")
            {
                for (int i = 0; i < cboDocGia.Items.Count; i++)
                {
                    DocGia dg = (DocGia)cboDocGia.Items[i];
                    if (dg.Ma == maDangChon)
                    {
                        cboDocGia.SelectedIndex = i;
                        return;
                    }
                }
            }

            if (cboDocGia.Items.Count > 0 && cboDocGia.SelectedIndex < 0)
            {
                cboDocGia.SelectedIndex = 0;
            }
        }

        // Nạp toàn bộ sách vào ComboBox (hiển thị dạng "Mã - Tên sách" qua ToString)
        private void NapComboBoxSach()
        {
            string maDangChon = "";
            if (cboSach.SelectedItem != null)
            {
                Sach sachCu = (Sach)cboSach.SelectedItem;
                maDangChon = sachCu.Ma;
            }

            cboSach.Items.Clear();
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                cboSach.Items.Add(s);
            }

            if (maDangChon != "")
            {
                for (int i = 0; i < cboSach.Items.Count; i++)
                {
                    Sach s = (Sach)cboSach.Items[i];
                    if (s.Ma == maDangChon)
                    {
                        cboSach.SelectedIndex = i;
                        return;
                    }
                }
            }

            if (cboSach.Items.Count > 0 && cboSach.SelectedIndex < 0)
            {
                cboSach.SelectedIndex = 0;
            }
        }

        // Gán ngày mượn = hôm nay, hạn trả = hôm nay + 14 ngày
        private void DatNgayMacDinh()
        {
            txtNgayMuon.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHanTra.Text = DateTime.Now.AddDays(SoNgayMuonMacDinh).ToString("dd/MM/yyyy");
            txtNgayTra.Clear();
            txtSoPhieu.Text = TaoSoPhieuMoi();
        }

        // Khóa phần thông tin khi đang xem một phiếu đã chọn trong danh sách.
        // Ô Ngày trả luôn mở để nhân viên nhập ngày trả thực tế khi trả sách.
        private void DatTrangThaiThongTinPhieu(bool choPhepChinhSua)
        {
            txtSoPhieu.Enabled = choPhepChinhSua;
            cboDocGia.Enabled = choPhepChinhSua;
            cboSach.Enabled = choPhepChinhSua;
            txtNgayMuon.Enabled = choPhepChinhSua;
            txtHanTra.Enabled = choPhepChinhSua;
        }

        // Đưa phần nhập liệu về chế độ lập phiếu mới
        private void ChuyenSangLapPhieuMoi()
        {
            soPhieuDangChon = "";
            DatNgayMacDinh();
            DatTrangThaiThongTinPhieu(true);
        }

        // Sinh số phiếu mới dạng PMxxx dựa trên số lớn nhất đang có
        private string TaoSoPhieuMoi()
        {
            int soLonNhat = 0;
            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                string so = pm.SoPhieu.Trim().ToUpper();
                if (so.StartsWith("PM"))
                {
                    int giaTri;
                    if (int.TryParse(so.Substring(2), out giaTri))
                    {
                        if (giaTri > soLonNhat)
                        {
                            soLonNhat = giaTri;
                        }
                    }
                }
            }

            int soMoi = soLonNhat + 1;
            return "PM" + soMoi.ToString("000");
        }

        // ================= HIỂN THỊ DANH SÁCH =================

        // Đổ dữ liệu phiếu mượn lên ListView: tìm kiếm + lọc trạng thái + tô màu cảnh báo
        private void HienThiDanhSachPhieuMuon()
        {
            // Tự động tính tiền phạt cho phiếu quá hạn chưa trả (theo ngày hiện tại)
            DuLieuChung.CapNhatTienPhatQuaHan();

            lvPhieuMuon.Items.Clear();

            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            string trangThaiLoc = "Tất cả";
            if (cboLocTrangThai.SelectedItem != null)
            {
                trangThaiLoc = cboLocTrangThai.SelectedItem.ToString();
            }

            DateTime homNay = DateTime.Now.Date;

            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                bool daTra = (pm.NgayTra.Trim() != "");

                // 1. Lọc theo trạng thái
                if (trangThaiLoc == "Đã trả" && !daTra)
                {
                    continue;
                }
                if (trangThaiLoc == "Đang mượn" && (daTra || pm.HanTra.Date < homNay))
                {
                    continue;
                }
                if (trangThaiLoc == "Quá hạn" && (daTra || pm.HanTra.Date >= homNay))
                {
                    continue;
                }

                // 2. Tìm kiếm theo số phiếu / mã độc giả / họ tên / mã sách / tên sách
                if (tuKhoa != "")
                {
                    DocGia dg = TimDocGia(pm.MaDocGia);
                    Sach sach = TimSach(pm.MaSach);

                    string chuoiTim = pm.SoPhieu.ToLower() + " " + pm.MaDocGia.ToLower();
                    if (dg != null)
                    {
                        chuoiTim = chuoiTim + " " + dg.HoTen.ToLower();
                    }
                    chuoiTim = chuoiTim + " " + pm.MaSach.ToLower();
                    if (sach != null)
                    {
                        chuoiTim = chuoiTim + " " + sach.Ten.ToLower();
                    }

                    if (!chuoiTim.Contains(tuKhoa))
                    {
                        continue;
                    }
                }

                // 3. Tạo dòng trên ListView
                ListViewItem item = new ListViewItem(pm.SoPhieu);
                item.SubItems.Add((TimDocGia(pm.MaDocGia) != null) ? TimDocGia(pm.MaDocGia).HoTen : pm.MaDocGia);
                item.SubItems.Add((TimSach(pm.MaSach) != null) ? TimSach(pm.MaSach).Ten : pm.MaSach);
                item.SubItems.Add(pm.NgayMuon.ToString("dd/MM/yyyy"));
                item.SubItems.Add(pm.HanTra.ToString("dd/MM/yyyy"));
                item.SubItems.Add(daTra ? pm.NgayTra : "");
                item.SubItems.Add(DinhDangTien(pm.TienPhat));
                item.SubItems.Add(TrangThaiHienThi(pm, homNay));
                item.Tag = pm;

                // 4. Tô màu cảnh báo:
                //    - Đã trả                        -> nền xanh lá nhạt
                //    - Chưa trả và đã quá hạn        -> nền hồng
                //    - Chưa trả, sắp đến hạn (<3 ngày) -> nền vàng
                if (daTra)
                {
                    item.BackColor = Color.FromArgb(232, 248, 240);
                }
                else if (pm.HanTra.Date < homNay)
                {
                    item.BackColor = Color.LightPink;
                }
                else if ((pm.HanTra.Date - homNay).Days <= SoNgayCanhBao)
                {
                    item.BackColor = Color.LightYellow;
                }

                lvPhieuMuon.Items.Add(item);
            }
        }

        // Trả về chuỗi trạng thái hiển thị của phiếu
        private string TrangThaiHienThi(PhieuMuon pm, DateTime homNay)
        {
            if (pm.NgayTra.Trim() != "")
            {
                return "Đã trả";
            }
            if (pm.HanTra.Date < homNay)
            {
                return "Quá hạn";
            }
            return "Đang mượn";
        }

        // Cập nhật nhãn thống kê nhanh ở khung thao tác
        private void CapNhatThongKe()
        {
            DateTime homNay = DateTime.Now.Date;
            int tongSo = DuLieuChung.DanhSachPhieuMuon.Count;
            int dangMuon = 0;
            int quaHan = 0;
            int daTra = 0;
            int tongPhat = 0;
            int phatChuaThu = 0;

            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                if (pm.NgayTra.Trim() != "")
                {
                    daTra++;
                    tongPhat = tongPhat + pm.TienPhat; // phiếu đã trả: tiền phạt đã chốt và thu
                }
                else if (pm.HanTra.Date < homNay)
                {
                    quaHan++;
                    phatChuaThu = phatChuaThu + pm.TienPhat; // phạt tự tính đến hôm nay, chưa thu
                }
                else
                {
                    dangMuon++;
                }
            }

            lblThongKe.Text = "Tổng số phiếu: " + tongSo.ToString() + "   |   Đã trả: " + daTra.ToString() + "\r\n" +
                              "Đang mượn: " + dangMuon.ToString() + "   |   Quá hạn: " + quaHan.ToString() + "\r\n" +
                              "Phạt đã thu: " + DinhDangTien(tongPhat) + "\r\n" +
                              "Phạt quá hạn chưa thu: " + DinhDangTien(phatChuaThu);
        }

        // Định dạng tiền tệ kiểu Việt Nam (1.250.000)
        private string DinhDangTien(int soTien)
        {
            return soTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
        }

        // Tìm sách theo mã bằng vòng lặp foreach
        private Sach TimSach(string ma)
        {
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                if (s.Ma.ToLower() == ma.ToLower())
                {
                    return s;
                }
            }
            return null;
        }

        // Tìm độc giả theo mã bằng vòng lặp foreach
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

        // Tìm phiếu mượn theo số phiếu
        private PhieuMuon TimPhieuMuon(string soPhieu)
        {
            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                if (pm.SoPhieu.ToLower() == soPhieu.ToLower())
                {
                    return pm;
                }
            }
            return null;
        }

        // Đọc tiền phạt mỗi ngày quá hạn từ App.config (mặc định 5000 đồng)
        private int LayTienPhatMoiNgay()
        {
            return DuLieuChung.LayTienPhatMoiNgay();
        }

        // ================= TÌM KIẾM VÀ LỌC =================

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao)
            {
                return;
            }
            HienThiDanhSachPhieuMuon();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HienThiDanhSachPhieuMuon();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSachPhieuMuon();
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao)
            {
                return;
            }
            HienThiDanhSachPhieuMuon();
        }

        // Xóa tìm kiếm + lọc trạng thái để xem toàn bộ phiếu
        private void btnTatCa_Click(object sender, EventArgs e)
        {
            dangKhoiTao = true;
            txtTimKiem.Clear();
            if (cboLocTrangThai.Items.Count > 0)
            {
                cboLocTrangThai.SelectedIndex = 0;
            }
            dangKhoiTao = false;

            HienThiDanhSachPhieuMuon();
            txtTimKiem.Focus();
        }

        // Khi chọn 1 dòng trên ListView thì đổ dữ liệu lên phần nhập liệu
        private void lvPhieuMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhieuMuon.SelectedItems.Count == 0)
            {
                // Bỏ chọn (hoặc danh sách vừa nạp lại) -> quay về chế độ lập phiếu mới
                if (soPhieuDangChon != "")
                {
                    ChuyenSangLapPhieuMoi();
                }
                return;
            }

            PhieuMuon pm = (PhieuMuon)lvPhieuMuon.SelectedItems[0].Tag;
            soPhieuDangChon = pm.SoPhieu;

            txtSoPhieu.Text = pm.SoPhieu;
            txtNgayMuon.Text = pm.NgayMuon.ToString("dd/MM/yyyy");
            txtHanTra.Text = pm.HanTra.ToString("dd/MM/yyyy");
            txtNgayTra.Text = pm.NgayTra;

            // Chọn đúng độc giả và sách của phiếu trong ComboBox
            ChonDocGiaTrongCombo(pm.MaDocGia);
            ChonSachTrongCombo(pm.MaSach);
            DatTrangThaiThongTinPhieu(false);
        }

        private void ChonDocGiaTrongCombo(string maDocGia)
        {
            for (int i = 0; i < cboDocGia.Items.Count; i++)
            {
                DocGia dg = (DocGia)cboDocGia.Items[i];
                if (dg.Ma.ToLower() == maDocGia.ToLower())
                {
                    cboDocGia.SelectedIndex = i;
                    return;
                }
            }
        }

        private void ChonSachTrongCombo(string maSach)
        {
            for (int i = 0; i < cboSach.Items.Count; i++)
            {
                Sach s = (Sach)cboSach.Items[i];
                if (s.Ma.ToLower() == maSach.ToLower())
                {
                    cboSach.SelectedIndex = i;
                    return;
                }
            }
        }

        // Hiển thị tồn kho của sách đang chọn
        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedItem == null)
            {
                lblTonKho.Text = "Tồn kho: --\r\nBỏ trống Ngày trả khi lập phiếu = chưa trả";
                return;
            }

            Sach s = (Sach)cboSach.SelectedItem;
            lblTonKho.Text = "Tồn kho: " + s.SoLuong.ToString() + " cuốn   |   Năm XB: " + s.NamXB.ToString() +
                             "\r\nBỏ trống Ngày trả khi lập phiếu = chưa trả";

            if (s.SoLuong <= 0)
            {
                lblTonKho.ForeColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                lblTonKho.ForeColor = Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            }
        }

        // ================= LẬP PHIẾU MƯỢN =================

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            // 0. Đang xem 1 phiếu cũ thì không lập phiếu từ dữ liệu của phiếu đó
            if (soPhieuDangChon != "")
            {
                MessageBox.Show("Bạn đang xem phiếu " + soPhieuDangChon + ".\nPhần thông tin đã được đưa về chế độ lập phiếu mới, vui lòng chọn độc giả và sách rồi bấm Lập phiếu lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvPhieuMuon.SelectedItems.Clear();
                ChuyenSangLapPhieuMoi();
                cboDocGia.Focus();
                return;
            }

            // 1. Kiểm tra đã chọn độc giả và sách chưa
            if (cboDocGia.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả mượn sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDocGia.Focus();
                return;
            }
            if (cboSach.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSach.Focus();
                return;
            }

            DocGia dg = (DocGia)cboDocGia.SelectedItem;
            Sach sach = (Sach)cboSach.SelectedItem;

            // 2. Kiểm tra điều kiện thẻ độc giả
            if (dg.TrangThai == "BiKhoa")
            {
                MessageBox.Show("Thẻ của độc giả '" + dg.HoTen + "' đang bị KHÓA!\nVui lòng mở khóa thẻ ở phân hệ Độc giả trước khi cho mượn.",
                    "Thẻ bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dg.NgayHetHan.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Thẻ của độc giả '" + dg.HoTen + "' đã HẾT HẠN ngày " + dg.NgayHetHan.ToString("dd/MM/yyyy") + "!\nVui lòng gia hạn thẻ trước khi cho mượn.",
                    "Thẻ hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2b. Không cho mượn khi độc giả đang giữ sách quá hạn chưa trả
            List<PhieuMuon> dsQuaHan = DuLieuChung.LayPhieuQuaHanCuaDocGia(dg.Ma);
            if (dsQuaHan.Count > 0)
            {
                StringBuilder sbQuaHan = new StringBuilder();
                foreach (PhieuMuon pmQH in dsQuaHan)
                {
                    Sach sachQH = TimSach(pmQH.MaSach);
                    int soNgayTre = (DateTime.Now.Date - pmQH.HanTra.Date).Days;
                    sbQuaHan.AppendLine("  • " + pmQH.SoPhieu + " - " + ((sachQH != null) ? sachQH.Ten : pmQH.MaSach) +
                                        " (hạn " + pmQH.HanTra.ToString("dd/MM/yyyy") + ", trễ " + soNgayTre + " ngày, phạt " +
                                        DinhDangTien(DuLieuChung.TinhTienPhat(pmQH, DateTime.Now.Date)) + ")");
                }
                MessageBox.Show("Độc giả '" + dg.HoTen + "' đang giữ " + dsQuaHan.Count + " cuốn sách QUÁ HẠN chưa trả:\n\n" +
                    sbQuaHan.ToString() + "\nVui lòng trả sách quá hạn trước khi mượn tiếp.",
                    "Đang giữ sách quá hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2c. Mỗi độc giả chỉ được giữ tối đa 5 cuốn chưa trả
            int soDangMuon = DuLieuChung.DemSachDangMuon(dg.Ma);
            if (soDangMuon >= DuLieuChung.SoSachMuonToiDa)
            {
                MessageBox.Show("Độc giả '" + dg.HoTen + "' đang mượn " + soDangMuon + " cuốn chưa trả.\n" +
                    "Mỗi độc giả chỉ được mượn tối đa " + DuLieuChung.SoSachMuonToiDa + " cuốn cùng lúc!",
                    "Vượt số lượng cho phép", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Kiểm tra tồn kho sách: hết sách thì gợi ý đặt trước
            if (sach.SoLuong <= 0)
            {
                DialogResult drDat = MessageBox.Show("Sách '" + sach.Ten + "' hiện đã được mượn hết (tồn kho = 0)!\n\n" +
                    "Bạn có muốn ĐẶT TRƯỚC cuốn sách này cho độc giả '" + dg.HoTen + "' không?\n" +
                    "Khi có người trả, độc giả sẽ được ưu tiên mượn theo thứ tự đặt.",
                    "Hết sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drDat == DialogResult.Yes)
                {
                    DatTruocSach(dg, sach);
                }
                return;
            }

            // 3b. Sách đang có người đặt trước: chỉ những người đứng đầu hàng chờ (trong phạm vi tồn kho) được mượn
            List<DatTruoc> hangCho = DuLieuChung.LayHangChoDatTruoc(sach.Ma);
            int viTriTrongHang = -1;
            for (int i = 0; i < hangCho.Count; i++)
            {
                if (hangCho[i].MaDocGia.ToLower() == dg.Ma.ToLower())
                {
                    viTriTrongHang = i;
                    break;
                }
            }
            int soNguoiUuTien = (viTriTrongHang >= 0) ? viTriTrongHang : hangCho.Count;
            if (soNguoiUuTien >= sach.SoLuong)
            {
                MessageBox.Show("Sách '" + sach.Ten + "' còn " + sach.SoLuong + " cuốn nhưng đang được giữ cho " + hangCho.Count +
                    " độc giả đặt trước (người đầu tiên: " + hangCho[0].MaDocGia + ").\n" +
                    "Độc giả '" + dg.HoTen + "' chưa đến lượt mượn cuốn này.",
                    "Sách đang được giữ chỗ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Kiểm tra độc giả đang mượn cuốn sách này mà chưa trả
            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                if (pm.MaDocGia.ToLower() == dg.Ma.ToLower() &&
                    pm.MaSach.ToLower() == sach.Ma.ToLower() &&
                    pm.NgayTra.Trim() == "")
                {
                    MessageBox.Show("Độc giả '" + dg.HoTen + "' đang mượn cuốn sách này (phiếu " + pm.SoPhieu + ") và chưa trả!",
                        "Trùng phiếu mượn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 5. Kiểm tra ngày mượn / hạn trả theo định dạng dd/MM/yyyy
            DateTime ngayMuon;
            if (!DateTime.TryParseExact(txtNgayMuon.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayMuon))
            {
                MessageBox.Show("Ngày mượn không hợp lệ!\nVui lòng nhập theo định dạng dd/MM/yyyy (ví dụ: 13/11/2026).",
                    "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayMuon.Focus();
                txtNgayMuon.SelectAll();
                return;
            }

            DateTime hanTra;
            if (!DateTime.TryParseExact(txtHanTra.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out hanTra))
            {
                MessageBox.Show("Hạn trả không hợp lệ!\nVui lòng nhập theo định dạng dd/MM/yyyy (ví dụ: 27/11/2026).",
                    "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHanTra.Focus();
                txtHanTra.SelectAll();
                return;
            }

            if (hanTra.Date < ngayMuon.Date)
            {
                MessageBox.Show("Hạn trả phải lớn hơn hoặc bằng ngày mượn!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHanTra.Focus();
                txtHanTra.SelectAll();
                return;
            }

            // 6. Tạo phiếu mượn mới
            string soPhieu = TaoSoPhieuMoi();
            PhieuMuon phieuMoi = new PhieuMuon(soPhieu, dg.Ma, sach.Ma, ngayMuon, hanTra, "", 0);
            DuLieuChung.DanhSachPhieuMuon.Add(phieuMoi);

            // 7. Trừ tồn kho 1 cuốn và ghi cả hai file dữ liệu
            sach.SoLuong = sach.SoLuong - 1;
            DuLieuChung.GhiPhieuMuon();
            DuLieuChung.GhiSach();

            // 7b. Nếu độc giả có đặt trước cuốn này thì đánh dấu đã nhận sách
            if (viTriTrongHang >= 0)
            {
                hangCho[viTriTrongHang].TrangThai = "DaNhan";
                DuLieuChung.GhiDatTruoc();
            }

            // 8. Làm mới giao diện
            ChuyenSangLapPhieuMoi();
            NapComboBoxSach();
            HienThiDanhSachPhieuMuon();
            CapNhatThongKe();
            cboSach_SelectedIndexChanged(sender, e);

            MessageBox.Show(
                "Lập phiếu mượn thành công!\n\n" +
                "- Số phiếu: " + soPhieu + "\n" +
                "- Độc giả: " + dg.HoTen + " (" + dg.Ma + ")\n" +
                "- Sách: " + sach.Ten + "\n" +
                "- Ngày mượn: " + ngayMuon.ToString("dd/MM/yyyy") + "\n" +
                "- Hạn trả: " + hanTra.ToString("dd/MM/yyyy") + "\n" +
                "- Tồn kho còn lại: " + sach.SoLuong.ToString() + " cuốn",
                "Lập phiếu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= TRẢ SÁCH =================

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (soPhieuDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần trả từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuMuon pm = TimPhieuMuon(soPhieuDangChon);
            if (pm == null)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn số: " + soPhieuDangChon, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pm.NgayTra.Trim() != "")
            {
                MessageBox.Show("Phiếu " + pm.SoPhieu + " đã được trả ngày " + pm.NgayTra + " rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ngày trả do người dùng nhập, rỗng thì lấy hôm nay
            DateTime ngayTra;
            if (txtNgayTra.Text.Trim() == "")
            {
                ngayTra = DateTime.Now.Date;
            }
            else if (!DateTime.TryParseExact(txtNgayTra.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayTra))
            {
                MessageBox.Show("Ngày trả không hợp lệ!\nVui lòng nhập theo định dạng dd/MM/yyyy hoặc để trống để lấy ngày hôm nay.",
                    "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayTra.Focus();
                txtNgayTra.SelectAll();
                return;
            }

            if (ngayTra.Date < pm.NgayMuon.Date)
            {
                MessageBox.Show("Ngày trả không thể trước ngày mượn (" + pm.NgayMuon.ToString("dd/MM/yyyy") + ")!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayTra.Focus();
                txtNgayTra.SelectAll();
                return;
            }

            // Tính tiền phạt theo số ngày quá hạn và cấu hình TienPhatMoiNgay
            int tienPhatMoiNgay = LayTienPhatMoiNgay();
            int soNgayQuaHan = Math.Max(0, (ngayTra.Date - pm.HanTra.Date).Days);
            int tienPhat = DuLieuChung.TinhTienPhat(pm, ngayTra);

            DocGia dg = TimDocGia(pm.MaDocGia);
            Sach sach = TimSach(pm.MaSach);

            string thongTin = "XÁC NHẬN TRẢ SÁCH\n\n" +
                              "- Phiếu: " + pm.SoPhieu + "\n" +
                              "- Độc giả: " + ((dg != null) ? dg.HoTen : pm.MaDocGia) + "\n" +
                              "- Sách: " + ((sach != null) ? sach.Ten : pm.MaSach) + "\n" +
                              "- Hạn trả: " + pm.HanTra.ToString("dd/MM/yyyy") + "\n" +
                              "- Ngày trả: " + ngayTra.ToString("dd/MM/yyyy") + "\n\n" +
                              "- Số ngày quá hạn: " + soNgayQuaHan.ToString() + " ngày\n" +
                              "- Tiền phạt mỗi ngày: " + DinhDangTien(tienPhatMoiNgay) + "\n" +
                              "- Tổng tiền phạt: " + DinhDangTien(tienPhat) + "\n\n" +
                              "Đồng ý trả sách?";

            DialogResult dr = MessageBox.Show(thongTin, "Xác nhận trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            // 1. Cập nhật phiếu mượn
            pm.NgayTra = ngayTra.ToString("dd/MM/yyyy");
            pm.TienPhat = tienPhat;

            // 2. Cộng lại 1 cuốn vào tồn kho sách
            if (sach != null)
            {
                sach.SoLuong = sach.SoLuong + 1;
            }

            // 3. Ghi đè file dữ liệu
            DuLieuChung.GhiPhieuMuon();
            DuLieuChung.GhiSach();

            // 4. Làm mới giao diện
            HienThiDanhSachPhieuMuon();
            CapNhatThongKe();
            NapComboBoxSach();
            cboSach_SelectedIndexChanged(sender, e);

            // 5. Báo nếu cuốn vừa trả đang có độc giả đặt trước
            string thongBaoDatTruoc = "";
            List<DatTruoc> hangCho = DuLieuChung.LayHangChoDatTruoc(pm.MaSach);
            if (hangCho.Count > 0)
            {
                DocGia dgCho = TimDocGia(hangCho[0].MaDocGia);
                thongBaoDatTruoc = "\n\n📌 Sách này đang có " + hangCho.Count + " độc giả đặt trước.\n" +
                                   "Hãy giữ sách và liên hệ người đầu hàng chờ: " +
                                   ((dgCho != null) ? dgCho.HoTen + " (" + dgCho.Ma + ")" : hangCho[0].MaDocGia) +
                                   ", đặt ngày " + hangCho[0].NgayDat.ToString("dd/MM/yyyy") + ".";
            }

            MessageBox.Show(
                "Trả sách thành công!\n" +
                "- Số ngày quá hạn: " + soNgayQuaHan.ToString() + " ngày\n" +
                "- Tiền phạt phải thu: " + DinhDangTien(tienPhat) +
                thongBaoDatTruoc,
                "Trả sách thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= ĐẶT TRƯỚC SÁCH (ĐIỂM CỘNG) =================

        // Bấm nút Đặt trước: dùng độc giả + sách đang chọn trên phần nhập liệu
        private void btnDatTruoc_Click(object sender, EventArgs e)
        {
            if (soPhieuDangChon != "")
            {
                lvPhieuMuon.SelectedItems.Clear();
                ChuyenSangLapPhieuMoi();
            }
            if (cboDocGia.SelectedItem == null || cboSach.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả và sách cần đặt trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGia dg = (DocGia)cboDocGia.SelectedItem;
            Sach sach = (Sach)cboSach.SelectedItem;

            if (sach.SoLuong > 0)
            {
                MessageBox.Show("Sách '" + sach.Ten + "' vẫn còn " + sach.SoLuong + " cuốn trong kho.\n" +
                    "Chỉ đặt trước được sách đang được mượn hết. Hãy lập phiếu mượn trực tiếp.",
                    "Không cần đặt trước", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatTruocSach(dg, sach);
        }

        // Tạo 1 yêu cầu đặt trước sau khi kiểm tra điều kiện thẻ và trùng lặp
        private void DatTruocSach(DocGia dg, Sach sach)
        {
            if (dg.TrangThai == "BiKhoa" || dg.NgayHetHan.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Thẻ của độc giả '" + dg.HoTen + "' đang bị khóa hoặc đã hết hạn, không thể đặt trước!",
                    "Không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                if (pm.MaDocGia.ToLower() == dg.Ma.ToLower() && pm.MaSach.ToLower() == sach.Ma.ToLower() && DuLieuChung.ChuaTra(pm))
                {
                    MessageBox.Show("Độc giả '" + dg.HoTen + "' đang mượn chính cuốn sách này (phiếu " + pm.SoPhieu + ")!",
                        "Không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            List<DatTruoc> hangCho = DuLieuChung.LayHangChoDatTruoc(sach.Ma);
            foreach (DatTruoc dtCu in hangCho)
            {
                if (dtCu.MaDocGia.ToLower() == dg.Ma.ToLower())
                {
                    MessageBox.Show("Độc giả '" + dg.HoTen + "' đã đặt trước cuốn sách này (mã " + dtCu.MaDat + ") rồi!",
                        "Trùng đặt trước", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DatTruoc dt = new DatTruoc(TaoMaDatTruocMoi(), dg.Ma, sach.Ma, DateTime.Now.Date, "ChoNhan");
            DuLieuChung.DanhSachDatTruoc.Add(dt);
            DuLieuChung.GhiDatTruoc();

            MessageBox.Show("Đặt trước thành công!\n\n" +
                "- Mã đặt trước: " + dt.MaDat + "\n" +
                "- Độc giả: " + dg.HoTen + " (" + dg.Ma + ")\n" +
                "- Sách: " + sach.Ten + "\n" +
                "- Vị trí trong hàng chờ: " + (hangCho.Count + 1),
                "Đặt trước sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sinh mã đặt trước mới dạng DTxxx
        private string TaoMaDatTruocMoi()
        {
            int soLonNhat = 0;
            foreach (DatTruoc dt in DuLieuChung.DanhSachDatTruoc)
            {
                string ma = dt.MaDat.Trim().ToUpper();
                int giaTri;
                if (ma.StartsWith("DT") && int.TryParse(ma.Substring(2), out giaTri) && giaTri > soLonNhat)
                {
                    soLonNhat = giaTri;
                }
            }
            return "DT" + (soLonNhat + 1).ToString("000");
        }

        // Mở form thống kê / báo cáo mượn trả (độc giả quá hạn, theo thể loại, sách ít mượn, đặt trước)
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            using (FrmBaoCaoMuonTra f = new FrmBaoCaoMuonTra())
            {
                f.ShowDialog(this);
            }
            // Form báo cáo có thể hủy đặt trước -> nạp lại hiển thị
            HienThiDanhSachPhieuMuon();
            CapNhatThongKe();
        }

        // ================= XÓA PHIẾU MƯỢN =================

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (soPhieuDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuMuon pm = TimPhieuMuon(soPhieuDangChon);
            if (pm == null)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn số: " + soPhieuDangChon, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Phiếu chưa trả thì khi xóa phải hoàn lại 1 cuốn vào kho
            bool daTra = (pm.NgayTra.Trim() != "");
            string canhBao = daTra ? "" : "\n\nLưu ý: Phiếu chưa trả, xóa sẽ HOÀN LẠI 1 cuốn vào tồn kho.";

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phiếu mượn:\n'" + pm.SoPhieu + "' của độc giả " + pm.MaDocGia + "?" + canhBao,
                "Xác nhận xóa phiếu mượn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            if (!daTra)
            {
                Sach sach = TimSach(pm.MaSach);
                if (sach != null)
                {
                    sach.SoLuong = sach.SoLuong + 1;
                }
            }

            DuLieuChung.DanhSachPhieuMuon.Remove(pm);
            DuLieuChung.GhiPhieuMuon();
            DuLieuChung.GhiSach();

            soPhieuDangChon = "";
            DatNgayMacDinh();
            DatTrangThaiThongTinPhieu(true);
            NapComboBoxSach();
            HienThiDanhSachPhieuMuon();
            CapNhatThongKe();
            cboSach_SelectedIndexChanged(sender, e);

            MessageBox.Show("Đã xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= LÀM MỚI =================

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dangKhoiTao = true;
            txtTimKiem.Clear();
            if (cboLocTrangThai.Items.Count > 0)
            {
                cboLocTrangThai.SelectedIndex = 0;
            }
            dangKhoiTao = false;

            // Đọc lại dữ liệu từ file để đồng bộ với các phân hệ khác
            DuLieuChung.DocTheLoai();
            DuLieuChung.DocSach();
            DuLieuChung.DocDocGia();
            DuLieuChung.DocPhieuMuon();
            DuLieuChung.DocDatTruoc();

            soPhieuDangChon = "";
            NapComboBoxDocGia();
            NapComboBoxSach();
            DatNgayMacDinh();
            DatTrangThaiThongTinPhieu(true);
            HienThiDanhSachPhieuMuon();
            CapNhatThongKe();
            cboSach_SelectedIndexChanged(sender, e);

            cboDocGia.Focus();
        }

        // ================= XUẤT CSV =================

        private void btnXuatCSV_Click(object sender, EventArgs e)
        {
            if (lvPhieuMuon.Items.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phiếu mượn để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách phiếu mượn ra file CSV";
                sfd.Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*";
                sfd.FileName = "danh sach phieu muon.csv";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    // Dùng ký tự phân cách theo cài đặt vùng Windows để Excel tự tách cột
                    DuLieuChung.XuatListViewRaCSV(lvPhieuMuon, sfd.FileName);

                    MessageBox.Show("Đã xuất " + lvPhieuMuon.Items.Count + " phiếu mượn ra file:\n" + sfd.FileName,
                        "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DuLieuChung.GhiLog("Lỗi xuất CSV phiếu mượn: " + ex.Message);
                }
            }
        }

        // ================= IN PHIẾU MƯỢN (ĐIỂM CỘNG) =================

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (lvPhieuMuon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu mượn trên danh sách để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuMuon pm = (PhieuMuon)lvPhieuMuon.SelectedItems[0].Tag;
            DocGia dg = TimDocGia(pm.MaDocGia);
            Sach sach = TimSach(pm.MaSach);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "In phiếu mượn sách";
                sfd.Filter = "Tập tin văn bản (*.txt)|*.txt";
                sfd.FileName = "phieu muon " + pm.SoPhieu + ".txt";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    int rong = 56;
                    StringBuilder sb = new StringBuilder();
                    string vien = "+" + new string('-', rong) + "+";

                    sb.AppendLine(vien);
                    sb.AppendLine("|" + CanGiua("PHIẾU MƯỢN SÁCH - THƯ VIỆN ĐẠI HỌC", rong) + "|");
                    sb.AppendLine(vien);
                    ThemDongPhieu(sb, "Số phiếu", pm.SoPhieu, rong);
                    ThemDongPhieu(sb, "Mã độc giả", pm.MaDocGia, rong);
                    ThemDongPhieu(sb, "Họ và tên", (dg != null) ? dg.HoTen : "", rong);
                    ThemDongPhieu(sb, "Lớp", (dg != null) ? dg.Lop : "", rong);
                    sb.AppendLine(vien);
                    ThemDongPhieu(sb, "Mã sách", pm.MaSach, rong);
                    ThemDongPhieu(sb, "Tên sách", (sach != null) ? sach.Ten : "", rong);
                    ThemDongPhieu(sb, "Tác giả", (sach != null) ? sach.TacGia : "", rong);
                    sb.AppendLine(vien);
                    ThemDongPhieu(sb, "Ngày mượn", pm.NgayMuon.ToString("dd/MM/yyyy"), rong);
                    ThemDongPhieu(sb, "Hạn trả", pm.HanTra.ToString("dd/MM/yyyy"), rong);
                    ThemDongPhieu(sb, "Ngày trả", (pm.NgayTra.Trim() != "") ? pm.NgayTra : "(chưa trả)", rong);

                    // Trạng thái và tiền phạt theo ngày hiện tại
                    DateTime homNay = DateTime.Now.Date;
                    string trangThai = TrangThaiHienThi(pm, homNay);
                    ThemDongPhieu(sb, "Trạng thái", trangThai, rong);

                    if (pm.NgayTra.Trim() != "")
                    {
                        ThemDongPhieu(sb, "Tiền phạt", DinhDangTien(pm.TienPhat), rong);
                    }
                    else
                    {
                        int soNgayTre = (homNay - pm.HanTra.Date).Days;
                        if (soNgayTre > 0)
                        {
                            int tamTinh = DuLieuChung.TinhTienPhat(pm, homNay);
                            ThemDongPhieu(sb, "Phạt tạm tính", DinhDangTien(tamTinh) + " (" + soNgayTre.ToString() + " ngày)", rong);
                        }
                        else
                        {
                            ThemDongPhieu(sb, "Phạt tạm tính", DinhDangTien(0), rong);
                        }
                    }

                    sb.AppendLine(vien);
                    ThemDongPhieu(sb, "Ngày in", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), rong);
                    sb.AppendLine(vien);

                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        sw.Write(sb.ToString());
                    }

                    MessageBox.Show("Đã xuất phiếu mượn ra file:\n" + sfd.FileName,
                        "In phiếu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi in phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DuLieuChung.GhiLog("Lỗi in phiếu mượn " + pm.SoPhieu + ": " + ex.Message);
                }
            }
        }

        // Thêm 1 dòng thông tin vào khung phiếu (căn cột cho đều)
        private void ThemDongPhieu(StringBuilder sb, string tenNhan, string noiDung, int rong)
        {
            int toiDa = rong - 19;
            if (noiDung.Length > toiDa)
            {
                noiDung = noiDung.Substring(0, toiDa - 3) + "...";
            }
            string dong = "|  " + (tenNhan + ":").PadRight(16) + noiDung;
            sb.AppendLine(dong.PadRight(rong + 1) + "|");
        }

        // Căn giữa 1 chuỗi trong khung phiếu có chiều rộng cho trước
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
