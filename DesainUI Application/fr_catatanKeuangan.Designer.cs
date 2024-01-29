namespace DesainUI_Application
{
    partial class fr_catatanKeuangan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_catatanKeuangan));
            this.gunaAdvenceButton1 = new Guna.UI.WinForms.GunaAdvenceButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lvwPengeluaran1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // gunaAdvenceButton1
            // 
            this.gunaAdvenceButton1.AnimationHoverSpeed = 0.07F;
            this.gunaAdvenceButton1.AnimationSpeed = 0.03F;
            this.gunaAdvenceButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(109)))), ((int)(((byte)(231)))));
            this.gunaAdvenceButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton1.CheckedBaseColor = System.Drawing.Color.Gray;
            this.gunaAdvenceButton1.CheckedBorderColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton1.CheckedForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton1.CheckedImage = ((System.Drawing.Image)(resources.GetObject("gunaAdvenceButton1.CheckedImage")));
            this.gunaAdvenceButton1.CheckedLineColor = System.Drawing.Color.DimGray;
            this.gunaAdvenceButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaAdvenceButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaAdvenceButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaAdvenceButton1.ForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaAdvenceButton1.Image")));
            this.gunaAdvenceButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaAdvenceButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaAdvenceButton1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.gunaAdvenceButton1.Location = new System.Drawing.Point(50, 22);
            this.gunaAdvenceButton1.Name = "gunaAdvenceButton1";
            this.gunaAdvenceButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(200)))), ((int)(((byte)(251)))));
            this.gunaAdvenceButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton1.OnHoverImage = null;
            this.gunaAdvenceButton1.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.gunaAdvenceButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton1.Size = new System.Drawing.Size(56, 41);
            this.gunaAdvenceButton1.TabIndex = 67;
            this.gunaAdvenceButton1.Click += new System.EventHandler(this.gunaAdvenceButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(491, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 29);
            this.label1.TabIndex = 71;
            this.label1.Text = "CATATAN KEUANGAN";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(616, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 48);
            this.button1.TabIndex = 70;
            this.button1.Text = "Pemasukkan";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(380, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 48);
            this.button2.TabIndex = 69;
            this.button2.Text = "Pengeluaran";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lvwPengeluaran1
            // 
            this.lvwPengeluaran1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lvwPengeluaran1.HideSelection = false;
            this.lvwPengeluaran1.Location = new System.Drawing.Point(75, 210);
            this.lvwPengeluaran1.Name = "lvwPengeluaran1";
            this.lvwPengeluaran1.Size = new System.Drawing.Size(1083, 347);
            this.lvwPengeluaran1.TabIndex = 68;
            this.lvwPengeluaran1.UseCompatibleStateImageBehavior = false;
            this.lvwPengeluaran1.SelectedIndexChanged += new System.EventHandler(this.lvwPengeluaran1_SelectedIndexChanged);
            // 
            // fr_catatanKeuangan
            // 
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1217, 603);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lvwPengeluaran1);
            this.Controls.Add(this.gunaAdvenceButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fr_catatanKeuangan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fr_CatatanKeuangan";
            this.Load += new System.EventHandler(this.fr_catatanKeuangan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       /* private Guna.UI.WinForms.GunaAdvenceButton btnKembali;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPemasukan;
        private System.Windows.Forms.Button btnPengeluaran;
        private System.Windows.Forms.ListView lvwPengeluaran;*/
        private Guna.UI.WinForms.GunaAdvenceButton gunaAdvenceButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView lvwPengeluaran1;
    }
}