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
        string str = "Data Source=DESKTOP-SDFOMUO;Initial Catalog=ShopCamera;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableHoaDon = new DataTable();
        DataTable tableChiTietHoaDon = new DataTable();
        DataTable tableNhanVien = new DataTable();
        DataTable tableKhachHang = new DataTable();
        DataTable tableSanPham = new DataTable();
        DataTable tableTheLoai = new DataTable();
        DataTable tableThongKe = new DataTable();
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
            command.CommandText = "SELECT \r\n    KH.TenLienHe AS [Tên khách hàng], \r\n    COUNT(CTHD.MaSP) AS [Số sản phẩm đã mua],\r\n    SUM(SP.DonGiaSP * (1 - SP.GiamGia) * CTHD.SoLuong) AS [Số tiền đã chi]\r\nFROM KhachHang AS KH\r\nJOIN HoaDon AS HD ON KH.MaKH = HD.MaKH\r\nJOIN ChiTietHoaDon AS CTHD ON HD.MaHD = CTHD.MaHD\r\nJOIN SanPham AS SP ON CTHD.MaSP = SP.MaSP\r\nGROUP BY KH.TenLienHe;";
            adapter.SelectCommand = command;
            tableThongKe.Clear();
            adapter.Fill(tableThongKe);
            dgvMain.DataSource = tableThongKe;
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
            int i;
            i = dgvMain.CurrentRow.Index;
            if (lblTieuDe.Text == "Khách hàng")
            {
                txtTenKH.Text = dgvMain.Rows[i].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
                txtSdtKH.Text = dgvMain.Rows[i].Cells[4].Value.ToString();
            }

            if (lblTieuDe.Text == "Sản phẩm")
            {
                txtMaSP.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
                txtTenSP.Text = dgvMain.Rows[i].Cells[1].Value.ToString();
            }

            if (lblTieuDe.Text == "Nhân viên")
            {
                txtMaNV.Text = dgvMain.Rows[i].Cells[0].Value.ToString();
                txtTenNV.Text = dgvMain.Rows[i].Cells[3].Value.ToString();
            }
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            khachhang();
            lblTieuDe.Text = "Khách hàng";
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
            thongke();
            lblTieuDe.Text = "Thống kê khách hàng";
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
        // Hàm thêm mới khách hàng
        private void ThemMoiKhachHang(string tenKhachHang, string diaChi, string sdt)
        {
            // Thực hiện câu lệnh SQL để thêm mới khách hàng
            // Lưu ý: Đây chỉ là ví dụ, bạn cần điều chỉnh để phản ánh đúng cấu trúc của CSDL của bạn
            // Ví dụ: INSERT INTO KhachHang (TenLienHe, DiaChi, Sdt) VALUES ('Tên khách hàng mới', 'Địa chỉ mới', 'Số điện thoại mới');
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO KhachHang (TenLienHe, DiaChi, Sdt) VALUES (@TenLienHe, @DiaChi, @Sdt)";
            command.Parameters.AddWithValue("@TenLienHe", tenKhachHang);
            command.Parameters.AddWithValue("@DiaChi", diaChi);
            command.Parameters.AddWithValue("@Sdt", sdt);
            command.ExecuteNonQuery();
        }

        // Hàm làm sạch TextBox của khách hàng
        private void LamSachTextBoxKhachHang()
        {
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSdtKH.Text = "";
        }

        // Hàm lấy thông tin từ TextBox
        private void LayThongTinTextBoxKhachHang(out string tenKhachHang, out string diaChi, out string sdt)
        {
            tenKhachHang = txtTenKH.Text;
            diaChi = txtDiaChi.Text;
            sdt = txtSdtKH.Text;
        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            string tenKhachHang, diaChi, sdt;

            // Lấy thông tin từ TextBox
            LayThongTinTextBoxKhachHang(out tenKhachHang, out diaChi, out sdt);

            // Kiểm tra xem tên khách hàng đã tồn tại hay chưa
            DataTable resultTable = TimKiemKhachHangTheoTen(tenKhachHang);

            if (resultTable.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Có vẻ chúng ta có nhiều người bị trùng tên ở đây, bạn có nằm trong số đó không?", "Thông báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Mở FrmTrungTenKH và truyền dữ liệu từ Form1
                    FrmTrungTenKH frmTrungTenKH = new FrmTrungTenKH(resultTable);
                    frmTrungTenKH.LayDuLieuForm1(txtTenSP.Text, txtTenNV.Text, txtSoLuong.Text, txtMaSP.Text, txtMaNV.Text);
                    frmTrungTenKH.ShowDialog();
                }
                // Nếu chọn NO thì không cần làm gì cả
            }
            else
            {
                ThemMoiKhachHang(tenKhachHang, diaChi, sdt);
                khachhang();
                lblTieuDe.Text = "Khách hàng";
                LamSachTextBoxKhachHang();
            }
        }

        // Hàm tìm kiếm khách hàng theo tên
        private DataTable TimKiemKhachHangTheoTen(string tenKhachHang)
        {
            // Sử dụng tham số để tránh tình trạng SQL injection
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM KhachHang WHERE TenLienHe LIKE @TenLienHe";
            command.Parameters.AddWithValue("@TenLienHe", "%" + tenKhachHang + "%");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable resultTable = new DataTable();
            adapter.Fill(resultTable);

            return resultTable;
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
