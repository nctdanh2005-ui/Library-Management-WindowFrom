using System;

namespace Library_Management
{
    // 1. Đối tượng Tài khoản người dùng hệ thống
    public class User
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; } // "QuanTri" hoặc "NhanVien"

        public User()
        {
            this.TaiKhoan = "";
            this.MatKhau = "";
            this.VaiTro = "NhanVien";
        }

        public User(string taiKhoan, string matKhau, string vaiTro)
        {
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
            this.VaiTro = vaiTro;
        }

        public override string ToString()
        {
            return this.TaiKhoan + " (" + this.VaiTro + ")";
        }
    }

    // 2. Đối tượng Thể loại sách (phân cấp Cha - Con)
    public class TheLoai
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MaCha { get; set; } // Thể loại gốc thì MaCha rỗng ""

        public TheLoai()
        {
            this.Ma = "";
            this.Ten = "";
            this.MaCha = "";
        }

        public TheLoai(string ma, string ten, string maCha)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.MaCha = maCha;
        }

        public override string ToString()
        {
            return this.Ten;
        }
    }

    // 3. Đối tượng Sách
    public class Sach
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TacGia { get; set; }
        public int NamXB { get; set; }
        public string MaTheLoai { get; set; }
        public int SoLuong { get; set; }
        public string Anh { get; set; } // Tên file ảnh trong thư mục Data/Images/

        public Sach()
        {
            this.Ma = "";
            this.Ten = "";
            this.TacGia = "";
            this.NamXB = DateTime.Now.Year;
            this.MaTheLoai = "";
            this.SoLuong = 0;
            this.Anh = "";
        }

        public Sach(string ma, string ten, string tacGia, int namXB, string maTheLoai, int soLuong, string anh)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.TacGia = tacGia;
            this.NamXB = namXB;
            this.MaTheLoai = maTheLoai;
            this.SoLuong = soLuong;
            this.Anh = anh;
        }

        public override string ToString()
        {
            return this.Ma + " - " + this.Ten;
        }
    }

    // 4. Đối tượng Độc giả
    public class DocGia
    {
        public string Ma { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TrangThai { get; set; } // "HoatDong" hoặc "BiKhoa"

        public DocGia()
        {
            this.Ma = "";
            this.HoTen = "";
            this.Lop = "";
            this.NgayHetHan = DateTime.Now.AddYears(1);
            this.TrangThai = "HoatDong";
        }

        public DocGia(string ma, string hoTen, string lop, DateTime ngayHetHan, string trangThai)
        {
            this.Ma = ma;
            this.HoTen = hoTen;
            this.Lop = lop;
            this.NgayHetHan = ngayHetHan;
            this.TrangThai = trangThai;
        }

        public override string ToString()
        {
            return this.Ma + " - " + this.HoTen;
        }
    }

    // 5. Đối tượng Phiếu mượn trả sách
    public class PhieuMuon
    {
        public string SoPhieu { get; set; }
        public string MaDocGia { get; set; }
        public string MaSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public string NgayTra { get; set; } // Chuỗi dd/MM/yyyy hoặc rỗng nếu chưa trả
        public int TienPhat { get; set; }

        public PhieuMuon()
        {
            this.SoPhieu = "";
            this.MaDocGia = "";
            this.MaSach = "";
            this.NgayMuon = DateTime.Now;
            this.HanTra = DateTime.Now.AddDays(14);
            this.NgayTra = "";
            this.TienPhat = 0;
        }

        public PhieuMuon(string soPhieu, string maDocGia, string maSach, DateTime ngayMuon, DateTime hanTra, string ngayTra, int tienPhat)
        {
            this.SoPhieu = soPhieu;
            this.MaDocGia = maDocGia;
            this.MaSach = maSach;
            this.NgayMuon = ngayMuon;
            this.HanTra = hanTra;
            this.NgayTra = ngayTra;
            this.TienPhat = tienPhat;
        }

        public override string ToString()
        {
            return "Phiếu " + this.SoPhieu + " (ĐG: " + this.MaDocGia + ", Sách: " + this.MaSach + ")";
        }
    }

    // 6. Đối tượng Đặt trước sách (độc giả xếp hàng chờ sách đang được mượn hết)
    public class DatTruoc
    {
        public string MaDat { get; set; }
        public string MaDocGia { get; set; }
        public string MaSach { get; set; }
        public DateTime NgayDat { get; set; }
        public string TrangThai { get; set; } // "ChoNhan", "DaNhan" hoặc "DaHuy"

        public DatTruoc()
        {
            this.MaDat = "";
            this.MaDocGia = "";
            this.MaSach = "";
            this.NgayDat = DateTime.Now;
            this.TrangThai = "ChoNhan";
        }

        public DatTruoc(string maDat, string maDocGia, string maSach, DateTime ngayDat, string trangThai)
        {
            this.MaDat = maDat;
            this.MaDocGia = maDocGia;
            this.MaSach = maSach;
            this.NgayDat = ngayDat;
            this.TrangThai = trangThai;
        }

        public override string ToString()
        {
            return "Đặt trước " + this.MaDat + " (ĐG: " + this.MaDocGia + ", Sách: " + this.MaSach + ")";
        }
    }
}

