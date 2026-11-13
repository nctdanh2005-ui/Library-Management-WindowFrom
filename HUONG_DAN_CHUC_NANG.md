# Tài liệu mô tả chức năng

## 1. Tổng quan

**Library Management** là ứng dụng Windows Forms quản lý thư viện, chạy trên
.NET Framework 4.7.2. Ứng dụng sử dụng giao diện MDI, lưu dữ liệu bằng các
file văn bản UTF-8 và quản lý dữ liệu trong các danh sách đối tượng tĩnh.

Các phân hệ chính:

1. Đăng nhập và phân quyền.
2. Giao diện chính MDI.
3. Quản lý thể loại và sách.
4. Quản lý độc giả.
5. Quản lý mượn - trả sách.
6. Lưu trữ, nạp dữ liệu, xuất CSV và in thông tin.

Ứng dụng được khởi động từ `Program.Main()` và mở form đăng nhập trước tiên.

## 2. Khởi động và nạp dữ liệu

Khi form đăng nhập được mở:

1. Ứng dụng xác định thư mục dữ liệu theo khóa `ThuMucData` trong
   `App.config`. Nếu đường dẫn là tương đối, đường dẫn được tính từ thư mục
   chứa file thực thi.
2. Nếu thư mục `Data` hoặc `Data/Images` chưa tồn tại, ứng dụng tự tạo.
3. Nếu các file dữ liệu chưa tồn tại, ứng dụng sinh dữ liệu mẫu:
   - `users.txt`
   - `theloai.txt`
   - `sach.txt`
   - `docgia.txt`
   - `phieumuon.txt`
   - 20 ảnh bìa mẫu trong `Images`
4. Ứng dụng đọc toàn bộ dữ liệu vào các danh sách tĩnh trong `DuLieuChung`.
5. Tài khoản đã chọn ghi nhớ được đọc từ Windows Registry.

Các lỗi đọc file được ghi vào `Data/log.txt`. Những dòng dữ liệu không hợp lệ
được bỏ qua để ứng dụng vẫn có thể tiếp tục chạy.

## 3. Đăng nhập và phân quyền

### 3.1. Đăng nhập

Form `FrmDangNhap` cung cấp:

- Nhập tên tài khoản.
- Nhập mật khẩu, hiển thị bằng ký tự che.
- Tùy chọn ghi nhớ tên tài khoản.
- Nút đăng nhập.
- Nút thoát chương trình.

Khi đăng nhập:

1. Tên tài khoản được loại bỏ khoảng trắng ở đầu và cuối.
2. Tài khoản được tìm trong danh sách người dùng, không phân biệt hoa thường.
3. Mật khẩu phải khớp chính xác.
4. Người dùng hợp lệ được lưu vào `NguoiDungHienTai`.
5. Form đăng nhập được ẩn và mở `FrmMain`.

Nếu nhập sai liên tiếp 3 lần, nút đăng nhập bị vô hiệu hóa cho đến khi đóng
form. Khi bỏ chọn ghi nhớ, giá trị tài khoản đã lưu trong Registry sẽ bị xóa.

### 3.2. Vai trò người dùng

Hệ thống có hai vai trò:

- `QuanTri`: được sử dụng đầy đủ các chức năng, bao gồm xem cấu hình hệ thống.
- `NhanVien`: được sử dụng các chức năng nghiệp vụ nhưng mục quản trị hệ thống
  bị vô hiệu hóa.

Tài khoản mẫu:

| Tài khoản | Mật khẩu | Vai trò |
|---|---|---|
| `admin` | `123456` | `QuanTri` |
| `nhanvien` | `123456` | `NhanVien` |
| `thuthu` | `123456` | `NhanVien` |

## 4. Giao diện chính MDI

`FrmMain` là form cha MDI của toàn bộ hệ thống.

### 4.1. Thanh trạng thái

Thanh trạng thái hiển thị:

- Tên thư viện lấy từ `App.config`.
- Tài khoản và vai trò đang đăng nhập.
- Đồng hồ ngày giờ hiện tại, cập nhật mỗi giây.

### 4.2. Mở các phân hệ

Menu chính cho phép mở:

- Quản lý sách.
- Quản lý độc giả.
- Mượn - trả sách.

Một phân hệ chỉ được mở một lần. Nếu form đã mở, hệ thống kích hoạt form cũ
thay vì tạo bản sao mới.

### 4.3. Sắp xếp cửa sổ

Các lệnh giao diện MDI gồm:

- Xếp cửa sổ dạng Cascade.
- Xếp cửa sổ theo chiều ngang.
- Xếp cửa sổ theo chiều dọc.
- Đóng tất cả cửa sổ con.

### 4.4. Giao diện người dùng

Người dùng có thể:

- Chọn màu nền.
- Chọn phông chữ.
- Khôi phục màu và phông chữ mặc định.
- Lưu và tải lại vị trí, kích thước, trạng thái phóng to của cửa sổ.

Các thiết lập giao diện được lưu trong Registry tại:

`HKEY_CURRENT_USER\Software\LibraryManagement\GiaoDien`

### 4.5. Đăng xuất và thoát

- **Đăng xuất:** xác nhận, xóa người dùng hiện tại, đóng các phiên làm việc và
  quay lại form đăng nhập.
- **Thoát:** hỏi xác nhận trước khi đóng chương trình.
- Khi form chính đóng, giao diện hiện tại được lưu vào Registry.

## 5. Quản lý thể loại và sách

Phân hệ nằm trong `FrmSach`.

### 5.1. Cây thể loại

Thể loại được hiển thị bằng `TreeView` gồm hai cấp:

- Thể loại gốc có `MaCha` rỗng.
- Thể loại con có `MaCha` là mã thể loại gốc.

Khi chọn một nút:

1. Mã và tên thể loại được đưa vào vùng nhập liệu.
2. Hệ thống thu thập mã thể loại đang chọn và các thể loại con trực tiếp.
3. Danh sách sách được lọc theo các mã đó.

### 5.2. Thêm thể loại gốc

Người dùng nhập mã và tên, sau đó chọn **Thêm gốc**.

Điều kiện:

- Mã không được rỗng.
- Tên không được rỗng.
- Mã không được trùng, không phân biệt hoa thường.

Dữ liệu được thêm với `MaCha` rỗng và ghi vào `theloai.txt`.

### 5.3. Thêm thể loại con

Người dùng chọn thể loại cha, nhập mã và tên, sau đó chọn **Thêm con**.

Điều kiện kiểm tra giống thêm thể loại gốc. Mã cha được lấy từ nút đang chọn
trên cây.

### 5.4. Sửa thể loại

Chức năng sửa chỉ đổi tên thể loại đang chọn. Mã thể loại và quan hệ cha - con
được giữ nguyên.

### 5.5. Xóa thể loại

Một thể loại chỉ được xóa khi:

- Không còn thể loại con trực tiếp.
- Không có sách nào đang tham chiếu đến mã thể loại đó.

Sau khi xác nhận, dữ liệu được ghi lại và cây thể loại được nạp lại.

### 5.6. Hiển thị và tìm kiếm sách

Danh sách sách hiển thị:

- Mã sách.
- Tên sách.
- Tác giả.
- Năm xuất bản.
- Tên thể loại.
- Số lượng tồn kho.
- Tên file ảnh.

Chức năng tìm kiếm tìm theo tên sách, không phân biệt hoa thường. Nút **Tất
cả** xóa từ khóa, bỏ chọn thể loại và hiển thị lại toàn bộ sách.

### 5.7. Thêm sách

Thông tin cần nhập:

- Mã sách.
- Tên sách.
- Tác giả.
- Năm xuất bản.
- Thể loại.
- Số lượng.
- Ảnh bìa tùy chọn.

Điều kiện:

- Các trường mã, tên và tác giả không được rỗng.
- Năm xuất bản nằm trong khoảng từ 1900 đến năm hiện tại.
- Số lượng là số nguyên không âm.
- Mã sách không được trùng.
- Phải chọn thể loại.

Sau khi thêm, dữ liệu được ghi vào `sach.txt`.

### 5.8. Sửa và xóa sách

Khi chọn một dòng sách, thông tin được đưa lên vùng nhập liệu để sửa. Hệ thống
kiểm tra lại tên, tác giả, năm, thể loại và số lượng trước khi lưu.

Khi xóa sách, người dùng phải xác nhận. Sau đó sách bị xóa khỏi danh sách và
`sach.txt` được ghi lại.

### 5.9. Quản lý ảnh bìa

Chức năng chọn ảnh:

1. Mở hộp thoại chọn file ảnh.
2. Chấp nhận JPG, JPEG và PNG.
3. Tạo thư mục `Data/Images` nếu chưa có.
4. Sao chép ảnh vào thư mục dữ liệu.
5. Lưu tên ảnh vào thuộc tính `Anh` của sách.

Khi chọn sách, ảnh bìa được nạp vào `PictureBox`. Ảnh cũ được giải phóng trước
khi nạp ảnh mới.

## 6. Quản lý độc giả

Phân hệ nằm trong `FrmDocGia`.

### 6.1. Danh sách độc giả

Danh sách hiển thị:

- Mã độc giả.
- Họ tên.
- Lớp.
- Ngày hết hạn thẻ.
- Trạng thái.

Các lớp được tự động thu thập không trùng lặp vào ComboBox lọc.

### 6.2. Tìm kiếm và lọc

- Tìm kiếm theo họ tên.
- Lọc theo lớp.
- Có thể kết hợp tìm kiếm và lọc.
- Nút **Tất cả** xóa từ khóa và bỏ lọc lớp.
- Nhấn Enter trong ô tìm kiếm cũng thực hiện tìm kiếm.

### 6.3. Màu cảnh báo thẻ

Màu nền dòng dữ liệu được áp dụng theo trạng thái:

- Màu hồng: thẻ bị khóa hoặc đã hết hạn.
- Màu vàng: còn dưới 7 ngày.
- Màu mặc định: thẻ còn hiệu lực và không bị khóa.

### 6.4. Thêm độc giả

Thông tin cần nhập:

- Mã độc giả.
- Họ tên.
- Lớp.
- Ngày hết hạn theo định dạng `dd/MM/yyyy`.
- Trạng thái `HoatDong` hoặc `BiKhoa`.

Mã độc giả không được trùng. Dữ liệu hợp lệ được thêm vào danh sách và ghi
vào `docgia.txt`.

### 6.5. Sửa độc giả

Người dùng chọn một độc giả, chỉnh sửa thông tin rồi chọn **Sửa**.

Hệ thống kiểm tra:

- Đã chọn độc giả cần sửa.
- Mã mới không rỗng.
- Mã mới không trùng độc giả khác.
- Họ tên và lớp không rỗng.
- Ngày hết hạn đúng định dạng.

### 6.6. Xóa độc giả

Sau khi xác nhận, độc giả được xóa khỏi danh sách và `docgia.txt` được ghi lại.

### 6.7. Gia hạn thẻ

Người dùng có thể chọn:

- **Có:** gia hạn thêm 6 tháng.
- **Không:** gia hạn thêm 12 tháng.
- **Hủy:** không thay đổi.

Nếu thẻ đã hết hạn, thời điểm bắt đầu gia hạn là ngày hiện tại. Nếu chưa hết
hạn, thời gian được cộng tiếp vào ngày hết hạn cũ.

### 6.8. Khóa và mở khóa thẻ

Nút khóa/mở khóa chuyển trạng thái giữa:

- `HoatDong`
- `BiKhoa`

Nhãn nút được thay đổi theo trạng thái hiện tại. Mọi thay đổi được lưu vào
`docgia.txt`.

### 6.9. Xuất danh sách độc giả

Chức năng xuất CSV ghi các dòng đang hiển thị trên ListView, bao gồm cả điều
kiện tìm kiếm và lọc hiện tại.

File CSV:

- Có BOM UTF-8 để tương thích với Excel.
- Có các cột `Ma`, `HoTen`, `Lop`, `NgayHetHan`, `TrangThai`.
- Tự động escape giá trị chứa dấu phẩy, dấu chấm phẩy hoặc dấu ngoặc kép.

### 6.10. In thẻ độc giả

Người dùng chọn một độc giả và xuất file TXT dạng khung. Nội dung gồm:

- Mã và họ tên.
- Lớp.
- Ngày hết hạn.
- Trạng thái.
- Tình trạng thẻ tính theo ngày hiện tại.
- Ngày in.

## 7. Quản lý mượn - trả sách

Phân hệ nằm trong `FrmMuonTra`.

### 7.1. Danh sách phiếu

Danh sách hiển thị:

- Số phiếu.
- Độc giả.
- Sách.
- Ngày mượn.
- Hạn trả.
- Ngày trả.
- Tiền phạt.
- Trạng thái.

Trạng thái được xác định như sau:

- `Đã trả`: trường ngày trả có dữ liệu.
- `Quá hạn`: chưa trả và hạn trả trước ngày hiện tại.
- `Đang mượn`: chưa trả và chưa quá hạn.

### 7.2. Tìm kiếm và lọc phiếu

Từ khóa tìm kiếm được đối chiếu với:

- Số phiếu.
- Mã độc giả.
- Họ tên độc giả.
- Mã sách.
- Tên sách.

Có thể lọc theo:

- Tất cả.
- Đang mượn.
- Quá hạn.
- Đã trả.

Nút **Tất cả** xóa từ khóa và đưa bộ lọc về trạng thái mặc định.

### 7.3. Màu cảnh báo phiếu

- Xanh lá nhạt: phiếu đã trả.
- Hồng: phiếu chưa trả và đã quá hạn.
- Vàng: phiếu chưa trả và còn tối đa 3 ngày đến hạn.

### 7.4. Sinh số phiếu

Số phiếu mới có dạng `PMxxx`.

Ứng dụng tìm số lớn nhất trong các phiếu hiện có, tăng thêm 1 và định dạng đủ
ba chữ số. Ví dụ: sau `PM009` sẽ tạo `PM010`.

### 7.5. Lập phiếu mượn

Người dùng chọn độc giả, chọn sách, nhập ngày mượn và hạn trả.

Điều kiện:

1. Phải chọn độc giả và sách.
2. Thẻ độc giả không bị khóa.
3. Thẻ độc giả chưa hết hạn.
4. Sách còn tồn kho.
5. Độc giả không được mượn cùng cuốn sách khi phiếu trước đó chưa trả.
6. Ngày mượn và hạn trả đúng định dạng `dd/MM/yyyy`.
7. Hạn trả không được trước ngày mượn.

Khi lập thành công:

- Tạo phiếu mới.
- Giảm tồn kho sách đi 1.
- Ghi `phieumuon.txt`.
- Ghi `sach.txt`.
- Làm mới danh sách và thống kê.

Ngày mượn mặc định là ngày hiện tại, hạn trả mặc định sau 14 ngày.

### 7.6. Trả sách

Người dùng chọn phiếu chưa trả và nhập ngày trả. Nếu để trống, ngày trả được
lấy là ngày hiện tại.

Điều kiện:

- Phiếu phải tồn tại.
- Phiếu chưa được trả trước đó.
- Ngày trả đúng định dạng `dd/MM/yyyy`.
- Ngày trả không được trước ngày mượn.

Tiền phạt được tính theo công thức:

```text
Số ngày quá hạn = max(0, Ngày trả - Hạn trả)
Tiền phạt = Số ngày quá hạn x TienPhatMoiNgay
```

Khi xác nhận trả:

- Lưu ngày trả.
- Lưu tiền phạt.
- Tăng tồn kho sách lên 1.
- Ghi lại `phieumuon.txt` và `sach.txt`.

### 7.7. Tính tiền phạt

Chức năng này dùng để tính lại tiền phạt của phiếu đang chọn:

- Phiếu đã trả: tính đến ngày trả thực tế.
- Phiếu chưa trả: tạm tính đến ngày hiện tại.

Người dùng xác nhận trước khi số tiền được cập nhật vào phiếu.

Đơn giá phạt lấy từ `App.config`, mặc định là 5.000 đồng/ngày nếu cấu hình
không hợp lệ.

### 7.8. Xóa phiếu

Sau khi xác nhận:

- Phiếu đã trả: chỉ xóa phiếu.
- Phiếu chưa trả: hoàn lại 1 cuốn sách vào tồn kho trước khi xóa.

Sau đó hệ thống ghi lại cả hai file `phieumuon.txt` và `sach.txt`.

### 7.9. Thống kê nhanh

Vùng thống kê hiển thị:

- Tổng số phiếu.
- Số phiếu đang mượn.
- Số phiếu quá hạn.
- Số phiếu đã trả.
- Tổng tiền phạt đang lưu trong dữ liệu.

### 7.10. Làm mới dữ liệu

Nút làm mới:

1. Xóa tìm kiếm và bộ lọc.
2. Đọc lại sách, độc giả và phiếu mượn từ file.
3. Nạp lại các ComboBox.
4. Đặt lại ngày mặc định.
5. Hiển thị lại danh sách và thống kê.

Chức năng này dùng để đồng bộ dữ liệu khi một phân hệ khác vừa thay đổi file.

### 7.11. Xuất danh sách phiếu

File CSV xuất các phiếu đang hiển thị, bao gồm cả điều kiện tìm kiếm và lọc.

Các cột:

`SoPhieu`, `DocGia`, `Sach`, `NgayMuon`, `HanTra`, `NgayTra`, `TienPhat`,
`TrangThai`.

File được ghi bằng UTF-8 có BOM và có xử lý escape dữ liệu CSV.

### 7.12. In phiếu mượn

Phiếu đang chọn được xuất thành file TXT dạng khung, gồm:

- Số phiếu.
- Thông tin độc giả.
- Thông tin sách và tác giả.
- Ngày mượn, hạn trả, ngày trả.
- Trạng thái.
- Tiền phạt hoặc tiền phạt tạm tính.
- Ngày in.

## 8. Dữ liệu và mô hình đối tượng

Các lớp dữ liệu được khai báo trong `Models.cs`.

### 8.1. `User`

| Thuộc tính | Ý nghĩa |
|---|---|
| `TaiKhoan` | Tên đăng nhập |
| `MatKhau` | Mật khẩu |
| `VaiTro` | Vai trò người dùng |

### 8.2. `TheLoai`

| Thuộc tính | Ý nghĩa |
|---|---|
| `Ma` | Mã thể loại |
| `Ten` | Tên thể loại |
| `MaCha` | Mã thể loại cha, rỗng nếu là thể loại gốc |

### 8.3. `Sach`

| Thuộc tính | Ý nghĩa |
|---|---|
| `Ma` | Mã sách |
| `Ten` | Tên sách |
| `TacGia` | Tác giả |
| `NamXB` | Năm xuất bản |
| `MaTheLoai` | Mã thể loại |
| `SoLuong` | Số lượng tồn kho |
| `Anh` | Tên file ảnh bìa |

### 8.4. `DocGia`

| Thuộc tính | Ý nghĩa |
|---|---|
| `Ma` | Mã độc giả |
| `HoTen` | Họ tên |
| `Lop` | Lớp |
| `NgayHetHan` | Ngày hết hạn thẻ |
| `TrangThai` | `HoatDong` hoặc `BiKhoa` |

### 8.5. `PhieuMuon`

| Thuộc tính | Ý nghĩa |
|---|---|
| `SoPhieu` | Số phiếu |
| `MaDocGia` | Mã độc giả |
| `MaSach` | Mã sách |
| `NgayMuon` | Ngày mượn |
| `HanTra` | Hạn trả |
| `NgayTra` | Ngày trả, rỗng nếu chưa trả |
| `TienPhat` | Tiền phạt |

## 9. Định dạng file dữ liệu

Các file dữ liệu dùng dấu chấm phẩy `;` làm ký tự phân cách.

### `users.txt`

```text
TaiKhoan;MatKhau;VaiTro
```

### `theloai.txt`

```text
Ma;Ten;MaCha
```

### `sach.txt`

```text
Ma;Ten;TacGia;NamXB;MaTheLoai;SoLuong;Anh
```

### `docgia.txt`

```text
Ma;HoTen;Lop;NgayHetHan;TrangThai
```

### `phieumuon.txt`

```text
SoPhieu;MaDocGia;MaSach;NgayMuon;HanTra;NgayTra;TienPhat
```

Ngày tháng được ghi theo định dạng `dd/MM/yyyy`.

## 10. Cấu hình ứng dụng

Các khóa cấu hình trong `App.config`:

| Khóa | Giá trị hiện tại | Ý nghĩa |
|---|---:|---|
| `TenThuVien` | `Thư viện Đại học` | Tên hiển thị trên giao diện |
| `ThuMucData` | `Data` | Thư mục lưu dữ liệu |
| `TienPhatMoiNgay` | `5000` | Tiền phạt mỗi ngày quá hạn |

## 11. Quy trình nghiệp vụ tổng quát

### Quy trình mượn sách

```text
Đăng nhập
  -> Chọn độc giả
  -> Chọn sách
  -> Kiểm tra thẻ và tồn kho
  -> Kiểm tra phiếu trùng
  -> Nhập ngày mượn và hạn trả
  -> Tạo phiếu
  -> Giảm tồn kho
  -> Lưu dữ liệu
```

### Quy trình trả sách

```text
Chọn phiếu chưa trả
  -> Nhập hoặc tự động lấy ngày trả
  -> Kiểm tra ngày trả
  -> Tính tiền phạt
  -> Xác nhận
  -> Cập nhật phiếu
  -> Tăng tồn kho
  -> Lưu dữ liệu
```

## 12. Cấu trúc dự án liên quan

- `Program.cs`: điểm khởi động ứng dụng.
- `Models.cs`: các lớp mô hình dữ liệu.
- `DuLieuChung.cs`: danh sách dùng chung, đọc/ghi file và ghi log.
- `FrmDangNhap.cs`: đăng nhập, ghi nhớ tài khoản và khóa sau nhiều lần sai.
- `FrmMain.cs`: form MDI, menu, phân quyền và thiết lập giao diện.
- `FrmSach.cs`: thể loại, sách, tồn kho và ảnh bìa.
- `FrmDocGia.cs`: độc giả, thẻ, tìm kiếm, CSV và in thẻ.
- `FrmMuonTra.cs`: phiếu mượn, trả sách, tiền phạt, CSV và in phiếu.
- `Data/`: dữ liệu mẫu và ảnh bìa.

