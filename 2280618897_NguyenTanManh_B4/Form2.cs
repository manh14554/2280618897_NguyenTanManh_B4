using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2280618897_NguyenTanManh_B4
{
    public partial class Form2 : Form
    {
        public delegate void AddNhanVien(NhanVien nhanvien);
        public delegate void SuaNhanVien(NhanVien nhanvien);
        private NhanVien _nhanVien; // Lưu trữ NhanVien đang chỉnh sửa
        private Mode _currentMode; // Chế độ hiện tại (Thêm hoặc Sửa)
        public enum Mode
        {
            Add,
            Edit
        }
        public Form2()
        {
            InitializeComponent();
            _currentMode = Mode.Add;
        }
        public AddNhanVien OnAddNhanVien;
        public SuaNhanVien OnSuaNhanVien;
        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (_currentMode == Mode.Add) // Nếu đang ở chế độ Thêm
            {
                var nhanvien = new NhanVien(int.Parse(txtMSNV.Text), txtTenNV.Text, double.Parse(txtLuongCB.Text));
                OnAddNhanVien?.Invoke(nhanvien); // Gọi sự kiện thêm
            }
            else if (_currentMode == Mode.Edit) // Nếu đang ở chế độ Sửa
            {
                _nhanVien.TenNV = txtTenNV.Text; // Cập nhật tên
                _nhanVien.LuongCB = double.Parse(txtLuongCB.Text); // Cập nhật lương
                OnSuaNhanVien?.Invoke(_nhanVien); // Gọi sự kiện sửa
            }

            this.Close(); // Đóng Form2
        }
        public Form2(NhanVien nhanVien) : this() // Gọi constructor mặc định
        {
            _nhanVien = nhanVien; // Lưu đối tượng NhanVien để sửa
            InitializeNhanVien(nhanVien); // Khởi tạo các trường
            _currentMode = Mode.Edit; // Thiết lập chế độ là Sửa
        }
        private void InitializeNhanVien(NhanVien nhanVien)
        {
            txtMSNV.Text = nhanVien.MSNV.ToString(); // Điền ID
            txtTenNV.Text = nhanVien.TenNV; // Điền tên
            txtLuongCB.Text = nhanVien.LuongCB.ToString(); // Điền lương
            txtMSNV.ReadOnly = true; // Làm cho ID không thể sửa
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
