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
    public partial class FrmMain : Form
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

        DataTable tableKhachHangTim = new DataTable();
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
            tableChiTietHoaDon.Clear();
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
            command.CommandText = "SELECT\r\n    SP.MaSP,\r\n    SP.TenSP,\r\n    SP.NhanSanXuat,\r\n    SUM(CTHD.SoLuong) AS SoLuongBan\r\nFROM\r\n    SanPham SP\r\nJOIN\r\n    ChiTietHoaDon CTHD ON SP.MaSP = CTHD.MaSP\r\nGROUP BY\r\n    SP.MaSP, SP.TenSP, SP.NhanSanXuat\r\nORDER BY\r\n    SoLuongBan DESC;";
            adapter.SelectCommand = command;
            tableThongKe.Clear();
            adapter.Fill(tableThongKe);
            dgvMain.DataSource = tableThongKe;
        }

        public FrmMain()
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

            // Thêm sự kiện Click cho TextBox txtTenKH, Địa chỉ, Sdt
            txtTenKH.Click += TxtTenKH_Click;
            txtDiaChi.Click += TxtTenDiaChi_Click;
            txtSdtKH.Click += TxtSdtKH_Click;
            // Thêm sự kiện Click cho TextBox txtTenSP, Tên NV
            txtTenSP.Click += TxtTenSP_Click;
            txtTenNV.Click += TxtTenNV_Click;

        }

        private void TxtTenKH_Click(object sender, EventArgs e)
        {
            // Hiển thị bảng KhachHang khi người dùng nhấn vào txtTenKH
            khachhang();
            lblTieuDe.Text = "Khách hàng";
        }

        private void TxtTenDiaChi_Click(object sender, EventArgs e)
        {
            // Hiển thị bảng KhachHang khi người dùng nhấn vào txtTenKH
            khachhang();
            lblTieuDe.Text = "Khách hàng";
        }

        private void TxtSdtKH_Click(object sender, EventArgs e)
        {
            // Hiển thị bảng KhachHang khi người dùng nhấn vào txtTenKH
            khachhang();
            lblTieuDe.Text = "Khách hàng";
        }

        private void TxtTenSP_Click(object sender, EventArgs e)
        {
            // Gọi phương thức hiển thị dữ liệu của bảng "SanPham"
            sanpham();

            // Cập nhật tiêu đề để thông báo rằng đang hiển thị bảng "SanPham"
            lblTieuDe.Text = "Sản phẩm";
        }

        private void TxtTenNV_Click(object sender, EventArgs e)
        {
            // Gọi phương thức hiển thị dữ liệu của bảng "SanPham"
            nhanvien();

            // Cập nhật tiêu đề để thông báo rằng đang hiển thị bảng "SanPham"
            lblTieuDe.Text = "Nhân viên";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sanpham();
            lblTieuDe.Text = "Sản phẩm";
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            FrmSanPham frm = new FrmSanPham();
            frm.ShowDialog();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien frm = new FrmNhanVien();
            frm.ShowDialog();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMain.CurrentRow.Index;
            if (lblTieuDe.Text == "Khách hàng")
            {
                txtMaKH.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
                txtTenKH.Text = dgvMain.Rows[i].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvMain.Rows[i].Cells[2].Value.ToString();
                txtSdtKH.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
            }

            if (lblTieuDe.Text == "Sản phẩm")
            {
                txtMaSP.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
                txtTenSP.Text = dgvMain.Rows[i].Cells[1].Value.ToString();
                txtTonKho.Text = dgvMain.Rows[i].Cells[5].Value.ToString();
            }

            if (lblTieuDe.Text == "Nhân viên")
            {
                txtMaNV.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
                txtTenNV.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
            }
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();
            frm.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nhanvien();
            lblTieuDe.Text = "Nhân viên";
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            khachhang();
            lblTieuDe.Text = "Khách hàng";

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

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon();
            lblTieuDe.Text = "Chi tiết hóa đơn";
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSdtKH_TextChanged(object sender, EventArgs e)
        {
            khachhang();
            lblTieuDe.Text = "Khách hàng";

            // Xóa bỏ các ký tự không phải số
            string input = new string(txtSdtKH.Text.Where(char.IsDigit).ToArray());

            // Giữ lại chỉ 10 ký tự đầu tiên
            if (input.Length > 10)
            {
                input = input.Substring(0, 10);
            }

            // Cập nhật giá trị của TextBox
            txtSdtKH.Text = input;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            // Xóa bỏ các ký tự không phải số
            string input = new string(txtSoLuong.Text.Where(char.IsDigit).ToArray());

            // Cập nhật giá trị của TextBox
            txtSoLuong.Text = input;

            // Kiểm tra nếu txtSoLuong và txtTonKho không rỗng
            if (!string.IsNullOrEmpty(txtSoLuong.Text) && !string.IsNullOrEmpty(txtTonKho.Text))
            {
                // Chuyển giá trị từ TextBox về dạng số
                int soLuong = int.Parse(txtSoLuong.Text);
                int tonKho = int.Parse(txtTonKho.Text);

                // Kiểm tra nếu số lượng lớn hơn tồn kho, thiết lập giá trị về tồn kho
                if (soLuong > tonKho)
                {
                    MessageBox.Show("Số lượng không được lớn hơn tồn kho!");
                    txtSoLuong.Text = txtTonKho.Text;
                }
            }

        }


        private void mnuTimTen_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Sản phẩm";

            // Sử dụng tham số để tránh tình trạng SQL injection
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM SanPham WHERE TenSP LIKE @TenSP";
            command.Parameters.AddWithValue("@TenSP", "%" + txtTenSP.Text + "%");

            adapter.SelectCommand = command;
            tableSanPham.Clear();
            adapter.Fill(tableSanPham);
            dgvMain.DataSource = tableSanPham;
        }

        // Cụm thêm mới ==============================================================================================================================================================================

        // Hàm lấy thông tin từ TextBox
        private void LayThongTinTextBoxKhachHang(out string MaKH, out string tenKhachHang, out string diaChi, out string sdt, out string MaSP, out string MaNV, out string SL)
        {
            MaKH = txtMaKH.Text;
            tenKhachHang = txtTenKH.Text;
            diaChi = txtDiaChi.Text;
            sdt = txtSdtKH.Text;
            MaSP = txtMaSP.Text;
            MaNV = txtMaNV.Text;
            SL = txtSoLuong.Text;
        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            string MaKH, tenKhachHang, diaChi, sdt, MaSP, MaNV, SL;

            // Lấy thông tin từ TextBox
            LayThongTinTextBoxKhachHang(out MaKH, out tenKhachHang, out diaChi, out sdt, out MaSP, out MaNV, out SL);

            // Kiểm tra xem tất cả các trường cần thiết có giá trị không rỗng
            if (!string.IsNullOrEmpty(MaKH) && !string.IsNullOrEmpty(MaNV) && !string.IsNullOrEmpty(diaChi) && !string.IsNullOrEmpty(MaSP) && !string.IsNullOrEmpty(SL))
            {
                // Thực hiện thêm mới vào HoaDon và ChiTietHoaDon
                try
                {
                    // Thêm mới vào HoaDon
                    string queryHoaDon = "INSERT INTO HoaDon (MaKH, MaNV, DiaChiShip) VALUES (@MaKH, @MaNV, @DiaChiShip);" +
                                         "SELECT SCOPE_IDENTITY();";

                    int MaHD;

                    using (SqlConnection conn = new SqlConnection(str))
                    using (SqlCommand cmd = new SqlCommand(queryHoaDon, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", MaKH);
                        cmd.Parameters.AddWithValue("@MaNV", MaNV);
                        cmd.Parameters.AddWithValue("@DiaChiShip", diaChi);

                        conn.Open();
                        MaHD = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Thêm mới vào ChiTietHoaDon
                    using (SqlConnection conn = new SqlConnection(str))
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong) VALUES (@MaHD, @MaSP, @SoLuong)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", MaHD);
                        cmd.Parameters.AddWithValue("@MaSP", MaSP);
                        cmd.Parameters.AddWithValue("@SoLuong", SL);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật TonKho của SanPham
                    int soLuong = int.Parse(SL);

                    // Truy vấn TonKho hiện tại từ cơ sở dữ liệu
                    string queryTonKho = "SELECT TonKhoSP FROM SanPham WHERE MaSP = @MaSP";

                    using (SqlConnection conn = new SqlConnection(str))
                    using (SqlCommand cmd = new SqlCommand(queryTonKho, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", MaSP);

                        conn.Open();
                        int tonKhoHienTai = Convert.ToInt32(cmd.ExecuteScalar());

                        // Trừ đi số lượng đã bán
                        int tonKhoMoi = tonKhoHienTai - soLuong;

                        // Cập nhật giá trị mới vào cơ sở dữ liệu
                        string queryUpdateTonKho = "UPDATE SanPham SET TonKhoSP = @TonKhoMoi WHERE MaSP = @MaSP";

                        using (SqlCommand updateCmd = new SqlCommand(queryUpdateTonKho, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@TonKhoMoi", tonKhoMoi);
                            updateCmd.Parameters.AddWithValue("@MaSP", MaSP);

                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Thêm mới thành công!");
                    txtTenSP.Text = "";
                    txtTonKho.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm mới: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin cần thiết.");
            }
        }


        //=========================================================================================================================================================================================

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtTonKho_TextChanged(object sender, EventArgs e)
        {

        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thốngKêToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            thongke();
            lblTieuDe.Text = "Thống kê khách hàng";
        }
    }
}
