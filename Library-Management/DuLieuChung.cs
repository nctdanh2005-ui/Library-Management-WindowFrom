using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Library_Management
{
    public static class DuLieuChung
    {
        // 5 Danh sách dữ liệu chung của toàn hệ thống
        public static List<User> DanhSachUser = new List<User>();
        public static List<TheLoai> DanhSachTheLoai = new List<TheLoai>();
        public static List<Sach> DanhSachSach = new List<Sach>();
        public static List<DocGia> DanhSachDocGia = new List<DocGia>();
        public static List<PhieuMuon> DanhSachPhieuMuon = new List<PhieuMuon>();
        public static List<DatTruoc> DanhSachDatTruoc = new List<DatTruoc>();

        // Số sách tối đa một độc giả được giữ cùng lúc (chưa trả)
        public const int SoSachMuonToiDa = 5;

        // Tài khoản hiện đang đăng nhập vào phần mềm
        public static User NguoiDungHienTai = null;

        // Lấy đường dẫn thư mục Data từ App.config
        public static string LayThuMucData()
        {
            string thuMuc = ConfigurationManager.AppSettings["ThuMucData"];
            if (string.IsNullOrEmpty(thuMuc))
            {
                thuMuc = "Data";
            }
            if (!Path.IsPathRooted(thuMuc))
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                try
                {
                    string assemblyLocation = typeof(DuLieuChung).Assembly.Location;
                    if (!string.IsNullOrEmpty(assemblyLocation))
                    {
                        baseDir = Path.GetDirectoryName(assemblyLocation);
                    }
                }
                catch
                {
                }
                thuMuc = Path.Combine(baseDir, thuMuc);
            }
            return thuMuc;
        }

        // Lấy đường dẫn thư mục Data/Images
        public static string LayThuMucImages()
        {
            return Path.Combine(LayThuMucData(), "Images");
        }

        // Hàm ghi log lỗi hệ thống vào file Data/log.txt
        public static void GhiLog(string loi)
        {
            try
            {
                string thuMuc = LayThuMucData();
                if (!Directory.Exists(thuMuc))
                {
                    Directory.CreateDirectory(thuMuc);
                }
                string duongDanLog = Path.Combine(thuMuc, "log.txt");
                using (StreamWriter sw = new StreamWriter(duongDanLog, true, Encoding.UTF8))
                {
                    sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - " + loi);
                }
            }
            catch
            {
                // Bỏ qua lỗi khi không ghi được log để tránh crash chương trình
            }
        }

        // Tạo ảnh mẫu tượng trưng nếu chưa có để hiển thị lên PictureBox
        private static void TaoAnhMauNeuChuaCo(string thuMucImages, string tenFile, string tieuDe)
        {
            try
            {
                string duongDan = Path.Combine(thuMucImages, tenFile);
                if (!File.Exists(duongDan))
                {
                    using (Bitmap bmp = new Bitmap(200, 280))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(Color.FromArgb(41, 128, 185)); // Màu xanh dương nhã nhặn
                            using (Pen p = new Pen(Color.White, 3))
                            {
                                g.DrawRectangle(p, 5, 5, 190, 270);
                            }
                            using (Font f1 = new Font("Segoe UI", 12, FontStyle.Bold))
                            using (Font f2 = new Font("Segoe UI", 9, FontStyle.Regular))
                            using (Brush b = new SolidBrush(Color.White))
                            {
                                StringFormat sf = new StringFormat();
                                sf.Alignment = StringAlignment.Center;
                                sf.LineAlignment = StringAlignment.Center;
                                g.DrawString("THƯ VIỆN", f2, b, new RectangleF(10, 30, 180, 30), sf);
                                g.DrawString(tieuDe, f1, b, new RectangleF(15, 80, 170, 120), sf);
                                g.DrawString(tenFile, f2, b, new RectangleF(10, 230, 180, 30), sf);
                            }
                        }
                        bmp.Save(duongDan, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
            catch
            {
                // Bỏ qua nếu có sự cố tạo ảnh mẫu
            }
        }

        // Khởi tạo thư mục và sinh dữ liệu mẫu chuẩn nếu chưa tồn tại
        public static void KhoiTaoDuLieuMau()
        {
            string thuMucData = LayThuMucData();
            string thuMucImages = LayThuMucImages();

            if (!Directory.Exists(thuMucData))
            {
                Directory.CreateDirectory(thuMucData);
            }
            if (!Directory.Exists(thuMucImages))
            {
                Directory.CreateDirectory(thuMucImages);
            }

            // 1. File users.txt (TaiKhoan;MatKhau;VaiTro)
            string fileUsers = Path.Combine(thuMucData, "users.txt");
            if (!File.Exists(fileUsers))
            {
                using (StreamWriter sw = new StreamWriter(fileUsers, false, Encoding.UTF8))
                {
                    sw.WriteLine("admin;123456;QuanTri");
                    sw.WriteLine("nhanvien;123456;NhanVien");
                    sw.WriteLine("thuthu;123456;NhanVien");
                }
            }

            // 2. File theloai.txt (Ma;Ten;MaCha)
            string fileTheLoai = Path.Combine(thuMucData, "theloai.txt");
            if (!File.Exists(fileTheLoai))
            {
                using (StreamWriter sw = new StreamWriter(fileTheLoai, false, Encoding.UTF8))
                {
                    // Thể loại gốc (MaCha = "")
                    sw.WriteLine("CNTT;Công nghệ thông tin;");
                    sw.WriteLine("KT;Kinh tế - Quản trị;");
                    sw.WriteLine("NN;Ngoại ngữ;");
                    sw.WriteLine("KH;Khoa học Xã hội;");

                    // Thể loại con của CNTT
                    sw.WriteLine("LTCS;Lập trình C#;CNTT");
                    sw.WriteLine("CSDL;Cơ sở dữ liệu;CNTT");
                    sw.WriteLine("MMT;Mạng máy tính;CNTT");

                    // Thể loại con của KT
                    sw.WriteLine("QTKD;Quản trị kinh doanh;KT");
                    sw.WriteLine("KTTC;Kế toán - Tài chính;KT");
                    sw.WriteLine("MKT;Marketing;KT");

                    // Thể loại con của NN
                    sw.WriteLine("TA;Tiếng Anh;NN");
                    sw.WriteLine("TN;Tiếng Nhật;NN");
                    sw.WriteLine("TH;Tiếng Hàn;NN");

                    // Thể loại con của KH
                    sw.WriteLine("LS;Lịch sử;KH");
                    sw.WriteLine("TLH;Tâm lý học;KH");
                }
            }

            // 3. File sach.txt (Ma;Ten;TacGia;NamXB;MaTheLoai;SoLuong;Anh) - Đủ 20 cuốn sách mẫu
            string fileSach = Path.Combine(thuMucData, "sach.txt");
            if (!File.Exists(fileSach))
            {
                using (StreamWriter sw = new StreamWriter(fileSach, false, Encoding.UTF8))
                {
                    sw.WriteLine("S01;Lập trình C# từ cơ bản đến nâng cao;Phạm Hữu Khang;2021;LTCS;15;s01.jpg");
                    sw.WriteLine("S02;Giáo trình C# và WinForms toàn tập;Nguyễn Vũ Cẩm Tú;2020;LTCS;20;s02.jpg");
                    sw.WriteLine("S03;Cơ sở dữ liệu nâng cao và ứng dụng;Đỗ Trung Tuấn;2019;CSDL;12;s03.jpg");
                    sw.WriteLine("S04;Thiết kế và cài đặt hệ CSDL quan hệ;Lê Tiến Vương;2022;CSDL;18;s04.jpg");
                    sw.WriteLine("S05;Giáo trình Mạng máy tính căn bản;Hồ Đắc Phương;2021;MMT;25;s05.jpg");
                    sw.WriteLine("S06;An toàn và bảo mật hệ thống mạng;Nguyễn Nam Hải;2023;MMT;10;s06.jpg");
                    sw.WriteLine("S07;Nhập môn Công nghệ thông tin;Trần Đan Thư;2020;CNTT;30;s07.jpg");
                    sw.WriteLine("S08;Kiến trúc máy tính và Hợp ngữ;Lê Đình Danh;2018;CNTT;14;s08.jpg");
                    sw.WriteLine("S09;Quản trị học hiện đại;Nguyễn Thị Liên Diệp;2021;QTKD;16;s09.jpg");
                    sw.WriteLine("S10;Khởi nghiệp tinh gọn trong thời đại số;Eric Ries;2020;QTKD;22;s10.jpg");
                    sw.WriteLine("S11;Nguyên lý Kế toán cơ bản;Võ Văn Nhị;2022;KTTC;18;s11.jpg");
                    sw.WriteLine("S12;Phân tích báo cáo tài chính doanh nghiệp;Nguyễn Ngọc Dung;2021;KTTC;15;s12.jpg");
                    sw.WriteLine("S13;Marketing căn bản thế hệ mới;Philip Kotler;2023;MKT;20;s13.jpg");
                    sw.WriteLine("S14;Digital Marketing từ A đến Z;Nguyễn Cao Phong;2022;MKT;12;s14.jpg");
                    sw.WriteLine("S15;Ngữ pháp Tiếng Anh toàn tập;Mai Lan Hương;2021;TA;35;s15.jpg");
                    sw.WriteLine("S16;Luyện thi TOEIC cấp tốc;Nguyễn Thành Long;2022;TA;28;s16.jpg");
                    sw.WriteLine("S17;Giáo trình Minna no Nihongo I;3A Corporation;2020;TN;25;s17.jpg");
                    sw.WriteLine("S18;Tiếng Hàn tổng hợp cho người Việt;Cho Hang Rok;2021;TH;19;s18.jpg");
                    sw.WriteLine("S19;Đại cương Lịch sử Việt Nam;Trần Bá Đệ;2019;LS;15;s19.jpg");
                    sw.WriteLine("S20;Tâm lý học đại cương;Nguyễn Quang Uẩn;2022;TLH;17;s20.jpg");
                }
            }

            // Tạo sẵn 20 ảnh mẫu tương ứng trong thư mục Data/Images
            for (int i = 1; i <= 20; i++)
            {
                string tenAnh = "s" + (i < 10 ? "0" + i.ToString() : i.ToString()) + ".jpg";
                string tieuDe = "Sách Mẫu " + i.ToString();
                TaoAnhMauNeuChuaCo(thuMucImages, tenAnh, tieuDe);
            }

            // 4. File docgia.txt (Ma;HoTen;Lop;NgayHetHan;TrangThai)
            string fileDocGia = Path.Combine(thuMucData, "docgia.txt");
            if (!File.Exists(fileDocGia))
            {
                using (StreamWriter sw = new StreamWriter(fileDocGia, false, Encoding.UTF8))
                {
                    sw.WriteLine("DG001;Nguyễn Văn An;CNTT-K22A;31/12/2026;HoatDong");
                    sw.WriteLine("DG002;Trần Thị Bình;KT-K22B;31/12/2026;HoatDong");
                    sw.WriteLine("DG003;Lê Hoàng Cường;QTKD-K23;30/06/2026;HoatDong");
                    sw.WriteLine("DG004;Phạm Minh Đức;CNTT-K21;15/05/2024;BiKhoa");
                    sw.WriteLine("DG005;Vũ Thị Mai;NNA-K22;31/12/2026;HoatDong");
                }
            }

            // 5. File phieumuon.txt (SoPhieu;MaDocGia;MaSach;NgayMuon;HanTra;NgayTra;TienPhat)
            string filePhieuMuon = Path.Combine(thuMucData, "phieumuon.txt");
            if (!File.Exists(filePhieuMuon))
            {
                using (StreamWriter sw = new StreamWriter(filePhieuMuon, false, Encoding.UTF8))
                {
                    sw.WriteLine("PM001;DG001;S01;01/11/2026;15/11/2026;10/11/2026;0");
                    sw.WriteLine("PM002;DG002;S09;05/11/2026;19/11/2026;;0");
                    sw.WriteLine("PM003;DG003;S15;02/11/2026;16/11/2026;;0");
                    sw.WriteLine("PM004;DG004;S03;01/10/2026;15/10/2026;20/10/2026;25000");
                }
            }

            // 6. File datruoc.txt (MaDat;MaDocGia;MaSach;NgayDat;TrangThai) - tạo rỗng nếu chưa có
            string fileDatTruoc = Path.Combine(thuMucData, "datruoc.txt");
            if (!File.Exists(fileDatTruoc))
            {
                using (StreamWriter sw = new StreamWriter(fileDatTruoc, false, Encoding.UTF8))
                {
                }
            }
        }

        // ================= CÁC HÀM ĐỌC DỮ LIỆU TỪ FILE =================

        public static void DocTatCa()
        {
            DocUser();
            DocTheLoai();
            DocSach();
            DocDocGia();
            DocPhieuMuon();
            DocDatTruoc();

            // Tự động tính tiền phạt cho các phiếu đang quá hạn tính đến hôm nay
            CapNhatTienPhatQuaHan();
        }

        public static void DocUser()
        {
            DanhSachUser.Clear();
            string duongDan = Path.Combine(LayThuMucData(), "users.txt");
            if (!File.Exists(duongDan)) return;

            using (StreamReader sr = new StreamReader(duongDan, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length < 3)
                        {
                            GhiLog("Lỗi dòng User không đủ 3 cột: " + line);
                            continue;
                        }
                        User u = new User(parts[0].Trim(), parts[1].Trim(), parts[2].Trim());
                        DanhSachUser.Add(u);
                    }
                    catch (Exception ex)
                    {
                        GhiLog("Lỗi nạp User dòng: " + line + " - Chi tiết: " + ex.Message);
                        continue;
                    }
                }
            }
        }

        public static void DocTheLoai()
        {
            DanhSachTheLoai.Clear();
            string duongDan = Path.Combine(LayThuMucData(), "theloai.txt");
            if (!File.Exists(duongDan)) return;

            using (StreamReader sr = new StreamReader(duongDan, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length < 2)
                        {
                            GhiLog("Lỗi dòng Thể loại không đủ cột: " + line);
                            continue;
                        }
                        string maCha = (parts.Length >= 3) ? parts[2].Trim() : "";
                        TheLoai tl = new TheLoai(parts[0].Trim(), parts[1].Trim(), maCha);
                        DanhSachTheLoai.Add(tl);
                    }
                    catch (Exception ex)
                    {
                        GhiLog("Lỗi nạp Thể loại dòng: " + line + " - Chi tiết: " + ex.Message);
                        continue;
                    }
                }
            }
        }

        public static void DocSach()
        {
            DanhSachSach.Clear();
            string duongDan = Path.Combine(LayThuMucData(), "sach.txt");
            if (!File.Exists(duongDan)) return;

            using (StreamReader sr = new StreamReader(duongDan, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length < 7)
                        {
                            GhiLog("Lỗi dòng Sách không đủ 7 cột: " + line);
                            continue;
                        }

                        int namXB;
                        if (!int.TryParse(parts[3].Trim(), out namXB))
                        {
                            GhiLog("Lỗi Năm XB không hợp lệ dòng Sách: " + line);
                            continue;
                        }

                        int soLuong;
                        if (!int.TryParse(parts[5].Trim(), out soLuong))
                        {
                            GhiLog("Lỗi Số lượng không hợp lệ dòng Sách: " + line);
                            continue;
                        }

                        Sach s = new Sach(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), namXB, parts[4].Trim(), soLuong, parts[6].Trim());
                        DanhSachSach.Add(s);
                    }
                    catch (Exception ex)
                    {
                        GhiLog("Lỗi nạp Sách dòng: " + line + " - Chi tiết: " + ex.Message);
                        continue;
                    }
                }
            }
        }

        public static void DocDocGia()
        {
            DanhSachDocGia.Clear();
            string duongDan = Path.Combine(LayThuMucData(), "docgia.txt");
            if (!File.Exists(duongDan)) return;

            using (StreamReader sr = new StreamReader(duongDan, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length < 5)
                        {
                            GhiLog("Lỗi dòng Độc giả không đủ 5 cột: " + line);
                            continue;
                        }

                        DateTime ngayHetHan;
                        if (!DateTime.TryParseExact(parts[3].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayHetHan))
                        {
                            if (!DateTime.TryParse(parts[3].Trim(), out ngayHetHan))
                            {
                                GhiLog("Lỗi Ngày hết hạn không hợp lệ dòng Độc giả: " + line);
                                continue;
                            }
                        }

                        DocGia dg = new DocGia(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), ngayHetHan, parts[4].Trim());
                        DanhSachDocGia.Add(dg);
                    }
                    catch (Exception ex)
                    {
                        GhiLog("Lỗi nạp Độc giả dòng: " + line + " - Chi tiết: " + ex.Message);
                        continue;
                    }
                }
            }
        }

        public static void DocPhieuMuon()
        {
            DanhSachPhieuMuon.Clear();
            string duongDan = Path.Combine(LayThuMucData(), "phieumuon.txt");
            if (!File.Exists(duongDan)) return;

            using (StreamReader sr = new StreamReader(duongDan, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length < 7)
                        {
                            GhiLog("Lỗi dòng Phiếu mượn không đủ 7 cột: " + line);
                            continue;
                        }

                        DateTime ngayMuon;
                        if (!DateTime.TryParseExact(parts[3].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayMuon))
                        {
                            if (!DateTime.TryParse(parts[3].Trim(), out ngayMuon))
                            {
                                GhiLog("Lỗi Ngày mượn không hợp lệ dòng Phiếu mượn: " + line);
                                continue;
                            }
                        }

                        DateTime hanTra;
                        if (!DateTime.TryParseExact(parts[4].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out hanTra))
                        {
                            if (!DateTime.TryParse(parts[4].Trim(), out hanTra))
                            {
                                GhiLog("Lỗi Hạn trả không hợp lệ dòng Phiếu mượn: " + line);
                                continue;
                            }
                        }

                        int tienPhat = 0;
                        int.TryParse(parts[6].Trim(), out tienPhat);

                        PhieuMuon pm = new PhieuMuon(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), ngayMuon, hanTra, parts[5].Trim(), tienPhat);
                        DanhSachPhieuMuon.Add(pm);
                    }
                    catch (Exception ex)
                    {
                        GhiLog("Lỗi nạp Phiếu mượn dòng: " + line + " - Chi tiết: " + ex.Message);
                        continue;
                    }
                }
            }
        }

        public static void DocDatTruoc()
        {
            DanhSachDatTruoc.Clear();
            string duongDan = Path.Combine(LayThuMucData(), "datruoc.txt");
            if (!File.Exists(duongDan)) return;

            using (StreamReader sr = new StreamReader(duongDan, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length < 5)
                        {
                            GhiLog("Lỗi dòng Đặt trước không đủ 5 cột: " + line);
                            continue;
                        }

                        DateTime ngayDat;
                        if (!DateTime.TryParseExact(parts[3].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayDat))
                        {
                            GhiLog("Lỗi Ngày đặt không hợp lệ dòng Đặt trước: " + line);
                            continue;
                        }

                        DatTruoc dt = new DatTruoc(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), ngayDat, parts[4].Trim());
                        DanhSachDatTruoc.Add(dt);
                    }
                    catch (Exception ex)
                    {
                        GhiLog("Lỗi nạp Đặt trước dòng: " + line + " - Chi tiết: " + ex.Message);
                        continue;
                    }
                }
            }
        }

        // ================= CÁC HÀM GHI DỮ LIỆU RA FILE =================

        public static void GhiUser()
        {
            try
            {
                string duongDan = Path.Combine(LayThuMucData(), "users.txt");
                using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
                {
                    foreach (User u in DanhSachUser)
                    {
                        sw.WriteLine(u.TaiKhoan + ";" + u.MatKhau + ";" + u.VaiTro);
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog("Lỗi ghi file users.txt: " + ex.Message);
            }
        }

        public static void GhiTheLoai()
        {
            try
            {
                string duongDan = Path.Combine(LayThuMucData(), "theloai.txt");
                using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
                {
                    foreach (TheLoai tl in DanhSachTheLoai)
                    {
                        sw.WriteLine(tl.Ma + ";" + tl.Ten + ";" + tl.MaCha);
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog("Lỗi ghi file theloai.txt: " + ex.Message);
            }
        }

        public static void GhiSach()
        {
            try
            {
                string duongDan = Path.Combine(LayThuMucData(), "sach.txt");
                using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
                {
                    foreach (Sach s in DanhSachSach)
                    {
                        sw.WriteLine(s.Ma + ";" + s.Ten + ";" + s.TacGia + ";" + s.NamXB.ToString() + ";" + s.MaTheLoai + ";" + s.SoLuong.ToString() + ";" + s.Anh);
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog("Lỗi ghi file sach.txt: " + ex.Message);
            }
        }

        public static void GhiDocGia()
        {
            try
            {
                string duongDan = Path.Combine(LayThuMucData(), "docgia.txt");
                using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
                {
                    foreach (DocGia dg in DanhSachDocGia)
                    {
                        sw.WriteLine(dg.Ma + ";" + dg.HoTen + ";" + dg.Lop + ";" + dg.NgayHetHan.ToString("dd/MM/yyyy") + ";" + dg.TrangThai);
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog("Lỗi ghi file docgia.txt: " + ex.Message);
            }
        }

        public static void GhiPhieuMuon()
        {
            try
            {
                string duongDan = Path.Combine(LayThuMucData(), "phieumuon.txt");
                using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
                {
                    foreach (PhieuMuon pm in DanhSachPhieuMuon)
                    {
                        sw.WriteLine(pm.SoPhieu + ";" + pm.MaDocGia + ";" + pm.MaSach + ";" + pm.NgayMuon.ToString("dd/MM/yyyy") + ";" + pm.HanTra.ToString("dd/MM/yyyy") + ";" + pm.NgayTra + ";" + pm.TienPhat.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog("Lỗi ghi file phieumuon.txt: " + ex.Message);
            }
        }

        public static void GhiDatTruoc()
        {
            try
            {
                string duongDan = Path.Combine(LayThuMucData(), "datruoc.txt");
                using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
                {
                    foreach (DatTruoc dt in DanhSachDatTruoc)
                    {
                        sw.WriteLine(dt.MaDat + ";" + dt.MaDocGia + ";" + dt.MaSach + ";" + dt.NgayDat.ToString("dd/MM/yyyy") + ";" + dt.TrangThai);
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog("Lỗi ghi file datruoc.txt: " + ex.Message);
            }
        }

        // ================= XUẤT CSV DÙNG CHUNG =================

        // Ký tự phân cách cột mà Excel dùng để tách cột khi mở file .csv trên máy này.
        // Excel lấy "List separator" của Windows; nhưng nếu ký tự đó trùng với dấu thập phân
        // (máy vùng Việt Nam thường đặt cả hai là ',') thì Excel chuyển sang dùng ';'.
        public static string LayKyTuPhanCachCSV()
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            string kyTu = ti.ListSeparator;
            string dauThapPhan = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (string.IsNullOrEmpty(kyTu) || kyTu == dauThapPhan)
            {
                kyTu = ";";
            }
            return kyTu;
        }

        // Ghép các ô thành 1 dòng CSV, tự bọc ngoặc kép ô có chứa ký tự đặc biệt
        public static string TaoDongCSV(params string[] cacO)
        {
            string phanCach = LayKyTuPhanCachCSV();
            string[] ketQua = new string[cacO.Length];
            for (int i = 0; i < cacO.Length; i++)
            {
                string giaTri = cacO[i] ?? "";
                if (giaTri.Contains(phanCach) || giaTri.Contains(",") || giaTri.Contains(";") ||
                    giaTri.Contains("\"") || giaTri.Contains("\n") || giaTri.Contains("\r"))
                {
                    giaTri = "\"" + giaTri.Replace("\"", "\"\"") + "\"";
                }
                ketQua[i] = giaTri;
            }
            return string.Join(phanCach, ketQua);
        }

        // Ghi các dòng của 1 ListView (kể cả tiêu đề cột) ra file CSV UTF-8 có BOM để Excel đọc đúng tiếng Việt
        public static void XuatListViewRaCSV(ListView lv, string duongDan)
        {
            using (StreamWriter sw = new StreamWriter(duongDan, false, new UTF8Encoding(true)))
            {
                string[] tieuDe = new string[lv.Columns.Count];
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    tieuDe[i] = lv.Columns[i].Text;
                }
                sw.WriteLine(TaoDongCSV(tieuDe));

                foreach (ListViewItem item in lv.Items)
                {
                    string[] o = new string[lv.Columns.Count];
                    for (int i = 0; i < o.Length; i++)
                    {
                        o[i] = (i < item.SubItems.Count) ? item.SubItems[i].Text : "";
                    }
                    sw.WriteLine(TaoDongCSV(o));
                }
            }
        }

        // ================= CÁC HÀM NGHIỆP VỤ MƯỢN - TRẢ DÙNG CHUNG =================

        // Đọc tiền phạt mỗi ngày quá hạn từ App.config (mặc định 5000 đồng)
        public static int LayTienPhatMoiNgay()
        {
            string giaTri = ConfigurationManager.AppSettings["TienPhatMoiNgay"];
            int tienPhat;
            if (!int.TryParse(giaTri, out tienPhat) || tienPhat < 0)
            {
                tienPhat = 5000;
            }
            return tienPhat;
        }

        // Phiếu chưa trả (cột NgayTra rỗng)
        public static bool ChuaTra(PhieuMuon pm)
        {
            return pm.NgayTra.Trim() == "";
        }

        // Phiếu chưa trả và đã quá hạn trả so với hôm nay
        public static bool DangQuaHan(PhieuMuon pm)
        {
            return ChuaTra(pm) && pm.HanTra.Date < DateTime.Now.Date;
        }

        // Tính tiền phạt của 1 phiếu tại mốc ngày cho trước: số ngày trễ x đơn giá trong App.config
        public static int TinhTienPhat(PhieuMuon pm, DateTime mocTinh)
        {
            int soNgayQuaHan = (mocTinh.Date - pm.HanTra.Date).Days;
            if (soNgayQuaHan <= 0)
            {
                return 0;
            }
            return soNgayQuaHan * LayTienPhatMoiNgay();
        }

        // Tự động cập nhật tiền phạt của các phiếu chưa trả tính đến hôm nay.
        // Phiếu đã trả giữ nguyên số tiền đã chốt lúc trả. Trả về true nếu có phiếu thay đổi (đã ghi file).
        public static bool CapNhatTienPhatQuaHan()
        {
            bool coThayDoi = false;
            DateTime homNay = DateTime.Now.Date;
            foreach (PhieuMuon pm in DanhSachPhieuMuon)
            {
                if (!ChuaTra(pm))
                {
                    continue;
                }
                int tienPhat = TinhTienPhat(pm, homNay);
                if (pm.TienPhat != tienPhat)
                {
                    pm.TienPhat = tienPhat;
                    coThayDoi = true;
                }
            }
            if (coThayDoi)
            {
                GhiPhieuMuon();
            }
            return coThayDoi;
        }

        // Đếm số sách độc giả đang giữ (chưa trả)
        public static int DemSachDangMuon(string maDocGia)
        {
            int dem = 0;
            foreach (PhieuMuon pm in DanhSachPhieuMuon)
            {
                if (pm.MaDocGia.ToLower() == maDocGia.ToLower() && ChuaTra(pm))
                {
                    dem++;
                }
            }
            return dem;
        }

        // Danh sách phiếu chưa trả đã quá hạn của 1 độc giả
        public static List<PhieuMuon> LayPhieuQuaHanCuaDocGia(string maDocGia)
        {
            List<PhieuMuon> ketQua = new List<PhieuMuon>();
            foreach (PhieuMuon pm in DanhSachPhieuMuon)
            {
                if (pm.MaDocGia.ToLower() == maDocGia.ToLower() && DangQuaHan(pm))
                {
                    ketQua.Add(pm);
                }
            }
            return ketQua;
        }

        // Tìm thể loại theo mã
        public static TheLoai TimTheLoai(string ma)
        {
            foreach (TheLoai tl in DanhSachTheLoai)
            {
                if (tl.Ma.ToLower() == ma.ToLower())
                {
                    return tl;
                }
            }
            return null;
        }

        // Lấy thể loại gốc (cấp cao nhất) của 1 thể loại; có chặn vòng lặp nếu dữ liệu lỗi
        public static TheLoai LayTheLoaiGoc(string maTheLoai)
        {
            TheLoai tl = TimTheLoai(maTheLoai);
            int buoc = 0;
            while (tl != null && tl.MaCha.Trim() != "" && buoc < 50)
            {
                TheLoai cha = TimTheLoai(tl.MaCha);
                if (cha == null)
                {
                    break;
                }
                tl = cha;
                buoc++;
            }
            return tl;
        }

        // Danh sách đặt trước đang chờ nhận của 1 cuốn sách (theo thứ tự đặt)
        public static List<DatTruoc> LayHangChoDatTruoc(string maSach)
        {
            List<DatTruoc> ketQua = new List<DatTruoc>();
            foreach (DatTruoc dt in DanhSachDatTruoc)
            {
                if (dt.MaSach.ToLower() == maSach.ToLower() && dt.TrangThai == "ChoNhan")
                {
                    ketQua.Add(dt);
                }
            }
            return ketQua;
        }
    }
}
