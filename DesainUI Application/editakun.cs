using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace DesainUI_Application
{
    public partial class editakun : Form
    {
        private infoakun infoForm;
        private SQLiteConnection connection;
        private DatabaseManager dbManager;
        public editakun(infoakun infoForm, string id, string nama, string noHp, string email, string username, string password, string pinATM)
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();
            this.infoForm = infoForm;

            txtID.Text = id;
            txtID.ReadOnly = true;
            txtNama.Text = nama;
            txtNohp.Text = noHp;
            txtEmail.Text = email;
            txt_Username.Text = username;
            txt_Password.Text = password;
            txtPin.Text = pinATM;
        }

        /*private void ClearForm()
        { 
            txtNama.Clear();
            txtNohp.Clear();
            txtEmail.Clear();
            txt_Username.Clear();
            txtPin.Clear();
        }*/

        public string Nama
        {
            get { return txtNama.Text; }
            set { txtNama.Text = value; }
        }

        public string NoHp
        {
            get { return txtNohp.Text; }
            set { txtNohp.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string Username
        {
            get { return txt_Username.Text; }
            set { txt_Username.Text = value; }
        }

        public string Password
        {
            get { return txt_Password.Text; }
            set { txt_Password.Text = value; }
        }

        public string Pin
        {
            get { return txtPin.Text; }
            set { txtPin.Text = value; }
        }

        public string ID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        private void editakun_Load(object sender, EventArgs e)
        {

        }

       


        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNohp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            var result = 0;

            // validasi nama harus diisi
            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtNama.Focus();
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
                MessageBox.Show("Username harus diisi !!!", "Informasi",
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
                txtPin.Focus();
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

            SQLiteConnection conn = dbManager.GetConnection();
            dbManager.OpenConnection();

            var sql = @"UPDATE Nasabah 
                         SET nama = @nama, 
                             email = @email, 
                             username = @username, 
                             password = @password, 
                             noHp = @noHp, 
                             pinATM = @pinATM
                         WHERE id_nasabah= @id_nasabah";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            try
            {


                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                cmd.Parameters.AddWithValue("@noHp", txtNohp.Text);
                cmd.Parameters.AddWithValue("@pinATM", txtPin.Text);
                cmd.Parameters.AddWithValue("@id_nasabah", txtID.Text);


                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                dbManager.CloseConnection();
            }

            // Check the result and show appropriate message
            if (result > 0)
            {
                MessageBox.Show("Update Berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Panggil metode pada form infoakun untuk menampilkannya kembali
                infoForm.RefreshInfoAkun();
                infoForm.Show();

                // Anda dapat menambahkan logika tambahan di sini setelah pembaruan berhasil
            }
            else
            {
                MessageBox.Show("Update Gagal", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
