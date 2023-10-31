namespace Quản_lý_Nhân_viên
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnChinh = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblNamSinh = new System.Windows.Forms.Label();
            this.txtNamSinh = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGoiTinh = new System.Windows.Forms.ComboBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.pnButton = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuTimMa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimTen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDemSL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cboDiaChi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnChinh.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(19, 182);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(761, 180);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(800, 48);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = " ";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Click += new System.EventHandler(this.lblTieuDe_Click);
            // 
            // pnChinh
            // 
            this.pnChinh.Controls.Add(this.lblMaNV);
            this.pnChinh.Controls.Add(this.txtMaNV);
            this.pnChinh.Controls.Add(this.lblNamSinh);
            this.pnChinh.Controls.Add(this.txtNamSinh);
            this.pnChinh.Controls.Add(this.lblDiaChi);
            this.pnChinh.Controls.Add(this.cboDiaChi);
            this.pnChinh.Controls.Add(this.lblHoTen);
            this.pnChinh.Controls.Add(this.txtHoTen);
            this.pnChinh.Controls.Add(this.lblGioiTinh);
            this.pnChinh.Controls.Add(this.cboGoiTinh);
            this.pnChinh.Controls.Add(this.lblDienThoai);
            this.pnChinh.Controls.Add(this.txtDienThoai);
            this.pnChinh.Controls.Add(this.comboBox1);
            this.pnChinh.Location = new System.Drawing.Point(19, 51);
            this.pnChinh.Name = "pnChinh";
            this.pnChinh.Size = new System.Drawing.Size(761, 116);
            this.pnChinh.TabIndex = 2;
            // 
            // lblMaNV
            // 
            this.lblMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(3, 0);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(100, 64);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã NV";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(109, 3);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(140, 20);
            this.txtMaNV.TabIndex = 6;
            // 
            // lblNamSinh
            // 
            this.lblNamSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamSinh.Location = new System.Drawing.Point(255, 0);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(100, 64);
            this.lblNamSinh.TabIndex = 7;
            this.lblNamSinh.Text = "Năm sinh";
            // 
            // txtNamSinh
            // 
            this.txtNamSinh.Location = new System.Drawing.Point(361, 3);
            this.txtNamSinh.Name = "txtNamSinh";
            this.txtNamSinh.Size = new System.Drawing.Size(140, 20);
            this.txtNamSinh.TabIndex = 8;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(507, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(100, 64);
            this.lblDiaChi.TabIndex = 9;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(3, 64);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(100, 64);
            this.lblHoTen.TabIndex = 11;
            this.lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(109, 67);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(140, 20);
            this.txtHoTen.TabIndex = 12;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(255, 64);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(100, 64);
            this.lblGioiTinh.TabIndex = 13;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // cboGoiTinh
            // 
            this.cboGoiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoiTinh.FormattingEnabled = true;
            this.cboGoiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGoiTinh.Location = new System.Drawing.Point(361, 67);
            this.cboGoiTinh.Name = "cboGoiTinh";
            this.cboGoiTinh.Size = new System.Drawing.Size(140, 21);
            this.cboGoiTinh.TabIndex = 17;
            this.cboGoiTinh.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDienThoai.Location = new System.Drawing.Point(507, 64);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(100, 64);
            this.lblDienThoai.TabIndex = 15;
            this.lblDienThoai.Text = "Điện thoại";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(613, 67);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(140, 20);
            this.txtDienThoai.TabIndex = 16;
            // 
            // pnButton
            // 
            this.pnButton.Controls.Add(this.menuStrip1);
            this.pnButton.Location = new System.Drawing.Point(19, 368);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(761, 62);
            this.pnButton.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimMa,
            this.mnuTimTen,
            this.mnuDemSL,
            this.mnuThem,
            this.mnuXoa,
            this.mnuSua,
            this.mnuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(473, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuTimMa
            // 
            this.mnuTimMa.AutoSize = false;
            this.mnuTimMa.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimMa.Image")));
            this.mnuTimMa.Name = "mnuTimMa";
            this.mnuTimMa.Size = new System.Drawing.Size(75, 20);
            this.mnuTimMa.Text = "Tìm Mã";
            this.mnuTimMa.Click += new System.EventHandler(this.mnuTimMa_Click);
            // 
            // mnuTimTen
            // 
            this.mnuTimTen.AutoSize = false;
            this.mnuTimTen.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimTen.Image")));
            this.mnuTimTen.Name = "mnuTimTen";
            this.mnuTimTen.Size = new System.Drawing.Size(76, 20);
            this.mnuTimTen.Text = "Tìm Tên";
            this.mnuTimTen.Click += new System.EventHandler(this.mnuTimTen_Click);
            // 
            // mnuDemSL
            // 
            this.mnuDemSL.AutoSize = false;
            this.mnuDemSL.Image = ((System.Drawing.Image)(resources.GetObject("mnuDemSL.Image")));
            this.mnuDemSL.Name = "mnuDemSL";
            this.mnuDemSL.Size = new System.Drawing.Size(75, 20);
            this.mnuDemSL.Text = "Đếm SL";
            this.mnuDemSL.Click += new System.EventHandler(this.mnuDemSL_Click);
            // 
            // mnuThem
            // 
            this.mnuThem.AutoSize = false;
            this.mnuThem.Image = ((System.Drawing.Image)(resources.GetObject("mnuThem.Image")));
            this.mnuThem.Name = "mnuThem";
            this.mnuThem.Size = new System.Drawing.Size(65, 20);
            this.mnuThem.Text = "Thêm";
            this.mnuThem.Click += new System.EventHandler(this.mnuThem_Click);
            // 
            // mnuXoa
            // 
            this.mnuXoa.AutoSize = false;
            this.mnuXoa.Image = ((System.Drawing.Image)(resources.GetObject("mnuXoa.Image")));
            this.mnuXoa.Name = "mnuXoa";
            this.mnuXoa.Size = new System.Drawing.Size(55, 20);
            this.mnuXoa.Text = "Xóa";
            this.mnuXoa.Click += new System.EventHandler(this.mnuXoa_Click);
            // 
            // mnuSua
            // 
            this.mnuSua.AutoSize = false;
            this.mnuSua.Image = ((System.Drawing.Image)(resources.GetObject("mnuSua.Image")));
            this.mnuSua.Name = "mnuSua";
            this.mnuSua.Size = new System.Drawing.Size(54, 20);
            this.mnuSua.Text = "Sửa";
            this.mnuSua.Click += new System.EventHandler(this.mnuSua_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.AutoSize = false;
            this.mnuThoat.Image = ((System.Drawing.Image)(resources.GetObject("mnuThoat.Image")));
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(65, 20);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.comboBox1.Location = new System.Drawing.Point(3, 131);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // cboDiaChi
            // 
            this.cboDiaChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiaChi.FormattingEnabled = true;
            this.cboDiaChi.Items.AddRange(new object[] {
            "An Giang",
            "Bà Rịa - Vũng Tàu",
            "Bắc Giang",
            "Bắc Kạn",
            "Bạc Liêu",
            "Bắc Ninh",
            "Bến Tre",
            "Bình Định",
            "Bình Dương",
            "Bình Phước",
            "Bình Thuận",
            "Cà Mau",
            "Cần Thơ",
            "Cao Bằng",
            "Đà Nẵng",
            "Đắk Lắk",
            "Đắk Nông",
            "Điện Biên",
            "Đồng Nai",
            "Đồng Tháp",
            "Gia Lai",
            "Hà Giang",
            "Hà Nam",
            "Hà Nội",
            "Hà Tĩnh",
            "Hải Dương",
            "Hải Phòng",
            "Hậu Giang",
            "Hòa Bình",
            "Hưng Yên",
            "Khánh Hòa",
            "Kiên Giang",
            "Kon Tum",
            "Lai Châu",
            "Lâm Đồng",
            "Lạng Sơn",
            "Lào Cai",
            "Long An",
            "Nam Định",
            "Nghệ An",
            "Ninh Bình",
            "Ninh Thuận",
            "Phú Thọ",
            "Phú Yên",
            "Quảng Bình",
            "Quảng Nam",
            "Quảng Ngãi",
            "Quảng Ninh",
            "Quảng Trị",
            "Sóc Trăng",
            "Sơn La",
            "Tây Ninh",
            "Thái Bình",
            "Thái Nguyên",
            "Thanh Hóa",
            "Thừa Thiên Huế",
            "Tiền Giang",
            "Thành phố Hồ Chí Minh",
            "Trà Vinh",
            "Tuyên Quang",
            "Vĩnh Long",
            "Vĩnh Phúc",
            "Yên Bái"});
            this.cboDiaChi.Location = new System.Drawing.Point(613, 3);
            this.cboDiaChi.Name = "cboDiaChi";
            this.cboDiaChi.Size = new System.Drawing.Size(140, 21);
            this.cboDiaChi.TabIndex = 19;
            this.cboDiaChi.SelectedIndexChanged += new System.EventHandler(this.cboDiaChi_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 440);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.pnChinh);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.dgv);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnChinh.ResumeLayout(false);
            this.pnChinh.PerformLayout();
            this.pnButton.ResumeLayout(false);
            this.pnButton.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.FlowLayoutPanel pnChinh;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.TextBox txtNamSinh;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.ComboBox cboGoiTinh;
        private System.Windows.Forms.FlowLayoutPanel pnButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTimMa;
        private System.Windows.Forms.ToolStripMenuItem mnuTimTen;
        private System.Windows.Forms.ToolStripMenuItem mnuDemSL;
        private System.Windows.Forms.ToolStripMenuItem mnuThem;
        private System.Windows.Forms.ToolStripMenuItem mnuSua;
        private System.Windows.Forms.ToolStripMenuItem mnuXoa;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ComboBox cboDiaChi;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

