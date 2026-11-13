# ĐỒ ÁN LẬP TRÌNH C# WINDOWS FORMS: HỆ THỐNG QUẢN LÝ THƯ VIỆN (ĐỀ 2)

## 📌 THÔNG TIN ĐỒ ÁN
- **Môn học:** Lập trình Trực quan / Lập trình Windows Forms (.NET Framework)
- **Nền tảng:** .NET Framework 4.7.2 / 4.8 - Visual Studio 2022
- **Kiến trúc:** Windows Forms (MDI Container), Quản lý dữ liệu bằng danh sách đối tượng tĩnh (`static List<T>`), lưu trữ tập tin văn bản (`*.txt`) định dạng UTF-8, cấu hình `App.config`, lưu vết `Registry`.
- **Phong cách lập trình:** 
  - Lập trình hướng đối tượng căn bản (OOP: Lớp, thuộc tính, constructor, phương thức `ToString`).
  - Sử dụng vòng lặp `foreach`, `for` và câu lệnh rẽ nhánh `if-else` thuần túy, nói không với LINQ / Lambda nâng cao nhằm đảm bảo tính minh bạch, dễ dàng giải thích trong các buổi thi vấn đáp.

---

## 👥 PHÂN CHIA NHIỆM VỤ NHÓM

| Thành viên | Vai trò | Nhiệm vụ phụ trách | Trạng thái |
| :--- | :--- | :--- | :---: |
| **Sinh viên 1** *(Trưởng nhóm)* | Leader / Core Dev | **Luồng 1:** Khởi tạo khung dự án, Cấu hình `App.config`, Quản lý dữ liệu tập trung (`DuLieuChung`), Đăng nhập & Ghi nhớ Registry (`FrmDangNhap`), Form chính MDI (`FrmMain`), Phân hệ Quản lý Sách & Danh mục Thể loại (`FrmSach`). | ✅ **Hoàn thành** |
| **Sinh viên 2** | Developer | **Luồng 2:** Phân hệ Quản lý Độc giả (`FrmDocGia`) - Thêm, sửa, xóa, tìm kiếm, lọc theo lớp, gia hạn thẻ, khóa/mở khóa, xuất CSV và in thẻ. | ✅ **Hoàn thành** |
| **Sinh viên 3** | Developer | **Luồng 3:** Phân hệ Mượn - Trả sách (`FrmMuonTra`) - Lập phiếu mượn, trả sách, trừ/cộng tồn kho sách, tính tiền phạt theo cấu hình ngày quá hạn. | ✅ **Hoàn thành** |

---

## 🗂️ CẤU TRÚC THƯ MỤC & FILE DỰ ÁN

```text
Library-Management/
│
├── .gitignore                          # Cấu hình bỏ qua bin/, obj/, .vs/ nhưng giữ lại Data/
├── README.md                           # Tài liệu hướng dẫn nhóm và giới thiệu đồ án
├── Library-Management.sln               # File Solution Visual Studio 2022
│
└── Library-Management/
    ├── App.config                      # Cấu hình: TenThuVien, ThuMucData, TienPhatMoiNgay
    ├── Models.cs                       # 5 Lớp OOP: User, TheLoai, Sach, DocGia, PhieuMuon
    ├── DuLieuChung.cs                  # Quản lý static List, Đọc/Ghi 5 file txt, sinh 20 sách & ảnh mẫu
    ├── Program.cs                      # Điểm khởi động ứng dụng (Application.Run(new FrmDangNhap()))
    │
    ├── FrmDangNhap.cs / .Designer.cs   # Form Đăng nhập (Ghi nhớ Registry, khóa sau 3 lần sai)
    ├── FrmMain.cs / .Designer.cs       # Form cha MDI (Menu, StatusStrip, đồng hồ, phân quyền)
    ├── FrmSach.cs / .Designer.cs       # Quản lý Sách & Thể loại (TreeView 2 cấp, ListView, ảnh)
    ├── FrmDocGia.cs / .Designer.cs     # Phân hệ Độc giả (CRUD, tìm kiếm/lọc, gia hạn, khóa thẻ, xuất CSV, in thẻ)
    ├── FrmMuonTra.cs / .Designer.cs    # Phân hệ Mượn - Trả sách (lập phiếu, trả sách, tồn kho, tiền phạt, CSV, in phiếu)
    │
    └── Data/                           # Thư mục chứa dữ liệu tĩnh
        ├── users.txt                   # Danh sách tài khoản người dùng
        ├── theloai.txt                 # Danh mục thể loại (Mã;Tên;MãCha)
        ├── sach.txt                    # Danh mục 20 cuốn sách mẫu
        ├── docgia.txt                  # Danh mục độc giả mẫu
        ├── phieumuon.txt               # Danh mục phiếu mượn mẫu
        ├── log.txt                     # Nhật ký ghi nhận lỗi hệ thống
        └── Images/                     # Thư mục lưu trữ ảnh bìa sách (*.jpg, *.png)
```

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

### 1. Dành cho SV1 (Đẩy code lên GitHub)
```bash
git remote add origin https://github.com/<tai-khoan>/Library-Management.git
git branch -M master
git push -u origin master
```

### 2. Dành cho SV2 & SV3 (Kéo code về và làm việc)
```bash
# Clone dự án về máy
git clone https://github.com/<tai-khoan>/Library-Management.git
cd Library-Management

# Mở solution bằng Visual Studio 2022
# Tạo nhánh riêng để làm nhiệm vụ của mình:
git checkout -b feature-docgia     # Đối với SV2
git checkout -b feature-muontra    # Đối với SV3
```

### 3. Tài khoản đăng nhập kiểm thử
- **Quản trị viên:** Tài khoản: `admin` | Mật khẩu: `123456` *(Toàn quyền hệ thống)*
- **Nhân viên:** Tài khoản: `nhanvien` | Mật khẩu: `123456` *(Bị làm mờ mục Quản trị hệ thống)*

---

## 🛠️ CHI TIẾT KỸ THUẬT QUAN TRỌNG TRONG LUỒNG 1

1. **TreeView không đệ quy:** Nạp cây danh mục 2 cấp bằng 2 vòng lặp `foreach` lồng nhau dựa vào thuộc tính `MaCha`.
2. **Lọc sách theo thể loại cha/con:** Thu thập mã thể loại được click và tất cả mã con trực tiếp để lọc dữ liệu trên `ListView`.
3. **Nạp ảnh bìa không khóa file:** Dùng `FileStream` và `Image.FromStream(fs)` trong khối `using` để file ảnh được giải phóng ngay, không bị lỗi "file being used by another process".
4. **An toàn dữ liệu:** Mọi dòng đọc từ file text đều được bọc `try-catch`, kiểm tra số cột và dùng `int.TryParse` / `DateTime.TryParseExact`. Dòng lỗi được ghi vào `Data/log.txt` và bỏ qua bằng lệnh `continue`.
5. **Ghi nhớ đăng nhập an toàn:** Lưu trữ tài khoản vào Windows Registry nhánh `CurrentUser\Software\QuanLyThuVien`. Khóa nút Đăng nhập sau 3 lần nhập sai liên tiếp.

## 🛠️ CHI TIẾT KỸ THUẬT QUAN TRỌNG TRONG LUỒNG 2

1. **Quản lý độc giả:** Hỗ trợ thêm, sửa và xóa độc giả; dữ liệu được kiểm tra mã trùng, ngày hết hạn theo định dạng `dd/MM/yyyy` và lưu vào `Data/docgia.txt`.
2. **Tìm kiếm và lọc:** Tìm kiếm theo họ tên kết hợp lọc theo lớp; danh sách lớp được tự động thu thập không trùng lặp từ dữ liệu độc giả.
3. **Cảnh báo hạn thẻ:** Dòng độc giả bị khóa hoặc đã hết hạn được tô màu hồng; thẻ sắp hết hạn trong vòng 7 ngày được tô màu vàng.
4. **Quản lý trạng thái thẻ:** Hỗ trợ gia hạn, khóa và mở khóa thẻ độc giả, đồng thời cập nhật lại dữ liệu trên file.
5. **Xuất và in:** Hỗ trợ xuất danh sách độc giả ra CSV và tạo bản in thẻ cho độc giả đang chọn.

## 🛠️ CHI TIẾT KỸ THUẬT QUAN TRỌNG TRONG LUỒNG 3

1. **Lập phiếu mượn:** Sinh số phiếu tự động dạng `PMxxx` (lấy số lớn nhất đang có cộng 1); kiểm tra thẻ độc giả (đang bị khóa / đã hết hạn), kiểm tra tồn kho và chặn trường hợp độc giả đang mượn chính cuốn sách đó mà chưa trả.
2. **Trừ / cộng tồn kho:** Lập phiếu thì `SoLuong` của sách giảm 1, trả sách thì tăng 1; xóa một phiếu chưa trả sẽ hoàn lại 1 cuốn vào kho. Mọi thay đổi đều ghi lại cả `sach.txt` và `phieumuon.txt` để đồng bộ với phân hệ Sách.
3. **Trả sách:** Ngày trả lấy từ ô nhập (bỏ trống thì lấy ngày hôm nay), kiểm tra không trước ngày mượn và chặn trả trùng phiếu đã trả.
4. **Tính tiền phạt:** `Số ngày quá hạn = Ngày trả − Hạn trả` (âm thì quy về 0), nhân với `TienPhatMoiNgay` đọc từ `App.config` (mặc định 5.000 đ/ngày). Phiếu đã trả thì tính theo ngày trả thực tế, phiếu chưa trả thì tạm tính đến hôm nay.
5. **Tìm kiếm và lọc:** Tìm theo số phiếu / mã hoặc họ tên độc giả / mã hoặc tên sách; lọc theo trạng thái `Đang mượn`, `Quá hạn`, `Đã trả`.
6. **Cảnh báo màu:** Dòng quá hạn chưa trả tô nền hồng, sắp đến hạn (còn tối đa 3 ngày) tô nền vàng, phiếu đã trả tô nền xanh lá nhạt — đồng bộ quy ước màu với phân hệ Độc giả.
7. **Xuất và in:** Xuất danh sách phiếu đang hiển thị ra CSV (UTF-8 có BOM để Excel không lỗi tiếng Việt) và in phiếu mượn đang chọn ra file `.txt` dạng khung.
