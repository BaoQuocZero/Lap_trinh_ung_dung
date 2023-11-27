using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_ShowCamera
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableHoaDon = new DataTable();
        DataTable tableChiTietHoaDon = new DataTable();
        DataTable tableNhanVien = new DataTable();
        DataTable tableKhachHang = new DataTable();
        DataTable tableSanPham = new DataTable();
        DataTable tableTheLoai = new DataTable();
        DataTable tableThongKe = new DataTable();
        void HoaDon()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM HoaDon";
            adapter.SelectCommand = command;
            tableHoaDon.Clear();
            adapter.Fill(tableHoaDon);
            dgvMain.DataSource = tableHoaDon;
        }

        void ChiTietHoaDon()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ChiTietHoaDon";
            adapter.SelectCommand = command;
            tableHoaDon.Clear();
            adapter.Fill(tableChiTietHoaDon);
            dgvMain.DataSource = tableChiTietHoaDon;
        }

        void sanpham()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM SanPham";
            adapter.SelectCommand = command;
            tableSanPham.Clear();
            adapter.Fill(tableSanPham);
            dgvMain.DataSource = tableSanPham;
        }

        void nhanvien()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM NhanVien";
            adapter.SelectCommand = command;
            tableNhanVien.Clear();
            adapter.Fill(tableNhanVien);
            dgvMain.DataSource = tableNhanVien;
        }

        void khachhang()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM KhachHang";
            adapter.SelectCommand = command;
            tableKhachHang.Clear();
            adapter.Fill(tableKhachHang);
            dgvMain.DataSource = tableKhachHang;
        }

        void theloai()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TheLoai";
            adapter.SelectCommand = command;
            tableTheLoai.Clear();
            adapter.Fill(tableTheLoai);
            dgvMain.DataSource = tableTheLoai;
        }

        void thongke()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT \r\n    KH.TenLienHe AS [Tên khách hàng], \r\n    COUNT(CTHD.MaSP) AS [Số sản phẩm đã mua],\r\n    SUM(SP.DonGiaSP * (1 - SP.GiamGia) * CTHD.SoLuong) AS [Số tiền đã chi]\r\nFROM KhachHang AS KH\r\nJOIN HoaDon AS HD ON KH.MaKH = HD.MaKH\r\nJOIN ChiTietHoaDon AS CTHD ON HD.MaHD = CTHD.MaHD\r\nJOIN SanPham AS SP ON CTHD.MaSP = SP.MaSP\r\nGROUP BY KH.TenLienHe;";
            adapter.SelectCommand = command;
            tableThongKe.Clear();
            adapter.Fill(tableThongKe);
            dgvMain.DataSource = tableThongKe;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lblMaKH_Click(object sender, EventArgs e)
        {

        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon();
            lblTieuDe.Text = "Hóa Đơn";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Hóa Đơn";
            connection = new SqlConnection(str);
            connection.Open();
            HoaDon();

            // Thêm sự kiện Click cho TextBox txtTenKH
            txtTenKH.Click += TxtTenKH_Click;
            txtTenSP.Click += TxtTenKH_Click;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sanpham();
            lblTieuDe.Text = "Sản phẩm";
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            sanpham();
            lblTieuDe.Text = "Sản phẩm";
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            nhanvien();
            lblTieuDe.Text = "Nhân viên";
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMain.CurrentRow.Index;
            if (lblTieuDe.Text == "Khách hàng")
            {
                txtTenKH.Text = dgvMain.Rows[i].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
                txtSdtKH.Text = dgvMain.Rows[i].Cells[4].Value.ToString();
            }
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            khachhang();
            lblTieuDe.Text = "Khách hàng";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nhanvien();
            lblTieuDe.Text = "Nhân viên";
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {

        }

        private void mnuShpper_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void mnuTheLoai_Click(object sender, EventArgs e)
        {
            theloai();
            lblTieuDe.Text = "Thể loại";
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            sanpham();
            lblTieuDe.Text = "Sản phẩm";
        }

        private void TxtTenKH_Click(object sender, EventArgs e)
        {
            // Hiển thị bảng KhachHang khi người dùng nhấn vào txtTenKH
            khachhang();
            lblTieuDe.Text = "Khách hàng";
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon();
            lblTieuDe.Text = "Chi tiết hóa đơn";
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongke();
            lblTieuDe.Text = "Thống kê khách hàng";
        }
    }
}
