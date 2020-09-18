namespace PhanMem_QuanlySpa
{
    partial class ThemAccount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tendangnhap = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_taotaikhoan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuytaotaikhoan = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_nhaplaimatkhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rd_quanli = new System.Windows.Forms.RadioButton();
            this.rd_nhanvien = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_tendangnhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 43);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // txt_tendangnhap
            // 
            this.txt_tendangnhap.Location = new System.Drawing.Point(110, 11);
            this.txt_tendangnhap.Name = "txt_tendangnhap";
            this.txt_tendangnhap.Size = new System.Drawing.Size(302, 20);
            this.txt_tendangnhap.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_matkhau);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 43);
            this.panel2.TabIndex = 1;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Location = new System.Drawing.Point(110, 11);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(302, 20);
            this.txt_matkhau.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu:";
            // 
            // btn_taotaikhoan
            // 
            this.btn_taotaikhoan.Location = new System.Drawing.Point(112, 226);
            this.btn_taotaikhoan.Name = "btn_taotaikhoan";
            this.btn_taotaikhoan.Size = new System.Drawing.Size(75, 23);
            this.btn_taotaikhoan.TabIndex = 14;
            this.btn_taotaikhoan.Text = "Tạo tài khoản";
            this.btn_taotaikhoan.Click += new System.EventHandler(this.btn_taotaikhoan_Click);
            // 
            // btnHuytaotaikhoan
            // 
            this.btnHuytaotaikhoan.Location = new System.Drawing.Point(237, 226);
            this.btnHuytaotaikhoan.Name = "btnHuytaotaikhoan";
            this.btnHuytaotaikhoan.Size = new System.Drawing.Size(75, 23);
            this.btnHuytaotaikhoan.TabIndex = 15;
            this.btnHuytaotaikhoan.Text = "Hủy";
            this.btnHuytaotaikhoan.Click += new System.EventHandler(this.btnHuytaotaikhoan_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_nhaplaimatkhau);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(2, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(431, 43);
            this.panel3.TabIndex = 16;
            // 
            // txt_nhaplaimatkhau
            // 
            this.txt_nhaplaimatkhau.Location = new System.Drawing.Point(110, 11);
            this.txt_nhaplaimatkhau.Name = "txt_nhaplaimatkhau";
            this.txt_nhaplaimatkhau.Size = new System.Drawing.Size(302, 20);
            this.txt_nhaplaimatkhau.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhập lại mật khẩu:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rd_nhanvien);
            this.panel4.Controls.Add(this.rd_quanli);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(2, 159);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(431, 43);
            this.panel4.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Phân quyền:";
            // 
            // rd_quanli
            // 
            this.rd_quanli.AutoSize = true;
            this.rd_quanli.Location = new System.Drawing.Point(110, 14);
            this.rd_quanli.Name = "rd_quanli";
            this.rd_quanli.Size = new System.Drawing.Size(60, 17);
            this.rd_quanli.TabIndex = 18;
            this.rd_quanli.TabStop = true;
            this.rd_quanli.Text = "Quản lí";
            this.rd_quanli.UseVisualStyleBackColor = true;
            // 
            // rd_nhanvien
            // 
            this.rd_nhanvien.AutoSize = true;
            this.rd_nhanvien.Location = new System.Drawing.Point(210, 14);
            this.rd_nhanvien.Name = "rd_nhanvien";
            this.rd_nhanvien.Size = new System.Drawing.Size(74, 17);
            this.rd_nhanvien.TabIndex = 19;
            this.rd_nhanvien.TabStop = true;
            this.rd_nhanvien.Text = "Nhân viên";
            this.rd_nhanvien.UseVisualStyleBackColor = true;
            // 
            // ThemAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 338);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnHuytaotaikhoan);
            this.Controls.Add(this.btn_taotaikhoan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ThemAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemAccount";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_tendangnhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btn_taotaikhoan;
        private DevExpress.XtraEditors.SimpleButton btnHuytaotaikhoan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_nhaplaimatkhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rd_nhanvien;
        private System.Windows.Forms.RadioButton rd_quanli;
        private System.Windows.Forms.Label label4;
    }
}