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
        string str = "Data Source=DESKTOP-SDFOMUO\\SQLEXPRESS;Initial Catalog=ShopCamera;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableHoaDon = new DataTable();
        DataTable tableNhanVien = new DataTable();
        DataTable tableKhachHang = new DataTable();
        DataTable tableSanPham = new DataTable();
        DataTable tableNCC = new DataTable();
        DataTable tableShipper = new DataTable();
        DataTable tableTheLoai = new DataTable();
        void HoaDon()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT [MaHD]\r\n      ,[MaKH]\r\n      ,[MaNV]\r\n      ,[NgayDatHang]\r\n      ,[PhiShip]\r\n      ,[CongTyVanChuyen]\r\n      ,[DiaChiShip]\r\n      ,[TinhThanh]\r\n      ,[QuocGia]\r\n  FROM [ShopCamera].[dbo].[HoaDon]";
            adapter.SelectCommand = command;
            tableHoaDon.Clear();
            adapter.Fill(tableHoaDon);
            dgv.DataSource = tableHoaDon;
        }

        void sanpham()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT *\r\nFROM [ShopCamera].[dbo].[SanPham]";
            adapter.SelectCommand = command;
            tableSanPham.Clear();
            adapter.Fill(tableSanPham);
            dgv.DataSource = tableSanPham;
        }

        void nhanvien()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT [MaNV]\r\n      ,[HoLotNV]\r\n      ,[TenNV]\r\n      ,[ChucVu]\r\n      ,[GioiTinh]\r\n      ,[NgaySinh]\r\n      ,[NgayVaoLam]\r\n      ,[DiaChiNV]\r\n      ,[ThanhPho]\r\n      ,[QuocGia]\r\n      ,[SdtNV]\r\n  FROM [ShopCamera].[dbo].[NhanVien]\r\n";
            adapter.SelectCommand = command;
            tableNhanVien.Clear();
            adapter.Fill(tableNhanVien);
            dgv.DataSource = tableNhanVien;
        }

        void khachhang()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT [MaKH]\r\n      ,[TenCongTy]\r\n      ,[TenLienHe]\r\n      ,[ThongTinLienLac]\r\n      ,[DiaChi]\r\n      ,[ThanhPho]\r\n      ,[QuocGia]\r\n      ,[Sdt]\r\n  FROM [ShopCamera].[dbo].[KhachHang]\r\n";
            adapter.SelectCommand = command;
            tableKhachHang.Clear();
            adapter.Fill(tableKhachHang);
            dgv.DataSource = tableKhachHang;
        }

        void nhacungcap()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT [MaNCC]\r\n      ,[TenCongTyNCC]\r\n      ,[TenLienHeNCC]\r\n      ,[ThongTinLienLacNCC]\r\n      ,[DiaChiNCC]\r\n      ,[ThanhPho]\r\n      ,[QuocGia]\r\n      ,[Sdt]\r\n      ,[WebSite]\r\n  FROM [ShopCamera].[dbo].[NhaCungCap]\r\n";
            adapter.SelectCommand = command;
            tableNCC.Clear();
            adapter.Fill(tableNCC);
            dgv.DataSource = tableNCC;
        }

        void shipper()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT [MaShipper]\r\n      ,[TenCongTy]\r\n      ,[Sdt]\r\n  FROM [ShopCamera].[dbo].[Shippers]\r\n";
            adapter.SelectCommand = command;
            tableShipper.Clear();
            adapter.Fill(tableShipper);
            dgv.DataSource = tableShipper;
        }

        void theloai()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT [MaTL]\r\n      ,[TenTL]\r\n      ,[MoTaTL]\r\n  FROM [ShopCamera].[dbo].[TheLoai]\r\n";
            adapter.SelectCommand = command;
            tableTheLoai.Clear();
            adapter.Fill(tableTheLoai);
            dgv.DataSource = tableTheLoai;
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
            lblTieuDe.Text = "Hóa đơn";
            connection = new SqlConnection(str);
            connection.Open();
            HoaDon();
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

        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            khachhang();
            lblTieuDe.Text = "Khách hàng";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nhanvien();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            khachhang();
            lblTieuDe.Text = "Khách hàng";
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            nhacungcap();
            lblTieuDe.Text = "Nhà cung cấp";
        }

        private void mnuShpper_Click(object sender, EventArgs e)
        {
            shipper();
            lblTieuDe.Text = "Shipper";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            shipper();
            lblTieuDe.Text = "Shipper";
        }

        private void mnuTheLoai_Click(object sender, EventArgs e)
        {
            theloai();
            lblTieuDe.Text = "Thể loại";
        }
    }
}
