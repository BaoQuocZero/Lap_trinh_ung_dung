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
    public partial class FrmKhachHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableKhachHang = new DataTable();
        DataTable tableKhachHangTim = new DataTable();

        void khachhang()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM KhachHang";
            adapter.SelectCommand = command;
            tableKhachHang.Clear();
            adapter.Fill(tableKhachHang);
            dgvMain.DataSource = tableKhachHang;
        }

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            khachhang();
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMain.CurrentRow.Index;
            txtMaKH.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvMain.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvMain.Rows[i].Cells[2].Value.ToString();
            txtSdtKH.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
        }

        // Hàm lấy thông tin từ TextBox
        private void LayThongTinTextBoxKhachHang(out string MaKH, out string tenKhachHang, out string diaChi, out string sdt)
        {
            MaKH = txtMaKH.Text;
            tenKhachHang = txtTenKH.Text;
            diaChi = txtDiaChi.Text;
            sdt = txtSdtKH.Text;
        }

        //Thêm ========================================================================================================

        private void mnuThem_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSdtKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string MaKH, tenKhachHang, diaChi, sdt;

            // Lấy thông tin từ TextBox
            LayThongTinTextBoxKhachHang(out MaKH, out tenKhachHang, out diaChi, out sdt);

            // Kiểm tra xem trường MaKH có giá trị không rỗng
            if (txtMaKH.Text == "")
            {
                ThemMoiKhachHang(tenKhachHang, diaChi, sdt);
                MessageBox.Show("Ok");
                // Sau khi thêm mới hoặc cập nhật, cập nhật lại hiển thị bảng KhachHang
                khachhang();
                return;
            }
            else
            {
                // Kiểm tra xem MaKH đã tồn tại hay chưa
                if (KiemTraTonTaiMaKH(MaKH))
                {
                    // Mã KH đã tồn tại
                    DialogResult result = MessageBox.Show("Mã KH này đã tồn tại! Bạn muốn cập nhật thông tin khách hàng?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện cập nhật thông tin khách hàng
                        CapNhatThongTinKhachHang(MaKH, tenKhachHang, diaChi, sdt);
                        khachhang();
                        return;
                    }
                    else
                    {
                        ThemMoiKhachHang(tenKhachHang, diaChi, sdt);
                        khachhang();
                        return;
                    }
                }
                else
                {
                    // Mã KH chưa tồn tại, thực hiện thêm mới
                    ThemMoiKhachHang(tenKhachHang, diaChi, sdt);
                    khachhang();
                    return;
                }
            }
        }

        private bool KiemTraTonTaiMaKH(string maKH)
        {
            // Thực hiện kiểm tra xem MaKH đã tồn tại trong cơ sở dữ liệu hay chưa
            string queryKiemTra = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(str))
            using (SqlCommand cmd = new SqlCommand(queryKiemTra, conn))
            {
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        private void CapNhatThongTinKhachHang(string maKH, string tenKhachHang, string diaChi, string sdt)
        {
            try
            {
                // Thực hiện cập nhật thông tin trong bảng KhachHang
                string queryCapNhatKhachHang = "UPDATE KhachHang SET TenLienHe = @TenLienHe, DiaChi = @DiaChi, Sdt = @Sdt WHERE MaKH = @MaKH";

                using (SqlConnection conn = new SqlConnection(str))
                using (SqlCommand cmd = new SqlCommand(queryCapNhatKhachHang, conn))
                {
                    cmd.Parameters.AddWithValue("@TenLienHe", tenKhachHang);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@Sdt", sdt);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void ThemMoiKhachHang(string tenKhachHang, string diaChi, string sdt)
        {
            try
            {
                // Thực hiện thêm mới vào bảng KhachHang
                string queryThemKhachHang = "INSERT INTO KhachHang (TenLienHe, DiaChi, Sdt) VALUES (@TenLienHe, @DiaChi, @Sdt)";

                using (SqlConnection conn = new SqlConnection(str))
                using (SqlCommand cmd = new SqlCommand(queryThemKhachHang, conn))
                {
                    cmd.Parameters.AddWithValue("@TenLienHe", tenKhachHang);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@Sdt", sdt);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mới: " + ex.Message);
            }
        }

        // Xóa ======================================================================================================

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string MaKH = txtMaKH.Text;

            // Kiểm tra xem MaKH có giá trị không rỗng
            if (!string.IsNullOrWhiteSpace(MaKH))
            {
                // Kiểm tra xem MaKH có tồn tại trong HoaDon hay không
                if (KiemTraTonTaiMaKHTrongHoaDon(MaKH))
                {
                    MessageBox.Show("Không thể xóa khách hàng vì Mã KH này đang tồn tại trong các hóa đơn.");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa từ bảng KhachHang
                    XoaKhachHang(MaKH);

                    // Sau khi xóa, cập nhật lại hiển thị bảng KhachHang
                    khachhang();
                }
            }
        }

        // Hàm kiểm tra xem MaKH có tồn tại trong HoaDon hay không
        private bool KiemTraTonTaiMaKHTrongHoaDon(string maKH)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM HoaDon WHERE MaKH = @MaKH";
            command.Parameters.AddWithValue("@MaKH", maKH);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private void XoaKhachHang(string maKH)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM KhachHang WHERE MaKH = @MaKH", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không có khách hàng nào được xóa. Mã KH không tồn tại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }


        // Sửa =========================================================================================================

        private void mnuSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSdtKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string MaKH, tenKhachHang, diaChi, sdt;

            // Lấy thông tin từ TextBox
            LayThongTinTextBoxKhachHang(out MaKH, out tenKhachHang, out diaChi, out sdt);

            // Kiểm tra xem trường MaKH có giá trị không rỗng
            if (txtMaKH.Text == "")
            {
                // Mã KH không tồn tại
                DialogResult result = MessageBox.Show("Mã KH này không tồn tại! Bạn muốn thêm thông tin khách hàng?", "Xác nhận thêm khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện cập nhật thông tin khách hàng
                    ThemMoiKhachHang(tenKhachHang, diaChi, sdt);
                }
                // Sau khi thêm mới hoặc cập nhật, cập nhật lại hiển thị bảng KhachHang
                khachhang();
                return;
            }
            else
            {
                CapNhatThongTinKhachHang(MaKH, tenKhachHang, diaChi, sdt);
                khachhang();
                return;
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            khachhang();
        }


        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSdtKH_TextChanged(object sender, EventArgs e)
        {
            // Xóa bỏ các ký tự không phải số
            string input = new string(txtSdtKH.Text.Where(char.IsDigit).ToArray());

            // Giữ lại chỉ 10 ký tự đầu tiên
            if (input.Length > 10)
            {
                input = input.Substring(0, 10);
            }

            // Cập nhật giá trị của TextBox
            txtSdtKH.Text = input;
            khachhang();
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            khachhang();
        }
    }
}
