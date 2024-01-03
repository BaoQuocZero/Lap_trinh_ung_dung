namespace Quản_lý_ShowCamera
{
    partial class FrmSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSanPham));
            this.pnMain = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaTL = new System.Windows.Forms.ComboBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTonKho = new System.Windows.Forms.TextBox();
            this.lblSdtKH = new System.Windows.Forms.Label();
            this.txtNhanSanXuat = new System.Windows.Forms.TextBox();
            this.pnButton = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.pnMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.lblTieuDe);
            this.pnMain.Controls.Add(this.flowLayoutPanel1);
            this.pnMain.Controls.Add(this.pnButton);
            this.pnMain.Controls.Add(this.dgvMain);
            this.pnMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnMain.Location = new System.Drawing.Point(12, 12);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1339, 638);
            this.pnMain.TabIndex = 8;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(3, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(398, 23);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Sản Phẩm";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblTenSP);
            this.flowLayoutPanel1.Controls.Add(this.txtTenSP);
            this.flowLayoutPanel1.Controls.Add(this.txtMaSP);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cboMaTL);
            this.flowLayoutPanel1.Controls.Add(this.lblDiaChi);
            this.flowLayoutPanel1.Controls.Add(this.txtDonGia);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtGiamGia);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtTonKho);
            this.flowLayoutPanel1.Controls.Add(this.lblSdtKH);
            this.flowLayoutPanel1.Controls.Add(this.txtNhanSanXuat);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1339, 69);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lblTenSP
            // 
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(3, 0);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(126, 23);
            this.lblTenSP.TabIndex = 0;
            this.lblTenSP.Text = "Tên sản phẩm";
            this.lblTenSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(135, 3);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(234, 20);
            this.txtTenSP.TabIndex = 1;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(375, 3);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(26, 20);
            this.txtMaSP.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(407, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Mã TL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMaTL
            // 
            this.cboMaTL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaTL.FormattingEnabled = true;
            this.cboMaTL.Location = new System.Drawing.Point(484, 3);
            this.cboMaTL.Name = "cboMaTL";
            this.cboMaTL.Size = new System.Drawing.Size(127, 21);
            this.cboMaTL.TabIndex = 38;
            this.cboMaTL.SelectedIndexChanged += new System.EventHandler(this.cboMaTL_SelectedIndexChanged);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(617, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(71, 23);
            this.lblDiaChi.TabIndex = 6;
            this.lblDiaChi.Text = "Đơn giá";
            this.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(694, 3);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(127, 20);
            this.txtDonGia.TabIndex = 7;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(827, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "Giảm giá";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(904, 3);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(127, 20);
            this.txtGiamGia.TabIndex = 37;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1037, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "Tồn kho";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTonKho
            // 
            this.txtTonKho.Location = new System.Drawing.Point(1114, 3);
            this.txtTonKho.Name = "txtTonKho";
            this.txtTonKho.Size = new System.Drawing.Size(127, 20);
            this.txtTonKho.TabIndex = 34;
            this.txtTonKho.TextChanged += new System.EventHandler(this.txtTonKho_TextChanged);
            // 
            // lblSdtKH
            // 
            this.lblSdtKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSdtKH.Location = new System.Drawing.Point(3, 27);
            this.lblSdtKH.Name = "lblSdtKH";
            this.lblSdtKH.Size = new System.Drawing.Size(126, 23);
            this.lblSdtKH.TabIndex = 16;
            this.lblSdtKH.Text = "Nhà sản xuất";
            this.lblSdtKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNhanSanXuat
            // 
            this.txtNhanSanXuat.Location = new System.Drawing.Point(135, 30);
            this.txtNhanSanXuat.Name = "txtNhanSanXuat";
            this.txtNhanSanXuat.Size = new System.Drawing.Size(267, 20);
            this.txtNhanSanXuat.TabIndex = 17;
            // 
            // pnButton
            // 
            this.pnButton.Controls.Add(this.menuStrip1);
            this.pnButton.Location = new System.Drawing.Point(3, 101);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(761, 37);
            this.pnButton.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimKiem,
            this.mnuThem,
            this.mnuXoa,
            this.mnuSua,
            this.mnuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(332, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuTimKiem
            // 
            this.mnuTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimKiem.Image")));
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.Size = new System.Drawing.Size(85, 20);
            this.mnuTimKiem.Text = "Tìm Kiếm";
            this.mnuTimKiem.Click += new System.EventHandler(this.mnuTimKiem_Click);
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
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(3, 144);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(1339, 462);
            this.dgvMain.TabIndex = 4;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            // 
            // FrmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 711);
            this.Controls.Add(this.pnMain);
            this.Name = "FrmSanPham";
            this.Text = "FrmSanPham";
            this.Load += new System.EventHandler(this.FrmSanPham_Load);
            this.pnMain.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnButton.ResumeLayout(false);
            this.pnButton.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnMain;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblSdtKH;
        private System.Windows.Forms.TextBox txtNhanSanXuat;
        private System.Windows.Forms.FlowLayoutPanel pnButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuThem;
        private System.Windows.Forms.ToolStripMenuItem mnuXoa;
        private System.Windows.Forms.ToolStripMenuItem mnuSua;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTonKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.ComboBox cboMaTL;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
    }
}