using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Quản_lý_Nhân_viên
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-SDFOMUO\SQLEXPRESS;Initial Catalog=QuanLyNhanVien_LT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * From NhanVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }

        static bool IsValidVietnameseName(string name)
        {
            // Kiểm tra xem chuỗi có chứa số hay không
            bool containsNumber = Regex.IsMatch(name, @"\d");

            // Kiểm tra xem chuỗi có chứa ký tự đặc biệt hay không
            // Chúng ta cho phép khoảng trắng và các ký tự Unicode bằng cách sử dụng biểu thức chính quy sau
            bool containsSpecialChar = Regex.IsMatch(name, @"[^\p{L}\s]");

            // Tên hợp lệ nếu không chứa số và ký tự đặc biệt
            return !containsNumber && !containsSpecialChar;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboGoiTinh.SelectedIndex = 0;
            cboDiaChi.SelectedIndex = 58;
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnTimMa_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.ReadOnly = true;
            int i;
            i = dgv.CurrentRow.Index;
            txtMaNV.Text = dgv.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dgv.Rows[i].Cells[1].Value.ToString();
            txtNamSinh.Text = dgv.Rows[i].Cells[2].Value.ToString();
            cboGoiTinh.Text = dgv.Rows[i].Cells[3].Value.ToString();
            cboDiaChi.Text = dgv.Rows[i].Cells[4].Value.ToString();
            txtDienThoai.Text = dgv.Rows[i].Cells[5].Value.ToString();

        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            try
            {
                int currentYear = DateTime.Now.Year;
                int birthYear = int.Parse(txtNamSinh.Text);
                if (txtMaNV.Text.StartsWith("NV") && Regex.Match(txtDienThoai.Text, @"^\d{10}$").Success == true && txtHoTen.Text != "" && (currentYear - birthYear) >= 18 && IsValidVietnameseName(txtHoTen.Text) == true)
                {
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into NhanVien values('" + txtMaNV.Text + "',N'" + txtHoTen.Text + "','" + txtNamSinh.Text + "',N'" + cboGoiTinh.Text + "',N'" + cboDiaChi.Text + "','" + txtDienThoai.Text + "')";
                    command.ExecuteNonQuery();
                    loaddata();
                }
                else
                {
                    MessageBox.Show("Lỗi điền thông tin", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi điền thông tin ngoài kiểm tra", "Thông báo");
            }
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "DELETE FROM NhanVien WHERE MaNV = '" + txtMaNV.Text + "';";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void mnuTimMa_Click(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = false;

            command = connection.CreateCommand();
            command.CommandText = "SELECT *\r\nFROM NhanVien\r\nWHERE [MaNV] LIKE '%" + txtMaNV.Text + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;

        }

        private void mnuTimTen_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT *\r\nFROM NhanVien\r\nWHERE [HoTen] LIKE N'%" + txtHoTen.Text + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }

        private void mnuSua_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "UPDATE NhanVien SET HoTen = N'" + txtHoTen.Text + "', NamSinh = '" + txtNamSinh.Text + "', GioiTinh = N'" + cboGoiTinh.Text + "', DiaChi = N'" + cboDiaChi.Text + "', DienThoai = '" + txtDienThoai.Text + "' WHERE MaNV = '" + txtMaNV.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
            }
            catch
            {
                MessageBox.Show("Lỗi điền thông tin", "Thông báo");
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuDemSL_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM NhanVien", connection))
                {
                    int count = (int)command.ExecuteScalar();
                    Console.WriteLine("Số dòng: " + count);
                    MessageBox.Show("Số dòng: " + count, "Đếm số lượng");
                }
            }

        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }

        private void cboDiaChi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
