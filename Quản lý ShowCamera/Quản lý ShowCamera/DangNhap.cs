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
    public partial class FrmDangNhap : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {;
            connection = new SqlConnection(str);
            connection.Open();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                string passNV = txtPass.Text;

                if (KiemTraDangNhap(maNV, passNV))
                {
                    // Đăng nhập thành công, mở Form chính
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    this.Hide(); // Ẩn Form đăng nhập
                }
                else
                {
                    // Đăng nhập thất bại, hiển thị thông báo
                    MessageBox.Show("Đăng nhập thất bại. Kiểm tra lại thông tin đăng nhập!");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: hiển thị thông báo hoặc ghi log, tùy thuộc vào yêu cầu của bạn
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private bool KiemTraDangNhap(string maNV, string passNV)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV AND PassNV = @PassNV";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@PassNV", passNV);

                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi thực hiện truy vấn
                MessageBox.Show("Đã xảy ra lỗi khi kiểm tra đăng nhập: " + ex.Message);
                return false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide(); // Ẩn Form đăng nhập
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự nhập vào nếu không phải là số
                MessageBox.Show("Mã Nhân Viên chỉ có số");
            }
        }

    }
}
