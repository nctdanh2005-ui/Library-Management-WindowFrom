using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Library_Management
{
    // Form thống kê - báo cáo của phân hệ Mượn - Trả (SV3):
    //  1. Danh sách độc giả quá hạn
    //  2. Thống kê lượt mượn theo thể loại
    //  3. Thống kê sách ít được mượn (điểm cộng)
    //  4. Quản lý danh sách đặt trước sách (điểm cộng)
    public partial class FrmBaoCaoMuonTra : Form
    {
        private bool dangKhoiTao = false;

        public FrmBaoCaoMuonTra()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoMuonTra_Load(object sender, EventArgs e)
        {
            dangKhoiTao = true;

            TaoCot(lvQuaHan, new string[] { "Mã ĐG", "Họ tên", "Lớp", "Số cuốn quá hạn", "Trễ lâu nhất", "Phạt tạm tính", "Sách đang giữ quá hạn" },
                             new int[] { 80, 170, 100, 110, 100, 120, 380 });
            TaoCot(lvTheLoai, new string[] { "Mã thể loại", "Tên thể loại", "Thể loại cha", "Lượt mượn", "Đang mượn", "Tỷ lệ" },
                              new int[] { 100, 230, 200, 100, 100, 100 });
            TaoCot(lvItMuon, new string[] { "Mã sách", "Tên sách", "Thể loại", "Tồn kho", "Lượt mượn", "Lần mượn gần nhất" },
                             new int[] { 80, 330, 170, 80, 90, 140 });
            TaoCot(lvDatTruoc, new string[] { "Mã đặt", "Độc giả", "Sách", "Ngày đặt", "Thứ tự chờ", "Trạng thái", "Tồn kho hiện tại" },
                               new int[] { 80, 190, 300, 100, 90, 110, 120 });

            rdoChiTiet.Checked = true;
            nudNguong.Value = 1;
            chkChiChoNhan.Checked = true;

            dangKhoiTao = false;
            NapTatCa();
        }

        private void TaoCot(ListView lv, string[] tieuDe, int[] doRong)
        {
            lv.Columns.Clear();
            for (int i = 0; i < tieuDe.Length; i++)
            {
                lv.Columns.Add(tieuDe[i], doRong[i]);
            }
        }

        private void NapTatCa()
        {
            HienThiDocGiaQuaHan();
            HienThiThongKeTheLoai();
            HienThiSachItMuon();
            HienThiDatTruoc();
        }

        // ================= TIỆN ÍCH =================

        private string DinhDangTien(int soTien)
        {
            return soTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
        }

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

        // ================= 1. DANH SÁCH ĐỘC GIẢ QUÁ HẠN =================

        private class DongQuaHan
        {
            public string MaDocGia = "";
            public int SoCuon = 0;
            public int TreLauNhat = 0;
            public int PhatTamTinh = 0;
            public List<string> DanhSachSach = new List<string>();
        }

        private void HienThiDocGiaQuaHan()
        {
            lvQuaHan.Items.Clear();

            DateTime homNay = DateTime.Now.Date;
            int tienPhatMoiNgay = DuLieuChung.LayTienPhatMoiNgay();

            // Gom các phiếu chưa trả đã quá hạn theo từng độc giả
            Dictionary<string, DongQuaHan> theoDocGia = new Dictionary<string, DongQuaHan>();
            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                if (!DuLieuChung.DangQuaHan(pm))
                {
                    continue;
                }

                string khoa = pm.MaDocGia.ToLower();
                if (!theoDocGia.ContainsKey(khoa))
                {
                    DongQuaHan dongMoi = new DongQuaHan();
                    dongMoi.MaDocGia = pm.MaDocGia;
                    theoDocGia.Add(khoa, dongMoi);
                }

                DongQuaHan dong = theoDocGia[khoa];
                int soNgayTre = (homNay - pm.HanTra.Date).Days;
                dong.SoCuon++;
                dong.PhatTamTinh = dong.PhatTamTinh + DuLieuChung.TinhTienPhat(pm, homNay);
                if (soNgayTre > dong.TreLauNhat)
                {
                    dong.TreLauNhat = soNgayTre;
                }

                Sach sach = TimSach(pm.MaSach);
                dong.DanhSachSach.Add(((sach != null) ? sach.Ten : pm.MaSach) + " (" + pm.SoPhieu + ", trễ " + soNgayTre + " ngày)");
            }

            // Sắp xếp: trễ lâu nhất lên đầu
            List<DongQuaHan> ds = new List<DongQuaHan>(theoDocGia.Values);
            ds.Sort(delegate (DongQuaHan a, DongQuaHan b) { return b.TreLauNhat.CompareTo(a.TreLauNhat); });

            int tongCuon = 0;
            int tongPhat = 0;
            foreach (DongQuaHan dong in ds)
            {
                DocGia dg = TimDocGia(dong.MaDocGia);
                ListViewItem item = new ListViewItem(dong.MaDocGia);
                item.SubItems.Add((dg != null) ? dg.HoTen : "(Đã xóa)");
                item.SubItems.Add((dg != null) ? dg.Lop : "");
                item.SubItems.Add(dong.SoCuon.ToString());
                item.SubItems.Add(dong.TreLauNhat + " ngày");
                item.SubItems.Add(DinhDangTien(dong.PhatTamTinh));
                item.SubItems.Add(string.Join("; ", dong.DanhSachSach.ToArray()));
                item.BackColor = Color.LightPink;
                lvQuaHan.Items.Add(item);

                tongCuon = tongCuon + dong.SoCuon;
                tongPhat = tongPhat + dong.PhatTamTinh;
            }

            lblQuaHanTongHop.Text = "Tính đến ngày " + homNay.ToString("dd/MM/yyyy") + ":  " + ds.Count + " độc giả quá hạn  |  " +
                                    tongCuon + " cuốn chưa trả  |  Phạt tạm tính: " + DinhDangTien(tongPhat) +
                                    "  (" + DinhDangTien(tienPhatMoiNgay) + "/ngày)";
        }

        // ================= 2. THỐNG KÊ LƯỢT MƯỢN THEO THỂ LOẠI =================

        private void HienThiThongKeTheLoai()
        {
            lvTheLoai.Items.Clear();

            bool gopTheoGoc = rdoGop.Checked;
            const string MaKhongRo = "?";

            // Khởi tạo bộ đếm cho các thể loại cần hiển thị (giữ cả thể loại có 0 lượt)
            List<string> thuTu = new List<string>();
            Dictionary<string, int> luotMuon = new Dictionary<string, int>();
            Dictionary<string, int> dangMuon = new Dictionary<string, int>();
            foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
            {
                if (gopTheoGoc && tl.MaCha.Trim() != "")
                {
                    continue;
                }
                string khoa = tl.Ma.ToLower();
                if (!luotMuon.ContainsKey(khoa))
                {
                    thuTu.Add(khoa);
                    luotMuon.Add(khoa, 0);
                    dangMuon.Add(khoa, 0);
                }
            }

            // Đếm lượt mượn: mỗi phiếu mượn = 1 lượt của thể loại cuốn sách đó
            int tongLuot = 0;
            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                string khoa = MaKhongRo;
                Sach sach = TimSach(pm.MaSach);
                if (sach != null)
                {
                    TheLoai tl = gopTheoGoc ? DuLieuChung.LayTheLoaiGoc(sach.MaTheLoai) : DuLieuChung.TimTheLoai(sach.MaTheLoai);
                    if (tl != null)
                    {
                        khoa = tl.Ma.ToLower();
                    }
                }

                if (!luotMuon.ContainsKey(khoa))
                {
                    thuTu.Add(khoa);
                    luotMuon.Add(khoa, 0);
                    dangMuon.Add(khoa, 0);
                }
                luotMuon[khoa]++;
                if (DuLieuChung.ChuaTra(pm))
                {
                    dangMuon[khoa]++;
                }
                tongLuot++;
            }

            // Sắp xếp giảm dần theo lượt mượn
            thuTu.Sort(delegate (string a, string b) { return luotMuon[b].CompareTo(luotMuon[a]); });

            foreach (string khoa in thuTu)
            {
                TheLoai tl = (khoa == MaKhongRo) ? null : DuLieuChung.TimTheLoai(khoa);
                TheLoai cha = (tl != null && tl.MaCha.Trim() != "") ? DuLieuChung.TimTheLoai(tl.MaCha) : null;
                double tyLe = (tongLuot > 0) ? luotMuon[khoa] * 100.0 / tongLuot : 0;

                ListViewItem item = new ListViewItem((tl != null) ? tl.Ma : "-");
                item.SubItems.Add((tl != null) ? tl.Ten : "(Không rõ thể loại / sách đã xóa)");
                item.SubItems.Add((cha != null) ? cha.Ten : "");
                item.SubItems.Add(luotMuon[khoa].ToString());
                item.SubItems.Add(dangMuon[khoa].ToString());
                item.SubItems.Add(tyLe.ToString("0.0") + " %");
                if (luotMuon[khoa] == 0)
                {
                    item.ForeColor = Color.Gray;
                }
                lvTheLoai.Items.Add(item);
            }

            lblTheLoaiTongHop.Text = "Tổng số lượt mượn: " + tongLuot + "  |  " + thuTu.Count + " thể loại" +
                                     (gopTheoGoc ? " gốc (đã cộng dồn thể loại con)" : "");
        }

        private void rdoCheDoTheLoai_CheckedChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao)
            {
                return;
            }
            HienThiThongKeTheLoai();
        }

        // ================= 3. SÁCH ÍT ĐƯỢC MƯỢN (ĐIỂM CỘNG) =================

        private void HienThiSachItMuon()
        {
            lvItMuon.Items.Clear();

            int nguong = (int)nudNguong.Value;

            // Đếm lượt mượn và ngày mượn gần nhất của từng sách
            Dictionary<string, int> luotMuon = new Dictionary<string, int>();
            Dictionary<string, DateTime> ganNhat = new Dictionary<string, DateTime>();
            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                string khoa = pm.MaSach.ToLower();
                if (!luotMuon.ContainsKey(khoa))
                {
                    luotMuon.Add(khoa, 0);
                    ganNhat.Add(khoa, pm.NgayMuon);
                }
                luotMuon[khoa]++;
                if (pm.NgayMuon > ganNhat[khoa])
                {
                    ganNhat[khoa] = pm.NgayMuon;
                }
            }

            List<Sach> ds = new List<Sach>();
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                int luot = luotMuon.ContainsKey(s.Ma.ToLower()) ? luotMuon[s.Ma.ToLower()] : 0;
                if (luot <= nguong)
                {
                    ds.Add(s);
                }
            }

            // Ít lượt nhất lên đầu, cùng lượt thì theo mã sách
            ds.Sort(delegate (Sach a, Sach b)
            {
                int la = luotMuon.ContainsKey(a.Ma.ToLower()) ? luotMuon[a.Ma.ToLower()] : 0;
                int lb = luotMuon.ContainsKey(b.Ma.ToLower()) ? luotMuon[b.Ma.ToLower()] : 0;
                if (la != lb)
                {
                    return la.CompareTo(lb);
                }
                return string.Compare(a.Ma, b.Ma, StringComparison.OrdinalIgnoreCase);
            });

            int chuaMuonLanNao = 0;
            foreach (Sach s in ds)
            {
                string khoa = s.Ma.ToLower();
                int luot = luotMuon.ContainsKey(khoa) ? luotMuon[khoa] : 0;
                TheLoai tl = DuLieuChung.TimTheLoai(s.MaTheLoai);

                ListViewItem item = new ListViewItem(s.Ma);
                item.SubItems.Add(s.Ten);
                item.SubItems.Add((tl != null) ? tl.Ten : s.MaTheLoai);
                item.SubItems.Add(s.SoLuong.ToString());
                item.SubItems.Add(luot.ToString());
                item.SubItems.Add((luot > 0) ? ganNhat[khoa].ToString("dd/MM/yyyy") : "Chưa từng được mượn");
                if (luot == 0)
                {
                    item.BackColor = Color.LightYellow;
                    chuaMuonLanNao++;
                }
                lvItMuon.Items.Add(item);
            }

            lblItMuonTongHop.Text = ds.Count + " / " + DuLieuChung.DanhSachSach.Count + " đầu sách có ≤ " + nguong +
                                    " lượt mượn  |  " + chuaMuonLanNao + " đầu sách chưa từng được mượn (tô vàng)";
        }

        private void nudNguong_ValueChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao)
            {
                return;
            }
            HienThiSachItMuon();
        }

        // ================= 4. DANH SÁCH ĐẶT TRƯỚC (ĐIỂM CỘNG) =================

        private void HienThiDatTruoc()
        {
            lvDatTruoc.Items.Clear();

            int soChoNhan = 0;
            foreach (DatTruoc dt in DuLieuChung.DanhSachDatTruoc)
            {
                bool choNhan = (dt.TrangThai == "ChoNhan");
                if (choNhan)
                {
                    soChoNhan++;
                }
                if (chkChiChoNhan.Checked && !choNhan)
                {
                    continue;
                }

                DocGia dg = TimDocGia(dt.MaDocGia);
                Sach sach = TimSach(dt.MaSach);

                string thuTuCho = "";
                if (choNhan)
                {
                    List<DatTruoc> hangCho = DuLieuChung.LayHangChoDatTruoc(dt.MaSach);
                    thuTuCho = (hangCho.IndexOf(dt) + 1).ToString() + " / " + hangCho.Count;
                }

                ListViewItem item = new ListViewItem(dt.MaDat);
                item.SubItems.Add((dg != null) ? dg.Ma + " - " + dg.HoTen : dt.MaDocGia);
                item.SubItems.Add((sach != null) ? sach.Ma + " - " + sach.Ten : dt.MaSach);
                item.SubItems.Add(dt.NgayDat.ToString("dd/MM/yyyy"));
                item.SubItems.Add(thuTuCho);
                item.SubItems.Add(TrangThaiDatTruoc(dt.TrangThai));
                item.SubItems.Add((sach != null) ? sach.SoLuong.ToString() : "");
                item.Tag = dt;

                if (choNhan && sach != null && sach.SoLuong > 0)
                {
                    item.BackColor = Color.FromArgb(232, 248, 240); // đã có sách, chờ độc giả đến nhận
                }
                else if (!choNhan)
                {
                    item.ForeColor = Color.Gray;
                }
                lvDatTruoc.Items.Add(item);
            }

            lblDatTruocTongHop.Text = soChoNhan + " yêu cầu đang chờ nhận  |  Tổng: " + DuLieuChung.DanhSachDatTruoc.Count +
                                      "  (nền xanh = sách đã về kho, liên hệ độc giả đến nhận)";
        }

        private string TrangThaiDatTruoc(string trangThai)
        {
            if (trangThai == "ChoNhan") return "Chờ nhận";
            if (trangThai == "DaNhan") return "Đã nhận sách";
            if (trangThai == "DaHuy") return "Đã hủy";
            return trangThai;
        }

        private void chkChiChoNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao)
            {
                return;
            }
            HienThiDatTruoc();
        }

        private void btnHuyDatTruoc_Click(object sender, EventArgs e)
        {
            if (lvDatTruoc.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn yêu cầu đặt trước cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatTruoc dt = (DatTruoc)lvDatTruoc.SelectedItems[0].Tag;
            if (dt.TrangThai != "ChoNhan")
            {
                MessageBox.Show("Chỉ hủy được yêu cầu đang ở trạng thái 'Chờ nhận'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Hủy yêu cầu đặt trước " + dt.MaDat + " của độc giả " + dt.MaDocGia + " cho sách " + dt.MaSach + "?",
                "Xác nhận hủy đặt trước", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            dt.TrangThai = "DaHuy";
            DuLieuChung.GhiDatTruoc();
            HienThiDatTruoc();
        }

        // ================= THAO TÁC CHUNG =================

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            NapTatCa();
        }

        // Xuất ListView của tab đang mở ra file CSV
        private void btnXuatCSV_Click(object sender, EventArgs e)
        {
            ListView lv;
            string tenFile;
            if (tabBaoCao.SelectedTab == tabQuaHan)
            {
                lv = lvQuaHan;
                tenFile = "doc gia qua han.csv";
            }
            else if (tabBaoCao.SelectedTab == tabTheLoai)
            {
                lv = lvTheLoai;
                tenFile = "luot muon theo the loai.csv";
            }
            else if (tabBaoCao.SelectedTab == tabItMuon)
            {
                lv = lvItMuon;
                tenFile = "sach it duoc muon.csv";
            }
            else
            {
                lv = lvDatTruoc;
                tenFile = "danh sach dat truoc.csv";
            }

            if (lv.Items.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất báo cáo ra file CSV";
                sfd.Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*";
                sfd.FileName = tenFile;
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    // Ký tự phân cách theo cài đặt vùng Windows để Excel tự tách cột
                    DuLieuChung.XuatListViewRaCSV(lv, sfd.FileName);

                    MessageBox.Show("Đã xuất " + lv.Items.Count + " dòng ra file:\n" + sfd.FileName,
                        "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DuLieuChung.GhiLog("Lỗi xuất CSV báo cáo mượn trả: " + ex.Message);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
