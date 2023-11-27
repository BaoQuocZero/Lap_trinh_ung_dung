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
    public partial class FrmTrungTenKH : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();

        // Thêm một biến để lưu trữ dữ liệu từ đối số
        private DataTable _data;

        // Constructor với đối số
        public FrmTrungTenKH(DataTable data)
        {
            InitializeComponent();
            _data = data;
            DisplayData();
        }

        // Phương thức để nhận dữ liệu từ Form1
        public void LayDuLieuForm1(string tenSP, string tenNV, string soLuong, string MaSP, string MaNV)
        {
            txtTenSP.Text = tenSP;
            txtTenNV.Text = tenNV;
            txtSoLuong.Text = soLuong;
            txtMaNV.Text = MaNV;
            txtMaSP.Text = MaSP;
        }

        private void FrmTrungTenKH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            // Load dữ liệu khi form được mở
            DisplayData();
        }

        // Phương thức hiển thị dữ liệu
        private void DisplayData()
        {
            // Kiểm tra xem có dữ liệu để hiển thị không
            if (_data != null && _data.Rows.Count > 0)
            {
                // Đặt nguồn dữ liệu cho DataGridView
                dgvTrungTenKH.DataSource = _data;
            }
            else
            {
                // Nếu không có dữ liệu, có thể hiển thị thông báo hoặc thực hiện các thao tác khác
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }

        private void dgvTrungTenKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvTrungTenKH.CurrentRow.Index;
            txtMaKH.Text = dgvTrungTenKH.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvTrungTenKH.Rows[i].Cells[2].Value.ToString();
            txtDiaChiKH.Text = dgvTrungTenKH.Rows[i].Cells[3].Value.ToString();
            txtSdtKH.Text = dgvTrungTenKH.Rows[i].Cells[4].Value.ToString();
        }

        //====================Cụm xử lý nút btnXacNhan_Click ====================================================

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox
            string maKH = txtMaKH.Text;
            string maNV = txtMaNV.Text;
            string maSP = txtMaSP.Text;
            string diaChiShip = txtDiaChiKH.Text; // Lấy từ TextBox txtDiaChiKH
            string soLuong = txtSoLuong.Text;

            // Thêm dữ liệu vào bảng HoaDon
            int maHoaDon = ThemHoaDonVaoBang(maKH, maNV, diaChiShip);

            // Thêm dữ liệu vào bảng ChiTietHoaDon
            int soLuongInt;
            if (int.TryParse(soLuong, out soLuongInt))
            {
                ThemChiTietHoaDonVaoBang(maHoaDon, maSP, soLuongInt);
                MessageBox.Show("Thêm dữ liệu thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
            }
        }

        // Hàm thêm mới hóa đơn và trả về mã hóa đơn
        private int ThemHoaDonVaoBang(string maKH, string maNV, string diaChiShip)
        {
            // Thực hiện câu lệnh SQL để thêm mới hóa đơn và lấy mã hóa đơn
            string query = "INSERT INTO HoaDon (MaKH, MaNV, DiaChiShip) VALUES (@MaKH, @MaNV, @DiaChiShip);" +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = new SqlConnection(str))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@DiaChiShip", diaChiShip); // Sử dụng DiaChiShip thay vì DiaChi

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Hàm thêm chi tiết hóa đơn
        private void ThemChiTietHoaDonVaoBang(int maHoaDon, string maSP, int soLuong)
        {
            using (SqlConnection conn = new SqlConnection(str))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong) VALUES (@MaHD, @MaSP, @SoLuong)", conn))
            {
                cmd.Parameters.AddWithValue("@MaHD", maHoaDon);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        //=======================================================================================================

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
