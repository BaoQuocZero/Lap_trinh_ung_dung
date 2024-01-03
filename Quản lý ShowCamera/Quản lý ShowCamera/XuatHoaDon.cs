using Microsoft.Reporting.WinForms;
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
    public partial class FrmXuatHoaDon : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableXuatHoaDon = new DataTable();

        void HoaDon()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT KH.TenLienHe, KH.DiaChi, KH.Sdt, SP.TenSP, TL.TenTL, NV.TenNV, CTHD.SoLuong, SP.DonGiaSP, SP.TonKhoSP, HD.MaHD, SP.MaSP, KH.MaKH, NV.MaNV, TL.MaTL, SP.DonGiaSP\r\nFROM HoaDon as HD, SanPham as SP, ChiTietHoaDon as CTHD, KhachHang as KH, NhanVien as NV, TheLoai as TL\r\nWHERE HD.MaHD = CTHD.MaHD AND HD.MaKH = KH.MaKH AND HD.MaNV = NV.MaNV AND CTHD.MaSP = SP.MaSP AND SP.MaTL = TL.MaTL\r\nORDER BY HD.MaHD DESC";
            adapter.SelectCommand = command;
            tableXuatHoaDon.Clear();
            adapter.Fill(tableXuatHoaDon);
            dgvMain.DataSource = tableXuatHoaDon;
        }

        public FrmXuatHoaDon()
        {
            InitializeComponent();
        }

        private void XuatHoaDon_Load(object sender, EventArgs e)
        {
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSdtKH.Text = "";
            txtTenSP.Text = "";
            txtTenNV.Text = "";

            connection = new SqlConnection(str);
            connection.Open();
            HoaDon();
            this.rptMan.RefreshReport();
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dgvMain.CurrentRow.Index;

                txtMaKH.Text = dgvMain.Rows[i].Cells[11].Value.ToString();
                txtMaSP.Text = dgvMain.Rows[i].Cells[10].Value.ToString();
                txtMaNV.Text = dgvMain.Rows[i].Cells[12].Value.ToString();
                txtTonKho.Text = dgvMain.Rows[i].Cells[8].Value.ToString();

                txtTenKH.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
                txtDiaChi.Text = dgvMain.Rows[i].Cells[1].Value.ToString();
                txtSdtKH.Text = dgvMain.Rows[i].Cells[2].Value.ToString();
                txtTenSP.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
                txtTenNV.Text = dgvMain.Rows[i].Cells[5].Value.ToString();
                txtSoLuong.Text = dgvMain.Rows[i].Cells[6].Value.ToString();
                txtDonGia.Text = dgvMain.Rows[i].Cells[7].Value.ToString();
            }
            catch
            {

            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox đã nhập
                string tenKH = txtTenKH.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string sdtKH = txtSdtKH.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();
                string tenNV = txtTenNV.Text.Trim();

                // Tạo câu truy vấn SQL sử dụng điều kiện WHERE chỉ khi có giá trị nhập
                string query = $"SELECT KH.TenLienHe, KH.DiaChi, KH.Sdt, SP.TenSP, TL.TenTL, NV.TenNV, CTHD.SoLuong, SP.DonGiaSP, SP.TonKhoSP, HD.MaHD, SP.MaSP, KH.MaKH, NV.MaNV, TL.MaTL " +
                               $"FROM HoaDon as HD, SanPham as SP, ChiTietHoaDon as CTHD, KhachHang as KH, NhanVien as NV, TheLoai as TL " +
                               $"WHERE HD.MaHD = CTHD.MaHD AND HD.MaKH = KH.MaKH AND HD.MaNV = NV.MaNV AND CTHD.MaSP = SP.MaSP AND SP.MaTL = TL.MaTL " +
                               $"{(!string.IsNullOrEmpty(tenKH) ? $"AND KH.TenLienHe LIKE '%{tenKH}%' " : "")}" +
                               $"{(!string.IsNullOrEmpty(diaChi) ? $"AND KH.DiaChi LIKE '%{diaChi}%' " : "")}" +
                               $"{(!string.IsNullOrEmpty(sdtKH) ? $"AND KH.Sdt LIKE '%{sdtKH}%' " : "")}" +
                               $"{(!string.IsNullOrEmpty(tenSP) ? $"AND SP.TenSP LIKE '%{tenSP}%' " : "")}" +
                               $"{(!string.IsNullOrEmpty(tenNV) ? $"AND NV.TenNV LIKE '%{tenNV}%' " : "")}" +
                               $"ORDER BY HD.MaHD DESC";

                // Thực hiện truy vấn và cập nhật dữ liệu trong DataGridView
                command.CommandText = query;
                adapter.SelectCommand = command;
                tableXuatHoaDon.Clear();
                adapter.Fill(tableXuatHoaDon);
                dgvMain.DataSource = tableXuatHoaDon;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, có thể hiển thị thông báo cho người dùng hoặc ghi log
                MessageBox.Show($"Lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<DuLieuXuatHD> duLieuXuatHDs = new List<DuLieuXuatHD>();

                DuLieuXuatHD dl = new DuLieuXuatHD();
                dl.tenKH = txtTenKH.Text;
                dl.diaChi = txtDiaChi.Text;
                dl.sdtKH = txtSdtKH.Text;
                dl.maNV = txtMaNV.Text;
                dl.tenNV = txtTenNV.Text;
                dl.tenSP = txtTenSP.Text;
                dl.giaSP = txtDonGia.Text;
                dl.soLuong = txtSoLuong.Text;

                duLieuXuatHDs.Add(dl);

                rptMan.LocalReport.ReportPath = "rptHoaDon.rdlc";
                var source = new ReportDataSource("DataSetHoaDon", duLieuXuatHDs);

                rptMan.LocalReport.DataSources.Clear();
                rptMan.LocalReport.DataSources.Add(source);

                this.rptMan.RefreshReport();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, có thể hiển thị thông báo cho người dùng hoặc ghi log
                MessageBox.Show($"Lỗi xảy ra khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

