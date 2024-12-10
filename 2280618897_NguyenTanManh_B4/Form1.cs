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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        List<NhanVien> NhanViens;
        private BindingSource bindingSource;
        private void Form1_Load(object sender, EventArgs e)
        {
            NhanViens = new List<NhanVien>();
            NhanViens.Add(new NhanVien() { MSNV = 1, TenNV = "A", LuongCB = 20 });
            NhanViens.Add(new NhanVien() { MSNV = 2, TenNV = "B", LuongCB = 30 });
            NhanViens.Add(new NhanVien() { MSNV = 3, TenNV = "C", LuongCB = 40 });
            bindingSource = new BindingSource { DataSource = NhanViens };
            dtgNhanVien.DataSource = bindingSource;
        }

        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.SelectedRows.Count > 0)
            {
                var selectedRow = dtgNhanVien.SelectedRows[0];
                var selectedNhanVien = (NhanVien)selectedRow.DataBoundItem;

                // Hiện hộp thoại xác nhận
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhân viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Nếu người dùng chọn "Có", thực hiện xóa
                if (result == DialogResult.Yes)
                {
                    NhanViens.Remove(selectedNhanVien); // Xóa nhân viên khỏi danh sách
                    UpdateDataGridView(); // Cập nhật giao diện
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một NhanVien để xóa."); // Thông báo nếu không có hàng nào được chọ
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.OnAddNhanVien += AddNhanVien;
            frm2.ShowDialog();
        }
        private void AddNhanVien(NhanVien nhanvien)
        {
            NhanViens.Add(nhanvien);
            dtgNhanVien.DataSource = null;
            dtgNhanVien.DataSource = NhanViens;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.SelectedRows.Count > 0)
            {
                var selectedRow = dtgNhanVien.SelectedRows[0];
                var selectedNhanVien = (NhanVien)selectedRow.DataBoundItem;

                Form2 frm2 = new Form2(selectedNhanVien); // Mở Form2 với NhanVien đã chọn
                frm2.OnSuaNhanVien += UpdateNhanVien; // Đăng ký sự kiện sửa
                frm2.ShowDialog(); // Hiện Form2
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }

        private void UpdateNhanVien(NhanVien nhanvien)
        {
            var original = NhanViens.FirstOrDefault(nv => nv.MSNV == nhanvien.MSNV);
            if (original != null)
            {
                original.TenNV = nhanvien.TenNV;
                original.LuongCB = nhanvien.LuongCB;
            }
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            dtgNhanVien.DataSource = null; // Đặt lại nguồn dữ liệu
            dtgNhanVien.DataSource = NhanViens; // Cập nhật nguồn dữ liệu mới
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
