using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesainUI_Application
{
    public partial class Fr_Daftar : Form
    {
        private DatabaseManager dbManager;
        private SQLiteConnection connection;

        public Fr_Daftar()
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();
        }


        private string GenerateRandomAccountNumber()
        {
            Random random = new Random();
            int accountNumber = random.Next(100000000, 999999999); // Generate a random 9-digit number

            return accountNumber.ToString();
        }

        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                // inputan selain angka
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void txtNIK_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtNohp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void Fr_Daftar_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;

            label9.Parent = pictureBox1;
            label9.BackColor = Color.Transparent;

            label10.Parent = pictureBox1;
            label10.BackColor = Color.Transparent;

            label11.Parent = pictureBox1;
            label11.BackColor = Color.Transparent;

            label12.Parent = pictureBox1;
            label12.BackColor = Color.Transparent;

            radioButton_L.Parent = pictureBox1;
            radioButton_L.BackColor = Color.Transparent;

            radioButton_P.Parent = pictureBox1;
            radioButton_P.BackColor = Color.Transparent;

            btnKembali.Parent = pictureBox1;
            btnKembali.BackColor = Color.Transparent;

            btnDaftar.Parent = pictureBox1;
            btnDaftar.BackColor = Color.Transparent;

        }

        private void txtNIK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTL_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_tgllahir_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_L_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_P_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNohp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            txtNIK.Clear();
            txtNama.Clear();
            txtTL.Clear();
            dateTimePicker_tgllahir.Value = DateTime.Now; // Mengatur tanggal ke nilai default
            radioButton_L.Checked = false; // Mereset RadioButton ke default
            radioButton_P.Checked = false; // Mereset RadioButton ke default
            txtAlamat.Clear();
            txtNohp.Clear();
            txtEmail.Clear();
            txt_Username.Clear();
            txt_Password.Clear();
            txtPin.Clear();
            txtNIK.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDaftar_Click_1(object sender, EventArgs e)
        {

            var result = 0;
            // validasi nik harus diisi
            if (string.IsNullOrEmpty(txtNIK.Text))
            {
                MessageBox.Show("NIK harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtNIK.Focus();
                return;
            }
            // validasi nama harus diisi
            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtNama.Focus();
                return;
            }
            // validasi tempatlahir harus diisi
            if (string.IsNullOrEmpty(txtTL.Text))
            {
                MessageBox.Show("Tempat Lahir harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtTL.Focus();
                return;
            }
            // validasi tanggallahir harus diisi
            if (string.IsNullOrEmpty(dateTimePicker_tgllahir.Text))
            {
                MessageBox.Show("Tanggal Lahir harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                dateTimePicker_tgllahir.Focus();
                return;
            }
            // validasi Jenis Kelamin harus diisi
            if (!radioButton_L.Checked && !radioButton_P.Checked)
            {
                MessageBox.Show("Jenis Kelamin harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            // validasi alamat harus diisi
            if (string.IsNullOrEmpty(txtAlamat.Text))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtAlamat.Focus();
                return;
            }
            // validasi no hp harus diisi
            if (string.IsNullOrEmpty(txtNohp.Text))
            {
                MessageBox.Show("Nomor HP harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtNohp.Focus();
                return;
            }
            // validasi email harus diisi
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtEmail.Focus();
                return;
            }
            // validasi username harus diisi
            if (string.IsNullOrEmpty(txt_Username.Text))
            {
                MessageBox.Show("Email harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txt_Username.Focus();
                return;
            }
            // validasi password harus diisi
            if (string.IsNullOrEmpty(txt_Password.Text))
            {
                MessageBox.Show("Password harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txt_Password.Focus();
                return;
            }
            // validasi pin ATM harus diisi
            if (string.IsNullOrEmpty(txtPin.Text))
            {
                MessageBox.Show("ATM Pin harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtPin.Focus();
                return;
            }

            if (txtPin.Text.Length != 6)
            {
                MessageBox.Show("ATM PIN harus terdiri dari 6 digit!", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPin.Focus();
                return;
            }



            string randomAccountNumber = GenerateRandomAccountNumber();

            SQLiteConnection conn = dbManager.GetConnection();
            dbManager.OpenConnection();

            var sql = @"INSERT INTO Nasabah (NIK, nama, alamat, tempatLahir, tgllahir, jeniskelamin, noHP, email, username, password, pinATM, norekening, saldo) VALUES (@NIK, @nama, @alamat, @tempatLahir, @tgllahir, @jeniskelamin, @noHP, @email, @username, @password, @pinATM, @norekening, @saldo)";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            try
            {
                // set parameter 
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@tempatLahir", txtTL.Text);
                cmd.Parameters.AddWithValue("@tgllahir", dateTimePicker_tgllahir.Value);
                string jenisKelamin = radioButton_L.Checked ? "Laki-laki" : "Perempuan";
                cmd.Parameters.AddWithValue("@jeniskelamin", jenisKelamin);
                cmd.Parameters.AddWithValue("@noHP", txtNohp.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                cmd.Parameters.AddWithValue("@norekening", randomAccountNumber);
                cmd.Parameters.AddWithValue("@saldo", 500000);
                cmd.Parameters.AddWithValue("@pinATM", txtPin.Text);

                result = cmd.ExecuteNonQuery(); // eksekusi perintah INSERT
                if (result > 0)
                {

                    MessageBox.Show("Data Nasabah berhasil disimpan !",
                    "Informasi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Data nasabah gagal disimpan !!!",
                    "Informasi", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
                // setelah selesai digunakan,
                // segera hapus objek connection dari memory
            }



            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }

        private void btnKembali_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            fr_login fr_Login = new fr_login();
            fr_Login.ShowDialog();
            this.Close();
        }
    }
}