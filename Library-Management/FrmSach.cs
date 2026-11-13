using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class FrmSach : Form
    {
        // Biến lưu tên file ảnh đang được chọn cho sách
        private string tenAnhDuocChon = "";

        // Cờ hiệu đánh dấu form đang trong quá trình khởi tạo để không tự lọc sách
        private bool dangKhoiTao = true;

        public FrmSach()
        {
            InitializeComponent();
        }

        private void FrmSach_Load(object sender, EventArgs e)
        {
            dangKhoiTao = true;

            // 1. Nạp dữ liệu cây thể loại lên TreeView
            NapCayTheLoai();

            // 2. Nạp danh mục thể loại vào ComboBox
            NapComboBoxTheLoai();

            // 3. Hiển thị toàn bộ danh sách sách lên ListView ngay từ đầu
            HienThiDanhSachSach(null);

            // Bỏ chọn node trên TreeView và xóa trắng ô nhập thể loại
            tvTheLoai.SelectedNode = null;
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();

            // Phân quyền: Nhân viên không được phép xóa sách và xóa danh mục thể loại
            if (DuLieuChung.NguoiDungHienTai != null && DuLieuChung.NguoiDungHienTai.VaiTro == "NhanVien")
            {
                btnXoaSach.Enabled = false;
                btnXoaSach.Text = "🗑️ Xóa (Chỉ Admin)";
                btnXoaTheLoai.Enabled = false;
                btnXoaTheLoai.Text = "Xóa TL (Admin)";
                tsmXoa.Enabled = false;
            }

            // Hoàn tất khởi tạo
            dangKhoiTao = false;
        }

        private void FrmSach_Shown(object sender, EventArgs e)
        {
            // Đảm bảo khi form hiển thị lên màn hình sẽ luôn nạp toàn bộ danh sách sách
            tvTheLoai.SelectedNode = null;
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();
            HienThiDanhSachSach(null);
            this.ActiveControl = txtTimKiem;
        }

        // ================= XỬ LÝ CÂY THỂ LOẠI (TREEVIEW) =================

        // Yêu cầu: Không dùng đệ quy, dùng 2 vòng lặp foreach lồng nhau (Cấp Cha -> Cấp Con)
        public void NapCayTheLoai()
        {
            tvTheLoai.Nodes.Clear();

            // Vòng lặp 1: Tìm và tạo các Node thể loại cấp gốc (MaCha rỗng)
            foreach (TheLoai cha in DuLieuChung.DanhSachTheLoai)
            {
                if (string.IsNullOrEmpty(cha.MaCha))
                {
                    TreeNode nodeCha = new TreeNode(cha.Ten);
                    nodeCha.Tag = cha.Ma; // Lưu mã thể loại vào thuộc tính Tag để dễ truy xuất

                    // Vòng lặp 2: Tìm các Node thể loại con trực tiếp thuộc về thể loại cha này
                    foreach (TheLoai con in DuLieuChung.DanhSachTheLoai)
                    {
                        if (con.MaCha == cha.Ma)
                        {
                            TreeNode nodeCon = new TreeNode(con.Ten);
                            nodeCon.Tag = con.Ma;
                            nodeCha.Nodes.Add(nodeCon);
                        }
                    }

                    tvTheLoai.Nodes.Add(nodeCha);
                }
            }

            // Mở rộng toàn bộ cây để sinh viên và giảng viên nhìn thấy trực quan
            tvTheLoai.ExpandAll();
        }

        // Nạp danh mục thể loại vào ComboBox nhập liệu của sách
        private void NapComboBoxTheLoai()
        {
            cboTheLoai.Items.Clear();
            foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
            {
                cboTheLoai.Items.Add(tl);
            }
            cboTheLoai.DisplayMember = "Ten";
        }

        // Sự kiện khi người dùng click chọn 1 thể loại trên TreeView
        private void tvTheLoai_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Chỉ lọc khi người dùng chủ động click chuột hoặc bàn phím (tránh TreeView tự chọn node đầu tiên khi nhận focus)
            if (dangKhoiTao || e.Action == TreeViewAction.Unknown || e.Node == null || e.Node.Tag == null)
            {
                return;
            }

            string maTheLoaiChon = e.Node.Tag.ToString();

            // Điền thông tin thể loại sang các ô nhập liệu quản lý thể loại
            txtMaTheLoai.Text = maTheLoaiChon;
            txtTenTheLoai.Text = e.Node.Text;

            // Thu thập mã thể loại đang chọn VÀ tất cả các mã thể loại con của nó
            List<string> dsMaCanLoc = new List<string>();
            dsMaCanLoc.Add(maTheLoaiChon);

            // Dùng vòng lặp tìm các mã con trực tiếp
            foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
            {
                if (tl.MaCha == maTheLoaiChon)
                {
                    dsMaCanLoc.Add(tl.Ma);
                }
            }

            // Lọc và hiển thị sách thuộc các thể loại trên
            HienThiDanhSachSach(dsMaCanLoc);
        }

        // ================= QUẢN LÝ THỂ LOẠI (THÊM, SỬA, XÓA) =================

        // Thêm thể loại cấp gốc (MaCha = "")
        private void btnThemGoc_Click(object sender, EventArgs e)
        {
            string ma = txtMaTheLoai.Text.Trim();
            string ten = txtTenTheLoai.Text.Trim();

            if (ma == "" || ten == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng mã thể loại bằng vòng lặp foreach
            bool daTonTai = false;
            foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
            {
                if (tl.Ma.ToLower() == ma.ToLower())
                {
                    daTonTai = true;
                    break;
                }
            }

            if (daTonTai)
            {
                MessageBox.Show("Mã thể loại này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTheLoai.Focus();
                return;
            }

            TheLoai tlMoi = new TheLoai(ma, ten, "");
            DuLieuChung.DanhSachTheLoai.Add(tlMoi);
            DuLieuChung.GhiTheLoai();

            NapCayTheLoai();
            NapComboBoxTheLoai();
            MessageBox.Show("Thêm thể loại gốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Thêm thể loại con cho thể loại đang chọn trên TreeView
        private void btnThemCon_Click(object sender, EventArgs e)
        {
            if (tvTheLoai.SelectedNode == null)
            {
                MessageBox.Show("Vui lòng chọn một thể loại cha trên TreeView trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maCha = tvTheLoai.SelectedNode.Tag.ToString();
            string ma = txtMaTheLoai.Text.Trim();
            string ten = txtTenTheLoai.Text.Trim();

            if (ma == "" || ten == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên thể loại con!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng mã
            bool daTonTai = false;
            foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
            {
                if (tl.Ma.ToLower() == ma.ToLower())
                {
                    daTonTai = true;
                    break;
                }
            }

            if (daTonTai)
            {
                MessageBox.Show("Mã thể loại này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTheLoai.Focus();
                return;
            }

            TheLoai tlCon = new TheLoai(ma, ten, maCha);
            DuLieuChung.DanhSachTheLoai.Add(tlCon);
            DuLieuChung.GhiTheLoai();

            NapCayTheLoai();
            NapComboBoxTheLoai();
            MessageBox.Show("Thêm thể loại con thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Đổi tên thể loại đang chọn
        private void btnSuaTheLoai_Click(object sender, EventArgs e)
        {
            if (tvTheLoai.SelectedNode == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại cần sửa trên TreeView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSua = tvTheLoai.SelectedNode.Tag.ToString();
            string tenMoi = txtTenTheLoai.Text.Trim();

            if (tenMoi == "")
            {
                MessageBox.Show("Vui lòng nhập tên thể loại mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
            {
                if (tl.Ma == maSua)
                {
                    tl.Ten = tenMoi;
                    break;
                }
            }

            DuLieuChung.GhiTheLoai();
            NapCayTheLoai();
            NapComboBoxTheLoai();
            MessageBox.Show("Cập nhật tên thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa thể loại: Phải kiểm tra không có thể loại con VÀ không có sách
        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {
            if (tvTheLoai.SelectedNode == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa trên TreeView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maXoa = tvTheLoai.SelectedNode.Tag.ToString();

            // 1. Kiểm tra xem thể loại này có thể loại con không
            bool coCon = false;
            foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
            {
                if (tl.MaCha == maXoa)
                {
                    coCon = true;
                    break;
                }
            }

            if (coCon)
            {
                MessageBox.Show("Không thể xóa vì thể loại này đang có thể loại con!\nVui lòng xóa các thể loại con trước.", "Cảnh báo ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra xem có cuốn sách nào đang thuộc thể loại này không
            bool coSach = false;
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                if (s.MaTheLoai == maXoa)
                {
                    coSach = true;
                    break;
                }
            }

            if (coSach)
            {
                MessageBox.Show("Không thể xóa vì hiện vẫn còn sách thuộc thể loại này!\nVui lòng chuyển hoặc xóa các cuốn sách liên quan trước.", "Cảnh báo ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Xác nhận xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int i = 0; i < DuLieuChung.DanhSachTheLoai.Count; i++)
                {
                    if (DuLieuChung.DanhSachTheLoai[i].Ma == maXoa)
                    {
                        DuLieuChung.DanhSachTheLoai.RemoveAt(i);
                        break;
                    }
                }

                DuLieuChung.GhiTheLoai();
                NapCayTheLoai();
                NapComboBoxTheLoai();
                txtMaTheLoai.Clear();
                txtTenTheLoai.Clear();
                HienThiDanhSachSach(null);
                MessageBox.Show("Đã xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ================= HIỂN THỊ VÀ TÌM KIẾM SÁCH (LISTVIEW) =================

        // Hiển thị danh sách sách theo điều kiện lọc thể loại (nếu dsMaTheLoai == null thì hiện tất cả)
        private void HienThiDanhSachSach(List<string> dsMaTheLoai)
        {
            lvSach.Items.Clear();

            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                bool hopLe = false;
                if (dsMaTheLoai == null)
                {
                    hopLe = true; // Hiện tất cả
                }
                else
                {
                    // Kiểm tra mã thể loại của sách có nằm trong danh sách mã lọc không
                    foreach (string maTL in dsMaTheLoai)
                    {
                        if (s.MaTheLoai == maTL)
                        {
                            hopLe = true;
                            break;
                        }
                    }
                }

                if (hopLe)
                {
                    // Tìm tên thể loại để hiển thị đẹp mắt lên ListView
                    string tenTheLoai = s.MaTheLoai;
                    foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
                    {
                        if (tl.Ma == s.MaTheLoai)
                        {
                            tenTheLoai = tl.Ten;
                            break;
                        }
                    }

                    ListViewItem item = new ListViewItem(s.Ma);
                    item.SubItems.Add(s.Ten);
                    item.SubItems.Add(s.TacGia);
                    item.SubItems.Add(s.NamXB.ToString());
                    item.SubItems.Add(tenTheLoai);
                    item.SubItems.Add(s.SoLuong.ToString());
                    item.SubItems.Add(s.Anh);
                    item.Tag = s;

                    lvSach.Items.Add(item);
                }
            }
        }

        // Hiện tất cả sách
        private void btnTatCaSach_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            tvTheLoai.SelectedNode = null;
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();
            HienThiDanhSachSach(null);
        }

        // Tìm kiếm sách theo tên sách (dùng vòng lặp foreach và if-else)
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (tuKhoa == "")
            {
                HienThiDanhSachSach(null);
                return;
            }

            lvSach.Items.Clear();
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                // Kiểm tra tên sách có chứa từ khóa không
                if (s.Ten.ToLower().IndexOf(tuKhoa) >= 0)
                {
                    string tenTheLoai = s.MaTheLoai;
                    foreach (TheLoai tl in DuLieuChung.DanhSachTheLoai)
                    {
                        if (tl.Ma == s.MaTheLoai)
                        {
                            tenTheLoai = tl.Ten;
                            break;
                        }
                    }

                    ListViewItem item = new ListViewItem(s.Ma);
                    item.SubItems.Add(s.Ten);
                    item.SubItems.Add(s.TacGia);
                    item.SubItems.Add(s.NamXB.ToString());
                    item.SubItems.Add(tenTheLoai);
                    item.SubItems.Add(s.SoLuong.ToString());
                    item.SubItems.Add(s.Anh);
                    item.Tag = s;

                    lvSach.Items.Add(item);
                }
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Khi người dùng click chọn dòng trên ListView
        private void lvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSach.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem item = lvSach.SelectedItems[0];
            string maSach = item.Text;

            // Tìm sách tương ứng trong danh sách
            Sach sachChon = null;
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                if (s.Ma == maSach)
                {
                    sachChon = s;
                    break;
                }
            }

            if (sachChon != null)
            {
                txtMaSach.Text = sachChon.Ma;
                txtTenSach.Text = sachChon.Ten;
                txtTacGia.Text = sachChon.TacGia;
                txtNamXB.Text = sachChon.NamXB.ToString();
                txtSoLuong.Text = sachChon.SoLuong.ToString();
                tenAnhDuocChon = sachChon.Anh;

                // Chọn đúng thể loại trong ComboBox
                for (int i = 0; i < cboTheLoai.Items.Count; i++)
                {
                    TheLoai tl = (TheLoai)cboTheLoai.Items[i];
                    if (tl.Ma == sachChon.MaTheLoai)
                    {
                        cboTheLoai.SelectedIndex = i;
                        break;
                    }
                }

                // Nạp ảnh bìa sách lên PictureBox an toàn không khóa file
                HienThiAnhBia(sachChon.Anh);
            }
        }

        // ================= XỬ LÝ ẢNH BÌA SÁCH =================

        // Nạp ảnh an toàn bằng FileStream để không bị khóa file (File Lock)
        private void HienThiAnhBia(string tenFileAnh)
        {
            if (picBiaSach.Image != null)
            {
                picBiaSach.Image.Dispose();
                picBiaSach.Image = null;
            }

            if (string.IsNullOrEmpty(tenFileAnh))
            {
                return;
            }

            string duongDan = Path.Combine(DuLieuChung.LayThuMucImages(), tenFileAnh);
            if (File.Exists(duongDan))
            {
                try
                {
                    using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                    {
                        picBiaSach.Image = Image.FromStream(fs);
                    }
                }
                catch (Exception ex)
                {
                    DuLieuChung.GhiLog("Lỗi nạp ảnh bìa sách (" + tenFileAnh + "): " + ex.Message);
                }
            }
        }

        // Chọn ảnh từ máy tính và copy vào Data/Images/
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh bìa sách";
                ofd.Filter = "Tập tin ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Tất cả tập tin (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string thuMucImages = DuLieuChung.LayThuMucImages();
                        if (!Directory.Exists(thuMucImages))
                        {
                            Directory.CreateDirectory(thuMucImages);
                        }

                        string duoiFile = Path.GetExtension(ofd.FileName);
                        string maSach = txtMaSach.Text.Trim();
                        string tenFileDich;

                        if (maSach != "")
                        {
                            tenFileDich = maSach.ToLower() + duoiFile;
                        }
                        else
                        {
                            tenFileDich = Path.GetFileName(ofd.FileName);
                        }

                        string duongDanDich = Path.Combine(thuMucImages, tenFileDich);

                        // Giải phóng ảnh cũ nếu đang hiển thị trước khi copy ghi đè
                        if (picBiaSach.Image != null)
                        {
                            picBiaSach.Image.Dispose();
                            picBiaSach.Image = null;
                        }

                        // Sao chép file ảnh vào thư mục dự án
                        File.Copy(ofd.FileName, duongDanDich, true);

                        tenAnhDuocChon = tenFileDich;
                        HienThiAnhBia(tenFileDich);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi sao chép ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DuLieuChung.GhiLog("Lỗi chọn ảnh bìa: " + ex.Message);
                    }
                }
            }
        }

        // ================= CÁC NÚT THAO TÁC SÁCH (THÊM, SỬA, XÓA, LÀM MỚI) =================

        // Thêm sách mới
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();
            string ten = txtTenSach.Text.Trim();
            string tacGia = txtTacGia.Text.Trim();

            // 1. Kiểm tra các ô không được để trống
            if (ma == "")
            {
                MessageBox.Show("Vui lòng nhập Mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSach.Focus();
                return;
            }

            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập Tên sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return;
            }

            if (tacGia == "")
            {
                MessageBox.Show("Vui lòng nhập Tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTacGia.Focus();
                return;
            }

            // 2. Kiểm tra Năm XB bằng int.TryParse
            int namXB;
            if (!int.TryParse(txtNamXB.Text.Trim(), out namXB) || namXB < 1900 || namXB > DateTime.Now.Year)
            {
                MessageBox.Show("Năm xuất bản phải là số nguyên hợp lệ (từ 1900 đến " + DateTime.Now.Year + ")!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamXB.Focus();
                txtNamXB.SelectAll();
                return;
            }

            // 3. Kiểm tra Thể loại
            if (cboTheLoai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Thể loại sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTheLoai.Focus();
                return;
            }
            TheLoai tlChon = (TheLoai)cboTheLoai.SelectedItem;
            string maTheLoai = tlChon.Ma;

            // 4. Kiểm tra Số lượng bằng int.TryParse
            int soLuong;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng sách phải là số nguyên không âm (>= 0)!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return;
            }

            // 5. Kiểm tra trùng mã sách bằng vòng lặp foreach
            bool daTonTai = false;
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                if (s.Ma.ToLower() == ma.ToLower())
                {
                    daTonTai = true;
                    break;
                }
            }

            if (daTonTai)
            {
                MessageBox.Show("Mã sách '" + ma + "' đã tồn tại! Vui lòng nhập mã sách khác.", "Cảnh báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSach.Focus();
                txtMaSach.SelectAll();
                return;
            }

            // Tạo đối tượng sách mới và thêm vào danh sách
            Sach sachMoi = new Sach(ma, ten, tacGia, namXB, maTheLoai, soLuong, tenAnhDuocChon);
            DuLieuChung.DanhSachSach.Add(sachMoi);

            // Ghi lại vào file txt
            DuLieuChung.GhiSach();

            // Làm mới ListView
            HienThiDanhSachSach(null);

            MessageBox.Show("Thêm sách mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sửa thông tin sách
        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm sách cần sửa theo mã
            Sach sachSua = null;
            foreach (Sach s in DuLieuChung.DanhSachSach)
            {
                if (s.Ma.ToLower() == ma.ToLower())
                {
                    sachSua = s;
                    break;
                }
            }

            if (sachSua == null)
            {
                MessageBox.Show("Không tìm thấy cuốn sách có mã: " + ma, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ten = txtTenSach.Text.Trim();
            string tacGia = txtTacGia.Text.Trim();

            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập Tên sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return;
            }

            if (tacGia == "")
            {
                MessageBox.Show("Vui lòng nhập Tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTacGia.Focus();
                return;
            }

            int namXB;
            if (!int.TryParse(txtNamXB.Text.Trim(), out namXB) || namXB < 1900 || namXB > DateTime.Now.Year)
            {
                MessageBox.Show("Năm xuất bản phải là số nguyên hợp lệ (1900 - " + DateTime.Now.Year + ")!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamXB.Focus();
                return;
            }

            if (cboTheLoai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Thể loại sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTheLoai.Focus();
                return;
            }
            TheLoai tlChon = (TheLoai)cboTheLoai.SelectedItem;

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng sách phải là số nguyên >= 0!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            // Cập nhật lại thông tin sách
            sachSua.Ten = ten;
            sachSua.TacGia = tacGia;
            sachSua.NamXB = namXB;
            sachSua.MaTheLoai = tlChon.Ma;
            sachSua.SoLuong = soLuong;
            if (!string.IsNullOrEmpty(tenAnhDuocChon))
            {
                sachSua.Anh = tenAnhDuocChon;
            }

            // Lưu thay đổi vào file
            DuLieuChung.GhiSach();

            // Cập nhật lại hiển thị
            HienThiDanhSachSach(null);

            MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa sách
        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn cuốn sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ràng buộc: Sách đang có phiếu mượn chưa trả thì không được xóa
            bool dangDuocMuon = false;
            foreach (PhieuMuon pm in DuLieuChung.DanhSachPhieuMuon)
            {
                if (pm.MaSach.ToLower() == ma.ToLower() && string.IsNullOrEmpty(pm.NgayTra))
                {
                    dangDuocMuon = true;
                    break;
                }
            }

            if (dangDuocMuon)
            {
                MessageBox.Show("Không thể xóa vì cuốn sách này hiện đang có độc giả mượn chưa trả!\nVui lòng kiểm tra lại trong phân hệ Mượn - Trả.", "Cảnh báo ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa cuốn sách: '" + txtTenSach.Text + "' (Mã: " + ma + ")?", "Xác nhận xóa sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int i = 0; i < DuLieuChung.DanhSachSach.Count; i++)
                {
                    if (DuLieuChung.DanhSachSach[i].Ma.ToLower() == ma.ToLower())
                    {
                        DuLieuChung.DanhSachSach.RemoveAt(i);
                        break;
                    }
                }

                DuLieuChung.GhiSach();
                HienThiDanhSachSach(null);
                btnLamMoi_Click(sender, e);
                MessageBox.Show("Đã xóa cuốn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Làm mới / Nhập lại dữ liệu trên form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtNamXB.Text = DateTime.Now.Year.ToString();
            txtSoLuong.Text = "1";
            cboTheLoai.SelectedIndex = -1;
            tenAnhDuocChon = "";

            if (picBiaSach.Image != null)
            {
                picBiaSach.Image.Dispose();
                picBiaSach.Image = null;
            }

            txtMaSach.Focus();
        }
    }
}

