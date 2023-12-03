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
    public partial class FrmSanPham : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableSanPham = new DataTable();

        void sanpham()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM SanPham";
            adapter.SelectCommand = command;
            tableSanPham.Clear();
            adapter.Fill(tableSanPham);
            dgvMain.DataSource = tableSanPham;
        }
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            // Load dữ liệu cho ComboBox cboMaTL từ bảng TheLoai
            LoadMaTLComboBox();

            sanpham();
        }

        private void LoadMaTLComboBox()
        {
            try
            {
                // Tạo câu truy vấn SQL để lấy dữ liệu từ bảng TheLoai
                string query = "SELECT MaTL FROM TheLoai";

                // Tạo và cấu hình SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Sử dụng SqlDataReader để đọc dữ liệu từ bảng TheLoai
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Xóa các item cũ của ComboBox
                        cboMaTL.Items.Clear();

                        // Thêm các giá trị của cột MaTL vào ComboBox
                        while (reader.Read())
                        {
                            cboMaTL.Items.Add(reader["MaTL"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu cho ComboBox MaTL: " + ex.Message);
            }
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMain.CurrentRow.Index;
            txtMaSP.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text = dgvMain.Rows[i].Cells[1].Value.ToString();
            cboMaTL.Text = dgvMain.Rows[i].Cells[2].Value.ToString();
            txtDonGia.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
            txtGiamGia.Text = dgvMain.Rows[i].Cells[4].Value.ToString();
            txtTonKho.Text = dgvMain.Rows[i].Cells[5].Value.ToString();
            txtNhanSanXuat.Text = dgvMain.Rows[i].Cells[6].Value.ToString();
        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra MaSP có được nhập hay không
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                // Nếu không có MaSP, thực hiện thêm mới sản phẩm
                InsertSanPham();
            }
            else
            {
                // Nếu có MaSP, kiểm tra xem đã tồn tại hay chưa
                if (string.IsNullOrEmpty(txtTenSP.Text) ||
                    string.IsNullOrEmpty(cboMaTL.Text) || string.IsNullOrEmpty(txtDonGia.Text) ||
                    string.IsNullOrEmpty(txtGiamGia.Text) || string.IsNullOrEmpty(txtTonKho.Text) ||
                    string.IsNullOrEmpty(txtNhanSanXuat.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.");
                    return;
                }

                try
                {
                    // Kiểm tra xem MaSP đã tồn tại hay không
                    bool maSPExists = CheckMaSPExists(txtMaSP.Text);

                    if (maSPExists)
                    {
                        // Nếu tồn tại, hiển thị hộp thoại xác nhận cập nhật
                        DialogResult dialogResult = MessageBox.Show("Mã sản phẩm đã tồn tại. Bạn muốn cập nhật mã này không?",
                            "Xác nhận cập nhật", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // Thực hiện chức năng giống mnuSua_Click
                            UpdateSanPham();
                        }
                        // Nếu chọn NO, thoát khỏi phương thức
                        return;
                    }

                    // Nếu MaSP không tồn tại, thực hiện thêm mới
                    InsertSanPham();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm/sửa sản phẩm: " + ex.Message);
                }
            }
        }

        // Kiểm tra xem MaSP đã tồn tại hay không
        private bool CheckMaSPExists(string maSP)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaSP", int.Parse(maSP));

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        // Thực hiện thêm mới sản phẩm
        private void InsertSanPham()
        {
            try
            {
                // Tạo câu truy vấn SQL để thêm mới sản phẩm
                string query = "INSERT INTO SanPham (TenSP, MaTL, DonGiaSP, GiamGia, TonKhoSP, NhanSanXuat) " +
                               "VALUES (@TenSP, @MaTL, @DonGiaSP, @GiamGia, @TonKhoSP, @NhanSanXuat)";

                // Tạo và mở kết nối
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@MaTL", cboMaTL.Text);
                        cmd.Parameters.AddWithValue("@DonGiaSP", decimal.Parse(txtDonGia.Text));
                        cmd.Parameters.AddWithValue("@GiamGia", float.Parse(txtGiamGia.Text));
                        cmd.Parameters.AddWithValue("@TonKhoSP", short.Parse(txtTonKho.Text));
                        cmd.Parameters.AddWithValue("@NhanSanXuat", txtNhanSanXuat.Text);

                        // Thực hiện truy vấn
                        cmd.ExecuteNonQuery();

                        // Cập nhật lại DataGridView
                        sanpham();

                        // Thông báo thành công
                        MessageBox.Show("Thêm sản phẩm thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        // Thực hiện cập nhật thông tin sản phẩm
        private void UpdateSanPham()
        {
            try
            {
                // Tạo câu truy vấn SQL để cập nhật thông tin sản phẩm
                string query = "UPDATE SanPham " +
                               "SET TenSP = @TenSP, MaTL = @MaTL, DonGiaSP = @DonGiaSP, " +
                               "GiamGia = @GiamGia, TonKhoSP = @TonKhoSP, NhanSanXuat = @NhanSanXuat " +
                               "WHERE MaSP = @MaSP";

                // Tạo và mở kết nối
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@MaTL", cboMaTL.Text);
                        cmd.Parameters.AddWithValue("@DonGiaSP", decimal.Parse(txtDonGia.Text));
                        cmd.Parameters.AddWithValue("@GiamGia", float.Parse(txtGiamGia.Text));
                        cmd.Parameters.AddWithValue("@TonKhoSP", short.Parse(txtTonKho.Text));
                        cmd.Parameters.AddWithValue("@NhanSanXuat", txtNhanSanXuat.Text);
                        cmd.Parameters.AddWithValue("@MaSP", int.Parse(txtMaSP.Text));

                        // Thực hiện truy vấn
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Kiểm tra xem có dòng nào được cập nhật không
                        if (rowsAffected > 0)
                        {
                            // Cập nhật lại DataGridView
                            sanpham();

                            // Thông báo thành công
                            MessageBox.Show("Cập nhật thông tin sản phẩm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm với MãSP = " + txtMaSP.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin sản phẩm: " + ex.Message);
            }
        }


        private void mnuXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra MaSP có được nhập hay không
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sản phẩm cần xóa.");
                return;
            }

            try
            {
                // Kiểm tra xem có sản phẩm đang tồn tại trong bảng HoaDon không
                string checkInHoaDonQuery = "SELECT COUNT(*) FROM HoaDon WHERE EXISTS (SELECT 1 FROM SanPham WHERE SanPham.MaSP = @MaSP)";
                int countInHoaDon;

                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    using (SqlCommand checkCmd = new SqlCommand(checkInHoaDonQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@MaSP", int.Parse(txtMaSP.Text));
                        countInHoaDon = (int)checkCmd.ExecuteScalar();
                    }
                }

                if (countInHoaDon > 0)
                {
                    MessageBox.Show("Không thể xóa sản phẩm vì nó đã được sử dụng trong các hóa đơn.");
                    return;
                }

                // Nếu không có trong bảng HoaDon, tiến hành xóa từ bảng SanPham
                string deleteQuery = "DELETE FROM SanPham WHERE MaSP = @MaSP";

                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@MaSP", int.Parse(txtMaSP.Text));

                        // Thực hiện truy vấn
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        // Kiểm tra xem có dòng nào bị xóa không
                        if (rowsAffected > 0)
                        {
                            // Cập nhật lại DataGridView
                            sanpham();

                            // Thông báo thành công
                            MessageBox.Show("Xóa sản phẩm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm với MãSP = " + txtMaSP.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }


        private void mnuSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra MaSP có được nhập hay không
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sản phẩm cần sửa.");
                return;
            }

            try
            {
                // Tạo câu truy vấn SQL để cập nhật thông tin sản phẩm
                string query = "UPDATE SanPham " +
                               "SET TenSP = @TenSP, MaTL = @MaTL, DonGiaSP = @DonGiaSP, " +
                               "GiamGia = @GiamGia, TonKhoSP = @TonKhoSP, NhanSanXuat = @NhanSanXuat " +
                               "WHERE MaSP = @MaSP";

                // Tạo và mở kết nối
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@MaTL", cboMaTL.Text);
                        cmd.Parameters.AddWithValue("@DonGiaSP", decimal.Parse(txtDonGia.Text));
                        cmd.Parameters.AddWithValue("@GiamGia", float.Parse(txtGiamGia.Text));
                        cmd.Parameters.AddWithValue("@TonKhoSP", short.Parse(txtTonKho.Text));
                        cmd.Parameters.AddWithValue("@NhanSanXuat", txtNhanSanXuat.Text);
                        cmd.Parameters.AddWithValue("@MaSP", int.Parse(txtMaSP.Text));

                        // Thực hiện truy vấn
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Kiểm tra xem có dòng nào được cập nhật không
                        if (rowsAffected > 0)
                        {
                            // Cập nhật lại DataGridView
                            sanpham();

                            // Thông báo thành công
                            MessageBox.Show("Sửa thông tin sản phẩm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm với MãSP = " + txtMaSP.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa thông tin sản phẩm: " + ex.Message);
            }
        }


        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMaTL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
