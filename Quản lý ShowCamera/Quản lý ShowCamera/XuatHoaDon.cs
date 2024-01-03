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
            command.CommandText = "SELECT KH.TenLienHe, KH.DiaChi, KH.Sdt, SP.TenSP, TL.TenTL, NV.TenNV, CTHD.SoLuong, SP.DonGiaSP, SP.TonKhoSP, HD.MaHD, SP.MaSP, KH.MaKH, NV.MaNV, TL.MaTL\r\nFROM HoaDon as HD, SanPham as SP, ChiTietHoaDon as CTHD, KhachHang as KH, NhanVien as NV, TheLoai as TL\r\nWHERE HD.MaHD = CTHD.MaHD AND HD.MaKH = KH.MaKH AND HD.MaNV = NV.MaNV AND CTHD.MaSP = SP.MaSP AND SP.MaTL = TL.MaTL\r\nORDER BY HD.MaHD DESC";
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
            connection = new SqlConnection(str);
            connection.Open();
            HoaDon();
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
    }
}
