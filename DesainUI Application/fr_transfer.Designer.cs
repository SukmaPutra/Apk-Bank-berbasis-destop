namespace DesainUI_Application
{
    partial class fr_transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_transfer));
            this.lbl_id = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_idnasabah = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_totaltransfer = new System.Windows.Forms.TextBox();
            this.txt_biayaadmin = new System.Windows.Forms.TextBox();
            this.txt_nominaltransfer = new System.Windows.Forms.TextBox();
            this.txtNamaTujuan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_RekeningTujuan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_namaBank = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLanjut = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnKembali = new Guna.UI.WinForms.GunaAdvenceButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id.Location = new System.Drawing.Point(450, 113);
            this.lbl_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(49, 23);
            this.lbl_id.TabIndex = 47;
            this.lbl_id.Text = "lbl_id";
            this.lbl_id.Click += new System.EventHandler(this.lbl_id_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(328, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 23);
            this.label9.TabIndex = 46;
            this.label9.Text = "ID Nasabah   :";
            // 
            // lbl_idnasabah
            // 
            this.lbl_idnasabah.AutoSize = true;
            this.lbl_idnasabah.Location = new System.Drawing.Point(112, 67);
            this.lbl_idnasabah.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_idnasabah.Name = "lbl_idnasabah";
            this.lbl_idnasabah.Size = new System.Drawing.Size(0, 16);
            this.lbl_idnasabah.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(328, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 23);
            this.label7.TabIndex = 44;
            this.label7.Text = "Total Transfer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(652, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 23);
            this.label6.TabIndex = 43;
            this.label6.Text = "Biaya Admin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 23);
            this.label5.TabIndex = 42;
            this.label5.Text = "Masukkan Nominal";
            // 
            // txt_totaltransfer
            // 
            this.txt_totaltransfer.BackColor = System.Drawing.Color.White;
            this.txt_totaltransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_totaltransfer.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_totaltransfer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totaltransfer.Location = new System.Drawing.Point(332, 390);
            this.txt_totaltransfer.Name = "txt_totaltransfer";
            this.txt_totaltransfer.Size = new System.Drawing.Size(580, 34);
            this.txt_totaltransfer.TabIndex = 41;
            this.txt_totaltransfer.TextChanged += new System.EventHandler(this.txt_totaltransfer_TextChanged);
            // 
            // txt_biayaadmin
            // 
            this.txt_biayaadmin.BackColor = System.Drawing.Color.White;
            this.txt_biayaadmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_biayaadmin.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_biayaadmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_biayaadmin.Location = new System.Drawing.Point(656, 325);
            this.txt_biayaadmin.Name = "txt_biayaadmin";
            this.txt_biayaadmin.Size = new System.Drawing.Size(250, 27);
            this.txt_biayaadmin.TabIndex = 40;
            this.txt_biayaadmin.TextChanged += new System.EventHandler(this.txt_biayaadmin_TextChanged);
            // 
            // txt_nominaltransfer
            // 
            this.txt_nominaltransfer.BackColor = System.Drawing.Color.White;
            this.txt_nominaltransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nominaltransfer.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_nominaltransfer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nominaltransfer.Location = new System.Drawing.Point(332, 325);
            this.txt_nominaltransfer.Name = "txt_nominaltransfer";
            this.txt_nominaltransfer.Size = new System.Drawing.Size(250, 27);
            this.txt_nominaltransfer.TabIndex = 39;
            this.txt_nominaltransfer.TextChanged += new System.EventHandler(this.txt_nominaltransfer_TextChanged);
            // 
            // txtNamaTujuan
            // 
            this.txtNamaTujuan.BackColor = System.Drawing.Color.White;
            this.txtNamaTujuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNamaTujuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtNamaTujuan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaTujuan.Location = new System.Drawing.Point(656, 252);
            this.txtNamaTujuan.Name = "txtNamaTujuan";
            this.txtNamaTujuan.Size = new System.Drawing.Size(250, 27);
            this.txtNamaTujuan.TabIndex = 38;
            this.txtNamaTujuan.TabStop = false;
            this.txtNamaTujuan.TextChanged += new System.EventHandler(this.txtNamaTujuan_TextChanged);
            this.txtNamaTujuan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamaTujuan_KeyPress_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(652, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 23);
            this.label4.TabIndex = 37;
            this.label4.Text = "Nama Tujuan";
            // 
            // txt_RekeningTujuan
            // 
            this.txt_RekeningTujuan.BackColor = System.Drawing.Color.White;
            this.txt_RekeningTujuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RekeningTujuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_RekeningTujuan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RekeningTujuan.Location = new System.Drawing.Point(332, 252);
            this.txt_RekeningTujuan.Name = "txt_RekeningTujuan";
            this.txt_RekeningTujuan.Size = new System.Drawing.Size(250, 27);
            this.txt_RekeningTujuan.TabIndex = 36;
            this.txt_RekeningTujuan.TextChanged += new System.EventHandler(this.txt_RekeningTujuan_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 23);
            this.label3.TabIndex = 34;
            this.label3.Text = "No Rekening Tujuan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 33;
            this.label2.Text = "Nama Bank";
            // 
            // comboBox_namaBank
            // 
            this.comboBox_namaBank.BackColor = System.Drawing.Color.White;
            this.comboBox_namaBank.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_namaBank.Location = new System.Drawing.Point(332, 178);
            this.comboBox_namaBank.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_namaBank.Name = "comboBox_namaBank";
            this.comboBox_namaBank.Size = new System.Drawing.Size(574, 31);
            this.comboBox_namaBank.TabIndex = 31;
            this.comboBox_namaBank.SelectedIndexChanged += new System.EventHandler(this.comboBox_namaBank_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(414, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 41);
            this.label1.TabIndex = 32;
            this.label1.Text = "Transfer ke Penerima Baru";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1217, 603);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnLanjut
            // 
            this.btnLanjut.AnimationHoverSpeed = 0.07F;
            this.btnLanjut.AnimationSpeed = 0.03F;
            this.btnLanjut.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(109)))), ((int)(((byte)(231)))));
            this.btnLanjut.BorderColor = System.Drawing.Color.Black;
            this.btnLanjut.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnLanjut.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnLanjut.CheckedForeColor = System.Drawing.Color.White;
            this.btnLanjut.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnLanjut.CheckedImage")));
            this.btnLanjut.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnLanjut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLanjut.FocusedColor = System.Drawing.Color.Empty;
            this.btnLanjut.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLanjut.ForeColor = System.Drawing.Color.White;
            this.btnLanjut.Image = null;
            this.btnLanjut.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLanjut.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLanjut.Location = new System.Drawing.Point(332, 439);
            this.btnLanjut.Name = "btnLanjut";
            this.btnLanjut.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(200)))), ((int)(((byte)(251)))));
            this.btnLanjut.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLanjut.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLanjut.OnHoverImage = null;
            this.btnLanjut.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLanjut.OnPressedColor = System.Drawing.Color.Black;
            this.btnLanjut.Size = new System.Drawing.Size(580, 42);
            this.btnLanjut.TabIndex = 57;
            this.btnLanjut.Text = "Lanjut";
            this.btnLanjut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLanjut.Click += new System.EventHandler(this.btnLanjut_Click_1);
            // 
            // btnKembali
            // 
            this.btnKembali.AnimationHoverSpeed = 0.07F;
            this.btnKembali.AnimationSpeed = 0.03F;
            this.btnKembali.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(109)))), ((int)(((byte)(231)))));
            this.btnKembali.BorderColor = System.Drawing.Color.Black;
            this.btnKembali.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnKembali.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnKembali.CheckedForeColor = System.Drawing.Color.White;
            this.btnKembali.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnKembali.CheckedImage")));
            this.btnKembali.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnKembali.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnKembali.FocusedColor = System.Drawing.Color.Empty;
            this.btnKembali.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKembali.ForeColor = System.Drawing.Color.White;
            this.btnKembali.Image = ((System.Drawing.Image)(resources.GetObject("btnKembali.Image")));
            this.btnKembali.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKembali.ImageSize = new System.Drawing.Size(20, 20);
            this.btnKembali.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnKembali.Location = new System.Drawing.Point(23, 12);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(200)))), ((int)(((byte)(251)))));
            this.btnKembali.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnKembali.OnHoverForeColor = System.Drawing.Color.White;
            this.btnKembali.OnHoverImage = null;
            this.btnKembali.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnKembali.OnPressedColor = System.Drawing.Color.Black;
            this.btnKembali.Size = new System.Drawing.Size(56, 41);
            this.btnKembali.TabIndex = 58;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click_1);
            // 
            // fr_transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1217, 603);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.btnLanjut);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_idnasabah);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_totaltransfer);
            this.Controls.Add(this.txt_biayaadmin);
            this.Controls.Add(this.txt_nominaltransfer);
            this.Controls.Add(this.txtNamaTujuan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_RekeningTujuan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_namaBank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fr_transfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fr_transfer";
            this.Load += new System.EventHandler(this.fr_transfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_idnasabah;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_totaltransfer;
        private System.Windows.Forms.TextBox txt_biayaadmin;
        private System.Windows.Forms.TextBox txt_nominaltransfer;
        private System.Windows.Forms.TextBox txtNamaTujuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_RekeningTujuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_namaBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaAdvenceButton btnLanjut;
        private Guna.UI.WinForms.GunaAdvenceButton btnKembali;
    }
}