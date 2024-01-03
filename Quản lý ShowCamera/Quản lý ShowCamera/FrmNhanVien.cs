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
    public partial class FrmNhanVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableNhanVien = new DataTable();

        void nhanvien()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM NhanVien";
            adapter.SelectCommand = command;
            tableNhanVien.Clear();
            adapter.Fill(tableNhanVien);
            dgvMain.DataSource = tableNhanVien;
        }

        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            nhanvien();
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMain.CurrentRow.Index;
            txtMaNV.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
            txtMatKhau.Text = dgvMain.Rows[i].Cells[1].Value.ToString();
            txtHo.Text = dgvMain.Rows[i].Cells[2].Value.ToString();
            txtTen.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvMain.Rows[i].Cells[4].Value.ToString();
            txtSdtNV.Text = dgvMain.Rows[i].Cells[5].Value.ToString();

        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có giá trị không rỗng
            if (txtMatKhau.Text != "" &&
                txtHo.Text != "" && txtTen.Text != "" &&
                txtDiaChi.Text != "" && txtSdtNV.Text != "" && txtSdtNV.Text.Length == 10)
            {
                // Lấy thông tin từ các TextBox
                string maNV = txtMaNV.Text;
                string matKhau = txtMatKhau.Text;
                string ho = txtHo.Text;
                string ten = txtTen.Text;
                string diaChi = txtDiaChi.Text;
                string sdt = txtSdtNV.Text;

                try
                {
                    command = connection.CreateCommand();

                    // Kiểm tra nếu txtMaNV không rỗng
                    if (maNV != "")
                    {
                        // Kiểm tra xem mã nhân viên đã tồn tại hay không
                        if (IsMaNVTonTai(maNV))
                        {
                            // Hiển thị thông báo và xác nhận cập nhật
                            DialogResult result = MessageBox.Show("Mã NV đã tồn tại. Bạn có muốn cập nhật mã nhân viên này không?", "Cập Nhật Mã NV", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                command = connection.CreateCommand();
                                command.CommandText = "UPDATE NhanVien SET PassNV = @MatKhau, HoLotNV = @Ho, TenNV = @Ten, DiaChiNV = @DiaChi, SdtNV = @Sdt WHERE MaNV = @MaNV";

                                // Thêm tham số để tránh SQL Injection
                                command.Parameters.AddWithValue("@MatKhau", matKhau);
                                command.Parameters.AddWithValue("@Ho", ho);
                                command.Parameters.AddWithValue("@Ten", ten);
                                command.Parameters.AddWithValue("@DiaChi", diaChi);
                                command.Parameters.AddWithValue("@Sdt", sdt);
                                command.Parameters.AddWithValue("@MaNV", maNV);

                                // Thực thi truy vấn
                                command.ExecuteNonQuery();

                                // Cập nhật DataGridView
                                nhanvien();

                                // Hiển thị thông báo thành công
                                MessageBox.Show("Đã cập nhật thông tin nhân viên thành công.");
                            }
                            else if (result == DialogResult.No)
                            {
                                // Thêm mới nhân viên nếu chọn NO
                                command.CommandText = "INSERT INTO NhanVien (MaNV, PassNV, HoLotNV, TenNV, DiaChiNV, SdtNV) VALUES (@MaNV, @MatKhau, @Ho, @Ten, @DiaChi, @Sdt)";
                                command.Parameters.AddWithValue("@MaNV", maNV);

                                // Thêm tham số để tránh SQL Injection
                                command.Parameters.AddWithValue("@MatKhau", matKhau);
                                command.Parameters.AddWithValue("@Ho", ho);
                                command.Parameters.AddWithValue("@Ten", ten);
                                command.Parameters.AddWithValue("@DiaChi", diaChi);
                                command.Parameters.AddWithValue("@Sdt", sdt);

                                // Thực thi truy vấn
                                command.ExecuteNonQuery();

                                // Cập nhật DataGridView
                                nhanvien();

                                // Hiển thị thông báo thành công
                                MessageBox.Show("Đã thêm mới thông tin nhân viên thành công.");
                            }
                        }
                        else
                        {
                            // Nếu mã nhân viên không tồn tại, thực hiện thêm mới
                            command.CommandText = "INSERT INTO NhanVien (MaNV, PassNV, HoLotNV, TenNV, DiaChiNV, SdtNV) VALUES (@MaNV, @MatKhau, @Ho, @Ten, @DiaChi, @Sdt)";
                            command.Parameters.AddWithValue("@MaNV", maNV);

                            // Thêm tham số để tránh SQL Injection
                            command.Parameters.AddWithValue("@MatKhau", matKhau);
                            command.Parameters.AddWithValue("@Ho", ho);
                            command.Parameters.AddWithValue("@Ten", ten);
                            command.Parameters.AddWithValue("@DiaChi", diaChi);
                            command.Parameters.AddWithValue("@Sdt", sdt);

                            // Thực thi truy vấn
                            command.ExecuteNonQuery();

                            // Cập nhật DataGridView
                            nhanvien();

                            // Hiển thị thông báo thành công
                            MessageBox.Show("Đã thêm mới thông tin nhân viên thành công.");
                        }
                    }
                    else
                    {
                        // Nếu txtMaNV rỗng, thêm mới nhân viên
                        command.CommandText = "INSERT INTO NhanVien (PassNV, HoLotNV, TenNV, DiaChiNV, SdtNV) VALUES (@MatKhau, @Ho, @Ten, @DiaChi, @Sdt)";

                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@MatKhau", matKhau);
                        command.Parameters.AddWithValue("@Ho", ho);
                        command.Parameters.AddWithValue("@Ten", ten);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);
                        command.Parameters.AddWithValue("@Sdt", sdt);

                        // Thực thi truy vấn
                        command.ExecuteNonQuery();

                        // Cập nhật DataGridView
                        nhanvien();

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Đã thêm mới thông tin nhân viên thành công.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
            }
        }

        // Hàm kiểm tra xem mã nhân viên đã tồn tại hay không
        private bool IsMaNVTonTai(string maNV)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            command.Parameters.AddWithValue("@MaNV", maNV);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }


        private void mnuXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem txtMaNV có giá trị không rỗng
            if (!string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                string maNV = txtMaNV.Text;

                try
                {
                    // Kiểm tra xem có tồn tại MaNV trong HoaDon hay không
                    if (IsMaNVExistInHoaDon(maNV))
                    {
                        MessageBox.Show("Không thể xóa nhân viên vì Mã NV này đang tồn tại trong các hóa đơn.");
                        return;
                    }

                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    command.Parameters.AddWithValue("@MaNV", maNV);

                    // Thực thi truy vấn
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Cập nhật DataGridView
                        nhanvien();

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Đã xóa nhân viên có Mã NV " + maNV + " thành công.");
                    }
                    else
                    {
                        // Hiển thị thông báo nếu không tìm thấy nhân viên để xóa
                        MessageBox.Show("Không tìm thấy nhân viên có Mã NV " + maNV + ".");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã NV để xóa.");
            }
        }

        // Hàm kiểm tra xem MaNV có tồn tại trong HoaDon hay không
        private bool IsMaNVExistInHoaDon(string maNV)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM HoaDon WHERE MaNV = @MaNV";
            command.Parameters.AddWithValue("@MaNV", maNV);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }



        private void mnuSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có giá trị không rỗng
            if (!string.IsNullOrWhiteSpace(txtMaNV.Text) && !string.IsNullOrWhiteSpace(txtMatKhau.Text) &&
                !string.IsNullOrWhiteSpace(txtHo.Text) && !string.IsNullOrWhiteSpace(txtTen.Text) &&
                !string.IsNullOrWhiteSpace(txtDiaChi.Text) && !string.IsNullOrWhiteSpace(txtSdtNV.Text) && txtSdtNV.Text.Length == 10)
            {
                // Lấy thông tin từ các TextBox
                string maNV = txtMaNV.Text;
                string matKhau = txtMatKhau.Text;
                string ho = txtHo.Text;
                string ten = txtTen.Text;
                string diaChi = txtDiaChi.Text;
                string sdt = txtSdtNV.Text;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = "UPDATE NhanVien SET PassNV = @MatKhau, HoLotNV = @Ho, TenNV = @Ten, DiaChiNV = @DiaChi, SdtNV = @Sdt WHERE MaNV = @MaNV";

                    // Thêm tham số để tránh SQL Injection
                    command.Parameters.AddWithValue("@MatKhau", matKhau);
                    command.Parameters.AddWithValue("@Ho", ho);
                    command.Parameters.AddWithValue("@Ten", ten);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@Sdt", sdt);
                    command.Parameters.AddWithValue("@MaNV", maNV);

                    // Thực thi truy vấn
                    command.ExecuteNonQuery();

                    // Cập nhật DataGridView
                    nhanvien();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Đã cập nhật thông tin nhân viên thành công.");
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
            }
        }


        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTen.Text != "")
                {
                    string tenNVCanTim = txtTen.Text.Trim();

                    // Tạo câu truy vấn SQL
                    string query = "SELECT * FROM NhanVien WHERE TenNV LIKE @TenNV";

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu truy vấn để tránh SQL injection
                        cmd.Parameters.AddWithValue("@TenNV", "%" + tenNVCanTim + "%");

                        // Tạo đối tượng SqlDataAdapter để lấy dữ liệu
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        // Tạo đối tượng DataTable để lưu dữ liệu
                        DataTable resultTable = new DataTable();

                        // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                        adapter.Fill(resultTable);

                        // Hiển thị kết quả trong DataGridView
                        dgvMain.DataSource = resultTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây, có thể là hiển thị thông báo lỗi, ghi log, v.v.
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHo_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtHo.Text;
            StringBuilder validText = new StringBuilder();

            // Kiểm tra từng ký tự trong văn bản
            foreach (char c in inputText)
            {
                // Kiểm tra xem ký tự là chữ cái tiếng Việt hoặc khoảng trắng
                if (char.IsLetter(c) && (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.LowercaseLetter ||
                    char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.UppercaseLetter) || char.IsWhiteSpace(c))
                {
                    validText.Append(c);
                }
            }

            // Gán văn bản hợp lệ vào ô văn bản
            txtHo.Text = validText.ToString();
        }


        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtTen.Text;
            StringBuilder validText = new StringBuilder();

            // Kiểm tra từng ký tự trong văn bản
            foreach (char c in inputText)
            {
                // Kiểm tra xem ký tự là chữ cái tiếng Việt hoặc khoảng trắng
                if (char.IsLetter(c) && (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.LowercaseLetter ||
                    char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.UppercaseLetter) || char.IsWhiteSpace(c))
                {
                    validText.Append(c);
                }
            }

            // Gán văn bản hợp lệ vào ô văn bản
            txtTen.Text = validText.ToString();
        }

        private void txtSdtNV_TextChanged(object sender, EventArgs e)
        {
            // Xóa bỏ các ký tự không phải số
            string input = new string(txtSdtNV.Text.Where(char.IsDigit).ToArray());

            // Giữ lại chỉ 10 ký tự đầu tiên
            if (input.Length > 10)
            {
                input = input.Substring(0, 10);
            }

            // Cập nhật giá trị của TextBox
            txtSdtNV.Text = input;
        }
    }
}
