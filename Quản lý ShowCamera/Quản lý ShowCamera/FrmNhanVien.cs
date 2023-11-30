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

        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {

        }

        private void mnuSua_Click(object sender, EventArgs e)
        {

        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
